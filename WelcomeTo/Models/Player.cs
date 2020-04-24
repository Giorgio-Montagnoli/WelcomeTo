using System;

namespace WelcomeTo.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool TurnDone { get; set; }
        public int CannotPlaceANumber { get; set; }
        public int CompletedProjects { get; set; }
        public bool HasPlacedAllNumbers { get; set; }
    }
}