﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHostelManagementSystem.Models
{
    public class Room
    {
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int Occupied { get; set; }
    }

}
