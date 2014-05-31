///////////////////////////////////////
#region Namespace Directives

using System;
using System.Collections.Generic;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Forms.Specialized
{
    /// <summary>
    /// Template for implementing a MVVM form object within a WPF back-end that facilitates the display and 
    /// manipulation of scientific data within its fields.
    /// </summary>
    interface IScientificDataForm : IForm
    {
        // Method Signatures
        object GetFieldValueByID(string fieldId);
        List<object> GetFieldValuesByType(Type fieldType);
    }
}
