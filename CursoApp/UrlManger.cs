using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp
{
    public static class UrlManger
    {
        public static async Task<Stream?> GetImageStream(string? url)
        {
            if(string.IsNullOrEmpty(url))
            {
                return null;
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(10);
                    // Send GET request and get the response
                    var httpResponse = await httpClient.GetAsync(url);

                    // Check for successful response
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        // Return the content stream
                        return await httpResponse.Content.ReadAsStreamAsync();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

    }
}
