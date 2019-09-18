using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadrezaTarkhanCRUDTest.DataLayer
{
	public class CustomerRepository : ICustomerRepository
	{
		public void Create (Customer inputData)
		{
			using (var context = new ApplicationDbContext())
			{
				context.Customers.Add(inputData);
				context.SaveChanges();
			}
		}

		public void Delete (Customer inputData)
		{
			using (var context = new ApplicationDbContext())
			{
				context.Customers.Remove(inputData);
				context.SaveChanges();

			}
		}

		public Customer Read (int id)
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Customers.FirstOrDefault(e => e.Id.Equals(id));
			}
		}

		public IReadOnlyList<Customer> List ()
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Customers.ToList();
			}
		}

		public void Update (Customer inputData)
		{
			using (var context = new ApplicationDbContext())
			{
				context.Customers.Update(inputData);
				context.SaveChanges();
			}
		}
	}
}
