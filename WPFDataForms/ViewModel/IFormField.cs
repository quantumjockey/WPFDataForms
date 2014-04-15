///////////////////////////////////////
#region Namespace Directives

using System;
using System.ComponentModel;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel
{
    /// <summary>
    /// Template for implementing a MVVM form field object base within a WPF back-end.
    /// </summary>
    public interface IFormField
    {
        // Property Signatures
        object Content { get; set; }
        Predicate<object> Expression { get; }
        string ID { get; }
        bool IsValid { get; set; }
        string Label { get; set; }
        string Status { get; set; }
        string ToolTip { get; set; }
        object Value { get; set; }

        // Method Signatures
        void Reset();

        // Event Signatures
        event PropertyChangedEventHandler PropertyChanged;
    }
}
