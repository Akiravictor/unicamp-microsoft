using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3.Calculator
{
    public abstract class Publisher
    {
        private List<Subscriber> subscribers = new List<Subscriber>();

        public void AddObserver(Subscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Notify()
        {
            foreach(var subscriber in subscribers)
            {
                subscriber.Update();
            }
        }
    }
}
