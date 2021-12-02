using System.ComponentModel;

namespace VedasPortal.Enums
{
    public enum ObjectClasses
    {
        [Description("pretty")]
        Pretty,
        [Description("p-default")]
        PrettyPDefault,

        [Description("pretty p-default")]
        PDefault,

        [Description("pretty p-default p-fill")]
        PrettyPDefaultPFill,
        [Description("p-fill")]
        PFill,

        [Description("pretty p-default p-thick")]
        PrettyPDefaultPThick,

        [Description("p-thick")]
        PThick,

        [Description("pretty p-default p-curve")]
        PrettyPDefaultPCurve,

        [Description("p-curve")]
        PCurve,

        [Description("pretty p-default p-curve p-fill")]
        PrettyPDefaultPCurvePFill,

        [Description("pretty p-default p-curve p-thick")]
        PrettyPDefaultPCurvePThick,

        [Description("pretty p-default p-round")]
        PrettyPDefaultPRound,

        [Description("p-round")]
        PRound,


        [Description("pretty p-default p-round p-fill")]
        PrettyPDefaultPRoundPFill,

        [Description("pretty p-default p-round p-thick")]
        PrettyPDefaultPRoundPthick,

        [Description("pretty p-switch")]
        PrettyPSwith,

        [Description("p-switch")]
        PSwith,

        [Description("pretty p-switch p-fill")]
        PrettyPSwithPFill,

        [Description("pretty p-switch p-slim")]
        PrettyPSwitchPslim,

        [Description("p-slim")]
        Pslim,

        [Description("state p-primary")]
        StatePrimary,

        [Description("p-primary")]
        PPrimary,

        [Description("state p-success")]
        StateSuccess,

        [Description("p-success")]
        PSuccess,

        [Description("state p-info")]
        StateInfo,

        [Description("p-info")]
        PInfo,

        [Description("state p-warning")]
        StateWarning,

        [Description("p-warning")]
        PWarning,

        [Description("state")]
        State,

        [Description("state p-danger")]
        StateDanger,

        [Description("p-danger")]
        PDanger,

        [Description("state p-primary-o")]
        StatePrimaryO,

        [Description("p-primary-o")]
        PPrimaryO,

        [Description("state p-success-o")]
        StateSuccessO,

        [Description("p-success-o")]
        PSuccessO,

        [Description("state p-info-o")]
        StateInfoO,

        [Description("p-info-o")]
        PInfoO,

        [Description("state p-warning-o")]
        StateWarningO,

        [Description("p-warning-o")]
        PWarningO,

        [Description("state p-danger-o")]
        StateDangerO,

        [Description("p-danger-o")]
        PDangerO,


        [Description("pretty p-icon p-smooth")]
        PrettyPIconPSmooth,

        [Description("p-smooth")]
        PSmooth,

        [Description("icon fas fa-times")]
        IconFasFaTimes,

        [Description("fas fa-times")]
        FasFaTimes,

        [Description("fa-times")]
        FaTimes,

        [Description("icon material-icons")]
        IconMaterialIcons,

        [Description("pretty p-icon p-toggle p-plain")]
        PrettyPIconPTogglePPlain,

        [Description("p-toggle")]
        PToggle,

        [Description("p-plain")]
        PPlain,

        [Description("p-icon")]
        PIcon,

        [Description("material-icons")]
        MaterialIcons,

        [Description("p-icon p-toggle p-plain")]
        PIconTogglePlain,

        [Description("p-toggle p-plain")]
        PTogglePPlain,

        [Description("state p-off")]
        StatePOff,
        [Description("p-off")]
        POff,

        [Description("state p-on p-info-o")]
        StatePOnPInfoO,

        [Description("p-on p-info-o")]
        POnPInfoO,

        [Description("p-on")]
        POn,

        [Description("pretty p-svg p-curve")]
        PrettyPSvgPCurve,

        [Description("p-svg p-curve")]
        PSvgPCurve,

        [Description("p-svg")]
        PSvg,

        [Description("svg svg-icon")]
        SvgSvgIcon,

        [Description("svg-icon")]
        SvgIcon,

        [Description("svg")]
        Svg,

        [Description("pretty p-icon p-round p-smooth p-plain")]
        PrettyPIconPRoundPSmoothPPlain,

        [Description("p-icon p-round p-smooth p-plain")]
        PIconPRoundPSmoothPPlain,

        [Description("p-round p-smooth p-plain")]
        PRoundPSmoothPPlain,

        [Description("p-smooth p-plain")]
        PSmoothPPlain,

        [Description("pretty p-default p-round p-smooth p-plain")]
        PrettyPDefaultPRoundPSmoothPPlain,
        [Description("p-default p-round p-smooth p-plain")]
        PDefaultPRoundPSmoothPPlain,

        [Description("pretty p-default p-curve p-toggle")]
        PrettyPDefaultPCurvePToggle,

        [Description("state p-danger p-off")]
        StatePDangerPOff,

        [Description("p-danger p-off")]
        PDangerPOff,

        [Description("state p-success p-on")]
        StatePSuccessPOn,

        [Description("p-success p-on")]
        PSuccessPOn,

        [Description("state p-on")]
        StatePOn,

        [Description("pretty p-icon p-jelly p-round p-bigger")]
        PrettyPIconPJellyPRoundPBigger,

        [Description("p-icon p-jelly p-round p-bigger")]
        PIconPJellyPRoundPBigger,

        [Description("p-jelly p-round p-bigger")]
        PJellyPRoundPBigger,

        [Description("p-round p-bigger")]
        PRoundPBigger,

        [Description("p-bigger")]
        PBigger,

        [Description("p-jelly")]
        PJelly,

        [Description("pretty p-default p-smooth p-bigger")]
        PrettyPDefaultPSmoothPBigger,

        [Description("p-default p-smooth p-bigger")]
        PDefaultPSmoothPBigger,

        [Description("p-smooth p-bigger")]
        PSmoothPBigger,

        [Description("state p-danger")]
        StatePDanger,


        [Description("pretty p-icon p-curve p-tada")]
        PrettyPIconPCurvePTada,

        [Description("p-icon p-curve p-tada")]
        PIconPCurvePTada,

        [Description("p-curve p-tada")]
        PCurvePTada,
        [Description("p-tada")]
        PTada,


        [Description("pretty p-icon p-curve p-rotate")]
        PrettyPIconPCurvePRotate,

        [Description("p-icon p-curve p-rotate")]
        PIconPCurvePRotate,


        [Description("p-curve p-rotate")]
        PCurvePRotate,

        [Description("p-rotate")]
        PRotate,

        [Description("pretty p-icon p-curve p-pulse")]
        PrettyPIconPCurvePPulse,

        [Description("p-icon p-curve p-pulse")]
        PIconPCurvePPulse,

        [Description("p-curve p-pulse")]
        PCurvePPulse,

        [Description("p-pulse")]
        PPulse,


        [Description("pretty p-icon p-curve p-jelly")]
        PrettyPIconPCurvePJelly,

        [Description("p-icon p-curve p-jelly")]
        PIconPCurvePJelly,

        [Description("p-curve p-jelly")]
        PCurvePJelly,

        [Description("pretty p-icon p-curve p-smooth")]
        PrettyPIconPCurvePSmooth,

        [Description("p-icon p-curve p-smooth")]
        PIconPCurvePSmooth,

        [Description("p-curve p-smooth")]
        PCurvePSmooth,

        [Description("pretty p-icon p-round p-plain p-smooth")]
        PrettyPIconPRoundPPlainPSmooth,

        [Description("p-icon p-round p-plain p-smooth")]
        PIconPRoundPPlainPSmooth,

        [Description("p-round p-plain p-smooth")]
        PRoundPPlainPSmooth,

        [Description("p-plain p-smooth")]
        PPlainPSmooth,

    }
}
