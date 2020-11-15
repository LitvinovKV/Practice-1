using System.ComponentModel;

namespace DateLayer.Entities.Car
{
    public enum State
    {
        [Description("Возле дома")]
        AtHome,

        [Description("В пути")]
        OnWay,

        [Description("Ищет парковку")]
        LookingParking,

        [Description("На парковке")]
        InParking
    }
}