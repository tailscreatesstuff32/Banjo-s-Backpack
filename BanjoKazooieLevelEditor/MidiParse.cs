// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.MidiParse
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

using System;
using System.IO;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public static class MidiParse
  {
    private static uint CharArrayToLong(byte[] currentSpot, int offset)
    {
      return Convert.ToUInt32((uint) ((((int) currentSpot[offset] << 8 | (int) currentSpot[offset + 1]) << 8 | (int) currentSpot[offset + 2]) << 8) | (uint) currentSpot[offset + 3]);
    }

    private static ushort CharArrayToShort(byte[] currentSpot, int offset)
    {
      return Convert.ToUInt16((int) currentSpot[offset] << 8 | (int) currentSpot[offset + 1]);
    }

    private static uint Flip32Bit(uint inLong)
    {
      return Convert.ToUInt32((uint) ((int) ((inLong & 4278190080U) >> 24) | (int) ((inLong & 16711680U) >> 8) | ((int) inLong & 65280) << 8 | ((int) inLong & (int) byte.MaxValue) << 24));
    }

    private static ushort Flip16Bit(ushort tempShort)
    {
      return Convert.ToUInt16(((int) tempShort & 65280) >> 8 | ((int) tempShort & (int) byte.MaxValue) << 8);
    }

    private static uint GetVLBytes(
      byte[] vlByteArray,
      ref int offset,
      ref uint original,
      ref byte[] altPattern,
      ref byte altOffset,
      ref byte altLength,
      bool includeFERepeats)
    {
      uint num1 = 0;
      byte vlByte1;
      while (true)
      {
        if (altPattern != null)
        {
          vlByte1 = altPattern[(int) altOffset];
          ++altOffset;
          if ((int) altOffset == (int) altLength && altPattern != null)
          {
            altPattern = (byte[]) null;
            altOffset = (byte) 0;
            altLength = (byte) 0;
          }
        }
        else
        {
          vlByte1 = vlByteArray[offset];
          ++offset;
          if (((vlByte1 != (byte) 254 ? 0 : (vlByteArray[offset] != (byte) 254 ? 1 : 0)) & (includeFERepeats ? 1 : 0)) != 0)
          {
            int vlByte2 = (int) vlByteArray[offset];
            ++offset;
            ushort uint16 = Convert.ToUInt16(vlByte2 << 8 | (int) vlByteArray[offset]);
            ++offset;
            byte vlByte3 = vlByteArray[offset];
            ++offset;
            altPattern = new byte[(int) vlByte3];
            for (int index = offset - 4 - (int) uint16; index < offset - 4 - (int) uint16 + (int) vlByte3; ++index)
              altPattern[index - (offset - 4 - (int) uint16)] = vlByteArray[index];
            altOffset = (byte) 0;
            altLength = vlByte3;
            vlByte1 = altPattern[(int) altOffset];
            ++altOffset;
          }
          else if (((vlByte1 != (byte) 254 ? 0 : (vlByteArray[offset] == (byte) 254 ? 1 : 0)) & (includeFERepeats ? 1 : 0)) != 0)
            ++offset;
          if ((int) altOffset == (int) altLength && altPattern != null)
          {
            altPattern = (byte[]) null;
            altOffset = (byte) 0;
            altLength = (byte) 0;
          }
        }
        if ((int) vlByte1 >> 7 == 1)
          num1 = num1 + (uint) vlByte1 << 8;
        else
          break;
      }
      uint num2 = num1 + (uint) vlByte1;
      original = num2;
      uint num3 = 0;
      int num4 = 0;
      int num5 = 0;
      while (true)
      {
        num3 += (uint) (((int) (num2 >> num4) & (int) sbyte.MaxValue) << num5);
        if (num4 != 24)
        {
          num4 += 8;
          num5 += 7;
        }
        else
          break;
      }
      return num3;
    }

    private static void WriteVLBytes(
      FileStream outFile,
      uint value,
      uint length,
      bool includeFERepeats)
    {
      switch (length)
      {
        case 1:
          byte num1 = (byte) (value & (uint) byte.MaxValue);
          outFile.WriteByte(num1);
          break;
        case 2:
          byte num2 = (byte) (value >> 8 & (uint) byte.MaxValue);
          outFile.WriteByte(num2);
          byte num3 = (byte) (value & (uint) byte.MaxValue);
          outFile.WriteByte(num3);
          break;
        case 3:
          byte num4 = (byte) (value >> 16 & (uint) byte.MaxValue);
          outFile.WriteByte(num4);
          byte num5 = (byte) (value >> 8 & (uint) byte.MaxValue);
          outFile.WriteByte(num5);
          byte num6 = (byte) (value & (uint) byte.MaxValue);
          outFile.WriteByte(num6);
          break;
        default:
          byte num7 = (byte) (value >> 24 & (uint) byte.MaxValue);
          outFile.WriteByte(num7);
          byte num8 = (byte) (value >> 8 & (uint) byte.MaxValue);
          outFile.WriteByte(num8);
          byte num9 = (byte) (value & (uint) byte.MaxValue);
          outFile.WriteByte(num9);
          break;
      }
    }

    private static byte ReadMidiByte(
      byte[] vlByteArray,
      ref int offset,
      ref byte[] altPattern,
      ref byte altOffset,
      ref byte altLength,
      bool includeFERepeats)
    {
      byte vlByte1;
      if (altPattern != null)
      {
        vlByte1 = altPattern[(int) altOffset];
        ++altOffset;
      }
      else
      {
        vlByte1 = vlByteArray[offset];
        ++offset;
        if (((vlByte1 != (byte) 254 ? 0 : (vlByteArray[offset] != (byte) 254 ? 1 : 0)) & (includeFERepeats ? 1 : 0)) != 0)
        {
          int vlByte2 = (int) vlByteArray[offset];
          ++offset;
          uint num = (uint) (vlByte2 << 8) | (uint) vlByteArray[offset];
          ++offset;
          byte vlByte3 = vlByteArray[offset];
          ++offset;
          altPattern = new byte[(int) vlByte3];
          for (int int32 = Convert.ToInt32((long) (offset - 4) - (long) num); (long) int32 < (long) (offset - 4) - (long) num + (long) vlByte3; ++int32)
            altPattern[(long) int32 - ((long) (offset - 4) - (long) num)] = vlByteArray[int32];
          altOffset = (byte) 0;
          altLength = vlByte3;
          vlByte1 = altPattern[(int) altOffset];
          ++altOffset;
        }
        else if (((vlByte1 != (byte) 254 ? 0 : (vlByteArray[offset] == (byte) 254 ? 1 : 0)) & (includeFERepeats ? 1 : 0)) != 0)
          ++offset;
      }
      if ((int) altOffset == (int) altLength && altPattern != null)
      {
        altPattern = (byte[]) null;
        altOffset = (byte) 0;
        altLength = (byte) 0;
      }
      return vlByte1;
    }

    private static uint ReturnVLBytes(uint value, ref uint length)
    {
      byte num1 = Convert.ToByte(value >> 21 & (uint) sbyte.MaxValue);
      byte num2 = Convert.ToByte(value >> 14 & (uint) sbyte.MaxValue);
      byte num3 = Convert.ToByte(value >> 7 & (uint) sbyte.MaxValue);
      byte num4 = Convert.ToByte(value & (uint) sbyte.MaxValue);
      if (num1 > (byte) 0)
      {
        int num5 = -2139062272 | (int) num1 << 24 | (int) num2 << 16 | (int) num3 << 8 | (int) num4;
        length = 4U;
        return (uint) num5;
      }
      if (num2 > (byte) 0)
      {
        int num5 = 8421376 | (int) num2 << 16 | (int) num3 << 8 | (int) num4;
        length = 3U;
        return (uint) num5;
      }
      if (num3 > (byte) 0)
      {
        int num5 = 32768 | (int) num3 << 8 | (int) num4;
        length = 2U;
        return (uint) num5;
      }
      length = 1U;
      return value;
    }

    private static void WriteLongToBuffer(byte[] Buffer, uint address, uint data)
    {
      Buffer[(int) address] = Convert.ToByte(data >> 24 & (uint) byte.MaxValue);
      Buffer[(int) address + 1] = Convert.ToByte(data >> 16 & (uint) byte.MaxValue);
      Buffer[(int) address + 2] = Convert.ToByte(data >> 8 & (uint) byte.MaxValue);
      Buffer[(int) address + 3] = Convert.ToByte(data & (uint) byte.MaxValue);
    }

    public static void GEMidiToMidi(
      byte[] inputMID,
      int inputSize,
      string outFileName,
      ref int numberInstruments)
    {
      numberInstruments = 0;
      try
      {
        FileStream outFile = new FileStream(outFileName, FileMode.Create, FileAccess.Write);
        if (outFile == null)
        {
          int num1 = (int) MessageBox.Show("Error outputting file", "Error");
        }
        else
        {
          uint num2 = 68;
          int num3 = 0;
          for (int offset = 0; (long) offset < (long) (num2 - 4U); offset += 4)
          {
            if (MidiParse.CharArrayToLong(inputMID, offset) != 0U)
              ++num3;
          }
          uint num4 = MidiParse.Flip32Bit(1297377380U);
          outFile.Write(BitConverter.GetBytes(num4), 0, 4);
          uint num5 = MidiParse.Flip32Bit(6U);
          outFile.Write(BitConverter.GetBytes(num5), 0, 4);
          uint num6 = MidiParse.Flip32Bit(Convert.ToUInt32(65536 | num3));
          outFile.Write(BitConverter.GetBytes(num6), 0, 4);
          ushort num7 = MidiParse.Flip16Bit(Convert.ToUInt16(MidiParse.CharArrayToLong(inputMID, 64)));
          outFile.Write(BitConverter.GetBytes(num7), 0, 2);
          int num8 = 0;
          for (int offset = 0; (long) offset < (long) (num2 - 4U); offset += 4)
          {
            uint num9 = 0;
            int index1 = 0;
            TrackEvent[] trackEventArray = new TrackEvent[1048576];
            for (int index2 = 0; index2 < 1048576; ++index2)
            {
              trackEventArray[index2] = new TrackEvent();
              trackEventArray[index2].contents = (byte[]) null;
              trackEventArray[index2].contentSize = 0;
              trackEventArray[index2].obsoleteEvent = false;
              trackEventArray[index2].deltaTime = 0U;
              trackEventArray[index2].absoluteTime = 0U;
            }
            int int32 = Convert.ToInt32(MidiParse.CharArrayToLong(inputMID, offset));
            if (int32 != 0)
            {
              uint num10 = MidiParse.Flip32Bit(1297379947U);
              outFile.Write(BitConverter.GetBytes(num10), 0, 4);
              int num11 = 0;
              byte[] altPattern = (byte[]) null;
              byte altOffset = 0;
              byte altLength = 0;
              bool flag1 = false;
              while (int32 < inputSize && !flag1)
              {
                if (index1 > 589824)
                  return;
                uint original = 0;
                uint vlBytes1 = MidiParse.GetVLBytes(inputMID, ref int32, ref original, ref altPattern, ref altOffset, ref altLength, true);
                trackEventArray[index1].deltaTime += vlBytes1;
                num9 += vlBytes1;
                trackEventArray[index1].absoluteTime = num9;
                byte num12 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                bool flag2 = num12 < (byte) 128;
                if (num12 == byte.MaxValue || flag2 && num11 == (int) byte.MaxValue)
                {
                  switch (!flag2 ? MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true) : num12)
                  {
                    case 45:
                      int num13 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                      int num14 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                      int num15 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, false);
                      int num16 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, false);
                      int num17 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, false);
                      int num18 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, false);
                      break;
                    case 46:
                      int num19 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                      if (MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true) == byte.MaxValue)
                        break;
                      break;
                    case 47:
                      trackEventArray[index1].type = byte.MaxValue;
                      trackEventArray[index1].contentSize = 2;
                      trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                      trackEventArray[index1].contents[0] = (byte) 47;
                      trackEventArray[index1].contents[1] = (byte) 0;
                      ++index1;
                      flag1 = true;
                      break;
                    case 81:
                      int num20 = ((int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true) << 8 | (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true)) << 8 | (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                      trackEventArray[index1].type = byte.MaxValue;
                      trackEventArray[index1].contentSize = 5;
                      trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                      trackEventArray[index1].contents[0] = (byte) 81;
                      trackEventArray[index1].contents[1] = (byte) 3;
                      trackEventArray[index1].contents[2] = Convert.ToByte(num20 >> 16 & (int) byte.MaxValue);
                      trackEventArray[index1].contents[3] = Convert.ToByte(num20 >> 8 & (int) byte.MaxValue);
                      trackEventArray[index1].contents[4] = Convert.ToByte(num20 & (int) byte.MaxValue);
                      ++index1;
                      double num21 = 60000000.0 / (double) num20;
                      break;
                  }
                  if (!flag2)
                    num11 = (int) num12;
                }
                else if (num12 >= (byte) 144 && num12 < (byte) 160 || flag2 && num11 >= 144 && num11 < 160)
                {
                  byte num13;
                  if (flag2)
                  {
                    trackEventArray[index1].type = Convert.ToByte(num11);
                    num13 = num12;
                    int num14 = (int) Convert.ToByte(num11);
                  }
                  else
                  {
                    trackEventArray[index1].type = num12;
                    num13 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                  }
                  byte num15 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                  uint vlBytes2 = MidiParse.GetVLBytes(inputMID, ref int32, ref original, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index1].durationTime = vlBytes2;
                  trackEventArray[index1].contentSize = 2;
                  trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                  trackEventArray[index1].contents[0] = num13;
                  trackEventArray[index1].contents[1] = num15;
                  ++index1;
                  if (!flag2)
                    num11 = (int) num12;
                }
                else if (num12 >= (byte) 176 && num12 < (byte) 192 || flag2 && num11 >= 176 && num11 < 192)
                {
                  byte num13;
                  if (flag2)
                  {
                    num13 = num12;
                    trackEventArray[index1].type = Convert.ToByte(num11);
                  }
                  else
                  {
                    num13 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index1].type = num12;
                  }
                  byte num14 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index1].contentSize = 2;
                  trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                  trackEventArray[index1].contents[0] = num13;
                  trackEventArray[index1].contents[1] = num14;
                  ++index1;
                  if (!flag2)
                    num11 = (int) num12;
                }
                else if (num12 >= (byte) 192 && num12 < (byte) 208 || flag2 && num11 >= 192 && num11 < 208)
                {
                  byte num13;
                  if (flag2)
                  {
                    num13 = num12;
                    trackEventArray[index1].type = Convert.ToByte(num11);
                  }
                  else
                  {
                    num13 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index1].type = num12;
                  }
                  trackEventArray[index1].contentSize = 1;
                  trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                  trackEventArray[index1].contents[0] = num13;
                  if ((int) num13 >= numberInstruments)
                    numberInstruments = (int) num13 + 1;
                  ++index1;
                  if (!flag2)
                    num11 = (int) num12;
                }
                else if (num12 >= (byte) 208 && num12 < (byte) 224 || flag2 && num11 >= 208 && num11 < 224)
                {
                  byte num13;
                  if (flag2)
                  {
                    num13 = num12;
                    trackEventArray[index1].type = Convert.ToByte(num11);
                  }
                  else
                  {
                    num13 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index1].type = num12;
                  }
                  trackEventArray[index1].contentSize = 1;
                  trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                  trackEventArray[index1].contents[0] = num13;
                  ++index1;
                  if (!flag2)
                    num11 = (int) num12;
                }
                else if (num12 >= (byte) 224 && num12 < (byte) 240 || flag2 && num11 >= 224 && num11 < 240)
                {
                  byte num13;
                  if (flag2)
                  {
                    num13 = num12;
                    trackEventArray[index1].type = Convert.ToByte(num11);
                  }
                  else
                  {
                    num13 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index1].type = num12;
                  }
                  byte num14 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index1].contentSize = 2;
                  trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                  trackEventArray[index1].contents[0] = num13;
                  trackEventArray[index1].contents[1] = num14;
                  ++index1;
                  if (!flag2)
                    num11 = (int) num12;
                }
              }
              for (int index2 = 0; index2 < index1; ++index2)
              {
                if (index1 > 589824)
                  return;
                TrackEvent trackEvent = trackEventArray[index2];
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160 && trackEvent.durationTime > 0U)
                {
                  uint num12 = trackEvent.absoluteTime + trackEvent.durationTime;
                  if (index2 != index1 - 1)
                  {
                    for (int index3 = index2 + 1; index3 < index1; ++index3)
                    {
                      if (trackEventArray[index3].absoluteTime > num12 && index3 != index1 - 1)
                      {
                        for (int index4 = index1 - 1; index4 >= index3; --index4)
                        {
                          trackEventArray[index4 + 1].absoluteTime = trackEventArray[index4].absoluteTime;
                          trackEventArray[index4 + 1].contentSize = trackEventArray[index4].contentSize;
                          if (trackEventArray[index4 + 1].contents != null)
                            trackEventArray[index4 + 1].contents = (byte[]) null;
                          trackEventArray[index4 + 1].contents = new byte[trackEventArray[index4].contentSize];
                          for (int index5 = 0; index5 < trackEventArray[index4].contentSize; ++index5)
                            trackEventArray[index4 + 1].contents[index5] = trackEventArray[index4].contents[index5];
                          trackEventArray[index4 + 1].deltaTime = trackEventArray[index4].deltaTime;
                          trackEventArray[index4 + 1].durationTime = trackEventArray[index4].durationTime;
                          trackEventArray[index4 + 1].obsoleteEvent = trackEventArray[index4].obsoleteEvent;
                          trackEventArray[index4 + 1].type = trackEventArray[index4].type;
                        }
                        trackEventArray[index3].type = trackEventArray[index2].type;
                        trackEventArray[index3].absoluteTime = num12;
                        trackEventArray[index3].deltaTime = trackEventArray[index3].absoluteTime - trackEventArray[index3 - 1].absoluteTime;
                        trackEventArray[index3].contentSize = trackEventArray[index2].contentSize;
                        trackEventArray[index3].durationTime = 0U;
                        trackEventArray[index3].contents = new byte[trackEventArray[index3].contentSize];
                        trackEventArray[index3].contents[0] = trackEventArray[index2].contents[0];
                        trackEventArray[index3].contents[1] = (byte) 0;
                        trackEventArray[index3 + 1].deltaTime = trackEventArray[index3 + 1].absoluteTime - trackEventArray[index3].absoluteTime;
                        int deltaTime = (int) trackEventArray[index3].deltaTime;
                        ++index1;
                        break;
                      }
                      if (index3 == index1 - 1)
                      {
                        trackEventArray[index3 + 1].absoluteTime = num12;
                        trackEventArray[index3 + 1].contentSize = trackEventArray[index3].contentSize;
                        if (trackEventArray[index3 + 1].contents != null)
                          trackEventArray[index3 + 1].contents = (byte[]) null;
                        trackEventArray[index3 + 1].contents = new byte[trackEventArray[index3].contentSize];
                        for (int index4 = 0; index4 < trackEventArray[index3].contentSize; ++index4)
                          trackEventArray[index3 + 1].contents[index4] = trackEventArray[index3].contents[index4];
                        trackEventArray[index3 + 1].deltaTime = trackEventArray[index3].deltaTime;
                        trackEventArray[index3 + 1].durationTime = trackEventArray[index3].durationTime;
                        trackEventArray[index3 + 1].obsoleteEvent = trackEventArray[index3].obsoleteEvent;
                        trackEventArray[index3 + 1].type = trackEventArray[index3].type;
                        trackEventArray[index3].type = trackEventArray[index2].type;
                        trackEventArray[index3].absoluteTime = num12;
                        trackEventArray[index3].deltaTime = trackEventArray[index3].absoluteTime - trackEventArray[index3 - 1].absoluteTime;
                        trackEventArray[index3].contentSize = trackEventArray[index2].contentSize;
                        trackEventArray[index3].durationTime = 0U;
                        trackEventArray[index3].contents = new byte[trackEventArray[index3].contentSize];
                        trackEventArray[index3].contents[0] = trackEventArray[index2].contents[0];
                        trackEventArray[index3].contents[1] = (byte) 0;
                        trackEventArray[index3 + 1].deltaTime = trackEventArray[index3 + 1].absoluteTime - trackEventArray[index3].absoluteTime;
                        ++index1;
                        break;
                      }
                    }
                  }
                  else
                  {
                    trackEventArray[index2 + 1].absoluteTime = num12;
                    trackEventArray[index2 + 1].contentSize = trackEventArray[index2].contentSize;
                    if (trackEventArray[index2 + 1].contents != null)
                      trackEventArray[index2 + 1].contents = (byte[]) null;
                    trackEventArray[index2 + 1].contents = new byte[trackEventArray[index2].contentSize];
                    for (int index3 = 0; index3 < trackEventArray[index2].contentSize; ++index3)
                      trackEventArray[index2 + 1].contents[index3] = trackEventArray[index2].contents[index3];
                    trackEventArray[index2 + 1].deltaTime = trackEventArray[index2].deltaTime;
                    trackEventArray[index2 + 1].durationTime = trackEventArray[index2].durationTime;
                    trackEventArray[index2 + 1].obsoleteEvent = trackEventArray[index2].obsoleteEvent;
                    trackEventArray[index2 + 1].type = trackEventArray[index2].type;
                    trackEventArray[index2].type = trackEventArray[index2].type;
                    trackEventArray[index2].absoluteTime = num12;
                    int num13 = (int) trackEventArray[index2].absoluteTime - (int) trackEventArray[index2 - 1].absoluteTime;
                    trackEventArray[index2].deltaTime = trackEventArray[index2].absoluteTime - trackEventArray[index2 - 1].absoluteTime;
                    trackEventArray[index2].contentSize = trackEventArray[index2].contentSize;
                    trackEventArray[index2].durationTime = 0U;
                    trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                    trackEventArray[index2].contents[0] = trackEventArray[index2].contents[0];
                    trackEventArray[index2].contents[1] = (byte) 0;
                    trackEventArray[index2 + 1].deltaTime = trackEventArray[index2 + 1].absoluteTime - trackEventArray[index2].absoluteTime;
                    int deltaTime = (int) trackEventArray[index2].deltaTime;
                    ++index1;
                  }
                }
              }
              uint num22 = 0;
              uint inLong = 0;
              byte num23 = 0;
              for (int index2 = 0; index2 < index1; ++index2)
              {
                TrackEvent trackEvent = trackEventArray[index2];
                if (trackEvent.obsoleteEvent)
                {
                  num22 += trackEvent.deltaTime;
                }
                else
                {
                  uint length = 0;
                  int num12 = (int) MidiParse.ReturnVLBytes(trackEvent.deltaTime + num22, ref length);
                  num22 = 0U;
                  uint num13 = inLong + length;
                  if ((int) trackEvent.type != (int) num23 || trackEvent.type == byte.MaxValue)
                    ++num13;
                  inLong = num13 + Convert.ToUInt32(trackEvent.contentSize);
                  num23 = trackEvent.type;
                }
              }
              uint num24 = MidiParse.Flip32Bit(inLong);
              outFile.Write(BitConverter.GetBytes(num24), 0, 4);
              uint num25 = 0;
              byte num26 = 0;
              for (int index2 = 0; index2 < index1; ++index2)
              {
                TrackEvent trackEvent = trackEventArray[index2];
                if (trackEvent.obsoleteEvent)
                {
                  num25 += trackEvent.deltaTime;
                }
                else
                {
                  uint length = 0;
                  uint num12 = MidiParse.ReturnVLBytes(trackEvent.deltaTime + num25, ref length);
                  num25 = 0U;
                  MidiParse.WriteVLBytes(outFile, num12, length, true);
                  if ((int) trackEvent.type != (int) num26 || trackEvent.type == byte.MaxValue)
                    outFile.WriteByte(trackEvent.type);
                  outFile.Write(trackEvent.contents, 0, trackEvent.contentSize);
                  num26 = trackEvent.type;
                }
              }
              for (int index2 = 0; index2 < index1; ++index2)
              {
                if (trackEventArray[index2].contents != null)
                  trackEventArray[index2].contents = (byte[]) null;
              }
            }
            ++num8;
          }
          outFile.Close();
          outFile.Dispose();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error exporting " + ex.ToString(), "Error");
      }
    }

    public static void BTMidiToMidi(
      byte[] inputMID,
      int inputSize,
      string outFileName,
      ref int numberInstruments)
    {
      numberInstruments = 0;
      try
      {
        FileStream outFile = new FileStream(outFileName, FileMode.Create, FileAccess.Write);
        if (outFile == null)
        {
          int num1 = (int) MessageBox.Show("Error outputting file", "Error");
        }
        else
        {
          int int32_1 = Convert.ToInt32(MidiParse.CharArrayToLong(inputMID, 4));
          uint num2 = MidiParse.Flip32Bit(1297377380U);
          outFile.Write(BitConverter.GetBytes(num2), 0, 4);
          uint num3 = MidiParse.Flip32Bit(6U);
          outFile.Write(BitConverter.GetBytes(num3), 0, 4);
          uint num4 = MidiParse.Flip32Bit(Convert.ToUInt32(65536 | int32_1));
          outFile.Write(BitConverter.GetBytes(num4), 0, 4);
          ushort num5 = MidiParse.Flip16Bit(Convert.ToUInt16(MidiParse.CharArrayToLong(inputMID, 0)));
          outFile.Write(BitConverter.GetBytes(num5), 0, 2);
          int num6 = 0;
          for (int index1 = 0; index1 < int32_1; ++index1)
          {
            uint num7 = 0;
            int index2 = 0;
            TrackEvent[] trackEventArray = new TrackEvent[1048576];
            for (int index3 = 0; index3 < 1048576; ++index3)
            {
              trackEventArray[index3] = new TrackEvent();
              trackEventArray[index3].contents = (byte[]) null;
              trackEventArray[index3].contentSize = 0;
              trackEventArray[index3].obsoleteEvent = false;
              trackEventArray[index3].deltaTime = 0U;
              trackEventArray[index3].absoluteTime = 0U;
            }
            int int32_2 = Convert.ToInt32(MidiParse.CharArrayToLong(inputMID, index1 * 4 + 8));
            if (int32_2 != 0)
            {
              uint num8 = MidiParse.Flip32Bit(1297379947U);
              outFile.Write(BitConverter.GetBytes(num8), 0, 4);
              int num9 = 0;
              byte[] altPattern = (byte[]) null;
              byte altOffset = 0;
              byte altLength = 0;
              bool flag1 = false;
              while (int32_2 < inputSize && !flag1)
              {
                if (index2 > 589824)
                  return;
                uint original = 0;
                uint vlBytes1 = MidiParse.GetVLBytes(inputMID, ref int32_2, ref original, ref altPattern, ref altOffset, ref altLength, true);
                trackEventArray[index2].deltaTime += vlBytes1;
                num7 += vlBytes1;
                trackEventArray[index2].absoluteTime = num7;
                byte num10 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                bool flag2 = num10 < (byte) 128;
                if (num10 == byte.MaxValue || flag2 && num9 == (int) byte.MaxValue)
                {
                  switch (!flag2 ? MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true) : num10)
                  {
                    case 45:
                      int num11 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                      int num12 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                      int num13 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, false);
                      int num14 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, false);
                      int num15 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, false);
                      int num16 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, false);
                      break;
                    case 46:
                      int num17 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                      if (MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true) == byte.MaxValue)
                        break;
                      break;
                    case 47:
                      trackEventArray[index2].type = byte.MaxValue;
                      trackEventArray[index2].contentSize = 2;
                      trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                      trackEventArray[index2].contents[0] = (byte) 47;
                      trackEventArray[index2].contents[1] = (byte) 0;
                      ++index2;
                      flag1 = true;
                      break;
                    case 81:
                      int num18 = ((int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true) << 8 | (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true)) << 8 | (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                      trackEventArray[index2].type = byte.MaxValue;
                      trackEventArray[index2].contentSize = 5;
                      trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                      trackEventArray[index2].contents[0] = (byte) 81;
                      trackEventArray[index2].contents[1] = (byte) 3;
                      trackEventArray[index2].contents[2] = Convert.ToByte(num18 >> 16 & (int) byte.MaxValue);
                      trackEventArray[index2].contents[3] = Convert.ToByte(num18 >> 8 & (int) byte.MaxValue);
                      trackEventArray[index2].contents[4] = Convert.ToByte(num18 & (int) byte.MaxValue);
                      ++index2;
                      double num19 = 60000000.0 / (double) num18;
                      break;
                  }
                  if (!flag2)
                    num9 = (int) num10;
                }
                else if (num10 >= (byte) 144 && num10 < (byte) 160 || flag2 && num9 >= 144 && num9 < 160)
                {
                  byte num11;
                  if (flag2)
                  {
                    trackEventArray[index2].type = Convert.ToByte(num9);
                    num11 = num10;
                    int num12 = (int) Convert.ToByte(num9);
                  }
                  else
                  {
                    trackEventArray[index2].type = num10;
                    num11 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                  }
                  byte num13 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                  uint vlBytes2 = MidiParse.GetVLBytes(inputMID, ref int32_2, ref original, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index2].durationTime = vlBytes2;
                  trackEventArray[index2].contentSize = 2;
                  trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                  trackEventArray[index2].contents[0] = num11;
                  trackEventArray[index2].contents[1] = num13;
                  ++index2;
                  if (!flag2)
                    num9 = (int) num10;
                }
                else if (num10 >= (byte) 176 && num10 < (byte) 192 || flag2 && num9 >= 176 && num9 < 192)
                {
                  byte num11;
                  if (flag2)
                  {
                    num11 = num10;
                    trackEventArray[index2].type = Convert.ToByte(num9);
                  }
                  else
                  {
                    num11 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index2].type = num10;
                  }
                  byte num12 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index2].contentSize = 2;
                  trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                  trackEventArray[index2].contents[0] = num11;
                  trackEventArray[index2].contents[1] = num12;
                  ++index2;
                  if (!flag2)
                    num9 = (int) num10;
                }
                else if (num10 >= (byte) 192 && num10 < (byte) 208 || flag2 && num9 >= 192 && num9 < 208)
                {
                  byte num11;
                  if (flag2)
                  {
                    num11 = num10;
                    trackEventArray[index2].type = Convert.ToByte(num9);
                  }
                  else
                  {
                    num11 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index2].type = num10;
                  }
                  trackEventArray[index2].contentSize = 1;
                  trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                  trackEventArray[index2].contents[0] = num11;
                  if ((int) num11 >= numberInstruments)
                    numberInstruments = (int) num11 + 1;
                  ++index2;
                  if (!flag2)
                    num9 = (int) num10;
                }
                else if (num10 >= (byte) 208 && num10 < (byte) 224 || flag2 && num9 >= 208 && num9 < 224)
                {
                  byte num11;
                  if (flag2)
                  {
                    num11 = num10;
                    trackEventArray[index2].type = Convert.ToByte(num9);
                  }
                  else
                  {
                    num11 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index2].type = num10;
                  }
                  trackEventArray[index2].contentSize = 1;
                  trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                  trackEventArray[index2].contents[0] = num11;
                  ++index2;
                  if (!flag2)
                    num9 = (int) num10;
                }
                else if (num10 >= (byte) 224 && num10 < (byte) 240 || flag2 && num9 >= 224 && num9 < 240)
                {
                  byte num11;
                  if (flag2)
                  {
                    num11 = num10;
                    trackEventArray[index2].type = Convert.ToByte(num9);
                  }
                  else
                  {
                    num11 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index2].type = num10;
                  }
                  byte num12 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index2].contentSize = 2;
                  trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                  trackEventArray[index2].contents[0] = num11;
                  trackEventArray[index2].contents[1] = num12;
                  ++index2;
                  if (!flag2)
                    num9 = (int) num10;
                }
              }
              for (int index3 = 0; index3 < index2; ++index3)
              {
                if (index2 > 589824)
                  return;
                TrackEvent trackEvent = trackEventArray[index3];
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160 && trackEvent.durationTime > 0U)
                {
                  uint num10 = trackEvent.absoluteTime + trackEvent.durationTime;
                  if (index3 != index2 - 1)
                  {
                    for (int index4 = index3 + 1; index4 < index2; ++index4)
                    {
                      if (trackEventArray[index4].absoluteTime > num10 && index4 != index2 - 1)
                      {
                        for (int index5 = index2 - 1; index5 >= index4; --index5)
                        {
                          trackEventArray[index5 + 1].absoluteTime = trackEventArray[index5].absoluteTime;
                          trackEventArray[index5 + 1].contentSize = trackEventArray[index5].contentSize;
                          if (trackEventArray[index5 + 1].contents != null)
                            trackEventArray[index5 + 1].contents = (byte[]) null;
                          trackEventArray[index5 + 1].contents = new byte[trackEventArray[index5].contentSize];
                          for (int index6 = 0; index6 < trackEventArray[index5].contentSize; ++index6)
                            trackEventArray[index5 + 1].contents[index6] = trackEventArray[index5].contents[index6];
                          trackEventArray[index5 + 1].deltaTime = trackEventArray[index5].deltaTime;
                          trackEventArray[index5 + 1].durationTime = trackEventArray[index5].durationTime;
                          trackEventArray[index5 + 1].obsoleteEvent = trackEventArray[index5].obsoleteEvent;
                          trackEventArray[index5 + 1].type = trackEventArray[index5].type;
                        }
                        trackEventArray[index4].type = trackEventArray[index3].type;
                        trackEventArray[index4].absoluteTime = num10;
                        trackEventArray[index4].deltaTime = trackEventArray[index4].absoluteTime - trackEventArray[index4 - 1].absoluteTime;
                        trackEventArray[index4].contentSize = trackEventArray[index3].contentSize;
                        trackEventArray[index4].durationTime = 0U;
                        trackEventArray[index4].contents = new byte[trackEventArray[index4].contentSize];
                        trackEventArray[index4].contents[0] = trackEventArray[index3].contents[0];
                        trackEventArray[index4].contents[1] = (byte) 0;
                        trackEventArray[index4 + 1].deltaTime = trackEventArray[index4 + 1].absoluteTime - trackEventArray[index4].absoluteTime;
                        int deltaTime = (int) trackEventArray[index4].deltaTime;
                        ++index2;
                        break;
                      }
                      if (index4 == index2 - 1)
                      {
                        trackEventArray[index4 + 1].absoluteTime = num10;
                        trackEventArray[index4 + 1].contentSize = trackEventArray[index4].contentSize;
                        if (trackEventArray[index4 + 1].contents != null)
                          trackEventArray[index4 + 1].contents = (byte[]) null;
                        trackEventArray[index4 + 1].contents = new byte[trackEventArray[index4].contentSize];
                        for (int index5 = 0; index5 < trackEventArray[index4].contentSize; ++index5)
                          trackEventArray[index4 + 1].contents[index5] = trackEventArray[index4].contents[index5];
                        trackEventArray[index4 + 1].deltaTime = trackEventArray[index4].deltaTime;
                        trackEventArray[index4 + 1].durationTime = trackEventArray[index4].durationTime;
                        trackEventArray[index4 + 1].obsoleteEvent = trackEventArray[index4].obsoleteEvent;
                        trackEventArray[index4 + 1].type = trackEventArray[index4].type;
                        trackEventArray[index4].type = trackEventArray[index3].type;
                        trackEventArray[index4].absoluteTime = num10;
                        trackEventArray[index4].deltaTime = trackEventArray[index4].absoluteTime - trackEventArray[index4 - 1].absoluteTime;
                        trackEventArray[index4].contentSize = trackEventArray[index3].contentSize;
                        trackEventArray[index4].durationTime = 0U;
                        trackEventArray[index4].contents = new byte[trackEventArray[index4].contentSize];
                        trackEventArray[index4].contents[0] = trackEventArray[index3].contents[0];
                        trackEventArray[index4].contents[1] = (byte) 0;
                        trackEventArray[index4 + 1].deltaTime = trackEventArray[index4 + 1].absoluteTime - trackEventArray[index4].absoluteTime;
                        ++index2;
                        break;
                      }
                    }
                  }
                  else
                  {
                    trackEventArray[index3 + 1].absoluteTime = num10;
                    trackEventArray[index3 + 1].contentSize = trackEventArray[index3].contentSize;
                    if (trackEventArray[index3 + 1].contents != null)
                      trackEventArray[index3 + 1].contents = (byte[]) null;
                    trackEventArray[index3 + 1].contents = new byte[trackEventArray[index3].contentSize];
                    for (int index4 = 0; index4 < trackEventArray[index3].contentSize; ++index4)
                      trackEventArray[index3 + 1].contents[index4] = trackEventArray[index3].contents[index4];
                    trackEventArray[index3 + 1].deltaTime = trackEventArray[index3].deltaTime;
                    trackEventArray[index3 + 1].durationTime = trackEventArray[index3].durationTime;
                    trackEventArray[index3 + 1].obsoleteEvent = trackEventArray[index3].obsoleteEvent;
                    trackEventArray[index3 + 1].type = trackEventArray[index3].type;
                    trackEventArray[index3].type = trackEventArray[index3].type;
                    trackEventArray[index3].absoluteTime = num10;
                    int num11 = (int) trackEventArray[index3].absoluteTime - (int) trackEventArray[index3 - 1].absoluteTime;
                    trackEventArray[index3].deltaTime = trackEventArray[index3].absoluteTime - trackEventArray[index3 - 1].absoluteTime;
                    trackEventArray[index3].contentSize = trackEventArray[index3].contentSize;
                    trackEventArray[index3].durationTime = 0U;
                    trackEventArray[index3].contents = new byte[trackEventArray[index3].contentSize];
                    trackEventArray[index3].contents[0] = trackEventArray[index3].contents[0];
                    trackEventArray[index3].contents[1] = (byte) 0;
                    trackEventArray[index3 + 1].deltaTime = trackEventArray[index3 + 1].absoluteTime - trackEventArray[index3].absoluteTime;
                    int deltaTime = (int) trackEventArray[index3].deltaTime;
                    ++index2;
                  }
                }
              }
              uint num20 = 0;
              uint inLong = 0;
              byte num21 = 0;
              for (int index3 = 0; index3 < index2; ++index3)
              {
                TrackEvent trackEvent = trackEventArray[index3];
                if (trackEvent.obsoleteEvent)
                {
                  num20 += trackEvent.deltaTime;
                }
                else
                {
                  uint length = 0;
                  int num10 = (int) MidiParse.ReturnVLBytes(trackEvent.deltaTime + num20, ref length);
                  num20 = 0U;
                  uint num11 = inLong + length;
                  if ((int) trackEvent.type != (int) num21 || trackEvent.type == byte.MaxValue)
                    ++num11;
                  inLong = num11 + Convert.ToUInt32(trackEvent.contentSize);
                  num21 = trackEvent.type;
                }
              }
              uint num22 = MidiParse.Flip32Bit(inLong);
              outFile.Write(BitConverter.GetBytes(num22), 0, 4);
              uint num23 = 0;
              byte num24 = 0;
              for (int index3 = 0; index3 < index2; ++index3)
              {
                TrackEvent trackEvent = trackEventArray[index3];
                if (trackEvent.obsoleteEvent)
                {
                  num23 += trackEvent.deltaTime;
                }
                else
                {
                  uint length = 0;
                  uint num10 = MidiParse.ReturnVLBytes(trackEvent.deltaTime + num23, ref length);
                  num23 = 0U;
                  MidiParse.WriteVLBytes(outFile, num10, length, true);
                  if ((int) trackEvent.type != (int) num24 || trackEvent.type == byte.MaxValue)
                    outFile.WriteByte(trackEvent.type);
                  outFile.Write(trackEvent.contents, 0, trackEvent.contentSize);
                  num24 = trackEvent.type;
                }
              }
              for (int index3 = 0; index3 < index2; ++index3)
              {
                if (trackEventArray[index3].contents != null)
                  trackEventArray[index3].contents = (byte[]) null;
              }
            }
            ++num6;
          }
          outFile.Close();
          outFile.Dispose();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error exporting " + ex.ToString(), "Error");
      }
    }

    public static bool MidiToGEFormat(
      string input,
      string output,
      bool loop,
      uint loopPoint,
      bool useRepeaters)
    {
      try
      {
        TrackEvent[,] trackEventArray = new TrackEvent[32, 65536];
        for (int index1 = 0; index1 < 32; ++index1)
        {
          for (int index2 = 0; index2 < 65536; ++index2)
            trackEventArray[index1, index2] = new TrackEvent();
        }
        int[] numArray1 = new int[32];
        for (int index = 0; index < 32; ++index)
          numArray1[index] = 0;
        string str = input;
        int int32_1 = Convert.ToInt32(new FileInfo(str).Length);
        byte[] numArray2 = File.ReadAllBytes(str);
        if (MidiParse.CharArrayToLong(numArray2, 0) != 1297377380U)
        {
          int num = (int) MessageBox.Show("Invalid midi hdr", "Error");
          return false;
        }
        int num1 = (int) MidiParse.CharArrayToLong(numArray2, 4);
        ushort num2 = MidiParse.CharArrayToShort(numArray2, 8);
        ushort num3 = MidiParse.CharArrayToShort(numArray2, 10);
        ushort num4 = MidiParse.CharArrayToShort(numArray2, 12);
        if (num3 > (ushort) 16)
        {
          int num5 = (int) MessageBox.Show("Too many tracks, truncated to 16", "Warning");
          num3 = (ushort) 16;
        }
        FileStream outFile = new FileStream(output, FileMode.Create, FileAccess.Write);
        if (outFile == null)
        {
          int num5 = (int) MessageBox.Show("Error outputting file", "Error");
          return false;
        }
        int num6 = (int) num3;
        if (num2 != (ushort) 0 && num2 != (ushort) 1)
        {
          int num5 = (int) MessageBox.Show("Invalid midi type", "Error");
          return false;
        }
        int offset = 14;
        byte[] altPattern = (byte[]) null;
        byte altOffset = 0;
        byte altLength = 0;
        bool flag1 = false;
        uint num7 = 0;
        uint[] numArray3 = new uint[16];
        for (int index = 0; index < 16; ++index)
          numArray3[index] = 0U;
        for (int index1 = 0; index1 < num6; ++index1)
        {
          uint num5 = 0;
          if (((((int) numArray2[offset] << 8 | (int) numArray2[offset + 1]) << 8 | (int) numArray2[offset + 2]) << 8 | (int) numArray2[offset + 3]) != 1297379947)
          {
            int num8 = (int) MessageBox.Show("Invalid track midi hdr", "Error");
            return false;
          }
          int num9 = (int) numArray2[offset + 4];
          int num10 = (int) numArray2[offset + 5];
          int num11 = (int) numArray2[offset + 6];
          int num12 = (int) numArray2[offset + 7];
          offset += 8;
          byte num13 = byte.MaxValue;
          bool flag2 = false;
          while (!flag2 && offset < int32_1)
          {
            uint original = 0;
            uint vlBytes = MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false);
            num5 += vlBytes;
            byte num8 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
            bool flag3 = num8 <= (byte) 127;
            if (num8 == byte.MaxValue)
            {
              byte num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              switch (num14)
              {
                case 47:
                  num5 -= vlBytes;
                  flag2 = true;
                  int num15 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                case 81:
                  int num16 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num17 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num18 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num19 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                default:
                  if (num14 < (byte) 127 && num14 != (byte) 81 && num14 != (byte) 47)
                  {
                    uint num20 = (uint) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    for (int index2 = 0; (long) index2 < (long) num20; ++index2)
                    {
                      int num21 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    break;
                  }
                  if (num14 == (byte) 127)
                  {
                    int int32_2 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
                    for (int index2 = 0; index2 < int32_2; ++index2)
                    {
                      int num20 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    break;
                  }
                  break;
              }
              num13 = num8;
            }
            else if (num8 >= (byte) 128 && num8 < (byte) 144 || flag3 && num13 >= (byte) 128 && num13 < (byte) 144)
            {
              if (!flag3)
              {
                int num14 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num15 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num13 = num8;
            }
            else if (num8 >= (byte) 144 && num8 < (byte) 160 || flag3 && num13 >= (byte) 144 && num13 < (byte) 160)
            {
              if (!flag3)
              {
                int num14 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num15 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num13 = num8;
            }
            else if (num8 >= (byte) 176 && num8 < (byte) 192 || flag3 && num13 >= (byte) 176 && num13 < (byte) 192)
            {
              if (!flag3)
              {
                int num14 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num15 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num13 = num8;
            }
            else if (num8 >= (byte) 192 && num8 < (byte) 208 || flag3 && num13 >= (byte) 192 && num13 < (byte) 208)
            {
              if (!flag3)
              {
                int num14 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              if (!flag3)
                num13 = num8;
            }
            else if (num8 >= (byte) 208 && num8 < (byte) 224 || flag3 && num13 >= (byte) 208 && num13 < (byte) 224)
            {
              if (!flag3)
              {
                int num14 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              if (!flag3)
                num13 = num8;
            }
            else if (num8 >= (byte) 224 && num8 < (byte) 240 || flag3 && num13 >= (byte) 224 && num13 < (byte) 240)
            {
              if (!flag3)
              {
                int num14 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num15 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num13 = num8;
            }
            else if (num8 == (byte) 240 || num8 == (byte) 247)
            {
              int int32_2 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
              for (int index2 = 0; index2 < int32_2; ++index2)
              {
                int num14 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
            }
            else if (!flag1)
            {
              int num14 = (int) MessageBox.Show("Invalid midi character found", "Error");
              flag1 = true;
            }
          }
          if (num5 > num7)
            num7 = num5;
          if (num5 > numArray3[index1])
            numArray3[index1] = num5;
        }
        offset = 14;
        altPattern = (byte[]) null;
        altOffset = (byte) 0;
        altLength = (byte) 0;
        for (int index1 = 0; index1 < num6; ++index1)
        {
          uint num5 = 0;
          if (((((int) numArray2[offset] << 8 | (int) numArray2[offset + 1]) << 8 | (int) numArray2[offset + 2]) << 8 | (int) numArray2[offset + 3]) != 1297379947)
          {
            int num8 = (int) MessageBox.Show("Invalid track midi hdr", "Error");
            return false;
          }
          int num9 = (int) numArray2[offset + 4];
          int num10 = (int) numArray2[offset + 5];
          int num11 = (int) numArray2[offset + 6];
          int num12 = (int) numArray2[offset + 7];
          offset += 8;
          byte num13 = byte.MaxValue;
          bool flag2 = false;
          bool flag3 = false;
          if (loop && loopPoint == 0U && numArray3[index1] > 0U)
          {
            TrackEvent trackEvent = trackEventArray[index1, numArray1[index1]];
            trackEvent.type = byte.MaxValue;
            trackEvent.absoluteTime = 0U;
            trackEvent.contentSize = 3;
            trackEvent.contents = new byte[trackEvent.contentSize];
            trackEvent.contents[0] = (byte) 46;
            trackEvent.contents[1] = (byte) 0;
            trackEvent.contents[2] = byte.MaxValue;
            trackEvent.deltaTime = 0U;
            trackEvent.obsoleteEvent = false;
            ++numArray1[index1];
            flag3 = true;
          }
          while (!flag2 && offset < int32_1)
          {
            uint original = 0;
            uint vlBytes = MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false);
            num5 += vlBytes;
            TrackEvent trackEvent1 = trackEventArray[index1, numArray1[index1]];
            trackEvent1.deltaTime = vlBytes;
            trackEvent1.obsoleteEvent = false;
            trackEvent1.contents = (byte[]) null;
            trackEvent1.absoluteTime = num5;
            if (loop && !flag3 && numArray3[index1] > loopPoint)
            {
              if ((int) num5 == (int) loopPoint)
              {
                TrackEvent trackEvent2 = trackEventArray[index1, numArray1[index1]];
                trackEvent2.type = byte.MaxValue;
                trackEvent2.absoluteTime = num5;
                trackEvent2.contentSize = 3;
                trackEvent2.contents = new byte[trackEvent2.contentSize];
                trackEvent2.contents[0] = (byte) 46;
                trackEvent2.contents[1] = (byte) 0;
                trackEvent2.contents[2] = byte.MaxValue;
                trackEvent2.deltaTime = vlBytes;
                trackEvent2.obsoleteEvent = false;
                ++numArray1[index1];
                trackEvent1 = trackEventArray[index1, numArray1[index1]];
                trackEvent1.deltaTime = 0U;
                trackEvent1.obsoleteEvent = false;
                trackEvent1.contents = (byte[]) null;
                trackEvent1.absoluteTime = num5;
                flag3 = true;
              }
              else if (num5 > loopPoint)
              {
                TrackEvent trackEvent2 = trackEventArray[index1, numArray1[index1]];
                trackEvent2.type = byte.MaxValue;
                trackEvent2.absoluteTime = loopPoint;
                trackEvent2.contentSize = 3;
                TrackEvent trackEvent3 = trackEvent2;
                trackEvent3.contents = new byte[trackEvent3.contentSize];
                trackEvent2.contents[0] = (byte) 46;
                trackEvent2.contents[1] = (byte) 0;
                trackEvent2.contents[2] = byte.MaxValue;
                trackEvent2.deltaTime = numArray1[index1] <= 0 ? loopPoint : loopPoint - trackEventArray[index1, numArray1[index1] - 1].absoluteTime;
                trackEvent2.obsoleteEvent = false;
                ++numArray1[index1];
                trackEvent1 = trackEventArray[index1, numArray1[index1]];
                trackEvent1.deltaTime = num5 - loopPoint;
                trackEvent1.obsoleteEvent = false;
                trackEvent1.contents = (byte[]) null;
                trackEvent1.absoluteTime = num5;
                flag3 = true;
              }
            }
            byte num8 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
            bool flag4 = num8 <= (byte) 127;
            if (num8 == byte.MaxValue)
            {
              byte num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              switch (num14)
              {
                case 47:
                  flag2 = true;
                  if (loop && numArray3[index1] > loopPoint)
                  {
                    TrackEvent trackEvent2 = trackEventArray[index1, numArray1[index1] - 1];
                    if (trackEvent2.type == byte.MaxValue && trackEvent2.contentSize > 0 && trackEvent2.contents[0] == (byte) 46)
                    {
                      TrackEvent trackEvent3 = trackEvent2;
                      trackEvent3.type = byte.MaxValue;
                      trackEvent3.contentSize = 1;
                      TrackEvent trackEvent4 = trackEvent3;
                      trackEvent4.contents = new byte[trackEvent4.contentSize];
                      trackEvent3.contents[0] = (byte) 47;
                    }
                    else
                    {
                      TrackEvent trackEvent3 = trackEventArray[index1, numArray1[index1] + 1];
                      trackEvent3.absoluteTime = num7;
                      trackEvent3.deltaTime = 0U;
                      trackEvent3.durationTime = trackEvent1.durationTime;
                      trackEvent3.obsoleteEvent = trackEvent1.obsoleteEvent;
                      trackEvent3.type = byte.MaxValue;
                      trackEvent3.contentSize = 1;
                      trackEvent3.contents = new byte[trackEvent3.contentSize];
                      trackEvent3.contents[0] = (byte) 47;
                      trackEvent1.type = byte.MaxValue;
                      if (num7 > trackEvent2.absoluteTime + trackEvent2.durationTime)
                      {
                        trackEvent1.deltaTime = num7 - (trackEvent2.absoluteTime + trackEvent2.durationTime);
                        trackEvent1.absoluteTime = num7;
                      }
                      else
                      {
                        trackEvent1.deltaTime = 0U;
                        trackEvent1.absoluteTime = trackEvent2.absoluteTime;
                      }
                      trackEvent1.contentSize = 7;
                      TrackEvent trackEvent4 = trackEvent1;
                      trackEvent4.contents = new byte[trackEvent4.contentSize];
                      trackEvent1.contents[0] = (byte) 45;
                      trackEvent1.contents[1] = byte.MaxValue;
                      trackEvent1.contents[2] = byte.MaxValue;
                      trackEvent1.contents[3] = (byte) 0;
                      trackEvent1.contents[4] = (byte) 0;
                      trackEvent1.contents[5] = (byte) 0;
                      trackEvent1.contents[6] = (byte) 0;
                      trackEvent1.obsoleteEvent = false;
                      ++numArray1[index1];
                    }
                  }
                  else
                  {
                    trackEvent1.type = byte.MaxValue;
                    trackEvent1.contentSize = 1;
                    TrackEvent trackEvent2 = trackEvent1;
                    trackEvent2.contents = new byte[trackEvent2.contentSize];
                    trackEvent1.contents[0] = (byte) 47;
                  }
                  int num15 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                case 81:
                  trackEvent1.type = byte.MaxValue;
                  trackEvent1.contentSize = 4;
                  TrackEvent trackEvent5 = trackEvent1;
                  trackEvent5.contents = new byte[trackEvent5.contentSize];
                  trackEvent1.contents[0] = (byte) 81;
                  int num16 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[1] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[2] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[3] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                default:
                  if (num14 < (byte) 127 && num14 != (byte) 81 && num14 != (byte) 47)
                  {
                    trackEvent1.type = byte.MaxValue;
                    uint num17 = (uint) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    for (int index2 = 0; (long) index2 < (long) num17; ++index2)
                    {
                      int num18 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    trackEvent1.obsoleteEvent = true;
                    break;
                  }
                  if (num14 == (byte) 127)
                  {
                    trackEvent1.type = byte.MaxValue;
                    int int32_2 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
                    for (int index2 = 0; index2 < int32_2; ++index2)
                    {
                      int num17 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    trackEvent1.obsoleteEvent = true;
                    break;
                  }
                  break;
              }
              num13 = num8;
            }
            else if (num8 >= (byte) 128 && num8 < (byte) 144 || flag4 && num13 >= (byte) 128 && num13 < (byte) 144)
            {
              byte num14;
              byte num15;
              if (flag4)
              {
                trackEvent1.type = num13;
                num14 = num8;
                num15 = num13;
              }
              else
              {
                trackEvent1.type = num8;
                num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                num15 = num8;
              }
              byte num16 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              for (int index2 = numArray1[index1] - 1; index2 >= 0; --index2)
              {
                if ((int) trackEventArray[index1, index2].type == (144 | (int) num15 & 15) && !trackEventArray[index1, index2].obsoleteEvent && (int) trackEventArray[index1, index2].contents[0] == (int) num14)
                {
                  trackEventArray[index1, index2].durationTime = num5 - trackEventArray[index1, index2].absoluteTime;
                  break;
                }
              }
              trackEvent1.durationTime = 0U;
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent2 = trackEvent1;
              trackEvent2.contents = new byte[trackEvent2.contentSize];
              trackEvent1.contents[0] = num14;
              trackEvent1.contents[1] = num16;
              trackEvent1.obsoleteEvent = true;
              if (!flag4)
                num13 = num8;
            }
            else if (num8 >= (byte) 144 && num8 < (byte) 160 || flag4 && num13 >= (byte) 144 && num13 < (byte) 160)
            {
              byte num14;
              byte num15;
              if (flag4)
              {
                trackEvent1.type = num13;
                num14 = num8;
                num15 = num13;
              }
              else
              {
                trackEvent1.type = num8;
                num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                num15 = num8;
              }
              byte num16 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (num16 == (byte) 0)
              {
                for (int index2 = numArray1[index1] - 1; index2 >= 0; --index2)
                {
                  if ((int) trackEventArray[index1, index2].type == (int) num15 && !trackEventArray[index1, index2].obsoleteEvent && (int) trackEventArray[index1, index2].contents[0] == (int) num14)
                  {
                    trackEventArray[index1, index2].durationTime = num5 - trackEventArray[index1, index2].absoluteTime;
                    break;
                  }
                }
                trackEvent1.durationTime = 0U;
                trackEvent1.contentSize = 2;
                TrackEvent trackEvent2 = trackEvent1;
                trackEvent2.contents = new byte[trackEvent2.contentSize];
                trackEvent1.contents[0] = num14;
                trackEvent1.contents[1] = num16;
                trackEvent1.obsoleteEvent = true;
              }
              else
              {
                for (int index2 = numArray1[index1] - 1; index2 >= 0; --index2)
                {
                  if ((int) trackEventArray[index1, index2].type == (int) num15 && !trackEventArray[index1, index2].obsoleteEvent && (int) trackEventArray[index1, index2].contents[0] == (int) num14)
                  {
                    if (trackEventArray[index1, index2].durationTime == 0U)
                    {
                      trackEventArray[index1, index2].durationTime = num5 - trackEventArray[index1, index2].absoluteTime;
                      break;
                    }
                    break;
                  }
                }
                trackEvent1.durationTime = 0U;
                trackEvent1.contentSize = 2;
                TrackEvent trackEvent2 = trackEvent1;
                trackEvent2.contents = new byte[trackEvent2.contentSize];
                trackEvent1.contents[0] = num14;
                trackEvent1.contents[1] = num16;
              }
              if (!flag4)
                num13 = num8;
            }
            else if (num8 >= (byte) 176 && num8 < (byte) 192 || flag4 && num13 >= (byte) 176 && num13 < (byte) 192)
            {
              byte num14;
              if (flag4)
              {
                num14 = num8;
                trackEvent1.type = num13;
              }
              else
              {
                num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num8;
              }
              byte num15 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent2 = trackEvent1;
              trackEvent2.contents = new byte[trackEvent2.contentSize];
              trackEvent1.contents[0] = num14;
              trackEvent1.contents[1] = num15;
              if (!flag4)
                num13 = num8;
            }
            else if (num8 >= (byte) 192 && num8 < (byte) 208 || flag4 && num13 >= (byte) 192 && num13 < (byte) 208)
            {
              byte num14;
              if (flag4)
              {
                num14 = num8;
                trackEvent1.type = num13;
              }
              else
              {
                num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num8;
              }
              trackEvent1.contentSize = 1;
              TrackEvent trackEvent2 = trackEvent1;
              trackEvent2.contents = new byte[trackEvent2.contentSize];
              trackEvent1.contents[0] = num14;
              if (!flag4)
                num13 = num8;
            }
            else if (num8 >= (byte) 208 && num8 < (byte) 224 || flag4 && num13 >= (byte) 208 && num13 < (byte) 224)
            {
              trackEvent1.type = num8;
              byte num14;
              if (flag4)
              {
                num14 = num8;
                trackEvent1.type = num13;
              }
              else
              {
                num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num8;
              }
              trackEvent1.contentSize = 1;
              TrackEvent trackEvent2 = trackEvent1;
              trackEvent2.contents = new byte[trackEvent2.contentSize];
              trackEvent1.contents[0] = num14;
              if (!flag4)
                num13 = num8;
            }
            else if (num8 >= (byte) 224 && num8 < (byte) 240 || flag4 && num13 >= (byte) 224 && num13 < (byte) 240)
            {
              trackEvent1.type = num8;
              byte num14;
              if (flag4)
              {
                num14 = num8;
                trackEvent1.type = num13;
              }
              else
              {
                num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num8;
              }
              byte num15 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent2 = trackEvent1;
              trackEvent2.contents = new byte[trackEvent2.contentSize];
              trackEvent1.contents[0] = num14;
              trackEvent1.contents[1] = num15;
              if (!flag4)
                num13 = num8;
            }
            else if (num8 == (byte) 240 || num8 == (byte) 247)
            {
              trackEvent1.type = num8;
              int int32_2 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
              for (int index2 = 0; index2 < int32_2; ++index2)
              {
                int num14 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              trackEvent1.obsoleteEvent = true;
            }
            else if (!flag1)
            {
              int num14 = (int) MessageBox.Show("Invalid midi character found", "Error");
              flag1 = true;
            }
            ++numArray1[index1];
          }
        }
        uint num22 = 0;
        uint inLong = 68;
        for (int index1 = 0; index1 < num6; ++index1)
        {
          uint num5 = 0;
          int num8 = 0;
          byte num9 = 0;
          if (numArray1[index1] > 0)
          {
            uint num10 = MidiParse.Flip32Bit(inLong);
            outFile.Write(BitConverter.GetBytes(num10), 0, 4);
            for (int index2 = 0; index2 < numArray1[index1]; ++index2)
            {
              TrackEvent trackEvent = trackEventArray[index1, index2];
              uint length1 = 0;
              int num11 = (int) MidiParse.ReturnVLBytes(trackEvent.deltaTime + num22, ref length1);
              if (trackEvent.obsoleteEvent)
              {
                num22 += trackEvent.deltaTime;
              }
              else
              {
                if (trackEvent.type == byte.MaxValue && trackEvent.contents[0] == (byte) 46)
                  num8 = Convert.ToInt32((long) (uint) ((int) inLong + (int) num5 + 1) + (long) trackEvent.contentSize + (long) length1);
                num22 = 0U;
                uint num12 = num5 + length1;
                if (trackEvent.type == byte.MaxValue && trackEvent.contents[0] == (byte) 45)
                {
                  uint uint32 = Convert.ToUInt32((long) (inLong + num12) - (long) num8 + 8L);
                  trackEvent.contents[3] = Convert.ToByte(uint32 >> 24 & (uint) byte.MaxValue);
                  trackEvent.contents[4] = Convert.ToByte(uint32 >> 16 & (uint) byte.MaxValue);
                  trackEvent.contents[5] = Convert.ToByte(uint32 >> 8 & (uint) byte.MaxValue);
                  trackEvent.contents[6] = Convert.ToByte(uint32 & (uint) byte.MaxValue);
                }
                if ((int) trackEvent.type != (int) num9 || trackEvent.type == byte.MaxValue)
                  ++num12;
                num5 = num12 + Convert.ToUInt32(trackEvent.contentSize);
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160)
                {
                  uint length2 = 0;
                  int num13 = (int) MidiParse.ReturnVLBytes(trackEvent.durationTime, ref length2);
                  num5 += length2;
                }
                num9 = trackEvent.type;
              }
            }
            inLong += num5;
          }
          else
          {
            uint num10 = 0;
            outFile.Write(BitConverter.GetBytes(num10), 0, 4);
          }
        }
        for (int index = num6; index < 16; ++index)
        {
          uint num5 = 0;
          outFile.Write(BitConverter.GetBytes(num5), 0, 4);
        }
        uint num23 = MidiParse.Flip32Bit((uint) num4);
        outFile.Write(BitConverter.GetBytes(num23), 0, 4);
        for (int index1 = 0; index1 < num6; ++index1)
        {
          if (numArray1[index1] > 0)
          {
            byte num5 = 0;
            for (int index2 = 0; index2 < numArray1[index1]; ++index2)
            {
              TrackEvent trackEvent = trackEventArray[index1, index2];
              if (trackEvent.obsoleteEvent)
              {
                num22 += trackEvent.deltaTime;
              }
              else
              {
                uint length1 = 0;
                uint num8 = MidiParse.ReturnVLBytes(trackEvent.deltaTime + num22, ref length1);
                num22 = 0U;
                MidiParse.WriteVLBytes(outFile, num8, length1, false);
                if ((int) trackEvent.type != (int) num5 || trackEvent.type == byte.MaxValue)
                  outFile.WriteByte(trackEvent.type);
                outFile.Write(trackEvent.contents, 0, trackEvent.contentSize);
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160)
                {
                  uint length2 = 0;
                  uint num9 = MidiParse.ReturnVLBytes(trackEvent.durationTime, ref length2);
                  MidiParse.WriteVLBytes(outFile, num9, length2, false);
                }
                num5 = trackEvent.type;
              }
            }
          }
          for (int index2 = 0; index2 < numArray1[index1]; ++index2)
          {
            if (trackEventArray[index1, index2].contents != null)
              trackEventArray[index1, index2].contents = (byte[]) null;
          }
        }
        outFile.Close();
        outFile.Dispose();
        int int32_3 = Convert.ToInt32(new FileInfo(output).Length);
        byte[] Buffer1 = File.ReadAllBytes(output);
        uint[] numArray4 = new uint[16];
        int[] numArray5 = new int[16];
        for (int index = 0; index < 64; index += 4)
        {
          numArray4[index / 4] = (uint) ((((int) Buffer1[index] << 8 | (int) Buffer1[index + 1]) << 8 | (int) Buffer1[index + 2]) << 8) | (uint) Buffer1[index + 3];
          numArray5[index / 4] = 0;
        }
        for (int index1 = 0; index1 < int32_3; ++index1)
        {
          if (index1 > 68 && Buffer1[index1] == (byte) 254)
          {
            for (int index2 = 0; index2 < num6; ++index2)
            {
              if ((long) numArray4[index2] > (long) index1)
                ++numArray5[index2];
            }
          }
        }
        FileStream fileStream1 = new FileStream(output, FileMode.Create, FileAccess.Write);
        for (int index = 0; index < 16; ++index)
          MidiParse.WriteLongToBuffer(Buffer1, Convert.ToUInt32(index * 4), numArray4[index] + Convert.ToUInt32(numArray5[index]));
        for (int index = 0; index < int32_3; ++index)
        {
          fileStream1.WriteByte(Buffer1[index]);
          if (index > 68 && Buffer1[index] == (byte) 254)
            fileStream1.WriteByte(Buffer1[index]);
        }
        fileStream1.Close();
        fileStream1.Dispose();
        byte[] numArray6 = (byte[]) null;
        if (useRepeaters)
        {
          int int32_2 = Convert.ToInt32(new FileInfo(output).Length);
          byte[] numArray7 = File.ReadAllBytes(output);
          uint[] numArray8 = new uint[16];
          for (int index = 0; index < 64; index += 4)
            numArray8[index / 4] = (uint) ((((int) numArray7[index] << 8 | (int) numArray7[index + 1]) << 8 | (int) numArray7[index + 2]) << 8) | (uint) numArray7[index + 3];
          uint data = (uint) ((((int) numArray7[64] << 8 | (int) numArray7[65]) << 8 | (int) numArray7[66]) << 8) | (uint) numArray7[67];
          byte[] Buffer2 = new byte[int32_2 * 4];
          for (int index = 0; index < int32_2 * 4; ++index)
            Buffer2[index] = (byte) 0;
          uint[] numArray9 = new uint[16];
          for (int index = 0; index < 16; ++index)
            numArray9[index] = 0U;
          int num5 = 68;
          for (int index1 = 0; index1 < 16 && numArray8[index1] != 0U; ++index1)
          {
            numArray9[index1] = Convert.ToUInt32(num5);
            int num8 = num5;
            int num9 = int32_2;
            if (index1 < 15 && numArray8[index1 + 1] != 0U)
              num9 = Convert.ToInt32(numArray8[index1 + 1]);
            int int32_4 = Convert.ToInt32(numArray8[index1]);
            while (int32_4 < num9)
            {
              int num10 = -1;
              int num11 = -1;
              for (int index2 = num8; index2 < num5; ++index2)
              {
                int num12;
                for (num12 = 0; (int) Buffer2[index2 + num12] == (int) numArray7[int32_4 + num12] && int32_4 + num12 < num9 && (Buffer2[index2 + num12] != (byte) 254 && Buffer2[index2 + num12] != byte.MaxValue) && index2 + num12 < num5; ++num12)
                {
                  bool flag2 = false;
                  for (int index3 = int32_4 + num12; index3 < num9 && index3 < int32_4 + num12 + 5; ++index3)
                  {
                    if (numArray7[index3] == byte.MaxValue)
                      flag2 = true;
                  }
                  if (flag2)
                    break;
                }
                if (num12 > num11 && num12 > 6)
                {
                  num11 = num12;
                  num10 = index2;
                }
              }
              Convert.ToInt32(((long) int32_4 - (long) numArray8[index1]) / 2L);
              if (num11 > 6)
              {
                if (num11 > 253)
                  num11 = 253;
                byte[] numArray10 = Buffer2;
                int index2 = num5;
                int num12 = index2 + 1;
                numArray10[index2] = (byte) 254;
                int num13 = num12 - num10 - 1;
                byte[] numArray11 = Buffer2;
                int index3 = num12;
                int num14 = index3 + 1;
                int num15 = (int) Convert.ToByte(num13 >> 8 & (int) byte.MaxValue);
                numArray11[index3] = (byte) num15;
                byte[] numArray12 = Buffer2;
                int index4 = num14;
                int num16 = index4 + 1;
                int num17 = (int) Convert.ToByte(num13 & (int) byte.MaxValue);
                numArray12[index4] = (byte) num17;
                byte[] numArray13 = Buffer2;
                int index5 = num16;
                num5 = index5 + 1;
                int num18 = (int) Convert.ToByte(num11);
                numArray13[index5] = (byte) num18;
                int32_4 += num11;
              }
              else
              {
                Buffer2[num5++] = numArray7[int32_4];
                ++int32_4;
              }
            }
            if (num5 % 4 != 0)
              num5 += 4 - num5 % 4;
          }
          for (int index = 0; index < 16; ++index)
          {
            if (numArray9[index] != 0U)
            {
              Convert.ToInt32(numArray9[index]);
              int num8 = num5;
              if (index < 15 && numArray9[index + 1] != 0U)
                num8 = Convert.ToInt32(numArray9[index + 1]);
              int int32_4 = Convert.ToInt32(numArray9[index]);
              bool flag2 = false;
              int num9 = 0;
              while (int32_4 < num8)
              {
                if (Buffer2[int32_4] == byte.MaxValue && Buffer2[int32_4 + 1] == (byte) 46 && (Buffer2[int32_4 + 2] == (byte) 0 && Buffer2[int32_4 + 3] == byte.MaxValue))
                {
                  flag2 = true;
                  num9 = int32_4 + 4;
                  int32_4 += 4;
                }
                else if (Buffer2[int32_4] == byte.MaxValue && Buffer2[int32_4 + 1] == (byte) 45 && (Buffer2[int32_4 + 2] == byte.MaxValue && Buffer2[int32_4 + 3] == byte.MaxValue))
                {
                  if (flag2)
                  {
                    int num10 = int32_4 + 8 - num9;
                    MidiParse.WriteLongToBuffer(Buffer2, Convert.ToUInt32(int32_4 + 4), Convert.ToUInt32(num10));
                    flag2 = false;
                  }
                  int32_4 += 8;
                }
                else
                  ++int32_4;
              }
            }
          }
          for (int index = 0; index < 16; ++index)
            MidiParse.WriteLongToBuffer(Buffer2, Convert.ToUInt32(index * 4), Convert.ToUInt32(numArray9[index]));
          MidiParse.WriteLongToBuffer(Buffer2, 64U, data);
          FileStream fileStream2 = new FileStream(output, FileMode.Create, FileAccess.Write);
          for (int index = 0; index < num5; ++index)
            fileStream2.WriteByte(Buffer2[index]);
          fileStream2.Close();
          fileStream2.Dispose();
          numArray6 = (byte[]) null;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error converting " + ex.ToString(), "Error");
        return false;
      }
      return true;
    }

    public static bool MidiToBTFormat(
      string input,
      string output,
      bool loop,
      uint loopPoint,
      bool useRepeaters)
    {
      string str = output + "temp.bin";
      ushort numTracks = 32;
      if (!MidiParse.MidiToBTFormatStageOne(input, str, loop, loopPoint, useRepeaters, ref numTracks))
        return false;
      int int32 = Convert.ToInt32(new FileInfo(str).Length);
      byte[] currentSpot = File.ReadAllBytes(str);
      File.Delete(str);
      FileStream fileStream = new FileStream(output, FileMode.Create, FileAccess.Write);
      uint inLong = MidiParse.CharArrayToLong(currentSpot, 128);
      uint[] numArray = new uint[32];
      for (int index = 0; index < 128; index += 4)
      {
        numArray[index / 4] = (uint) ((((int) currentSpot[index] << 8 | (int) currentSpot[index + 1]) << 8 | (int) currentSpot[index + 2]) << 8) | (uint) currentSpot[index + 3];
        if (numArray[index / 4] == 0U)
          break;
      }
      uint uint32 = Convert.ToUInt32(132 - ((int) numTracks * 4 + 8));
      uint num1 = MidiParse.Flip32Bit(inLong);
      fileStream.Write(BitConverter.GetBytes(num1), 0, 4);
      uint num2 = MidiParse.Flip32Bit((uint) numTracks);
      fileStream.Write(BitConverter.GetBytes(num2), 0, 4);
      for (int index = 0; index < (int) numTracks; ++index)
      {
        uint num3 = MidiParse.Flip32Bit(numArray[index] - uint32);
        fileStream.Write(BitConverter.GetBytes(num3), 0, 4);
      }
      for (int index = 132; index < int32; ++index)
        fileStream.WriteByte(currentSpot[index]);
      fileStream.Close();
      fileStream.Dispose();
      return true;
    }

    private static bool MidiToBTFormatStageOne(
      string input,
      string output,
      bool loop,
      uint loopPoint,
      bool useRepeaters,
      ref ushort numTracks)
    {
      try
      {
        TrackEvent[,] trackEventArray = new TrackEvent[32, 65536];
        for (int index1 = 0; index1 < 32; ++index1)
        {
          for (int index2 = 0; index2 < 65536; ++index2)
            trackEventArray[index1, index2] = new TrackEvent();
        }
        int[] numArray1 = new int[32];
        for (int index = 0; index < 32; ++index)
          numArray1[index] = 0;
        string str = input;
        int int32_1 = Convert.ToInt32(new FileInfo(str).Length);
        byte[] numArray2 = File.ReadAllBytes(str);
        if (MidiParse.CharArrayToLong(numArray2, 0) != 1297377380U)
        {
          int num = (int) MessageBox.Show("Invalid midi hdr", "Error");
          return false;
        }
        int num1 = (int) MidiParse.CharArrayToLong(numArray2, 4);
        ushort num2 = MidiParse.CharArrayToShort(numArray2, 8);
        numTracks = MidiParse.CharArrayToShort(numArray2, 10);
        ushort num3 = MidiParse.CharArrayToShort(numArray2, 12);
        if (numTracks > (ushort) 32)
        {
          int num4 = (int) MessageBox.Show("Too many tracks, truncated to 32", "Warning");
          numTracks = (ushort) 32;
        }
        int uint32_1 = (int) Convert.ToUInt32(132 - ((int) numTracks * 4 + 8));
        FileStream outFile = new FileStream(output, FileMode.Create, FileAccess.Write);
        if (outFile == null)
        {
          int num4 = (int) MessageBox.Show("Error outputting file", "Error");
          return false;
        }
        if (num2 != (ushort) 0 && num2 != (ushort) 1)
        {
          int num4 = (int) MessageBox.Show("Invalid midi type", "Error");
          return false;
        }
        int offset = 14;
        byte[] altPattern = (byte[]) null;
        byte altOffset = 0;
        byte altLength = 0;
        bool flag1 = false;
        uint num5 = 0;
        uint[] numArray3 = new uint[32];
        for (int index = 0; index < 32; ++index)
          numArray3[index] = 0U;
        for (int index1 = 0; index1 < (int) numTracks; ++index1)
        {
          uint num4 = 0;
          if (((((int) numArray2[offset] << 8 | (int) numArray2[offset + 1]) << 8 | (int) numArray2[offset + 2]) << 8 | (int) numArray2[offset + 3]) != 1297379947)
          {
            int num6 = (int) MessageBox.Show("Invalid track midi hdr", "Error");
            return false;
          }
          int num7 = (int) numArray2[offset + 4];
          int num8 = (int) numArray2[offset + 5];
          int num9 = (int) numArray2[offset + 6];
          int num10 = (int) numArray2[offset + 7];
          offset += 8;
          byte num11 = byte.MaxValue;
          bool flag2 = false;
          while (!flag2 && offset < int32_1)
          {
            uint original = 0;
            uint vlBytes = MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false);
            num4 += vlBytes;
            byte num6 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
            bool flag3 = num6 <= (byte) 127;
            if (num6 == byte.MaxValue)
            {
              byte num12 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              switch (num12)
              {
                case 47:
                  num4 -= vlBytes;
                  flag2 = true;
                  int num13 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                case 81:
                  int num14 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num15 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num16 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num17 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                default:
                  if (num12 < (byte) 127 && num12 != (byte) 81 && num12 != (byte) 47)
                  {
                    uint num18 = (uint) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    for (int index2 = 0; (long) index2 < (long) num18; ++index2)
                    {
                      int num19 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    break;
                  }
                  if (num12 == (byte) 127)
                  {
                    int int32_2 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
                    for (int index2 = 0; index2 < int32_2; ++index2)
                    {
                      int num18 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    break;
                  }
                  break;
              }
              num11 = num6;
            }
            else if (num6 >= (byte) 128 && num6 < (byte) 144 || flag3 && num11 >= (byte) 128 && num11 < (byte) 144)
            {
              if (!flag3)
              {
                int num12 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num13 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num11 = num6;
            }
            else if (num6 >= (byte) 144 && num6 < (byte) 160 || flag3 && num11 >= (byte) 144 && num11 < (byte) 160)
            {
              if (!flag3)
              {
                int num12 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num13 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num11 = num6;
            }
            else if (num6 >= (byte) 176 && num6 < (byte) 192 || flag3 && num11 >= (byte) 176 && num11 < (byte) 192)
            {
              if (!flag3)
              {
                int num12 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num13 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num11 = num6;
            }
            else if (num6 >= (byte) 192 && num6 < (byte) 208 || flag3 && num11 >= (byte) 192 && num11 < (byte) 208)
            {
              if (!flag3)
              {
                int num12 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              if (!flag3)
                num11 = num6;
            }
            else if (num6 >= (byte) 208 && num6 < (byte) 224 || flag3 && num11 >= (byte) 208 && num11 < (byte) 224)
            {
              if (!flag3)
              {
                int num12 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              if (!flag3)
                num11 = num6;
            }
            else if (num6 >= (byte) 224 && num6 < (byte) 240 || flag3 && num11 >= (byte) 224 && num11 < (byte) 240)
            {
              if (!flag3)
              {
                int num12 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num13 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num11 = num6;
            }
            else if (num6 == (byte) 240 || num6 == (byte) 247)
            {
              int int32_2 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
              for (int index2 = 0; index2 < int32_2; ++index2)
              {
                int num12 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
            }
            else if (!flag1)
            {
              int num12 = (int) MessageBox.Show("Invalid midi character found", "Error");
              flag1 = true;
            }
          }
          if (num4 > num5)
            num5 = num4;
          if (num4 > numArray3[index1])
            numArray3[index1] = num4;
        }
        offset = 14;
        altPattern = (byte[]) null;
        altOffset = (byte) 0;
        altLength = (byte) 0;
        for (int index1 = 0; index1 < (int) numTracks; ++index1)
        {
          uint num4 = 0;
          if (((((int) numArray2[offset] << 8 | (int) numArray2[offset + 1]) << 8 | (int) numArray2[offset + 2]) << 8 | (int) numArray2[offset + 3]) != 1297379947)
          {
            int num6 = (int) MessageBox.Show("Invalid track midi hdr", "Error");
            return false;
          }
          int num7 = (int) numArray2[offset + 4];
          int num8 = (int) numArray2[offset + 5];
          int num9 = (int) numArray2[offset + 6];
          int num10 = (int) numArray2[offset + 7];
          offset += 8;
          byte num11 = byte.MaxValue;
          bool flag2 = false;
          bool flag3 = false;
          if (loop && loopPoint == 0U && numArray3[index1] > 0U)
          {
            TrackEvent trackEvent = trackEventArray[index1, numArray1[index1]];
            trackEvent.type = byte.MaxValue;
            trackEvent.absoluteTime = 0U;
            trackEvent.contentSize = 3;
            trackEvent.contents = new byte[trackEvent.contentSize];
            trackEvent.contents[0] = (byte) 46;
            trackEvent.contents[1] = (byte) 0;
            trackEvent.contents[2] = byte.MaxValue;
            trackEvent.deltaTime = 0U;
            trackEvent.obsoleteEvent = false;
            ++numArray1[index1];
            flag3 = true;
          }
          while (!flag2 && offset < int32_1)
          {
            uint original = 0;
            uint vlBytes = MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false);
            num4 += vlBytes;
            TrackEvent trackEvent1 = trackEventArray[index1, numArray1[index1]];
            trackEvent1.deltaTime = vlBytes;
            trackEvent1.obsoleteEvent = false;
            trackEvent1.contents = (byte[]) null;
            trackEvent1.absoluteTime = num4;
            if (loop && !flag3 && numArray3[index1] > loopPoint)
            {
              if ((int) num4 == (int) loopPoint)
              {
                TrackEvent trackEvent2 = trackEventArray[index1, numArray1[index1]];
                trackEvent2.type = byte.MaxValue;
                trackEvent2.absoluteTime = num4;
                trackEvent2.contentSize = 3;
                trackEvent2.contents = new byte[trackEvent2.contentSize];
                trackEvent2.contents[0] = (byte) 46;
                trackEvent2.contents[1] = (byte) 0;
                trackEvent2.contents[2] = byte.MaxValue;
                trackEvent2.deltaTime = vlBytes;
                trackEvent2.obsoleteEvent = false;
                ++numArray1[index1];
                trackEvent1 = trackEventArray[index1, numArray1[index1]];
                trackEvent1.deltaTime = 0U;
                trackEvent1.obsoleteEvent = false;
                trackEvent1.contents = (byte[]) null;
                trackEvent1.absoluteTime = num4;
                flag3 = true;
              }
              else if (num4 > loopPoint)
              {
                TrackEvent trackEvent2 = trackEventArray[index1, numArray1[index1]];
                trackEvent2.type = byte.MaxValue;
                trackEvent2.absoluteTime = loopPoint;
                trackEvent2.contentSize = 3;
                TrackEvent trackEvent3 = trackEvent2;
                trackEvent3.contents = new byte[trackEvent3.contentSize];
                trackEvent2.contents[0] = (byte) 46;
                trackEvent2.contents[1] = (byte) 0;
                trackEvent2.contents[2] = byte.MaxValue;
                trackEvent2.deltaTime = numArray1[index1] <= 0 ? loopPoint : loopPoint - trackEventArray[index1, numArray1[index1] - 1].absoluteTime;
                trackEvent2.obsoleteEvent = false;
                ++numArray1[index1];
                trackEvent1 = trackEventArray[index1, numArray1[index1]];
                trackEvent1.deltaTime = num4 - loopPoint;
                trackEvent1.obsoleteEvent = false;
                trackEvent1.contents = (byte[]) null;
                trackEvent1.absoluteTime = num4;
                flag3 = true;
              }
            }
            byte num6 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
            bool flag4 = num6 <= (byte) 127;
            if (num6 == byte.MaxValue)
            {
              byte num12 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              switch (num12)
              {
                case 47:
                  flag2 = true;
                  if (loop && numArray3[index1] > loopPoint)
                  {
                    TrackEvent trackEvent2 = trackEventArray[index1, numArray1[index1] - 1];
                    if (trackEvent2.type == byte.MaxValue && trackEvent2.contentSize > 0 && trackEvent2.contents[0] == (byte) 46)
                    {
                      TrackEvent trackEvent3 = trackEvent2;
                      trackEvent3.type = byte.MaxValue;
                      trackEvent3.contentSize = 1;
                      TrackEvent trackEvent4 = trackEvent3;
                      trackEvent4.contents = new byte[trackEvent4.contentSize];
                      trackEvent3.contents[0] = (byte) 47;
                    }
                    else
                    {
                      TrackEvent trackEvent3 = trackEventArray[index1, numArray1[index1] + 1];
                      trackEvent3.absoluteTime = num5;
                      trackEvent3.deltaTime = 0U;
                      trackEvent3.durationTime = trackEvent1.durationTime;
                      trackEvent3.obsoleteEvent = trackEvent1.obsoleteEvent;
                      trackEvent3.type = byte.MaxValue;
                      trackEvent3.contentSize = 1;
                      trackEvent3.contents = new byte[trackEvent3.contentSize];
                      trackEvent3.contents[0] = (byte) 47;
                      trackEvent1.type = byte.MaxValue;
                      if (num5 > trackEvent2.absoluteTime + trackEvent2.durationTime)
                      {
                        trackEvent1.deltaTime = num5 - (trackEvent2.absoluteTime + trackEvent2.durationTime);
                        trackEvent1.absoluteTime = num5;
                      }
                      else
                      {
                        trackEvent1.deltaTime = 0U;
                        trackEvent1.absoluteTime = trackEvent2.absoluteTime;
                      }
                      trackEvent1.contentSize = 7;
                      TrackEvent trackEvent4 = trackEvent1;
                      trackEvent4.contents = new byte[trackEvent4.contentSize];
                      trackEvent1.contents[0] = (byte) 45;
                      trackEvent1.contents[1] = byte.MaxValue;
                      trackEvent1.contents[2] = byte.MaxValue;
                      trackEvent1.contents[3] = (byte) 0;
                      trackEvent1.contents[4] = (byte) 0;
                      trackEvent1.contents[5] = (byte) 0;
                      trackEvent1.contents[6] = (byte) 0;
                      trackEvent1.obsoleteEvent = false;
                      ++numArray1[index1];
                    }
                  }
                  else
                  {
                    trackEvent1.type = byte.MaxValue;
                    trackEvent1.contentSize = 1;
                    TrackEvent trackEvent2 = trackEvent1;
                    trackEvent2.contents = new byte[trackEvent2.contentSize];
                    trackEvent1.contents[0] = (byte) 47;
                  }
                  int num13 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                case 81:
                  trackEvent1.type = byte.MaxValue;
                  trackEvent1.contentSize = 4;
                  TrackEvent trackEvent5 = trackEvent1;
                  trackEvent5.contents = new byte[trackEvent5.contentSize];
                  trackEvent1.contents[0] = (byte) 81;
                  int num14 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[1] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[2] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[3] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                default:
                  if (num12 < (byte) 127 && num12 != (byte) 81 && num12 != (byte) 47)
                  {
                    trackEvent1.type = byte.MaxValue;
                    uint num15 = (uint) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    for (int index2 = 0; (long) index2 < (long) num15; ++index2)
                    {
                      int num16 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    trackEvent1.obsoleteEvent = true;
                    break;
                  }
                  if (num12 == (byte) 127)
                  {
                    trackEvent1.type = byte.MaxValue;
                    int int32_2 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
                    for (int index2 = 0; index2 < int32_2; ++index2)
                    {
                      int num15 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    trackEvent1.obsoleteEvent = true;
                    break;
                  }
                  break;
              }
              num11 = num6;
            }
            else if (num6 >= (byte) 128 && num6 < (byte) 144 || flag4 && num11 >= (byte) 128 && num11 < (byte) 144)
            {
              byte num12;
              byte num13;
              if (flag4)
              {
                trackEvent1.type = num11;
                num12 = num6;
                num13 = num11;
              }
              else
              {
                trackEvent1.type = num6;
                num12 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                num13 = num6;
              }
              byte num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              for (int index2 = numArray1[index1] - 1; index2 >= 0; --index2)
              {
                if ((int) trackEventArray[index1, index2].type == (144 | (int) num13 & 15) && !trackEventArray[index1, index2].obsoleteEvent && (int) trackEventArray[index1, index2].contents[0] == (int) num12)
                {
                  trackEventArray[index1, index2].durationTime = num4 - trackEventArray[index1, index2].absoluteTime;
                  break;
                }
              }
              trackEvent1.durationTime = 0U;
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent2 = trackEvent1;
              trackEvent2.contents = new byte[trackEvent2.contentSize];
              trackEvent1.contents[0] = num12;
              trackEvent1.contents[1] = num14;
              trackEvent1.obsoleteEvent = true;
              if (!flag4)
                num11 = num6;
            }
            else if (num6 >= (byte) 144 && num6 < (byte) 160 || flag4 && num11 >= (byte) 144 && num11 < (byte) 160)
            {
              byte num12;
              byte num13;
              if (flag4)
              {
                trackEvent1.type = num11;
                num12 = num6;
                num13 = num11;
              }
              else
              {
                trackEvent1.type = num6;
                num12 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                num13 = num6;
              }
              byte num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (num14 == (byte) 0)
              {
                for (int index2 = numArray1[index1] - 1; index2 >= 0; --index2)
                {
                  if ((int) trackEventArray[index1, index2].type == (int) num13 && !trackEventArray[index1, index2].obsoleteEvent && (int) trackEventArray[index1, index2].contents[0] == (int) num12)
                  {
                    trackEventArray[index1, index2].durationTime = num4 - trackEventArray[index1, index2].absoluteTime;
                    break;
                  }
                }
                trackEvent1.durationTime = 0U;
                trackEvent1.contentSize = 2;
                TrackEvent trackEvent2 = trackEvent1;
                trackEvent2.contents = new byte[trackEvent2.contentSize];
                trackEvent1.contents[0] = num12;
                trackEvent1.contents[1] = num14;
                trackEvent1.obsoleteEvent = true;
              }
              else
              {
                for (int index2 = numArray1[index1] - 1; index2 >= 0; --index2)
                {
                  if ((int) trackEventArray[index1, index2].type == (int) num13 && !trackEventArray[index1, index2].obsoleteEvent && (int) trackEventArray[index1, index2].contents[0] == (int) num12)
                  {
                    if (trackEventArray[index1, index2].durationTime == 0U)
                    {
                      trackEventArray[index1, index2].durationTime = num4 - trackEventArray[index1, index2].absoluteTime;
                      break;
                    }
                    break;
                  }
                }
                trackEvent1.durationTime = 0U;
                trackEvent1.contentSize = 2;
                TrackEvent trackEvent2 = trackEvent1;
                trackEvent2.contents = new byte[trackEvent2.contentSize];
                trackEvent1.contents[0] = num12;
                trackEvent1.contents[1] = num14;
              }
              if (!flag4)
                num11 = num6;
            }
            else if (num6 >= (byte) 176 && num6 < (byte) 192 || flag4 && num11 >= (byte) 176 && num11 < (byte) 192)
            {
              byte num12;
              if (flag4)
              {
                num12 = num6;
                trackEvent1.type = num11;
              }
              else
              {
                num12 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num6;
              }
              byte num13 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent2 = trackEvent1;
              trackEvent2.contents = new byte[trackEvent2.contentSize];
              trackEvent1.contents[0] = num12;
              trackEvent1.contents[1] = num13;
              if (!flag4)
                num11 = num6;
            }
            else if (num6 >= (byte) 192 && num6 < (byte) 208 || flag4 && num11 >= (byte) 192 && num11 < (byte) 208)
            {
              byte num12;
              if (flag4)
              {
                num12 = num6;
                trackEvent1.type = num11;
              }
              else
              {
                num12 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num6;
              }
              trackEvent1.contentSize = 1;
              TrackEvent trackEvent2 = trackEvent1;
              trackEvent2.contents = new byte[trackEvent2.contentSize];
              trackEvent1.contents[0] = num12;
              if (!flag4)
                num11 = num6;
            }
            else if (num6 >= (byte) 208 && num6 < (byte) 224 || flag4 && num11 >= (byte) 208 && num11 < (byte) 224)
            {
              trackEvent1.type = num6;
              byte num12;
              if (flag4)
              {
                num12 = num6;
                trackEvent1.type = num11;
              }
              else
              {
                num12 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num6;
              }
              trackEvent1.contentSize = 1;
              TrackEvent trackEvent2 = trackEvent1;
              trackEvent2.contents = new byte[trackEvent2.contentSize];
              trackEvent1.contents[0] = num12;
              if (!flag4)
                num11 = num6;
            }
            else if (num6 >= (byte) 224 && num6 < (byte) 240 || flag4 && num11 >= (byte) 224 && num11 < (byte) 240)
            {
              trackEvent1.type = num6;
              byte num12;
              if (flag4)
              {
                num12 = num6;
                trackEvent1.type = num11;
              }
              else
              {
                num12 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num6;
              }
              byte num13 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent2 = trackEvent1;
              trackEvent2.contents = new byte[trackEvent2.contentSize];
              trackEvent1.contents[0] = num12;
              trackEvent1.contents[1] = num13;
              if (!flag4)
                num11 = num6;
            }
            else if (num6 == (byte) 240 || num6 == (byte) 247)
            {
              trackEvent1.type = num6;
              int int32_2 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
              for (int index2 = 0; index2 < int32_2; ++index2)
              {
                int num12 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              trackEvent1.obsoleteEvent = true;
            }
            else if (!flag1)
            {
              int num12 = (int) MessageBox.Show("Invalid midi character found", "Error");
              flag1 = true;
            }
            ++numArray1[index1];
          }
        }
        uint num20 = 0;
        uint inLong = 132;
        for (int index1 = 0; index1 < (int) numTracks; ++index1)
        {
          uint num4 = 0;
          int num6 = 0;
          byte num7 = 0;
          if (numArray1[index1] > 0)
          {
            uint num8 = MidiParse.Flip32Bit(inLong);
            outFile.Write(BitConverter.GetBytes(num8), 0, 4);
            for (int index2 = 0; index2 < numArray1[index1]; ++index2)
            {
              TrackEvent trackEvent = trackEventArray[index1, index2];
              uint length1 = 0;
              int num9 = (int) MidiParse.ReturnVLBytes(trackEvent.deltaTime + num20, ref length1);
              if (trackEvent.obsoleteEvent)
              {
                num20 += trackEvent.deltaTime;
              }
              else
              {
                if (trackEvent.type == byte.MaxValue && trackEvent.contents[0] == (byte) 46)
                  num6 = Convert.ToInt32((long) (uint) ((int) inLong + (int) num4 + 1) + (long) trackEvent.contentSize + (long) length1);
                num20 = 0U;
                uint num10 = num4 + length1;
                if (trackEvent.type == byte.MaxValue && trackEvent.contents[0] == (byte) 45)
                {
                  uint uint32_2 = Convert.ToUInt32((long) (inLong + num10) - (long) num6 + 8L);
                  trackEvent.contents[3] = Convert.ToByte(uint32_2 >> 24 & (uint) byte.MaxValue);
                  trackEvent.contents[4] = Convert.ToByte(uint32_2 >> 16 & (uint) byte.MaxValue);
                  trackEvent.contents[5] = Convert.ToByte(uint32_2 >> 8 & (uint) byte.MaxValue);
                  trackEvent.contents[6] = Convert.ToByte(uint32_2 & (uint) byte.MaxValue);
                }
                if ((int) trackEvent.type != (int) num7 || trackEvent.type == byte.MaxValue)
                  ++num10;
                num4 = num10 + Convert.ToUInt32(trackEvent.contentSize);
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160)
                {
                  uint length2 = 0;
                  int num11 = (int) MidiParse.ReturnVLBytes(trackEvent.durationTime, ref length2);
                  num4 += length2;
                }
                num7 = trackEvent.type;
              }
            }
            inLong += num4;
          }
          else
          {
            uint num8 = 0;
            outFile.Write(BitConverter.GetBytes(num8), 0, 4);
          }
        }
        for (int index = (int) numTracks; index < 32; ++index)
        {
          uint num4 = 0;
          outFile.Write(BitConverter.GetBytes(num4), 0, 4);
        }
        uint num21 = MidiParse.Flip32Bit((uint) num3);
        outFile.Write(BitConverter.GetBytes(num21), 0, 4);
        for (int index1 = 0; index1 < (int) numTracks; ++index1)
        {
          if (numArray1[index1] > 0)
          {
            byte num4 = 0;
            for (int index2 = 0; index2 < numArray1[index1]; ++index2)
            {
              TrackEvent trackEvent = trackEventArray[index1, index2];
              if (trackEvent.obsoleteEvent)
              {
                num20 += trackEvent.deltaTime;
              }
              else
              {
                uint length1 = 0;
                uint num6 = MidiParse.ReturnVLBytes(trackEvent.deltaTime + num20, ref length1);
                num20 = 0U;
                MidiParse.WriteVLBytes(outFile, num6, length1, false);
                if ((int) trackEvent.type != (int) num4 || trackEvent.type == byte.MaxValue)
                  outFile.WriteByte(trackEvent.type);
                outFile.Write(trackEvent.contents, 0, trackEvent.contentSize);
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160)
                {
                  uint length2 = 0;
                  uint num7 = MidiParse.ReturnVLBytes(trackEvent.durationTime, ref length2);
                  MidiParse.WriteVLBytes(outFile, num7, length2, false);
                }
                num4 = trackEvent.type;
              }
            }
          }
          for (int index2 = 0; index2 < numArray1[index1]; ++index2)
          {
            if (trackEventArray[index1, index2].contents != null)
              trackEventArray[index1, index2].contents = (byte[]) null;
          }
        }
        outFile.Close();
        outFile.Dispose();
        int int32_3 = Convert.ToInt32(new FileInfo(output).Length);
        byte[] Buffer1 = File.ReadAllBytes(output);
        uint[] numArray4 = new uint[32];
        int[] numArray5 = new int[32];
        for (int index = 0; index < 128; index += 4)
        {
          numArray4[index / 4] = (uint) ((((int) Buffer1[index] << 8 | (int) Buffer1[index + 1]) << 8 | (int) Buffer1[index + 2]) << 8) | (uint) Buffer1[index + 3];
          numArray5[index / 4] = 0;
        }
        for (int index1 = 0; index1 < int32_3; ++index1)
        {
          if (index1 > 132 && Buffer1[index1] == (byte) 254)
          {
            for (int index2 = 0; index2 < (int) numTracks; ++index2)
            {
              if ((long) numArray4[index2] > (long) index1)
                ++numArray5[index2];
            }
          }
        }
        FileStream fileStream1 = new FileStream(output, FileMode.Create, FileAccess.Write);
        for (int index = 0; index < 32; ++index)
          MidiParse.WriteLongToBuffer(Buffer1, Convert.ToUInt32(index * 4), numArray4[index] + Convert.ToUInt32(numArray5[index]));
        for (int index = 0; index < int32_3; ++index)
        {
          fileStream1.WriteByte(Buffer1[index]);
          if (index > 132 && Buffer1[index] == (byte) 254)
            fileStream1.WriteByte(Buffer1[index]);
        }
        fileStream1.Close();
        fileStream1.Dispose();
        byte[] numArray6 = (byte[]) null;
        if (useRepeaters)
        {
          int int32_2 = Convert.ToInt32(new FileInfo(output).Length);
          byte[] numArray7 = File.ReadAllBytes(output);
          uint[] numArray8 = new uint[32];
          for (int index = 0; index < 128; index += 4)
            numArray8[index / 4] = (uint) ((((int) numArray7[index] << 8 | (int) numArray7[index + 1]) << 8 | (int) numArray7[index + 2]) << 8) | (uint) numArray7[index + 3];
          uint data = (uint) ((((int) numArray7[128] << 8 | (int) numArray7[129]) << 8 | (int) numArray7[130]) << 8) | (uint) numArray7[131];
          byte[] Buffer2 = new byte[int32_2 * 4];
          for (int index = 0; index < int32_2 * 4; ++index)
            Buffer2[index] = (byte) 0;
          uint[] numArray9 = new uint[32];
          for (int index = 0; index < 32; ++index)
            numArray9[index] = 0U;
          int num4 = 132;
          for (int index1 = 0; index1 < 32 && numArray8[index1] != 0U; ++index1)
          {
            numArray9[index1] = Convert.ToUInt32(num4);
            int num6 = num4;
            int num7 = int32_2;
            if (index1 < 15 && numArray8[index1 + 1] != 0U)
              num7 = Convert.ToInt32(numArray8[index1 + 1]);
            int int32_4 = Convert.ToInt32(numArray8[index1]);
            while (int32_4 < num7)
            {
              int num8 = -1;
              int num9 = -1;
              for (int index2 = num6; index2 < num4; ++index2)
              {
                int num10;
                for (num10 = 0; (int) Buffer2[index2 + num10] == (int) numArray7[int32_4 + num10] && int32_4 + num10 < num7 && (Buffer2[index2 + num10] != (byte) 254 && Buffer2[index2 + num10] != byte.MaxValue) && index2 + num10 < num4; ++num10)
                {
                  bool flag2 = false;
                  for (int index3 = int32_4 + num10; index3 < num7 && index3 < int32_4 + num10 + 5; ++index3)
                  {
                    if (numArray7[index3] == byte.MaxValue)
                      flag2 = true;
                  }
                  if (flag2)
                    break;
                }
                if (num10 > num9 && num10 > 6)
                {
                  num9 = num10;
                  num8 = index2;
                }
              }
              Convert.ToInt32(((long) int32_4 - (long) numArray8[index1]) / 2L);
              if (num9 > 6)
              {
                if (num9 > 253)
                  num9 = 253;
                byte[] numArray10 = Buffer2;
                int index2 = num4;
                int num10 = index2 + 1;
                numArray10[index2] = (byte) 254;
                int num11 = num10 - num8 - 1;
                byte[] numArray11 = Buffer2;
                int index3 = num10;
                int num12 = index3 + 1;
                int num13 = (int) Convert.ToByte(num11 >> 8 & (int) byte.MaxValue);
                numArray11[index3] = (byte) num13;
                byte[] numArray12 = Buffer2;
                int index4 = num12;
                int num14 = index4 + 1;
                int num15 = (int) Convert.ToByte(num11 & (int) byte.MaxValue);
                numArray12[index4] = (byte) num15;
                byte[] numArray13 = Buffer2;
                int index5 = num14;
                num4 = index5 + 1;
                int num16 = (int) Convert.ToByte(num9);
                numArray13[index5] = (byte) num16;
                int32_4 += num9;
              }
              else
              {
                Buffer2[num4++] = numArray7[int32_4];
                ++int32_4;
              }
            }
            if (num4 % 4 != 0)
              num4 += 4 - num4 % 4;
          }
          for (int index = 0; index < 32; ++index)
          {
            if (numArray9[index] != 0U)
            {
              Convert.ToInt32(numArray9[index]);
              int num6 = num4;
              if (index < 15 && numArray9[index + 1] != 0U)
                num6 = Convert.ToInt32(numArray9[index + 1]);
              int int32_4 = Convert.ToInt32(numArray9[index]);
              bool flag2 = false;
              int num7 = 0;
              while (int32_4 < num6)
              {
                if (Buffer2[int32_4] == byte.MaxValue && Buffer2[int32_4 + 1] == (byte) 46 && (Buffer2[int32_4 + 2] == (byte) 0 && Buffer2[int32_4 + 3] == byte.MaxValue))
                {
                  flag2 = true;
                  num7 = int32_4 + 4;
                  int32_4 += 4;
                }
                else if (Buffer2[int32_4] == byte.MaxValue && Buffer2[int32_4 + 1] == (byte) 45 && (Buffer2[int32_4 + 2] == byte.MaxValue && Buffer2[int32_4 + 3] == byte.MaxValue))
                {
                  if (flag2)
                  {
                    int num8 = int32_4 + 8 - num7;
                    MidiParse.WriteLongToBuffer(Buffer2, Convert.ToUInt32(int32_4 + 4), Convert.ToUInt32(num8));
                    flag2 = false;
                  }
                  int32_4 += 8;
                }
                else
                  ++int32_4;
              }
            }
          }
          for (int index = 0; index < 32; ++index)
            MidiParse.WriteLongToBuffer(Buffer2, Convert.ToUInt32(index * 4), Convert.ToUInt32(numArray9[index]));
          MidiParse.WriteLongToBuffer(Buffer2, 128U, data);
          FileStream fileStream2 = new FileStream(output, FileMode.Create, FileAccess.Write);
          for (int index = 0; index < num4; ++index)
            fileStream2.WriteByte(Buffer2[index]);
          fileStream2.Close();
          fileStream2.Dispose();
          numArray6 = (byte[]) null;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error converting " + ex.ToString(), "Error");
        return false;
      }
      return true;
    }
  }
}
