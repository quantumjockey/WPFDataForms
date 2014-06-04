///////////////////////////////////////
#region Namespace Directives

using System;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Fields.Output
{
    public class FFDateDisplayVM : FormFieldViewModel
    {
        ////////////////////////////////////////
        #region Properties

        public new string Content
        {
            get
            {
                return ((DateTime)base.Content).Month.ToString() + "/" + ((DateTime)base.Content).Day.ToString() + "/" + ((DateTime)base.Content).Year.ToString();
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Constructors

        public FFDateDisplayVM(string _id, string _label, string _toolTip) : base(_id, _label, _toolTip) { }

        #endregion
    }
}
