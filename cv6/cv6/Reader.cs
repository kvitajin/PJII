using System.Data.SqlClient;
namespace cv6 {
    public static class Reader {
        public static byte? GetByteOrNull(this SqlDataReader reader, string colName){
            return reader.IsDBNull(reader.GetOrdinal(colName))? null: (byte?)reader.GetByte(reader.GetOrdinal(colName));
        }
    }
}