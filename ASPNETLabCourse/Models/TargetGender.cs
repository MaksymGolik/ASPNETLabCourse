using System.ComponentModel;

namespace ASPNETLabCourse.Models
{
    public enum TargetGender
    {
        [Description("Чоловічі")]
        Male,
        [Description("Жіночі")]
        Female,
        [Description("Універсальні")]
        Unisex
    }
}
