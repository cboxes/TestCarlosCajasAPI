//Modelo de datos Department- Employee
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCarlosCajasAPI.Models
{
    public class Department_EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public Boolean status { get; set; }
        public int id_department { get; set; }
        public int id_employees { get; set; }
    }
}
