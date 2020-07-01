// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKLevelMap
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class BKLevelMap
  {
    public static string getLevelName(byte levelID)
    {
      string str;
      switch (levelID)
      {
        case 1:
          str = "Mumbo's Mountain";
          break;
        case 2:
          str = "Treasure Trove Cove";
          break;
        case 3:
          str = "Clanker's Cavern";
          break;
        case 4:
          str = "Bubblegloop Swamp";
          break;
        case 5:
          str = "Freezeezy Peak";
          break;
        case 6:
          str = "Grunty's Lair";
          break;
        case 7:
          str = "Gobi's Valley";
          break;
        case 8:
          str = "Click Clock Wood";
          break;
        case 9:
          str = "Rusty Bucket Bay";
          break;
        case 10:
          str = "Mad Monster Mansion";
          break;
        case 11:
          str = "Spiral Mountain";
          break;
        case 12:
          str = "Final Battle";
          break;
        case 13:
          str = "Cutscenes";
          break;
        default:
          str = "UNKNOWN";
          break;
      }
      return str;
    }
  }
}
