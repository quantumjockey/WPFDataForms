///////////////////////////////////////
#region Namespace Directives

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WPFDataForms.ViewModel.Fields;
using WPFDataForms.ViewModel.Forms;

#endregion
///////////////////////////////////////

namespace WPFDataForms.Test.ViewModel.Forms
{
    /// <remarks>
    /// When separating large test classes into partials, you only need to specify the [Test Class] attribute 
    /// within one file. The compiler will yell at you if specify the attribute in all parts.
    /// </remarks>
    public partial class FormViewModel_spec
    {
        ////////////////////////////////////////
        #region Unit Tests (Search Methods)

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
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            dummy.Content = message;
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.AreEqual(message, form.GetFieldContentByID("Item1") as String);
        }

        [TestMethod]
        public void GetFieldContentByID_ValidID_ContentIsNotNull()
        {
            string message = "Hello!";
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            dummy.Content = message;
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.IsNotNull(form.GetFieldContentByID("Item1"));
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
        public void GetFieldObjectByID_ValidID_ContentIsNotNull()
        {
            TestFormField dummy = new TestFormField("Item1", "(label)", "(tooltip)");
            FormViewModel form = new FormViewModel();
            form.AddField(dummy);
            Assert.IsNotNull(form.GetFieldObjectByID("Item1"));
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

        #endregion
    }
}
