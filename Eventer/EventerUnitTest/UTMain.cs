using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetEventer;


namespace EventerUnitTest
{
    [TestClass]
    public class UTMain
    {
        const string _applicationName = "UnitTestApp";
        const string _applicationNameField = "application";



        [TestMethod]
        public void FactoryCreationWithTransaction()
        {
            EventFactory _ef = new EventFactory(_applicationName, true);
            

            // Check if AppendCorrelationID is set to true
            if (_ef.AppendCorrelationID == false)
            {
                Assert.Fail("AppendCorrelationID = false, must be true!");
            }

            CheckForField(_ef, _applicationNameField);
            
            


        }

        [TestMethod]
        public void FactoryCreationWithNoTransaction()
        {
            EventFactory _ef = new EventFactory(_applicationName, false);


            // Check if AppendCorrelationID is set to true
            if (_ef.AppendCorrelationID == true)
            {
                Assert.Fail("AppendCorrelationID = true, must be false!");
            }

            CheckForField(_ef, _applicationNameField);

        }

        public void CheckForField(EventFactory EF, string FieldName)
        {
            bool _fieldFound = false;
             // Check if Application name field definition was created
            foreach (EventFieldDefinition _field in EF.Fields)
            {
                if (_field.Name == FieldName)
                {
                    _fieldFound = true;
                    break;
                }
            }

            if (_fieldFound == false)
            {
                Assert.Fail(string.Format("Field '{0}' doesn't not extist, must exist!", FieldName));
            }
        }
    }
}
