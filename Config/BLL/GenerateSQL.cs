using Config.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Config.BLL
{
    public static class GenerateSQL
    {
        public static string getColumnName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            if (Constant.listSpecial.Contains(name.ToLower()))
            {
                return "\"" + name + "\"";
            }

            return name;
        }

        public static void generateCodeCreateTable(Table table)
        {
            var stringBuilder = new StringBuilder();
            //stringBuilder.Append(string.Format(" DROP TABLE IF EXISTS public.{0}; " + System.Environment.NewLine, tableName));
            stringBuilder.Append(string.Format("CREATE TABLE public.{0} ( " + System.Environment.NewLine, table.TableName));

            var lstField = new List<string>();

            foreach (var item in table.ListColumn)
            {
                if (!string.IsNullOrWhiteSpace(item.DefaultValue) && item.DefaultValue.ToLower().Contains("nextval"))
                {
                    if (getTypeString(item.DataType.ToLower(), item.MaxLength, item.DatetimePrecision) == "integer")
                    {
                        lstField.Add(string.Format("  {0} {1}", getColumnName(item.ColumnName), "serial"));
                    }
                    else if (getTypeString(item.DataType.ToLower(), item.MaxLength, item.DatetimePrecision) == "bigint")
                    {
                        lstField.Add(string.Format("  {0} {1}", getColumnName(item.ColumnName), "bigserial"));
                    }
                }
                else
                {
                    lstField.Add(string.Format("  {0} {1} {2} {3}", getColumnName(item.ColumnName), getTypeString(item.DataType.ToLower(), item.MaxLength, item.DatetimePrecision),
                        !string.IsNullOrWhiteSpace(item.DefaultValue) ? "default " + item.DefaultValue : string.Empty,
                        item.IsNullable == "no" ? "not null" : string.Empty));
                }
            }

            foreach (var item in table.ListConstraint)
            {
                lstField.Add(string.Format("  CONSTRAINT {0} {1}{2}", "\"" + item.ConstraintName + "\"", item.ConstraintType, item.Columns));
            }

            lstField = lstField.Select(s => s = s.TrimEnd()).ToList();

            stringBuilder.Append(string.Join("," + System.Environment.NewLine, lstField));
            stringBuilder.Append(System.Environment.NewLine);
            stringBuilder.Append(")" + System.Environment.NewLine);
            stringBuilder.AppendLine("WITH (oids = false);");
            stringBuilder.AppendLine();

            foreach (var item in table.ListComment)
            {
                stringBuilder.AppendLine(string.Format("COMMENT ON COLUMN public.{0}.{1}", table.TableName, getColumnName(item.ColumnName)));
                stringBuilder.AppendLine(string.Format("IS '{0}';", item.Description));
            }

            table.Code = stringBuilder.ToString();

        }

        public static string generateCreateTable(Table table)
        {
            if (table == null)
            {
                return string.Empty;
            }

            return table.Code;
        }

        public static string generateUpdateTable(Table table)
        {
            if (table == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(System.Environment.NewLine);
            stringBuilder.Append(@"/*  Script update bảng  */" + System.Environment.NewLine);
            stringBuilder.Append(string.Format("CREATE OR REPLACE FUNCTION public.{0}_update ( " + System.Environment.NewLine, table.TableName));

            stringBuilder.Append(string.Join("," + System.Environment.NewLine, table.ListColumn.Select(s => "    _" + s.ColumnName.ToString() + " " + GetDataTypeName(s.DataType.ToString()))));

            stringBuilder.Append(" ) " + System.Environment.NewLine);
            stringBuilder.Append(" RETURNS void AS  " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" BEGIN " + System.Environment.NewLine);

            stringBuilder.Append(string.Format(" UPDATE public.{0} ", table.TableName) + System.Environment.NewLine);
            stringBuilder.Append(" SET " + System.Environment.NewLine);

            stringBuilder.Append(string.Join(" ," + System.Environment.NewLine, table.ListColumn.Where(s => s.ColumnName != "id").Select(s => getColumnName(s.ColumnName) + " = _" + s.ColumnName)));

            stringBuilder.Append(System.Environment.NewLine);
            stringBuilder.Append(" WHERE id = _id ;" + System.Environment.NewLine);

            stringBuilder.Append(" END; " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" LANGUAGE plpgsql;" + System.Environment.NewLine);
            stringBuilder.Append(System.Environment.NewLine);

            return stringBuilder.ToString();
        }

        public static string generateInsertNoReturn(Table table)
        {
            if (table == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(System.Environment.NewLine);
            stringBuilder.Append(@"/*  Script thêm mới không trả về id  */" + System.Environment.NewLine);
            stringBuilder.Append(string.Format("CREATE OR REPLACE FUNCTION public.{0}_insert ( " + System.Environment.NewLine, table.TableName));

            var lstColumn = table.ListColumn.Where(s => s.ColumnName != "id");

            stringBuilder.Append(string.Join(", " + System.Environment.NewLine, lstColumn.Select(s => "_" + s.ColumnName.ToString() + " " + GetDataTypeName(s.DataType.ToString()))));
            stringBuilder.Append(" ) " + System.Environment.NewLine);
            stringBuilder.Append(" RETURNS void AS  " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" BEGIN " + System.Environment.NewLine);

            stringBuilder.Append(string.Format(" INSERT INTO public.{0}( {1} ) ", table.TableName, string.Join(", ", lstColumn.Select(s => getColumnName(s.ColumnName)))) + System.Environment.NewLine);

            stringBuilder.Append(string.Format(" VALUES ( {0} ) ;", string.Join(", ", lstColumn.Select(s => "_" + s.ColumnName.ToString()))) + System.Environment.NewLine);

            stringBuilder.Append(" END; " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" LANGUAGE plpgsql; " + System.Environment.NewLine);
            stringBuilder.Append(System.Environment.NewLine);

            return stringBuilder.ToString();
        }

        public static string generateInsertReturnId(Table table)
        {
            if (table == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            var lstColumn = table.ListColumn.Where(s => s.ColumnName != "id");
            var columId = table.ListColumn.SingleOrDefault(s => s.ColumnName == "id");

            stringBuilder.Append(System.Environment.NewLine);
            stringBuilder.Append(@"/*  Script thêm mới vào bảng trả về id  */" + System.Environment.NewLine);
            stringBuilder.Append(string.Format("CREATE OR REPLACE FUNCTION public.{0}_insert ( " + System.Environment.NewLine, table.TableName));

            stringBuilder.Append(string.Join("," + System.Environment.NewLine, lstColumn.Select(s => "    _" + s.ColumnName.ToString() + " " + GetDataTypeName(s.DataType.ToString()))));
            stringBuilder.Append(string.Format("," + System.Environment.NewLine + "    {0} {1}", "_id", columId.DataType));

            stringBuilder.Append(" ) " + System.Environment.NewLine);
            stringBuilder.Append(" RETURNS " + columId.DataType + " AS " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" DECLARE _id " + columId.DataType + " ;" + System.Environment.NewLine);
            stringBuilder.Append(" BEGIN " + System.Environment.NewLine);

            stringBuilder.Append(string.Format(" INSERT INTO public.{0}( {1} ) ", table.TableName, string.Join(", ", lstColumn.Select(s => getColumnName(s.ColumnName)))) + System.Environment.NewLine);
            stringBuilder.Append(string.Format(" VALUES ( {0} ) ", string.Join(", ", lstColumn.Select(s => "_" + s.ColumnName.ToString()))) + System.Environment.NewLine);

            stringBuilder.Append(" RETURNING id INTO _id; " + System.Environment.NewLine);
            stringBuilder.Append(" RETURN _id; " + System.Environment.NewLine);
            stringBuilder.Append(" END; " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" LANGUAGE 'plpgsql' " + System.Environment.NewLine);
            stringBuilder.Append(" VOLATILE " + System.Environment.NewLine);
            stringBuilder.Append(" CALLED ON NULL INPUT " + System.Environment.NewLine);
            stringBuilder.Append(" SECURITY INVOKER " + System.Environment.NewLine);
            stringBuilder.Append(" COST 100; " + System.Environment.NewLine);

            return stringBuilder.ToString();
        }

        public static string generateDeleteById(Table table)
        {
            if (table == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(System.Environment.NewLine);
            stringBuilder.Append(@"/*  Script delete bản ghi theo id  */" + System.Environment.NewLine);
            stringBuilder.Append(string.Format("CREATE OR REPLACE FUNCTION public.{0}_delete ( " + System.Environment.NewLine, table.TableName));

            stringBuilder.Append(string.Format("    {0} {1}", "_id", table.ListColumn.SingleOrDefault(a => a.ColumnName == "id").DataType));

            stringBuilder.Append(" ) " + System.Environment.NewLine);
            stringBuilder.Append(" RETURNS void AS  " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" BEGIN " + System.Environment.NewLine);

            stringBuilder.Append(string.Format(" DELETE FROM public.{0} ", table.TableName) + System.Environment.NewLine);
            stringBuilder.Append(" WHERE id = _id ;" + System.Environment.NewLine);

            stringBuilder.Append(" END; " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" LANGUAGE plpgsql;" + System.Environment.NewLine);
            stringBuilder.Append(System.Environment.NewLine);

            return stringBuilder.ToString();
        }

        public static string generateGetListCondition(Table table, bool ckPaging, ListBox lbConditions, ListBox lbColumGet)
        {
            if (table == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            //var lstColumn = listColumns.Where(s => s.Key != "id");


            stringBuilder.Append(System.Environment.NewLine);
            stringBuilder.Append(@"/*  Script thêm mới get list có condition  */" + System.Environment.NewLine);

            //Check các điều kiện


            //lsCondition.Add(string.Format("{0} {1}", "_pageindex", "integer"));
            //lsCondition.Add(string.Format("{0} {1}", "_pagesize", "integer"));

            var condition = string.Empty;
            if (ckPaging)
            {
                condition = "paging";
            }
            else if (lbConditions.SelectedItems.Count == 0)
            {
                condition = "non";
            }

            //Nếu không chọn các cột cần lấy, thì get tất
            var lsSelect = lbConditions.SelectedItems.Cast<Column>().Select(s => "_" + s.ColumnName + " " + GetDataTypeName(table.ListColumn.SingleOrDefault(a => a.ColumnName == s.ColumnName)?.DataType)).ToList();

            if (ckPaging)
            {
                lsSelect.Add("_pageindex integer");
                lsSelect.Add("_pagesize integer");
            }

            stringBuilder.Append(string.Format("CREATE OR REPLACE FUNCTION public.{0}_getlist_" + condition + " ( " + System.Environment.NewLine, table.TableName));
            stringBuilder.Append(string.Join("," + System.Environment.NewLine, lsSelect.Select(s => "    " + s.ToString())));
            stringBuilder.Append(" ) " + System.Environment.NewLine);

            stringBuilder.Append("  RETURNS TABLE(" + System.Environment.NewLine);

            //Nếu không chọn các cột cần lấy, thì get tất
            if (lbColumGet.SelectedItems.Count > 0)
            {
                stringBuilder.Append(string.Join("," + System.Environment.NewLine, lbColumGet.SelectedItems.Cast<Column>().ToList().Select(s => "    " + getColumnName(s.ColumnName) + " " + table.ListColumn.SingleOrDefault(a => a.ColumnName == s.ColumnName)?.DataType)));
            }
            else
            {
                stringBuilder.Append(string.Join("," + System.Environment.NewLine, table.ListColumn.Select(s => "    " + getColumnName(s.ColumnName) + " " + GetDataTypeName(s.DataType))));
            }

            stringBuilder.Append(" ) " + System.Environment.NewLine);

            stringBuilder.Append("  AS " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" BEGIN " + System.Environment.NewLine);

            stringBuilder.Append("  RETURN QUERY" + System.Environment.NewLine);
            stringBuilder.Append("  SELECT " + System.Environment.NewLine);


            if (lbColumGet.SelectedItems.Count > 0)
            {
                stringBuilder.Append(string.Join("," + System.Environment.NewLine, lbColumGet.SelectedItems.Cast<Column>().ToList().Select(s => "    " + s.ColumnName)));
            }
            else
            {
                stringBuilder.Append(string.Join(", " + System.Environment.NewLine, table.ListColumn.Select(s => "    " + getColumnName(s.ColumnName))));
            }

            stringBuilder.Append(string.Format(" FROM   public.{0} ", table.TableName));

            if (lbConditions.SelectedItems.Count > 0)
            {
                stringBuilder.Append("  WHERE " + System.Environment.NewLine);
                stringBuilder.Append(string.Join(System.Environment.NewLine + " AND", lbConditions.SelectedItems.Cast<Column>().ToList().Select(s => "    " + getColumnName(s.ColumnName) + " = _" + s.ColumnName)));
            }

            if (ckPaging)
            {
                stringBuilder.Append(System.Environment.NewLine + "  LIMIT _pagesize");
                stringBuilder.Append(System.Environment.NewLine + "  OFFSET _pagesize*(_pageindex -1)");
            }

            stringBuilder.Append("; " + System.Environment.NewLine);
            stringBuilder.Append(" END; " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" LANGUAGE 'plpgsql' " + System.Environment.NewLine);
            stringBuilder.Append(" VOLATILE " + System.Environment.NewLine);
            stringBuilder.Append(" CALLED ON NULL INPUT " + System.Environment.NewLine);
            stringBuilder.Append(" SECURITY INVOKER " + System.Environment.NewLine);
            stringBuilder.Append(" COST 100 ROWS 1000;" + System.Environment.NewLine);

            return stringBuilder.ToString();
        }

        public static string generateGetCount(Table table, bool ckOrCondition, ListBox lbConditions)
        {
            if (table == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(System.Environment.NewLine);
            stringBuilder.Append(@"/*  Script thêm mới get list có condition  */" + System.Environment.NewLine);

            var condition = string.Empty;
            if (lbConditions.SelectedItems.Count == 0)
            {
                condition = "non";
            }

            //Nếu không chọn các cột cần lấy, thì get tất
            var lsSelect = lbConditions.SelectedItems.Cast<Column>().Select(s => "_" + s.ColumnName + " " + table.ListColumn.SingleOrDefault(a => a.ColumnName == s.ColumnName).DataType)?.ToList();

            stringBuilder.Append(string.Format("CREATE OR REPLACE FUNCTION public.{0}_getcount_" + condition + " ( " + System.Environment.NewLine, table.TableName));
            stringBuilder.Append(string.Join("," + System.Environment.NewLine, lsSelect.Select(s => "    " + s.ToString())));
            stringBuilder.Append(" ) " + System.Environment.NewLine);

            stringBuilder.Append("  RETURNS integer" + System.Environment.NewLine);
            stringBuilder.Append("  AS" + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" DECLARE _count INTEGER; " + System.Environment.NewLine);
            stringBuilder.Append(" BEGIN " + System.Environment.NewLine);

            stringBuilder.Append("    SELECT COUNT(1) INTO _count from public." + table.TableName + System.Environment.NewLine);

            if (lbConditions.SelectedItems.Count > 0)
            {
                stringBuilder.Append("  WHERE " + System.Environment.NewLine);

                if (ckOrCondition)
                {
                    stringBuilder.Append(string.Join(System.Environment.NewLine + " AND", lbConditions.SelectedItems.Cast<Column>().ToList().Select(s => "    (_" + s.ColumnName + " = " + (table.ListColumn.SingleOrDefault(a => a.ColumnName == s.ColumnName)?.DataType == "varchar" ? "''" : "-1") + " OR _" + s + " = " + s + ")")));
                }
                else
                {
                    stringBuilder.Append(string.Join(System.Environment.NewLine + " AND", lbConditions.SelectedItems.Cast<Column>().ToList().Select(s => "    " + s.ColumnName + " = _" + s.ColumnName)));
                }
            }

            stringBuilder.Append("; " + System.Environment.NewLine);
            stringBuilder.Append("  RETURN _count;" + System.Environment.NewLine);
            stringBuilder.Append(" END; " + System.Environment.NewLine);
            stringBuilder.Append(" $body$ " + System.Environment.NewLine);
            stringBuilder.Append(" LANGUAGE 'plpgsql' " + System.Environment.NewLine);
            stringBuilder.Append(" VOLATILE " + System.Environment.NewLine);
            stringBuilder.Append(" CALLED ON NULL INPUT " + System.Environment.NewLine);
            stringBuilder.Append(" SECURITY INVOKER " + System.Environment.NewLine);
            stringBuilder.Append(" COST 100;" + System.Environment.NewLine);

            return stringBuilder.ToString();
        }

        public static string getTypeString(string type, string maxlength, string datetimePrecision)
        {
            if (type.ToLower() == "character varying")
            {
                return !string.IsNullOrWhiteSpace(maxlength) ? "varchar(" + maxlength + ")" : "varchar";
            }

            if (type.ToLower().Contains("timestamp"))
            {
                return datetimePrecision == "0" ? "timestamp(0) without time zone" : "timestamp without time zone";
            }

            return type;
        }

        public static string GetDataTypeName(string type)
        {
            if (type.Contains("character"))
            {
                return "varchar";
            }
            else if (type.Contains("timestamp"))
            {
                return "timestamp";
            }

            return type;
        }
    }
}
