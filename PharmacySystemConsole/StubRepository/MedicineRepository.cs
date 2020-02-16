using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;

namespace PharmacySystemConsole.StubRepository
{
    public class MedicineRepository : IMedicine
    {
        public Medicine Add(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Medicine> GetAll()
        {
            throw new NotImplementedException();
        }

        public Medicine GetById(int id)
        {
            return new Medicine()
            {
                Id = 1,
                Name = "Apap",
                Manufacturer = "aerserf",
                Amount = 100,
                Price = 10
            };
        }

        public Medicine Update(Medicine medicine)
        {
            throw new NotImplementedException();
        }
    }
}
