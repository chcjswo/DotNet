﻿
namespace DolPic.Common
{
    public class Domains
    {
        private static readonly Domains domains = new Domains();

        public static string WebDomain { get; set; }
        public static string MobileDomain { get; set; }

        public Domains()
        {
            switch (UserStates.DeployType)
            {
                case DeployType.Local:
                case DeployType.Dev:
                case DeployType.Qa:
                    WebDomain = "http://localhost:3281";
                    MobileDomain = "http://localhost:5102";
                    break;
                case DeployType.Live:
                    WebDomain = "http://www.dolpic.kr";
                    MobileDomain = "http://m.dolpic.kr";
                    break;
            }
        }

    }
}
