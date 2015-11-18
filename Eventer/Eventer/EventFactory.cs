using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetEventer
{


    public class EventFactory : IDisposable
    {


        private List<EventFieldDefinition> _fields = new List<EventFieldDefinition>();
        private bool _appendTransactionID = false;
        private string _transactionID = Guid.NewGuid().ToString();
        private string transactionIDFieldName = "transactionid";
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
            _appendTransactionID = AppendCorrelationID;
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
        /// <param name="SetNewTransactionID">Indicate that the Correlation ID must be renewed</param>
        /// <returns>An initialized event containing all field definition</returns>
        public Event NewEvent(bool SetNewTransactionID)
        {
            //Event _event = new Event();
            Event _event;
            _event = _queue.AddEvent();

            if (SetNewTransactionID)
            {
                _transactionID = Guid.NewGuid().ToString();
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

            if (_appendTransactionID)
            {
                _event.Fields.Add(new EventField(transactionIDFieldName, _transactionID.ToString()));
            }

            return _event;

        }

        [Obsolete("Procedure GenerateNewCorrelationID is obsolete, use GenerateNewTransactionID instead")]
        public string GenerateNewCorrelationID()
        {
            _transactionID = Guid.NewGuid().ToString();
            return _transactionID.ToString();
        }

        public string GenerateNewTransactionID()
        {
            _transactionID = Guid.NewGuid().ToString();
            return _transactionID.ToString();
        }



        /// <summary>
        /// Get the bool value indicating if the factory will append a CorrelationID field to each new event
        /// </summary>
        /// 
        [Obsolete("Property AppendTransactionID is obsolete, use AppendTransactionID instead")]
        public bool AppendCorrelationID
        {
            get
            {
                return _appendTransactionID;
            }
            set
            {
                _appendTransactionID = value;
            }
        }

        public bool AppendTransactionID
        {
            get
            {
                return _appendTransactionID;
            }
            set
            {
                _appendTransactionID = value;
            }
        }

        /// <summary>
        /// Gets or sets a string coresponding to the name of the Correlation ID field. Default is correlationid
        /// </summary>
        /// 
        [Obsolete("Property CorrelationIDFieldName is obsolete, use TransactionIDFieldName instead")]
        public string CorrelationIDFieldName
        {
            get
            {
                return transactionIDFieldName;
            }
            set
            {
                transactionIDFieldName = value;
            }
        }

        public string TransactionIDFieldName
        {
            get
            {
                return transactionIDFieldName;
            }
            set
            {
                transactionIDFieldName = value;
            }
        }

        [Obsolete("Property CorrelationID is obsolete, use TransactionID instead")]
        public string CorrelationID
        {
            get
            {
                return _transactionID;
            }
            set
            {
                _transactionID = value;
            }
        }

        public string TransactionID
        {
            get
            {
                return _transactionID;
            }
            set
            {
                _transactionID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Flush()
        {
            return this.Flush(false);
        }

        /// <summary>
        /// Render all events
        /// </summary>
        /// <param name="RenderEmptyField">Redner null or empty field. Default = false</param>
        /// <returns>Event rendered as string</returns>
        public string Flush(bool RenderEmptyField)
        {
            StringBuilder _sb = new StringBuilder();

            while (_queue.Count != 0)
            {
                _sb.AppendLine(_queue.Dequeue().Render(RenderEmptyField));
            }

            return _sb.ToString();
        }

        public void Dispose()
        {
            _queue.Clear();
            _fields.Clear();
        }
    }
}
