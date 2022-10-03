using Movie_Rental.Models;

namespace Movie_Rental.ViewModels
{
    public class ViewCustomerForm
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
