using System.ComponentModel;

namespace Domain.Models.ScreeningModels
{
    public enum VideoTechnology
    {
        [Description("2D")]
        TwoDimensional,

        [Description("3D")]
        ThreeDimensional
    }
}
