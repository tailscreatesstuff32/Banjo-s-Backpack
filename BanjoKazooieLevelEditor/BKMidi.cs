// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKMidi
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class BKMidi
  {
    public string Name = "";
    public int ID;
    public int Pointer;

    public BKMidi(int id, string name, int pntr)
    {
      this.ID = id;
      this.Name = name;
      this.Pointer = pntr;
    }
  }
}
