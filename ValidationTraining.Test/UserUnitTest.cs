using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTraining.Domain.Models;
using ValidationTraining.Domain.Validations;

namespace ValidationTraining.Test
{
    public class UserUnitTest
    {
        [Fact]
        public void WhenName_IsNullOrEmpty_ShoulReturnDomainException()
        {
            Action user = () => new User("", "testEmail", "testPassword", "testPhoneNumber", "testCpf", DateTime.Now);

            user.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }

        [Fact]
        public void WhenName_IsLongerThanDomain_ShoulReturnDomainException()
        {
            Action user = () => new User("UserTestNameButNowThisNameIsLongerThanThirdyCharacters", "testEmail", "testPassword", "testPhoneNumber", "testCpf", DateTime.Now);

            user.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Too long name.");
        }

        [Fact]
        public void WhenEmail_IsNullOrEmpty_ShoulReturnDomainException()
        {
            Action user = () => new User("testUser", "", "testPassword", "testPhoneNumber", "testCpf", DateTime.Now);

            user.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Email. Email is required!");
        }

        [Fact]
        public void WhenPassword_IsNullOrEmpty_ShoulReturnDomainException()
        {
            Action user = () => new User("testUser", "testEmail", "", "testPhoneNumber", "testCpf", DateTime.Now);

            user.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Password. Password is required!");
        }

        [Fact]
        public void WhenPhoneNumber_IsNullOrEmpty_ShoulReturnDomainException()
        {
            Action user = () => new User("testUser", "testEmail", "testPassword", "", "testCpf", DateTime.Now);

            user.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Phone Number. Phone Number is required!");
        }

        [Fact]
        public void WhenPhoneNumber_IsLongerThanDomain_ShoulReturnDomainException()
        {
            Action user = () => new User("testUser", "testEmail", "testPassword", "9999999999999999", "testCpf", DateTime.Now);

            user.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Phone number cannot be longer than 15 characters!");
        }

        [Fact]
        public void WhenCpf_IsNullOrEmpty_ShoulReturnDomainException()
        {
            Action user = () => new User("testUser", "testEmail", "testPhoneNumber", "testPhoneNumber", "", DateTime.Now);

            user.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid CPF. CPF is required!");
        }
    }
}
