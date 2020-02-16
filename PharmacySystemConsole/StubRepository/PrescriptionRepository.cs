using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;

namespace PharmacySystemConsole.StubRepository
{
    public class PrescriptionRepository : IPrescription
    {
        public Prescription Add(Prescription prescription)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> GetAll()
        {
            throw new NotImplementedException();
        }

        public Prescription GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Prescription Update(Prescription prescription)
        {
            throw new NotImplementedException();
        }
    }
}
