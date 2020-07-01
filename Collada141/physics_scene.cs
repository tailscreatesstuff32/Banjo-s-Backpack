// Decompiled with JetBrains decompiler
// Type: Collada141.physics_scene
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
  public class physics_scene
  {
    private asset assetField;
    private Collada141.extra[] extraField;
    private string idField;
    private InstanceWithExtra[] instance_force_fieldField;
    private Collada141.instance_physics_model[] instance_physics_modelField;
    private string nameField;
    private Collada141.technique[] techniqueField;
    private physics_sceneTechnique_common technique_commonField;

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

    [XmlElement("instance_force_field")]
    public InstanceWithExtra[] instance_force_field
    {
      get
      {
        return this.instance_force_fieldField;
      }
      set
      {
        this.instance_force_fieldField = value;
      }
    }

    [XmlElement("instance_physics_model")]
    public Collada141.instance_physics_model[] instance_physics_model
    {
      get
      {
        return this.instance_physics_modelField;
      }
      set
      {
        this.instance_physics_modelField = value;
      }
    }

    public physics_sceneTechnique_common technique_common
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
