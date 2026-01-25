namespace SmartCartBackend.API.Authentication;

public record ClaimsDto(string Phone, Guid SessionId, string Purpose);