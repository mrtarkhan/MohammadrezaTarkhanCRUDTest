using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadrezaTarkhanCRUDTest.DataLayer
{
	public interface ICustomerRepository
	{
		void Create (Customer inputData);
		void Update (Customer inputData);
		void Delete (Customer inputData);
		Customer Read (int id);
		IReadOnlyList<Customer> List ();
	}
}
