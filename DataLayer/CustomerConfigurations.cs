using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MohammadrezaTarkhanCRUDTest.DataLayer
{
	public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
	{
		public void Configure (EntityTypeBuilder<Customer> builder)
		{

			builder.ToTable("Customer");
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.DateOfBirth).HasColumnType("datetime");
			builder.HasIndex(e => e.Email).IsUnique();
			builder.Property(e => e.Email).HasMaxLength(300).IsRequired();
			builder.Property(e => e.PhoneNumber).HasMaxLength(15).IsRequired();
			builder.Property(e => e.FirstName).HasMaxLength(300).IsRequired();
			builder.Property(e => e.LastName).HasMaxLength(300).IsRequired();
			builder.Property(e => e.BankAccountNumber).HasMaxLength(300).IsRequired();
			builder.HasIndex(e => new { e.FirstName, e.LastName, e.DateOfBirth }).IsUnique();
			builder.Ignore(e => e.Country);

		}
	}
}
