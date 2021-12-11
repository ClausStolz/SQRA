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

        public static byte GetSize(EncodingMethod encodingMethod, byte version) =>
            version switch
            {
                (<= 9)  => _informationTable[encodingMethod][0], 
                (<= 26) => _informationTable[encodingMethod][1],
                (<= 40) => _informationTable[encodingMethod][2],
                _  => throw new ArgumentOutOfRangeException()
            };

        public static bool CheckCorrectionSize(EncodingMethod encodingMethod, byte version, byte size) =>
            size == GetSize(encodingMethod, version);

    }
}