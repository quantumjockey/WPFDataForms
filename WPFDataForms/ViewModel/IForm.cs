///////////////////////////////////////
#region Namespace Directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel
{
    /// <summary>
    /// Template for implementing a MVVM form object within a WPF back-end.
    /// </summary>
    public interface IForm
    {
        // Property Signatures
        ObservableCollection<IFormField> Fields { get; set; }
        bool IsComplete { get; set; }

        // Method Signatures
        int AddField(IFormField field);
        bool CheckIfFieldExists(string fieldId);
        bool ClearFields();
        object GetFieldContentByID(string fieldId);
        List<object> GetFieldContentByType(Type fieldType);
        int GetFieldIndexByID(string fieldId);
        List<int> GetFieldIndicesByType(Type fieldType);
        IFormField GetFieldObjectByID(string fieldId);
        List<IFormField> GetFieldObjectsByType(Type fieldType);
        object GetFieldValueByID(string fieldId);
        List<object> GetFieldValuesByType(Type fieldType);
        List<string> ListFieldIDs();
        bool RemoveField(IFormField field);
        bool RemoveFieldByID(string fieldId);
        bool RemoveFieldByIndex(int fieldIndex);
        bool ResetFields();
    }
}
