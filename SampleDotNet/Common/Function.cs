using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Hashing;
using System.Threading.Tasks;

namespace SampleDotNet.Common
{
    public class Function
    {
        /// <summary>
        /// HashString using CRC32 algorithm
        /// </summary>
        /// <param name="str"></param>
        /// <returns>uint hashValue</returns>
        public static uint HashStringCRC32(string str)
        {
            // Convert it into bytes array
            byte[] inputBytes = Encoding.UTF8.GetBytes(str);

            // Using Crc32 to hash recent array
            byte[] hashBytes = Crc32.Hash(inputBytes);

            // convert it into unit
            uint hashValue = BitConverter.ToUInt32(hashBytes, 0) % Common.MaxAllowUser;

            return hashValue;
        }
    }
}