namespace FluentUnit.Examples.TestObjects
{
    public class MockDependency : IDependency
    {
        public bool DependencyMethodWasCalled { get; set; }
        public object DependencyProperty { get; set; }

        public void DependencyMethod()
        {
            DependencyMethodWasCalled = true;
        }
    }
}