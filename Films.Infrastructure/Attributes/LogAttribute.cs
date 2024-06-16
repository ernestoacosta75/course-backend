namespace Films.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class LogAttribute : Attribute
    {
        public LogAttribute() { }
    }
}
