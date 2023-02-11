// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace UrlResponse
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetTodoItems();
        }
        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync("https://official-joke-api.appspot.com/random_joke");
            //Console.WriteLine(response);

            //var serializerSettings = new JsonSerializerSettings();
            //serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //var json = JsonConvert.SerializeObject(response, serializerSettings);
            var asd = JObject.Parse(response);
            var todo = JsonConvert.DeserializeObject(response);
            Console.WriteLine(todo);
        }
    }
}
class todo
{
    public string type { get; set; }
    public string setup { get; set; }
    public string punchline { get; set; }
    public int id { get; set; }
}
//class todo
//{
//    public string activity { get; set; }
//    public string type { get; set; }
//    public int participants { get; set; }
//    public float price { get; set; }
//    public string link { get; set; }
//    public int key { get; set; }
//    public float accessibility { get; set; }
//}

//"activity":"Play a game of tennis with a friend","type":"social","participants":2,
//"price":0.1,"link":"","key":"1093640","accessibility":0.4}

//{ "type":"general","setup":"Have you heard the rumor going around about butter?",
//"punchline":"Never mind, I shouldn't spread it.","id":112}