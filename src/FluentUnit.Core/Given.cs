namespace FluentUnit.Core
{
    public static class Given
    {
        public static IGiven A => new GivenStep();
    }
}