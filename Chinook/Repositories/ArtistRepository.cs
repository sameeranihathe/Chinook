using Chinook.Models;
using Chinook.Repositories.Interfaces;

namespace Chinook.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly ChinookContext _context;
    public ArtistRepository(ChinookContext context)
    {
        _context = context;
    }

    public IQueryable<Artist> GetAllArtists()
    {
        return _context.Artists;
    }

    /// <summary>
    /// Returns a specific artist
    /// </summary>
    /// <param name="albumId"></param>
    /// <returns>Artist</returns>
    public IQueryable<Artist> GetArtistById(long albumId)
    {
        return _context.Artists
            .Where(ar => ar.ArtistId == albumId);

    }
}
