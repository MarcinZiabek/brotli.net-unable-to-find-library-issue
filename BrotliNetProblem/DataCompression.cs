using System.IO;
using System.IO.Compression;
using Brotli;

namespace TestProject1
{
    public static class DataCompression
    {
        public static byte[] Compress(this byte[] data)
        {
            using (var input = new MemoryStream(data))
            using (var output = new MemoryStream())
            using (var brotli = new BrotliStream(output, CompressionMode.Compress))
            {
                input.CopyTo(brotli);
                brotli.Close();
                return output.ToArray();
            }
        }
        
        public static byte[] Decompress(this byte[] data)
        {
            using (var input = new MemoryStream(data))
            using (var brotli = new BrotliStream(input, CompressionMode.Decompress))
            using (var output = new MemoryStream())
            {
                brotli.CopyTo(output);
                output.Seek(0, SeekOrigin.Begin);
                return output.ToArray();
            }
        }
    }
}