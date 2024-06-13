using Microsoft.AspNetCore.Mvc;

namespace NEP.Controllers
{
    public class StyleController : Controller
    {
        [HttpGet]
        public IActionResult Index(string css)
        {
            string cssString = string.Empty;
            if (css == "gsmservice")
            {
                cssString = "@font-face {font-family: Poppins;src: url('/gsm/content/gsmservice/css/fonts/Poppins-light.ttf') format('truetype');}" +
                    "@font-face {font-family: Poppins-Bold;src: url('/gsm/content/gsmservice/css/fonts/Poppins-bold.ttf') format('truetype');}" +
                    "@font-face {font-family: NameFont;src: url('/gsm/content/gsmservice/css/fonts/Gilroy-Black.ttf') format('truetype');" +
                    "/* Additional properties if needed */font-weight: normal;font-style: normal;}" +
                    "@font-face {font-family: CEOFont;src: url('/gsm/content/gsmservice/css/fonts/Gobold Regular.otf') format('opentype');" +
                    "/* Additional properties if needed */font-weight: normal;font-style: normal;}" +
                    "@font-face {font-family: LinksFont;src: url('/gsm/content/gsmservice/css/fonts/Gilroy-SemiBold.ttf') format('truetype');" +
                    "/* Additional properties if needed */font-weight: normal;font-style: normal;}" +
                    ".nep-container {display: flex;}" +
                    ".nep-box {flex: 1;border: none}";
            }
            return Content(cssString, "text/css");
        }
    }
}
