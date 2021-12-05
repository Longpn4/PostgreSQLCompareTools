using System.Collections.Generic;

namespace Config.BLL
{
    public class Constant
    {
        public static List<string> listSpecial = new List<string>() { "analyse", "analyze", "and", "any", "array", "as", "asc", "asymmetric", "authorization", "between", "bigint", "binary", "bit", "boolean", "both", "case", "cast", "char", "character", "check", "coalesce", "collate", "collation", "column", "concurrently", "constraint", "create", "cross", "current_catalog", "current_date", "current_role", "current_schema", "current_time", "current_timestamp", "current_user", "dec", "decimal", "default", "deferrable", "desc", "distinct", "do", "else", "end", "except", "exists", "extract", "false", "fetch", "float", "for", "foreign", "freeze", "from", "full", "grant", "greatest", "group", "grouping", "having", "ilike", "in", "initially", "inner", "inout", "int", "integer", "intersect", "interval", "into", "is", "isnull", "join", "lateral", "leading", "least", "left", "like", "limit", "localtime", "localtimestamp", "national", "natural", "nchar", "none", "not", "notnull", "null", "nullif", "numeric", "offset", "on", "only", "or", "order", "out", "outer", "overlaps", "overlay", "placing", "position", "precision", "primary", "real", "references", "returning", "right", "row", "select", "session_user", "setof", "similar", "smallint", "some", "substring", "symmetric", "table", "tablesample", "then", "time", "timestamp", "to", "trailing", "treat", "trim", "true", "union", "unique", "user", "using", "values", "varchar", "variadic", "verbose", "when", "where", "window", "with", "xmlattributes", "xmlconcat", "xmlelement", "xmlexists", "xmlforest", "xmlparse", "xmlpi", "xmlroot", "xmlserialize" };

        public static int TYPE_FUNCTION = 1;
        public static int TYPE_TABLE = 2;
        public static bool ShowWaiting = false;

        public static int Img_NewConnection = 16;
        public static int Img_NewFolder = 14;
        public static int Img_Connection = 23;
        public static int Img_ConnectionSuccess = 18;

        //Show cac file Backup trong tab Compare database
        public static bool SHOW_FILE_BACKUP_IN_COMPARE = true;

        //Show cac file Backup trong tab Compare database
        public static bool REFRESH_DATABASE_BEFORE_COMPARE = true;

        //Auto check to compare
        public static bool AUTO_CHECK_COMBOBOX_TO_COMPARE = true;
    }
}
