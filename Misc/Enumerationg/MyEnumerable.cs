using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerationg
{
    internal class MyEnumerable(int start, int stop) : IEnumerable<int>
    {
        public int Start { get; } = start;
        public int Stop { get; } = stop;

        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator(Start, Stop);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class MyEnumerator : IEnumerator<int>
        {
            public MyEnumerator(int start, int stop)
            {
                Start = start;
                Stop = stop;
                Current = start - 1;
            }

            public int Start { get; private set; }
            public int Stop { get; private set; }

            private int _current;

            public int Current
            {
                get
                {
                    Console.WriteLine("Getting current");
                    return _current;
                }
                private set
                {
                    _current = value;
                }

            }

            object IEnumerator.Current { get => Current; }

            public void Dispose()
            {
                Console.WriteLine("Disposing");
            }

            public bool MoveNext()
            {
                Console.WriteLine("Moving next");
                if (_current >= Stop)
                {
                    return false;
                }
                _current++;
                return true;
            }

            public void Reset()
            {
                _current = Start -1;
            }
        }
    }
}
