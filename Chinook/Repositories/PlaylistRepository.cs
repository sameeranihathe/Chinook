using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repositories;

public class PlaylistRepository : IPlaylistRepository
{
    private readonly ChinookContext _context;

    public PlaylistRepository(ChinookContext context)
    {
        _context = context;
    }

    public IQueryable<Models.Playlist> GetAllPlaylists()
    {
        return _context.Playlists.AsQueryable();
    }

    public IQueryable<Models.Playlist> GetPlaylistById(long playlistId)
    {
        return _context.Playlists
             .Include(a => a.Tracks).ThenInclude(a => a.Album).ThenInclude(a => a.Artist)
            .Where(pl => pl.PlaylistId == playlistId);
    }
    public IQueryable<Models.Playlist> GetFavouritePlaylist(string currentUserId)
    {
        return _context.Playlists
            .Where(p => p.UserPlaylists.Any(up => up.UserId == currentUserId && up.Playlist.Name == "Favorites"));
    }

    public void AddToFavourites(string currentUserId, Track track)
    {
        var favouritePlayList = _context.Playlists
             .Include(a => a.Tracks).ThenInclude(a => a.Album).ThenInclude(a => a.Artist)
            .Where(p => p.UserPlaylists.Any(up => up.UserId == currentUserId && up.Playlist.Name == "Favorites"))
            .FirstOrDefault();

        favouritePlayList.Tracks.Add(track);
        _context.Update(favouritePlayList);
        _context.SaveChanges();
    }

    public void RemoveFromFavourites(Track track, string CurrentUserId)
    {
        var favouritePlayList = _context.Playlists
             .Include(a => a.Tracks).ThenInclude(a => a.Album).ThenInclude(a => a.Artist)
            .Where(p => p.UserPlaylists.Any(up => up.UserId == CurrentUserId && up.Playlist.Name == "Favorites"))
            .FirstOrDefault();

        favouritePlayList.Tracks.Remove(track);
        _context.Update(favouritePlayList);
        _context.SaveChanges();
    }

    public void RemoveFromPlaylist(long playlistId, Track track)
    {
       var playlist =  _context.Playlists
        .Include(a => a.Tracks).ThenInclude(a => a.Album).ThenInclude(a => a.Artist)
        .Where(pl => pl.PlaylistId == playlistId)
        .FirstOrDefault();

        if (playlist != null)
        {
            playlist.Tracks.Remove(track);
            _context.Update(playlist);
            _context.SaveChanges();
        }
    }

    public void CheckForExistingPlaylistsAndAdd(string CurrentUserId, string NewPlaylistName, Track track)
    {
        var currentPlaylist = _context.Playlists.Where(p => p.UserPlaylists.Any(up => up.UserId == CurrentUserId && up.Playlist.Name == NewPlaylistName)).SingleOrDefault();

        if (currentPlaylist != null)
        {
            currentPlaylist.Tracks.Add(track);
            _context.Update(currentPlaylist);
            _context.SaveChanges();
        }
        else
        {
            Random random = new Random();
            long playlistId = random.NextInt64();

            var playList = _context.UserPlaylists.Add(new UserPlaylist
            {
                UserId = CurrentUserId,
                PlaylistId = playlistId,
                Playlist = new Playlist
                {
                    Name = NewPlaylistName,
                    PlaylistId = playlistId,
                    Tracks = new List<Track> { track }
                },
            });

            _context.SaveChanges();
        }
    }

}
