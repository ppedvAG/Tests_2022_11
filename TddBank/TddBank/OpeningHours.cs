namespace TddBank
{
    public class OpeningHours
    {
        public bool IsOpen(DateTime dt)
        {
            var start = new TimeSpan(10, 30, 0);
            var ende = new TimeSpan(19, 00, 0);
            var endeSa = new TimeSpan(14, 00, 0);


            //häßlich aber geht
            if (dt.DayOfWeek == DayOfWeek.Sunday) return false;
            else if (dt.DayOfWeek == DayOfWeek.Saturday && dt.TimeOfDay >= start && dt.TimeOfDay < endeSa)
                return true;
            else if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday && dt.TimeOfDay >= start && dt.TimeOfDay < ende)
                return true;

            return false;
        }

        //public bool IsWeekend() => IsWeekend(DateTime.Now);

        //public bool IsWeekend(DateTime dt)
        //{
        //    if (dt.DayOfWeek == DayOfWeek.Saturday ||
        //        dt.DayOfWeek == DayOfWeek.Sunday)
        //        return true;
        //    else
        //        return false;
        //}

        public bool IsWeekend()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday ||
                DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                return true;
            else
                return false;
        }

        public void ReaderConfFile()
        {
            using (var sr = new StreamReader(@"b:\\textst.txt"))
            {
                var txt = sr.ReadToEnd();

                if (txt.Contains("Bier"))
                    Console.WriteLine(txt);
                else
                    Console.WriteLine(":-(");
            }

        }
    }
}
