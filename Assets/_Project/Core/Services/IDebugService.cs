using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wordania.Core.Services
{
    public interface IDebugService
    {
        void LogInformation(string message);
    }
}