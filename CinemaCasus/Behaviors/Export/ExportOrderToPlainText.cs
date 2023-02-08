using CinemaCasus.Interfaces;

namespace CinemaCasus.Behaviors.Export;

public class ExportOrderToPlainText : IExportBehaviour
{
    public string Export(object exportObject)
    {
        return exportObject.ToString() ?? string.Empty;
    }
}