using Data.Models;
using Microsoft.EntityFrameworkCore;

internal static class PatientsRepository
{

    internal static async Task<List<Patient>> GetPatientsAsync()
    {
        using (var db = new RISDbContext())
        {

            return await db.patients.ToListAsync();
        }

    }
    internal static async Task<Patient> GetPatientByIdAsync(int id)
    {
        using (var db = new RISDbContext())
        {

            return await db.patients.FirstOrDefaultAsync(Patient => Patient.Id == id);
        }
    }
    internal static async Task<bool> CreatePatientAsync(Patient patientToCreate)
    {
        using (var db = new RISDbContext())
        {

            try
            {
                await db.patients.AddAsync(patientToCreate);
                return await db.SaveChangesAsync() >= 1;

            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
    internal static async Task<bool> UpdatePatientAsync(Patient PatientToUpdate)
    {
        using (var db = new RISDbContext())
        {

            try
            {
                db.patients.Update(PatientToUpdate);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }

    internal static async Task<bool> DeletePatientAsync(int id)
    {
        using (var db = new RISDbContext())
        {

            try
            {
                Patient PatientToDelete = await GetPatientByIdAsync(id);
                db.patients.Remove(PatientToDelete);
                return await db.SaveChangesAsync() >= 1;

            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}