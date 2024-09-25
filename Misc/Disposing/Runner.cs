using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disposing
{
    public static class Runner
    {
        private static Resource Resource { get; set; }

        //public static void Run()
        //{
        //    using (var resource = new Resource())
        //    {
        //        resource.Use();
        //    }
        //}

        public static void Initialize()
        {
            Resource = new Resource("default");
        }

        public static void DoSomething()
        {
            Resource.Use();
            //using (var res2 = new Resource("res2"))
            //{
            //    using (var res3 = new Resource("res3"))
            //    {
            //        using (var res4 = new Resource("res4"))
            //        {
            //            // here we can use res2, res3, res4
            //        }
            //    }
            //}

            using var res2 = new Resource("res2");
            using var res3 = new Resource("res3");
            var res4 = new Resource("res4");
            // here we can use res2, res3, res4
        }

        public static void Dispose()
        {
            Resource.Dispose();
        }
    }
}
