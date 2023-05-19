global using System.Net;
global using Newtonsoft.Json;
global using Microsoft.OpenApi.Models;
global using Serilog;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;

global using Hipages.Tradies.Application.Exceptions;
global using Hipages.Tradies.Api.Middleware;
global using Hipages.Tradies.Application;
global using Hipages.Tradies.Infrastructure;
global using Hipages.Tradies.Persistence;
global using Hipages.Tradies.Application.Features.Jobs.Commands.UpdateJobStatus;
global using Hipages.Tradies.Application.Features.Jobs.Queries.GetJobList;