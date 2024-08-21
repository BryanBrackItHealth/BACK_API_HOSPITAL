using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_CORE.Model
{
    public class CreatePatientModel
    {
        public int? PatientID { get; set; }
        public int IdDocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public int IdGender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public bool Active { get; set; }
    }

    public class DetailPatientModel
    {
        public int PatientID { get; set; }
        public int IdDocumentType { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public int IdGender { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public bool Active { get; set; }
    }
}
