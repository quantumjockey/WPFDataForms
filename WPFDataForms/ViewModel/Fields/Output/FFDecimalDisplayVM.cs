
namespace WPFDataForms.ViewModel.Fields.Output
{
    public class FFDecimalDisplayVM : FormFieldViewModel
    {
        ////////////////////////////////////////
        #region Properties

        public new double Content
        {
            get
            {
                return (double)base.Content;
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Constructors

        public FFDecimalDisplayVM(string _id, string _label, string _toolTip) : base(_id, _label, _toolTip) { }

        #endregion
    }
}
