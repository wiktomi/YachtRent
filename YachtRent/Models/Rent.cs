﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YachtRent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Rent
    {
        public int Id { get; set; }
        [DisplayName("Nazwa jachtu")]
        public string YachtName { get; set; }
        [DisplayName("Imię Klienta")]
        public string CustomerName { get; set; }
        [DisplayName("Opłata")]
        public Nullable<int> Fee { get; set; }
        [DisplayName("Data startu rezerwacji")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [DisplayName("Data końca rezerwacji")]
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}
