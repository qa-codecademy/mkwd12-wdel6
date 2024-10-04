using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    public class Md5VsSha256
    {
        private const int N = 10000;
        private readonly byte[] data;

        public Md5VsSha256()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Md5() => MD5.HashData(data);

        [Benchmark]
        public byte[] Sha256() => SHA256.HashData(data);
    }

}
