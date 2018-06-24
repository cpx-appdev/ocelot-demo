using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class IndexModel : PageModel
    {
        public string[] Users { get; set; }
        public string[] Subscriptions { get; set; }

        //private ApiHelper userApi;
        //private ApiHelper subscApi;

        private ApiHelper gatewayHelper;

        public IndexModel()
        {
            gatewayHelper = new ApiHelper(ApiUrls.Gateway);
            //userApi = new ApiHelper(ApiUrls.UserService);
            //subscApi = new ApiHelper(ApiUrls.SubscriptionService);
        }


        public async Task OnGetAsync()
        {
            var userResult = await gatewayHelper.Get<string[]>("users");
            Users = userResult;

            var subs = await gatewayHelper.Get<string[]>("subscriptions");
            Subscriptions = subs;
        }
    }
}
