using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YachtRent.Models
{
    [MetadataType(typeof(YachtsMetaData))]
    public partial class Yachts
    {
        public class YachtsMetaData
        {
            [DisplayName("Nazwa Jachtu")]
            public string YachtName { get; set; }
            [DisplayName("Pojemność (osób)")]
            public Nullable<int> Capacity { get; set; }
            [DisplayName("Ilość kabin")]
            public Nullable<int> Cabins { get; set; }
            [DisplayName("Ilość łóżek")]
            public Nullable<int> Beds { get; set; }
            [DisplayName("Liczba Pryszniców")]
            public Nullable<int> Showers { get; set; }
            [DisplayName("Data produkcji jachtu")]
            public Nullable<int> ProductionDate { get; set; }
            [DisplayName("Długość jachtu")]
            public Nullable<int> Length { get; set; }
            [DisplayName("Cena za dzień")]
            public Nullable<int> Price { get; set; }
            [DisplayName("Dostepność")]
            public string Avaliable { get; set; }
        }
    }
}