using System;
using System.Threading;

namespace CloaksPlus
{
    class EbicConsoleStuff
    {
        public void smoothWrite(string text)
        {
            foreach (char ch in text + "\n")
            {
                Thread.Sleep(25);
                Console.Write(ch);
            }
        }
    }
}
