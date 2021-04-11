using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineAdmissionSystem.ViewModels
{
    public class StudentViewModel
    {
        public string name { get; set; }

        [Key, Required]
        public string email { get; set; }
        public string mobile { get; set; }
        public int pcm { get; set; }
        public int gujcet { get; set; }
        public float merit { get; set; }
    }
}