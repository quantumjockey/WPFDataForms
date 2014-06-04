
namespace WPFDataForms.ViewModel.Fields.Output
{
    public class FFIntegerDisplayVM : FormFieldViewModel
    {
        ////////////////////////////////////////
        #region Properties

        public new int Content
        {
            get
            {
                return (int)base.Content;
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Constructors

        public FFIntegerDisplayVM(string _id, string _label, string _toolTip) : base(_id, _label, _toolTip) { }

        #endregion
    }
}
