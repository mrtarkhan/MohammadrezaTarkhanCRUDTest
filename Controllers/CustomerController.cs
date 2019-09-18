using Microsoft.AspNetCore.Mvc;
using MohammadrezaTarkhanCRUDTest.DataLayer;

namespace MohammadrezaTarkhanCRUDTest.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerController (ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public ActionResult Index ()
		{
			var data = _customerRepository.List();
			return View(data);
		}

		public ActionResult Details (int id)
		{
			var data = _customerRepository.Read(id);
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create ([FromForm] Customer inputData)
		{
			inputData.ValidatePhoneNumber();
			_customerRepository.Create(inputData);
			return RedirectToAction(nameof(Index));
		}



		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit ([FromForm] Customer inputData)
		{
			inputData.ValidatePhoneNumber();
			_customerRepository.Update(inputData);
			return RedirectToAction(nameof(Index));
		}



		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete ([FromForm] Customer inputData)
		{
			_customerRepository.Delete(inputData);
			return RedirectToAction(nameof(Index));
		}

	}
}