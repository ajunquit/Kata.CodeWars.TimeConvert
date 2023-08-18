namespace Kata.CodeWars.TimeConvert
{
    public class TimeConvert
    {
        private const string NOON = "pm";
        private const string MIDNIGHT = "am";
        private const int HOURS_INDEX = 0;
        private const int MINUTES_INDEX = 1;
        private const int HOURS_12 = 12;

        public static string Convert12hTo24h(int hours, int minutes, string period)
        {
            if (
                IsValid(hours, EnumTime.Hour) &&
                IsValid(minutes, EnumTime.Minute) &&
                IsValid(period, EnumTime.Period))
                return ConvertTime(hours, minutes, period);

            throw new Exception("The parameters doesn't met the validations.");
        }

        public static bool IsValid(int valueTime, EnumTime time)
        {
            bool response = false;

            switch (time)
            {
                case EnumTime.Minute:
                    response = ValidateRangeOfTime(valueTime, 0, 59);
                    break;

                case EnumTime.Hour:
                    response = ValidateRangeOfTime(valueTime, 1, 12);
                    break;
            }

            return response;
        }

        public static bool IsValid(string period, EnumTime time)
        {
            if (period.ToLower().Equals(NOON) || period.ToLower().Equals(MIDNIGHT))
            {
                return true;
            }
            return false;
        }

        public static bool ValidateRangeOfTime(int valueTime, int from, int to)
        {
            if (valueTime >= from && valueTime <= to)
                return true;
            else
                return false;
        }

        private static string ConvertTime(int hours, int minutes, string period)
        {

            int determinateCase = DeterminateCase(hours, minutes, period);
            
            var time = new TimeSpan(hours, minutes, 0);

            string response = string.Empty;

            switch (determinateCase)
            {
                case 1:
                    response = FormatOutput(time);
                    break;
                case 2:
                    time = time.Add(new TimeSpan(HOURS_12, 0, 0));
                    response = FormatOutput(time);
                    break;
                case 3:
                    response = "00" + PadLeftWithZeros(time.Minutes, 2);

                    break;
                case 4:
                    response = "12" + PadLeftWithZeros(time.Minutes, 2);
                    break;

               
            }
            return response;
        }

        private static string FormatOutput(TimeSpan time)
        {
            return $"{PadLeftWithZeros(time.Hours, 2)}{PadLeftWithZeros(time.Minutes, 2)}";
        }

        private static int DeterminateCase(int hours, int minutes, string period)
        {

            if (hours == HOURS_12 && period.Equals(NOON))
            {
                return 4;
            }

            if (hours == HOURS_12 && period.Equals(MIDNIGHT))
            {
                return 3;
            }


            if (period.Equals(NOON))
            {
                return 2;
            }


            if (period.Equals(MIDNIGHT))
            {
                return 1;
            }
            return 0;
        }

        private static string PadLeftWithZeros(int number, int totalWidth)
        {
            return number.ToString().PadLeft(totalWidth, '0');
        }
    }

    public enum EnumTime
    {
        Minute,
        Hour,
        Period
    }
}
