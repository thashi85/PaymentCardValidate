﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnXTestAPI.Models
{
    public class Error
    {
        public string ErrorCode { get; set; }
        public string Description { get; set; }
        public bool? IsWarning { get; set; }
    }
}
