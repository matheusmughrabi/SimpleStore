using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

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
    }
}
