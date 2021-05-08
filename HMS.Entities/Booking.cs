using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public class Booking
    {
        public int ID { get; set; }
        public int AccomodationID { get; set; }
        public Accomodation Accodomation { get; set; }

        public DateTime dateTime { get; set; }
        /// <summary>
        /// No of stay nights
        /// </summary>
        public int Duration { get; set; }
    }
}
