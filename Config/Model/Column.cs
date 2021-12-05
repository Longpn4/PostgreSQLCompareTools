using System;

namespace Config.Model
{
    [Serializable]
    public class Column
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }
        public string IsNullable { get; set; }
        public string MaxLength { get; set; }
        public string DatetimePrecision { get; set; }
    }
}
