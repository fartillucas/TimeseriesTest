using Microsoft.ML.Data;
using System;

namespace TimeseriesTest
{
    internal class TemperatureData
    {
        [LoadColumn(0)]
        public DateTime Date { get; set; }


        [LoadColumn(1)]
        public float Temperature { get; set; }
    }
}