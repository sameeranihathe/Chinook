using Chinook.ClientModels;
using Chinook.Models;

namespace Chinook.ClientMappings;
public static class PlaylistTrackMapping
{
    public static List<PlaylistTrack> Map(IQueryable<Track>? tracks, string currentUserId)
    {
        return tracks.Select(t => new PlaylistTrack()
        {
            AlbumTitle = (t.Album == null ? "-" : t.Album.Title),
            TrackId = t.TrackId,
            TrackName = t.Name,
            IsFavorite = t.Playlists.Where(p => p.UserPlaylists.Any(up => up.UserId == currentUserId && up.Playlist.Name == "Favorites")).Any()
        })
            .ToList();
    }
}
