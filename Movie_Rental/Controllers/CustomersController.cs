using Microsoft.AspNetCore.Mvc;
using Movie_Rental.Models;
using Movie_Rental.ViewModels;
using System.Data.Entity;


namespace Movie_Rental.Controllers
{
    public class CustomersController : Controller
    {

        private Movie_RentalDB_Content _content;

        public CustomersController()
        {
            _content = new Movie_RentalDB_Content();
        }

        protected override void Dispose(bool disposing)
        {
            _content.Dispose();
        }

        public IActionResult Index()
        {

            var customersViewModel = _content.Customers.Include(c => c.MembershipType).ToList();
            return View(customersViewModel);
        }

        [Route("customers/CustomerForm/{id}")]
        public IActionResult CustomerForm(int id)
        {
            var customer = _content.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                customer = new Customer
                {
                    Id = 0
                };
            }

            var viewModel = new ViewCustomerForm
            {
                Customer = customer,
                MembershipTypes = _content.MembershipTypes.ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ViewCustomerForm
                {
                    Customer = customer,
                    MembershipTypes = _content.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                _content.Customers.Add(customer);
            else
            {
                var customerInDb = _content.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubsribedToNewsletter = customer.IsSubsribedToNewsletter;
            }
            _content.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


    }
}
