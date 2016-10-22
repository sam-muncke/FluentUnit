using System;
using FluentUnit.Core;
using Ploeh.AutoFixture;

namespace FluentUnit.AutoFixture
{
    internal class GivenAFixture : IGivenAFixture
    {
        private IGiven _given;
        private readonly IFixture _fixture;

        public GivenAFixture(IGiven given, IFixture fixture)
        {
            _given = given;
            _fixture = fixture;
        }

        public IAnd<IGivenAFixture> With<TDependency>()
        {
            return With<TDependency>(null);
        }

        public IAnd<IGivenAFixture> With<TDependency>(Action<TDependency> setupDependency)
        {
            _given = _given.Context(() =>
            {
                var dependency = _fixture.Freeze<TDependency>();
                setupDependency?.Invoke(dependency);
            }).And;

            return new AndStep<IGivenAFixture>(this);
        }

        public IAnd<IGivenAFixture> With<TDependency>(TDependency instance) {
            return With(instance, null);
        }

        public IAnd<IGivenAFixture> With<TDependency>(TDependency instance, Action<TDependency> setupDependency)
        {
            _given = _given.Context(() =>
            {
                setupDependency?.Invoke(instance);
                _fixture.Inject(instance);
            }).And;

            return new AndStep<IGivenAFixture>(this);
        }

        public IWhen<TSubject> WithSubject<TSubject>()
        {
            return _given.Subject(() => _fixture.Create<TSubject>());
        }
    }
}