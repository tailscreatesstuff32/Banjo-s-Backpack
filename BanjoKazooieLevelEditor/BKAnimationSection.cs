// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKAnimationSection
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

using System.Collections.Generic;

namespace BanjoKazooieLevelEditor
{
  public class BKAnimationSection
  {
    public List<BKAnimationCommand> commands = new List<BKAnimationCommand>();
    public ushort boneDL;
    public TransformationType tranformationType;

    public BKAnimationSection(ushort boneID_, TransformationType transformationType_)
    {
      this.boneDL = boneID_;
      this.tranformationType = transformationType_;
    }
  }
}
