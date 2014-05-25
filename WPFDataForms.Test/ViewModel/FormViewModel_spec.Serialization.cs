///////////////////////////////////////
#region Namespace Directives

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WPFDataForms.ViewModel;

#endregion
///////////////////////////////////////

namespace WPFDataForms.Test.ViewModel
{
    /// <summary>
    /// Unit tests addressing functionality within the "WPFDataForms.ViewModel.FormViewModel" class.
    /// </summary>
    /// <remarks>
    /// When separating large test classes into partials, you only need to specify the [Test Class] attribute 
    /// within one file. The compiler will yell at you if specify the attribute in all parts.
    /// </remarks>
    public partial class FormViewModel_spec
    {
        ////////////////////////////////////////
        #region Unit Tests (Object-to-Form Serialization)

        // bool DeserializeObjectToForm(object dummy);

        [TestMethod]
        public void DeserializeObjectToForm_Null_ReturnFalse()
        {
            frindle dummy = new frindle();
            dummy.Name = "Waldo";
            dummy.Whut = "Navy SEAL";

            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField("Name", "Name:", "Enter a name."));
            form.AddField(new TestFormField("Whut", "Whut?:", "Enter schtuff."));

            Assert.IsFalse(form.DeserializeObjectToForm(null));
        }

        [TestMethod]
        public void DeserializeObjectToForm_EmptyObject_EmptyForm()
        {
            frindle dummy = new frindle();

            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField("Name", "Name:", "Enter a name."));
            form.AddField(new TestFormField("Whut", "Whut?:", "Enter schtuff."));

            form.DeserializeObjectToForm(dummy);

            Assert.AreEqual(dummy.Name, form.Fields[0].Content);
        }

        [TestMethod]
        public void DeserializeObjectToForm_PartialObject_PartiallyPopulatedForm()
        {
            frindle dummy = new frindle();
            dummy.Name = "Waldo";

            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField("Name", "Name:", "Enter a name."));
            form.AddField(new TestFormField("Whut", "Whut?:", "Enter schtuff."));

            form.DeserializeObjectToForm(dummy);

            Assert.AreEqual(dummy.Name, (string)form.Fields[0].Content);
        }

        [TestMethod]
        public void DeserializeObjectToForm_FullObject_CompletedForm()
        {
            frindle dummy = new frindle();
            dummy.Name = "Waldo";
            dummy.Whut = "Navy SEAL";

            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField("Name", "Name:", "Enter a name."));
            form.AddField(new TestFormField("Whut", "Whut?:", "Enter schtuff."));

            form.DeserializeObjectToForm(dummy);

            Assert.IsTrue((dummy.Name == (string)form.Fields[0].Content) && (dummy.Whut == (string)form.Fields[1].Content));
        }

        // object SerializeObjectFromForm(Type objectType);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SerializeObjectFromForm_Null_ExceptionThrown()
        {
            frindle dummy;

            FormViewModel form = new FormViewModel();
            form.AddField(new TestFormField("Name", "Name:", "Enter a name."));
            form.AddField(new TestFormField("Whut", "Whut?:", "Enter schtuff."));

            dummy = form.SerializeObjectFromForm(null) as frindle;
        }

        [TestMethod]
        public void SerializeObjectFromForm_EmptyForm_EmptyObject()
        {
            frindle dummy = new frindle();
            frindle dumber = new frindle();

            FormViewModel form = new FormViewModel();
            dumber = form.SerializeObjectFromForm(typeof(frindle)) as frindle;

            Assert.IsNull(dumber.Name);
        }

        [TestMethod]
        public void SerializeObjectFromForm_PartialForm_PartialObject()
        {
            frindle dummy = new frindle();

            TestFormField field = new TestFormField("Name", "Name:", "Enter a name.");
            FormViewModel form = new FormViewModel();

            field.Content = dummy.Name = "Waldo";
            form.AddField(field);

            Assert.AreEqual(dummy.Name, (form.SerializeObjectFromForm(typeof(frindle)) as frindle).Name);
        }

        [TestMethod]
        public void SerializeObjectFromForm_CompletedForm_FullyInitializedObject()
        {
            frindle dummy = new frindle();
            frindle dumber = new frindle();

            TestFormField fieldOne = new TestFormField("Name", "Name:", "Enter a name.");
            TestFormField fieldTwo = new TestFormField("Whut", "Whut?:", "Enter schtuff.");
            FormViewModel form = new FormViewModel();

            fieldOne.Content = dummy.Name = "Waldo";
            fieldTwo.Content = dummy.Whut = "Navy SEAL";

            form.AddField(fieldOne);
            form.AddField(fieldTwo);

            dumber = form.SerializeObjectFromForm(typeof(frindle)) as frindle;

            Assert.AreEqual(dummy.Name, dumber.Name);
            Assert.AreEqual(dummy.Whut, dumber.Whut);
        }

        #endregion

        ////////////////////////////////////////
        #region Child Classes (Used in Testing)

        class frindle
        {
            public string Name { get; set; }
            public string Whut { get; set; }
        }

        #endregion
    }
}
