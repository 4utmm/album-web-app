using SpotifyAPI.Web;

class NormalOrderGame : IOrderGame {

    private Album album; 

    private List<Song> trackList;
    private List<Song> shuffledTrackList;
    private List<Song> finalTrackList;
    private Boolean solved;
    private static Random rng = new Random();

    public NormalOrderGame(Album album) { //NOT READY
        this.album = album;
        this.trackList = album.Songs;
        this.shuffledTrackList = this.trackList;
        solved = false;

        int count = shuffledTrackList.Count;
        this.finalTrackList = new List<Song>();

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
        int[] incorrectTracks = new int[album.TrackCount];
    
        int pointer = 0;
        foreach (Song t in trackList){
            if (t.ID != finalTrackList[pointer].ID){
                incorrectTracks[pointer] = finalTrackList[pointer].TrackPos;
            }
            else {
                incorrectTracks[pointer] = 0;
            }
        }
    
        return incorrectTracks;
    }

    public int getTrackCount(){
        return album.TrackCount;
    }

    public List<Song> getTrackList(){
        return album.Songs;
    }

    public List<Song> getShuffledTrackList(){
     return shuffledTrackList;
    }

    public string getAlbumArt(){
        return album.AlbumArt;
    }

    public string getAlbumName(){
        return album.Name;
    }

    public List<SimpleArtist> getAlbumArtists(){
        return album.ArtistName;
    }

    public string getAlbumReleaseDate(){
        return album.ReleaseDate;
    }

    public void placeTrack(Song track, int index){
        finalTrackList[index] = track;
    }

    public void removeTrack(int index){
        finalTrackList[index] = null;
    }

    public void solve(){
        int pointer = 0;
        foreach (Song t in trackList){
            if (t.GetHashCode != finalTrackList[pointer].GetHashCode){
                solved = false;
                return;
            }
        }
        
        solved = true;
    }
}