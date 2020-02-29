using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0}  é obrigatório")]
        [StringLength(60,MinimumLength =3, ErrorMessage ="{0} deve ser entre {2} e {1}")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}  é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}  é obrigatório")]

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0}  é obrigatório")]
        [Display(Name = "Salário Base")]
        [Range(100.0, 50000.0, ErrorMessage ="{0} deve ser entre {1} e {2}")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public Double BaseSalary { get; set; }


        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
