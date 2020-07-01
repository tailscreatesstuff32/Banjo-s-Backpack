// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.ActiveBone
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class ActiveBone
  {
    public int parentCMDBoneID = -1;
    public byte bone;
    public int length;

    public ActiveBone(byte b, int l)
    {
      this.bone = b;
      this.length = l;
    }
  }
}
