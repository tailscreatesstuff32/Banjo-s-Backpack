// Decompiled with JetBrains decompiler
// Type: Collada141.asset
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
  public class asset
  {
    private assetContributor[] contributorField;
    private DateTime createdField;
    private string keywordsField;
    private DateTime modifiedField;
    private string revisionField;
    private string subjectField;
    private string titleField;
    private assetUnit unitField;
    private UpAxisType up_axisField;

    public asset()
    {
      this.up_axisField = UpAxisType.Y_UP;
    }

    [XmlElement("contributor")]
    public assetContributor[] contributor
    {
      get
      {
        return this.contributorField;
      }
      set
      {
        this.contributorField = value;
      }
    }

    public DateTime created
    {
      get
      {
        return this.createdField;
      }
      set
      {
        this.createdField = value;
      }
    }

    public string keywords
    {
      get
      {
        return this.keywordsField;
      }
      set
      {
        this.keywordsField = value;
      }
    }

    public DateTime modified
    {
      get
      {
        return this.modifiedField;
      }
      set
      {
        this.modifiedField = value;
      }
    }

    public string revision
    {
      get
      {
        return this.revisionField;
      }
      set
      {
        this.revisionField = value;
      }
    }

    public string subject
    {
      get
      {
        return this.subjectField;
      }
      set
      {
        this.subjectField = value;
      }
    }

    public string title
    {
      get
      {
        return this.titleField;
      }
      set
      {
        this.titleField = value;
      }
    }

    public assetUnit unit
    {
      get
      {
        return this.unitField;
      }
      set
      {
        this.unitField = value;
      }
    }

    [DefaultValue(UpAxisType.Y_UP)]
    public UpAxisType up_axis
    {
      get
      {
        return this.up_axisField;
      }
      set
      {
        this.up_axisField = value;
      }
    }
  }
}
