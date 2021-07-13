using FluentAssertions;
using MVC_ContentType.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace MVC_ContentType.Test
{
    public class UnitTest1
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Test1(byte[] inputData,string inputName,string expected)
        {
            var sut = new MimeMappingService(null);
            var actual = sut.GetMimeType(inputData,inputName);
            actual.Should().NotBeNull();
            actual.Mime.Should().Be(expected);
        }
        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new byte[] { 255, 216, 255 }, "testimgj.jpg", "image/jpg" },
            new object[] { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0xD, 0xA, 0x1A, 0xA, 0x0, 0x0, 0x0, 0xD, 0x49, 0x48, 0x44, 0x52 }, "testimgp.png", "image/png" }
        };
    }
}
