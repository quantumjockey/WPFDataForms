﻿///////////////////////////////////////
#region Namespace Directives

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WPFDataForms.ViewModel;
using WPFDataForms.ViewModel.Fields.Interchangeable;
using WPFDataForms.ViewModel.Forms;

#endregion
///////////////////////////////////////

namespace WPFDataForms.Test.ViewModel.Interchangeable
{
    /// <summary>
    /// Unit tests addressing functionality within the "WPFDataForms.ViewModel.Fields.Interchangeable.FormFieldScientificDataViewModel" class.
    /// </summary>
    [TestClass]
    public class FormFieldScientificDataViewModelTest
    {
        ////////////////////////////////////////
        #region Constructor (Auto-generated)

        public FormFieldScientificDataViewModelTest()
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
        #region Unit Tests (Methods)

        // Constructor

        [TestMethod]
        public void Constructor_EmptyDefaults_ScaleFactorIsOne()
        {
            TestFormField field = new TestFormField(); 
            field.Content = 10.0;
            Assert.AreEqual(10.0, field.Value);
        }

        // Content Member

        [TestMethod]
        public void ContentMember_NumericInputDataChanged_ValueIsContentDividedByScaleFactor()
        {
            TestFormField field = new TestFormField(10.0, false, (x) => ((double)x != 0.0), "Item", "Item:", "I have a headache, and with a head this big that's no joke!");
            field.Content = 10.0;
            Assert.AreEqual(1.0, field.Value);
        }

        // Value Member

        [TestMethod]
        public void ValueMember_NumericInputDataChanged_ContentIsValueTimesScaleFactor()
        {
            TestFormField field = new TestFormField(10.0, true, (x) => ((double)x != 0.0), "Item", "Item:", "Gordon, it's been twenty years...");
            field.Value = 10.0;
            Assert.AreEqual(100.0, field.Content);
        }

        // void Reset();

        [TestMethod]
        public void Reset_IsDisplayField_ClearsContentViaValue()
        {
            TestFormField field = new TestFormField(10.0, true, (x) => ((double)x != 0.0), "Item", "Item:", "All life provides clues for those who can read them.");
            field.Reset();
            Assert.AreEqual(0.0, field.Content);
        }

        [TestMethod]
        public void Reset_IsNotDisplayField_ClearsValueViaContent()
        {
            TestFormField field = new TestFormField(10.0, false, (x) => ((double)x != 0.0), "Item", "Item:", "Get out of there Isaac!");
            field.Reset();
            Assert.AreEqual(0.0, field.Value);
        }

        #endregion

        ////////////////////////////////////////
        #region Child Classes (Used in Testing)

        class TestFormField : FormFieldScientificDataViewModel
        {
            // empty constructor so class inherits values from base constructor
            public TestFormField() : base() { }

            public TestFormField(bool isDisplayField, string id, string label, string toolTip) : base(isDisplayField, id, label, toolTip) { }

            public TestFormField(double scaleFactor, bool isDisplayField, Predicate<object> expression, string id, string label, string toolTip) : base(scaleFactor, isDisplayField, expression, id, label, toolTip) { }

        }

        #endregion
    }
}