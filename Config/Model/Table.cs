using System;
using System.Collections.Generic;

namespace Config.Model
{
    [Serializable]
    public class Table
    {
        public string TableName { get; set; }
        public string Code { get; set; }
        public List<Column> ListColumn { get; set; }
        public List<Constraint> ListConstraint { get; set; }
        public List<Comment> ListComment { get; set; }

        public Table()
        {
            ListColumn = new List<Column>();
            ListConstraint = new List<Constraint>();
            ListComment = new List<Comment>();
        }
    }
}
