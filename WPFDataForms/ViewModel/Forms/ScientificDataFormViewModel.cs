///////////////////////////////////////
#region Namespace Directives

using System;
using System.Collections.ObjectModel;
using WPFDataForms.ViewModel.Fields.Interchangeable;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Forms
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
