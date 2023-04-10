using AstoundWebAPI.Models;
using AstoundWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AstoundWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IConnectionService _connectionService;
        
        

        public ContactsController(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _connectionService.GetContactsAsync();

            if (contacts == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No contacts in database");
            }

            return StatusCode(StatusCodes.Status200OK, contacts);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetContact(int id)
        {
            Contact contact = await _connectionService.GetContactAsync(id);

            if (contact == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No contact found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> AddContact(Contact contact)
        {
            var dbContact = await _connectionService.AddContactAsync(contact);

            if (dbContact == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{contact.Name} could not be added.");
            }

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            Contact dbContact = await _connectionService.UpdateContactAsync(contact);

            if (dbContact == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{contact.Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _connectionService.GetContactAsync(id);
            (bool status, string message) = await _connectionService.DeleteContactAsync(contact);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, contact);
        }
    }
}