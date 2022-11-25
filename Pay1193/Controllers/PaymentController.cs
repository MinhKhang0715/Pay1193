using Microsoft.AspNetCore.Mvc;
using Pay1193.Models;
using Pay1193.Services;

namespace Pay1193.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPayService _payService;
        private readonly IEmployee _employeeService;

        public PaymentController(IPayService payService, IEmployee employeeService)
        {
            _payService = payService;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var viewModel = _payService
              .GetAll()
              .Select(payment => PaymentRecordIndexViewModel.FromPaymentRecord(payment));

            return View(viewModel);
        }

        public IActionResult Create()
        {
            var model = new PaymentRecordCreateViewModel
            {
                Employees = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
                {
                    Id = employee.Id,
                    EmployeeNo = employee.EmployeeNo,
                    FullName = employee.FullName,
                    Gender = employee.Gender,
                    ImageUrl = employee.ImageUrl,
                    DateJoined = employee.DateJoined,
                    Designation = employee.Designation,
                    City = employee.City
                }).ToList()
            };

            return View(model);
        }
    }
}
