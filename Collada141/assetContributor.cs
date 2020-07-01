// Decompiled with JetBrains decompiler
// Type: Collada141.assetContributor
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
  public class assetContributor
  {
    private string authorField;
    private string authoring_toolField;
    private string commentsField;
    private string copyrightField;
    private string source_dataField;

    public string author
    {
      get
      {
        return this.authorField;
      }
      set
      {
        this.authorField = value;
      }
    }

    public string authoring_tool
    {
      get
      {
        return this.authoring_toolField;
      }
      set
      {
        this.authoring_toolField = value;
      }
    }

    public string comments
    {
      get
      {
        return this.commentsField;
      }
      set
      {
        this.commentsField = value;
      }
    }

    public string copyright
    {
      get
      {
        return this.copyrightField;
      }
      set
      {
        this.copyrightField = value;
      }
    }

    [XmlElement(DataType = "anyURI")]
    public string source_data
    {
      get
      {
        return this.source_dataField;
      }
      set
      {
        this.source_dataField = value;
      }
    }
  }
}
