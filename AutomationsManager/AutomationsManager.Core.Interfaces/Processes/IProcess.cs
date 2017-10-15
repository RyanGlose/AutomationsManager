using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationsManager.Core.Interfaces.Processes
{
    public interface IProcess
    {
        IList<ISimpleAction> Actions { get; }
        IProcessConfiguration Configuration { get; }
        IProcessResult Execute();
        bool IsPossibleToStart();
    }
}
