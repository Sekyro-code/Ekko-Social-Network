namespace Services.User.Api.Initializer.Interface
{
    public interface IInitializer
    {
        /// <summary>
        /// Interface à implémenter par les classes responsables de l'initialisation des services.
        /// Les classes qui implémentent cette interface doivent fournir une implémentation de la méthode "InitializeServices"
        /// qui est utilisée pour configurer les services nécessaires à l'application.
        /// </summary>
        /// <param name="services">La collection de services à configurer.</param>
        /// <param name="configuration">La configuration de l'application.</param>
        void InitializeServices(IServiceCollection services, IConfiguration configuration);
    }
}
