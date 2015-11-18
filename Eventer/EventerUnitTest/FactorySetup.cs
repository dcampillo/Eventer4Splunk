using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetEventer;

namespace EventerUnitTest
{
    [TestClass]
    public class FactorySetup
    {
        const string _field1 = "Area";
        const string _field2 = "Message";
        const string _field3 = "Status";

        const bool _isNumberField1 = false;
        const bool _isNumberField2 = false;
        const bool _isNumberField3 = true;

        EventFactory _ef;

        [TestMethod]
        [TestInitialize]
        public void SetupFactory()
        {
            _ef = FactoryCreation.CreateEventFactory(true);

            // Add three field
            _ef.Fields.Add(new EventFieldDefinition(_field1, _isNumberField1));
            _ef.Fields.Add(new EventFieldDefinition(_field2, _isNumberField2));
            _ef.Fields.Add(new EventFieldDefinition(_field3, _isNumberField3));
        }

        [TestMethod]
        public void CheckFieldCreation()
        {
            // Check the number of field
            if (_ef.Fields.Count != 4)
            {
                Assert.Fail("Number of field must be 4 but is " + _ef.Fields.Count);
            }
        }

        [TestMethod]
        public void CheckFieldDefinitionConsistency()
        {
            if (_ef.Fields[1].Name != _field1 || _ef.Fields[1].IsNumber != _isNumberField1)
            {
                Assert.Fail(string.Format("Field '{0}' is inconsistent.", _field1));
            }

            if (_ef.Fields[2].Name != _field2 || _ef.Fields[2].IsNumber != _isNumberField2)
            {
                Assert.Fail(string.Format("Field '{0}' is inconsistent.", _field2));

            }

            if (_ef.Fields[3].Name != _field3 || _ef.Fields[3].IsNumber != _isNumberField3)
            {
                Assert.Fail(string.Format("Field '{0}' is inconsistent.", _field3));
            }
        }
    }
}
