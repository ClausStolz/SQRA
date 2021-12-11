namespace SQRA.QR.Enums
{
    /// <summary>
    /// QR code supports several ways to encode data, depending on what
    /// characters are used: numeric, alphanumeric, kanji (not supported
    /// in this implementation) and the byte encoding.
    /// </summary>
    public enum EncodingMethod
    {
        /// <summary>
        /// This type of encoding requires 10 bits per 3 characters.
        /// The entire character sequence is split into a group of 3
        /// digits, and each group (three-digit number) is converted
        /// to a 10-bit binary number and added to the bit sequence.
        /// If the total number of characters is not a multiple of 3,
        /// then if 2 characters remain at the end, the resulting
        /// two-digit number is encoded with 7 bits, and if 1 character,
        /// then 4 bits.
        /// </summary>
        Numeric = 0b0001,
        /// <summary>
        /// This type of encoding requires 11 bits per 2 characters.
        /// The entire character sequence is split into a group of 2,
        /// each symbol in the group is encoded according to the table 
        /// <see cref="SQRA.QR.Configurations.AlphanumericValue"/>, the
        /// value of the first symbol in the group is multiplied by 45
        /// and added to the value of the second symbol. The resulting
        /// number is converted to an 11-bit binary number and added to
        /// the bit sequence. If there is 1 character in the last group,
        /// then its value is immediately encoded with a 6-bit number
        /// and added to the bit sequence.
        /// </summary>
        Alphanumeric = 0b0010,
        /// <summary>
        /// This is a universal encoding method that can encode any character.
        /// The only drawback of this method is the relatively low information
        /// density. In this case, the text is encoded in any encoding
        /// (recommended in UTF-8) and the resulting byte sequence is taken
        /// unchanged.
        /// </summary>
        Byte = 0b0100
    }
}