using System.Net;
using System.Text.RegularExpressions;

namespace RegexVideoPlayer.Core
{
    class Parser
    {
        /// <summary>
        /// Downloads the source code of the given <see cref="System.Uri">URI</see> and returns the regex match.
        /// </summary>
        /// <param name="url">URI where the video is embed</param>
        /// <param name="pattern">See <see cref="System.Text.RegularExpressions">RegEx</see></param>
        /// <param name="grpId">Regex group id</param>
        /// <returns>RegEx match</returns>
        public static string ExtractData(string url, string pattern, int grpId = 0)
        {
            string html;
            using (WebClient client = new WebClient())
                html = client.DownloadString(url);
            return Regex.Match(html, pattern).Groups[grpId].Value;
        }
    }
}
