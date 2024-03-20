using System.IO;

namespace _1_7Solution
{
    internal class Program
    {

        class Application
        {
            public ProtectedData protecteds { get; set; }
        }
        class ProtectedData
        {
            public string shieldLastRun { get; set; }
        }
        class ApplicationInfo
        {
            public string Path { get; set; }
            public string Name { get; set; }
        }
        class Product
        {
            public Product(string sku, decimal price)
            {
                SKU = sku;
                Price = price;
            }

            public string SKU { get; set; }
            public decimal Price { get; set; }
        }
        class Laptop
        {
            private string _os;

            public Laptop(string os)
            {
                _os = os;
            }

            public string GetOs()
            {
                return _os;
            }
        }
        class EventPublisher
        {
            public event EventHandler MyEvent;
            public void RaiseEvent()
            {
                MyEvent?.Invoke(this, EventArgs.Empty);
            }
        }
        class EventSubscriber : IDisposable
        {
            private readonly EventPublisher _publisher;

            public EventSubscriber(EventPublisher publisher)
            {
                _publisher = publisher;
                _publisher.MyEvent += OnMyEvent;
            }

            private void OnMyEvent(object sender, EventArgs e)
            {
                Console.WriteLine("MyEvent raised");
            }

            public void Dispose()
            {
                _publisher.MyEvent -= OnMyEvent;
            }
        }
        class TreeNode
        {
            private readonly List<TreeNode> _children = new List<TreeNode>();

            public void AddChild(TreeNode child)
            {
                _children.Add(child);
            }

            // opt. implement for a method to remove chlid nodes
            public void RemoveChild(TreeNode child)
            {
                _children.Remove(child);
            }
        }
        class Cache
        {
            private static readonly Dictionary<int, object> _cache = new Dictionary<int, object>();


            public static void Add(int key, object value)
            {

                _cache[key] = value;

            }

            public static object Get(int key)
            {

                return _cache.ContainsKey(key) ? _cache[key] : null;

            }
        }


        static void Main(string[] args)
        {

            //usage no 2
            string path = "C:/apps/";
            string name = "Shield.exe";
            ApplicationInfo appInfo = GetApplicationInfo(path, name);

            //usage no 3
            var laptop = new Laptop("macOs");
            Console.WriteLine(laptop.GetOs());

            //usage no 4
            while (true)
            {

                var myList = new List<Product>(); // Create a new list for each iteration

                for (int i = 0; i < 1000; i++) // populate list with 1000 integers
                {
                    myList.Add(new Product(Guid.NewGuid().ToString(), i));
                }

                Console.WriteLine(myList.Count);

                myList = null; // Allow the list to be garbage collected
            }

            //no 5
            var publisher = new EventPublisher();
            while (true)
            {
                using (var subscriber = new EventSubscriber(publisher))
                {
                    // do something 
                }
            }

            var rootNode = new TreeNode();
            while (true)
            {
                for (int i = 0; i < 10001; i++)
                {
                    var childNode = new TreeNode();
                    rootNode.AddChild(childNode);
                }
            }

            //no6
            PopulateCache();
            Console.WriteLine("Cache populated");
            Console.ReadLine();
        }


        private string no1(Application request)
        {
            if (request?.protecteds?.shieldLastRun != null)
            {
                return request.protecteds.shieldLastRun;
            }
            return null;
        }
        //no 2
        private static ApplicationInfo GetApplicationInfo(string path, string name)
        {
            var application = new ApplicationInfo
            {
                Path = path,
                Name = name
            };
            return application;


        }
        //no 5
        
        //no6
        
        static void PopulateCache()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Cache.Add(i, new object());
            }
        }
       

    }
}
