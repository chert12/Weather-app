using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_demo.Data.DatabaseModels
{
    [Table("Cities")]
    public class CityDataModel
    {
        [PrimaryKey, AutoIncrement, NotNull, Unique, Column("ID")]
        public int Id { get; set; }
        [Column("CITY_ID")]
        public int CityId { get; set; }
        [Column("CITY_NAME")]
        public string City { get; set; }
        [Column("COUNTRY")]
        public string Country { get; set; }
    }
}
