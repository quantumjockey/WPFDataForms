///////////////////////////////////////
#region Namespace Directives

// none

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Fields.Output
{
    public class FFTextDisplayVM : FormFieldViewModel
    {
        ////////////////////////////////////////
        #region Properties

        public new string Content
        {
            get
            {
                return base.Content.ToString();
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Constructors

        public FFTextDisplayVM(string _id, string _label, string _toolTip) : base(_id, _label, _toolTip) { }

        #endregion
    }
}
