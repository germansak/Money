﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Data
{
    public class EventSourcingContext : Neptuo.Data.Entity.EventSourcingContext
    {
        public EventSourcingContext(string connectionString) 
            : base(connectionString)
        { }
    }
}
