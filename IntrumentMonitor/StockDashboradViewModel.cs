using StockProvider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;


namespace InstrumentMonitor
{
    public class StockDashboardViewModel : DependencyObject
    {

        public ObservableCollection<Prices> InstrumentPrices { get; set; }

        private readonly IPriceEngine _priceEngine;

        public string Symbol { get; set; }

        public ICommand SubscribeCommand { get; set; }

        public ICommand UnSubscribeCommand { get; set; }

        public ICommand StartEngineCommand { get; set; }

        public ICommand StopEngineCommand { get; set; }

        public StockDashboardViewModel(IPriceEngine source)
        {

            this.SubscribeCommand = new SubscribeCommand(this);

            this.UnSubscribeCommand = new UnSubscribeCommand(this);

            this.StartEngineCommand = new StartEngineCommand(this);

            this.StopEngineCommand = new StopEngineCommand(this);

            this.InstrumentPrices = new ObservableCollection<Prices>();

            _priceEngine = source;
         
        }

        void _source_PriceArrived(Prices price)
        {
            InstrumentPrices.Add(price);
        }

        public void StartEngine()
        {
            _priceEngine.PriceArrived += _source_PriceArrived;
            _priceEngine.StartEngine();
        }

        public void StopEngine()
        {
            _priceEngine.PriceArrived -= _source_PriceArrived;
            _priceEngine.StopEngine();
        }

        public void Subscribe()
        {
            _priceEngine.Subscribe(this.Symbol);
        }


        public void UnSubscribe()
        {
            _priceEngine.UnSubscribe(this.Symbol);
        }

    }
}
