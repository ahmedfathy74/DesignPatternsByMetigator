using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern.After
{
    public interface INavigationStrategy
    {
         Route Navigate(string origin, string destination);
    }
}
