using System;
using System.Text;
using SQRA.Infrastructure.Extensions;
using SQRA.Infrastructure.Interfaces;


namespace SQRA.Infrastructure.Models
{
    public class DataBock : IDataBlock
    {
        #region Consts
            private const int MaxBlockSize = 128;
        #endregion

        #region Private fields
            private byte[] _value = null;
        #endregion
        
        #region Constructors
            public DataBock(string jsonValue)
            {
                jsonValue.LimitValidation(DataBock.MaxBlockSize);

                this._value = Encoding.Unicode.GetBytes(jsonValue);
            }

            public DataBock(byte[] byteValue)
            {
                byteValue.LimitValidation(DataBock.MaxBlockSize);

                this._value = byteValue;
            }
        #endregion

        #region Properties

        public string JsonValue
        {
            get => this._value.ToString();
            set
            {
                value.LimitValidation(DataBock.MaxBlockSize);
                this._value = Encoding.Unicode.GetBytes(value);
            }
        }

        public byte[] ByteValue
        {
            get => this._value;
            set
            {
                value.LimitValidation(DataBock.MaxBlockSize);
                this._value = value;
            }
        }

        #endregion
        
    }
}