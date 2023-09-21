using System.Reflection;
using System.Resources;
using Unitagram.Application.Contracts.Localization;
using Microsoft.Extensions.Localization;
using Unitagram.Infrastructure.Resources;


namespace Unitagram.Infrastructure.Localization;

public class LocalizationService : ILocalizationService
{
    private readonly IStringLocalizer _localizer;

    public LocalizationService(IStringLocalizerFactory factory)
    {
        var type = typeof(SharedResources);
        var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName!);
        _localizer = factory.Create("SharedResources", assemblyName.Name!);
    }

    public string this[string key] => _localizer[key];


    public string GetLocalizedString(string key)
    {
        return _localizer[key];
    }
}