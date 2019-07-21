﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Data.Models
{
    public class EntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
