namespace FluentUnit.Core
{
    public class AndStep<TStep> : IAnd<TStep>
    {
        public AndStep(TStep step)
        {
            And = step;
        }

        public TStep And { get; }
    }
}