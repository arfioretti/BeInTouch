using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ClienteController : Controller
    {
        // só pra dar commit
        // vai entrar na master via merge
        public ActionResult ClienteExiste(int id)
        {
            string bRet = "false";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58095/api/v1/");
                //HTTP GET
                var responseTask = client.GetAsync("clientes/"+id.ToString()+"/existe");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsByteArrayAsync();
                    //readTask.Wait();
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    bRet = readTask.Result;
                }
                else //web api sent error response 
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            ViewBag.ClienteExiste = bRet;
            return View();
        }

        // GET: Cliente
        public ActionResult Index()
        {
            IEnumerable<ClienteViewModel> clientes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58095/api/v1/");
                //HTTP GET
                var responseTask = client.GetAsync("clientes");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ClienteViewModel>>();
                    readTask.Wait();

                    clientes = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    clientes = Enumerable.Empty<ClienteViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(clientes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClienteViewModel cliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58095/api/v1/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ClienteViewModel>("clientes", cliente);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(cliente);
        }

        public ActionResult Edit(int id)
        {
            ClienteViewModel cliente = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58095/api/v1/");
                //HTTP GET
                var responseTask = client.GetAsync("clientes/" + id.ToString());

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClienteViewModel>();


                    readTask.Wait();

                    cliente = readTask.Result;
                }
            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58095/api/v1/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<ClienteViewModel>("clientes/"+(cliente.Id).ToString(), cliente);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58095/api/v1/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("clientes/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}