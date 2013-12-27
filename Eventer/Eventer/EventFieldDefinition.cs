using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetEventer
{
    /// <summary>
    /// Implements an event field definition
    /// </summary>
    public class EventFieldDefinition
    {
        private string _fieldName = string.Empty;
        private bool _isNumber = false;

        /// <summary>
        /// Initialize a new EventFieldDefinition
        /// </summary>
        /// <param name="Name">Name of the field</param>
        /// <param name="IsNumber">Bool value that indicate if the field is a number</param>
        public EventFieldDefinition(string Name, bool IsNumber)
        {
            _fieldName = Name;
            _isNumber = IsNumber;

        }

        /// <summary>
        /// Return the name of field
        /// </summary>
        public string Name
        {
            get
            {
                return _fieldName;
            }
            set
            {
                _fieldName = value;
            }
        }

        /// <summary>
        /// Get or set a boolean value indicating if the field is a number or not
        /// </summary>
        public bool IsNumber
        {
            get
            {
                return _isNumber;
            }
            set
            {
                _isNumber = value;
            }
        }
    }
}
