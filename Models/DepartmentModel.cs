//Modelo de datos Department
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace TestCarlosCajasAPI.Models
{
    public class DepartmentModel
    {
        [Key]
        [JsonConverter(typeof(IntToStringConverter))]
        public int Id { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public bool status { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        [JsonConverter(typeof(IntToStringConverter))]
        public Int32 id_enterprise { get; set; }
    }
}
