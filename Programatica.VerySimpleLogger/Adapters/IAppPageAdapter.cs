using Programatica.Framework.Mvc.Adapters;

namespace Programatica.VerySimpleLogger.Adapters
{
    public interface IAppPageAdapter : IPageAdapter
    {
        string AppVersion { get; }
    }
}
