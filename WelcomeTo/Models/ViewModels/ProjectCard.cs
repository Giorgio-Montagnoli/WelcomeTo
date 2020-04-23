using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WelcomeTo.Models.ViewModels
{
    public class ProjectCard
    {
        public int Id { get; set; }
        public string imgUrl { get; set; }
        public bool Approved { get; set; }
    }
}
