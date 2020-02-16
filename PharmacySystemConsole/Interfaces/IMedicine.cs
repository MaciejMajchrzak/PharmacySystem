using PharmacySystemConsole.Models;
using System.Collections.Generic;

namespace PharmacySystemConsole.Interfaces
{
    public interface IMedicine
    {
        public List<Medicine> GetAll();
        public Medicine GetById(int id);
        public Medicine Add(Medicine medicine);
        public Medicine Update(Medicine medicine);
        public void Delete(int id);
    }
}
