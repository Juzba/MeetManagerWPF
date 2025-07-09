﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetManagerWPF.Model
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Location { get; set; } = string.Empty;

        // Events
        public IEnumerable<Event> Events { get; set; } = [];
    }
}
