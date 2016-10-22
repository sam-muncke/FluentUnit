using System;
using FluentUnit.Core;

namespace FluentUnit.AutoFixture
{
    public interface IGivenAFixture
    {
        IAnd<IGivenAFixture> With<TDependency>();
        IAnd<IGivenAFixture> With<TDependency>(Action<TDependency> setupDependency);
        IAnd<IGivenAFixture> With<TDependency>(TDependency instance);
        IAnd<IGivenAFixture> With<TDependency>(TDependency instance, Action<TDependency> setupDependency);
        IWhen<TSubject> WithSubject<TSubject>();
    }
}