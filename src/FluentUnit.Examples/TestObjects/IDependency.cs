namespace FluentUnit.Examples.TestObjects
{
    public interface IDependency
    {
        object DependencyProperty { get; }
        void DependencyMethod();
    }
}