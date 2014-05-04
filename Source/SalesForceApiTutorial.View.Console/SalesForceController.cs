using Salesforce.Common;
using Salesforce.Force;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForceApiTutorial.View.Console
{
    public class SalesForceController
    {
        public SalesForceController()
        {
            // no-op
        }

        public async void Run()
        {
            // Authenticate
            var userName = "";
            var password = "";
            var passwordSecurityToken = "";
            var consumerKey = "";
            var consumerSecret = "";

            var auth = new AuthenticationClient();

            await auth.UsernamePasswordAsync(consumerKey, consumerSecret, userName, password + passwordSecurityToken);

            var forceClient = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
        }
    }
}