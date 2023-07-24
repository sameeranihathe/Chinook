namespace Chinook.ClientMappings;

public static class PlaylistMapping
{
    public static ClientModels.Playlist Map(IQueryable<Models.Playlist>? tracks, string currentUserId)
    {
        return  tracks.Select(p => new ClientModels.Playlist()
         {
             Name = p.Name,
             Tracks = p.Tracks.Select(t => new ClientModels.PlaylistTrack()
             {
                 AlbumTitle = t.Album.Title,
                 ArtistName = t.Album.Artist.Name,
                 TrackId = t.TrackId,
                 TrackName = t.Name,
                 IsFavorite = t.Playlists.Where(p => p.UserPlaylists.Any(up => up.UserId == currentUserId && up.Playlist.Name == "Favorites")).Any()
             }).ToList()
         })
        .FirstOrDefault();

    }

}
