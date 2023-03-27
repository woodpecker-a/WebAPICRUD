using BO = Infrastructure.BusinessObjects;
using Infrastructure.UnitOfWorks;
using Infrastructure.Entities;
using System.Text.RegularExpressions;
using AutoMapper;

namespace Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IApplicationUnitOfWork _works;
        private readonly IMapper _mapper;
        public CustomerService(IApplicationUnitOfWork work, IMapper mapper)
        {
            _works = work;
            _mapper = mapper;
        }
        public void CreateCustomer(BO.Customer customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);

            _works.Customers.Add(customerEntity);
            _works.Save();
        }

        public void DeleteCustomer(Guid id)
        {
            _works.Customers.Remove(id);
            _works.Save();
        }

        public void EditCustomer(BO.Customer customer)
        {
            var customerEntity = _works.Customers.GetById(customer.Id);
            if (customerEntity != null)
            {
                _mapper.Map(customer, customerEntity);
                _works.Save();
            }
            else throw new InvalidOperationException("Customer not found");
        }

        public BO.Customer GetCustomerById(Guid id)
        {
            Customer customerEntity = _works.Customers.GetById(id);
            BO.Customer customer = _mapper.Map<BO.Customer>(customerEntity);
            return customer;
        }

        public (int total, int totalDisplay, IList<BO.Customer> records) GetCustomers(int pageIndex, int pageSize, string searchText, string orderby)
        {
            (IList<Customer> customresList, int total, int totalDisplay) results = _works.Customers.GetCustomers(pageIndex, pageSize, searchText, orderby);
            IList<BO.Customer> customers = new List<BO.Customer>();
            foreach(Customer customer in results.customresList)
            {
                customers.Add(_mapper.Map<BO.Customer>(customer));
            }
            return (results.total, results.totalDisplay, customers);
        }
    }
}
