using System;

namespace Tools.ProbabilityChanger
{
    public interface ICityProbabilityChanger
    {
        double CarsStatusChance { get; set; }
        double CarsUtilizationChance { get; set; }
        double NewCarChance { get; set; }

        void NewCarAction();
        void CarsStatusChangeAction();
        void CarsUtilizationAction();
    }
}
