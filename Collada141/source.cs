// Decompiled with JetBrains decompiler
// Type: Collada141.source
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
  public class source
  {
    private asset assetField;
    private string idField;
    private object itemField;
    private string nameField;
    private Collada141.technique[] techniqueField;
    private sourceTechnique_common technique_commonField;

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

    [XmlElement("IDREF_array", typeof (IDREF_array))]
    [XmlElement("Name_array", typeof (Name_array))]
    [XmlElement("bool_array", typeof (bool_array))]
    [XmlElement("float_array", typeof (float_array))]
    [XmlElement("int_array", typeof (int_array))]
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

    public sourceTechnique_common technique_common
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
