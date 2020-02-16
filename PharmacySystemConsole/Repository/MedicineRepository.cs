using PharmacySystemConsole.Context;
using PharmacySystemConsole.Interfaces;
using PharmacySystemConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PharmacySystemConsole.Repository
{
    public class MedicineRepository : IMedicine
    {
        readonly EFCContext _eFCContext = new EFCContext();

        public Medicine Add(Medicine medicine)
        {
            try
            {
                _eFCContext.Medicines.Add(medicine);

                _eFCContext.SaveChanges();

                return medicine;
            }
            catch (Exception ex)
            {
                return medicine;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var obj = GetById(id);

                _eFCContext.Medicines.Remove(obj);

                _eFCContext.SaveChanges();

            }
            catch (Exception ex)
            {
            }
        }

        public List<Medicine> GetAll()
        {
            return _eFCContext.Medicines.ToList();
        }

        public Medicine GetById(int id)
        {
            return _eFCContext.Medicines.FirstOrDefault(p => p.Id == id);
        }

        public Medicine Update(Medicine medicine)
        {
            try
            {
                var obj = GetById(medicine.Id);

                obj.Name = medicine.Name;

                obj.Manufacturer = medicine.Manufacturer;

                obj.Price = medicine.Price;

                obj.Amount = medicine.Amount;

                obj.WithPrescription = medicine.WithPrescription;

                _eFCContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _eFCContext.SaveChanges();

                return medicine;
            }
            catch (Exception ex)
            {
                return medicine;
            }
        }
    }
}
