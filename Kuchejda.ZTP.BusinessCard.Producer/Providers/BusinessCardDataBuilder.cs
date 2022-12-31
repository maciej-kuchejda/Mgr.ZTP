using Kuchejda.ZTP.BusinessCard.Shared.Models;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuchejda.ZTP.BusinessCard.Producer.Providers
{
    public class BusinessCardDataBuilder : IBusinessCardDataBuilder
    {
        private readonly BusinessCardDTO _entity;
        private readonly IPersonNameGenerator _personNameGenerator;
        private readonly int _randomDepartments;

        public BusinessCardDataBuilder(IPersonNameGenerator personNameGenerator, int randomDepartments)
        {
            _entity = new BusinessCardDTO();
            _personNameGenerator = personNameGenerator;
            _randomDepartments = randomDepartments;
        }

        public BusinessCardDTO Build()
        {
            return _entity;
        }

        public IBusinessCardDataBuilder WithRandomEmail()
        {
            var email = Faker.Internet.Email();
            _entity.Email = email;

            return this;
        }

        public IBusinessCardDataBuilder WithRandomFirstName()
        {
            var firstName = _personNameGenerator.GenerateRandomFirstName();
            _entity.FirstName = firstName;

            return this;
        }

        public IBusinessCardDataBuilder WithRandomLastName()
        {
            var lastName = _personNameGenerator.GenerateRandomLastName();
            _entity.LastName = lastName;

            return this;
        }

        public IBusinessCardDataBuilder WithRandomTelephone()
        {
            var telephone = Faker.Phone.Number();
            _entity.Telephone = telephone;

            return this;
        }

        public IBusinessCardDataBuilder WithRandomWebSite()
        {
            var website = $"www.{Faker.Internet.DomainName()}.{Faker.Internet.DomainSuffix()}";
            _entity.WebSite = website;

            return this;
        }

        public IBusinessCardDataBuilder WithCompany()
        {
            var company = $"{Faker.Internet.DomainName()} - Cebulla Company - CC - departament: {Faker.RandomNumber.Next(_randomDepartments)}";
            _entity.Company = company;

            return this;
        }
    }
}
