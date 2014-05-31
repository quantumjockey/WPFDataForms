///////////////////////////////////////
#region Namespace Directives

using System;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Fields.Specialized
{
    /// <summary>
    /// Creates a form field object that can be used to store, validate, manipulate, and display scientific data.
    /// </summary>
    /// <remarks>
    /// The purpose of the content/value conversion functionality is to perform internal standardization of scientific and/or 
    /// mathematical results, but allow those standardized results to be displayed according to custom unit systems, whether 
    /// applied application-wide or to each field individually. i.e. In an application where metric and english unit systems 
    /// are required by the user, such as in a mechanical simulation, calculations can be done internally using Systeme 
    /// International (metric) units and converted to English units by changing the value of the _scaleFactor field.
    /// </remarks>
    public class FFScientificDataVM : FormFieldViewModel, IScientificDataFormField
    {
        ////////////////////////////////////////
        #region Generic Fields

        // data handling/formatting
        private bool _isDisplayField;

        // data scaling (for use with unit systems)
        private double _scaleFactor;

        // associated with IFormField members
        private double _content;
        private double _value;

        #endregion

        ////////////////////////////////////////
        #region Properties

        /// <summary>
        /// Data displayed within the interface. Can hold input or output data depending on the form field type.
        /// </summary>
        public new double Content
        {
            get
            {
                // if for data display, return the converted value
                return (_isDisplayField) ? (_value * _scaleFactor) : _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        /// <summary>
        /// Indicates whether or not this field acts as an input or output field.
        /// </summary>
        /// <remarks>
        /// Exposed as a property so certain parts of the view markup can be enabled/disabled while keeping 
        /// the overall markup format the same for each field when this is bound to the view.
        /// </remarks>
        public bool IsDisplayField
        {
            get
            {
                return _isDisplayField;
            }
        }

        /// <summary>
        /// Supplement to Content member. Aid for performing numeric data input.
        /// </summary>
        /// <remarks>
        /// Intended for use where the field contains scientific data and/or is used to perform mathematical operations.
        /// </remarks>
        public double Value
        {
            get
            {
                // if for data input, return the converted value
                return (_isDisplayField) ? _value : (_content / _scaleFactor);
            }
            set
            {
                _value = value;
                EvaluateInput(_value);
                OnPropertyChanged("Value");
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Constructor(s)


        /// <summary>
        /// A blank form field object with default initializers.
        /// </summary>
        public FFScientificDataVM() : this(false, null, null, null) { }

        /// <summary>
        /// A blank form field object.
        /// </summary>
        public FFScientificDataVM(bool isDisplayField, string id, string label, string toolTip) : this(1.0, isDisplayField, null, id, label, toolTip) { }

        /// <summary>
        /// A form field object with all initializers.
        /// </summary>
        /// <param name="scaleFactor">Contains the scale factor for use with scientific data; allows for a standardized infrastructure that induces </param>
        /// <param name="isDisplayField"></param>
        /// <param name="expression"></param>
        /// <param name="id"></param>
        /// <param name="label"></param>
        /// <param name="toolTip"></param>
        public FFScientificDataVM(double scaleFactor, bool isDisplayField, Predicate<object> expression, string id, string label, string toolTip)
        {
            // initialize field state
            _isDisplayField = isDisplayField;

            // initialize data scale
            _scaleFactor = scaleFactor;
        }

        #endregion

        ////////////////////////////////////////
        #region Public Methods

        /// <summary>
        /// Clears the value within this field.
        /// </summary>
        public override void Reset()
        {
            if (IsDisplayField)
                Value = 0.0;
            else
                Content = 0.0;
        }

        #endregion
    }
}
