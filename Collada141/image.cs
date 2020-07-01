// Decompiled with JetBrains decompiler
// Type: Collada141.image
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
  public class image
  {
    private asset assetField;
    private ulong depthField;
    private Collada141.extra[] extraField;
    private string formatField;
    private ulong heightField;
    private bool heightFieldSpecified;
    private string idField;
    private object itemField;
    private string nameField;
    private ulong widthField;
    private bool widthFieldSpecified;

    public image()
    {
      this.depthField = 1UL;
    }

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

    [XmlElement("data", typeof (byte[]), DataType = "hexBinary")]
    [XmlElement("init_from", typeof (string), DataType = "anyURI")]
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

    [XmlAttribute(DataType = "token")]
    public string format
    {
      get
      {
        return this.formatField;
      }
      set
      {
        this.formatField = value;
      }
    }

    [XmlAttribute]
    public ulong height
    {
      get
      {
        return this.heightField;
      }
      set
      {
        this.heightField = value;
      }
    }

    [XmlIgnore]
    public bool heightSpecified
    {
      get
      {
        return this.heightFieldSpecified;
      }
      set
      {
        this.heightFieldSpecified = value;
      }
    }

    [XmlAttribute]
    public ulong width
    {
      get
      {
        return this.widthField;
      }
      set
      {
        this.widthField = value;
      }
    }

    [XmlIgnore]
    public bool widthSpecified
    {
      get
      {
        return this.widthFieldSpecified;
      }
      set
      {
        this.widthFieldSpecified = value;
      }
    }

    [XmlAttribute]
    [DefaultValue(typeof (ulong), "1")]
    public ulong depth
    {
      get
      {
        return this.depthField;
      }
      set
      {
        this.depthField = value;
      }
    }
  }
}
