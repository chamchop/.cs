using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.Events
{
    public class CustomEventArgs : EventArgs
    {
        public int a { get; set; }
        public int b { get; set; }
    }

    public class Publish
    {
        public event EventHandler<CustomEventArgs> myEvent;

        public void RaiseEvent(object sender, int a, int b)
        {
            if (this.myEvent != null)
            {
                CustomEventArgs customEventArgs = new CustomEventArgs() { a = a, b = b };
                this.myEvent(sender, customEventArgs);
            }
        }
    }
}
