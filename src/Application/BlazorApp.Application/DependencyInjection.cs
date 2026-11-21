using BlazorApp.Api.Bus;
using BlazorApp.Api.Commands;
using BlazorApp.Api.Handlers;
using BlazorApp.Api.MappingProfiles;
using BlazorApp.Api.Queries;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Application.Services;
using BlazorApp.Web.Data.Models;
using LiteBus;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // LiteBus CQRS
            services.AddSingleton<ILiteBus, SimpleLiteBus>();

            // Mapster configuration
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(NimsMappingConfig).Assembly);
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            // Domain Services
            services.AddScoped<INimsService, NimsService>();
            services.AddScoped<IActivitysService, ActivitysService>();
            services.AddScoped<IActivityTracksService, ActivityTracksService>();
            services.AddScoped<IAgencysService, AgencysService>();
            services.AddScoped<IBranchsService, BranchsService>();
            services.AddScoped<IBuildingsService, BuildingsService>();
            services.AddScoped<IBuildingTypesService, BuildingTypesService>();
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IFloorsService, FloorsService>();
            services.AddScoped<INotesService, NotesService>();
            services.AddScoped<IRespondentsService, RespondentsService>();
            services.AddScoped<IRoomsService, RoomsService>();
            services.AddScoped<IStatusOptionsService, StatusOptionsService>();
            services.AddScoped<ISuitesService, SuitesService>();

            // NIMS CQRS Handlers
            services.AddTransient<IQueryHandler<GetAllNimsQuery, List<Nims>>, GetAllNimsQueryHandler>();
            services.AddTransient<IQueryHandler<GetNimsByIdQuery, Nims?>, GetNimsByIdQueryHandler>();
            services.AddTransient<ICommandHandler<CreateNimsCommand>, CreateNimsCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateNimsCommand>, UpdateNimsCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteNimsCommand>, DeleteNimsCommandHandler>();

            // Note CQRS Handlers
            services.AddTransient<IQueryHandler<GetAllNoteQuery, List<Notes>>, GetAllNoteQueryHandler>();
            services.AddTransient<IQueryHandler<GetNoteByIdQuery, Notes?>, GetNoteByIdQueryHandler>();
            services.AddTransient<ICommandHandler<CreateNoteCommand>, CreateNoteCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateNoteCommand>, UpdateNoteCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteNoteCommand>, DeleteNoteCommandHandler>();

            return services;
        }
    }
}
