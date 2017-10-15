using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationsManager.Core.Interfaces.Processes
{
    public interface IProcessResult
    {
        void IncludeActionResult(IActionResult result);
    }
}
