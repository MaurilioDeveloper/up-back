using Microsoft.Extensions.Logging;
using Positivo.AtividadesComplementares.Api.ViewModel;
using System;
using System.IO;


namespace Positivo.AtividadesComplementares.Infrastructure.Repository
{
    public class CustomLogger : ILogger
    {
        readonly string loggerName;
        readonly CustomLoggerProviderConfiguration loggerConfig;
        public CustomLogger(string name, CustomLoggerProviderConfiguration config)
        {
            this.loggerName = name;
            loggerConfig = config;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, 
            Exception exception, Func<TState, Exception, string> formatter)
        {
            string mensagem = string.Format("{0}: {1} - {2}", logLevel.ToString(), 
                eventId.Id, formatter(state, exception));
            EscreverTextoNoArquivo(mensagem);
        }
        private void EscreverTextoNoArquivo(string mensagem)
        {
            try
            {
                var ano = DateTime.Now.Year;
                var mes = DateTime.Now.Month;
                string caminhoArquivoLog = $@"Log\{ano}_{mes}_Log.txt";
                using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
                {
                    streamWriter.WriteLine(mensagem);
                    streamWriter.Close();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}