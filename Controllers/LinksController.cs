using AstoundWebAPI.Models;
using AstoundWebAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace AstoundWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinksController : ControllerBase
    {
        private readonly IConnectionService _ConntectionService;

        public LinksController(IConnectionService connectionService)
        {
            _ConntectionService = connectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLinks()
        {
            var links = await _ConntectionService.GetLinksAsync();
            if (links == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No links in database.");
            }

            return StatusCode(StatusCodes.Status200OK, links);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLinks(int id)
        {
            Link link = await _ConntectionService.GetLinkAsync(id);

            if (link == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No link found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, link);
        }

        [HttpPost]
        public async Task<ActionResult<Link>> AddLink(Link link)
        {
            var dbLink = await _ConntectionService.AddLinkAsync(link);

            if (dbLink == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{link.Name} could not be added.");
            }

            return CreatedAtAction("GetLink", new { id = link.Id }, link);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLink(int id, Link link)
        {
            if (id != link.Id)
            {
                return BadRequest();
            }

            Link dbLink = await _ConntectionService.UpdateLinkAsync(link);

            if (dbLink == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{link.Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            var link = await _ConntectionService.GetLinkAsync(id);
            (bool status, string message) = await _ConntectionService.DeleteLinkAsync(link);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, link);
        }
    }
}