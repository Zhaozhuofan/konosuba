using AngleSharp;

namespace konosuba.Helpers
{
    public class WebHelper
    {
        public const string BseeUrl = "http://konosuba.com/1st/character/";

        /// <summary>
        /// 通过AngleSharper提供的方法在官网上拿到角色的icon和portrait信息
        /// </summary>
        /// <returns>返回角色icon和Protrait的List</returns>
        public static async Task<(List<string> Icon, List<string> Portrait)> GetPictureUrl()
        {
            var context = new BrowsingContext(Configuration.Default.WithDefaultLoader());
            var doc = await context.OpenAsync(BseeUrl);

            var iconResult = new List<string?>();

            foreach (var img in doc.QuerySelectorAll("#bx-pager > a img"))
                iconResult.Add(img.GetAttribute("src"));


            var portraitResult = new List<string?>();
            foreach (var img in doc.QuerySelectorAll("ul.bxslider li img"))
                portraitResult.Add(img.GetAttribute("src"));


            return (iconResult, portraitResult);
        }


    }
}
