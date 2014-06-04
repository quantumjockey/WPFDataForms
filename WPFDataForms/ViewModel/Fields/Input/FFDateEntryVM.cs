///////////////////////////////////////
#region Namespace Directives

using System;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Fields.Input
{
    public class FFDateEntryVM : FormFieldViewModel
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

        public FFDateEntryVM(string _id, string _label, string _tooltip)
            : base(_id, _label, _tooltip)
        {
            this.Expression = (x) => DefaultInputFilter(x);
            this.FieldWidth = 250;
            InitializeDate();
        }

        public FFDateEntryVM(string _id, Predicate<object> _expression, string _label, string _tooltip)
            : base(_expression, _id, _label, _tooltip)
        {
            this.FieldWidth = 250;
            InitializeDate();
        }

        public FFDateEntryVM(string _id, int _fieldWidth, string _label, string _tooltip)
            : base(_id, _label, _tooltip)
        {
            this.Expression = (x) => DefaultInputFilter(x);
            this.FieldWidth = _fieldWidth;
            InitializeDate();
        }

        public FFDateEntryVM(string _id, int _fieldWidth, Predicate<object> _expression, string _label, string _tooltip)
            : base(_expression, _id, _label, _tooltip)
        {
            this.FieldWidth = _fieldWidth;
            InitializeDate();
        }

        #endregion

        ////////////////////////////////////////
        #region Public Methods

        public override void Reset()
        {
            int daysDifference, monthsDifference, yearsDifference;

            if (DateTime.Today.Day == 1)
            {
                daysDifference = DateTime.Today.Day - ((DateTime)Content).Day;
                monthsDifference = (DateTime.Today.Month - 1) - ((DateTime)Content).Month;
                yearsDifference = DateTime.Today.Year - ((DateTime)Content).Year;
            }
            else
            {
                daysDifference = (DateTime.Today.Day - 1) - ((DateTime)Content).Day;
                monthsDifference = DateTime.Today.Month - ((DateTime)Content).Month;
                yearsDifference = DateTime.Today.Year - ((DateTime)Content).Year;
            }

            Content = ((DateTime)Content).AddDays(daysDifference).AddMonths(monthsDifference).AddYears(yearsDifference);
        }

        #endregion

        ////////////////////////////////////////
        #region Supporting Methods

        private void InitializeDate()
        {
            if (DateTime.Today.Day == 1)
                Content = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, DateTime.Today.Day);
            else
                Content = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day - 1);
        }

        #endregion

        ////////////////////////////////////////
        #region Filters

        private bool DefaultInputFilter(object x)
        {
            return (DateTime)x >= DateTime.Today;
        }

        #endregion
    }
}
