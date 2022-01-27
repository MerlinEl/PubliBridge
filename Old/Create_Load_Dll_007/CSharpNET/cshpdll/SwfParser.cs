using System;
using System.Text;
using System.IO;
using System.Drawing;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
/*
How To: Get the width and height of the SWF file using C#
Use the below SwfParser class to get the width and height of the SWF file.
This class requires ICSharpCode.SharpZipLib.dll. You can download it from here or ICSharpCode.
Use GetDimensions(String filePath) method whenever you want the dimensions of the swf file that resides on your server. 
Give the complete file path as a parameter.
Use GetDimensions(Stream stream) method whenever you want to find the swf file dimensions from the input stream 
(Ex: Asp.net file upload control's PostedFile.InputStream object.), it can be of any inputStream. 
Here you no need to save the file on to the server.
These two methods returns Rectangle object, from this object you can get width and height.

Usage:
//Use when the file resides on your server.
try
{
    SwfParser swfParser = new SwfParser();
    Rectangle rectangle = swfParser.GetDimensions(filePath); 
    int width=rectangle.Width;
    int height=rectangle.Height;
       
}
catch (Exception ex)
{
    return "There is a problem with the swf file.";
}

//Use when you want to use file upload control's input stream.(it may be any input stream)
try
{
    SwfParser swfParser = new SwfParser();
    Rectangle rectangle = swfParser.GetDimensions(uploadedfile.PostedFile.InputStream); 
    int width=rectangle.Width;
    int height=rectangle.Height;         
}
catch (Exception ex)
{
    return "There is a problem with the swf file.";
}
 */
namespace cshpdll {
    class SwfParser {
        public Rectangle GetDimensions(String filePath) {
            using (FileStream stream = File.OpenRead(filePath)) {
                return GetDimensions(stream);
            }
        }
        // Read Header info
        public Rectangle GetDimensions(Stream stream) {
            byte[] signature = new byte[8];
            byte[] rect = new byte[8];
            stream.Position = 0; // reset position if anybody call this method again
            stream.Read(signature, 0, 8);
            Stream inputStream;
            if ("CWS" == Encoding.ASCII.GetString(signature, 0, 3)) {
                inputStream = new InflaterInputStream(stream);
            } else {
                inputStream = stream;
            }

            inputStream.Read(rect, 0, 8);
            int nbits = rect[0] >> 3;
            rect[0] = (byte)(rect[0] & 0x07);
            String bits = ByteArrayToBitString(rect);
            bits = bits.Remove(0, 5);
            int[] dims = new int[4];
            for (int i = 0; i < 4; i++) {
                char[] dest = new char[nbits];
                bits.CopyTo(0, dest, 0, bits.Length > nbits ? nbits : bits.Length);
                bits = bits.Remove(0, bits.Length > nbits ? nbits : bits.Length);
                dims[i] = BitStringToInteger(new String(dest)) / 20;
            }

            return new Rectangle(0, 0, dims[1] - dims[0], dims[3] - dims[2]);
        }

        private int BitStringToInteger(String bits) {
            int converted = 0;
            for (int i = 0; i < bits.Length; i++) {
                converted = (converted << 1) + (bits[i] == '1' ? 1 : 0);
            }
            return converted;
        }

        private String ByteArrayToBitString(byte[] byteArray) {
            byte[] newByteArray = new byte[byteArray.Length];
            Array.Copy(byteArray, newByteArray, byteArray.Length);
            String converted = "";
            for (int i = 0; i < newByteArray.Length; i++) {
                for (int j = 0; j < 8; j++) {
                    converted += (newByteArray[i] & 0x80) > 0 ? "1" : "0";
                    newByteArray[i] <<= 1;
                }
            }
            return converted;
        }
    }
}
