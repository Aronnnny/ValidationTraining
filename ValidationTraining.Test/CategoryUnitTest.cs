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
    public class CategoryUnitTest
    {
        [Fact]
        public void WhenName_IsNullOrEmptyDomain_ShouldReturnDomainException()
        {
            Action category = () => new Category("", true);
         
            category.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Category name is required!");
        }
    }
}