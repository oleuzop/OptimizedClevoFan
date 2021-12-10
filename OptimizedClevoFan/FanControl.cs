using System;
using System.Collections.Generic;

namespace OptimizedClevoFan
{
    public class FanControl
    {
        private IFanControl fan;
        private int fanNumber;
        private int[] temps;

        private Queue<int> last_temps;
        private double last_temp;
        private int cpu_temp;
        private int desired_fan_rpm;

        private int NUMBER_OF_COUNTS = 4;
        private double DECREMENT_STEP = 0.1;
        private int DEGREE_STEPS = 5;

        public FanControl(IFanControl fan, int fanNumber)
        {
            this.fan = fan;
            this.fanNumber = fanNumber;
            this.last_temps = new Queue<int>();

            this.desired_fan_rpm = 50;
            this.last_temp = 40.0;
            this.cpu_temp = (int)this.last_temp;
        }

        public void LoadTemps(int[] temps)
        {
            this.temps = temps;
        }

        public void UpdateTemp()
        {
            int cpu_instant_temp = (int)fan?.GetECData(this.fanNumber).Remote;

            // ----------------------------------------------------------------------------------------------------
            // Get average temperature for the last steps

            last_temps.Enqueue(cpu_instant_temp);
            if (last_temps.Count > this.NUMBER_OF_COUNTS)
                last_temps.Dequeue();

            int cpu_temp_avg = 0;
            foreach (int temp in last_temps)
                cpu_temp_avg += temp;
            cpu_temp_avg /= this.NUMBER_OF_COUNTS;

            // ----------------------------------------------------------------------------------------------------
            // Decrease slow, increase instantly

            if (cpu_temp_avg >= this.last_temp)
                this.last_temp = cpu_temp_avg;
            else
                if ((this.last_temp - this.DECREMENT_STEP) > cpu_temp_avg)
                this.last_temp -= this.DECREMENT_STEP;

            this.cpu_temp = (int)this.last_temp;

            // ----------------------------------------------------------------------------------------------------
        }

        public void CalculateFanRPM(int offset)
        {
            if (temps.Length == 0)
                return;

            // ----------------------------------------------------------------------------------------------------
            // Ramp calculation

            int vec_value_low = this.cpu_temp / this.DEGREE_STEPS;
            if (vec_value_low >= temps.Length)
                vec_value_low = temps.Length - 1;
            if (vec_value_low < 0)
                vec_value_low = 0;

            int vec_value_high = (this.cpu_temp / this.DEGREE_STEPS) + 1;
            if (vec_value_high >= temps.Length)
                vec_value_high = temps.Length - 1;
            if (vec_value_high < 0)
                vec_value_high = 0;

            int temp_low = temps[vec_value_low];
            int temp_high = temps[vec_value_high];

            int extra_degrees = this.cpu_temp % this.DEGREE_STEPS;
            double diff = (double)extra_degrees / (double)this.DEGREE_STEPS;
            diff *= (double)(temp_high - temp_low);

            this.desired_fan_rpm = temps[vec_value_low] + (int)diff;

            // OFFSET
            this.desired_fan_rpm += offset;

            // ----------------------------------------------------------------------------------------------------
        }

        public int GetCalculatedFanRPM()
        {
            return this.desired_fan_rpm;
        }

        public void SetFanRPM(int minimum_fan_rpm)
        {
            int definitive_fan_rpm = this.desired_fan_rpm;
            if (this.desired_fan_rpm < minimum_fan_rpm)
                definitive_fan_rpm = minimum_fan_rpm;

            fan?.SetFanSpeed(this.fanNumber, definitive_fan_rpm);
            Console.WriteLine("Remote:\t" + this.cpu_temp + ",\tFan%:\t" + definitive_fan_rpm);
        }

    }
}
