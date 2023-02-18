using Newtonsoft.Json;

namespace Data.Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}