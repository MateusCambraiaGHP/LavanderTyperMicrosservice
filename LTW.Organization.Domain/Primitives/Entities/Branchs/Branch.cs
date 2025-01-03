﻿using LavanderTyperWeb.Core.DomainObjects;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;

namespace LavanderTyperWeb.Domain.Primitives.Entities.Branchs
{
    public class Branch : EntityBase
    {
        public Guid IdCompany { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Company Company { get; set; } = new();
        public List<Employee> Employees { get; set; } = new();

        internal Branch() { }

        public Branch(
            Guid idCompany,
            string name,
            string address,
            Company company,
            List<Employee> employees)
        {
            IdCompany = idCompany;
            Name = name;
            Address = address;
            Company = company;
            Employees = employees;
        }
    }
}