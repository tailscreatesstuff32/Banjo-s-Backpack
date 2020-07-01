// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SetupFileWritter
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BanjoKazooieLevelEditor
{
  internal class SetupFileWritter
  {
    private WrittenFile writtenFile;

    public void stripDown(string file, int byteToRemove)
    {
      List<byte> byteList = new List<byte>();
      if (File.Exists(file))
      {
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(file, FileMode.Open));
        long length = binaryReader.BaseStream.Length;
        byte[] buffer = new byte[length];
        binaryReader.BaseStream.Read(buffer, 0, (int) length);
        binaryReader.Close();
        byteList = new List<byte>((IEnumerable<byte>) buffer);
      }
      bool flag = false;
      for (int index1 = 0; index1 + 3 < byteList.Count && !flag; ++index1)
      {
        if (byteList[index1] == (byte) 3 && byteList[index1 + 1] == (byte) 10 && byteList[index1 + 3] == (byte) 11)
        {
          int num1 = (int) byteList[index1 + 2];
          int num2 = num1;
          int index2 = index1 + 4;
          for (int index3 = 0; index3 < num2 && !flag && num1 > 1; ++index3)
          {
            if (byteList[index2 + 6] == (byte) 250 && byteList[index2 + 7] == (byte) 18 || byteList[index2 + 6] == (byte) 250 && byteList[index2 + 7] == (byte) 14 || (byteList[index2 + 8] == (byte) 0 && byteList[index2 + 9] == (byte) 0 || byteList[index2 + 6] == (byte) 100 && byteList[index2 + 7] == (byte) 8) || byteList[index2 + 6] == (byte) 150 && byteList[index2 + 7] == (byte) 18)
            {
              byteList.RemoveRange(index2, 20);
              --num1;
              byteList[index1 + 2] = (byte) num1;
              byteToRemove -= 20;
              if (byteToRemove < 0)
                flag = true;
            }
            else
              index2 += 20;
          }
          index1 += 2;
        }
      }
      FileStream fileStream = File.Create(file);
      BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
      binaryWriter.Write(byteList.ToArray());
      binaryWriter.Close();
      fileStream.Close();
    }

    public void stripDown(List<byte> bytesInFileList, int byteToRemove)
    {
      bool flag = false;
      for (int index1 = 0; index1 + 3 < bytesInFileList.Count && !flag; ++index1)
      {
        if (bytesInFileList[index1] == (byte) 3 && bytesInFileList[index1 + 1] == (byte) 10 && bytesInFileList[index1 + 3] == (byte) 11)
        {
          int bytesInFile = (int) bytesInFileList[index1 + 2];
          int num1 = bytesInFile;
          int index2 = index1 + 4;
          for (int index3 = 0; index3 < num1 && !flag && bytesInFile > 1; ++index3)
          {
            short num2 = (short) ((int) bytesInFileList[index2 + 8] * 100 + (int) bytesInFileList[index2 + 9]);
            short num3 = (short) ((int) bytesInFileList[index2 + 6] * 100 + (int) bytesInFileList[index2 + 7]);
            if (bytesInFileList[index2 + 6] == (byte) 250 && bytesInFileList[index2 + 7] == (byte) 18 || bytesInFileList[index2 + 6] == (byte) 250 && bytesInFileList[index2 + 7] == (byte) 14 || (bytesInFileList[index2 + 8] == (byte) 0 && bytesInFileList[index2 + 9] == (byte) 0 || bytesInFileList[index2 + 6] == (byte) 100 && bytesInFileList[index2 + 7] == (byte) 8) || (bytesInFileList[index2 + 6] == (byte) 150 && bytesInFileList[index2 + 7] == (byte) 18 || num2 == short.MinValue && (num3 <= short.MinValue || num3 >= (short) -32512)))
            {
              bytesInFileList.RemoveRange(index2, 20);
              --bytesInFile;
              bytesInFileList[index1 + 2] = (byte) bytesInFile;
              byteToRemove -= 20;
              if (byteToRemove <= 0)
                flag = true;
            }
            else
              index2 += 20;
          }
          index1 += 2;
        }
      }
    }

    private bool objectInBounds(ObjectData obj, BoundingBox bounds)
    {
      bool flag = false;
      if ((int) obj.locX < bounds.largeX + 1000 && (int) obj.locX > bounds.smallX - 1000 && ((int) obj.locY < bounds.largeY + 1000 && (int) obj.locY > bounds.smallY - 1000) && ((int) obj.locZ < bounds.largeZ + 1000 && (int) obj.locZ > bounds.smallZ - 1000))
        flag = true;
      return flag;
    }

    public WrittenFile createBinaryFileObjects(
      string inDir_,
      string outDir_,
      SetupFile file_,
      List<ObjectData> objects_,
      List<ObjectData> structs_,
      List<BKPath> paths_,
      List<CameraObject> cams_,
      List<LevelEntryPoint> entries_,
      bool includeTriggers,
      BoundingBox maxBounds,
      string replacementModel_,
      string replacementModelB_,
      bool allObjsErased_,
      string filename_)
    {
      ObjectData objectData1 = new ObjectData((short) 0, 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0);
      for (int index = 0; index < objects_.Count<ObjectData>(); ++index)
      {
        if (objects_[index].name == "Start Point")
          objectData1 = objects_[index];
      }
      for (int index = 0; index < entries_.Count<LevelEntryPoint>(); ++index)
      {
        short specialScript_ = 6412;
        ObjectData objectData2 = new ObjectData((short) entries_[index].objectId, 0, objectData1.locX, objectData1.locY, objectData1.locZ, objectData1.rot, objectData1.size, specialScript_);
        objects_.Add(objectData2);
      }
      List<int> intList = new List<int>();
      for (int index = 0; index < cams_.Count; ++index)
        intList.Add((int) cams_[index].id);
      short num1 = 4352;
      List<short> shortList = new List<short>();
      for (int index = 0; index < paths_.Count<BKPath>(); ++index)
        objects_.AddRange((IEnumerable<ObjectData>) paths_[index].nodes);
      for (int index = 0; index < objects_.Count<ObjectData>(); ++index)
        shortList.Add((short) ((int) objects_[index].obj16 * 256 + (int) objects_[index].obj17));
      shortList.Add((short) 1200);
      shortList.Add((short) 1232);
      shortList.Add((short) 1744);
      shortList.Add((short) 1184);
      shortList.Add((short) 6032);
      for (int index = 0; index < objects_.Count; ++index)
      {
        if (objects_[index].obj16 == (byte) 0 && objects_[index].obj17 == (byte) 0)
        {
          while (shortList.Contains(num1))
            num1 += (short) 32;
          objects_[index].obj16 = (byte) ((uint) num1 >> 8);
          objects_[index].obj17 = (byte) num1;
          num1 += (short) 32;
        }
      }
      List<byte> source = new List<byte>();
      source.Add((byte) 1);
      source.Add((byte) 1);
      int num2 = 999999999;
      int num3 = 999999999;
      int num4 = 999999999;
      int num5 = -999999999;
      int num6 = -999999999;
      int num7 = -999999999;
      for (int index = 0; index < objects_.Count; ++index)
      {
        ObjectData objectData2 = objects_[index];
        if (objectData2.objectID != short.MinValue && this.objectInBounds(objectData2, maxBounds))
        {
          if (num2 > (int) objectData2.locX)
            num2 = (int) objectData2.locX;
          if (num3 > (int) objectData2.locY)
            num3 = (int) objectData2.locY;
          if (num4 > (int) objectData2.locZ)
            num4 = (int) objectData2.locZ;
          if (num5 < (int) objectData2.locX)
            num5 = (int) objectData2.locX;
          if (num6 < (int) objectData2.locY)
            num6 = (int) objectData2.locY;
          if (num7 < (int) objectData2.locZ)
            num7 = (int) objectData2.locZ;
        }
      }
      for (int index = 0; index < structs_.Count; ++index)
      {
        ObjectData objectData2 = structs_[index];
        if (this.objectInBounds(objectData2, maxBounds))
        {
          if (num2 > (int) objectData2.locX)
            num2 = (int) objectData2.locX;
          if (num3 > (int) objectData2.locY)
            num3 = (int) objectData2.locY;
          if (num4 > (int) objectData2.locZ)
            num4 = (int) objectData2.locZ;
          if (num5 < (int) objectData2.locX)
            num5 = (int) objectData2.locX;
          if (num6 < (int) objectData2.locY)
            num6 = (int) objectData2.locY;
          if (num7 < (int) objectData2.locZ)
            num7 = (int) objectData2.locZ;
        }
      }
      int number1 = num2 / 1000;
      if (num2 % 1000 != 0)
        --number1;
      int number2 = num3 / 1000;
      if (num3 % 1000 != 0)
        --number2;
      int number3 = num4 / 1000;
      if (num4 % 1000 != 0)
        --number3;
      int number4 = num5 / 1000;
      int num8 = num5 % 1000;
      int number5 = num6 / 1000;
      int num9 = num6 % 1000;
      int number6 = num7 / 1000;
      int num10 = num7 % 1000;
      byte[] byteArray1 = this.Int32ToByteArray(number1);
      byte[] byteArray2 = this.Int32ToByteArray(number2);
      byte[] byteArray3 = this.Int32ToByteArray(number3);
      byte[] byteArray4 = this.Int32ToByteArray(number4);
      byte[] byteArray5 = this.Int32ToByteArray(number5);
      byte[] byteArray6 = this.Int32ToByteArray(number6);
      BoundingBox bb_ = new BoundingBox();
      bb_.smallX = number1;
      bb_.smallY = number2;
      bb_.smallZ = number3;
      bb_.largeX = number4;
      bb_.largeY = number5;
      bb_.largeZ = number6;
      source.Add(byteArray1[0]);
      source.Add(byteArray1[1]);
      source.Add(byteArray1[2]);
      source.Add(byteArray1[3]);
      source.Add(byteArray2[0]);
      source.Add(byteArray2[1]);
      source.Add(byteArray2[2]);
      source.Add(byteArray2[3]);
      source.Add(byteArray3[0]);
      source.Add(byteArray3[1]);
      source.Add(byteArray3[2]);
      source.Add(byteArray3[3]);
      source.Add(byteArray4[0]);
      source.Add(byteArray4[1]);
      source.Add(byteArray4[2]);
      source.Add(byteArray4[3]);
      source.Add(byteArray5[0]);
      source.Add(byteArray5[1]);
      source.Add(byteArray5[2]);
      source.Add(byteArray5[3]);
      source.Add(byteArray6[0]);
      source.Add(byteArray6[1]);
      source.Add(byteArray6[2]);
      source.Add(byteArray6[3]);
      int num11 = Math.Abs(number1) + number4 + 1;
      if (number1 > 0)
        num11 = number4 - number1 + 1;
      int num12 = Math.Abs(number2) + number5 + 1;
      if (number2 > 0)
        num12 = number5 - number2 + 1;
      int num13 = Math.Abs(number3) + number6 + 1;
      if (number3 > 0)
        num13 = number6 - number3 + 1;
      for (int index1 = 0; index1 < num11; ++index1)
      {
        for (int index2 = 0; index2 < num12; ++index2)
        {
          for (int index3 = 0; index3 < num13; ++index3)
          {
            List<byte> byteList = new List<byte>();
            byteList.Add((byte) 3);
            byteList.Add((byte) 10);
            byteList.Add((byte) 0);
            int num14 = (number1 + index1) * 1000;
            int num15 = num14 + 1000;
            int num16 = (number2 + index2) * 1000;
            int num17 = num16 + 1000;
            int num18 = (number3 + index3) * 1000;
            int num19 = num18 + 1000;
            bool flag1 = false;
            bool flag2 = false;
            byte num20 = 0;
            byte num21 = 0;
            int index4 = 2;
            try
            {
              for (int index5 = 0; index5 < objects_.Count<ObjectData>(); ++index5)
              {
                ObjectData objectData2 = objects_[index5];
                bool flag3 = true;
                if (objectData2.specialScript == (short) -1518 && !intList.Contains((int) objectData2.objectID))
                  flag3 = false;
                if (objectData2.specialScript == (short) -1518 && !includeTriggers)
                  flag3 = false;
                if ((((int) objectData2.locX < num14 || (int) objectData2.locX >= num15 || ((int) objectData2.locY < num16 || (int) objectData2.locY >= num17) || (int) objectData2.locZ < num18 ? 0 : ((int) objectData2.locZ < num19 ? 1 : 0)) & (flag3 ? 1 : 0)) != 0)
                {
                  if (!flag1)
                  {
                    flag1 = true;
                    byteList.Add((byte) 11);
                  }
                  ++num20;
                  objects_.RemoveAt(index5);
                  --index5;
                  byte[] numArray = new byte[20];
                  if (objectData2.type != ObjectType.SPath)
                  {
                    byte[] byteArray7 = this.Int16ToByteArray(objectData2.locX);
                    byte[] byteArray8 = this.Int16ToByteArray(objectData2.locY);
                    byte[] byteArray9 = this.Int16ToByteArray(objectData2.locZ);
                    byte[] byteArray10 = this.Int16ToByteArray(objectData2.specialScript);
                    byte num22 = (byte) ((uint) objectData2.rot / 2U);
                    byte[] byteArray11 = this.Int16ToByteArray(objectData2.size);
                    byte[] byteArray12 = this.Int16ToByteArray(objectData2.objectID);
                    numArray[0] = byteArray7[0];
                    numArray[1] = byteArray7[1];
                    numArray[2] = byteArray8[0];
                    numArray[3] = byteArray8[1];
                    numArray[4] = byteArray9[0];
                    numArray[5] = byteArray9[1];
                    numArray[6] = byteArray10[0];
                    numArray[7] = byteArray10[1];
                    numArray[8] = byteArray12[0];
                    numArray[9] = byteArray12[1];
                    numArray[10] = objectData2.obj10;
                    numArray[11] = objectData2.obj11;
                    numArray[12] = num22;
                    numArray[13] = objectData2.obj13;
                    numArray[14] = byteArray11[0];
                    numArray[15] = byteArray11[1];
                    numArray[16] = objectData2.obj16;
                    numArray[17] = objectData2.obj17;
                    numArray[18] = objectData2.obj18;
                    numArray[19] = objectData2.obj19;
                    if (objectData2.name == "Start Point")
                      numArray[17] = (byte) 32;
                    else if (objectData2.name == "Jiggy Flag")
                    {
                      numArray[14] = (byte) 0;
                      numArray[15] = (byte) 0;
                    }
                    if (numArray[16] == (byte) 0 && numArray[17] == (byte) 0 && (numArray[19] == (byte) 0 && !(objectData2.name == "Blue Jinjo")))
                    {
                      if (objectData2.name == "Yellow Jinjo")
                        numArray[19] = (byte) 208;
                      else if (objectData2.name == "Green Jinjo")
                        numArray[19] = (byte) 64;
                      else if (objectData2.name == "Purple Jinjo")
                        numArray[19] = (byte) 192;
                      else if (objectData2.name == "Orange Jinjo")
                        numArray[19] = (byte) 80;
                      else if (objectData2.name.Contains("SNS Egg"))
                        numArray[19] = (byte) 70;
                    }
                    if (objectData2.name == "Warp" && numArray[16] == (byte) 0)
                    {
                      int num23 = (int) numArray[17];
                    }
                    int objectId = (int) objectData2.objectID;
                    if (numArray[19] == (byte) 0 && objectData2.type != ObjectType.SPath)
                      numArray[19] = (byte) 64;
                  }
                  else
                  {
                    byte[] bytes = BitConverter.GetBytes(objectData2.activationPercent);
                    numArray[0] = bytes[3];
                    numArray[1] = bytes[2];
                    numArray[2] = bytes[1];
                    numArray[3] = bytes[0];
                    numArray[4] = (byte) (objectData2.pw1 >> 24);
                    numArray[5] = (byte) (objectData2.pw1 >> 16);
                    numArray[6] = (byte) (objectData2.pw1 >> 8);
                    numArray[7] = (byte) objectData2.pw1;
                    numArray[8] = (byte) (objectData2.pw2 >> 24);
                    numArray[9] = (byte) (objectData2.pw2 >> 16);
                    numArray[10] = (byte) (objectData2.pw2 >> 8);
                    numArray[11] = (byte) objectData2.pw2;
                    numArray[12] = (byte) (objectData2.pw3 >> 24);
                    numArray[13] = (byte) (objectData2.pw3 >> 16);
                    numArray[14] = (byte) (objectData2.pw3 >> 8);
                    numArray[15] = (byte) objectData2.pw3;
                    numArray[16] = objectData2.obj16;
                    numArray[17] = objectData2.obj17;
                    numArray[18] = objectData2.obj18;
                    numArray[19] = objectData2.obj19;
                  }
                  byteList.AddRange((IEnumerable<byte>) numArray);
                }
              }
              byteList[index4] = num20;
              byteList.Add((byte) 8);
              int num24 = byteList.Count - 1;
              byteList.Add((byte) 0);
              for (int index5 = 0; index5 < structs_.Count; ++index5)
              {
                ObjectData objectData2 = structs_[index5];
                if ((int) objectData2.locX >= num14 && (int) objectData2.locX < num15 && ((int) objectData2.locY >= num16 && (int) objectData2.locY < num17) && ((int) objectData2.locZ >= num18 && (int) objectData2.locZ < num19))
                {
                  if (!flag2)
                  {
                    flag2 = true;
                    byteList.Add((byte) 9);
                  }
                  ++num21;
                  structs_.RemoveAt(index5);
                  --index5;
                  byte[] byteArray7 = this.Int16ToByteArray(objectData2.locX);
                  byte[] byteArray8 = this.Int16ToByteArray(objectData2.locY);
                  byte[] byteArray9 = this.Int16ToByteArray(objectData2.locZ);
                  this.Int16ToByteArray(objectData2.specialScript);
                  byte[] byteArray10 = this.Int16ToByteArray(objectData2.size);
                  byte[] byteArray11 = this.Int16ToByteArray(objectData2.objectID);
                  byte[] numArray = new byte[12];
                  numArray[0] = byteArray11[0];
                  numArray[1] = byteArray11[1];
                  numArray[2] = objectData2.struct2;
                  numArray[3] = objectData2.struct3;
                  if (objectData2.struct3 == (byte) 0)
                  {
                    if (objectData2.name == "Red Feather")
                      numArray[3] = (byte) 220;
                    if (objectData2.name == "Gold Feather")
                      numArray[3] = (byte) 222;
                    if (objectData2.name == "Note")
                      numArray[3] = (byte) 180;
                    if (objectData2.name == "Blue Egg")
                      numArray[3] = (byte) 162;
                    if (objectData2.name == "Fire 2D")
                    {
                      numArray[2] = (byte) 1;
                      numArray[3] = (byte) 144;
                    }
                    if (objectData2.name == "Blue Flowers")
                    {
                      numArray[2] = (byte) 1;
                      numArray[3] = (byte) 78;
                    }
                    if (objectData2.name == "Red Flowers")
                    {
                      numArray[2] = (byte) 0;
                      numArray[3] = (byte) 230;
                    }
                    if (objectData2.name == "Yellow Red Flowers")
                    {
                      numArray[2] = (byte) 1;
                      numArray[3] = (byte) 74;
                    }
                    if (objectData2.name == "MM Tree" || objectData2.name == "TTC Tree")
                    {
                      numArray[2] = (byte) 179;
                      numArray[3] = (byte) 0;
                    }
                    if (objectData2.name == "Conga's Tree")
                    {
                      numArray[2] = (byte) 11;
                      numArray[3] = (byte) 0;
                    }
                    if (objectData2.name == "Orange 2D")
                    {
                      numArray[2] = (byte) 0;
                      numArray[3] = (byte) 108;
                    }
                    if (objectData2.name == "Another Crate")
                    {
                      numArray[2] = (byte) 0;
                      numArray[3] = (byte) 0;
                    }
                    if (objectData2.name == "Dark Crate")
                    {
                      numArray[2] = (byte) 59;
                      numArray[3] = (byte) 177;
                    }
                    if (objectData2.name == "Light Crate")
                    {
                      numArray[2] = (byte) 21;
                      numArray[3] = (byte) 2;
                    }
                  }
                  numArray[4] = byteArray7[0];
                  numArray[5] = byteArray7[1];
                  numArray[6] = byteArray8[0];
                  numArray[7] = byteArray8[1];
                  numArray[8] = byteArray9[0];
                  numArray[9] = byteArray9[1];
                  numArray[10] = byteArray10[1];
                  numArray[11] = objectData2.structB;
                  if (objectData2.structB == (byte) 0)
                  {
                    if (objectData2.name == "SM Tree")
                      numArray[11] = (byte) 18;
                    if (objectData2.name == "MM Tree")
                      numArray[11] = (byte) 210;
                    if (objectData2.name == "TTC Tree")
                      numArray[11] = (byte) 18;
                    if (objectData2.name == "GV Tree")
                      numArray[11] = (byte) 146;
                    if (objectData2.name == "Conga's Tree")
                      numArray[11] = (byte) 82;
                    if (objectData2.name == "Another Crate")
                      numArray[11] = (byte) 210;
                    if (objectData2.name == "Dark Crate")
                      numArray[11] = (byte) 146;
                    if (objectData2.name == "Light Crate")
                      numArray[11] = (byte) 210;
                    if (objectData2.name.Contains("Toxic"))
                      numArray[11] = (byte) 210;
                  }
                  if (objectData2.structB == (byte) 0 && objectData2.structA == (byte) 0)
                  {
                    if (objectData2.name == "Blue Flowers")
                    {
                      numArray[10] = (byte) 6;
                      numArray[11] = (byte) 80;
                    }
                    if (objectData2.name == "Red Flowers")
                    {
                      numArray[10] = (byte) 6;
                      numArray[11] = (byte) 48;
                    }
                    if (objectData2.name == "Yellow Red Flowers")
                    {
                      numArray[10] = (byte) 1;
                      numArray[11] = (byte) 16;
                    }
                    if (objectData2.name == "Orange 2D")
                    {
                      numArray[10] = (byte) 2;
                      numArray[11] = (byte) 80;
                    }
                  }
                  byteList.AddRange((IEnumerable<byte>) numArray);
                }
              }
              byteList.Add((byte) 1);
              byteList[num24 + 1] = num21;
              if (!flag1 && !flag2)
                source.Add((byte) 1);
              else
                source.AddRange((IEnumerable<byte>) byteList);
            }
            catch (Exception ex)
            {
            }
          }
        }
      }
      source.Add((byte) 0);
      source.Add((byte) 3);
      for (int index = 0; index < cams_.Count; ++index)
      {
        if (cams_[index].type == 3 || cams_[index].type == 2 || cams_[index].type == 1)
        {
          source.Add((byte) 1);
          source.Add((byte) 0);
          source.Add((byte) cams_[index].id);
          source.Add((byte) 2);
          source.Add((byte) cams_[index].type);
          source.Add((byte) 1);
          byte[] bytes1 = BitConverter.GetBytes(cams_[index].x);
          byte[] bytes2 = BitConverter.GetBytes(cams_[index].y);
          byte[] bytes3 = BitConverter.GetBytes(cams_[index].z);
          source.Add(bytes1[3]);
          source.Add(bytes1[2]);
          source.Add(bytes1[1]);
          source.Add(bytes1[0]);
          source.Add(bytes2[3]);
          source.Add(bytes2[2]);
          source.Add(bytes2[1]);
          source.Add(bytes2[0]);
          source.Add(bytes3[3]);
          source.Add(bytes3[2]);
          source.Add(bytes3[1]);
          source.Add(bytes3[0]);
          source.Add((byte) 2);
          if (cams_[index].type == 2)
          {
            byte[] bytes4 = BitConverter.GetBytes(cams_[index].pitch);
            byte[] bytes5 = BitConverter.GetBytes(cams_[index].yaw);
            byte[] bytes6 = BitConverter.GetBytes(cams_[index].roll);
            source.Add(bytes4[3]);
            source.Add(bytes4[2]);
            source.Add(bytes4[1]);
            source.Add(bytes4[0]);
            source.Add(bytes5[3]);
            source.Add(bytes5[2]);
            source.Add(bytes5[1]);
            source.Add(bytes5[0]);
            source.Add(bytes6[3]);
            source.Add(bytes6[2]);
            source.Add(bytes6[1]);
            source.Add(bytes6[0]);
          }
          if (cams_[index].type == 3 || cams_[index].type == 1)
          {
            byte[] bytes4 = BitConverter.GetBytes(cams_[index].camHSpeed);
            byte[] bytes5 = BitConverter.GetBytes(cams_[index].camVSpeed);
            source.Add(bytes4[3]);
            source.Add(bytes4[2]);
            source.Add(bytes4[1]);
            source.Add(bytes4[0]);
            source.Add(bytes5[3]);
            source.Add(bytes5[2]);
            source.Add(bytes5[1]);
            source.Add(bytes5[0]);
            source.Add((byte) 3);
            byte[] bytes6 = BitConverter.GetBytes(cams_[index].camRotation);
            byte[] bytes7 = BitConverter.GetBytes(cams_[index].camAccel);
            source.Add(bytes6[3]);
            source.Add(bytes6[2]);
            source.Add(bytes6[1]);
            source.Add(bytes6[0]);
            source.Add(bytes7[3]);
            source.Add(bytes7[2]);
            source.Add(bytes7[1]);
            source.Add(bytes7[0]);
            source.Add((byte) 4);
            byte[] bytes8 = BitConverter.GetBytes(cams_[index].pitch3);
            byte[] bytes9 = BitConverter.GetBytes(cams_[index].yaw3);
            byte[] bytes10 = BitConverter.GetBytes(cams_[index].roll3);
            source.Add(bytes8[3]);
            source.Add(bytes8[2]);
            source.Add(bytes8[1]);
            source.Add(bytes8[0]);
            source.Add(bytes9[3]);
            source.Add(bytes9[2]);
            source.Add(bytes9[1]);
            source.Add(bytes9[0]);
            source.Add(bytes10[3]);
            source.Add(bytes10[2]);
            source.Add(bytes10[1]);
            source.Add(bytes10[0]);
            source.Add((byte) 5);
            byte[] byteArray7 = this.Int32ToByteArray(cams_[index].Type3Arg5);
            source.Add(byteArray7[0]);
            source.Add(byteArray7[1]);
            source.Add(byteArray7[2]);
            source.Add(byteArray7[3]);
            if (cams_[index].type == 3)
            {
              source.Add((byte) 6);
              byte[] bytes11 = BitConverter.GetBytes(cams_[index].camCDist);
              byte[] bytes12 = BitConverter.GetBytes(cams_[index].camFDist);
              source.Add(bytes11[3]);
              source.Add(bytes11[2]);
              source.Add(bytes11[1]);
              source.Add(bytes11[0]);
              source.Add(bytes12[3]);
              source.Add(bytes12[2]);
              source.Add(bytes12[1]);
              source.Add(bytes12[0]);
            }
          }
        }
        source.Add((byte) 0);
      }
      source.Add((byte) 0);
      source.Add((byte) 4);
      source.Add((byte) 0);
      source.Add((byte) 0);
      int num25 = 0;
      if (File.Exists(inDir_ + file_.pointer.ToString("x")))
      {
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(inDir_ + file_.pointer.ToString("x"), FileMode.Open));
        num25 = (int) binaryReader.BaseStream.Length;
        binaryReader.Close();
      }
      source.Count<byte>();
      FileStream fileStream = !(filename_ == "") ? File.Create(filename_) : File.Create(outDir_ + file_.pointer.ToString("x"));
      BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
      binaryWriter.Write(source.ToArray());
      binaryWriter.Close();
      fileStream.Close();
      this.writtenFile = new WrittenFile(file_.pointer.ToString("x"), bb_, file_.pointer, file_.modelAPointer, file_.modelBPointer, replacementModel_, replacementModelB_);
      return this.writtenFile;
    }

    public byte[] Int16ToByteArray(short number)
    {
      return new byte[2]
      {
        (byte) ((uint) number >> 8),
        (byte) ((uint) number & (uint) byte.MaxValue)
      };
    }

    public byte[] Int32ToByteArray(int number)
    {
      return new byte[4]
      {
        (byte) (number >> 24),
        (byte) (number >> 16),
        (byte) (number >> 8),
        (byte) (number & (int) byte.MaxValue)
      };
    }
  }
}
