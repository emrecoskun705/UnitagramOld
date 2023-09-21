namespace Unitagram.Application.Contracts.Localization;

public interface ILocalizationService
{
    string GetLocalizedString(string key);
    string this[string key] { get; }
}