using Smart.Blazor;
using VedasPortal.Enums;

namespace VedasPortal.Models.OptionsElements
{
    public class ElementService : IElementService
    {
        public ElementService()
        {
            ConfigOptions(new ElementOptions());
        }

        public ElementService(ElementOptions extOptions)
        {
            ConfigOptions(extOptions);
        }

        private static void ConfigOptions(ElementOptions extOptions)
        {
            var intOptions = new OptionsInternal();
            switch (extOptions.positionClass)
            {
                case PositionClassType.TopRight:
                    intOptions.positionClass = "toast-top-right";
                    break;
                case PositionClassType.TopLeft:
                    intOptions.positionClass = "toast-top-left";
                    break;
                case PositionClassType.TopCenter:
                    intOptions.positionClass = "toast-top-center";
                    break;
                case PositionClassType.TopFullWidth:
                    intOptions.positionClass = "toast-top-full-width";
                    break;
                case PositionClassType.BottomRight:
                    intOptions.positionClass = "toast-bottom-right";
                    break;
                case PositionClassType.BottomLeft:
                    intOptions.positionClass = "toast-bottom-left";
                    break;
                case PositionClassType.BottomCenter:
                    intOptions.positionClass = "toast-bottom-center";
                    break;
                case PositionClassType.BottomFullWidth:
                    intOptions.positionClass = "toast-bottom-full-width";
                    break;
                default:
                    intOptions.positionClass = "toast-top-right";
                    break;
            }
            intOptions.closeButton = extOptions.closeButton;
            intOptions.debug = extOptions.debug;
            intOptions.newestOnTop = extOptions.newestOnTop;
            intOptions.progressBar = extOptions.progressBar;
            intOptions.preventDuplicates = extOptions.preventDuplicates;
            intOptions.onclick = extOptions.onClick;
            intOptions.showDuration = extOptions.showDuration;
            intOptions.hideDuration = extOptions.hideDuration;
            intOptions.timeOut = extOptions.timeOut;
            intOptions.extendedTimeOut = extOptions.extendedTimeOut;
            switch (extOptions.showEasing)
            {
                case EasingType.Linear:
                    intOptions.showEasing = "linear";
                    break;
                case EasingType.Swing:
                    intOptions.showEasing = "swing";
                    break;
                case EasingType.Default:
                    intOptions.showEasing = "default";
                    break;
                default:
                    intOptions.showEasing = "swing";
                    break;
            }
            switch (extOptions.hideEasing)
            {
                case EasingType.Linear:
                    intOptions.hideEasing = "linear";
                    break;
                case EasingType.Swing:
                    intOptions.hideEasing = "swing";
                    break;
                case EasingType.Default:
                    intOptions.hideEasing = "default";
                    break;
                default:
                    intOptions.hideEasing = "linear";
                    break;
            }
            switch (extOptions.showMethod)
            {
                case EffectType.FadeIn:
                    intOptions.showMethod = "fadeIn";
                    break;
                case EffectType.FadeOut:
                    intOptions.showMethod = "fadeOut";
                    break;
                case EffectType.SlideIn:
                    intOptions.showMethod = "slideIn";
                    break;
                case EffectType.SlideOut:
                    intOptions.showMethod = "slideOut";
                    break;
                default:
                    intOptions.showMethod = "fadeIn";
                    break;
            }
            switch (extOptions.hideMethod)
            {
                case EffectType.FadeIn:
                    intOptions.hideMethod = "fadeIn";
                    break;
                case EffectType.FadeOut:
                    intOptions.hideMethod = "fadeOut";
                    break;
                case EffectType.SlideIn:
                    intOptions.hideMethod = "slideIn";
                    break;
                case EffectType.SlideOut:
                    intOptions.hideMethod = "slideOut";
                    break;
                default:
                    intOptions.hideMethod = "fadeOut";
                    break;
            }


        }

        public void Show(ToastType toastrType, string message, string title = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
