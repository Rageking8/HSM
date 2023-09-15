namespace HSM.Utils
{
    public static class ObjectUtils
    {
        public static bool IsDefault<T>(this T obj)
        {
            return Equals(obj, default(T));
        }
    }
}
