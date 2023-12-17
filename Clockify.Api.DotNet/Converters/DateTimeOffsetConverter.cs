using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Clockify.Api.DotNet.Converters;
internal class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
            DateTimeOffset.ParseExact(reader.GetString()!,
                "yyyy-MM-ddThh:mm:ss.fffZ", CultureInfo.InvariantCulture);

    public override void Write(
        Utf8JsonWriter writer,
        DateTimeOffset dateTimeValue,
        JsonSerializerOptions options)
    {
        var dateTimeString = dateTimeValue.ToString("yyyy-MM-ddThh:mm:ss.fffZ", CultureInfo.InvariantCulture);
        writer.WriteStringValue(dateTimeString);
    }
}
