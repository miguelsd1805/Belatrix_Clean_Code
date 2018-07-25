using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._05_Dependency_Inversion
{
    public abstract class Device : WeatherTracker
    {
        String currentConditions;
        public virtual void SetCurrentConditions(String weatherConditions)
        {
            currentConditions = weatherConditions;
            GenerateWeatherAlert(weatherConditions);
        }
    }
}
