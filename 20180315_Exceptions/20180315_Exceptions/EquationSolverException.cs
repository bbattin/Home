using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180315_Exceptions
{
    class EquationSolverException : Exception
    {
        public EquationSolverException()
        {
            CreatedDate = DateTime.Now;
        }

        public EquationSolverException(string message)
            : base(message)
        {
            CreatedDate = DateTime.Now;
        }

        public EquationSolverException(string message, Exception innerException)
            : base(message, innerException)
        {
            CreatedDate = DateTime.Now;
        }

        // описание возникшей ситации
        public DateTime CreatedDate { get; private set; }
    }
}
