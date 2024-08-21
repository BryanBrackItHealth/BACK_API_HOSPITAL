using HOSPITAL_CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_CORE.Interface
{
    public interface IPatient
    {
        Task<bool> CreatePatient(CreatePatientModel data);
        Task<object> DetailPatients();
        Task<object> ConsultPatient(int PatientID);
        Task<bool> DeletePatient(int PatientID);
    }
}
