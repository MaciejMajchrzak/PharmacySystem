using PharmacySystemConsole.Models;
using System.Collections.Generic;

namespace PharmacySystemConsole.Interfaces
{
    public interface IPrescription
    {
        public List<Prescription> GetAll();
        public Prescription GetById(int id);
        public Prescription Add(Prescription prescription);
        public Prescription Update(Prescription prescription);
        public void Delete(int id);
    }
}
