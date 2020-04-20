using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WelcomeTo.Models.ViewModels
{
    public class GameVM
    {
        public List<Card> CurrentIcons { get; set; }
        public List<Card> CurrentNumbers { get; set; }
        public List<ProjectCard> ProjectCards { get; set; }

        public GameVM()
        {
            CurrentIcons = new List<Card>();
            CurrentNumbers = new List<Card>();
            ProjectCards = new List<ProjectCard>();
        }
    }
}