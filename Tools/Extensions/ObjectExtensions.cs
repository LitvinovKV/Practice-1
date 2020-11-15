using System;

namespace Tools.Extensions
{
    public static class ObjectExtensions
    {
        public static object GenericMethodInvoke(this object obj, string methodName, Type[] genericTypes, object[] methodParams = null)
        {
            if(genericTypes.IsNullOrEmpty())
            {
                throw new ArgumentNullException("Должны быть указаны параметры типа: GenericMethodInfo()");
            }

            var methodInfo = obj.GetType().GetMethod(methodName);
            var genericMethod = methodInfo.MakeGenericMethod(genericTypes);
            return genericMethod.Invoke(obj, methodParams);
        }
    }
}
