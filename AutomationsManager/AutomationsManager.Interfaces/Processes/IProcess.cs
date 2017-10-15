using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationsManager.Interfaces.Processes
{
    public interface IProcess
    {
        IProcessResult Execute();
    }
}
