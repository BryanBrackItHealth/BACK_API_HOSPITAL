using HOSPITAL_CORE.Interface;
using HOSPITAL_INFRA.Service;

namespace API_HOSPITAL.Extensions
{
    public static class Startup
    {
        public static void configureStartup(this IServiceCollection services)
        {
            services.AddScoped<IPatient, PatientService>();
        }
    }
}
