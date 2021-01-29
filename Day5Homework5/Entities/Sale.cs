using System;
using System.Collections.Generic;
using System.Text;

namespace Day5Homework5.Entities
{
    class Sale
    {
        public DateTime SaleTime { get; set; }
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public string GameName { get; set; }
        public string Explanation { get; set; }
    }
}
