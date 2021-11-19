using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    class ErrorArchivosExcepction : Exception
    {
        public ErrorArchivosExcepction(string message) : base(message) { }

        public ErrorArchivosExcepction(string message, Exception inner) 
            : base(message, inner) { }
    }
}
