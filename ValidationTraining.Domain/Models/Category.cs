using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTraining.Domain.Entities;
using ValidationTraining.Domain.Validations;

namespace ValidationTraining.Domain.Models
{
    public class Category : EntityBase
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public List<Product> Products { get; private set; }

        public Category (string name, bool isActive)
        {
            ValidateName(name);
            Name = name;
            IsActive = isActive;
        }

        public void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                DomainExceptionValidation.ExceptionHandler(true, "Category name is required!");
            if (name.Length > 15)
                DomainExceptionValidation.ExceptionHandler(true, "Category name cannot be longer than 15 characters");
        }
    }
}
