using System;
using System.Text;

namespace WpfApp6.MVVM.Model
{
    public class CityTime
    {
        public string abbreviation { get; set; }
        public string client_ip { get; set; }
        public string datetime { get; set; }
        public int day_of_week { get; set; }
        public int day_of_year { get; set; }
        public bool dst { get; set; }
        public object dst_from { get; set; }
        public int dst_offset { get; set; }
        public object dst_until { get; set; }
        public int raw_offset { get; set; }
        public string timezone { get; set; }
        public int unixtime { get; set; }
        public DateTime utc_datetime { get; set; }
        public string utc_offset { get; set; }
        public int week_number { get; set; }

        public override string ToString()
        {
            string date = GetDate();
            string time = GetTime();
            return date + " " + time;
        }

        private string GetTime()
        {
            StringBuilder strBuilder = new StringBuilder();
            int index = datetime.IndexOf('T');
            int index2 = datetime.IndexOf('.');
            
            for(;index < index2;index++)
            {
                strBuilder.Append(datetime[index]);
            }
            
            return strBuilder.ToString();
        }

        private string GetDate()
        {
            return datetime.Remove(datetime.IndexOf('T'), datetime.Length - datetime.IndexOf('T'));
        }
    }

}