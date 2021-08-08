using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton sins = Singleton.Instance;
            sins.Add();
            sins.Write();
            Task.Run(() =>
            {
                Thread.Sleep(1200);
                Singleton dwo = Singleton.Instance;
                dwo.Write();
            });
            Console.ReadKey();
        }
    }





    public class MySingleton
        {
            private MySingleton()
        {

        }
        public static MySingleton Instance{ get { return Nested.instance; } }
        class Nested
        {
            static Nested()
            {

            }
            internal static readonly MySingleton instance = new MySingleton(); 
        }

        }



    public class LazySingleton
    {
        private static readonly Lazy<LazySingleton> lazy = new Lazy<LazySingleton>(() => new LazySingleton());
        public static LazySingleton Instance { get { return lazy.Value; } }

        private LazySingleton()
        {

        }

    }

    public sealed class Singleton
    {
        private Singleton()
        {
            inks = 0;
        }

        public int inks;
        public void Add()
        {
            inks++;
        }

        public void Write()
        {
            Console.WriteLine("Warotsc {0}", inks);
        }

        public static Singleton Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Singleton instance = new Singleton();
        }
    }
}
