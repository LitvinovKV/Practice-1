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
            
            sb.Append("Номер: ").Append(Number);
            sb.Append(" Марка: ").Append(Make.GetType().Name);
            sb.Append(" Модель: ").Append(Model.GetType().Name);
            sb.Append(" Цвет: ").Append(Color.GetDescription());
            sb.Append(" Состояние: ").Append(State.GetDescription());

            return sb.ToString();
        }

        public override int GetHashCode()
            => Number.GetHashCode();
    }
}