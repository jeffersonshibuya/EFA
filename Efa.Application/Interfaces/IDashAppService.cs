using System;
using Efa.Application.ViewModels;

namespace Efa.Application.Interfaces
{
    public interface IDashAppService : IDisposable
    {
        DashViewModel Dash();
    }
}