using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEventer;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace EventerTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Eventer4Splunk Test Application");
            Console.WriteLine("---------------------------------\n");
            GenerateLogs();
            Console.ReadKey();
        }

        static void GenerateLogs()
        {
            EventFactory _e = new EventFactory("LogGeneratorSample", true);

            // Setup event factory with three fields
            _e.Fields.Add(new EventFieldDefinition("message", false));
            _e.Fields.Add(new EventFieldDefinition("level", false));
            _e.Fields.Add(new EventFieldDefinition("status", true));

            // Create a new event
            Event _ev = _e.NewEvent();

            // Fill the newly created event
            _ev["message"].Value = "This is a sample message";
            _ev["level"].Value = "verbose";
            _ev["status"].SetValue(200);


            Console.WriteLine("\n" + _e.Flush());


            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();





        }

    }
}
