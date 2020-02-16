using PharmacySystemConsole.Context;
using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PharmacySystemConsole.Repository
{
    public class PrescriptionRepository : IPrescription
    {
        readonly EFCContext _eFCContext = new EFCContext();

        public Prescription Add(Prescription prescription)
        {
            try
            {
                _eFCContext.Prescriptions.Add(prescription);

                _eFCContext.SaveChanges();

                return prescription;
            }
            catch (Exception ex)
            {
                return prescription;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var obj = GetById(id);

                _eFCContext.Prescriptions.Remove(obj);

                _eFCContext.SaveChanges();

            }
            catch (Exception ex)
            {
            }
        }

        public List<Prescription> GetAll()
        {
            return _eFCContext.Prescriptions.ToList();
        }

        public Prescription GetById(int id)
        {
            return _eFCContext.Prescriptions.FirstOrDefault(p => p.Id == id);
        }

        public Prescription Update(Prescription prescription)
        {
            try
            {
                var obj = GetById(prescription.Id);

                obj.Number = prescription.Number;

                obj.Pesel = prescription.Pesel;

                obj.FirstName = prescription.FirstName;

                obj.LastName = prescription.LastName;

                obj.Order = prescription.Order;

                _eFCContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _eFCContext.SaveChanges();

                return prescription;
            }
            catch (Exception ex)
            {
                return prescription;
            }
        }
    }
}
