﻿using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class Account : DbRecord, IAccount
    {
        public string SubjectID { get; set; }
        public string Props { get; set; }
    }
}
