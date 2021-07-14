using FluentAssertions;
using Microsoft.AspNetCore.StaticFiles;
using MVC_ContentType.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace MVC_ContentType.Test
{
    public class TestScenarios
    {
        [Theory]
        [MemberData(nameof(ContentTypeData))]
        public void TestMime(byte[] inputData, string inputName,string expected)
        {
            var sut = new MimeMappingService();
            var actual = sut.Map(inputName);
            actual.Should().NotBeNull();
            actual.Should().Be(expected);
        }
        [Theory]
        [MemberData(nameof(ContentTypeData))]
        public void TestContentType(byte[] inputData, string inputName, string expected)
        {
            var sut = new MimeMappingService();
            var actual = sut.GetMimeType(inputData, inputName);
            actual.Should().NotBeNull();
            actual.Mime.Should().Be(expected);
        }
        public static IEnumerable<object[]> ContentTypeData =>
        new List<object[]>
        {
            new object[] { new byte[] { 255, 216, 255 }, "testimgj.jpg", "image/jpeg" },
            new object[] { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0xD, 0xA, 0x1A, 0xA, 0x0, 0x0, 0x0, 0xD, 0x49, 0x48, 0x44, 0x52 }, "testimgp.png", "image/png" },
            new object[] { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0xD, 0xA, 0x1A, 0xA, 0x0, 0x0, 0x0, 0xD, 0x49, 0x48, 0x44, 0x52 }, ".png", "image/png" },

            new object[] { new byte[] { 216, 255, 255 }, "testimgj.jpg", "application/octet-stream" },
            new object[] { new byte[] { 0x50, 0x89, 0x4E, 0x47, 0xD, 0xA, 0x1A, 0xA, 0x0, 0x0, 0x0, 0xD, 0x49, 0x48, 0x44, 0x52 }, "testimgp.png", "application/octet-stream" },
            new object[] { new byte[] { 0x50, 0x89, 0x4E, 0x47, 0xD, 0xA, 0x1A, 0xA, 0x0, 0x0, 0x0, 0xD, 0x49, 0x48, 0x44, 0x52 }, ".png", "application/octet-stream" },
        };
    }
}
