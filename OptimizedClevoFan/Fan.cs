using System;
using System.Collections.Generic;

namespace OptimizedClevoFan
{
    public class Fan
    {
        private IFanControl fanControl;

        private Queue<int> last_temperatures;
        private int avg_temperature;
        private int desired_fan_rpm;
        private double last_fan_rpm;
        private int numberOfValuesForAvgTemperature;

        // PARAMS
        public int fanNumber;
        public string name;
        public double rpmStepUp = 2.5;
        public double rpmStepDown = 0.1;
        public int degreesStepSize = 5;
        public int[] temperatures;

        public Fan(IFanControl fan, int fanNumber, string name, int numberOfValuesForAvgTemperature)
        {
            this.fanControl = fan;
            this.fanNumber = fanNumber;
            this.name = name;
            this.numberOfValuesForAvgTemperature = numberOfValuesForAvgTemperature;

            this.avg_temperature = 40;
            this.last_temperatures = new Queue<int>();
            this.desired_fan_rpm = 35;
            this.last_fan_rpm = (double)this.desired_fan_rpm;
        }
        public int GetFanNumber() { return fanNumber; }

        public int GetDesiredRPM() { return this.desired_fan_rpm; }

        public double GetLastRPM() { return this.last_fan_rpm; }

        public int GetTemperature() { return this.avg_temperature; }

        public void LoadTemps(int[] temps)
        {
            this.temperatures = temps;
        }

        public void UpdateAvgTemperature()
        {
            int instant_temperature = (int)fanControl?.GetECData(this.fanNumber).Remote;

            // ----------------------------------------------------------------------------------------------------
            // Get average temperature for the last steps

            last_temperatures.Enqueue(instant_temperature);
            if (last_temperatures.Count > this.numberOfValuesForAvgTemperature)
                last_temperatures.Dequeue();

            int cpu_temp_avg = 0;
            foreach (int temp in last_temperatures)
                cpu_temp_avg += temp;
            cpu_temp_avg /= this.numberOfValuesForAvgTemperature;

            this.avg_temperature = cpu_temp_avg;
            // ----------------------------------------------------------------------------------------------------
        }

        public void CalculateDesiredRPM(int offset)
        {
            if (temperatures.Length == 0)
                return;

            // ----------------------------------------------------------------------------------------------------
            // Ramp calculation

            int vec_value_low = this.avg_temperature / this.degreesStepSize;
            if (vec_value_low >= temperatures.Length)
                vec_value_low = temperatures.Length - 1;
            if (vec_value_low < 0)
                vec_value_low = 0;

            int vec_value_high = (this.avg_temperature / this.degreesStepSize) + 1;
            if (vec_value_high >= temperatures.Length)
                vec_value_high = temperatures.Length - 1;
            if (vec_value_high < 0)
                vec_value_high = 0;

            int temp_low = temperatures[vec_value_low];
            int temp_high = temperatures[vec_value_high];

            int extra_degrees = this.avg_temperature % this.degreesStepSize;
            double diff = (double)extra_degrees / (double)this.degreesStepSize;
            diff *= (double)(temp_high - temp_low);

            this.desired_fan_rpm = temperatures[vec_value_low] + (int)diff;

            // Add offset
            this.desired_fan_rpm += offset;

            // ----------------------------------------------------------------------------------------------------
        }

        public void SetFanRPM(int minimum_fan_rpm)
        {
            double original_last_fan_rpm = Math.Truncate(this.last_fan_rpm * 10.0);

            int definitive_fan_rpm = this.desired_fan_rpm;
            if (this.desired_fan_rpm < minimum_fan_rpm)
                definitive_fan_rpm = minimum_fan_rpm;

            if (definitive_fan_rpm >= this.last_fan_rpm)
            {
                this.last_fan_rpm += this.rpmStepUp;
            }
            else
            {
                if ((this.last_fan_rpm - this.rpmStepDown) > definitive_fan_rpm)
                    this.last_fan_rpm -= this.rpmStepDown;
            }

            if (this.last_fan_rpm > 100)
                this.last_fan_rpm = 100;

            if (this.last_fan_rpm < 0)
                this.last_fan_rpm = 0;

            // Only change fan speed if it has changed
            if(original_last_fan_rpm != Math.Truncate(this.last_fan_rpm * 10.0))
                fanControl?.SetFanSpeed(this.fanNumber, this.last_fan_rpm);
        }

    }
}
