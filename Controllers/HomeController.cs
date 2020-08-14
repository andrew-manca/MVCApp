using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApp.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Home/GetFeatureFlags")]
        public async Task<KeyResponseModel> GetFeatureFlag(string keyName)
        {
            //Need to extract method to do Auth
            HttpClient client = new HttpClient();
            HelperFunctions helper = new HelperFunctions();
            string token = await helper.getTokenAsync();
            //POST https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/listKeyValue?api-version=2019-10-01
            string subscriptionId = "43c4fce3-91d3-4498-9282-275f49cdd065";
            string resourceGroupName = "amancaRG";
            string configStoreName = "amancaAppConfig";
            string route = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/listKeyValue?api-version=2019-10-01";
            KeyModel keyModel = new KeyModel();
            keyModel.key = keyName;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Imh1Tjk1SXZQZmVocTM0R3pCRFoxR1hHaXJuTSIsImtpZCI6Imh1Tjk1SXZQZmVocTM0R3pCRFoxR1hHaXJuTSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDcvIiwiaWF0IjoxNTk3NDIyMzg0LCJuYmYiOjE1OTc0MjIzODQsImV4cCI6MTU5NzQyNjI4NCwiX2NsYWltX25hbWVzIjp7Imdyb3VwcyI6InNyYzEifSwiX2NsYWltX3NvdXJjZXMiOnsic3JjMSI6eyJlbmRwb2ludCI6Imh0dHBzOi8vZ3JhcGgud2luZG93cy5uZXQvNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3L3VzZXJzLzMzYzBiOGYzLWIyZDMtNDBhYi1iMzhkLTBjOTUyMzNjMDAzZi9nZXRNZW1iZXJPYmplY3RzIn19LCJhY3IiOiIxIiwiYWlvIjoiQVZRQXEvOFFBQUFBTFhTVmg2VFVyK3NUeEtrVnhIbzA5RzRnVnRrNXRWM0F1OUhxUUZyQ3pDa3VoMVB1SjhPMFBZMXpHUTY5clZrMGR5MldqSjFIVmR5QzU1UjEwdXh5dnhXM05ST3FkUk1PWDlBd3I0OVFEQVE9IiwiYW1yIjpbInB3ZCIsIm1mYSJdLCJhcHBpZCI6IjA0YjA3Nzk1LThkZGItNDYxYS1iYmVlLTAyZjllMWJmN2I0NiIsImFwcGlkYWNyIjoiMCIsImZhbWlseV9uYW1lIjoiTWFuY2EiLCJnaXZlbl9uYW1lIjoiQW5kcmV3IiwiaXBhZGRyIjoiMTcyLjcyLjIxNy4yMDYiLCJuYW1lIjoiQW5kcmV3IE1hbmNhIiwib2lkIjoiMzNjMGI4ZjMtYjJkMy00MGFiLWIzOGQtMGM5NTIzM2MwMDNmIiwib25wcmVtX3NpZCI6IlMtMS01LTIxLTEyNDUyNTA5NS03MDgyNTk2MzctMTU0MzExOTAyMS0xOTU3MDU4IiwicHVpZCI6IjEwMDMyMDAwOTg5RUJDNUYiLCJyaCI6IjAuQVJvQXY0ajVjdkdHcjBHUnF5MTgwQkhiUjVWM3NBVGJqUnBHdS00Qy1lR19lMFlhQUpVLiIsInNjcCI6InVzZXJfaW1wZXJzb25hdGlvbiIsInN1YiI6ImNXcktWWms4bFdzTXE5VUZ2VXJWY0dIRjZCbmkzZFMxeHNReGN0M283bE0iLCJ0aWQiOiI3MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDciLCJ1bmlxdWVfbmFtZSI6ImFubWFuY2FAbWljcm9zb2Z0LmNvbSIsInVwbiI6ImFubWFuY2FAbWljcm9zb2Z0LmNvbSIsInV0aSI6IkNZenBxanNJb0VtYk1xaFl1VnNDQUEiLCJ2ZXIiOiIxLjAiLCJ4bXNfdGNkdCI6MTI4OTI0MTU0N30.1tWsBX-MtiUAWWW56HX8oWbr1pWalrivHs2WHW-CIa28vC5ONfyBnyYla6W1voEf_kMftyncUuXFH7abqejYjjbI-GrWrGXhyQ9OUBBFOA24srEww0LtntouFKEhclTYDd0OagPHkSS70e6v9hB134v6soR3VDH-hNaEWKmK_5zXCyCf_gIV4gFB8pKBtaBgYhGm4gxnZNb_7oLykg5uaoaDFRn00UqnVVlE8R0Oyiebf2Qpf0nxpw1ZplBIeQtcdWOLZD0avv1Axq8TipLNURJNOxjrqdZ19nYfhORmOGKEiexFpXsvvVMdaJc9U7x8XWPVSVvHNI99suAVdXtFJw");

            HttpResponseMessage message = await client.PostAsync(route, new StringContent(JsonConvert.SerializeObject(keyModel),Encoding.UTF8, "application/json"));
            var keyResponse = await System.Text.Json.JsonSerializer.DeserializeAsync<KeyResponseModel>(await message.Content.ReadAsStreamAsync());
            //var keyResponse = await message.Content.ReadAsStringAsync();

            return keyResponse;  

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
