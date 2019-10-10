using System;

namespace lab_just_Do_It_17_enum_With_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class TestEnums
    {
        enum DaysOfWeek
        {
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 3,
            Friday = 4,
            Saturday = 5,
            Sunday = 6
        }
        enum MonthsOfYear
        {
            January = 0,
            February = 1,
            March = 2,
            April = 3,
            May = 4,
            June = 5,
            July = 6,
            August = 7,
            September = 8,
            October = 9,
            November = 10,
            December = 11
        }
        public static (string, string)GetDayMonth(int day, int month)
        {
            return ((string)Enum.GetValues(typeof(DaysOfWeek)).GetValue(day), (string)Enum.GetValues(typeof(MonthsOfYear)).GetValue(month)); // = Tuple, a custom anonymous data type without a name 
        }
    }
}
