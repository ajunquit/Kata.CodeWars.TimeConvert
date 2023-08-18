namespace Kata.CodeWars.TimeConvert.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Should return 0100 for hour=1, minutes=0, period=am")]
        public void Test1PeriodAM()
        {
            var timeResult = TimeConvert.Convert12hTo24h(1, 0, "am");
            Assert.Equal("0100", timeResult);
        }

        [Fact(DisplayName = "Should return 0215 for hour=2, minutes=15, period=am")]
        public void Test2PeriodAM()
        {
            var timeResult = TimeConvert.Convert12hTo24h(2, 15, "am");
            Assert.Equal("0215", timeResult);
        }

        [Fact(DisplayName = "Should return 1300 for hour=1, minutes=0, period=pm")]
        public void Test1PeriodPM()
        {
            var timeResult = TimeConvert.Convert12hTo24h(1, 0, "pm");
            Assert.Equal("1300", timeResult);
        }

        [Fact(DisplayName = "Should return 1415 for hour=2, minutes=15, period=pm")]
        public void Test2PeriodPM()
        {
            var timeResult = TimeConvert.Convert12hTo24h(2, 15, "pm");
            Assert.Equal("1415", timeResult);
        }

        [Fact(DisplayName = "Should return 2159 for hour=9, minutes=59, period=pm")]
        public void Test3PeriodPM()
        {
            var timeResult = TimeConvert.Convert12hTo24h(9, 59, "pm");
            Assert.Equal("2159", timeResult);
        }

        [Fact(DisplayName = "Should return 0000 for hour=12, minutes=0, period=am")]
        public void Test1EdgeCases()
        {
            var timeResult = TimeConvert.Convert12hTo24h(12, 0, "am");
            Assert.Equal("0000", timeResult);
        }

        [Fact(DisplayName = "Should return 1200 for hour=12, minutes=0, period=pm")]
        public void Test2EdgeCases()
        {
            var timeResult = TimeConvert.Convert12hTo24h(12, 0, "pm");
            Assert.Equal("1200", timeResult);
        }
    }
}