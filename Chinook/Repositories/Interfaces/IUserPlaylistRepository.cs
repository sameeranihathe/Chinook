using Chinook.Models;

namespace Chinook.Repositories.Interfaces;

public interface IUserPlaylistRepository
{
    public IQueryable<Models.Playlist> GetUserPlayLists(string currentUserId);
    public void AddNewUserPlaylist(UserPlaylist userPlaylist, Track track);
    public void AddTrackToPlaylist(UserPlaylist userPlaylist, Track track);
}
