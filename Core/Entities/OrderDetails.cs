﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OrderDetails : BaseEntity
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
