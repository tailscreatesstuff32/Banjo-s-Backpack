// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.RomHandler
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

using System;
using System.IO;

namespace BanjoKazooieLevelEditor
{
  public static class RomHandler
  {
    public static string tmpDir = "";
    public const int TABLE_SETUPS_START = 38776;
    private static byte[] rom;

    public static byte[] Rom
    {
      set
      {
        RomHandler.rom = value;
      }
      get
      {
        return RomHandler.rom;
      }
    }

    public static int getNextPointer(int pntr_)
    {
      int num1 = (int) RomHandler.rom[pntr_] * 16777216 + (int) RomHandler.rom[pntr_ + 1] * 65536 + (int) RomHandler.rom[pntr_ + 2] * 256 + (int) RomHandler.rom[pntr_ + 3];
      int num2 = (int) RomHandler.rom[pntr_ + 8] * 16777216 + (int) RomHandler.rom[pntr_ + 1 + 8] * 65536 + (int) RomHandler.rom[pntr_ + 2 + 8] * 256 + (int) RomHandler.rom[pntr_ + 3 + 8];
      while (num1 - num2 == 0)
      {
        num2 = (int) RomHandler.rom[pntr_ + 8] * 16777216 + (int) RomHandler.rom[pntr_ + 1 + 8] * 65536 + (int) RomHandler.rom[pntr_ + 2 + 8] * 256 + (int) RomHandler.rom[pntr_ + 3 + 8];
        pntr_ += 8;
      }
      return num2;
    }

    public static byte[] DecompressFileToByteArray(int pntr)
    {
      int num1 = (int) RomHandler.rom[pntr] * 16777216 + (int) RomHandler.rom[pntr + 1] * 65536 + (int) RomHandler.rom[pntr + 2] * 256 + (int) RomHandler.rom[pntr + 3];
      int compressedSize = RomHandler.getNextPointer(pntr) - num1;
      int num2 = num1 + 68816;
      byte[] numArray = new byte[compressedSize];
      for (int index = 0; index < compressedSize; ++index)
        numArray[index] = RomHandler.rom[num2 + index];
      GECompression geCompression = new GECompression();
      byte[] Buffer = numArray;
      geCompression.SetCompressedBuffer(Buffer, Buffer.Length);
      int fileSize = 0;
      return geCompression.OutputDecompressedBuffer(ref fileSize, ref compressedSize);
    }

    public static byte[] GetDecompressedFile(int pntr, int length)
    {
      byte[] numArray = new byte[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = RomHandler.rom[pntr + index];
      return numArray;
    }

    public static void DecompressFileToHDD(int pntr)
    {
      if (File.Exists(RomHandler.tmpDir + pntr.ToString("x")))
        return;
      try
      {
        byte[] byteArray = RomHandler.DecompressFileToByteArray(pntr);
        FileStream fileStream = File.Create(RomHandler.tmpDir + pntr.ToString("x"));
        BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
        try
        {
          binaryWriter.Write(byteArray);
          binaryWriter.Close();
          fileStream.Close();
        }
        catch
        {
          binaryWriter.Close();
          fileStream.Close();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
