using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetEventer
{
    class EventQueue : System.Collections.Generic.Queue<Event>
    {

        public EventQueue()
        {

        }

        public Event AddEvent()
        {
            Event _event = new Event();
            this.Enqueue(_event);

            return _event;
        }
    }
}
