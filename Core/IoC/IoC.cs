using Autofac;
using JsonRepository;
using Repository;

namespace IoC
{
	public class IoC
	{
		private static IoC Singelton;
		IContainer Container { get; set; }
		ContainerBuilder ContainerBuilder { get; set; } = new ContainerBuilder();

		private IoC()
		{
			Register<IProductRepository, ProductRepository>();
		}

		public void Register<T, Y>()
		{
			ContainerBuilder.RegisterType<Y>().As<T>();
			Container = ContainerBuilder.Build(Autofac.Builder.ContainerBuildOptions.None);
		}

		public T Resolve<T>() => Container.Resolve<T>();

		public static IoC GetIoC()
		{
			if (Singelton == null)
				Singelton = new IoC();
			return Singelton;
		}
	}
}