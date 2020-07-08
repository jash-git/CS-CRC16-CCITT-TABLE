using System;
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

            string input1 = "000680010002";
            byte[] bytes1 = HexToBytes(input1);
            string hex1 = Crc16CcittKermit.ComputeChecksum(bytes1).ToString("x2"); ;
            Console.WriteLine("crc16_CCITT_TABLE  =>  " + hex1);
            //*

            byte[] bytes2 = new byte[] { 0x01, 0x30, 0x30, 0x30, 0x31, 0x44, 0x52, 0x30, 0x35, 0x30, 0x30, 0x32, 0x36, 0x38, 0x38, 0x30, 0x30, 0x30, 0x34, 0x33, 0x41, 0x30, 0x30, 0x30, 0x35, 0x32, 0x32, 0x31, 0x37, 0x35, 0x30, 0x31, 0x31, 0x30, 0x32, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x32, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x02 };
            Crc16ARC Crc16ARC = new Crc16ARC();
            //string hex2 = CRC16_MODBUS.Cal_crc16(bytes2, bytes2.Length).ToString("x2");
            string hex2 = Crc16ARC.ComputeChecksum(bytes2).ToString("x2");
            byte[] bytesAns = Crc16ARC.ComputeChecksumBytes(bytes2);
            Console.WriteLine("Crc16ARC  =>  " + hex2);

            string hex3 = Crc16.calcrc16(bytes).ToString("x2");
            Console.WriteLine("Crc16 =>  " + hex3);

            string hex4 = Crc16.calcrc16(bytes1).ToString("x2");
            Console.WriteLine("Crc16 =>  " + hex4);

            string hex5 = Crc16.calcrc16(bytes2).ToString("x2");
            Console.WriteLine("Crc16 =>  " + hex5);
            //*/ 
            /*
            //crc16 online
            //https://emn178.github.io/online-tools/crc16.html
            000680010003 => 81d1
            */
            pause();
        }
    }
}
