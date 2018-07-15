using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploParallel
{
    class Progress<T> : IProgress<T>
    {

        private readonly Action<T> _handler;

        public Progress(Action<T> handler)
        {
            _handler = handler;
        }

        public void Report(T value)
        {
            _handler(value);
        }
    }
}
