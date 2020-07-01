// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKAnimation
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

using System.Collections.Generic;

namespace BanjoKazooieLevelEditor
{
  public class BKAnimation
  {
    public List<BKAnimationSection> sections = new List<BKAnimationSection>();
    public ushort startFrame;
    public ushort endFrame;

    public BKAnimation(byte[] animationData)
    {
      this.startFrame = (ushort) (((uint) animationData[0] << 8) + (uint) animationData[1]);
      this.endFrame = (ushort) (((uint) animationData[2] << 8) + (uint) animationData[3]);
      ushort num1 = (ushort) (((uint) animationData[4] << 8) + (uint) animationData[5]);
      ushort num2 = 8;
      while (this.sections.Count < (int) num1)
      {
        BKAnimationSection animationSection = new BKAnimationSection((ushort) (((int) animationData[(int) num2] << 8) + (int) animationData[(int) num2 + 1] >> 4), (TransformationType) ((int) animationData[(int) num2 + 1] & 15));
        ushort num3 = (ushort) ((uint) num2 + 2U);
        ushort num4 = (ushort) (((uint) animationData[(int) num3] << 8) + (uint) animationData[(int) num3 + 1]);
        num2 = (ushort) ((uint) num3 + 2U);
        if (this.sections.Count != 17)
          ;
        while (animationSection.commands.Count < (int) num4)
        {
          BKAnimationCommand animationCommand = new BKAnimationCommand((ushort) ((uint) animationData[(int) num2] >> 6), (ushort) (((int) animationData[(int) num2] << 8) + (int) animationData[(int) num2 + 1] & 16383), (short) (((int) animationData[(int) num2 + 2] << 8) + (int) animationData[(int) num2 + 3]));
          num2 += (ushort) 4;
          animationSection.commands.Add(animationCommand);
        }
        this.sections.Add(animationSection);
      }
    }
  }
}
