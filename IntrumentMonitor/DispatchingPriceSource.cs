using StockProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace InstrumentMonitor
{
    public class DispatchingPriceSource : IPriceEngine
    {
        private readonly Dispatcher _currentDispatcher;

        private readonly IPriceEngine _underlying;

        public DispatchingPriceSource(IPriceEngine underlying)
        {
            _currentDispatcher = Dispatcher.CurrentDispatcher;

            _underlying = underlying;

            _underlying.PriceArrived += _underlying_PriceArrived;
        }

        void _underlying_PriceArrived(Prices obj)
        {
            Action dispatchAction = () =>
            {
                if (PriceArrived != null)
                    PriceArrived(obj);
            };
            _currentDispatcher.BeginInvoke(DispatcherPriority.DataBind, dispatchAction);

        }

        public event Action<Prices> PriceArrived;

        public void StartEngine()
        {
            _underlying.StartEngine();
        }

        public void StopEngine()
        {
            _underlying.StopEngine();
        }

        public void Subscribe(string symbol)
        {
            _underlying.Subscribe(symbol);
        }

        public void UnSubscribe(string symbol)
        {
            _underlying.UnSubscribe(symbol);
        }
    }
}
