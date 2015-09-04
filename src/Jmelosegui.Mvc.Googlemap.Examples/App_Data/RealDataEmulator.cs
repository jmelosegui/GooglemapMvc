using System;
using System.Collections.Generic;

namespace Jmelosegui.Mvc.GoogleMap.Examples.App_Data
{
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

        #region Constructors

        public RealDataEmulator(double minValue, double maxValue,
            double currentValue,
            double maxIncrement, double maxDecrement)
        {
            Initialzation(minValue, maxValue,
                currentValue,
                maxIncrement, maxDecrement);
        }

        public RealDataEmulator(double minValue, double maxValue, double currentValue)
        {
            double increment = (maxValue - minValue)/10d;
            Initialzation(minValue, maxValue, currentValue, increment, increment);
        }

        public RealDataEmulator(double minValue, double maxValue)
        {
            Initialzation(minValue, maxValue, minValue,
                (maxValue - minValue)/10d,
                (maxValue - minValue)/10d);
        }

        public RealDataEmulator()
        {
            Initialzation(0d, 100d, 0d, 10d, 10d);
        }

        private void Initialzation(double minValue, double maxValue,
            double currentValue,
            double maxIncrement,
            double maxDecrement)
        {
            min = minValue;
            max = maxValue;

            value = currentValue;
            this.maxIncrement = maxIncrement;
            this.maxDecrement = maxDecrement;

            direction = 1d;
        }

        #endregion

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        private void SetDirection()
        {
            double range = rangeList.GetDirectionPriorityValue(value);
            double directionValue = rndDirection.NextDouble();
            direction = 1d;

            if (directionValue > 0.5 - range/2
                && directionValue < 0.5 + range/2)
                direction = -direction;
        }

        private double GetNormalizedValue()
        {
            double nextValue = rnd.NextDouble();
            if (direction > 0)
            {
                nextValue *= rangeList.MaxIncrement < 0 ? maxIncrement : rangeList.MaxIncrement;
            }
            else
            {
                nextValue *= rangeList.MaxDecrement < 0 ? maxDecrement : rangeList.MaxDecrement;
            }

            return direction*nextValue;
        }

        public double GetNextValue()
        {
            SetDirection();
            double stepValue = GetNormalizedValue();

            double nextValue = value + stepValue;

            if (nextValue > max)
                nextValue = max - Math.Abs(stepValue);

            if (nextValue < min)
                nextValue = min + Math.Abs(stepValue);

            value = nextValue;

            if (value > max)
                value = max;

            if (value < min)
                value = min;

            return value;
        }

        public void AddRange(double min, double max, double directionPriority,
            double maxIncrement, double maxDecrement)
        {
            rangeList.AddRange(min, max, directionPriority, maxIncrement, maxDecrement);
        }

        public void AddRange(double min, double max, double directionPriority)
        {
            AddRange(min, max, directionPriority, -1, -1);
        }

        private class RangeList
        {
            private readonly List<Range> _rangeList = new List<Range>();
            public double MaxDecrement;
            public double MaxIncrement;

            public double GetDirectionPriorityValue(double value)
            {
                const double directionPriority = 0.5;
                MaxIncrement = -1;
                MaxDecrement = -1;

                foreach (Range range in _rangeList)
                {
                    double newPriority = range.GetDirectionPriorityValue(value);
                    if (newPriority != 0)
                    {
                        MaxIncrement = range.MaxIncrement;
                        MaxDecrement = range.MaxDecrement;
                        return newPriority;
                    }
                }

                return directionPriority;
            }

            public void AddRange(double min, double max, double directionPriority,
                double maxIncrement, double maxDecrement)
            {
                _rangeList.Add(new Range(min, max, directionPriority, maxIncrement, maxDecrement));
            }

            private class Range
            {
                public readonly double MaxDecrement;
                public readonly double MaxIncrement;
                private readonly double _directionPriority;
                private readonly double _max;
                private readonly double _min;

                public Range(double min, double max, double directionPriority,
                    double maxIncrement, double maxDecrement)
                {
                    _min = min;
                    _max = max;
                    _directionPriority = directionPriority;

                    MaxIncrement = maxIncrement;
                    MaxDecrement = maxDecrement;
                }

                public double GetDirectionPriorityValue(double value)
                {
                    return !IsInRange(value) ? 0d : _directionPriority;
                }

                private bool IsInRange(double value)
                {
                    return value >= _min && value <= _max;
                }
            }
        }
    }
}