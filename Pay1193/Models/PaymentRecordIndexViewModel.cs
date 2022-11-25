using Pay1193.Entity;

namespace Pay1193.Models
{
    public class PaymentRecordIndexViewModel
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public DateTime PayDate { get; set; }
        public int TaxYearId { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal NetPayment { get; set; }

        public static PaymentRecordIndexViewModel FromPaymentRecord(PaymentRecord record)
        {
            return new PaymentRecordIndexViewModel(
              record.Id,
              record.Employee,
              record.DatePay,
              record.TaxYearId,
              record.TotalEarnings,
              record.TotalDeduction,
              record.NetPayment
            );
        }

        public PaymentRecordIndexViewModel(
          int id,
          Employee employee,
          DateTime payDate,
          int taxYearId,
          decimal totalEarnings,
          decimal totalDeduction,
          decimal netPayment
        )
        {
            Id = id;
            Employee = employee;
            PayDate = payDate;
            TaxYearId = taxYearId;
            TotalEarnings = totalEarnings;
            TotalDeduction = totalDeduction;
            NetPayment = netPayment;
        }
    }
}
