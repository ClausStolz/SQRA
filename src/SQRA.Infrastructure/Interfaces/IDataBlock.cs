namespace SQRA.Infrastructure.Interfaces
{
    public interface IDataBlock
    {
        public string JsonValue { get; set; }
        
        public byte[] ByteValue { get; set; }
    }
}