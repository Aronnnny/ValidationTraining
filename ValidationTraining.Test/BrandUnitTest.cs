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
    public class BrandUnitTest
    {
        [Fact]
        public void WhenName_IsEmptyOrNullDomain_ShouldReturnDomainException()
        {
            Action brand = () => new Brand("", "testImage");

            brand.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }

        [Fact]
        public void WhenImage_IsEmptyOrNullDomain_ShouldReturnDomainException()
        {
            Action brand = () => new Brand("test", "");

            brand.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Image. Image is Required!");
        }

        [Fact]
        public void WhenName_LenghtMoreThanDomain_ShouldReturnDomainException()
        {
            Action brand = () => new Brand("BrandTestNameButNowThisNameIsLongerThanThirdyCharacters", "testImage");

            brand.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Name cannot be longer than 30 characters");
        }
    }
}