using SpotifyAPI.Web;

public class Song{
    public required String ID {get; set;}
    public int TrackPos {get; set;}
    public required String Name {get; set;}
    public required List<SimpleArtist> ArtistName {get; set;}
    public required String AlbumName {get; set;}
}