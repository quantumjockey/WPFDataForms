///////////////////////////////////////
#region Namespace Directives

// none

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Forms.Specialized
{
    public partial class ScientificDataFormViewModel : FormViewModel
    {
        ////////////////////////////////////////
        #region Generic Fields

        private string _title;

        #endregion

        ////////////////////////////////////////
        #region Properties

        /// <summary>
        /// Describes the data being presented/displayed within this form.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        #endregion
    }
}
