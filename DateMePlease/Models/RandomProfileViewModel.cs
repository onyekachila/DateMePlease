using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateMePlease.Models
{
    public class RandomProfileViewModel
    {
        public string PhotoUrl { get; internal set; }
        public string LookingFor { get; internal set; }
        public string MemberName { get; internal set; }
    }
}