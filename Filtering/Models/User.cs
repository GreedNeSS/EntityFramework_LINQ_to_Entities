﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtering.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public override string ToString()
        {
            return $"{Id}) Name: {Name}, Age: {Age} Company: {Company?.Title}";
        }
    }
}
