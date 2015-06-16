
namespace DolPic.Common
{
    public class Domains
    {
        private static readonly Domains domains = new Domains();

        public static string WebDomain { get; set; }
        public static string MobileDomain { get; set; }
        public static string StaticDomain { get; set; }

        public Domains()
        {
            switch (UserStates.DeployType)
            {
                case DeployType.Local:
                    WebDomain = "http://localhost:7208";
                    MobileDomain = "http://localhost:12085";
                    StaticDomain = "http://static.event.mobile.actoz.com";
                    break;
                case DeployType.Dev:
                case DeployType.Qa:
                    WebDomain = "http://qa-event.mobile.actoz.com";
                    MobileDomain = "http://qa-m.event.mobile.actoz.com";
                    StaticDomain = "http://static.event.mobile.actoz.com";
                    break;
                case DeployType.Live:
                    WebDomain = "http://event.mobile.actoz.com";
                    MobileDomain = "http://m.event.mobile.actoz.com";
                    StaticDomain = "http://static.event.mobile.actoz.com";
                    break;
            }
        }

    }
}
