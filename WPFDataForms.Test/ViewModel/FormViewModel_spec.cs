///////////////////////////////////////
#region Namespace Directives

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WPFDataForms.ViewModel;

#endregion
///////////////////////////////////////

namespace WPFDataForms.Test.ViewModel
{
    /// <summary>
    /// Unit tests addressing functionality within the "WPFDataForms.ViewModel.FormViewModel" class.
    /// </summary>
    [TestClass]
    public partial class FormViewModel_spec
    {
        ////////////////////////////////////////
        #region Constructor (Auto-generated)

        public FormViewModel_spec()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        ////////////////////////////////////////
        #region TestContext Components (Auto-Generated)

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Unit Tests (Public Methods)

        // int AddField(IFormField field);

        [TestMethod]
        public void AddField_IFormFieldObject_FieldsCountNotZero()
        {
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            Assert.AreNotEqual(0, form.Fields.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddField_Null_ExceptionThrown()
        {
            FormViewModel form = new FormViewModel();
            form.AddField(null);
        }

        // bool CheckIfFieldExists(string fieldId);

        [TestMethod]
        public void CheckIfFieldExists_Null_ReturnFalse()
        {
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField("Field1", "Soccer", "The 'other' football."));
            Assert.IsFalse(form.CheckIfFieldExists(null));
        }

        [TestMethod]
        public void CheckIfFieldExists_InvalidID_ReturnFalse()
        {
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField("Field1", "Rugby", "Rough."));
            Assert.IsFalse(form.CheckIfFieldExists("Field2"));
        }

        [TestMethod]
        public void CheckIfFieldExists_ValidID_ReturnTrue()
        {
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField("Field1", "LaCrosse", "Actually quite fun."));
            Assert.IsTrue(form.CheckIfFieldExists("Field1"));
        }

        // bool ClearFields();

        [TestMethod]
        public void ClearFields_FieldsCleared_FieldsCountIsZero()
        {
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            form.ClearFields();
            Assert.AreEqual(0, form.Fields.Count);
        }

        [TestMethod]
        public void ClearFields_FieldsCountIsZero_ReturnTrue()
        {
            FormViewModel form = new FormViewModel();
            Assert.IsTrue(form.ClearFields());
        }

        // (Constructor)

        [TestMethod]
        public void Constructor_EmptyDefaults_FieldsCollectionIsNotNull()
        {
            FormViewModel form = new FormViewModel();
            Assert.IsNotNull(form.Fields);
        }

        // List<string> ListFieldIDs();

        [TestMethod]
        public void ListFieldIDs_FieldsListCountGreaterThanZero_ListReturnedHasSameCount()
        {
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            Assert.AreEqual(form.Fields.Count, form.ListFieldIDs().Count);
        }

        [TestMethod]
        public void ListFieldIDs_FieldsListCountIsZero_ListReturnedIsNotNull()
        {
            FormViewModel form = new FormViewModel();
            Assert.IsNotNull(form.ListFieldIDs());
        }

        [TestMethod]
        public void ListFieldIDs_FieldsListCountIsZero_ListReturnedCountIsZero()
        {
            FormViewModel form = new FormViewModel();
            Assert.AreEqual(0, form.ListFieldIDs().Count);
        }

        // bool RemoveField(IFormField field);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveFieldByObject_Null_ExceptionThrown()
        {
            FormViewModel form = new FormViewModel();
            form.RemoveField((IFormField)null);
        }

        // bool RemoveField(string fieldId);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveFieldByID_Null_ExceptionThrown()
        {
            FormViewModel form = new FormViewModel();
            form.RemoveFieldByID((string)null);
        }

        // bool RemoveFieldByIndex(int fieldIndex);

        [TestMethod]
        public void RemoveFieldByIndex_InvalidIndex_ReturnFalse()
        {
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());      
            Assert.IsFalse(form.RemoveFieldByIndex(-1));
        }

        // bool ResetFields();

        [TestMethod]
        public void ResetFields_FieldsCountIsZero_ReturnTrue()
        {
            FormViewModel form = new FormViewModel();
            Assert.IsTrue(form.ResetFields());
        }

        #endregion

        ////////////////////////////////////////
        #region Child Classes (Used in Testing)

        class TestFormField : FormFieldViewModel
        {
            // empty constructor so class inherits values from base constructor
            public TestFormField() : base() { }

            public TestFormField(string id, string label, string toolTip) : base(id, label, toolTip) { }
        }

        #endregion
    }
}
