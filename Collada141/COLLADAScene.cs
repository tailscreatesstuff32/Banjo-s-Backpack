// Decompiled with JetBrains decompiler
// Type: Collada141.COLLADAScene
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
  public class COLLADAScene
  {
    private Collada141.extra[] extraField;
    private InstanceWithExtra[] instance_physics_sceneField;
    private InstanceWithExtra instance_visual_sceneField;

    [XmlElement("instance_physics_scene")]
    public InstanceWithExtra[] instance_physics_scene
    {
      get
      {
        return this.instance_physics_sceneField;
      }
      set
      {
        this.instance_physics_sceneField = value;
      }
    }

    public InstanceWithExtra instance_visual_scene
    {
      get
      {
        return this.instance_visual_sceneField;
      }
      set
      {
        this.instance_visual_sceneField = value;
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
