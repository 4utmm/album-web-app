using Microsoft.Extensions.Primitives;
using SpotifyAPI.Web;

interface IOrderGame {

    /// <summary>
    /// Method specifies wether or not the track list has been ordered correctly.
    /// </summary>
    /// <returns>Returns true if order is correct.</returns>
    Boolean isOrderCorrect();
    
    /// <summary>
    /// Method retrieves the incorrectly ordered index.
    /// </summary>
    /// <returns>Returns integer array which value is 0 if track is in correct index and the actual place it
    ///  should be if it is not in correct index.</returns>
    int[] incorrectTrackIndex();
    
    /// <summary>
    /// Method retrieves the total count of songs on the album.
    /// </summary>
    /// <returns>Integer value of the track count.</returns>
    int getTrackCount();

    /// <summary>
    /// Method retrieves the name of each album.
    /// </summary>
    /// <returns>Returns array of strings of each track name corresponding to the index of the album.</returns>
    List<SimpleTrack> getTrackList();

    /// <summary>
    /// Method takes the track list then shuffles it.
    /// </summary>
    /// <returns>Returns array of strings of each track name in no particular order.</returns>
    List<SimpleTrack> getShuffledTrackList();

    /// <summary>
    /// Gets the album art corresponding to the album.
    /// </summary>
    /// <returns>Returns string url which corresponds to the album art.</returns>
    string getAlbumArt();

    /// <summary>
    /// Retreives album's title.
    /// </summary>
    /// <returns>Returns string of album name.</returns>
    string getAlbumName();

    /// <summary>
    /// Retrieve's the artist who created the album
    /// </summary>
    /// <returns>Returns array of string of artists who created album.</returns>
    List<SimpleArtist> getAlbumArtists();

    /// <summary>
    /// Retrieves the release date of the album.
    /// </summary>
    /// <returns>Returns string of the album release date in the format YYYY-MM.</returns>
    string getAlbumReleaseDate();

    /// <summary>
    /// Places shuffled track into final array.
    /// </summary>
    void placeTrack(SimpleTrack track, int index);

    /// <summary>
    /// Removes shuffled track into final array.
    /// </summary>
    void removeTrack(int index);

    /// <summary>
    /// Scan final array to see if ordered correctly.
    /// </summary>
    void solve();
}