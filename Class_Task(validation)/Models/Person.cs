using Class_Task_validation_.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace ValidationTask_Class3.Models
{
    public class Person
    {
        [Required]
        [ValidaetionName]
        public String Name { get; set; }
        [Required]
        [ValidationUserName]
        public String UserName { get; set; }
        [Required]
        [ValidationId]
        public string Id { get; set; }
        [Required]
        [ValidationEmail]
        public string Email { get; set; }
    }
}