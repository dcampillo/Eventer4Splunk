using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetEventer
{
    /// <summary>
    /// Implements a new event field
    /// </summary>
    public class EventField
    {

        private bool _isNumber = false;
        private string _fieldName = string.Empty;
        private string _fieldValue = string.Empty;

        /// <summary>
        /// Initialize a new event field
        /// </summary>
        /// <param name="Name">Name of the field</param>
        public EventField(string Name)
            : this(Name, string.Empty)
        {

        }

        /// <summary>
        /// Initialize a new event field
        /// </summary>
        /// <param name="Name">Name of the field</param>
        /// <param name="IsNumber">Indicated if this field should be considered as number</param>
        public EventField(string Name, bool IsNumber)
            : this(Name, string.Empty)
        {
            _isNumber = IsNumber;
        }
        /// <summary>
        /// Initialize a new event field
        /// </summary>
        /// <param name="Name">Name of the value</param>
        /// <param name="Value">Int value</param>
        public EventField(string Name, int Value)
            : this(Name, Value.ToString())
        {
            _isNumber = true;
        }

        /// <summary>
        /// Initialize a new event field
        /// </summary>
        /// <param name="Name">Name of the field</param>
        /// <param name="Value">Float value</param>
        public EventField(string Name, float Value)
            : this(Name, Value.ToString())
        {
            _isNumber = true;
        }

        /// <summary>
        /// Initialize a new event field
        /// </summary>
        /// <param name="Name">Name of the field</param>
        /// <param name="Value">String value</param>
        public EventField(string Name, string Value)
        {
            _fieldName = Name;
            _fieldValue = Value;
        }

        /// <summary>
        /// Get or set the field value
        /// </summary>
        public string Value
        {
            get
            {

                return _fieldValue;

            }
            set
            {
                _fieldValue = value;
            }
        }

        /// <summary>
        /// Set field value
        /// </summary>
        /// <param name="Value"></param>
        public void  SetValue(string Value)
        {
            _fieldValue = Value;
        }

        /// <summary>
        /// Set field value
        /// </summary>
        /// <param name="Value"></param>
        public void SetValue(int Value)
        {
            _fieldValue = Value.ToString();
        }

        /// <summary>
        /// Set field value
        /// </summary>
        /// <param name="Value"></param>
        public void SetValue(Double Value)
        {
            _fieldValue = Value.ToString();
        }

        /// <summary>
        /// Set field value
        /// </summary>
        /// <param name="Value"></param>
        public void SetValue(float Value)
        {
            _fieldValue = Value.ToString();
        }

        /// <summary>
        /// Set field value
        /// </summary>
        /// <param name="Value"></param>
        public void SetValue(bool Value)
        {
            if (Value)
            {
                _fieldValue = "1";
            }
            else
            {
                _fieldValue = "0";
            }
        }

        /// <summary>
        /// Get a formatted value taking care of space and numbers
        /// </summary>
        /// <returns>Returns a formated string</returns>
        public string GetFormatedValue()
        {
            if (_isNumber)
            {
                return _fieldValue;
            }
            else
            {
                if (_fieldValue.Contains(" "))
                {
                    return string.Format("\"{0}\"", _fieldValue);
                }
                else
                {
                    return _fieldValue;
                }
            }
        }

        /// <summary>
        /// Gets the name fo the field
        /// </summary>
        public string Name
        {
            get
            {
                return _fieldName;
            }
        }


        /// <summary>
        /// Get the value indicating if this field must be considered as number
        /// </summary>
        public bool IsNumber
        {
            get
            {
                return _isNumber;
            }
        }



    }
}
