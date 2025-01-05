using GtMotive.Renting.Modules.Rentals.Domain.Rentals;
using GtMotive.Renting.Modules.Rentals.Infrastructure;
using System.Reflection;

namespace GtMotive.Renting.Modules.Rentals.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(Rentals.Application.AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(Rental).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(RentalsModule).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Rentals.Presentation.AssemblyReference).Assembly;
}