// Decompiled with JetBrains decompiler
// Type: Collada141.geometry
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
  public class geometry
  {
    private asset assetField;
    private Collada141.extra[] extraField;
    private string idField;
    private object itemField;
    private string nameField;

    public asset asset
    {
      get
      {
        return this.assetField;
      }
      set
      {
        this.assetField = value;
      }
    }

    [XmlElement("convex_mesh", typeof (convex_mesh))]
    [XmlElement("mesh", typeof (mesh))]
    [XmlElement("spline", typeof (spline))]
    public object Item
    {
      get
      {
        return this.itemField;
      }
      set
      {
        this.itemField = value;
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

    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get
      {
        return this.idField;
      }
      set
      {
        this.idField = value;
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
