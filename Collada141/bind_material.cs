// Decompiled with JetBrains decompiler
// Type: Collada141.bind_material
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
  [XmlRoot(IsNullable = false, Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [RummageKeepReflectionSafe]
  [Serializable]
  public class bind_material
  {
    private Collada141.extra[] extraField;
    private Collada141.param[] paramField;
    private Collada141.technique[] techniqueField;
    private instance_material[] technique_commonField;

    [XmlElement("param")]
    public Collada141.param[] param
    {
      get
      {
        return this.paramField;
      }
      set
      {
        this.paramField = value;
      }
    }

    [XmlArrayItem("instance_material", IsNullable = false)]
    public instance_material[] technique_common
    {
      get
      {
        return this.technique_commonField;
      }
      set
      {
        this.technique_commonField = value;
      }
    }

    [XmlElement("technique")]
    public Collada141.technique[] technique
    {
      get
      {
        return this.techniqueField;
      }
      set
      {
        this.techniqueField = value;
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
  }
}
