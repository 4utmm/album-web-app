using SpotifyAPI.Web;

interface ISpotifyRepository {
    Task<FullAlbum> GetAlbum();
}