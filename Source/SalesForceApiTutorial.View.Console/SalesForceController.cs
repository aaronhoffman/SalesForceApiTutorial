using Salesforce.Common;
using Salesforce.Force;
using System;
using System.Collections.Generic;
using System.Dynamic;
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


            // Insert some test data
            dynamic myAccount = new ExpandoObject();
            myAccount.Name = "Aaron";
            var accountId = await forceClient.CreateAsync("Account", myAccount);


            // Query via API
            var accounts = await forceClient.QueryAsync<dynamic>("select Id, Name from Account");
            
            foreach (var account in accounts.records)
            {
                System.Console.WriteLine(String.Format("Id:{0}, Name:{1}", account.Id, account.Name));
            }

            var accountResult = await forceClient.QueryByIdAsync<dynamic>("Account", accountId);


            // Modify via API
            myAccount.Name = "Aaron 2";
            await forceClient.UpdateAsync("Account", accountId, myAccount);

            await forceClient.DeleteAsync("Account", accountId);
        }
    }
}