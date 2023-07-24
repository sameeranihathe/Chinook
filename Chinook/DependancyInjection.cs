using Chinook.Repositories;
using Chinook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IAlbumRepository>(_ =>
                    new AlbumRepository(
                        _.GetRequiredService<IDbContextFactory<ChinookContext>>().CreateDbContext()))
                .AddTransient<ITrackRepository>(_ =>
                    new TracksRepository(
                        _.GetRequiredService<IDbContextFactory<ChinookContext>>().CreateDbContext()))
                .AddTransient<IArtistRepository>(_ =>
                    new ArtistRepository(
                        _.GetRequiredService<IDbContextFactory<ChinookContext>>().CreateDbContext()))
                .AddTransient<IPlaylistRepository>(_ =>
                    new PlaylistRepository(
                        _.GetRequiredService<IDbContextFactory<ChinookContext>>().CreateDbContext()))
                .AddTransient<IUserPlaylistRepository>(_ =>
                    new UserPlaylistRepository(
                        _.GetRequiredService<IDbContextFactory<ChinookContext>>().CreateDbContext()));
            return services;
        }
    }
}
