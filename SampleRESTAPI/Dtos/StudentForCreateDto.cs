﻿using System;

namespace SampleRESTAPI.Dtos
{
    public class StudentForCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
