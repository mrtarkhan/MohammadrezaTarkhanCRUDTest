using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MohammadrezaTarkhanCRUDTest.DataLayer
{
	public class Customer
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string PhoneNumber { get; set; }
		public string Country { get; set; }
		public string Email { get; set; }
		public string BankAccountNumber { get; set; }

		public void ValidatePhoneNumber ()
		{
			this.Country = this.Country == null ? "US" : this.Country;
			if (this.PhoneNumber[0] != '0')
				this.PhoneNumber = '0' + this.PhoneNumber;

			var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
			var phoneNumber = phoneNumberUtil.Parse(this.PhoneNumber, this.Country.ToUpper());
			var type= phoneNumberUtil.GetNumberType(phoneNumber);
			if (type != PhoneNumberType.MOBILE)
			{
				throw new ArgumentException("phone number is not valid");
			}
			if (!phoneNumberUtil.IsValidNumber(phoneNumber))
			{
				throw new ArgumentException("phone number is not valid");
			}

		}

	}
}
