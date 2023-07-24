using Chinook.Models;
using Chinook.Repositories.Interfaces;

namespace Chinook.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly ChinookContext _context;
    public AlbumRepository(ChinookContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get album by Id
    /// </summary>
    /// <param name="albumId"></param>
    /// <returns></returns>
    public IQueryable<Album> GetAlbumById(long albumId)
    {
        return _context.Albums
            .Where(al => al.AlbumId == albumId);
    }

}
