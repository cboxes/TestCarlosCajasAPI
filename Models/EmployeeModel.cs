//Modelo de datos Employee
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestCarlosCajasAPI.Models
{
    public class EmployeeModel
    {
        [Key]
        [JsonConverter(typeof(IntToStringConverter))]
        public int Id { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public Boolean status { get; set; }
        [JsonConverter(typeof(IntToStringConverter))]
        public Int32 age { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string surname { get; set; }
    }
}
