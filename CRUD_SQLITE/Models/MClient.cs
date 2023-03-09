﻿using SQLite;
using System;
using System.Collections.Generic;

namespace CRUD_SQLITE.Models
{
    public class MClient
    {
        [PrimaryKey, AutoIncrement]
        public int IdClient { get; set; }
        public string DNI { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Direction { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string City { get; set; } = "";
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<MCart> Cart { get; set; } = new List<MCart>();
    }
}
