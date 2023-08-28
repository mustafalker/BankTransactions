using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransactionsApi.Model
{
    public enum CustomerType
    {
        Normal,
        Senior,
        Corporate
    }

    public class CustomerInfo 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(30, ErrorMessage = "First name must be up to 30 characters.")]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Customer surname is required.")]
        [StringLength(30, ErrorMessage = "Last name must be up to 30 characters.")]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 150, ErrorMessage = "Age must be between 18 and 150.")]
        public int CustomerAge { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 digits.")]
        public string PhoneNumber { get; set; }

        public CustomerType Type { get; set; }
    }

    public class RegularCustomer : CustomerInfo
    {
        public RegularCustomer()
        {
            Type = CustomerType.Normal;
        }
    }

    public class SeniorCustomer : CustomerInfo
    {
        public SeniorCustomer()
        {
            Type = CustomerType.Senior;
        }
    }

    public class CorporateCustomer : CustomerInfo
    {
        public CorporateCustomer()
        {
            Type = CustomerType.Corporate;
        }
    }
}
