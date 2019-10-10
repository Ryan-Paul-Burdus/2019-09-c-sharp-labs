
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation; //use for ping
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace just_do_it_HTTP_Console_App
{
    class Program
    {
        static string url = "https://localhost:44337/api/products";
        static List<Product> products = new List<Product>();
        static void Main(string[] args)
        {
            Console.WriteLine("enter anything when page has loaded..");
            Console.ReadLine();



            using (WebClient wc = new System.Net.WebClient())
            {
                Console.WriteLine("requesting..");
                var json = wc.DownloadString("https://localhost:44337/api/values/");
                //wc
                Console.WriteLine(json.ToString());
            }



            GetAsync();
            Console.WriteLine("end of Main()..");
            Console.ReadLine();
        }



        static public async void GetAsync()
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("requesting..\n");
                var jsonString = await client.GetAsync("https://localhost:44337/Customers/details/");
                Console.WriteLine(jsonString.ToString());
                Console.WriteLine(jsonString.Content);
                Console.WriteLine("\n\nrequest ended..");
            }

        }

        public static void TestCode()
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine($"Is local network live: {NetworkInterface.GetIsNetworkAvailable()}");
            Console.WriteLine($"Is network live: {IsNetworkLive()}");
            GetAPIDataAsync();
            Console.ReadLine();
            GetAPIDataAsync();
            Console.ReadLine();
            GetAPIDataAsync();
            Console.ReadLine();
        }

        public static bool IsNetworkLive()
        {
            //do something to check if network connection is ok first
            //many ways to do this - try a PING
            var pingGoogle = new Ping();
            var pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
            string data = "abcdefghijklmnopqrstuvxyz";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            var timeout = 120;
            //send 4 pings
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Loop {i}\n");
                var reply = pingGoogle.Send("8.8.8.8", timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            return false;
        }
        static async void GetAPIDataAsync()
        {
            using (var client = new HttpClient())
            {
                var s = new Stopwatch();
                s.Start();
                //raw string
                var JSONstring = await client.GetStringAsync(url);
                //convert to object 'deserialise'
                //use newtonsoft
                products = JsonConvert.DeserializeObject<List<Product>>(JSONstring);
                s.Stop();
                Console.WriteLine($"Query took: {s.ElapsedMilliseconds} milliseconds");
                Console.WriteLine("about to print products");
                printProducts();
            }
        }
        static void printProducts()
        {
            products.ForEach(p =>
            {
                Console.WriteLine($"{p.ProductID,-15},{p.ProductName}");
            });
        }
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            this.Products = new List<Product>();
        }
    }
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }
}



