using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using ChatGptIntegration;
using System.Net.Http;
using System.Text.Json;

namespace ChatGptIntegration
{
    public class Integration
    {
        string OPENAI_API_KEY = "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"; // https://beta.openai.com/account/api-keys

        public async Task CallAPIAsync ( )
        {
            // Read entire text file content in one string.
            string text = System.IO.File.ReadAllText(@"C:\\User.cs");


            CompletionResponse completionResponse = null;

            //string Query ="Can you edit code and write comments in given code ? " +text;
            //string Query1 =   text+ " Can you find errors in given C# code and edit it ?";
            //string Query2 = "Can you write c# unit test cases for given code ?" +  text;
            //string Query1 =   text + " Can you find errors in given C# code and edit it ?";
            //Console.WriteLine ( Query );

            string Query ="# Can you edit code and write comments in given code ?"
                +"# Can you find errors in given C# code and edit it ?"
                +"# Can you write c# unit test cases for given code ? "
                + text;


            CompletionRequest completionRequest = new CompletionRequest
            {
                Model = "text-davinci-003",
                Prompt = Query,
                MaxTokens = 1000,
            };


            try
            {
                using ( HttpClient httpClient = new HttpClient () )
                {
                    using ( var httpReq = new HttpRequestMessage ( HttpMethod.Post, "https://api.openai.com/v1/completions" ) )
                    {
                        httpReq.Headers.Add ( "Authorization", $"Bearer {OPENAI_API_KEY}" );
                        string requestString = JsonSerializer.Serialize(completionRequest);
                        httpReq.Content = new StringContent ( requestString, Encoding.UTF8, "application/json" );
                        using ( HttpResponseMessage? httpResponse = await httpClient.SendAsync ( httpReq ) )
                        {
                            if ( httpResponse is not null )
                            {
                                if ( httpResponse.IsSuccessStatusCode )
                                {
                                    string responseString = await httpResponse.Content.ReadAsStringAsync();
                                    {
                                        if ( !string.IsNullOrWhiteSpace ( responseString ) )
                                        {
                                            completionResponse = JsonSerializer.Deserialize<CompletionResponse> ( responseString );
                                        }
                                    }
                                }
                            }
                            if ( completionResponse is not null )
                            {
                                string ? completionText = completionResponse.Choices ? [0]?.Text;
                                Console.WriteLine ( completionText );
                            }
                            else
                            {
                                Console.WriteLine ( "Something is wrong......" );
                            }
                            Console.WriteLine ( "Process completed." );
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine ( ex.Message );
            }


        }

    }
}