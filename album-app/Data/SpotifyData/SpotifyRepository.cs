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

    public async Task<FullAlbum> GetAlbum()
    {
        var response = await new OAuthClient(config).RequestToken(request);
        var client = new SpotifyClient(config.WithToken(response.AccessToken));

        return await client.Albums.Get("5qKAJg56GqQIrxajvzaiEC");;
    }

}