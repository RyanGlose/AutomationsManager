using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationsManager.Core.Processes
{
    public interface IProcess
    {
        IProcessResult Execute();
    }
}
