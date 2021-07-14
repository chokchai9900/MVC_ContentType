using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ContentType.Services
{
    public class ContentType
    {
        public List<ContentTypeModel> GetType()
        {
            var data = new List<ContentTypeModel>()
            {
                new ContentTypeModel
                {
                    Name = "LZ",
                    ByteHeaders = new byte[] { 0x4C, 0x5A, 0x49, 0x50 },
                    Extension = "LZ",
                    Mime = "application/lzip"
                },
                new ContentTypeModel
                {
                    Name = "ZIP",
                    ByteHeaders = new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                    Extension = "ZIP",
                    Mime = "application/zip"
                },
                new ContentTypeModel
                {
                    Name = "ZIP",
                    ByteHeaders = new byte[] { 0x50, 0x4B, 0x05, 0x06 },
                    Extension = "ZIP",
                    Mime = "application/zip"
                },
                new ContentTypeModel
                {
                    Name = "ZIP",
                    ByteHeaders = new byte[] { 0x50, 0x4B, 0x07, 0x08 },
                    Extension = "ZIP",
                    Mime = "application/zip"
                },
                new ContentTypeModel
                {
                    Name = "RAR",
                    ByteHeaders = new byte[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x00 },
                    Extension = "RAR",
                    Mime = "application/vnd.rar"
                },
                new ContentTypeModel
                {
                    Name = "RAR",
                    ByteHeaders = new byte[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x01, 0x00 },
                    Extension = "RAR",
                    Mime = "application/vnd.rar"
                },
                new ContentTypeModel
                {
                    Name = "RAR",
                    ByteHeaders = new byte[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x01, 0x00 },
                    Extension = "RAR",
                    Mime = "application/vnd.rar"
                },
                new ContentTypeModel
                {
                    Name = "XAR",
                    ByteHeaders = new byte[] {0x78, 0x61, 0x72, 0x21},
                    Extension = "XAR",
                    Mime = "application/x-xar"
                },
                new ContentTypeModel
                {
                    Name = "TAR",
                    ByteHeaders = new byte[] {0x75, 0x73, 0x74, 0x61, 0x72, 0x00, 0x30, 0x30},
                    Extension = "TAR",
                    Mime = "application/x-tar"
                },
                new ContentTypeModel
                {
                    Name = "TAR",
                    ByteHeaders = new byte[] {0x75, 0x73, 0x74, 0x61, 0x72, 0x20, 0x20, 0x00},
                    Extension = "TAR",
                    Mime = "application/x-tar"
                },
                new ContentTypeModel
                {
                    Name = "GZ",
                    ByteHeaders = new byte[] {0x1F, 0x8B},
                    Extension = "GZ",
                    Mime = "application/gzip"
                },
                new ContentTypeModel
                {
                    Name = "TAR.GZ",
                    ByteHeaders = new byte[] {0x1F, 0x8B},
                    Extension = "TAR.GZ",
                    Mime = "application/gzip"
                },
                new ContentTypeModel
                {
                    Name = "XZ",
                    ByteHeaders = new byte[] {0xFD, 0x37, 0x7A, 0x58, 0x5A, 0x00},
                    Extension = "XZ",
                    Mime = "application/x-gtar"
                },
                new ContentTypeModel
                {
                    Name = "TAR.Z",
                    ByteHeaders = new byte[] {0x1F, 0x9D},
                    Extension = "TAR.Z",
                    Mime = "application/x-gtar"
                },
                new ContentTypeModel
                {
                    Name = "LZ4",
                    ByteHeaders = new byte[] {0x04, 0x22, 0x4D, 0x18},
                    Extension = "LZ4",
                    Mime = ""
                },
                new ContentTypeModel
                {
                    Name = "??_",
                    ByteHeaders = new byte[] {0x53, 0x5A, 0x44, 0x44, 0x88, 0xF0, 0x27, 0x33},
                    Extension = "??_",
                    Mime = ""
                },
                new ContentTypeModel
                {
                    Name = "??_",
                    ByteHeaders = new byte[] {0x4B, 0x57, 0x41, 0x4A},
                    Extension = "??_",
                    Mime = ""
                },
                new ContentTypeModel
                {
                    Name = "??_",
                    ByteHeaders = new byte[] {0x53, 0x5A, 0x44, 0x44},
                    Extension = "??_",
                    Mime = ""
                },
                new ContentTypeModel
                {
                    Name = "zlib",
                    ByteHeaders = new byte[] {0x78, 0x01},
                    Extension = "zlib",
                    Mime = "application/zlib"
                },
                new ContentTypeModel
                {
                    Name = "zlib",
                    ByteHeaders = new byte[] {0x78, 0x5E},
                    Extension = "zlib",
                    Mime = "application/zlib"
                },
                new ContentTypeModel
                {
                    Name = "zlib",
                    ByteHeaders = new byte[] {0x78, 0x9C},
                    Extension = "zlib",
                    Mime = "application/zlib"
                },
                new ContentTypeModel
                {
                    Name = "zlib",
                    ByteHeaders = new byte[] {0x78, 0xDA},
                    Extension = "zlib",
                    Mime = "application/zlib"
                },
                new ContentTypeModel
                {
                    Name = "zlib",
                    ByteHeaders = new byte[] {0x78, 0x20},
                    Extension = "zlib",
                    Mime = "application/zlib"
                },
                new ContentTypeModel
                {
                    Name = "zlib",
                    ByteHeaders = new byte[] {0x78, 0x7D},
                    Extension = "zlib",
                    Mime = "application/zlib"
                },
                new ContentTypeModel
                {
                    Name = "zlib",
                    ByteHeaders = new byte[] {0x78, 0xBB},
                    Extension = "zlib",
                    Mime = "application/zlib"
                },
                new ContentTypeModel
                {
                    Name = "lzfse",
                    ByteHeaders = new byte[] {0x62, 0x76, 0x78, 0x32},
                    Extension = "lzfse",
                    Mime = "application/octet-stream"
                },
                new ContentTypeModel
                {
                    Name = "zst",
                    ByteHeaders = new byte[] {0x52, 0x53, 0x56, 0x4B, 0x44, 0x41, 0x54, 0x41},
                    Extension = "zst",
                    Mime = "application/zstd"
                },
                new ContentTypeModel
                {
                    Name = "ace",
                    ByteHeaders = new byte[] {0x2A, 0x2A, 0x41, 0x43, 0x45, 0x2A, 0x2A},
                    Extension = "ace",
                    Mime = "application/x-ace-compressed"
                },
                new ContentTypeModel
                {
                    Name = "isz",
                    ByteHeaders = new byte[] {0x49, 0x73, 0x5A, 0x21},
                    Extension = "isz",
                    Mime = "application/x-iso9660-image"
                },
                new ContentTypeModel
                {
                    Name = "iso",
                    ByteHeaders = new byte[] {0x43, 0x44, 0x30, 0x30, 0x31},
                    Extension = "iso",
                    Mime = "application/x-iso9660-image"
                },
                new ContentTypeModel
                {
                    Name = "iso",
                    ByteHeaders = new byte[] {0x43, 0x44, 0x30, 0x30, 0x31},
                    Extension = "iso",
                    Mime = "application/x-iso9660-image"
                },
                new ContentTypeModel
                {
                    Name = "PDF",
                    ByteHeaders = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x2D, 0x31, 0x2E },
                    Extension = "PDF",
                    Mime = "application/pdf"
                },
                new ContentTypeModel
                {
                    Name = "DOC",
                    ByteHeaders = new byte[] { 0xD0, 0xCF },
                    Extension = "DOC",
                    Mime = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                },
                // Allowcate content type 
                new ContentTypeModel
                {
                    Name = "JPG",
                    ByteHeaders = new byte[] { 0xFF, 0xD8, 0xFF },
                    Extension = "JPG",
                    Mime = "image/jpeg"
                },
                new ContentTypeModel
                {
                    Name = "PNG",
                    ByteHeaders = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0xD, 0xA, 0x1A, 0xA, 0x0, 0x0, 0x0, 0xD, 0x49, 0x48, 0x44, 0x52 },
                    Extension = "PNG",
                    Mime = "image/png"
                },
                new ContentTypeModel
                {
                    Name = "TXT",
                    ByteHeaders = new byte[] { 0x0 },
                    Extension = "TXT",
                    Mime = "text/plain"
                },
                new ContentTypeModel
                {
                    Name = "TXT",
                    ByteHeaders = new byte[] { 0xEF, 0xBB, 0xBF },
                    Extension = "TXT",
                    Mime = "text/plain"
                },
                new ContentTypeModel
                {
                    Name = "TXT",
                    ByteHeaders = new byte[] { 0xFE, 0xFF },
                    Extension = "TXT",
                    Mime = "text/plain"
                },
                new ContentTypeModel
                {
                    Name = "TXT",
                    ByteHeaders = new byte[] { 0xFF, 0xFE },
                    Extension = "TXT",
                    Mime = "text/plain"
                },
                new ContentTypeModel
                {
                    Name = "TXT",
                    ByteHeaders = new byte[] { 0x0, 0x0, 0xFE, 0xFF },
                    Extension = "TXT",
                    Mime = "text/plain"
                },
                new ContentTypeModel
                {
                    Name = "TXT",
                    ByteHeaders = new byte[] { 0xFF, 0xFE, 0x0, 0x0 },
                    Extension = "TXT",
                    Mime = "text/plain"
                },
                //excutable
                new ContentTypeModel
                {
                    Name = "DMG",
                    ByteHeaders = new byte[] {0x6B, 0x6F, 0x6C, 0x79},
                    Extension = "DMG",
                    Mime = "application/x-apple-diskimage"
                },
                new ContentTypeModel
                {
                    Name = "EXE",
                    ByteHeaders = new byte[] {0x5A, 0x4D},
                    Extension = "EXE",
                    Mime = "application/x-msdownload"
                },
                new ContentTypeModel
                {
                    Name = "DLL",
                    ByteHeaders = new byte[] {0x4D, 0x5A},
                    Extension = "DLL",
                    Mime = "application/x-msdos-program"
                },
                new ContentTypeModel
                {
                    Name = "DEX",
                    ByteHeaders = new byte[] {0x64, 0x65, 0x78, 0x0A, 0x30, 0x33, 0x35, 0x00},
                    Extension = "DEX",
                    Mime = "application/octet-stream"
                },
                new ContentTypeModel
                {
                    Name = "DOS",
                    ByteHeaders = new byte[] {0x4D, 0x5A},
                    Extension = "DOS",
                    Mime = "application/octet-stream"
                },
                new ContentTypeModel
                {
                    Name = "APK",
                    ByteHeaders = new byte[] {0x50, 0x4B, 0x03, 0x04},
                    Extension = "APK",
                    Mime = "application/vnd.android.package-archive"
                },
                new ContentTypeModel
                {
                    Name = "MSI",
                    ByteHeaders = new byte[] {0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1},
                    Extension = "MSI",
                    Mime = "application/x-msi"
                },
                new ContentTypeModel
                {
                    Name = "O",
                    ByteHeaders = new byte[] {0xFE, 0xED, 0xFA, 0xCE} ,
                    Extension = "O",
                    Mime = "com.apple.mach-o-binary"
                },
                new ContentTypeModel
                {
                    Name = "DYLIB",
                    ByteHeaders = new byte[] {0xFE, 0xED, 0xFA, 0xCE} ,
                    Extension = "DYLIB",
                    Mime = "com.apple.mach-o-binary"
                },
                new ContentTypeModel
                {
                    Name = "BUNDLE",
                    ByteHeaders = new byte[] {0xFE, 0xED, 0xFA, 0xCE} ,
                    Extension = "BUNDLE",
                    Mime = "com.apple.mach-o-binary"
                },
            };

            return data;
        }
    }
    public class ContentTypeModel
    {
        public string Name { get; set; }
        public byte[] ByteHeaders { get; set; }
        public string Mime { get; set; }
        public string Extension { get; set; }
    }
}
