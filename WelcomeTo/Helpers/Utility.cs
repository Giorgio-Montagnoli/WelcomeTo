using System.Collections.Generic;
using System.Linq;
using WelcomeTo.Models;

namespace WelcomeTo.Helpers
{
    public static class Utility
    {
        public const string COOKIE_GAME_ID = "gameId";
        public const string COOKIE_GAME_NAME = "gameName";

        public static List<ProjectCard> AllProject_1_Cards
        {
            get
            {
                return Enumerable.Range(1, 6).Select(q => new ProjectCard { ImgUrl = $"/Content/Projects/1-0{ q }.png" }).ToList();
            }
        }

        public static List<ProjectCard> AllProject_2_Cards
        {
            get
            {
                return Enumerable.Range(1, 6).Select(q => new ProjectCard { ImgUrl = $"/Content/Projects/2-0{ q }.png" }).ToList();
            }
        }

        public static List<ProjectCard> AllProject_3_Cards
        {
            get
            {
                return Enumerable.Range(1, 6).Select(q => new ProjectCard { ImgUrl = $"/Content/Projects/3-0{ q }.png" }).ToList();
            }
        }

        public static List<Card> AllCards
        {
            get
            {
                return new List<Card>
                {
                    new Card { Number = 1, IconType = IconCard.Garden },
                    new Card { Number = 1, IconType = IconCard.Financial },
                    new Card { Number = 1, IconType = IconCard.Fence },
                    new Card { Number = 2, IconType = IconCard.Garden },
                    new Card { Number = 2, IconType = IconCard.Financial },
                    new Card { Number = 2, IconType = IconCard.Fence },
                    new Card { Number = 3, IconType = IconCard.Fence },
                    new Card { Number = 3, IconType = IconCard.Pool },
                    new Card { Number = 3, IconType = IconCard.Bis },
                    new Card { Number = 3, IconType = IconCard.WorkInProgress },
                    new Card { Number = 4, IconType = IconCard.Garden },
                    new Card { Number = 4, IconType = IconCard.Financial },
                    new Card { Number = 4, IconType = IconCard.Pool },
                    new Card { Number = 4, IconType = IconCard.Bis },
                    new Card { Number = 4, IconType = IconCard.WorkInProgress },
                    new Card { Number = 5, IconType = IconCard.Garden },
                    new Card { Number = 5, IconType = IconCard.Garden },
                    new Card { Number = 5, IconType = IconCard.Financial },
                    new Card { Number = 5, IconType = IconCard.Financial },
                    new Card { Number = 5, IconType = IconCard.Fence },
                    new Card { Number = 5, IconType = IconCard.Fence },
                    new Card { Number = 6, IconType = IconCard.Garden },
                    new Card { Number = 6, IconType = IconCard.Financial },
                    new Card { Number = 6, IconType = IconCard.Fence },
                    new Card { Number = 6, IconType = IconCard.Fence },
                    new Card { Number = 6, IconType = IconCard.Pool },
                    new Card { Number = 6, IconType = IconCard.Bis },
                    new Card { Number = 6, IconType = IconCard.WorkInProgress },
                    new Card { Number = 7, IconType = IconCard.Garden },
                    new Card { Number = 7, IconType = IconCard.Garden },
                    new Card { Number = 7, IconType = IconCard.Financial },
                    new Card { Number = 7, IconType = IconCard.Financial },
                    new Card { Number = 7, IconType = IconCard.Fence },
                    new Card { Number = 7, IconType = IconCard.Pool },
                    new Card { Number = 7, IconType = IconCard.Bis },
                    new Card { Number = 7, IconType = IconCard.WorkInProgress },
                    new Card { Number = 8, IconType = IconCard.Garden },
                    new Card { Number = 8, IconType = IconCard.Garden },
                    new Card { Number = 8, IconType = IconCard.Financial },
                    new Card { Number = 8, IconType = IconCard.Financial },
                    new Card { Number = 8, IconType = IconCard.Fence },
                    new Card { Number = 8, IconType = IconCard.Fence },
                    new Card { Number = 8, IconType = IconCard.Pool },
                    new Card { Number = 8, IconType = IconCard.Bis },
                    new Card { Number = 8, IconType = IconCard.WorkInProgress },
                    new Card { Number = 9, IconType = IconCard.Garden },
                    new Card { Number = 9, IconType = IconCard.Garden },
                    new Card { Number = 9, IconType = IconCard.Financial },
                    new Card { Number = 9, IconType = IconCard.Financial },
                    new Card { Number = 9, IconType = IconCard.Fence },
                    new Card { Number = 9, IconType = IconCard.Pool },
                    new Card { Number = 9, IconType = IconCard.Bis },
                    new Card { Number = 9, IconType = IconCard.WorkInProgress },
                    new Card { Number = 10, IconType = IconCard.Garden },
                    new Card { Number = 10, IconType = IconCard.Financial },
                    new Card { Number = 10, IconType = IconCard.Fence },
                    new Card { Number = 10, IconType = IconCard.Fence },
                    new Card { Number = 10, IconType = IconCard.Pool },
                    new Card { Number = 10, IconType = IconCard.Bis },
                    new Card { Number = 10, IconType = IconCard.WorkInProgress },
                    new Card { Number = 11, IconType = IconCard.Garden },
                    new Card { Number = 11, IconType = IconCard.Garden },
                    new Card { Number = 11, IconType = IconCard.Financial },
                    new Card { Number = 11, IconType = IconCard.Financial },
                    new Card { Number = 11, IconType = IconCard.Fence },
                    new Card { Number = 11, IconType = IconCard.Fence },
                    new Card { Number = 12, IconType = IconCard.Garden },
                    new Card { Number = 12, IconType = IconCard.Financial },
                    new Card { Number = 12, IconType = IconCard.Pool },
                    new Card { Number = 12, IconType = IconCard.Bis },
                    new Card { Number = 12, IconType = IconCard.WorkInProgress },
                    new Card { Number = 13, IconType = IconCard.Fence },
                    new Card { Number = 13, IconType = IconCard.Pool },
                    new Card { Number = 13, IconType = IconCard.Bis },
                    new Card { Number = 13, IconType = IconCard.WorkInProgress },
                    new Card { Number = 14, IconType = IconCard.Garden },
                    new Card { Number = 14, IconType = IconCard.Financial },
                    new Card { Number = 14, IconType = IconCard.Fence },
                    new Card { Number = 15, IconType = IconCard.Garden },
                    new Card { Number = 15, IconType = IconCard.Financial },
                    new Card { Number = 15, IconType = IconCard.Fence }
               };
            }
        }
    }
}
