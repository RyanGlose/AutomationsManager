using System;
using System.Collections.Generic;
using System.Text;
using AutomationsManager.Core.Interfaces.Processes;

namespace AutomationsManager.Core.Processes
{
    public class TestProcess : IProcess
    {
        public IList<ISimpleAction> Actions { get; }
        public IProcessConfiguration Configuration { get; }

        public IProcessResult Execute()
        {
            return null;
        }

        public bool IsPossibleToStart()
        {
            throw new NotImplementedException();
        }
    }
}
