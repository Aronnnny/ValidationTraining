using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTraining.Domain.Models;
using ValidationTraining.Domain.Validations;
using Xunit;

namespace ValidationTraining.Test
{
    public class ProductUnitTest
    {
        [Fact]
        public void WhenName_IsEmptyOrNullDomain_ShouldReturnDomainException()
        {
            Action product = () => new Product("", "testDescription", 1, 1, Guid.NewGuid(), Guid.NewGuid());

            product.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Product must have a name.");
        }

        [Fact]
        public void WhenName_LenghtMoreThanDomain_ShouldReturnDomainException()
        {
            Action product = () => new Product("ProductNameButNowThisNameIsLongerThanThirtyCharacters", "testDescription", 1, 1, Guid.NewGuid(), Guid.NewGuid());

            product.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Product name cannot be longer than 30 characters.");
        }

        [Fact]
        public void WhenDescription_IsEmptyOrNullDomain_ShouldReturnDomainException()
        {
            Action product = () => new Product("testName", "", 1, 1, Guid.NewGuid(), Guid.NewGuid());

            product.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Product must have a description.");
        }

        [Fact]
        public void WhenQuantity_IsLessThanDomain_ShouldReturnDomainException()
        {
            Action product = () => new Product("testName", "testDescription", -1, 1, Guid.NewGuid(), Guid.NewGuid());

            product.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Product quantity cannot be negative.");
        }

        [Fact]
        public void WhenPrice_IsLessThanDomain_ShouldReturnDomainException()
        {
            Action product = () => new Product ("testName", "testDescription", 1, -1, Guid.NewGuid(), Guid.NewGuid());

            product.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Product price cannot be less than zero.");
        }

        [Fact]
        public void WhenBrand_IsNullOrEmpty_ShouldReturnDomainException()
        {
            Action product = () => new Product("testName", "testDescription", 1, 1, Guid.Empty, Guid.NewGuid());

            product.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Product must have a brand.");
        }

        [Fact]
        public void WhenCategory_IsNullOrEmpty_ShouldReturnDomainException()
        {
            Action product = () => new Product("testName", "testDescription", 1, 1, Guid.NewGuid(), Guid.Empty);

            product.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Product must have a category.");
        }

    }
}