using System;

namespace Config.Model
{
    [Serializable]
    public class Constraint
    {
        public string ConstraintType { get; set; }
        public string ConstraintName { get; set; }
        public string Columns { get; set; }
    }
}
