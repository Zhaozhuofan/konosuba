using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konosuba.Helpers
{
    public class WebHelper
    {
        public const string BseeUrl = "http://konosuba.com/1st/character/";

        


        public static async Task<(List<string> Icon, List<string> Portrait)> GetPictureUrl()
        {
            var context = new BrowsingContext(Configuration.Default.WithDefaultLoader());
            var doc = await context.OpenAsync(BseeUrl);

            var iconResult = new List<string?>();
            foreach (var img in doc.QuerySelectorAll("#bx-pager > a img"))
            {
                iconResult.Add(img.GetAttribute("src"));
            }

            var portraitResult = new List<string?>();
            foreach (var img in doc.QuerySelectorAll("ul.bxslider li img"))
            {
                portraitResult.Add(img.GetAttribute("src"));
            }
            
            return (iconResult, portraitResult);
        }

      
    }
}
