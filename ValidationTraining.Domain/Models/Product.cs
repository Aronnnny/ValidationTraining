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
        public Guid BrandId { get; private set; }
        public Guid CategoryId { get; private set; }

        public Product(string name, string description, int quantity, double price, Guid brandId, Guid categoryId) 
        {
            ValidateName(name);
            ValidateDescription(description);
            ValidateQuantity(quantity);
            ValidatePrice(price);
            ValidateBrand(brandId);
            ValidateCategory(categoryId);

            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
            BrandId = brandId;
            CategoryId = categoryId;
        }
        
        public void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                DomainExceptionValidation.ExceptionHandler(true, "Product must have a name.");
            if (name.Length > 30)
                DomainExceptionValidation.ExceptionHandler(true, "Product name cannot be longer than 30 characters.");
        }

        public void ValidateDescription(string description) 
        {
            if (string.IsNullOrEmpty(description))
                DomainExceptionValidation.ExceptionHandler(true, "Product must have a description.");
            if (description.Length > 300)
                DomainExceptionValidation.ExceptionHandler(true, "Description cannot be longer than 300 characters.");
        }

        public void ValidateQuantity(int quantity)
        {
            DomainExceptionValidation.ExceptionHandler(quantity < 0, "Product quantity cannot be negative.");
        }

        public void ValidatePrice(double price)
        {
            DomainExceptionValidation.ExceptionHandler(price < 0, "Product price cannot be less than zero.");
        }

        public void ValidateBrand(Guid brandId)
        {
            DomainExceptionValidation.ExceptionHandler(brandId == Guid.Empty, "Product must have a brand.");
        }
        public void ValidateCategory(Guid categoryId)
        {
            DomainExceptionValidation.ExceptionHandler(categoryId == Guid.Empty, "Product must have a category.");
        }
    }
}
