﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Core.Domain.Common
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
