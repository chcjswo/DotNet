using System.Configuration;

namespace DolPic.Common
{
    public class UserStates
    {
        private static readonly UserStates userStates = new UserStates();

        public UserStates()
        {
            string statement = ConfigurationManager.AppSettings["statement"];

            switch (statement.ToLower())
            {
                case "local":
                    DeployType = DeployType.Local;
                    break;
                case "dev":
                    DeployType = DeployType.Dev;
                    break;
                case "qa":
                    DeployType = DeployType.Qa;
                    break;
                case "live":
                default:
                    DeployType = DeployType.Live;
                    break;
            }
        }

        public static DeployType DeployType { get; set; }
    }
}
