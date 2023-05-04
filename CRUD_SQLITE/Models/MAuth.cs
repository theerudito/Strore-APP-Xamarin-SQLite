﻿using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class MAuth
    {
        [Key]
        public int IdAuth { get; set; }

        public string User { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}