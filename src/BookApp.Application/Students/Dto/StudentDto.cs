﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Entities;

namespace BookApp.Students.Dto
{
    [AutoMapTo(typeof(Student))]
    [AutoMapFrom(typeof(Student))]
    public class StudentDto : EntityDto<int>
    {
        public string StudentName { get; set; }
        public string StudentContactNumber { get; set; }
        public string StudentEmail { get; set; }
        public string StudentDepartment { get; set; }
    }
}