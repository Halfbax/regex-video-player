using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexVideoPlayer.ViewModel
{
    class ParsingData
    {
        public string pattern { get; set; }

        public int groupId { get; set; }

        public ParsingData data { get; set; }
    }

    class Show
    {
        public string name { get; set; }

        public int Episodes { get; set; }

        public string initialURI { get; set; }

        public ParsingData data { get; set; }
    }

    class ConfigurationViewModel
    {
        public IEnumerable<Show> shows { get; set; }
    }
}
