using Chinook.Models;
using Chinook.Repositories.Interfaces;

namespace Chinook.Repositories;

public class UserPlaylistRepository : IUserPlaylistRepository
{
    private readonly ChinookContext _context;
    public UserPlaylistRepository(ChinookContext context)
    {
        _context = context;
    }
    public void AddNewUserPlaylist(UserPlaylist userPlaylist, Track track)
    {
        _context.UserPlaylists.Add(userPlaylist);
        _context.SaveChanges();
        userPlaylist.Playlist.Tracks.Add(track); 
        _context.Update(userPlaylist);
    }

    public void AddTrackToPlaylist(UserPlaylist userPlaylist, Track track)
    {
        userPlaylist.Playlist.Tracks.Add(track);
        _context.SaveChanges();
    }

    public IQueryable<Models.Playlist> GetUserPlayLists(string currentUserId)
    {
        return _context.UserPlaylists
       .Where(up => up.UserId == currentUserId)
       .Select(x =>x.Playlist);
    }


}
