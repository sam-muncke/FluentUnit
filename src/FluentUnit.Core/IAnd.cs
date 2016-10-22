namespace FluentUnit.Core
{
    public interface IAnd<out TStep>
    {
        TStep And { get; }
    }
}