///////////////////////////////////////
#region Namespace Directives

using System;
using System.ComponentModel;
using WpfHelper.ViewModel;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel
{
    public abstract class FormFieldViewModel : ViewModelBase, IFormField
    {
        ////////////////////////////////////////
        #region Constants

        const string _defaultToolTip = "Generic data field.";

        #endregion

        ////////////////////////////////////////
        #region Generic Fields

        private object _content;
        private bool _isValid;
        private string _label;
        private string _status;
        private string _toolTip;
        private object _value;

        #endregion

        ////////////////////////////////////////
        #region Properties

        public object Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = ExecuteEvaluation(value);
                OnPropertyChanged("Content");
            }
        }

        public Predicate<object> Expression
        {
            get;
            private set;
        }

        public string ID
        {
            get;
            private set;
        }

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

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

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

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Constructor(s)

        public FormFieldViewModel() : this(null, null, null) { }

        public FormFieldViewModel(string id, string label, string toolTip) : this(null, id, label, toolTip) { }

        public FormFieldViewModel(Predicate<object> expression, string id, string label, string toolTip)
        {
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
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private object ExecuteEvaluation(object input)
        {
            if (Expression(input))
            {
                IsValid = true;
            }
            else
            {
                IsValid = false;
            }
            return input;
        }

        #endregion
    }
}
