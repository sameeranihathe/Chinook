using Chinook.Models;

namespace Chinook.Repositories.Interfaces;
public interface ITrackRepository
{
    public IQueryable<Track> GetTracksByArtistId(long artistId);
    public Track? GetTracksByÌd(long trackId);
}
