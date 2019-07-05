using Microsoft.Extensions.Logging;

namespace Positivo.AtividadesComplementares.Api.ViewModel
{
    public class CustomLoggerProviderConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; }
    }
}