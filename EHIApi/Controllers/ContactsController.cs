using EHIApi.Models;
using EHIApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EHIApi.Controllers
{
    public class ContactsController : ApiController
    {
        ContactContext _context = new ContactContext();
        [HttpGet]
        // Get all contacts
        public IEnumerable<Contact> GetContacts()
        {
            try
            {
                var contacts= _context.Contacts.ToList();
                if (contacts != null)
                {
                    return contacts;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        // Add new contact
        public bool AddContact(string firstName, string lastName, string email, string phoneNo, string status)
        {
            try
            {
                _context.Contacts.Add(new Contact() { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phoneNo, Status = status });
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [HttpGet]
        // Update contact details
        public bool UpdateContact(int id, string firstName, string lastName, string email, string phoneNo, string status)
        {
            try
            {
                var contact = (from c in _context.Contacts
                               where c.Id == id
                               select c).First<Contact>();
                contact.FirstName = firstName;
                contact.LastName = lastName;
                contact.Email = email;
                contact.PhoneNumber = phoneNo;
                contact.Status = status;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        [HttpGet]
        // Delete Contact
        public bool DeleteContact(int id)
        {
            try
            {
                Contact contact = (from c in _context.Contacts
                                   where c.Id == id
                                   select c).First<Contact>();
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        [HttpGet]
        // In Activate a contact
        public bool InActiveContact(int id, string status)
        {
            try
            {
                var contact = (from c in _context.Contacts
                               where c.Id == id
                               select c).First<Contact>();
                contact.Status = status;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
