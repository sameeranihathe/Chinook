using Chinook.Models;

namespace Chinook.Repositories.Interfaces
{
    public interface IArtistRepository
    {
        public IQueryable<Artist> GetArtistById(long albumId);
        public IQueryable<Artist> GetAllArtists();
    }
}
