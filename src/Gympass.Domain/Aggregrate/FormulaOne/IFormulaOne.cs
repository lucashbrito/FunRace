﻿namespace Gympass.Domain.Interfaces
{
    public interface IFormulaOne
    {
        void Start();

        void GetBestLap();

        void AverageSpeed();

        void DifferenceOfEachPilot();

        void Result();
        void GetBestLapOfEachDriver();
    }
}