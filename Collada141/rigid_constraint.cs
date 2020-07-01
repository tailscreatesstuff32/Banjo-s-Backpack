// Decompiled with JetBrains decompiler
// Type: Collada141.rigid_constraint
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
  public class rigid_constraint
  {
    private rigid_constraintAttachment attachmentField;
    private Collada141.extra[] extraField;
    private string nameField;
    private rigid_constraintRef_attachment ref_attachmentField;
    private string sidField;
    private Collada141.technique[] techniqueField;
    private rigid_constraintTechnique_common technique_commonField;

    public rigid_constraintRef_attachment ref_attachment
    {
      get
      {
        return this.ref_attachmentField;
      }
      set
      {
        this.ref_attachmentField = value;
      }
    }

    public rigid_constraintAttachment attachment
    {
      get
      {
        return this.attachmentField;
      }
      set
      {
        this.attachmentField = value;
      }
    }

    public rigid_constraintTechnique_common technique_common
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

    [XmlAttribute(DataType = "NCName")]
    public string sid
    {
      get
      {
        return this.sidField;
      }
      set
      {
        this.sidField = value;
      }
    }

    [XmlAttribute(DataType = "NCName")]
    public string name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }
  }
}
