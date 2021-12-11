using System;
using System.Collections.Generic;

namespace OptimizedClevoFan
{
    public class Fan
    {
        private IFanControl fanControl;
        private int fanNumber;
        private int[] temps;


        private Queue<int> last_temperatures;
        private int avg_temperature;

        private int desired_fan_rpm;
        private double last_fan_rpm;

        // PARAMS
        private int NUMBER_OF_COUNTS = 4;
        private double INCREMENT_STEP = 2.5;
        private double DECREMENT_STEP = 0.1;
        private int STEP_SIZE_IN_DEGREE_CELSIUS = 5;

        public Fan(IFanControl fan, int fanNumber)
        {
            this.fanControl = fan;
            this.fanNumber = fanNumber;

            this.avg_temperature = 40;
            this.last_temperatures = new Queue<int>();
            this.desired_fan_rpm = 40;
            this.last_fan_rpm = (double)this.desired_fan_rpm;
        }
        public int GetFanNumber() { return fanNumber; }

        public int GetDesiredRPM() { return this.desired_fan_rpm; }

        public double GetLastRPM() { return this.last_fan_rpm; }

        public int GetTemperature() { return this.avg_temperature; }

        public void LoadTemps(int[] temps)
        {
            this.temps = temps;
        }

        public void UpdateAvgTemperature()
        {
            int instant_temperature = (int)fanControl?.GetECData(this.fanNumber).Remote;

            // ----------------------------------------------------------------------------------------------------
            // Get average temperature for the last steps

            last_temperatures.Enqueue(instant_temperature);
            if (last_temperatures.Count > this.NUMBER_OF_COUNTS)
                last_temperatures.Dequeue();

            int cpu_temp_avg = 0;
            foreach (int temp in last_temperatures)
                cpu_temp_avg += temp;
            cpu_temp_avg /= this.NUMBER_OF_COUNTS;

            this.avg_temperature = cpu_temp_avg;
            // ----------------------------------------------------------------------------------------------------
        }

        public void CalculateDesiredRPM(int offset)
        {
            if (temps.Length == 0)
                return;

            // ----------------------------------------------------------------------------------------------------
            // Ramp calculation

            int vec_value_low = this.avg_temperature / this.STEP_SIZE_IN_DEGREE_CELSIUS;
            if (vec_value_low >= temps.Length)
                vec_value_low = temps.Length - 1;
            if (vec_value_low < 0)
                vec_value_low = 0;

            int vec_value_high = (this.avg_temperature / this.STEP_SIZE_IN_DEGREE_CELSIUS) + 1;
            if (vec_value_high >= temps.Length)
                vec_value_high = temps.Length - 1;
            if (vec_value_high < 0)
                vec_value_high = 0;

            int temp_low = temps[vec_value_low];
            int temp_high = temps[vec_value_high];

            int extra_degrees = this.avg_temperature % this.STEP_SIZE_IN_DEGREE_CELSIUS;
            double diff = (double)extra_degrees / (double)this.STEP_SIZE_IN_DEGREE_CELSIUS;
            diff *= (double)(temp_high - temp_low);

            this.desired_fan_rpm = temps[vec_value_low] + (int)diff;

            // Add offset
            this.desired_fan_rpm += offset;

            // ----------------------------------------------------------------------------------------------------
        }

        public void SetFanRPM(int minimum_fan_rpm)
        {
            int definitive_fan_rpm = this.desired_fan_rpm;
            if (this.desired_fan_rpm < minimum_fan_rpm)
                definitive_fan_rpm = minimum_fan_rpm;

            if (definitive_fan_rpm >= this.last_fan_rpm)
            {
                this.last_fan_rpm += this.INCREMENT_STEP;
            }
            else
            {
                if ((this.last_fan_rpm - this.DECREMENT_STEP) > definitive_fan_rpm)
                    this.last_fan_rpm -= this.DECREMENT_STEP;
            }

            if (this.last_fan_rpm > 100)
                this.last_fan_rpm = 100;

            if (this.last_fan_rpm < 0)
                this.last_fan_rpm = 0;


            fanControl?.SetFanSpeed(this.fanNumber, (int)this.last_fan_rpm);
        }

    }
}
