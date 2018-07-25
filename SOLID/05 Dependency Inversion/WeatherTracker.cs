using System;

namespace SOLID._05_Dependency_Inversion
{
    public abstract class WeatherTracker
    {
        public virtual void GenerateWeatherAlert(String weatherConditions)
        {
            String alert = "It is " + weatherConditions;
            Console.Write(alert);
        }
    }
}
