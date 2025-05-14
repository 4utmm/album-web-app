using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SpotifyAPI.Web;

class SpotifyRepository : ISpotifyRepository {

    private SpotifyClientConfig config; 
    private ClientCredentialsRequest request; 
  
    public SpotifyRepository(){
        config = SpotifyClientConfig.CreateDefault();
        request = new ClientCredentialsRequest("fbfdf4c942ab4978bb4c1cde7c78fa1a", "38dbedd257be47b7bb41689eb82ca0a7"); 
    }

    public async Task<Album> GetAlbum()
    {
        return createAlbumModel(await GetAlbumData());
    }

    private async Task<FullAlbum> GetAlbumData() {
        var response = await new OAuthClient(config).RequestToken(request);
        var client = new SpotifyClient(config.WithToken(response.AccessToken));

        return await client.Albums.Get("5qKAJg56GqQIrxajvzaiEC");
    }

    public static Album createAlbumModel(FullAlbum fullAlbum){
        var songs = new List<Song>();

        foreach (SimpleTrack track in fullAlbum.Tracks.Items){
            songs.Add(createSongModel(track, fullAlbum.Name));
        }
        return new Album{
            ID = fullAlbum.Id,
            TrackCount = fullAlbum.TotalTracks,
            Name = fullAlbum.Name,
            ArtistName = fullAlbum.Artists,
            Songs = songs,
            AlbumArt = fullAlbum.Images[0].Url,
            ReleaseDate = fullAlbum.ReleaseDate
        };
    }

    public static Song createSongModel(SimpleTrack simpleTrack, String albumName){
        return new Song{
            ID = simpleTrack.Id,
            TrackPos = simpleTrack.TrackNumber,
            Name = simpleTrack.Name,
            ArtistName = simpleTrack.Artists,
            AlbumName = albumName
        }; 
    }
}