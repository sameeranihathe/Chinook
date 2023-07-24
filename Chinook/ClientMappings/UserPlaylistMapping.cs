using Chinook.Models;

namespace Chinook.ClientMappings
{
    public static class UserPlaylistMapping
    {
        public static UserPlaylist Map(string CurrentUserId, long playlistId)
        {
            return new UserPlaylist
            {
                UserId = CurrentUserId,
                Playlist = new Models.Playlist
                {
                    Name = "Favorites",
                    PlaylistId = playlistId
                }
            };
        }
    }
}
