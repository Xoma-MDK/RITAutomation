using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    internal class NoRecordsInDatabase : Exception
    {
        public NoRecordsInDatabase(): base("No records in database!")
        {
            
        }

    }
}
