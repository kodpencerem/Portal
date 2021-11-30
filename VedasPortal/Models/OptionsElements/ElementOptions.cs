using VedasPortal.Enums;

namespace VedasPortal.Models.OptionsElements
{
    public class ElementOptions
    {
        public bool closeButton { get; set; } = false;

        public bool debug { get; set; } = false;

        public bool newestOnTop { get; set; } = false;

        public bool progressBar { get; set; } = false;

        public PositionClassType positionClass { get; set; } = PositionClassType.TopRight;

        public bool preventDuplicates { get; set; } = false;

        public string onClick { get; set; } = null;

        public long showDuration { get; set; } = 300;

        public long hideDuration { get; set; } = 1000;

        public long timeOut { get; set; } = 5000;

        public long extendedTimeOut { get; set; } = 1000;

        public EasingType showEasing { get; set; } = EasingType.Swing;

        public EasingType hideEasing { get; set; } = EasingType.Linear;

        public EffectType showMethod { get; set; } = EffectType.FadeIn;

        public EffectType hideMethod { get; set; } = EffectType.FadeOut;

    }
}
