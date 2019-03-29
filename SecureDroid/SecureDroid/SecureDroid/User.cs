﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureDroid
{
    class User
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public byte[] PasswortHash { get; set; }
    }
}
