using System;
using Autofac;
using Utils.Commands;

namespace Utils
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            ConfigureContainer();

            ICommand command;

            if (args.Length < 1)
            {
                command = ResolveError("No arguments are provide. Use \"help\" for list of commands");
                command.Execute(args);
                return;
            }

            switch (args[0])
            {
                case "filejoin":
                    command = Container.Resolve<FileJoin>();
                    break;

                case "fixlinebreak":
                    command = Container.Resolve<FixLineBreak>();
                    break;

                case "rename":
                    command = Container.Resolve<Rename>();
                    break;

                default:
                    command = Container.Resolve<Help>();
                    break;
            }

            command.Execute(args);
        }

        private static ICommand ResolveError(string error)
        {
            return Container.Resolve<Error>(new NamedParameter("error", error));
        }

        private static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register
            builder.RegisterType<Output>().As<IOutput>();
            builder.RegisterType<Help>();
            builder.RegisterType<Error>();
            builder.RegisterType<FileJoin>();
            builder.RegisterType<FixLineBreak>();
            builder.RegisterType<Rename>();

            // Build Container
            Container = builder.Build();
        }
    }
}
