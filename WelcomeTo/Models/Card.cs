using WelcomeTo.Helpers;

namespace WelcomeTo.Models
{
    public class Card
    {
        public int Number { get; set; }
        public IconCard IconType { get; set; }

        public string ImgUrl
        {
            get
            {
                switch (IconType)
                {
                    case IconCard.Garden:
                        return "/Content/Templates/garden.png";

                    case IconCard.Financial:
                        return "/Content/Templates/money.png";

                    case IconCard.Fence:
                        return "/Content/Templates/fence.png";

                    case IconCard.Pool:
                        return "/Content/Templates/pool.png";

                    case IconCard.Bis:
                        return "/Content/Templates/bis.png";

                    case IconCard.WorkInProgress:
                        return "/Content/Templates/work.png";

                    default:
                        return string.Empty;
                }
            }
        }
    }
}