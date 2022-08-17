using ChessTournament.DL;
using ChessTournament.DL.Interfaces;
using ChessTournament.DL.Models;
using ChessTournament.IL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataBase(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITournamentRepository, TournamentRepository>();
            serviceCollection.AddScoped<IRepository<int, Match>, BaseRepository<int, Match>>();
            serviceCollection.AddScoped<IMemberRepository, MemberRepository>();
            return serviceCollection;
        }
    }
}
