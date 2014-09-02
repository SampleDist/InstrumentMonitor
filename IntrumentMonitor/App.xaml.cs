using InstrumentMonitor;
using Microsoft.Practices.Unity;
using StockProvider;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InstrumentMonitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();

            RandomPriceSources source = new RandomPriceSources();

            DispatchingPriceSource dispatching = new DispatchingPriceSource(source);

            //registering this source as implementation of iquotesource
            container.RegisterInstance<IPriceEngine>(dispatching);

            StockDashboard window = container.Resolve<StockDashboard>();
            window.Show();


        }


    }
}
