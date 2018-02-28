using Ninject;

namespace Mp3.Core
{
    /// <summary>
    /// IoC Conteiner
    /// </summary>
    public static class IoC 
    {
        #region Fields

        private static IKernel _kernel = new StandardKernel();

        #endregion

        #region Property

        public static IKernel Kernel
        {
            get => IoC._kernel;
            set => IoC._kernel = value;
        }

        public static T Get<T>() => Kernel.Get<T>();

        #endregion

        #region Setup
        public static void Setup() => BindViewModel();

        private static void BindViewModel() => Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

        #endregion
    }
}
