namespace FluentUnit.Core
{
    public class PostGivenThat
    {
        public PostGivenThat(IGiven given)
        {
            And = given;
        }

        public IGiven And { get; }
    }
}