///////////////////////////////////////
#region Namespace Directives

using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Fields.Input
{
    public class FFPasswordEntryVM : FormFieldViewModel
    {
        ////////////////////////////////////////
        #region Fields

        private PasswordBox _box;

        #endregion

        ////////////////////////////////////////
        #region Properties

        public PasswordBox Box
        {
            get
            {
                return _box;
            }
            set
            {
                _box = value;
                OnPropertyChanged("Box");
            }
        }

        public Action<object> KeyReturnAction
        {
            get;
            set;
        }

        #endregion

        ////////////////////////////////////////
        #region Constructors

        public FFPasswordEntryVM(string _id, string _label, string _tooltip)
            : base(_id, _label, _tooltip)
        {
            this.Expression = (x) => DefaultInputFilter(x);
            this.Box = InitializePasswordBox();
        }

        public FFPasswordEntryVM(string _id, Predicate<object> _expression, string _label, string _tooltip)
            : base(_expression, _id, _label, _tooltip)
        {
            this.Box = InitializePasswordBox();
        }

        public FFPasswordEntryVM(string _id, Action<object> _keyReturnAction, string _label, string _tooltip)
            : base(_id, _label, _tooltip)
        {
            this.Expression = (x) => DefaultInputFilter(x);
            this.KeyReturnAction = _keyReturnAction;
            this.Box = InitializePasswordBox();
            this.Box.KeyDown += Box_KeyDown;
        }

        public FFPasswordEntryVM(string _id, Predicate<object> _expression, Action<object> _keyReturnAction, string _label, string _tooltip)
            : base(_expression, _id, _label, _tooltip)
        {
            this.KeyReturnAction = _keyReturnAction;
            this.Box = InitializePasswordBox();
            this.Box.KeyDown += Box_KeyDown;
        }

        #endregion

        ////////////////////////////////////////
        #region Public Methods

        public override void Reset()
        {
            Box.Password = String.Empty;
        }

        #endregion

        ////////////////////////////////////////
        #region Events

        void Box_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Return:
                    KeyReturnAction.Invoke(KeyReturnAction);
                    break;

                default:
                    break;
            }
        }

        void passwordEntry_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            PasswordBox input = sender as PasswordBox;
            if (Expression(input.Password))
            {
                SHA512 hashObject = SHA512Managed.Create();
                byte[] dataVehicle = hashObject.ComputeHash(Encoding.ASCII.GetBytes(input.Password));
                Content = BitConverter.ToString(dataVehicle);
                IsValid = true;
            }
            else
            {
                Content = String.Empty;
                IsValid = false;
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Supporting Methods

        private PasswordBox InitializePasswordBox()
        {
            PasswordBox passwordEntry = new PasswordBox();
            passwordEntry.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            passwordEntry.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            passwordEntry.Width = 150;
            passwordEntry.PasswordChanged += passwordEntry_PasswordChanged;
            return passwordEntry;
        }

        #endregion

        ////////////////////////////////////////
        #region Filters

        private bool DefaultInputFilter(object x)
        {
            return (x.ToString().Trim().Length >= 8 && x.ToString().Length <= 16);
        }

        #endregion
    }
}
