///////////////////////////////////////
#region Namespace Directives

using System;
using System.Collections.Generic;
using WpfHelper.ViewModel;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel
{
    public partial class FormViewModel : ViewModelBase, IForm
    {
        ////////////////////////////////////////
        #region Form Search

        /// <summary>
        /// Retrieves the content of the form field specified by ID.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns>The Content of the form field object specified by ID.</returns>
        public object GetFieldContentByID(string fieldId)
        {
            object content = null;

            if (fieldId == null)
                throw new ArgumentException("Null fieldID argument passed.");

            foreach (IFormField field in Fields)
            {
                if (field.ID == fieldId)
                {
                    content = field.Content;
                    break;
                }
                break;
            }

            return content;
        }

        /// <summary>
        /// Retrieves the content(s) of the form field(s) specified by Type.
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns>A list containing the contents of objects matching the specified Type within the Fields collection.</returns>
        public List<object> GetFieldContentByType(Type fieldType)
        {
            List<object> content = new List<object>();

            if (fieldType == null)
                throw new ArgumentException("Null type argument passed.");

            foreach (IFormField field in Fields)
            {
                if (field.GetType() == fieldType)
                    content.Add(field.Content);
            }

            return content;
        }

        /// <summary>
        /// Retrieves the index of the form field specified by ID within the Fields collection.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns>The first index of the form field object specified by ID.</returns>
        public int GetFieldIndexByID(string fieldId)
        {
            int index = -1;

            if (fieldId == null)
                throw new ArgumentException("Null fieldID argument passed.");

            foreach (IFormField field in Fields)
            {
                if (field.ID == fieldId)
                {
                    index = Fields.IndexOf(field);
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Retrieves the index(-ices) of the form field(s) specified by Type within the Fields collection.
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns>A list containing the Value indices of objects matching the specified Type within the Fields collection.</returns>
        public List<int> GetFieldIndicesByType(Type fieldType)
        {
            List<int> indices = new List<int>();

            if (fieldType == null)
                throw new ArgumentException("Null type argument passed.");

            foreach (IFormField field in Fields)
            {
                if (field.GetType() == fieldType)
                    indices.Add(Fields.IndexOf(field));
            }

            return indices;
        }

        /// <summary>
        /// Retrieves the form field object specified by ID within the Fields collection.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns>The form field object specified.</returns>
        public IFormField GetFieldObjectByID(string fieldId)
        {
            object formField = null;

            if (fieldId == null)
                throw new ArgumentException("Null fieldID argument passed.");

            foreach (IFormField field in Fields)
            {
                if (field.ID == fieldId)
                {
                    formField = field;
                    break;
                }
            }

            return formField as IFormField;
        }

        /// <summary>
        /// Retrieves the form field object(s) specified by Type within the Fields collection.
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns>A list containing copies of objects matching the specified Type within the Fields collection.</returns>
        public List<IFormField> GetFieldObjectsByType(Type fieldType)
        {
            List<IFormField> objects = new List<IFormField>();

            if (fieldType == null)
                throw new ArgumentException("Null type argument passed.");

            foreach (IFormField field in Fields)
            {
                if (field.GetType() == fieldType)
                    objects.Add(field);
            }

            return objects;
        }

        /// <summary>
        /// Retrieves the value of the form field specified by ID within the Fields collection.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns>The Value property of the form field object specified.</returns>
        public object GetFieldValueByID(string fieldId)
        {
            object value = null;

            if (fieldId == null)
                throw new ArgumentException("Null fieldID argument passed.");

            foreach (IFormField field in Fields)
            {
                value = (field.ID == fieldId) ? field.Value : null;
                break;
            }

            return value;
        }

        /// <summary>
        /// Retrieves the value(s) of the form field(s) specified by Type within the Fields collection.
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns>A list containing the Value properties of objects matching the specified Type within the Fields collection.</returns>
        public List<object> GetFieldValuesByType(Type fieldType)
        {
            List<object> values = new List<object>();

            if (fieldType == null)
                throw new ArgumentException("Null type argument passed.");

            foreach (IFormField field in Fields)
            {
                if (field.GetType() == fieldType)
                    values.Add(field.Value);
            }

            return values;
        }

        #endregion
    }
}
