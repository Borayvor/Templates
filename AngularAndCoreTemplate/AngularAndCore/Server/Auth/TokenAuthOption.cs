using System;
using AngularAndCore.Common.Constants;
using Microsoft.IdentityModel.Tokens;

namespace AngularAndCore.Server.Auth
{
  public class TokenAuthOption
  {
    public static string Audience { get; } = "ExampleAudience";

    public static string Issuer { get; } = "ExampleIssuer";

    public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());

    public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(
      Key,
      SecurityAlgorithms.RsaSha256Signature);

    public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(AuthConstants.TokenTimeSpanMinutes);

    public static string TokenType { get; } = "Bearer";
  }
}
