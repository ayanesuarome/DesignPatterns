using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    enum Box
    {
        Open,
        Closed,
        Locked // you need a key to open it
    }

    enum BoxAction
    {
        Open,
        Close
    }

    // Better approach to use switch expressions
    internal static class SwitchExpression
    {
        private static Box Manipulate(Box box, BoxAction action, bool haveKey) =>
            (box, action, haveKey) switch
            {
                (Box.Locked, BoxAction.Open, true) => Box.Open,
                (Box.Closed, BoxAction.Open, _) => Box.Open,
                (Box.Open, BoxAction.Close, true) => Box.Locked,
                (Box.Open, BoxAction.Close, false) => Box.Closed,
                _ => box,
            };

        // Better approach when you have many states
        private static Box Manipulate2(Box box, BoxAction action, bool haveKey)
        {
            switch(box, action, haveKey)
            {
                case (Box.Locked, BoxAction.Open, true):
                    return Box.Open;
                case (Box.Closed, BoxAction.Open, _):
                    return Box.Open;
                case (Box.Open, BoxAction.Close, true):
                    return Box.Locked;
                case (Box.Open, BoxAction.Close, false):
                    return Box.Closed;
                default:
                    WriteLine("Box unchanged");
                    return box;
            };
        }

        internal static void RunDemo()
        {
            Box box = Box.Locked;
            WriteLine($"Box is {box}");

            box = SwitchExpression.Manipulate(box, BoxAction.Open, true);
            WriteLine($"Box is {box}");

            box = SwitchExpression.Manipulate(box, BoxAction.Close, false);
            WriteLine($"Box is {box}");

            box = SwitchExpression.Manipulate(box, BoxAction.Close, false);
            WriteLine($"Box is {box}");
        }
    }
}
