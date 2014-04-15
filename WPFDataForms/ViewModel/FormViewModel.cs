///////////////////////////////////////
#region Namespace Directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using WpfHelper.ViewModel;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel
{
    public class FormViewModel : ViewModelBase, IForm
    {
        ////////////////////////////////////////
        #region Generic Fields

        private bool _isComplete;

        #endregion

        ////////////////////////////////////////
        #region Properties

        /// <summary>
        /// Represents data fields displayed/inputted via the form.
        /// </summary>
        /// <remarks>
        /// "ObservableCollection" objects already have PropertyChanged notification built within, so updates to the internal ArrayList
        /// will update the state of the collection displayed within an interface when this is bound to it. We don't have to provide a
        /// complete implementation of the Setter.
        /// </remarks>
        public ObservableCollection<IFormField> Fields
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether or not all form fields have been populated with valid input.
        /// </summary>
        /// <remarks>
        /// Even though a read-only version of this property would make sense for validation purposes, attaching PropertyChanged notification
        /// allows us to change the state of the interface surrounding the form when this property is bound to the interface itself.
        /// </remarks>
        public bool IsComplete
        {
            get
            {
                return _isComplete;
            }
            set
            {
                _isComplete = value;
                OnPropertyChanged("IsComplete");
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Public Methods

        /// <summary>
        /// Adds a field to the form and attaches appropriate events to it.
        /// </summary>
        /// <param name="field">A field object.</param>
        /// <returns>The index of the object in the collection.</returns>
        public int AddField(IFormField field)
        {
            if (field == null)
                throw new ArgumentException("Null Argument passed.");

            field.PropertyChanged += field_PropertyChanged;
            Fields.Add(field);
            return Fields.IndexOf(field);
        }

        /// <summary>
        /// Searches the Fields collection for the specified ID, indicating whether or not it was found.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns>Whether or not the specified ID could be found.</returns>
        public bool CheckIfFieldExists(string fieldId)
        {
            bool fieldExists = false;

            if (fieldId != null)
            {
                foreach (IFormField field in Fields)
                {
                    if (field.ID == fieldId)
                    {
                        fieldExists = true;
                        break;
                    }
                }
            }

            return fieldExists;
        }

        /// <summary>
        /// Clears the collection of Fields for this form.
        /// </summary>
        /// <returns>Whether or not the Clear() operation was successful.</returns>
        public bool ClearFields()
        {
            try
            {
                Fields.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }

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

        /// <summary>
        /// Retrieves a list of the IDs available for access within the Fields collection.
        /// </summary>
        /// <returns>List of IDs currently available for access.</returns>
        public List<string> ListFieldIDs()
        {
            List<string> ids = new List<string>();

            foreach (IFormField field in Fields)
            {
                ids.Add(field.ID);
            }

            return ids;
        }

        /// <summary>
        /// Removes the form field object specified by duplicate within the Fields collection.
        /// </summary>
        /// <param name="field"></param>
        /// <returns>Whether or not the field was successfully removed from the collection.</returns>
        public bool RemoveField(IFormField field)
        {
            bool removeSuccessful = false;

            if (field == null)
                throw new ArgumentException("Null object argument passed.");

            try
            {
                field.PropertyChanged -= field_PropertyChanged;
                Fields.Remove(field);
                removeSuccessful = true;
            }
            catch
            {
                removeSuccessful = false;
            }

            return removeSuccessful;
        }

        /// <summary>
        /// Removes the form field object specified by ID within the Fields collection.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns>Whether or not the field was successfully removed from the collection.</returns>
        public bool RemoveFieldByID(string fieldId)
        {
            bool removeSuccessful = false;

            if (fieldId == null)
                throw new ArgumentException("Null fieldId argument passed.");

            try
            {
                foreach (IFormField field in Fields)
                {
                    if (field.ID == fieldId)
                    {
                        field.PropertyChanged -= field_PropertyChanged;
                        Fields.Remove(field);
                        removeSuccessful = true;
                    }
                }
            }
            catch
            {
                removeSuccessful = false;
            }

            return removeSuccessful;
        }

        /// <summary>
        /// Removes the form field object specified by index within the Fields collection.
        /// </summary>
        /// <param name="fieldIndex"></param>
        /// <returns>Whether or not the field was successfully removed from the collection.</returns>
        public bool RemoveFieldByIndex(int fieldIndex)
        {
            bool removeSuccessful = false;

            try
            {
                Fields[fieldIndex].PropertyChanged -= field_PropertyChanged;
                Fields.RemoveAt(fieldIndex);
                removeSuccessful = true;
            }
            catch
            {
                removeSuccessful = false;
            }

            return removeSuccessful;
        }

        /// <summary>
        /// Resets all fields in the Fields collection to their respective defaults.
        /// </summary>
        /// <returns>Whether or not the reset operations were successful.</returns>
        public bool ResetFields()
        {
            bool resetSuccessful = false;

            try
            {
                foreach (IFormField field in Fields)
                {
                    field.Reset();
                }
                resetSuccessful = true;
            }
            catch
            {
                resetSuccessful = false;
            }

            return resetSuccessful;
        }

        #endregion

        ////////////////////////////////////////
        #region Object-to-Form Serialization

        /// <summary>
        /// Populates the field contents of a form object by deserializing data from an object.
        /// </summary>
        /// <param name="_object">The object/type form data will be populated from.</param>
        /// <returns>Whether or not deserialization succeeded.</returns>
        /// <remarks>
        /// This method is designed to match form field IDs to property names and vice-versa.
        /// Be sure that the object type you are serializing form data to has properties that match the form IDs if 
        /// you want a complete object to result.
        /// </remarks>
        public bool DeserializeObjectToForm(object _object)
        {
            bool success = false;

            if (_object != null)
            {
                PropertyInfo[] properties = _object.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    if (property.CanWrite && CheckIfFieldExists(property.Name))
                    {
                        GetFieldObjectByID(property.Name).Content = property.GetValue(_object, null);
                    }
                }

                success = true;
            }

            return success;
        }

        /// <summary>
        /// Serializes an object from form data.
        /// </summary>
        /// <param name="objectType">The object type the form is to be serialized to.</param>
        /// <returns>A serialized object with properties and attributes assigned from the type argument.</returns>
        /// <remarks>
        /// This method is designed to match form field IDs to property names and vice-versa.
        /// Be sure that the object type you are serializing form data to has properties that match the form IDs if 
        /// you want a complete object to result.
        /// </remarks>
        public object SerializeObjectFromForm(Type objectType)
        {
            if (objectType == null)
                throw new ArgumentException("Type argument cannot be null.");

            object _dummyObject = Activator.CreateInstance(objectType);

            PropertyInfo[] properties = objectType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite && CheckIfFieldExists(property.Name) && !(property.GetValue(_dummyObject, null) is System.Guid))
                {
                    if (property.GetValue(_dummyObject, null) is Double)
                    {
                        double resultDouble = 0.0;
                        if (Double.TryParse(GetFieldObjectByID(property.Name).Content.ToString(), out resultDouble))
                        {
                            property.SetValue(_dummyObject, resultDouble, null);
                        }
                    }
                    else if (property.GetValue(_dummyObject, null) is Int32)
                    {
                        int resultInt = 0;
                        if (Int32.TryParse(GetFieldObjectByID(property.Name).Content.ToString(), out resultInt))
                        {
                            property.SetValue(_dummyObject, resultInt, null);
                        }
                    }
                    else
                    {
                        property.SetValue(_dummyObject, GetFieldObjectByID(property.Name).Content, null);
                    }
                }
            }

            return _dummyObject;
        }

        #endregion

        ////////////////////////////////////////
        #region Constructors

        /// <summary>
        /// Creates a new data form object.
        /// </summary>
        public FormViewModel()
        {
            InitializeFieldsCollection();
        }

        #endregion

        ////////////////////////////////////////
        #region Event Handlers

        void field_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.IsComplete = CheckIfFieldsAreComplete();
        }

        void Fields_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.IsComplete = CheckIfFieldsAreComplete();
        }

        #endregion

        ////////////////////////////////////////
        #region Supporting Methods

        /// <summary>
        /// Determines if all form fields contain valid input.
        /// </summary>
        /// <returns></returns>
        private bool CheckIfFieldsAreComplete()
        {
            bool fieldsAreValid = false;

            foreach (IFormField field in Fields)
            {
                if (field.IsValid)
                {
                    fieldsAreValid = true;
                }
                else
                {
                    fieldsAreValid = false;
                    break;
                }
            }

            return fieldsAreValid;
        }

        /// <summary>
        /// Instantiates the fields collection and attaches appropriate attributes and event handlers.
        /// </summary>
        private void InitializeFieldsCollection()
        {
            Fields = new ObservableCollection<IFormField>();
            Fields.CollectionChanged += Fields_CollectionChanged;
        }

        #endregion
    }
}
