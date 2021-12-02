using NUnit.Framework;
using SQRA.QR.Configurations;
using SQRA.QR.Enums;

namespace SQRA.QR.Test
{
    [TestFixture]
    public class TablesTest
    {
        [TestCase(CorrectionLevel.L, 255, 2)]
        [TestCase(CorrectionLevel.M, 1255, 9)]
        [TestCase(CorrectionLevel.Q, 22255, -1)]
        [TestCase(CorrectionLevel.H, 3255, 22)]
        public void GetOptimalVersionTest(CorrectionLevel correctionLevel, int size, int expectedVersion)
        {
            Assert.AreEqual(
                expectedVersion, 
                MaxInformationSize.GetOptimalVersion(correctionLevel, size)
            );
        }

        [TestCase('F', 15)]
        [TestCase(' ', 36)]
        public void GetAlphanumericValue(char value, byte expectedValue)
        {
            Assert.AreEqual(
                expectedValue,
                AlphanumericValue.GetValue(value)
            );
        }

        [TestCase(EncodingMethod.Numeric, 9, 10, true)]
        [TestCase(EncodingMethod.Numeric, 9, 11, false)]
        [TestCase(EncodingMethod.Numeric, 12, 12, true)]
        [TestCase(EncodingMethod.Numeric, 12, 10, false)]
        [TestCase(EncodingMethod.Numeric, 40, 14, true)]
        [TestCase(EncodingMethod.Numeric, 40, 10, false)]
        [TestCase(EncodingMethod.Alphanumeric, 9, 9, true)]
        [TestCase(EncodingMethod.Alphanumeric, 9, 11, false)]
        [TestCase(EncodingMethod.Alphanumeric, 12, 11, true)]
        [TestCase(EncodingMethod.Alphanumeric, 12, 10, false)]
        [TestCase(EncodingMethod.Alphanumeric, 40, 13, true)]
        [TestCase(EncodingMethod.Alphanumeric, 40, 10, false)]
        [TestCase(EncodingMethod.Byte, 9, 8, true)]
        [TestCase(EncodingMethod.Byte, 9, 11, false)]
        [TestCase(EncodingMethod.Byte, 12, 16, true)]
        [TestCase(EncodingMethod.Byte, 12, 10, false)]
        [TestCase(EncodingMethod.Byte, 40, 16, true)]
        [TestCase(EncodingMethod.Byte, 40, 10, false)]
        public void CheckCorrectionSizeTest(EncodingMethod encodingMethod, byte version, byte size, bool expectedResult)
        {
            Assert.AreEqual(
                expectedResult,
                ServiceInformationSize.CheckCorrectionSize(encodingMethod, version, size)
            );
        }
    }
}