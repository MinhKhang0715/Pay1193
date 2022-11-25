using System.ComponentModel.DataAnnotations;

namespace Pay1193.Models
{
    public class PaymentRecordCreateViewModel
    {
        public IEnumerable<EmployeeIndexViewModel> Employees { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string PayMonth { get; set; }
        [Required]
        public DateTime PayDate { get; set; }
        [Required, Range(0.0, 999.0)]

        public decimal HourlyRate { get; set; }
        [Required, Range(0.0, 300.0)]

        public decimal HoursWorked { get; set; }
        [Required]

        public decimal ContractualHours { get; set; }
    }
}
