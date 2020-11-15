using DataLayer;
using DateLayer.Entities.Car.Make;
using DateLayer.Entities.Car.Make.Model;
using System.Text;

namespace DateLayer.Entities.Car
{
    public class CarBase
    {
        public string Number { get; set; }
        public MakeBase Make { get; set; }
        public ModelBase Model { get; set; }
        public Color Color { get; set; }
        public State State { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            sb.Append("�����: ").Append(Number);
            sb.Append(" �����: ").Append(Make.GetType().Name);
            sb.Append(" ������: ").Append(Model.GetType().Name);
            sb.Append(" ����: ").Append(Color.GetDescription());
            sb.Append(" ���������: ").Append(State.GetDescription());

            return sb.ToString();
        }

        public override int GetHashCode()
            => Number.GetHashCode();
    }
}