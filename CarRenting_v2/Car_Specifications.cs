//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRenting_v2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car_Specifications
    {
        public int ID_Car { get; set; }
        public int Consumption { get; set; }
        public int Horse_Power { get; set; }
        public int Tank_Capacity { get; set; }
        public int Tachometer { get; set; }
        public int Max_Speed { get; set; }
        public int Number_of_seats { get; set; }
        public int Rental_price { get; set; }
        public System.DateTime Production_date { get; set; }
        public string Color { get; set; }
        public string License_plate { get; set; }
        public string Emission_standard { get; set; }
    
        public virtual Car Car { get; set; }
    }
}