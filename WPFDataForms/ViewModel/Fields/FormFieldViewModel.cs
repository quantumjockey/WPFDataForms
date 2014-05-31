///////////////////////////////////////
#region Namespace Directives

using System;
using WpfHelper.ViewModel;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Fields
{
    /// <summary>
    /// Creates a base form field class that can be used to store, display, and validate user input data.
    /// </summary>
    public abstract class FormFieldViewModel : ViewModelBase, IFormField
    {
        ////////////////////////////////////////
        #region Constants

        const string _defaultToolTip = "Generic data field.";

        #endregion

        ////////////////////////////////////////
        #region Generic Fields

        // associated with IFormField members
        private object _content;
        private bool _isValid;
        private string _label;
        private string _toolTip;

        #endregion

        ////////////////////////////////////////
        #region Properties

        /// <summary>
        /// Data displayed within the interface. Can hold input or output data depending on the form field type.
        /// </summary>
        public object Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                EvaluateInput(_content);
                OnPropertyChanged("Content");
            }
        }

        /// <summary>
        /// An expression that must be true for changes to be made within the form field.
        /// </summary>
        public Predicate<object> Expression
        {
            get;
            private set;
        }

        /// <summary>
        /// The internal ID (not displayed to the user) associated with this form field.
        /// </summary>
        public string ID
        {
            get;
            private set;
        }

        /// <summary>
        /// Indicates whether or not the form field expression evaluated to true.
        /// </summary>
        /// <remarks>
        /// This member is fully-implemented as read-write (rather than just read-only) so that updates to the state
        /// of the interface can be performed when this member is bound to interface components.
        /// </remarks>
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                OnPropertyChanged("IsValid");
            }
        }

        /// <summary>
        /// Tag that can be used to access this form field within a form or workspace.
        /// </summary>
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                OnPropertyChanged("Label");
            }
        }

        /// <summary>
        /// Instructions/tips displayed to the user when the form field is active.
        /// </summary>
        public string ToolTip
        {
            get
            {
                return _toolTip;
            }
            set
            {
                _toolTip = value;
                OnPropertyChanged("ToolTip");
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Constructor(s)

        /// <summary>
        /// A blank form field object with default initializers.
        /// </summary>
        public FormFieldViewModel() : this(null, null, null) { }

        /// <summary>
        /// A blank form field object.
        /// </summary>
        public FormFieldViewModel(string id, string label, string toolTip) : this(null, id, label, toolTip) { }

        /// <summary>
        /// A form field object with all initializers.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="id"></param>
        /// <param name="label"></param>
        /// <param name="toolTip"></param>
        public FormFieldViewModel(Predicate<object> expression, string id, string label, string toolTip)
        {
            // populate members
            this.Expression = ((expression == null) ? (x) => x != null : expression);
            this.ID = ((id == null || id == String.Empty) ? Guid.NewGuid().ToString() : id);
            this.Label = ((label == null) ? String.Empty : label);
            this.ToolTip = ((toolTip == null || toolTip == String.Empty) ? _defaultToolTip : toolTip);
        }

        #endregion

        ////////////////////////////////////////
        #region Public Methods

        /// <summary>
        /// Clears the content of this field.
        /// </summary>
        public virtual void Reset()
        {
            // Override in a derived class.
        }

        #endregion

        ////////////////////////////////////////
        #region Private Methods

        /// <summary>
        /// Evaluates the validity of input based on the expression associated with this data field.
        /// </summary>
        /// <param name="input"></param>
        protected void EvaluateInput(object input)
        {
            IsValid = Expression(input) ? true : false;
        }

        #endregion
    }
}
