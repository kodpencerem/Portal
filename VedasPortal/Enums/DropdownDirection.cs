using System.ComponentModel;

namespace VedasPortal.Enums
{
    public enum DropdownDirection
    {
        Down,
        [Description("dropup")]
        Up,
        [Description("dropright")]
        Right,
        [Description("dropleft")]
        Left
    }
}
