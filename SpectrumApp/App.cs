using System;

namespace SpectrumApp
{
    public class App
    {
        public static void Initialize()
        {
             ServiceLocator.Instance.Register<IDataStore<User>, SpectrumDb>();
        }
    }
}
