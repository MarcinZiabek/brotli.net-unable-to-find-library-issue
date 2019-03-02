using System;
using System.Linq;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            // generate data
            var data = Enumerable
                .Range(0, (int)1e6)
                .Select(x => x % 256)
                .Select(x => (byte)x)
                .ToArray();
            
            // try to use Brotli.Net
            var compressed = data.Compress();
            var decompressed = compressed.Decompress();
        }
    }
}