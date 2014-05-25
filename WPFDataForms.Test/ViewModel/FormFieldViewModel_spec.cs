///////////////////////////////////////
#region Namespace Directives

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WPFDataForms.ViewModel;

#endregion
///////////////////////////////////////

namespace WPFDataForms.Test.ViewModel
{
    [TestClass]
    public class FormFieldViewModel_spec
    {
        ////////////////////////////////////////
        #region Unit Tests (Methods)

        // Constructor

        [TestMethod]
        public void Constructor_EmptyDefaults_ExpressionNotNull()
        {
            TestFormField field = new TestFormField();
            Assert.IsNotNull(field.Expression);
        }

        [TestMethod]
        public void Constructor_EmptyDefaults_IDIsNotEmptyString()
        {
            TestFormField field = new TestFormField();
            Assert.AreNotEqual(String.Empty, field.ID);
        }

        [TestMethod]
        public void Constructor_EmptyDefaults_IDIsNotNull()
        {
            TestFormField field = new TestFormField();
            Assert.IsNotNull(field.ID);
        }

        [TestMethod]
        public void Constructor_EmptyDefaults_LabelIsNotNull()
        {
            TestFormField field = new TestFormField();
            Assert.IsNotNull(field.Label);
        }

        [TestMethod]
        public void Constructor_EmptyDefaults_ToolTipIsNotNull()
        {
            TestFormField field = new TestFormField();
            Assert.IsNotNull(field.ToolTip);
        }

        [TestMethod]
        public void Constructor_IDIsEmptyString_IDIsNotEmptyString()
        {
            TestFormField field = new TestFormField(String.Empty, null, null);
            Assert.AreNotEqual(String.Empty, field.ID);
        }

        [TestMethod]
        public void Constructor_ToolTipIsEmptyString_ToolTipIsNotEmptyString()
        {
            TestFormField field = new TestFormField(String.Empty, null, String.Empty);
            Assert.AreNotEqual(String.Empty, field.ToolTip);
        }

        #endregion

        ////////////////////////////////////////
        #region Child Classes (Used in Testing)

        class TestFormField : FormFieldViewModel
        {
            // empty constructor so class inherits values from base constructor
            public TestFormField() : base() { }

            public TestFormField(string id, string label, string toolTip) : base(id, label, toolTip) { }

            public TestFormField(Predicate<object> expression, string id, string label, string toolTip) : base(expression, id, label, toolTip) { }

        }

        #endregion
    }
}
