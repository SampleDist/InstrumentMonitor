using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProvider
{
    public interface IPriceEngine
    {
        event Action<Prices> PriceArrived;

        void Subscribe(string symbol);

        void UnSubscribe(string symbol);

        void StartEngine();

        void StopEngine();
    }
}
