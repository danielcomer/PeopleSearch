using Ninject;

namespace PeopleSearch.Wpf.Client.IoC
{
    public static class NinjectServiceLocator
    {
        private static IKernel _kernel;

        public static T Get<T>()
        {
            if (_kernel == null)
            {
                throw new KernelNotInitilizedException();
            }

            return _kernel.Get<T>();
        }

        public static void Initialize(IKernel kernel)
        {
            if (_kernel != null)
            {
                throw new KernelAlreadyInitializedException();
            }

            _kernel = kernel;
        }
    }
}
