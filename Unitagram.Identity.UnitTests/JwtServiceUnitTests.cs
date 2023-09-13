// using System.Security.Claims;
// using AutoFixture;
// using FluentAssertions;
// using Microsoft.Extensions.Options;
// using Moq;
// using Unitagram.Application.Contracts.Identity;
// using Unitagram.Application.Models.Identity.Jwt;
// using Unitagram.Identity.Services;
//
// namespace Unitagram.Identity.UnitTests;
//
// public class JwtServiceUnitTests
// {
//     private readonly IFixture _fixture = new Fixture();
//     private readonly IJwtService _jwtService;
//
//     public JwtServiceUnitTests()
//     {
//         var jwtSettings = new JwtSettings()
//         {
//             Issuer = "http://localhost:7164",
//             Audience = "http://localhost:4200",
//             ExpirationDays = 1,
//             Key = "this is secret key for jwt",
//             RefreshTokenValidityInDays = 7,
//         };
//
//         var optionsMock = new Mock<IOptions<JwtSettings>>();
//         optionsMock.Setup(x => x.Value).Returns(jwtSettings);
//
//         _jwtService = new JwtService(optionsMock.Object);
//     }
//
//     #region CreateJwtToken
//
//     [Fact]
//     public void CreateJwtToken_ReturnsValidJwtResponse()
//     {
//         // Arrange
//         var jwtRequest = _fixture.Build<JwtRequest>().Create();
//
//         //Act
//         var jwtResponse = _jwtService.CreateJwtToken(jwtRequest);
//
//         //Assert
//         jwtResponse.Should().BeOfType<JwtResponse>();
//         jwtResponse.Token.Should().NotBeNullOrEmpty();
//     }
//
//     #endregion
//
//     #region GetPrincipleFromJwtToken
//
//     [Fact]
//     public void GetPrincipleFromJwtToken_ValidToken_ReturnsClaimsPrincipal()
//     {
//         // Arrange
//         var jwtRequest = _fixture.Build<JwtRequest>().Create();
//         var jwtResponse = _jwtService.CreateJwtToken(jwtRequest);
//         var token = jwtResponse.Token;
//
//         // Act
//         var claimsPrincipal = _jwtService.GetPrincipleFromJwtToken(token);
//
//         // Assert
//         claimsPrincipal.Should().NotBeNull();
//         claimsPrincipal.Should().BeOfType<ClaimsPrincipal>();
//     }
//
//     #endregion
//     
//     
//
// }