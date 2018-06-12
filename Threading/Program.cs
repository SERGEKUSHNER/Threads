using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Threading
{
    class Program
    {

        static Mutex mutex = new Mutex(false, "RunsMutex");
        static void writeInfile(object threadID)
        {

            mutex.WaitOne();

            using (StreamWriter sw = new StreamWriter(@"file.txt", true))
            {

                sw.Write("Tread_ID: " + threadID + ": ");
                sw.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));

                sw.Flush();
            }
            Thread.Sleep(800);
            mutex.ReleaseMutex();
        }

        public static void Main(String[] args)
        {

            for (int i = 0; i < 20; i++)
            {
                new Thread(writeInfile).Start(i);
                //Thread.Sleep(2000);
            }



        }

    }
}


