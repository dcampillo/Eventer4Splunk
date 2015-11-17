using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetEventer
{


    public class EventFactory
    {


        private List<EventFieldDefinition> _fields = new List<EventFieldDefinition>();
        private bool _appendCorrelationID = false;
        private string _correlationID = Guid.NewGuid().ToString();
        private string _correlationIDFieldName = "correlationid";
        private const string _applicationNameField = "application";
        private string _applicationName;
        private EventQueue _queue = new EventQueue();


        /// <summary>
        /// Initialize a new EventFactory object
        /// </summary>
        public EventFactory(String ApplicationName)
            : this(ApplicationName, false)
        {


        }

        /// <summary>
        /// Initialize a new EventFactory object
        /// </summary>
        /// <param name="AppendCorrelationID">Indicates if the factory will append a CorrelationID field to each new event</param>
        public EventFactory(string ApplicationName, bool AppendCorrelationID)
        {
            _appendCorrelationID = AppendCorrelationID;
            _applicationName = ApplicationName;
            _fields.Add(new EventFieldDefinition(_applicationNameField, false));
        }

        /// <summary>
        /// Get the collection of Event Field used to generate a new event
        /// </summary>
        public List<EventFieldDefinition> Fields
        {
            get
            {
                return _fields;
            }
        }

        /// <summary>
        /// Initialize a new Event
        /// </summary>
        /// <returns>An initialized event containing all field definition</returns>
        public Event NewEvent()
        {
            return this.NewEvent(false);
        }

        /// <summary>
        /// Initialize a new Event
        /// </summary>
        /// <param name="SetNewCorrelationID">Indicate that the Correlation ID must be renewed</param>
        /// <returns>An initialized event containing all field definition</returns>
        public Event NewEvent(bool SetNewCorrelationID)
        {
            //Event _event = new Event();
            Event _event;
            _event = _queue.AddEvent();

            if (SetNewCorrelationID)
            {
                _correlationID = Guid.NewGuid().ToString();
            }

            //_event.Fields.Add(new EventField(_timestampFieldName, DateTime.Now.ToString()));
            // Add application name field


            //_event.Fields.Add(new EventField(_applicationNameField, false));

            // Initialize fields
            foreach (EventFieldDefinition _field in _fields)
            {
                _event.Fields.Add(new EventField(_field.Name, _field.IsNumber));
            }

            // Set application name value
            _event[_applicationNameField].Value = _applicationName;

            if (_appendCorrelationID)
            {
                _event.Fields.Add(new EventField(_correlationIDFieldName, _correlationID.ToString()));
            }

            return _event;

        }

        public string GenerateNewCorrelationID()
        {
            _correlationID = Guid.NewGuid().ToString();
            return _correlationID.ToString();
        }

        /// <summary>
        /// Get the bool value indicating if the factory will append a CorrelationID field to each new event
        /// </summary>
        public bool AppendCorrelationID
        {
            get
            {
                return _appendCorrelationID;
            }
            set
            {
                _appendCorrelationID = value;
            }
        }

        /// <summary>
        /// Gets or sets a string coresponding to the name of the Correlation ID field. Default is correlationid
        /// </summary>
        public string CorrelationIDFieldName
        {
            get
            {
                return _correlationIDFieldName;
            }
            set
            {
                _correlationIDFieldName = value;
            }
        }

        public string CorrelationID
        {
            get
            {
                return _correlationID;
            }
            set
            {
                _correlationID = value;
            }
        }

        /// <summary>
        /// Render all events
        /// </summary>
        /// <returns>Event rendered as string</returns>
        public string Flush()
        {
            StringBuilder _sb = new StringBuilder();

            while (_queue.Count != 0)
            {
                _sb.AppendLine( _queue.Dequeue().Render());
            }

            return _sb.ToString();
        }

    }
}
