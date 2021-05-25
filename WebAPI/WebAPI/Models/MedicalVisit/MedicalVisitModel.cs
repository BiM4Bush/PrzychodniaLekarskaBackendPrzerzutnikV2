﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class MedicalVisitModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public DoctorModel Doctor { get; set; }
        public string Reason { get; set; }
        public bool Private { get; set; }
    }
}