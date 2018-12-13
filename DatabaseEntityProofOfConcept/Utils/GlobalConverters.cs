using System;

namespace DatabaseEntityProofOfConcept.Extensions
{
    public static class GlobalConverters
    {
        public static T ConvertToEntities<T>(object obj)
        {
            T enumValue = (T)Enum.Parse(typeof(T), obj.ToString());
            return enumValue;
        }
    }
}
