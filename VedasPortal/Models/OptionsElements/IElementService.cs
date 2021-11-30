using Smart.Blazor;

namespace VedasPortal.Models.OptionsElements
{
    public interface IElementService
    {
        void Show(ToastType toastrType, string message, string title = null);
    }
}
