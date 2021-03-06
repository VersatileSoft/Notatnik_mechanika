﻿using System.Collections.Generic;

namespace NotatnikMechanika.Data.Models
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        /// <summary>
        /// np NIP
        /// </summary>
        public string CompanyIdentyficator { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
