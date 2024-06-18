using Services.User.Api.Initializer.Interface;

namespace Services.User.Api.Initializer
{
    public static class InjectionInitializer
    {
        /// <summary>
        /// Applique tous les initialisateurs implémentant l'interface <see cref="IInitializer"/> pour configurer
        /// les services de l'application. Cette méthode recherche toutes les classes qui implémentent
        /// l'interface <see cref="IInitializer"/> dans l'assembly de la classe <see cref="Program"/> et les utilise
        /// pour initialiser les services avec la configuration spécifiée.
        /// </summary>
        /// <param name="services">La collection de services à configurer.</param>
        /// <param name="configuration">La configuration de l'application.</param>
        /// <returns>La collection de services configurée.</returns>

        public static IServiceCollection ApplyInitializers(this IServiceCollection services, IConfiguration configuration)
        {
            // typeof(Program).Assembly récupère l'assembly dans lequel se trouve la classe "Program"
            // ExportedTypes récupère tous les types publics de cet assembly.
            // "Where" filtre les types pour inclure uniquement ceux qui sont des implémentations de
            // l'interface IInstaller, ne sont pas des interfaces eux-mêmes et ne sont pas des classes abstraites.

            // GENERALE : Recupère toutes les classes qui implémentes IInitializer (DbInitializer & ServicesApplicationInitializer)
            // et qui ne sont pas des Interface ou des classe abstraite)

            var Initializer = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInitializer)
                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                // Select(Activator.CreateInstance) crée une instance de chaque type trouvé.
                // Cast<IInstaller>().ToList() convertit ces instances en une liste d'objets implémentant l'interface IInstaller.
                .Select(Activator.CreateInstance).Cast<IInitializer>().ToList();

            // installers.ForEach(installer => installer.InstallServices(services, Configuration));
            // itère sur chaque instance d'installateur et appelle la méthode InstallServices
            // sur chacune, passant les services et la configuration en tant que paramètres.
            Initializer.ForEach(i => i.InitializeServices(services, configuration));

            return services;
        }

    }
}
