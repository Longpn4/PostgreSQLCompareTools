using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SqlCompare
{
    public class Database
    {
        private string _name;
        private string _description;
        private int _type;
        private string _connection;

        [CategoryAttribute("Settings"), DescriptionAttribute("Name of the Database")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [CategoryAttribute("Settings"), DescriptionAttribute("Description of the Database")]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        //[CategoryAttribute("Settings"), DescriptionAttribute("Type of the Database"), Bindable(false)]
        public int Type;

        [CategoryAttribute("Settings"), DescriptionAttribute("Connection of the Database")]
        public string Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }
    }
}
