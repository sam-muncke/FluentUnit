using System;

namespace FluentUnit.Core
{
    public interface IGiven
    {
        IAnd<IGiven> Context(Action arrange);
        IWhen<TSubject> Subject<TSubject>(Func<TSubject> createSubject);
    }
}