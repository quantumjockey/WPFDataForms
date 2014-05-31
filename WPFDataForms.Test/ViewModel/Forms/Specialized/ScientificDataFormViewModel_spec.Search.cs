///////////////////////////////////////
#region Namespace Directives

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WPFDataForms.ViewModel;
using WPFDataForms.ViewModel.Fields.Interchangeable;
using WPFDataForms.ViewModel.Forms;

#endregion
///////////////////////////////////////

namespace WPFDataForms.Test.ViewModel.Forms.Specialized
{
    /// <remarks>
    /// When separating large test classes into partials, you only need to specify the [Test Class] attribute 
    /// within one file. The compiler will yell at you if specify the attribute in all parts.
    /// </remarks>
    public partial class ScientificDataFormViewModel_spec
    {
        ////////////////////////////////////////
        #region Unit Tests (Search Methods)

        // object GetFieldValueByID(string fieldId);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFieldValueByID_Null_ExceptionThrown()
        {
            object dummy;
            ScientificDataFormViewModel form = new ScientificDataFormViewModel();
            form.AddField(new TestFormField());
            dummy = form.GetFieldValueByID(null);
        }

        [TestMethod]
        public void GetFieldValueByID_ValidID_ValueReturned()
        {
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            dummy.Value = 3.0;
            ScientificDataFormViewModel form = new ScientificDataFormViewModel();
            form.AddField(dummy);
            Assert.AreEqual(dummy.Value, form.GetFieldValueByID("Item1"));
        }

        [TestMethod]
        public void GetFieldValueByID_InvalidID_ZeroReturned()
        {
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            ScientificDataFormViewModel form = new ScientificDataFormViewModel();
            form.AddField(dummy);
            Assert.AreEqual(0.0, form.GetFieldValueByID("Item2"));
        }

        // List<object> GetFieldValuesByType(Type fieldType);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFieldValuesByType_Null_ExceptionThrown()
        {
            List<double> dummy;
            ScientificDataFormViewModel form = new ScientificDataFormViewModel();
            form.AddField(new TestFormField());
            dummy = form.GetFieldValuesByType(null);
        }

        [TestMethod]
        public void GetFieldValuesByType_ValidType_ListOfObjectsReturned()
        {
            List<double> dummy;
            ScientificDataFormViewModel form = new ScientificDataFormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            form.AddField(new ExtraTestFormField());
            dummy = form.GetFieldValuesByType(typeof(TestFormField));
            Assert.AreEqual(2, dummy.Count);
        }

        [TestMethod]
        public void GetFieldValuesByType_InvalidType_EmptyListReturned()
        {
            List<double> dummy;
            ScientificDataFormViewModel form = new ScientificDataFormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            dummy = form.GetFieldValuesByType(typeof(FormViewModel));
            Assert.AreEqual(0, dummy.Count);
        }

        #endregion

        ////////////////////////////////////////
        #region Child Classes (Used in Testing)

        class TestFormField : FFScientificDataVM
        {
            // empty constructor so class inherits values from base constructor
            public TestFormField() : base() { }

            public TestFormField(string id, string label, string toolTip) : base(false, id, label, toolTip) { }

        }

        class ExtraTestFormField : FFScientificDataVM
        {
            // empty constructor so class inherits values from base constructor
            public ExtraTestFormField() : base() { }
        }

        #endregion
    }
}
