using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System;

namespace TimeseriesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // var i = 0;


            var context = new MLContext();

            var data = context.Data.LoadFromTextFile<TemperatureData>(@"C:\Users\Michael\source\repos\TimeseriesTest\actualdata.csv",
                hasHeader: true, separatorChar: ',');

            var pipeline = context.Forecasting.ForecastBySsa(

                "Forecast",
                nameof(TemperatureData.Temperature),
                windowSize: 7 * 24,//observations in week
                seriesLength: 30 * 24, //observations in a month
                trainSize: 23819,//from where prediction starts
                horizon: 9 //number of timesteps in prediction
                );
            var model = pipeline.Fit(data);

            var forecastingEngine = model.CreateTimeSeriesEngine<TemperatureData, TemperatureForecast>(context);

            var forecasts = forecastingEngine.Predict();

            foreach (var forecast in forecasts.Forecast)
            {
                Console.WriteLine(forecast);

            }
            Console.ReadLine();
        }
    }
}
