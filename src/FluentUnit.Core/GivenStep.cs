using System;

namespace FluentUnit.Core
{
    internal class GivenStep : IGiven
    {
        private Action _arrange = () => {};

        public IAnd<IGiven> Context(Action arrange)
        {
            _arrange += arrange;
            return new AndStep<IGiven>(this);
        }

        public IWhen<TSubject> Subject<TSubject>(Func<TSubject> createSubject)
        {
            return new WhenStep<TSubject>(_arrange, createSubject);
        }
    }
}