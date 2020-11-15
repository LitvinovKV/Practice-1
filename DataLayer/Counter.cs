
namespace DataLayer
{
    public class Counter
    {
        private int stepValue;
        private int globalValue;

        public int Value
        {
            get
            {
                globalValue = stepValue;
                stepValue = 0;
                return globalValue;
            }

            set => stepValue += value;
        }

        public int SafeGetValue()
        {
            return globalValue;
        }
    }
}
