using AstoundWebAPI.Models;
namespace AstoundWebAPI.Services
{
    public interface IConnectionService
    {
        // Contact Services
        Task<List<Contact>> GetContactsAsync(); // GET All contacts
        Task<Contact> GetContactAsync(int id); // GET Single contacts
        Task<Contact> AddContactAsync(Contact contact); // POST New contacts
        Task<Contact> UpdateContactAsync(Contact contact); // PUT contacts
        Task<(bool, string)> DeleteContactAsync(Contact contact); // DELETE contacts

        // link Services
        Task<List<Link>> GetLinksAsync(); // GET All Links
        Task<Link> GetLinkAsync(int id); // Get Single link
        Task<Link> AddLinkAsync(Link link); // POST New link
        Task<Link> UpdateLinkAsync(Link link); // PUT link
        Task<(bool, string)> DeleteLinkAsync(Link link); // DELETE link
    }
}