using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SmartCartBackend.Infrastructure.Extensions;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TProperty> HasDateTimeOffsetConversion<TProperty>(
        this PropertyBuilder<TProperty> builder) => builder.HasConversion(
        new ValueConverter<DateTimeOffset, DateTimeOffset>(
            v => v.ToUniversalTime(),
            v => v));
    
    public static PropertyBuilder<TProperty> HasDateTimeOffsetNullableConversion<TProperty>(
        this PropertyBuilder<TProperty> builder) => builder.HasConversion(
        new ValueConverter<DateTimeOffset?, DateTimeOffset?>(
            v => v.HasValue ? v.Value.ToUniversalTime() : null,
            v => v));
}