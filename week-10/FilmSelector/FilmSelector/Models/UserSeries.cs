﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSelector.Models
{
    public class UserSeries
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Series Series { get; set; }
    }
}
