// Decompiled with JetBrains decompiler
// Type: Collada141.technique
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

using RummageAttributes;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
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
  public class technique
  {
    private XmlElement[] anyField;
    private string profileField;

    [XmlAnyElement]
    public XmlElement[] Any
    {
      get
      {
        return this.anyField;
      }
      set
      {
        this.anyField = value;
      }
    }

    [XmlAttribute(DataType = "NMTOKEN")]
    public string profile
    {
      get
      {
        return this.profileField;
      }
      set
      {
        this.profileField = value;
      }
    }
  }
}
