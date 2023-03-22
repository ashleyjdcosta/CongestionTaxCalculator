using System.Collections.Generic;


namespace congestion.calculator.Models
{
    public class TollFee
    {
        public TollFee(string start, string end, int fee)
        {
            this.start = start;
            this.end = end;
            this.fee = fee;
        }

        public string start { get; set; }
        public string end { get; set; }
        public int fee { get; set; }
    }

    public class CongestionData
    {
        public string city { get; set; }
        public int max_daily_fee { get; set; }
        public List<string> toll_free_vehicles { get; set; }
        public List<string> toll_free_dates { get; set; }
        public List<TollFee> toll_fees { get; set; }
    }
}
