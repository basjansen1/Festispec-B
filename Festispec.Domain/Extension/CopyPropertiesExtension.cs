using System.Reflection;

namespace Festispec.Domain.Extension
{
    public static class CopyPropertiesExtension
    {
        public static void CopyPropertiesTo<T>(this T source, T destination)
        {
            // Iterate the Properties of the destination instance and  
            // populate them from their source counterparts  
            var propertyInfos = typeof(T).GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                // Check for write/set access
                if (!propertyInfo.CanWrite)
                    continue;

                try
                {
                    // Get the property value from the source
                    var sourceValue = propertyInfo.GetValue(source, null);

                    // Set the property value on the destination
                    propertyInfo.SetValue(destination, sourceValue, null);
                }
                catch (TargetInvocationException)
                {
                    // Catch exceptions when trying to access navigation properties while the DbContext has been disposed
                }
            }
        }
    }
}