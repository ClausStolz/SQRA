namespace SQRA.QR.Enums
{
    /// <summary>
    /// QR codes have 4 levels of error correction,
    /// which differ in the amount of information to recover
    /// and the amount of useful information that can be recovered
    /// if the code is damaged. This enum implements all 4 levels.
    /// </summary>
    public enum CorrectionLevel
    {
        /// <summary>
        /// Allowed maximum 7% damage.
        /// </summary>
        L, 
        /// <summary>
        /// Allowed maximum 15% damage. 
        /// </summary>
        M,
        /// <summary>
        /// Allowed maximum 25% damage. 
        /// </summary>
        Q,
        /// <summary>
        /// Allowed maximum 30% damage. 
        /// </summary>
        H
    }
}