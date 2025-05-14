using SpotifyAPI.Web;

public class Album {
    public required String ID {get; set;}
    public int TrackCount {get; set;}
    public required String Name {get; set;}
    public required String ReleaseDate {get; set;}
    public required List<SimpleArtist> ArtistName {get; set;}
    public required List<Song> Songs {get; set;}
    public required String AlbumArt {get; set;}
}