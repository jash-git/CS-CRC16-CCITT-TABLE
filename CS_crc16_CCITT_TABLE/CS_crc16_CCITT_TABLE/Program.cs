﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_crc16_CCITT_TABLE
{
    class Program
    {
        static byte[] HexToBytes(string input)
        {
            byte[] result = new byte[input.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(input.Substring(2 * i, 2), 16);
            }
            return result;
        }
        static void pause()
        {
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        static void Main(string[] args)
        {
            string input = "000680010003";
            byte[] bytes = HexToBytes(input);
            string hex = Crc16CcittKermit.ComputeChecksum(bytes).ToString("x2"); ;
            Console.WriteLine("crc16_CCITT_TABLE  =>  "+hex);
            string hex1 = Crc16.ComputeChecksum(bytes).ToString("x2");
            Console.WriteLine("Crc16 =>  " + hex1); //c061
            /*
            //crc16 online
            //https://emn178.github.io/online-tools/crc16.html
            000680010003 => 81d1
            */
            pause();
        }
    }
}