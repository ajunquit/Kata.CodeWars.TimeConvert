namespace Kata.CodeWars.TimeConvert
{
    public class TimeConvert
    {
        private const string NOON = "pm";
        private const string MIDNIGHT = "am";
        private const int HOURS_12 = 12;
        private const int TOTAL_WIDTH_ZERO = 2;
        private const char ZERO_CHARACTER = '0';


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

            EnumCase determinateCase = DeterminateCase(hours, minutes, period);
            
            var time = new TimeSpan(hours, minutes, 0);

            string response = string.Empty;

            switch (determinateCase)
            {
                case EnumCase.One:
                    response = FormatOutput(time);
                    break;
                case EnumCase.Two:
                    time = time.Add(new TimeSpan(HOURS_12, 0, 0));
                    response = FormatOutput(time);
                    break;
                case EnumCase.Three:
                    response = "00" + PadLeftWithZeros(time.Minutes, TOTAL_WIDTH_ZERO);

                    break;
                case EnumCase.Four:
                    response = "12" + PadLeftWithZeros(time.Minutes, TOTAL_WIDTH_ZERO);
                    break;
            }
            return response;
        }

        private static string FormatOutput(TimeSpan time)
        {
            return $"{PadLeftWithZeros(time.Hours, 2)}{PadLeftWithZeros(time.Minutes, 2)}";
        }

        private static EnumCase DeterminateCase(int hours, int minutes, string period)
        {

            if (hours == HOURS_12 && period.Equals(NOON))
                return EnumCase.Four;

            if (hours == HOURS_12 && period.Equals(MIDNIGHT))
                return EnumCase.Three;

            if (period.Equals(NOON))
                return EnumCase.Two;

            if (period.Equals(MIDNIGHT))
                return EnumCase.One;

            throw new Exception("Undeterminated case.");
        }

        private static string PadLeftWithZeros(int number, int totalWidth)
        {
            return number.ToString().PadLeft(totalWidth, ZERO_CHARACTER);
        }
    }

    public enum EnumTime
    {
        Minute,
        Hour,
        Period
    }

    public enum EnumCase
    {
        One, // When the period=am
        Two, // When the period=pm
        Three, // When the hours=12 and period=am
        Four // When the hours=12 and period=pm
    }

}
