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
    public class FormViewModelTest
    {
        ////////////////////////////////////////
        #region Constructor (Auto-generated)

        public FormViewModelTest()
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
            form.AddField(new TestFormField("Field1", "Ackbar", "It's A Trap!"));
            Assert.IsFalse(form.CheckIfFieldExists(null));
        }

        [TestMethod]
        public void CheckIfFieldExists_InvalidID_ReturnFalse()
        {
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField("Field1", "Ackbar", "It's A Trap!"));
            Assert.IsFalse(form.CheckIfFieldExists("Field2"));
        }

        [TestMethod]
        public void CheckIfFieldExists_ValidID_ReturnTrue()
        {
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField("Field1", "Ackbar", "It's A Trap!"));
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

        // object GetFieldContentByID(string fieldId);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFieldContentByID_Null_ExceptionThrown()
        {
            object dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            dummy = form.GetFieldContentByID(null);
        }

        [TestMethod]
        public void GetFieldContentByID_ValidID_ContentReturned()
        {
            string message = "Hello!";
            TestFormField dummy =new TestFormField("Item1", "(label)", "(tooltip)");
            dummy.Content = message;
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.AreEqual(message, form.GetFieldContentByID("Item1") as String);
        }

        [TestMethod]
        public void GetFieldContentByID_InvalidID_NullReturned()
        {
            string message = "Hello!";
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            dummy.Content = message;
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.IsNull(form.GetFieldContentByID("Item2"));
        }

        // List<object> GetFieldContentByType(Type fieldType);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFieldContentByType_Null_ExceptionThrown()
        {
            List<object> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            dummy = form.GetFieldContentByType(null);
        }

        [TestMethod]
        public void GetFieldContentByType_ValidType_ListOfObjectsReturned()
        {
            List<object> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            dummy = form.GetFieldContentByType(typeof(TestFormField));
            Assert.AreEqual(2, dummy.Count);
        }

        [TestMethod]
        public void GetFieldContentByType_InvalidType_EmptyListReturned()
        {
            List<object> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            dummy = form.GetFieldContentByType(typeof(FormViewModel));
            Assert.AreEqual(0, dummy.Count);
        }

        // int GetFieldIndexByID(string fieldId);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFieldIndexByID_Null_ExceptionThrown()
        {
            object dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            dummy = form.GetFieldIndexByID(null);
        }

        [TestMethod]
        public void GetFieldIndexByID_ValidID_IndexReturned()
        {
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.AreEqual(0, form.GetFieldIndexByID("Item1"));
        }

        [TestMethod]
        public void GetFieldIndexByID_InvalidID_NegativeOneReturned()
        {
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.AreEqual(-1, form.GetFieldIndexByID("Item2"));
        }

        // List<int> GetFieldIndicesByType(Type fieldType);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFieldIndicesByType_Null_ExceptionThrown()
        {
            List<int> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            dummy = form.GetFieldIndicesByType(null);
        }

        [TestMethod]
        public void GetFieldIndicesByType_ValidType_ListOfObjectsReturned()
        {
            List<int> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            dummy = form.GetFieldIndicesByType(typeof(TestFormField));
            Assert.AreEqual(2, dummy.Count);
        }

        [TestMethod]
        public void GetFieldIndicesByType_InvalidType_EmptyListReturned()
        {
            List<int> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            dummy = form.GetFieldIndicesByType(typeof(FormViewModel));
            Assert.AreEqual(0, dummy.Count);
        }

        // IFormField GetFieldObjectByID(string fieldId);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFieldObjectByID_Null_ExceptionThrown()
        {
            object dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            dummy = form.GetFieldObjectByID(null);
        }

        [TestMethod]
        public void GetFieldObjectByID_ValidID_ObjectReturned()
        {
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.AreEqual(dummy, form.GetFieldObjectByID("Item1"));
        }

        [TestMethod]
        public void GetFieldObjectByID_InvalidID_NullReturned()
        {
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.IsNull(form.GetFieldObjectByID("Item2"));
        }

        // List<IFormField> GetFieldObjectsByType(Type fieldType);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFieldObjectsByType_Null_ExceptionThrown()
        {
            List<IFormField> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            dummy = form.GetFieldObjectsByType(null);
        }

        [TestMethod]
        public void GetFieldObjectsByType_ValidType_ListOfObjectsReturned()
        {
            List<IFormField> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            dummy = form.GetFieldObjectsByType(typeof(TestFormField));
            Assert.AreEqual(2, dummy.Count);
        }

        [TestMethod]
        public void GetFieldObjectsByType_InvalidType_EmptyListReturned()
        {
            List<IFormField> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            dummy = form.GetFieldObjectsByType(typeof(FormViewModel));
            Assert.AreEqual(0, dummy.Count);
        }

        // object GetFieldValueByID(string fieldId);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFieldValueByID_Null_ExceptionThrown()
        {
            object dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            dummy = form.GetFieldValueByID(null);
        }

        [TestMethod]
        public void GetFieldValueByID_ValidID_ValueReturned()
        {
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            dummy.Value = 3;
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.AreEqual(dummy.Value, (int)form.GetFieldValueByID("Item1"));
        }

        [TestMethod]
        public void GetFieldValueByID_InvalidID_NullReturned()
        {
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.IsNull(form.GetFieldValueByID("Item2"));
        }

        // List<object> GetFieldValuesByType(Type fieldType);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFieldValuesByType_Null_ExceptionThrown()
        {
            List<object> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            dummy = form.GetFieldValuesByType(null);
        }

        [TestMethod]
        public void GetFieldValuesByType_ValidType_ListOfObjectsReturned()
        {
            List<object> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            dummy = form.GetFieldValuesByType(typeof(TestFormField));
            Assert.AreEqual(2, dummy.Count);
        }

        [TestMethod]
        public void GetFieldValuesByType_InvalidType_EmptyListReturned()
        {
            List<object> dummy;
            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField());
            form.AddField(new TestFormField());
            dummy = form.GetFieldValuesByType(typeof(FormViewModel));
            Assert.AreEqual(0, dummy.Count);
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

        class frindle
        {
            public string Name { get; set; }
            public string Whut { get; set; }
        }

        class TestFormField : FormFieldViewModel
        {
            // empty constructor so class inherits values from base constructor
            public TestFormField() : base() { }

            public TestFormField(string id, string label, string toolTip) : base(id, label, toolTip) { }
        }

        #endregion
    }
}
