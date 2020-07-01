// Decompiled with JetBrains decompiler
// Type: Collada141.skinVertex_weights
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

using RummageAttributes;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Collada141
{
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [RummageKeepReflectionSafe]
  [Serializable]
  public class skinVertex_weights
  {
    private ulong countField;
    private Collada141.extra[] extraField;
    private InputLocalOffset[] inputField;
    private string vField;
    private string vcountField;

    [XmlElement("input")]
    public InputLocalOffset[] input
    {
      get
      {
        return this.inputField;
      }
      set
      {
        this.inputField = value;
      }
    }

    public string vcount
    {
      get
      {
        return this.vcountField;
      }
      set
      {
        this.vcountField = value;
      }
    }

    public string v
    {
      get
      {
        return this.vField;
      }
      set
      {
        this.vField = value;
      }
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get
      {
        return this.extraField;
      }
      set
      {
        this.extraField = value;
      }
    }

    [XmlAttribute]
    public ulong count
    {
      get
      {
        return this.countField;
      }
      set
      {
        this.countField = value;
      }
    }
  }
}
