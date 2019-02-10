using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WFLite.Activities.Console;
using WFLite.Json.Converters;
using WFLite.Json.HelloWorld.Entities;
using WFLite.Variables;

namespace WFLite.Json.HelloWorld
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var activity = new ConsoleWriteLineActivity()
            {
                Value = new AnyVariable()
                {
                    Value = new Message() { Value = "Hello World!" },
                    Converter = new SerializeConverter()
                    {
                        Formatting = new AnyVariable<Formatting>(Formatting.Indented)
                    }
                }
            };

            await activity.Start();

            Console.ReadKey();
        }
    }
}
