using System.Collections.Generic;

namespace PharmacySystemConsole.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        ///<param name="Number">Prescription number</param>
        public string Number { get; set; }
        public string Pesel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Order Order { get; set; }
    }
}
