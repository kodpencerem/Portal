
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace VedasPortal.Components.VedasToastComponent
{
    /// <summary>
    /// gerekli olması durumunda bakabilirsiniz: https://github.com/aspnet/AspNetCore/issues/13104
    /// </summary>
    [EventHandler("onmouseenter", typeof(MouseEventArgs))]
    [EventHandler("onmouseleave", typeof(MouseEventArgs))]
    public static class EventHandlers
    {
    }
}