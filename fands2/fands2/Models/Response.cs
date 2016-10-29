using System.ComponentModel.DataAnnotations;

namespace fands2.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        public string RequestedMethod { get; set; }
        public string RequestedUrl { get; set; }
        public string ResponseCode { get; set; }
        public int ResponseTime { get; set; }

    }
}