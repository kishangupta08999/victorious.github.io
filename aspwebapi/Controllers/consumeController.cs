using aspwebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace aspwebapi.Controllers
{
    public class consumeController : Controller
    {
        // GET: consume
        HttpClient client=new HttpClient();
        public ActionResult Index()
        {
            List<admin> list
                = new List<admin>();
            client.BaseAddress = new Uri("https://localhost:44356/api/newapi");
            var response = client.GetAsync("newapi");
            response.Wait();

            var test =response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<admin>>();
                display.Wait();
                list=display.Result;
            }
            return View(list);
        }
        

        public ActionResult create(admin ad)
        {
            client.BaseAddress = new Uri("https://localhost:44356/api/newapi");
            var response = client.PostAsJsonAsync<admin>("newapi",ad);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}