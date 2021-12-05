using Config.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Config.BLL
{
    public class DatabaseBLL
    {

        public NpgsqlCommand CreateCommand(string sqlText, string connection)
        {
            NpgsqlConnection _connection = new NpgsqlConnection(connection);
            _connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlText, _connection);
            cmd.CommandText = sqlText;
            return cmd;
        }

        public string getStringObject(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }

        public bool getDatabaseInfo(DatabaseInfo database, bool isCache = true)
        {
            bool flag = false;
            try
            {
                if (database == null || database.ListTable == null || database.ListTable.Count() <= 0 || !isCache)
                {

                    List<Table> listTable = new List<Table>();
                    List<Column> ListColumn = new List<Column>();
                    List<Constraint> ListConstraint = new List<Constraint>();

                    using (NpgsqlCommand command = CreateCommand(
                          @"SELECT  c.table_name, 
		                        c.column_name as ColumnName,
                                c.udt_name::regtype::text,
                                column_default as DefaultValue,
                                is_nullable as IsNullable,
                                character_maximum_length as MaxLength,
                                datetime_precision as DatetimePrecision
                        FROM information_schema.columns c, 
	                        (SELECT table_name FROM information_schema.tables WHERE table_type='BASE TABLE' 
    	                        AND table_schema='public' order by table_name) t
                        WHERE
                        c.table_schema not in ('pg_catalog', 'information_schema') and
                        c.table_name = t.table_name ORDER BY c.table_name, ordinal_position", database.Connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var tableName = reader.GetValue(0).ToString();

                                    var table = listTable.SingleOrDefault(s => s.TableName == tableName);
                                    if (table == null)
                                    {
                                        table = new Table() { TableName = tableName };
                                        listTable.Add(table);
                                    }

                                    table.ListColumn.Add(new Column()
                                    {
                                        ColumnName = getStringObject(reader.GetValue(1)),
                                        DataType = getStringObject(reader.GetValue(2)),
                                        DefaultValue = getStringObject(reader.GetValue(3)),
                                        IsNullable = getStringObject(reader.GetValue(4)),
                                        MaxLength = getStringObject(reader.GetValue(5)),
                                        DatetimePrecision = getStringObject(reader.GetValue(6))
                                    });
                                }
                            }
                        }
                    }

                    getListConstraint(listTable, database.Connection);
                    getListFunction(database);
                    getListComment(listTable, database.Connection);

                    //listTable.ForEach(table => table.ListComment = table.ListComment.OrderBy(c => c.ColumnName).ToList());

                    listTable.ForEach(item =>
                    {
                        GenerateSQL.generateCodeCreateTable(item);
                    });

                    database.ListTable = listTable;
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return flag;
        }

        private void getListConstraint(List<Table> listTable, string connection)
        {
            using (NpgsqlCommand command = CreateCommand(
                 @"select distinct tc.table_name, tc.constraint_type,
                           tc.constraint_name,
                           (
                             select '(' || string_agg(b.column_name, ', '
                             order by b.ordinal_position, a.constraint_name) || ')' as code
                             from information_schema.table_constraints a
                                  join information_schema.key_column_usage b on b.table_name =
                                    a.table_name and b.table_schema = a.table_schema and
                                    b.constraint_name = a.constraint_name and 
                                    b.constraint_name = tc.constraint_name
                             where 1 = 1 and
                                   a.table_name = tc.table_name and a.table_name = t.table_name and
                                   b.ordinal_position is not null
                           ) as columns
                    from information_schema.table_constraints tc
                         join information_schema.key_column_usage kc on kc.table_name =
                           tc.table_name and kc.table_schema = tc.table_schema and
                           kc.constraint_name = tc.constraint_name
                         inner JOIN (SELECT table_name FROM information_schema.tables WHERE table_type='BASE TABLE' AND table_schema='public' order by table_name) as t
                         on tc.table_name = t.table_name
                    where 1 = 1 and
                          tc.constraint_schema not in ('pg_catalog', 'information_schema') and
                          kc.ordinal_position is not null
                    order by tc.table_name , tc.constraint_type,
                             tc.constraint_name ", connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listTable.SingleOrDefault(s => s.TableName == getStringObject(reader.GetValue(0))).ListConstraint.Add(new Constraint()
                            {
                                ConstraintType = getStringObject(reader.GetValue(1)),
                                ConstraintName = getStringObject(reader.GetValue(2)),
                                Columns = getStringObject(reader.GetValue(3)),
                            });
                        }
                    }
                }
            }
        }

        private void getListComment(List<Table> listTable, string connection)
        {
            using (NpgsqlCommand command = CreateCommand(
                 @"select st.relname as TableName, c.column_name, pgd.description
                    from pg_catalog.pg_statio_all_tables as st
                         inner join information_schema.columns c on c.table_schema = st.schemaname
                           and c.table_name = st.relname
                         inner join pg_catalog.pg_description pgd on pgd.objoid = st.relid and
                           pgd.objsubid = c.ordinal_position AND c.table_schema = 'public' 
                         order by st.relname , c.column_name", connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listTable.SingleOrDefault(s => s.TableName == getStringObject(reader.GetValue(0))).ListComment.Add(new Comment()
                            {
                                ColumnName = getStringObject(reader.GetValue(1)),
                                Description = getStringObject(reader.GetValue(2))
                            });
                        }
                    }
                }
            }
        }

        public void getListFunction(DatabaseInfo database)
        {
            List<Function> listFunction = new List<Function>();
            using (NpgsqlCommand command = CreateCommand(
               @"select p.oid as Id,
                            format('%I.%I(%s)', n.nspname, p.proname, oidvectortypes(p.proargtypes)) as Name,
                            case when l.lanname = 'internal' then p.prosrc
                                else pg_get_functiondef(p.oid)
                                end as Code,
                                t.typname as Return
                    from pg_proc p
                        left join pg_namespace n on p.pronamespace = n.oid
                        left join pg_language l on p.prolang = l.oid
                        left join pg_type t on t.oid = p.prorettype 
                        where n.nspname not in ('pg_catalog', 'information_schema')
                        order by Name", database.Connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listFunction.Add(new Function()
                            {
                                Id = getStringObject(reader.GetValue(0)),
                                Name = getStringObject(reader.GetValue(1)),
                                Code = getStringObject(reader.GetValue(2)),
                                Return = getStringObject(reader.GetValue(3))
                            });
                        }
                    }
                }

                database.ListFunction = listFunction;
            }
        }

        public void ExecuteSql(ResultExecute executeInfo)
        {
            if (!string.IsNullOrWhiteSpace(executeInfo.Connection))
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(executeInfo.Connection))
                {
                    NpgsqlCommand command;
                    try
                    {
                        connection.Open();
                        command = new NpgsqlCommand(executeInfo.Query, connection);
                        command.ExecuteNonQuery();
                        executeInfo.Result = true;
                    }
                    catch (Exception ex)
                    {
                        executeInfo.Result = false;
                        executeInfo.Message = ex.ToString();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void ExecuteMultiSql(List<ResultExecute> listExecute, string Connection)
        {
            if (!string.IsNullOrWhiteSpace(Connection))
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Connection))
                {
                    try
                    {
                        connection.Open();
                        NpgsqlCommand command = new NpgsqlCommand();
                        command.Connection = connection;

                        foreach (var execute in listExecute)
                        {
                            if (!string.IsNullOrWhiteSpace(execute.Query))
                            {
                                try
                                {
                                    command.CommandText = execute.Query;
                                    command.ExecuteNonQuery();
                                    execute.Result = true;
                                }
                                catch (Exception ex)
                                {
                                    execute.Result = false;
                                    execute.Message = ex.ToString();
                                }
                            }
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
