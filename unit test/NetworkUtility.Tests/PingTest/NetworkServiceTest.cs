using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkUtility.Ping;

namespace NetworkUtility.Tests.PingTest
{
    public class NetworkServiceTest
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange
            var pingService = new NetworkService();

            //Act
            var result = pingService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().BeOfType<string>();
            result.Should().Be("Ping response");
            result.Should().Contain("Ping", Exactly.Once());
        }

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        public void NetworkService_PingTimeout_ReturnSum(int a, int b, int expected)
        {
            //Arrange
            var pingService = new NetworkService();

            //Act
            var result = pingService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
        }
    }
}