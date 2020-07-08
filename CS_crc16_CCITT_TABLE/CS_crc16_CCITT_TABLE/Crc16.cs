using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_crc16_CCITT_TABLE
{
    public class Crc16ARC
    {
        //http://sanity-free.org/134/standard_crc_16_in_csharp.html
        const ushort polynomial = 0xA001;
        ushort[] table = new ushort[256];

        public ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = 0;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return crc;
        }

        public byte[] ComputeChecksumBytes(byte[] bytes)
        {
            ushort crc = ComputeChecksum(bytes);
            return BitConverter.GetBytes(crc);
        }

        public Crc16ARC()
        {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }
        }
    }

    public class CRC16_MODBUS
    {
        //https://www.itread01.com/content/1549066714.html
        public static UInt16 Cal_crc16(byte[] data, int size)
        {

            UInt32 i = 0;
            UInt16 crc = 0;
            for (i = 0; i < size; i++)
            {
                crc = UpdateCRC16(crc, data[i]);
            }
            crc = UpdateCRC16(crc, 0);
            crc = UpdateCRC16(crc, 0);

            return (UInt16)(crc);
        }
        public static UInt16 UpdateCRC16(UInt16 crcIn, byte bytee)
        {
            UInt32 crc = crcIn;
            UInt32 ins = (UInt32)bytee | 0x100;

            do
            {
                crc <<= 1;
                ins <<= 1;
                if ((ins & 0x100) == 0x100)
                {
                    ++crc;
                }
                if ((crc & 0x10000) == 0x10000)
                {
                    crc ^= 0x1021;
                }
            }
            while (!((ins & 0x10000) == 0x10000));
            return (UInt16)crc;
        }
    }
    public class Crc16
    {
        //Figure 2.7 – C Language implementation of the CRC calculation
        public static long calcrc16(byte[] dataP)
        {
	        int i, j; // Byte counter, bit counter
	        long crc16; // calculation
	        crc16 = 0000; // PRESET value
            for (i = 0; i < dataP.Length; i++) // check each Byte in the array
	        {
                crc16 ^= dataP[i];
		        for (j = 0; j < 8; j++) // test each bit in the Byte
		        {
                    if (crc16%2==1)//(crc16 & 0x0001 )
			        {
				        crc16 >>= 1;
				        crc16 ^= 0x8408; // POLYNOMIAL x^16 + x^12 + x^5 + 1
			        }
			        else
			        {
				        crc16 >>= 1;
			        }
		        }
	        }
	        return( crc16 ); // returns calculated crc (16 bits)
        }
    }
}
