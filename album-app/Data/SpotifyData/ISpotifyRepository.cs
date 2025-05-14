using SpotifyAPI.Web;

interface ISpotifyRepository {
    Task<Album> GetAlbum();
}