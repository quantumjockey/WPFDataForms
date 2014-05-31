///////////////////////////////////////
#region Namespace Directives

// none

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Fields.Specialized

{
    /// <summary>
    /// Template for implementing a MVVM form field object within a WPF back-end that facilitates the display and 
    /// manipulation of scientific data.
    /// </summary>
    public interface IScientificDataFormField : IFormField
    {
        // Property Signatures
        new double Content { get; set; }
        bool IsDisplayField { get; }
        double Value { get; set; }
    }
}
