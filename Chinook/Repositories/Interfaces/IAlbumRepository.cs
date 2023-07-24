using Chinook.Models;

namespace Chinook.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        public IQueryable<Album> GetAlbumById(long albumId);
    }
}
