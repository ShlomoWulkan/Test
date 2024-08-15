using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test.Controllers
{
	public class TestController : Controller
	{

        public async Task<string> GetUsers()
        {
            //Define your baseUrl
            string baseUrl = "https://fakestoreapi.com/users";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            return data;
                        }
                    }
                }
            }
            catch (Exception exception)
            {                
                return "";
            }
        }

        public async Task<IActionResult> Index()
		{
            TempData["Data"] = await GetUsers();    
			return View();
		}
	}
}
