using CommonInitializer;
using DrainagetubeService.Domain.Events;
using Juqianxie.ASPNETCore;
using Microsoft.AspNetCore.Mvc;
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
    public class BulkAddRequest
    {
        public string TranID { get; set; }
        public long Uid { get; set; }
        public IEnumerable<BulkAddRequestStructure> bulkAddStructures { get; set; }
        public BulkAddRequest() { bulkAddStructures = new List<BulkAddRequestStructure>(); }
       

    }
    public class BulkAddRequestStructure
    {
        public DateTime RecordTime { get; set; }
        public string LiquidColor { get; set; }
        public string LiquidProperty { get; set; }
        public string Liquidodour { get; set; }
        public string TubeState { get; set; }
        public float Volume { get; set; }
        /// <summary>
        /// 管子ID
        /// </summary>
        public string Tubekey { get; set; }
    }
    public class TubeBulkAddRequest
    {
        public string TranID { get; set; }
        public long Uid { get; set; }
        public IEnumerable<TubeBulkAddStructure> tubeBulkAddStructures { get; set; }
        public TubeBulkAddRequest() { tubeBulkAddStructures = new List<TubeBulkAddStructure>(); }
    }
    public class TubeBulkAddStructure
    {
        public string tubeType { get; set; }
        public string tubePosition { get; set; }
        public string tubeExtention { get; set; }
    }
}
