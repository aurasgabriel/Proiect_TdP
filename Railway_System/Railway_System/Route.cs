//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Railway_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class Route
    {
        public int Id { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Class { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Seat { get; set; }
        public string TrainCode { get; set; }
    }
}
