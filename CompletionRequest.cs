using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ChatGptIntegration
{
   
    public class CompletionRequest
    {
        [JsonPropertyName ( "model" )]
        public string? Model
        {
            get;
            set;
        }
        [JsonPropertyName ( "prompt" )]
        public string? Prompt
        {
            get;
            set;
        }
        [JsonPropertyName ( "max_tokens" )]
        public int? MaxTokens
        {
            get;
            set;
        }

        //[JsonPropertyName ( "finish_reason" )]
        //public string? FinishReason
        //{
        //    get;
        //    set;
        //}
    }
}