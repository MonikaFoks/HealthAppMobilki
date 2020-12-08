using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HealthAppMobilki.Models;
using Refit;

namespace HealthAppMobilki.Interface
{
    public interface IHealthAPI
    {
        [Get("/api/users")]
        Task<List<User>> GetUsers();

        [Get("/api/pulses")]
        Task<List<Pulse>> GetPulses();

        [Get("/api/pressures")]
        Task<List<Pressure>> GetPressures();
        [Get("/api/bloodSugars")]
        Task<List<BloodSugar>> GetBloodSugars();

        [Get("/api/weights")]
        Task<List<Weight>> GetWeights();

        [Delete("/api/pressures/{id}")]
        Task<DeleteAttribute> DeletePressure(int id);

        [Delete("/api/pulses/{id}")]
        Task<DeleteAttribute> DeletePulse(int id);

        [Delete("/api/weights/{id}")]
        Task<DeleteAttribute> DeleteWeight(int id);

        [Delete("/api/bloodsugars/{id}")]
        Task<DeleteAttribute> DeleteBloodSugar(int id);

    }
}