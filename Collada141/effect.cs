// Decompiled with JetBrains decompiler
// Type: Collada141.effect
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
  public class effect
  {
    private fx_annotate_common[] annotateField;
    private asset assetField;
    private Collada141.extra[] extraField;
    private string idField;
    private Collada141.image[] imageField;
    private effectFx_profile_abstractProfile_COMMON[] itemsField;
    private string nameField;
    private fx_newparam_common[] newparamField;

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

    [XmlElement("annotate")]
    public fx_annotate_common[] annotate
    {
      get
      {
        return this.annotateField;
      }
      set
      {
        this.annotateField = value;
      }
    }

    [XmlElement("image")]
    public Collada141.image[] image
    {
      get
      {
        return this.imageField;
      }
      set
      {
        this.imageField = value;
      }
    }

    [XmlElement("newparam")]
    public fx_newparam_common[] newparam
    {
      get
      {
        return this.newparamField;
      }
      set
      {
        this.newparamField = value;
      }
    }

    [XmlElement("profile_COMMON")]
    public effectFx_profile_abstractProfile_COMMON[] Items
    {
      get
      {
        return this.itemsField;
      }
      set
      {
        this.itemsField = value;
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
