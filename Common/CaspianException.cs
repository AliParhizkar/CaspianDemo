using System;

namespace Caspian.Common
{
    public class CaspianException : Exception
    {
        internal int _HelpId;
        public CaspianException(string message, int helpId)
            : base(message)
        {
            _HelpId = helpId;
        }
    }
}
