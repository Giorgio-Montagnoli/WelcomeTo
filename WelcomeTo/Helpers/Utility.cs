using System.Collections.Generic;
using WelcomeTo.Models;
using WelcomeTo.Models.ViewModels;

namespace WelcomeTo.Helpers
{
    static class Utility
    {
        public static List<ProjectCard> AllProject_1_Cards
        {
            get
            {
                return new List<ProjectCard>
                    {
                        new ProjectCard { imgUrl = "/Content/Projects/1-01.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/1-02.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/1-03.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/1-04.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/1-05.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/1-06.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/1-07.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/1-08.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/1-09.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/1-10.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/1-11.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/1-12.png" },
                    };
            }
        }

        public static List<ProjectCard> AllProject_2_Cards
        {
            get
            {
                return new List<ProjectCard>
                    {
                        new ProjectCard { imgUrl = "/Content/Projects/2-01.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/2-02.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/2-03.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/2-04.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/2-05.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/2-06.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/2-07.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/2-08.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/2-09.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/2-10.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/2-11.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/2-12.png" },
                    };
            }
        }

        public static List<ProjectCard> AllProject_3_Cards
        {
            get
            {
                return new List<ProjectCard>
                    {
                        new ProjectCard { imgUrl = "/Content/Projects/3-01.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/3-02.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/3-03.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/3-04.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/3-05.png" },
                        new ProjectCard { imgUrl = "/Content/Projects/3-06.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/3-07.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/3-08.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/3-09.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/3-10.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/3-11.png" },
                        //new ProjectCard { imgUrl = "/Content/Projects/3-12.png" },
                    };
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
