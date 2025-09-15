using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

public enum BookingTypeEnum
{
    [EnumMember(Value = "Apartment")]
    APARTMENT,
    [EnumMember(Value = "Vehicle")]
    VEHICLE,
    [EnumMember(Value = "Show")]
    SHOW
}