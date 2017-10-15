using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutomationsManager.Core.Interfaces.Exceptions;
using AutomationsManager.Core.Interfaces.Processes;

namespace AutomationsManager.Core.Processes
{
    public abstract class AbstractProcess : IProcess
    {
        public IList<ISimpleAction> Actions { get; }
        public IProcessConfiguration Configuration { get; }
        public IProcessResult Execute()
        {
            if (!IsPossibleToStart())
            {
                throw new NotPossibleToStartProcessException();
            }

            IProcessResult processResult = GetEmptyProcessResult();

            OnProcessStart(processResult);

            foreach (var action in Actions)
            {
                var actionResult = action.Perform();
                processResult.IncludeActionResult(actionResult);
            }

            OnProcessEnd(processResult);

            return processResult;
        }

        public virtual bool IsPossibleToStart()
        {
            return Actions != null && Actions.Any();
        }

        #region Abstract Methods
        protected virtual void OnProcessStart(IProcessResult result) { }
        protected virtual void OnProcessEnd(IProcessResult result) { }
        protected abstract IProcessResult GetEmptyProcessResult();

        #endregion
    }
}
