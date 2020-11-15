using System.ComponentModel;

namespace DateLayer.Entities.Car
{
    public enum State
    {
        [Description("����� ����")]
        AtHome,

        [Description("� ����")]
        OnWay,

        [Description("���� ��������")]
        LookingParking,

        [Description("�� ��������")]
        InParking
    }
}