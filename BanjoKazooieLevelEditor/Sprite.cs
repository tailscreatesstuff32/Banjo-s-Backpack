// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Sprite
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

using System.Collections.Generic;
using System.Drawing;

namespace BanjoKazooieLevelEditor
{
  public class Sprite
  {
    public string name = "";
    public List<Bitmap> frames = new List<Bitmap>();
    public SpriteTextureFormat textureFormat = SpriteTextureFormat.CI4;
    public int imagesPerFrame = 1;
    public bool compressed = true;
    public int id;
    public int pointer;
    public short numberFrames;
    public byte animationByte;

    public Sprite(int id_, string name_, int pointer_, bool compressed_)
    {
      this.id = id_;
      this.name = name_;
      this.pointer = pointer_;
      this.compressed = compressed_;
    }
  }
}
