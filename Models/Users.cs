﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_lesson_No._29.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public DateTime RentStart { get; set; }
        public int Duration { get; set; }
        public int IdClub { get; set; }
    }
}
