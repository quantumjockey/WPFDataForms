///////////////////////////////////////
#region Namespace Directives

using System;
using System.Security;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Fields.Output
{
    public class FFPasswordDisplayVM : FormFieldViewModel
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

        public FFPasswordDisplayVM(string _id, string _label, SecureString _content, string _toolTip)
            : base(_id, _label, _toolTip)
        {
            string temp = String.Empty;

            for (int i = 0; i < _content.Length; i++)
                temp += (char)250;

            base.Content = temp;
        }

        #endregion
    }
}
