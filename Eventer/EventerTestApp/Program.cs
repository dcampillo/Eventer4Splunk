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
            Console.Write("Output to splunk [y]es / [n]o ? ");
            ConsoleKeyInfo _key = Console.ReadKey();
            GenerateLogs(_key);
            Console.ReadKey();
        }

        static void GenerateLogs(ConsoleKeyInfo Key)
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
            _ev["status"].Value = "OK";

            if (Key.KeyChar == char.Parse("y"))
            {
                TcpClient _t = new TcpClient("splunkmaster.zorglub.local", 4646);
                StreamWriter _sw = new StreamWriter(_t.GetStream());
                // Flush events as string
                _sw.Write(_e.Flush());
                _sw.Flush();
                _sw.Close();
            }
            else
            {
                Console.WriteLine("\n" + _e.Flush());
            }
            

            Console.ReadKey();





        }

    }
}
