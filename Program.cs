using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

namespace console {
    class Program {
        private static HttpClient client = new HttpClient();        
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            //            ProcessRepository().Wait();
            var result = ProcessRepositories().Result;
            foreach( var repo in result)
            {
                Console.WriteLine("-------");
                Console.WriteLine("{0}-{1}\n{2}",
                    repo.Name
                    ,repo.Description
                    ,repo.HomePage);
                Console.WriteLine("-------");
            }
        }
        public static async Task ProcessRepository () {
            var serializer = new DataContractJsonSerializer(typeof(List<Repository>));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
//            var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = serializer.ReadObject(await streamTask) as List<Repository>;
//            var msg = await stringTask;
//            Console.WriteLine(msg);
            foreach( var repo in repositories)
                Console.WriteLine(repo.Name);
        }
        public static async Task<List<Repository>> ProcessRepositories()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Repository>));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = serializer.ReadObject(await streamTask) as List<Repository>;
            return repositories;
        }
    }
}