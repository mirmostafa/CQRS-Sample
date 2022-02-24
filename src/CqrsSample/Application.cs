using Autofac;
using CqrsSample.Infra;
using CqrsSample.Sample;

namespace CqrsSample
{
    internal class Application
    {
        private static IContainer _container;
        public static void Init()
        {
            var cb = new ContainerBuilder();

            _ = AddDbContext(cb);
            _ = AddQueries(cb);
            _ = AddCommands(cb);

            _container = cb.Build();
        }

        private static ContainerBuilder AddDbContext(ContainerBuilder builder)
        {
            _ = builder
                .RegisterType<DbContext>()
                .AsSelf().InstancePerLifetimeScope();
            return builder;
        }

        public static (IQueryProcessor queryProcessor, ICommandProcessor commandProcessor) GetProcessors()
        {

            var queryProcessor = _container.Resolve<IQueryProcessor>();
            var commandProcessor = _container.Resolve<ICommandProcessor>();
            return (queryProcessor, commandProcessor);
        }

        private static ContainerBuilder AddQueries(ContainerBuilder builder)
        {
            _ = builder
                .RegisterType<QueryProcessor>()
                .As<IQueryProcessor>()
                .InstancePerLifetimeScope();

            _ = builder
               .RegisterAssemblyTypes(typeof(Program).Assembly)
               .AsClosedTypesOf(typeof(IQueryHandler<,>), "1")
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            return builder;
        }

        private static ContainerBuilder AddCommands(ContainerBuilder builder)
        {
            var assembly = typeof(Program).Assembly;
            _ = builder
               .RegisterType<CommandProcessor>()
               .As<ICommandProcessor>()
               .InstancePerLifetimeScope();

            _ = builder
               .RegisterAssemblyTypes(assembly)
               .AsClosedTypesOf(typeof(ICommandHandler<,>), "1")
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            _ = builder
               .RegisterAssemblyTypes(assembly)
               .AssignableTo<ICommandResult>()
               .AsImplementedInterfaces()
               .InstancePerRequest();

            _ = builder
               .RegisterAssemblyTypes(assembly)
               .AsClosedTypesOf(typeof(ICommandValidator<>))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            _ = builder
               .RegisterGenericDecorator(typeof(ValidationCommandHandlerDecorator<,>), typeof(ICommandHandler<,>), "1", "2")
               .InstancePerLifetimeScope();

            return builder;
        }
    }
}
