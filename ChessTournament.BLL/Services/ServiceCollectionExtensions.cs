using ChessTournament.BLL.Interfaces;
using ChessTournament.DL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBLL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITournamentService, TournamentService>();
            return serviceCollection;
        }
    }
}
