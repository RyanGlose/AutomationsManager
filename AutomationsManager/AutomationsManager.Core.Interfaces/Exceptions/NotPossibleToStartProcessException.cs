using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationsManager.Core.Interfaces.Properties;

namespace AutomationsManager.Core.Interfaces.Exceptions
{
    public class NotPossibleToStartProcessException : Exception
    {
        public NotPossibleToStartProcessException() : base(Resources.ErrorNotPossibleToStartProcess)
        {
            
        }

        public NotPossibleToStartProcessException(string customMessage) : base(customMessage)
        {
            
        }
    }
}
