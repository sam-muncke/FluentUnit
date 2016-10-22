using System;
using System.Threading.Tasks;

namespace FluentUnit.Core
{
    public interface IThenAsync
    {
        Task Then(Action assert);
    }

    public interface IThenAsync<out TResult> : IThenAsync
    {
        Task Then(Action<TResult> assert);
    }
}