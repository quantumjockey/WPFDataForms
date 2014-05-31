///////////////////////////////////////
#region Namespace Directives

using System;
using System.Collections.Generic;
using WPFDataForms.ViewModel.Fields;
using WPFDataForms.ViewModel.Fields.Specialized;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Forms.Specialized
{
    public partial class ScientificDataFormViewModel : FormViewModel
    {
        ////////////////////////////////////////
        #region Form Search

        /// <summary>
        /// Retrieves the value of the form field specified by ID within the Fields collection.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns>The Value property of the form field object specified.</returns>
        public double GetFieldValueByID(string fieldId)
        {
            double value = 0.0;

            if (fieldId == null)
                throw new ArgumentException("Null fieldID argument passed.");

            foreach (IFormField field in Fields)
            {
                if (field.ID == fieldId)
                {
                    value = (field as IScientificDataFormField).Value;
                    break;
                }
            }

            return value;
        }

        /// <summary>
        /// Retrieves the value(s) of the form field(s) specified by Type within the Fields collection.
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns>A list containing the Value properties of objects matching the specified Type within the Fields collection.</returns>
        public List<double> GetFieldValuesByType(Type fieldType)
        {
            List<double> values = new List<double>();

            if (fieldType == null)
                throw new ArgumentException("Null type argument passed.");

            foreach (IFormField field in Fields)
            {
                if (field.GetType() == fieldType)
                    values.Add((field as IScientificDataFormField).Value);
            }

            return values;
        }

        #endregion
    }
}
