using System;
using System.Collections.Generic;

namespace Config.Model
{
    [Serializable]
    public class DatabaseNode
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public string Connection { get; set; }
        public int ImageIndex { get; set; }
        public int SelectedImageIndex { get; set; }
        public List<DatabaseNode> ListNode { get; set; }
    }

    [Serializable]
    public class Database
    {
        public string Name { get; set; }
        public string Connection { get; set; }
    }

    [Serializable]
    public class DatabaseInfo
    {
        public string Name { get; set; }
        public string Connection { get; set; }
        public List<Table> ListTable { get; set; }
        public List<Function> ListFunction { get; set; }

        public DatabaseInfo()
        {
            ListTable = new List<Table>();
            ListFunction = new List<Function>();
        }

        public DatabaseInfo(Database db)
        {
            Name = db.Name;
            Connection = db.Connection;
            ListTable = new List<Table>();
            ListFunction = new List<Function>();
        }
    }

    [Serializable]
    public class DatabaseFileInfo : DatabaseInfo
    {
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }

        public DatabaseFileInfo(DatabaseInfo db)
        {
            Name = db.Name;
            Connection = db.Connection;
            ListTable = new List<Table>();
            ListFunction = new List<Function>();

            try
            {
                this.FileName = db.Name.Substring(0, db.Name.Length - 24);
                //this.CreateDate = db.Name.Substring(this.FileName.Length, 24);
            }
            catch
            {

            }
        }
    }
}
