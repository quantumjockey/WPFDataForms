﻿///////////////////////////////////////
#region Namespace Directives

using System;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Fields.Input
{
    public class FFDecimalEntryVM : FormFieldViewModel
    {
        ////////////////////////////////////////
        #region Properties

        public int FieldWidth
        {
            get;
            set;
        }

        #endregion

        ////////////////////////////////////////
        #region Constructors

        public FFDecimalEntryVM(string _id, string _label, string _tooltip)
            : base(_id, _label, _tooltip)
        {
            this.Expression = (x) => DefaultInputFilter(x);
            this.FieldWidth = 250;
        }

        public FFDecimalEntryVM(string _id, Predicate<object> _expression, string _label, string _tooltip)
            : base(_expression, _id, _label, _tooltip)
        {
            this.FieldWidth = 250;
        }

        public FFDecimalEntryVM(string _id, int _fieldWidth, string _label, string _tooltip)
            : base(_id, _label, _tooltip)
        {
            this.Expression = (x) => DefaultInputFilter(x);
            this.FieldWidth = _fieldWidth;
        }

        public FFDecimalEntryVM(string _id, int _fieldWidth, Predicate<object> _expression, string _label, string _tooltip)
            : base(_expression, _id, _label, _tooltip)
        {
            this.FieldWidth = _fieldWidth;
        }

        #endregion

        ////////////////////////////////////////
        #region Public Methods

        public override void Reset()
        {
            Content = 0.0;
        }

        #endregion

        ////////////////////////////////////////
        #region Filters

        private bool DefaultInputFilter(object x)
        {
            double result; 
            if (Double.TryParse(x.ToString(), out result) && result > 0.0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
