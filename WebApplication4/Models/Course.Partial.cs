﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication4.Models
{
    [ModelMetadataType(typeof(CourseMetadata))]
    public partial class Course
    {
    }

    internal class CourseMetadata
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Credits { get; set; }
    }
}