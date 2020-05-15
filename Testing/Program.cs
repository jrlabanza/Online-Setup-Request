using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var cal = Helpers.ONCalendar.GetByDate(DateTime.Now);
            var datestring = DateTime.Now;
            var getworkweek = Helpers.ONCalendar.GetWWOnlyByDate(DateTime.Now);
            var getnewCal = Helpers.ONCalendar.GetFirstDay(getworkweek, datestring.Year);
            var getbyYear = Helpers.ONCalendar.GetByYear(2019);
            var lastworkweek = getworkweek - 1;
            var getLastWeekNewCal = Helpers.ONCalendar.GetByWW(lastworkweek, datestring.Year);
            //foreach (var data in getnewCal)
            //{
            //    var temp = data.Value;
            //    var ww = data.Key;

            //    Console.WriteLine(temp["start"].ToString());
            //}
            //foreach (var newdat in getbyYear) {
            //    Console.WriteLine(newdat);
            //}
            foreach (var test in getLastWeekNewCal) {
                Console.WriteLine(test);
            }
            
            Console.ReadLine();
        }
    }
}
