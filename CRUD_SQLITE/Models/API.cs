using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_SQLITE.Models
{
    public class API
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public List<API> data { get; set; }
    }
}
