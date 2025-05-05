using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using SpotifyAPI.Web;


namespace album_app.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }



    public void OnGet()
    {

    }
}
