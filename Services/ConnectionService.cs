using Microsoft.EntityFrameworkCore;
using AstoundWebAPI.Models;
using AstoundWebAPI.Data;

namespace AstoundWebAPI.Services
{
    public class ConnectionService : IConnectionService
    {

        private readonly AppDbContext _db;

        public ConnectionService(AppDbContext db)
        {
            _db = db;
        }


        #region Contacts

        public async Task<List<Contact>> GetContactsAsync()
        {
            try
            {
                return await _db.Contacts.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Contact> GetContactAsync(int id)
        {
            try
            {
                return await _db.Contacts.FindAsync(id);
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            try
            {
                await _db.Contacts.AddAsync(contact);
                await _db.SaveChangesAsync();
                return await _db.Contacts.FindAsync(contact.Id);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            try
            {
                _db.Entry(contact).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return contact;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteContactAsync(Contact contact)
        {
            try
            {
                var dbAuthor = await _db.Contacts.FindAsync(contact.Id);

                if (dbAuthor == null)
                {
                    return (false, "Author could not be found");
                }

                _db.Contacts.Remove(contact);
                await _db.SaveChangesAsync();

                return (true, "Author got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Contacts
        #region Links

        public async Task<List<Link>> GetLinksAsync()
        {
            try
            {
                return await _db.Links.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Link> GetLinkAsync(int id)
        {
            try
            {
                return await _db.Links.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Link> AddLinkAsync(Link link)
        {
            try
            {
                await _db.Links.AddAsync(link);
                await _db.SaveChangesAsync();
                return await _db.Links.FindAsync(link.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Link> UpdateLinkAsync(Link link)
        {
            try
            {
                _db.Entry(link).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return link;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteLinkAsync(Link link)
        {
            try
            {
                var dbBook = await _db.Links.FindAsync(link.Id);

                if (dbBook == null)
                {
                    return (false, "Link could not be found.");
                }

                _db.Links.Remove(link);
                await _db.SaveChangesAsync();

                return (true, "Link got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Links
    }
}






