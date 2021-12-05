namespace Config.Model
{
    public class ResultExecute
    {
        public string Description { get; set; }
        public string Query { get; set; }
        public string Connection { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }

        public ResultExecute() { }

        public ResultExecute(string Query, string Connection, string Description)
        {
            this.Query = Query;
            this.Connection = Connection;
            this.Description = Description;
        }
    }
}
