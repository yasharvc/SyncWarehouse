using Autofac;

namespace IoC
{
	public class IoC
	{
		IContainer Container { get; set; }
		ContainerBuilder ContainerBuilder { get; set; } = new ContainerBuilder();

		public void Register<T, Y>()
		{
			ContainerBuilder.RegisterType<Y>().As<T>();
			Container = ContainerBuilder.Build(Autofac.Builder.ContainerBuildOptions.None);
		}

		public void Resolve<T>() => Container.Resolve<T>();
	}
}