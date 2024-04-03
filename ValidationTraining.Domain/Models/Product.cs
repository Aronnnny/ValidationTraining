using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTraining.Domain.Entities;
using ValidationTraining.Domain.Validations;

namespace ValidationTraining.Domain.Models
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        public string Brand { get; private set; }

        public Product(string name, string description, int quantity, double price, string brand) 
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
            Brand = brand;
        }
        
        public void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(Name))
                DomainExceptionValidation.ExceptionHandler(true, "Product must have a name.");
            if (name.Length > 30)
                DomainExceptionValidation.ExceptionHandler(true, "Product name cannot be longer than 30 characters");
        }

    }
}
