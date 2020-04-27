using System.IO;

namespace WelcomeTo.Models
{
    public class ProjectCard
    {
        public string ImgUrl { get; set; }

        private bool _approved;
        public bool Approved
        {
            get
            {
                return _approved;
            }
            set
            {
                _approved = value;

                if (!string.IsNullOrEmpty(ImgUrl))
                {
                    if (_approved)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(ImgUrl);
                        ImgUrl = ImgUrl.Replace(fileName, fileName + "_retro");
                    }
                    else
                    {
                        ImgUrl = ImgUrl.Replace("_retro", string.Empty);
                    }
                }


            }
        }
    }
}
