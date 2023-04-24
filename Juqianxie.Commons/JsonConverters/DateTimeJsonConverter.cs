using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juqianxie.Commons.JsonConverters
{
    internal class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        private readonly string _dateFormat;
        public DateTimeJsonConverter()
        {
            _dateFormat = "yyyy-MM-dd HH:mm:ss";
        }
        public DateTimeJsonConverter(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? str = reader.GetString();
            if (str == null) { return default(DateTime); }
            else { return DateTime.Parse(str); }
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_dateFormat));
        }
    }
}
