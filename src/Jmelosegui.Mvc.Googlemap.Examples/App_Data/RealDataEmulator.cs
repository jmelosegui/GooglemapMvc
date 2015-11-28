namespace Jmelosegui.Mvc.GoogleMap.Examples.App_Data
{
    using System;
    using System.Collections.Generic;

    internal class RealDataEmulator
    {
        private readonly RangeList rangeList = new RangeList();
        private readonly Random rnd = new Random();
        private readonly Random rndDirection = new Random();
        private double direction;
        private double max;
        private double maxDecrement;
        private double maxIncrement;
        private double min;
        private double value;

        public RealDataEmulator(
            double minValue,
            double maxValue,
            double currentValue,
            double maxIncrement,
            double maxDecrement)
        {
            this.Initialzation(
                minValue,
                maxValue,
                currentValue,
                maxIncrement,
                maxDecrement);
        }

        public RealDataEmulator(double minValue, double maxValue, double currentValue)
        {
            double increment = (maxValue - minValue) / 10d;
            this.Initialzation(minValue, maxValue, currentValue, increment, increment);
        }

        public RealDataEmulator(double minValue, double maxValue)
        {
            this.Initialzation(minValue, maxValue, minValue, (maxValue - minValue) / 10d, (maxValue - minValue) / 10d);
        }

        public RealDataEmulator()
        {
            this.Initialzation(0d, 100d, 0d, 10d, 10d);
        }

        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public double GetNextValue()
        {
            this.SetDirection();
            double stepValue = this.GetNormalizedValue();

            double nextValue = this.value + stepValue;

            if (nextValue > this.max)
            {
                nextValue = this.max - Math.Abs(stepValue);
            }

            if (nextValue < this.min)
            {
                nextValue = this.min + Math.Abs(stepValue);
            }

            this.value = nextValue;

            if (this.value > this.max)
            {
                this.value = this.max;
            }

            if (this.value < this.min)
            {
                this.value = this.min;
            }

            return this.value;
        }

        public void AddRange(double min, double max, double directionPriority, double maxIncrement, double maxDecrement)
        {
            this.rangeList.AddRange(min, max, directionPriority, maxIncrement, maxDecrement);
        }

        public void AddRange(double min, double max, double directionPriority)
        {
            this.AddRange(min, max, directionPriority, -1, -1);
        }

        private void Initialzation(
            double minValue,
            double maxValue,
            double currentValue,
            double maxIncrement,
            double maxDecrement)
        {
            this.min = minValue;
            this.max = maxValue;

            this.value = currentValue;
            this.maxIncrement = maxIncrement;
            this.maxDecrement = maxDecrement;

            this.direction = 1d;
        }

        private void SetDirection()
        {
            double range = this.rangeList.GetDirectionPriorityValue(this.value);
            double directionValue = this.rndDirection.NextDouble();
            this.direction = 1d;

            if (directionValue > 0.5 - (range / 2)
                && directionValue < 0.5 + (range / 2))
            {
                this.direction = -this.direction;
            }
        }

        private double GetNormalizedValue()
        {
            double nextValue = this.rnd.NextDouble();
            if (this.direction > 0)
            {
                nextValue *= this.rangeList.MaxIncrement < 0 ? this.maxIncrement : this.rangeList.MaxIncrement;
            }
            else
            {
                nextValue *= this.rangeList.MaxDecrement < 0 ? this.maxDecrement : this.rangeList.MaxDecrement;
            }

            return this.direction * nextValue;
        }

        private class RangeList
        {
            private readonly List<Range> rangeList = new List<Range>();

            public double MaxDecrement { get; private set; }

            public double MaxIncrement { get; private set; }

            public double GetDirectionPriorityValue(double value)
            {
                const double directionPriority = 0.5;
                this.MaxIncrement = -1;
                this.MaxDecrement = -1;

                foreach (Range range in this.rangeList)
                {
                    double newPriority = range.GetDirectionPriorityValue(value);
                    if (newPriority != 0)
                    {
                        this.MaxIncrement = range.MaxIncrement;
                        this.MaxDecrement = range.MaxDecrement;
                        return newPriority;
                    }
                }

                return directionPriority;
            }

            public void AddRange(double min, double max, double directionPriority, double maxIncrement, double maxDecrement)
            {
                this.rangeList.Add(new Range(min, max, directionPriority, maxIncrement, maxDecrement));
            }

            private class Range
            {
                private readonly double directionPriority;
                private readonly double max;
                private readonly double min;

                public Range(double min, double max, double directionPriority, double maxIncrement, double maxDecrement)
                {
                    this.min = min;
                    this.max = max;
                    this.directionPriority = directionPriority;

                    this.MaxIncrement = maxIncrement;
                    this.MaxDecrement = maxDecrement;
                }

                public double MaxIncrement { get; }

                public double MaxDecrement { get; }

                public double GetDirectionPriorityValue(double value)
                {
                    return !this.IsInRange(value) ? 0d : this.directionPriority;
                }

                private bool IsInRange(double value)
                {
                    return value >= this.min && value <= this.max;
                }
            }
        }
    }
}