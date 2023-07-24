using Chinook.Models;

namespace Chinook.Repositories.Interfaces;

public interface IPlaylistRepository
{
    public IQueryable<Models.Playlist> GetPlaylistById(long playlistId);
    public IQueryable<Models.Playlist> GetAllPlaylists();
    public IQueryable<Models.Playlist> GetFavouritePlaylist(string currentUserId);
    public void AddToFavourites(string currentUserId, Track track);
    public void RemoveFromFavourites(Models.Track trackId, string CurrentUserId);
    public void RemoveFromPlaylist(long playlistId, Track track);
    public void CheckForExistingPlaylistsAndAdd(string CurrentUserId, string NewPlaylistName, Track track);
}
