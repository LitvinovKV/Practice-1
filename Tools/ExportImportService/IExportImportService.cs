using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.ExportImportService
{
    public interface IExportImportService
    {
        Task<T> Import<T>(String path);
        Task Export(Object data, String path);
    }
}
