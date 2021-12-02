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
    }
}