using System;

namespace Config.Model
{
    [Serializable]
    public class Comment
    {
        public string ColumnName { get; set; }
        public string Description { get; set; }
    }
}
