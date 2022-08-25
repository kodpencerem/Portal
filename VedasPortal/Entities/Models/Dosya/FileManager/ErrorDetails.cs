using System.Collections.Generic;
#if EJ2_DNX
using System.Web;
#endif

namespace DocumentExplorer.Models.FileManager
{
    public class ErrorDetails
    {

        public string Code { get; set; }

        public string Message { get; set; }

        public IEnumerable<string> FileExists { get; set; }
    }
}