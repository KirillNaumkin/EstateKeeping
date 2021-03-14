using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Учёт_аренды.Data
{
    class Banker
    {
        private const string _data_url = "";
        private static async Task<Stream> GetDataStreamAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_data_url, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        public static IEnumerable<string> GetDataLines()
        {
            var data_stream = GetDataStreamAsync().Result;
            var data_reader = new StreamReader(data_stream);
            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line;
            }
            yield break;
        }

        private static void ProcessDataLines()
        {
            foreach (var data_line in GetDataLines())
            {
                Console.WriteLine(data_line);
            }
            Console.ReadLine();
        }
    }
}
