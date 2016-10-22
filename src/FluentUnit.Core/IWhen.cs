using System;
using System.Threading.Tasks;

namespace FluentUnit.Core
{
    public interface IWhen<TSubject>
    {
        IThen When(Action<TSubject> act);
        IThen<TResult> When<TResult>(Func<TSubject, TResult> act);
        IThenAsync When(Func<TSubject, Task> act);
        IThenAsync<TResult> When<TResult>(Func<TSubject, Task<TResult>> act);
        IThen<Action> WhenCreated();
    }
}