using HOSPITAL_CORE.Interface;
using HOSPITAL_CORE.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_HOSPITAL.Controller
{
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPatient _patient;

        public PacienteController(IPatient patient)
        {
            _patient = patient;
        }

        /// <summary>
        /// Metodo para crear pacientes
        /// </summary>
        [HttpPost]
        [Route("api/createPatient")]
        public async Task<bool> CreatePatient([FromBody] CreatePatientModel data)
        {
            var res = await _patient.CreatePatient(data);
            return res;
        }
        /// <summary>
        /// Metodo para obetener detalle de pacientes creados
        /// </summary>
        [HttpGet]
        [Route("api/detailPatients")]
        public async Task<object> DetailPatients()
        {
            var res = await _patient.DetailPatients();
            return res;
        }

        /// <summary>
        /// Metodo para consultar detalle de paciente por ID
        /// </summary>
        [HttpGet]
        [Route("api/consultPatient/{PatientID}")]
        public async Task<object> CreatePatient([FromRoute] int PatientID)
        {
            var res = await _patient.ConsultPatient(PatientID);
            return res;
        }

        /// <summary>
        /// Metodo para eliminar pacientes creados
        /// </summary>
        [HttpGet]
        [Route("api/deletePatient/{PatientID}")]
        public async Task<object> DeletePatient([FromRoute] int PatientID)
        {
            var res = await _patient.DeletePatient(PatientID);
            return res;
        }
    }
}
