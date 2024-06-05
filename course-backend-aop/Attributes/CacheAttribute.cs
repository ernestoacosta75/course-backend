namespace course_backend_aop.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class CacheAttribute : Attribute
    {
        public CacheAttribute() { }
    }
}
