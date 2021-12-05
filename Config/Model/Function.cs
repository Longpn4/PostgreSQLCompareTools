using System;

namespace Config.Model
{
    [Serializable]
    public class Function
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Return { get; set; }
    }
}
