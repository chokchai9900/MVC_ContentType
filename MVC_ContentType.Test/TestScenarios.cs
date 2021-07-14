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
            //normal case
            new object[] { new byte[] { 255, 216, 255 }, "testimgj.jpg", "image/jpeg" },
            new object[] { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0xD, 0xA, 0x1A, 0xA, 0x0, 0x0, 0x0, 0xD, 0x49, 0x48, 0x44, 0x52 }, "testimgp.png", "image/png" },
            new object[] { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0xD, 0xA, 0x1A, 0xA, 0x0, 0x0, 0x0, 0xD, 0x49, 0x48, 0x44, 0x52 }, ".png", "image/png" },
            //all type case
            //compress file
            new object[] { new byte[] { 0x4C, 0x5A, 0x49, 0x50 }, "testFile.lz", "application/lzip" },
            new object[] { new byte[] { 0x50, 0x4B, 0x03, 0x04 }, "testFile.zip", "application/zip" },
            new object[] { new byte[] { 0x50, 0x4B, 0x05, 0x06 }, "testFile.zip", "application/zip" },
            new object[] { new byte[] { 0x50, 0x4B, 0x07, 0x08 }, "testFile.zip", "application/zip" },
            new object[] { new byte[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x00 }, "testFile.rar", "application/vnd.rar" },
            new object[] { new byte[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x01, 0x00 }, "testFile.rar", "application/vnd.rar" },
            new object[] { new byte[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x01, 0x00 }, "testFile.rar", "application/vnd.rar" },
            new object[] { new byte[] { 0x78, 0x61, 0x72, 0x21 }, "testFile.xar", "application/x-xar" },
            new object[] { new byte[] { 0x75, 0x73, 0x74, 0x61, 0x72, 0x00, 0x30, 0x30 }, "testFile.tar", "application/x-tar" },
            new object[] { new byte[] { 0x75, 0x73, 0x74, 0x61, 0x72, 0x20, 0x20, 0x00 }, "testFile.tar", "application/x-tar" },
            new object[] { new byte[] { 0x1F, 0x8B }, "testFile.gz", "application/gzip" },
            new object[] { new byte[] { 0x1F, 0x8B }, "testFile.tar.gz", "application/gzip" },
            new object[] { new byte[] { 0xFD, 0x37, 0x7A, 0x58, 0x5A, 0x00 }, "testFile.xz", "application/x-gtar" },
            new object[] { new byte[] { 0x1F, 0x9D }, "testFile.tar.z", "application/x-gtar" },
            new object[] { new byte[] { 0x04, 0x22, 0x4D, 0x18 }, "testFile.lz4", "" },
            new object[] { new byte[] { 0x53, 0x5A, 0x44, 0x44, 0x88, 0xF0, 0x27, 0x33 }, "testFile.??_", "" },
            new object[] { new byte[] { 0x4B, 0x57, 0x41, 0x4A }, "testFile.??_", "" },
            new object[] { new byte[] { 0x53, 0x5A, 0x44, 0x44 }, "testFile.??_", "" },
            new object[] { new byte[] { 0x78, 0x01 }, "testFile.zlib", "application/zlib" },
            new object[] { new byte[] { 0x78, 0x5E }, "testFile.zlib", "application/zlib" },
            new object[] { new byte[] { 0x78, 0x9C }, "testFile.zlib", "application/zlib" },
            new object[] { new byte[] { 0x78, 0xDA }, "testFile.zlib", "application/zlib" },
            new object[] { new byte[] { 0x78, 0x20 }, "testFile.zlib", "application/zlib" },
            new object[] { new byte[] { 0x78, 0x7D }, "testFile.zlib", "application/zlib" },
            new object[] { new byte[] { 0x78, 0xBB }, "testFile.zlib", "application/zlib" },
            new object[] { new byte[] { 0x62, 0x76, 0x78, 0x32 }, "testFile.lzfse", "application/octet-stream" },
            new object[] { new byte[] { 0x52, 0x53, 0x56, 0x4B, 0x44, 0x41, 0x54, 0x41 }, "testFile.zst", "application/zstd" },
            new object[] { new byte[] { 0x2A, 0x2A, 0x41, 0x43, 0x45, 0x2A, 0x2A }, "testFile.ace", "application/x-ace-compressed" },
            new object[] { new byte[] { 0x49, 0x73, 0x5A, 0x21 }, "testFile.isz", "application/x-iso9660-image" },
            new object[] { new byte[] { 0x43, 0x44, 0x30, 0x30, 0x31 }, "testFile.iso", "application/x-iso9660-image" },
            //excutable file
            new object[] { new byte[] { 0x6B, 0x6F, 0x6C, 0x79 }, "testFile.dmg", "application/x-apple-diskimage" },
            new object[] { new byte[] { 0x5A, 0x4D }, "testFile.exe", "application/x-msdownload" },
            new object[] { new byte[] { 0x4D, 0x5A }, "testFile.dll", "application/x-msdos-program" },
            new object[] { new byte[] { 0x64, 0x65, 0x78, 0x0A, 0x30, 0x33, 0x35, 0x00 }, "testFile.dex", "application/octet-stream" },
            new object[] { new byte[] { 0x4D, 0x5A }, "testFile.dos", "application/octet-stream" },
            new object[] { new byte[] { 0x50, 0x4B, 0x03, 0x04 }, "testFile.apk", "application/vnd.android.package-archive" },
            new object[] { new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }, "testFile.msi", "application/x-msi" },
            new object[] { new byte[] { 0xFE, 0xED, 0xFA, 0xCE }, "testFile.o", "com.apple.mach-o-binary" },
            new object[] { new byte[] { 0xFE, 0xED, 0xFA, 0xCE }, "testFile.dylib", "com.apple.mach-o-binary" },
            new object[] { new byte[] { 0xFE, 0xED, 0xFA, 0xCE }, "testFile.bundle", "com.apple.mach-o-binary" },
            //document file
            new object[] { new byte[] { 0x25, 0x50, 0x44, 0x46, 0x2D, 0x31, 0x2E }, "testFile.pdf", "application/pdf" },
            new object[] { new byte[] { 0xD0, 0xCF }, "testFile.doc", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            //image file
            new object[] { new byte[] { 0xFF, 0xD8, 0xFF }, "testFile.jpg", "image/jpeg" },
            new object[] { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0xD, 0xA, 0x1A, 0xA, 0x0, 0x0, 0x0, 0xD, 0x49, 0x48, 0x44, 0x52 }, "testFile.png", "image/png" },
            new object[] { new byte[] { 0x0 }, "testFile.txt", "text/plain" },
            new object[] { new byte[] { 0xEF, 0xBB, 0xBF }, "testFile.txt", "text/plain" },
            new object[] { new byte[] { 0xFE, 0xFF }, "testFile.txt", "text/plain" },
            new object[] { new byte[] { 0xFF, 0xFE }, "testFile.txt", "text/plain" },
            new object[] { new byte[] { 0x0, 0x0, 0xFE, 0xFF }, "testFile.txt", "text/plain" },
            new object[] { new byte[] { 0xFF, 0xFE, 0x0, 0x0 }, "testFile.txt", "text/plain" },
            
        };
    }
}
