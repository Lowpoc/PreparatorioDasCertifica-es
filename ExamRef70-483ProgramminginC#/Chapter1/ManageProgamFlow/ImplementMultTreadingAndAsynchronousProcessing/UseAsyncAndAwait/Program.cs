using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace UseAsyncAndAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DownloadContent().Result);
        }


        static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("https://www.microsoft.com");
                return result;
            }   
        }
    }
}
