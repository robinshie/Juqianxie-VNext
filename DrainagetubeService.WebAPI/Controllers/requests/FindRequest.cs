using CommonInitializer;
using System.Collections;

namespace CommonInitializer
{
    public class FindRequest
    {
        public int pageindex { get; set; }
        public int pageLen { get; set; }
        public IEnumerable<JConfig>? conditions { get; set; }
        public FindRequest()
        {
            //conditions = new List<JConfig>();
        }

    }
}
