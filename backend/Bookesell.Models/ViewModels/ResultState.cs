using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookesell.Models.ViewModels
{
    public class ResultStateWithModel<T> : ResultState
    {
        public ResultStateWithModel() : base("OK", "Successful", string.Empty)
        { }

        [JsonPropertyName("data")]
        public T Data { get; set; }

    }

    public class ResultState
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        public ResultState(string code, string title, string detail)
        {
            Code = code;
            Title = title;
            Detail = detail;
        }

    }

}
