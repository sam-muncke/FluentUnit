using System;

namespace FluentUnit.Core
{
    public interface IThen
    {
        void Then(Action assert);
    }

    public interface IThen<out TResult> : IThen
    {
        void Then(Action<TResult> assert);
    }
}