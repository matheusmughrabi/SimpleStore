using System;
using System.Data.SqlClient;

namespace SimpleStore.DataAccessLayer.Helpers
{
    public static class SqlCommandReader
    {
        public static DateTime? SafeGetDateTime(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDateTime(colIndex);
            return null;
        }

        public static int? SafeGetInt(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            return null;
        }

        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }
}
