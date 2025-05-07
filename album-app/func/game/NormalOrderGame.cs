using SpotifyAPI.Web;

class NormalOrderGame : IOrderGame {

    private FullAlbum album; 

    private List<SimpleTrack> trackList;
    private List<SimpleTrack> shuffledTrackList;
    private SimpleTrack[] finalTackList;
    private Boolean solved;
    private static Random rng = new Random();

    public NormalOrderGame(FullAlbum album) { //NOT READY
        this.album = album;
        this.trackList = getTrackList();
        this.shuffledTrackList = this.trackList;
        solved = false;

        int count = shuffledTrackList.Count;
        this.finalTackList = new SimpleTrack[count];

        while (count > 1) {
            count--;
            int next = rng.Next(count + 1);
            var value = this.shuffledTrackList[next];
            this.shuffledTrackList[next] = this.shuffledTrackList[count];
            this.shuffledTrackList[count] = value;
        }

    }

    public Boolean isOrderCorrect(){
        return solved;
    }

    public int[] incorrectTrackIndex(){ 
        int[] incorrectTracks = new int[album.TotalTracks];
    
        int pointer = 0;
        foreach (SimpleTrack t in trackList){
            if (t.GetHashCode != finalTackList[pointer].GetHashCode){
                incorrectTracks[pointer] = finalTackList[pointer].TrackNumber;
            }
            else {
                incorrectTracks[pointer] = 0;
            }
        }
    
        return incorrectTracks;
    }

    public int getTrackCount(){
        return album.TotalTracks;
    }

    public List<SimpleTrack> getTrackList(){
        return album.Tracks.Items;
    }

    public List<SimpleTrack> getShuffledTrackList(){
     return shuffledTrackList;
    }

    public string getAlbumArt(){
        return album.Images[0].Url;
    }

    public string getAlbumName(){
        return album.Name;
    }

    public List<SimpleArtist> getAlbumArtists(){
        return album.Artists;
    }

    public string getAlbumReleaseDate(){
        return album.ReleaseDate;
    }

    public void placeTrack(SimpleTrack track, int index){
        finalTackList[index] = track;
    }

    public void removeTrack(int index){
        finalTackList[index] = null;
    }

    public void solve(){
        int pointer = 0;
        foreach (SimpleTrack t in trackList){
            if (t.GetHashCode != finalTackList[pointer].GetHashCode){
                solved = false;
                return;
            }
        }
        
        solved = true;
    }
}