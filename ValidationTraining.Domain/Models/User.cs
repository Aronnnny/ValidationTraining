using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTraining.Domain.Entities;
using ValidationTraining.Domain.Validations;

namespace ValidationTraining.Domain.Models
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }

        public User(string name, string email, string password, string phoneNumber, string cpf, DateTime birthDate)
        {
            ValidateName(name);
            ValidateEmail(email);
            ValidatePassword(password);
            ValidatePhoneNumber(phoneNumber);
            ValidateBirthDate(birthDate);
            ValidateCPF(cpf);

            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Cpf = cpf;
        }
        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                DomainExceptionValidation.ExceptionHandler(true, "Invalid name. Name is required!");
            if (name.Length > 30)
                DomainExceptionValidation.ExceptionHandler(true, "Too long name.");
        }
        private void ValidateEmail(string email)
        {
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(email), "Invalid Email. Email is required!");
        }
        private void ValidatePassword(string password)
        {
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(password), "Invalid Password. Password is required!");
        }
        private void ValidatePhoneNumber(string phoneNumber)
        {
            if(phoneNumber.Length > 15)
            {
                DomainExceptionValidation.ExceptionHandler(true, "Phone number cannot be longer than 15 characters!");
            }
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(phoneNumber), "Invalid Phone Number. Phone Number is required!");
        }
        private void ValidateCPF(string cpf)
        {
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(cpf), "Invalid CPF. CPF is required!");
        }
        private void ValidateBirthDate(DateTime birthDate)
        {
            DomainExceptionValidation.ExceptionHandler(birthDate == null, "Invalid Birth Date. Birth Date is required!");
        }
    }
}
