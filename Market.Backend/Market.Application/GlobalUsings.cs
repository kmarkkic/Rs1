// ================================================
// Global using directives — shared across all feature modules
// ================================================

global using MediatR;
global using FluentValidation;
global using Market.Application.Abstractions;
global using Market.Domain.Entities.Catalog;
global using Market.Domain.Entities.UdomiMe; // Dodajemo i Aminov namespace da ne moraš u svakom fajlu kucati using
global using Market.Application.Common;
global using Microsoft.EntityFrameworkCore;
global using System.Text.Json.Serialization;
global using Market.Application.Common.Exceptions;
global using Market.Domain.Entities.Identity;
global using Microsoft.AspNetCore.Identity;