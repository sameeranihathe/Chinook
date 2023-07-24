using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repositories;

public class TracksRepository : ITrackRepository
{
    private readonly ChinookContext _context;
    public TracksRepository(ChinookContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Returns tracks related to a specific albumId
    /// </summary>
    /// <param name="albumId"></param>
    /// <returns></returns>
    public IQueryable<Track> GetTracksByArtistId(long artistId)
    {
        return _context.Tracks
            .Include(tr =>tr.Album)
            .Where(tr => tr.Album.ArtistId == artistId);
    }

    public Track? GetTracksByÌd(long trackId)
    {
        return _context.Tracks
            .Where(tr => tr.TrackId == trackId)
            .FirstOrDefault();
    }
}
