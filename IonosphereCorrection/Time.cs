using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonosphereCorrection
{
    class Time
    {
        private int _year;
        private int _month;
        private int _day;
        private int _hour;
        private int _minute;
        private double _second;

        public int Year
        {
            get
            {
                return _year;
            }
        }
        public int Month
        {
            get
            {
                return _month;
            }
        }
        public int Day
        {
            get
            {
                return _day;
            }
        }
        public int Hour
        {
            get
            {
                return _hour;
            }
        } 
        public int Minute
        {
            get
            {
                return _minute;
            }
        }

        public double Second
        {
            get
            {
                return _second;
            }
        }

        public Time (int year , int month , int day , int hour , int minute , double second)
        {
            _year = year;
            _month = month;
            _day = day;
            _hour = hour;
            _minute = minute;
            _second = second;
        }

        public double SecondOfDay()
        {
            return Hour * 3600.0 + Minute * 60.0 + Second;
        }

    }
}
