using HVLC.RentACar.Data.Abstract;
using HVLC.RentACar.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Data.Concrete.EntityFramework.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {

        }
    }
}
