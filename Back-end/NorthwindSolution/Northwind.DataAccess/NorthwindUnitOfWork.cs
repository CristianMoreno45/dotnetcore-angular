using Northwind.Repositories;
using Northwind.UnitOfWork;
using System;

namespace Northwind.DataAccess
{
    public class NorthwindUnitOfWork : IUnitOfWork

    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
        }
        public ICustomerRepository Customer { get; private set; }
    }
}
