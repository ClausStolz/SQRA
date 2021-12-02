using System;
using System.Collections.Generic;
using SQRA.QR.Enums;

namespace SQRA.QR.Configurations
{
    public static class ServiceInformationSize
    {
        private static readonly Dictionary<EncodingMethod, byte[]> _informationTable = new()
        {
            {
                EncodingMethod.Numeric, new byte[]
                {
                    10, 12, 14,
                }
            },
            {
                EncodingMethod.Alphanumeric, new byte[]
                {
                    9, 11, 13,
                }
            },
            {
                EncodingMethod.Byte, new byte[]
                {
                    8, 16, 16,
                }
            },
        };

        public static bool CheckCorrectionSize(EncodingMethod encodingMethod, byte version, byte size) =>
            version switch
            {
                (<= 9)  => size == _informationTable[encodingMethod][0], 
                (<= 26) => size == _informationTable[encodingMethod][1],
                (<= 40) => size == _informationTable[encodingMethod][2],
                     _  => throw new ArgumentOutOfRangeException()
            };
        
    }
}