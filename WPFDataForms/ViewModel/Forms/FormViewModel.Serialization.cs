///////////////////////////////////////
#region Namespace Directives

using System;
using System.Reflection;
using WpfHelper.ViewModel;

#endregion
///////////////////////////////////////

namespace WPFDataForms.ViewModel.Forms
{
    public partial class FormViewModel : ViewModelBase, IForm
    {
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
                PropertyInfo[] properties = _object.GetType().GetProperties(); // list all properties available to this type

                foreach (PropertyInfo property in properties) // enumerate through properties to assign form field contents
                {
                    if (property.CanWrite && CheckIfFieldExists(property.Name)) // if property exists & is not read-only
                        GetFieldObjectByID(property.Name).Content = property.GetValue(_object, null);
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
        /// Additionally, though this currently contains parsers for Int32, Double and Object types at the moment
        /// </remarks>
        public object SerializeObjectFromForm(Type objectType)
        {
            if (objectType == null)
                throw new ArgumentException("Type argument cannot be null.");

            object _dummyObject = Activator.CreateInstance(objectType); // cast blank object to the type specified as method argument

            PropertyInfo[] properties = objectType.GetProperties(); // list all properties available to this type

            foreach (PropertyInfo property in properties) // enumerate through properties to assign object values
            {
                if (property.CanWrite && CheckIfFieldExists(property.Name) && !(property.GetValue(_dummyObject, null) is System.Guid))
                {
                    if (property.GetValue(_dummyObject, null) is Double) // recognize Double type
                    {
                        property.SetValue(_dummyObject, ParseContentAsDouble(property), null);
                    }
                    else if (property.GetValue(_dummyObject, null) is Int32) // recognize Int32 type
                    {
                        property.SetValue(_dummyObject, ParseContentAsInt32(property), null);
                    }
                    else // default to Object type
                    {
                        property.SetValue(_dummyObject, GetFieldObjectByID(property.Name).Content, null);
                    }
                }
            }

            return _dummyObject;
        }

        #endregion

        ////////////////////////////////////////
        #region Supporting Methods

        /// <summary>
        /// Parse property data to Double for injection into "blank" object.
        /// </summary>
        /// <param name="property"></param>
        /// <returns>Data associated with the specified object property, casted as a double.</returns>
        /// <remarks>
        /// Types listed within these methods are the only ones (of the ones used so far) that successfully
        /// brought similar implementations in prior applications to a grinding halt when not present. System.DateTime
        /// and others seem to fit the last object case quite well. If any others are found to be useful, feel free to 
        /// suggest/add them!
        /// </remarks>
        private double ParseContentAsDouble(PropertyInfo property)
        {
            double resultDouble = 0.0;
            return Double.TryParse(GetFieldObjectByID(property.Name).Content.ToString(), out resultDouble) ? resultDouble : 0.0;
        }

        /// <summary>
        /// Parse property data to Double for injection into "blank" object.
        /// </summary>
        /// <param name="property"></param>
        /// <returns>Data associated with the specified object property, casted as Int32.</returns>
        /// <remarks>
        /// Types listed within these methods are the only ones (of the ones used so far) that successfully
        /// brought similar implementations in prior applications to a grinding halt when not present. System.DateTime
        /// and others seem to fit the last object case quite well. If any others are found to be useful, feel free to 
        /// suggest/add them!
        /// </remarks>
        private int ParseContentAsInt32(PropertyInfo property)
        {
            int resultInt = 0;
            return Int32.TryParse(GetFieldObjectByID(property.Name).Content.ToString(), out resultInt) ? resultInt : 0;
        }

        #endregion
    }
}
