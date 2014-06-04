///////////////////////////////////////
#region Namespace Directives

using System;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Fields.Input
{
    public class FFTextEntryVM : FormFieldViewModel
    {
        ////////////////////////////////////////
        #region Properties

        public new string Content
        {
            get
            {
                if (base.Content != null)
                    return base.Content.ToString();
                else
                    return String.Empty;
            }
            set
            {
                base.Content = value;
                OnPropertyChanged("Content");
            }
        }

        public int FieldWidth
        {
            get;
            set;
        }

        #endregion

        ////////////////////////////////////////
        #region Constructors

        public FFTextEntryVM(string _id, string _label, string _tooltip)
            : base(_id, _label, _tooltip)
        {
            this.Expression = (x) => DefaultInputFilter(x);
            this.FieldWidth = 250;
        }

        public FFTextEntryVM(string _id, Predicate<object> _expression, string _label, string _tooltip)
            : base(_expression, _id, _label, _tooltip)
        {
            this.FieldWidth = 250;
        }

        public FFTextEntryVM(string _id, int _fieldWidth, string _label, string _tooltip)
            : base(_id, _label, _tooltip)
        {
            this.Expression = (x) => DefaultInputFilter(x);
            this.FieldWidth = _fieldWidth;
        }

        public FFTextEntryVM(string _id, int _fieldWidth, Predicate<object> _expression, string _label, string _tooltip)
            : base(_expression, _id, _label, _tooltip)
        {
            this.FieldWidth = _fieldWidth;
        }

        #endregion

        ////////////////////////////////////////
        #region Public Methods

        public override void Reset()
        {
            Content = String.Empty;
        }

        #endregion

        ////////////////////////////////////////
        #region Filters

        private bool DefaultInputFilter(object x)
        {
            return x != null && x.ToString() != String.Empty;
        }

        #endregion
    }
}
