using EHIApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EHIApi.Controllers
{
    public class ContactsPageController : Controller
    {
        private HttpClient _client = new HttpClient();
        private const string BasePath = "http://localhost:50408/api";
        // Action to Show Contacts List
        public ActionResult Index()
        {
            var response = _client.GetAsync(BasePath + "/Contacts");
            if (response.Result.IsSuccessStatusCode)
            {
                var compressedContent = response.Result.Content.ReadAsAsync<List<Contact>>();
                return View(compressedContent.Result);
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        // Action to Add new Contact
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var response = _client.GetAsync(BasePath + $"/Contacts?firstName={contact.FirstName}&lastName={contact.LastName}&email={contact.Email}&phoneNo={contact.PhoneNumber}&status={contact.Status}");
            if (response.Result.IsSuccessStatusCode)
            {
                var compressedContent = response.Result.Content.ReadAsStringAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        // Action to Edit a Contact
        public ActionResult EditContact(int Id)
        {
            var response = _client.GetAsync(BasePath + "/Contacts");
            if (response.Result.IsSuccessStatusCode)
            {
                var compressedContent = response.Result.Content.ReadAsAsync<List<Contact>>();
                Contact contact = (from c in compressedContent.Result
                                   where c.Id == Id
                                   select c).SingleOrDefault<Contact>();
                return View(contact);
            }
            return View();
        }
        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var response = _client.GetAsync(BasePath + $"/Contacts?id={contact.Id}&firstName={contact.FirstName}&lastName={contact.LastName}&email={contact.Email}&phoneNo={contact.PhoneNumber}&status={contact.Status}");
            if (response.Result.IsSuccessStatusCode)
            {
                var compressedContent = response.Result.Content.ReadAsStringAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        // Action to Delete a Contact
        public ActionResult DeleteContact(int Id)
        {
            var response = _client.GetAsync(BasePath + "/Contacts?id=" + Id);
            if (response.Result.IsSuccessStatusCode)
            {
                var compressedContent = response.Result.Content.ReadAsStringAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        // Action to InActive a Contact
        public ActionResult InActiveContact(int Id)
        {
            var response = _client.GetAsync(BasePath + $"/Contacts?id={Id}&status=InActive");
            if (response.Result.IsSuccessStatusCode)
            {
                var compressedContent = response.Result.Content.ReadAsStringAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}