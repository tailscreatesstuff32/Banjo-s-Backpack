// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.ModelImportForm
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tao.OpenGl;

namespace BanjoKazooieLevelEditor
{
  public class ModelImportForm : Form
  {
    private Core core = new Core();
    private string path = Application.StartupPath;
    private F3DEX f3dex = new F3DEX();
    private List<TextureSetting> TextureSettings = new List<TextureSetting>();
    private List<TextureSetting> TextureSettingsAlpha = new List<TextureSetting>();
    private List<TextureData> TextureDataList = new List<TextureData>();
    private List<TextureData> TextureDataAlphaList = new List<TextureData>();
    private bool updateCollision = true;
    private bool updateGround = true;
    private bool updateSound = true;
    private bool updateCull = true;
    private bool updateColor = true;
    private int CollisionMode16 = 1;
    private int CollisionModeAuto = 2;
    private int collisionMode = 2;
    private bool canDeleteTmp = true;
    private bool vertUpdate = true;
    private float precision = 100f;
    private List<string> textureNames = new List<string>();
    private List<string> alphaTextureNames = new List<string>();
    private List<byte> solidTextureBytes = new List<byte>();
    private List<byte> alphaTextureBytes = new List<byte>();
    private List<byte[]> VTXCommands = new List<byte[]>();
    private List<byte[]> AlphaVTXCommands = new List<byte[]>();
    private List<int> VTXLocations = new List<int>();
    private List<int> AlphaVTXLocations = new List<int>();
    private List<int> textureLocations = new List<int>();
    private List<string> textureOrder = new List<string>();
    private List<TextureOffset> textureOffsets = new List<TextureOffset>();
    private List<TextureOffset> alphaTextureOffsets = new List<TextureOffset>();
    private List<int> alphaTextureLocations = new List<int>();
    private List<string> alphaTextureOrder = new List<string>();
    private List<TriangleGL> triangleGLs = new List<TriangleGL>();
    private List<TriangleGL> triangleGLAlphas = new List<TriangleGL>();
    private List<TriangleGL> originalTriangleGLs = new List<TriangleGL>();
    private List<TriangleGL> originalTriangleGLAlphas = new List<TriangleGL>();
    private string objFile = "";
    private string tmpFile = "";
    private string tmpFileA = "";
    private double speed = 60.0;
    private double finalz = -2161.0;
    private bool showBanjo = true;
    private bool forceRedraw = true;
    private string inDir = "";
    private bool drawEdges = true;
    private bool splitCol = true;
    private bool painting;
    private int currentImage;
    private bool sphereMap;
    private int CollisionMode1;
    private bool drawColMap;
    private bool drawSoundMap;
    private bool colPickMode;
    private bool triUpdate;
    private bool flipUpdate;
    private bool moveToAFile;
    private int tID;
    private bool colour16Mode;
    private int vertsToMake;
    private int alphaVertsToMake;
    private float xpos;
    private float ypos;
    private float zpos;
    private float xrot;
    private float yrot;
    private float zrot;
    private bool key_w;
    private bool key_a;
    private bool key_s;
    private bool key_d;
    private double yrotad;
    private double xrotad;
    private double zrotad;
    private double finaly;
    private double finalx;
    private int newx;
    private int newy;
    private int oldx;
    private int oldy;
    private bool sceneClick;
    private bool RotateSceneClick;
    private double[] banjoLocation;
    private int banjoRotation;
    private uint levelLinesList;
    private uint levelSelectionDL;
    private uint CollisionMapDL;
    private uint SoundMapDL;
    private uint banjoDList;
    private uint pickDListTriAlpha;
    private uint pickDListTri;
    private bool banjoMode;
    private bool movingBanjoClick;
    private bool rotateBanjoClick;
    private bool exitProgram;
    private int oldEditX;
    private int oldEditY;
    private int newEditX;
    private int newEditY;
    private bool triangleMode;
    private bool backspace_delete;
    private bool vertMode;
    private bool isSelecting;
    private IContainer components;
    private SaveFileDialog saveFileDialog1;
    private OpenFileDialog openFileDialog1;
    private Timer timer1;
    private Label label8;
    private TextBox red_tb;
    private TextBox green_tb;
    private Label label7;
    private TextBox alpha_tb;
    private Label label9;
    private TextBox blue_tb;
    private Label label10;
    private Label label11;
    private ComboBox collisionType_cb;
    private GroupBox vertPaint_gb;
    private ComboBox ground_cb;
    private Label label4;
    private PictureBox colorPick_pbx;
    private Panel pnlPreview;
    private ComboBox soundType_cb;
    private Label label5;
    private Label label12;
    private GroupBox mouseSettings_gb;
    internal TrackBar scale_tbar;
    private Label label2;
    private GroupBox groupBox4;
    private RadioButton triUpdate_rb;
    private RadioButton vertUpdate_rb;
    private RadioButton banjo_rb;
    private RadioButton camera_rb;
    private Label label13;
    private TextBox scale_tb;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem importOBJToolStripMenuItem;
    private ToolStripMenuItem openBinToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private OpenFileDialog openFD_bin;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem drawBanjoToolStripMenuItem;
    internal TrackBar CamSpeed_tb;
    private Label label3;
    private ToolStripMenuItem drawEdgesToolStripMenuItem;
    private Panel colour5_pnl;
    private Panel colour4_pnl;
    private Panel colour3_pnl;
    private Panel colour2_pnl;
    private Panel colour1_pnl;
    private GroupBox groupBox2;
    private CheckBox moveToA_cb;
    private TextBox moveZ_tb;
    private GroupBox col_modelMods_gb;
    private TextBox moveX_tb;
    private TextBox moveY_tb;
    private Label label6;
    private ToolStripMenuItem drawCollisionMapToolStripMenuItem;
    private Button colPick_btn;
    private ComboBox cullMode_cb;
    private Label label16;
    private Button flipV_btn;
    private ToolStripMenuItem drawSoundMapToolStripMenuItem;
    private ToolStripMenuItem collisionToolStripMenuItem;
    private ToolStripMenuItem collisionGroup16_tsmi;
    private ToolStripMenuItem groupCollisionAuto_tsmi;
    private CheckBox updateCull_cb;
    private CheckBox updateSound_cb;
    private CheckBox updateGround_cb;
    private CheckBox updateCollision_cb;
    private Panel panel1;
    private Panel panel3;
    private Panel panel2;
    private Panel panel4;
    private CheckBox updateColor_cb;
    private RadioButton flipUpdate_rb;
    private Button applyAll_btn;
    private FlowLayoutPanel flowLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel3;
    private Label label19;
    private Label label17;
    private Label label18;
    private Button col_model_mod_btn;
    private Button col_vertPaint_btn;
    private Panel colour6_pnl;
    private Panel collision_gb;
    private Button col_mouse_btn;
    private PictureBox tex_pb;
    private Button apply_texShade_btn;
    private Button nxt_btn;
    private Button pr_btn;
    private CheckBox clampV_cb;
    private CheckBox clampU_cb;
    private Label tex_lbl;
    private Panel panel5;
    private Label label1;
    private ToolStripMenuItem saveAsObjectModelToolStripMenuItem;
    private Panel panel6;
    private Label label14;
    private CheckBox sphereMap_cb;
    private Panel panel7;
    private Label label15;
    private CheckBox genWaves_cb;
    private Panel panel8;
    private Label label20;
    private CheckBox animVert_cb;
    private GLControl simpleOpenGlControl1;
    private Panel panel9;
    private Label label21;
    private CheckBox scrollTexture_cb;
    private ComboBox scrollMode_cb;

    public byte[] calculateWaves(ref List<TriangleGL> tris)
    {
      List<byte> byteList = new List<byte>();
      byteList.Add((byte) 2);
      byteList.Add((byte) 196);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      for (int index = 0; index < tris.Count; ++index)
      {
        if (tris[index].genWave)
        {
          int num1 = index * 3;
          byteList.Add((byte) (num1 >> 8));
          byteList.Add((byte) num1);
          int num2 = index * 3 + 1;
          byteList.Add((byte) (num2 >> 8));
          byteList.Add((byte) num2);
          int num3 = index * 3 + 2;
          byteList.Add((byte) (num3 >> 8));
          byteList.Add((byte) num3);
        }
      }
      byteList[2] = (byte) ((byteList.Count - 4) / 2 >> 8);
      byteList[3] = (byte) ((byteList.Count - 4) / 2);
      return byteList.ToArray();
    }

    public byte[] calculateVertexColourEffect(ref List<TriangleGL> tris)
    {
      List<byte> byteList = new List<byte>();
      byteList.Add((byte) 0);
      byteList.Add((byte) 200);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      for (int index1 = 0; index1 < tris.Count; ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
          if (tris[index1].verts[index2].animateVertColour)
          {
            int num = index1 * 3 + index2;
            byteList.Add((byte) (num >> 8));
            byteList.Add((byte) num);
          }
        }
      }
      byteList[2] = (byte) ((byteList.Count - 4) / 2 >> 8);
      byteList[3] = (byte) ((byteList.Count - 4) / 2);
      if (byteList.Count < 5)
        byteList.Clear();
      return byteList.ToArray();
    }

    public byte[] calculateTextureScrollEffect(ref List<TriangleGL> tris, ScrollSpeed speed)
    {
      List<byte> byteList = new List<byte>();
      byteList.Add((byte) 0);
      byteList.Add((byte) speed);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      for (int index1 = 0; index1 < tris.Count; ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
          if (tris[index1].verts[index2].scrollTexture && speed == ScrollSpeed.Normal || tris[index1].verts[index2].scrollTextureFast && speed == ScrollSpeed.Fast || tris[index1].verts[index2].scrollTextureSlow && speed == ScrollSpeed.Slow)
          {
            int num = index1 * 3 + index2;
            byteList.Add((byte) (num >> 8));
            byteList.Add((byte) num);
          }
        }
      }
      byteList[2] = (byte) ((byteList.Count - 4) / 2 >> 8);
      byteList[3] = (byte) ((byteList.Count - 4) / 2);
      if (byteList.Count < 5)
        byteList.Clear();
      return byteList.ToArray();
    }

    public void drawNormals()
    {
      GL.PushMatrix();
      foreach (TriangleGL triangleGl in this.triangleGLs)
      {
        if (this.TextureSettings[triangleGl.textureSetting].textureMode == (byte) 6)
        {
          foreach (VertGL vert in triangleGl.verts)
          {
            GL.Begin(BeginMode.Lines);
            GL.Color3(0.0f, 0.0f, 0.0f);
            GL.LineWidth(0.2f);
            GL.Vertex3(vert.x, vert.y, vert.z);
            float[] numArray = new float[3]
            {
              (sbyte) vert.r < (sbyte) 0 ? (float) (sbyte) vert.r / 128f : (float) (sbyte) vert.r / (float) sbyte.MaxValue,
              (sbyte) vert.g < (sbyte) 0 ? (float) (sbyte) vert.g / 128f : (float) (sbyte) vert.g / (float) sbyte.MaxValue,
              (sbyte) vert.b < (sbyte) 0 ? (float) (sbyte) vert.b / 128f : (float) (sbyte) vert.b / (float) sbyte.MaxValue
            };
            float num = 100f;
            GL.Vertex3((float) vert.x + numArray[0] * num, (float) vert.y + numArray[1] * num, (float) vert.z + numArray[2] * num);
            GL.End();
          }
        }
      }
      GL.PopMatrix();
    }

    public ModelImportForm(string inDir_)
    {
      this.banjoLocation = new double[3];
      this.inDir = inDir_ + "\\";
      this.InitializeComponent();
    }

    private void ModelImportForm_Load(object sender, EventArgs e)
    {
      this.forceRedraw = true;
      this.simpleOpenGlControl1.SwapBuffers();
      this.simpleOpenGlControl1.Invalidate();
    }

    private void BanjoDL()
    {
      try
      {
        GL.PushMatrix();
        this.banjoDList = this.core.GenerateDL();
        this.core.DrawModelFile(this.path + "\\resources\\banjo.mw", 0.0f, 0.0f, 0.0f, 0, 100f, (ushort) 0, false);
        this.core.EndDL();
        GL.PopMatrix();
      }
      catch
      {
      }
    }

    private void RenderLevelWithSelection()
    {
      GL.DeleteLists(this.levelSelectionDL, 1);
      this.levelSelectionDL = (uint) GL.GenLists(1);
      GL.NewList(this.levelSelectionDL, ListMode.Compile);
      this.DrawInternalStructure(false, false);
      this.DrawInternalStructure(true, false);
      GL.EndList();
      GL.DeleteLists(this.CollisionMapDL, 1);
      this.CollisionMapDL = (uint) GL.GenLists(1);
      GL.NewList(this.CollisionMapDL, ListMode.Compile);
      this.DrawCollisionMap(false);
      this.DrawCollisionMap(true);
      GL.EndList();
      GL.DeleteLists(this.SoundMapDL, 1);
      this.SoundMapDL = (uint) GL.GenLists(1);
      GL.NewList(this.SoundMapDL, ListMode.Compile);
      this.DrawSoundMap(false);
      this.DrawSoundMap(true);
      GL.EndList();
      this.RenderPick();
    }

    private void RenderLines()
    {
      GL.DeleteLists(this.levelLinesList, 1);
      this.levelLinesList = (uint) GL.GenLists(1);
      GL.NewList(this.levelLinesList, ListMode.Compile);
      this.DrawInternalStructureLines(false);
      this.DrawInternalStructureLines(true);
      GL.EndList();
    }

    private void RenderPick()
    {
      GL.DeleteLists(this.pickDListTri, 1);
      this.pickDListTri = (uint) GL.GenLists(1);
      GL.NewList(this.pickDListTri, ListMode.Compile);
      this.DrawInternalStructure(false, true);
      GL.EndList();
      GL.DeleteLists(this.pickDListTriAlpha, 1);
      this.pickDListTriAlpha = (uint) GL.GenLists(1);
      GL.NewList(this.pickDListTriAlpha, ListMode.Compile);
      this.DrawInternalStructure(true, true);
      GL.EndList();
    }

    private void camera()
    {
      bool flag = false;
      this.yrotad = (double) this.yrot / 180.0 * 3.14159265;
      this.xrotad = (double) this.xrot / 180.0 * 3.14159265;
      this.zrotad = (double) this.zrot / 180.0 * 3.14159265;
      if (this.key_w)
      {
        flag = true;
        if ((double) this.xrot >= 85.0 || (double) this.xrot <= -85.0)
        {
          this.finaly += Math.Sin(this.xrotad) * this.speed;
        }
        else
        {
          this.finalx -= Math.Sin(this.yrotad) * this.speed;
          this.finalz += Math.Cos(this.yrotad) * this.speed;
          this.finaly += Math.Sin(this.xrotad) * this.speed;
        }
      }
      if (this.key_s)
      {
        flag = true;
        if ((double) this.xrot <= -85.0 || (double) this.xrot >= 85.0)
        {
          this.finaly -= Math.Sin(this.xrotad) * this.speed;
        }
        else
        {
          this.finalx += Math.Sin(this.yrotad) * this.speed;
          this.finalz -= Math.Cos(this.yrotad) * this.speed;
          this.finaly -= Math.Sin(this.xrotad) * this.speed;
        }
      }
      if (this.key_d)
      {
        flag = true;
        this.finalx -= Math.Cos(this.yrotad) * this.speed;
        this.finalz -= Math.Sin(this.yrotad) * this.speed;
      }
      if (this.key_a)
      {
        flag = true;
        this.finalx += Math.Cos(this.yrotad) * this.speed;
        this.finalz += Math.Sin(this.yrotad) * this.speed;
      }
      Point mousePosition1 = Control.MousePosition;
      this.newx = mousePosition1.X;
      mousePosition1 = Control.MousePosition;
      this.newy = mousePosition1.Y;
      if (this.RotateSceneClick)
      {
        flag = true;
        if (this.oldx < this.newx)
          this.yrot += (float) (this.newx - this.oldx) * 0.25f;
        if (this.oldx > this.newx)
          this.yrot -= (float) (this.oldx - this.newx) * 0.25f;
        if (this.oldy > this.newy)
        {
          if ((double) this.xrot <= -90.0)
            this.xrot = -90f;
          else
            this.xrot -= (float) (this.oldy - this.newy) * 0.25f;
        }
        if (this.oldy < this.newy)
        {
          if ((double) this.xrot >= 90.0)
            this.xrot = 90f;
          else
            this.xrot += (float) (this.newy - this.oldy) * 0.25f;
        }
      }
      if (this.forceRedraw || this.sceneClick)
      {
        flag = true;
        this.forceRedraw = false;
      }
      Point mousePosition2 = Control.MousePosition;
      this.oldx = mousePosition2.X;
      mousePosition2 = Control.MousePosition;
      this.oldy = mousePosition2.Y;
      if (!flag)
        return;
      this.core.ClearScreenAndLoadIdentity();
      GL.PushMatrix();
      this.SetCameraView();
      this.Redraw();
      GL.PopMatrix();
      this.simpleOpenGlControl1.SwapBuffers();
    }

    private void Redraw()
    {
      GL.PushMatrix();
      if (this.showBanjo)
      {
        GL.PushMatrix();
        GL.Translate((float) this.banjoLocation[0], (float) this.banjoLocation[1], (float) this.banjoLocation[2]);
        GL.Rotate((float) this.banjoRotation, 0.0f, 1f, 0.0f);
        GL.CallList(this.banjoDList);
        GL.PopMatrix();
      }
      if (!this.drawColMap && !this.drawSoundMap)
        GL.CallList(this.levelSelectionDL);
      else if (this.drawSoundMap)
        GL.CallList(this.SoundMapDL);
      else if (this.drawColMap)
        GL.CallList(this.CollisionMapDL);
      if (this.drawEdges)
        GL.CallList(this.levelLinesList);
      GL.PopMatrix();
    }

    private void SetCameraView()
    {
      GL.Rotate(this.xrot, 1f, 0.0f, 0.0f);
      GL.Rotate(this.yrot, 0.0f, 1f, 0.0f);
      GL.Rotate(this.zrot, 0.0f, 0.0f, 1f);
      GL.Translate((float) this.finalx, (float) this.finaly, (float) this.finalz);
    }

    private void pickVert(int x, int y)
    {
      GL.PushMatrix();
      this.SetCameraView();
      bool isAlpha = false;
      int selectedTri = this.pickColorTri(x, y, ref isAlpha);
      GL.PopMatrix();
      this.core.ClearScreenAndLoadIdentity();
      if (selectedTri != -1)
      {
        GL.PushMatrix();
        this.SetCameraView();
        int closestVert = this.getClosestVert(x, y, selectedTri, isAlpha);
        GL.PopMatrix();
        this.core.ClearScreenAndLoadIdentity();
        if (this.colPickMode)
        {
          TriangleGL triangleGl = isAlpha ? this.triangleGLAlphas[selectedTri] : this.triangleGLs[selectedTri];
          this.red_tb.Text = Convert.ToString(triangleGl.verts[closestVert].r);
          this.green_tb.Text = Convert.ToString(triangleGl.verts[closestVert].g);
          this.blue_tb.Text = Convert.ToString(triangleGl.verts[closestVert].b);
          this.alpha_tb.Text = Convert.ToString(triangleGl.verts[closestVert].a);
          this.pnlPreview.BackColor = Color.FromArgb((int) triangleGl.verts[closestVert].a, (int) triangleGl.verts[closestVert].r, (int) triangleGl.verts[closestVert].g, (int) triangleGl.verts[closestVert].b);
        }
        else
          this.updateVertTri(selectedTri, closestVert, isAlpha);
        this.RenderLevelWithSelection();
      }
      Core.InitGl();
    }

    public int getClosestVert(int x, int y, int selectedTri, bool alpha)
    {
      this.core.ClearScreenAndLoadIdentity();
      GL.PushMatrix();
      this.SetCameraView();
      TriangleGL triangleGl = alpha ? this.triangleGLAlphas[selectedTri] : this.triangleGLs[selectedTri];
      GL.Disable(EnableCap.CullFace);
      GL.Begin(BeginMode.Triangles);
      GL.Color4(1, 1, 1, 1);
      GL.Vertex3(triangleGl.verts[0].x, triangleGl.verts[0].y, triangleGl.verts[0].z);
      GL.Vertex3(triangleGl.verts[1].x, triangleGl.verts[1].y, triangleGl.verts[1].z);
      GL.Vertex3(triangleGl.verts[2].x, triangleGl.verts[2].y, triangleGl.verts[2].z);
      GL.End();
      int[] numArray1 = new int[4];
      double[] numArray2 = new double[16];
      double[] numArray3 = new double[16];
      GL.GetInteger(GetPName.Viewport, numArray1);
      GL.GetDouble(GetPName.Modelview0MatrixExt, numArray2);
      GL.GetDouble(GetPName.ProjectionMatrix, numArray3);
      int num1 = numArray1[3];
      int x1 = x;
      int num2 = y;
      int y1 = num1 - num2;
      float[] pixels = new float[1];
      GL.ReadPixels<float>(x1, y1, 1, 1, OpenTK.Graphics.OpenGL.PixelFormat.DepthComponent, PixelType.Float, pixels);
      double objX = 0.0;
      double objY = 0.0;
      double objZ = 0.0;
      Glu.gluUnProject((double) x1, (double) y1, (double) pixels[0], numArray2, numArray3, numArray1, out objX, out objY, out objZ);
      GL.PopMatrix();
      int num3 = 0;
      double num4 = Math.Sqrt(Math.Pow((double) triangleGl.verts[0].x - objX, 2.0) + Math.Pow((double) triangleGl.verts[0].y - objY, 2.0) + Math.Pow((double) triangleGl.verts[0].z - objZ, 2.0));
      double num5 = Math.Sqrt(Math.Pow((double) triangleGl.verts[1].x - objX, 2.0) + Math.Pow((double) triangleGl.verts[1].y - objY, 2.0) + Math.Pow((double) triangleGl.verts[1].z - objZ, 2.0));
      double num6 = Math.Sqrt(Math.Pow((double) triangleGl.verts[2].x - objX, 2.0) + Math.Pow((double) triangleGl.verts[2].y - objY, 2.0) + Math.Pow((double) triangleGl.verts[2].z - objZ, 2.0));
      if (num4 < num5 && num4 < num6)
        num3 = 0;
      if (num5 < num4 && num5 < num6)
        num3 = 1;
      if (num6 < num5 && num6 < num4)
        num3 = 2;
      return num3;
    }

    public int pickColorTri(int x, int y, ref bool isAlpha)
    {
      GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
      GL.Disable(EnableCap.Texture2D);
      GL.Disable(EnableCap.Fog);
      GL.Disable(EnableCap.Lighting);
      GL.ShadeModel(ShadingModel.Flat);
      GL.PushMatrix();
      GL.Translate(0.0f, 0.0f, 0.0f);
      GL.Rotate(0.0f, 1f, 0.0f, 0.0f);
      GL.Rotate(0.0f, 0.0f, 1f, 0.0f);
      GL.Rotate(0.0f, 0.0f, 0.0f, 1f);
      GL.CallList(this.pickDListTri);
      GL.CallList(this.pickDListTriAlpha);
      GL.PopMatrix();
      byte[] pixels = new byte[3];
      int[] data = new int[4];
      GL.GetInteger(GetPName.Viewport, data);
      GL.ReadPixels<byte>(x, data[3] - y, 1, 1, OpenTK.Graphics.OpenGL.PixelFormat.Rgb, PixelType.UnsignedByte, pixels);
      int num = -1;
      for (int index = 0; index < this.triangleGLs.Count; ++index)
      {
        if ((int) this.triangleGLs[index].pickObj.m_colorID[0] == (int) pixels[0] && (int) this.triangleGLs[index].pickObj.m_colorID[1] == (int) pixels[1] && (int) this.triangleGLs[index].pickObj.m_colorID[2] == (int) pixels[2])
          num = index;
      }
      if (num == -1)
      {
        for (int index = 0; index < this.triangleGLAlphas.Count; ++index)
        {
          if ((int) this.triangleGLAlphas[index].pickObj.m_colorID[0] == (int) pixels[0] && (int) this.triangleGLAlphas[index].pickObj.m_colorID[1] == (int) pixels[1] && (int) this.triangleGLAlphas[index].pickObj.m_colorID[2] == (int) pixels[2])
          {
            num = index;
            isAlpha = true;
          }
        }
      }
      return num;
    }

    private SoundType getSoundByte()
    {
      SoundType soundType = SoundType.Normal;
      if (this.soundType_cb.Text == "Metal")
        soundType = SoundType.Metal;
      else if (this.soundType_cb.Text == "Hard Ground")
        soundType = SoundType.HardGround;
      else if (this.soundType_cb.Text == "Stone")
        soundType = SoundType.Stone;
      else if (this.soundType_cb.Text == "Wood")
        soundType = SoundType.Wood;
      else if (this.soundType_cb.Text == "Snow")
        soundType = SoundType.Snow;
      else if (this.soundType_cb.Text == "Leaves")
        soundType = SoundType.Leaves;
      else if (this.soundType_cb.Text == "Swamp")
        soundType = SoundType.Swamp;
      else if (this.soundType_cb.Text == "Sand")
        soundType = SoundType.Sand;
      else if (this.soundType_cb.Text == "Slush")
        soundType = SoundType.Slush;
      return soundType;
    }

    private CollisionType getCollisionByte()
    {
      CollisionType collisionType = CollisionType.Ground;
      if (this.collisionType_cb.Text == "Water")
        collisionType = CollisionType.Water;
      else if (this.collisionType_cb.Text == "Double Sided")
        collisionType = CollisionType.DoubleSided;
      else if (this.collisionType_cb.Text == "No Collision")
        collisionType = CollisionType.NoCollision;
      return collisionType;
    }

    private GroundType getGroundByte()
    {
      GroundType groundType = GroundType.Normal;
      if (this.ground_cb.Text == "Talon Trot")
        groundType = GroundType.Talon;
      else if (this.ground_cb.Text == "Unclimbable")
        groundType = GroundType.Unclimbable;
      return groundType;
    }

    private void apply_texShade_btn_Click(object sender, EventArgs e)
    {
      if (this.currentImage < this.TextureDataList.Count)
      {
        for (int selected = 0; selected < this.triangleGLs.Count<TriangleGL>(); ++selected)
        {
          if (this.TextureSettings[this.triangleGLs[selected].textureSetting].textureData == this.currentImage)
          {
            TextureSetting ts = TextureSetting.clone(this.TextureSettings[this.triangleGLs[selected].textureSetting]);
            byte[] oldA = new byte[3];
            bool flag = false;
            for (int index = 0; index < 3; ++index)
            {
              flag = false;
              oldA[index] = this.triangleGLs[selected].verts[index].a;
              if (this.updateColor)
              {
                this.triangleGLs[selected].verts[index].r = Convert.ToByte(this.red_tb.Text);
                this.triangleGLs[selected].verts[index].g = Convert.ToByte(this.green_tb.Text);
                this.triangleGLs[selected].verts[index].b = Convert.ToByte(this.blue_tb.Text);
                this.triangleGLs[selected].verts[index].a = Convert.ToByte(this.alpha_tb.Text);
              }
              if (oldA[0] == byte.MaxValue && oldA[1] == byte.MaxValue && oldA[2] == byte.MaxValue && (this.triangleGLs[selected].verts[0].a < byte.MaxValue || this.triangleGLs[selected].verts[1].a < byte.MaxValue || this.triangleGLs[selected].verts[2].a < byte.MaxValue) || this.triangleGLs[selected].collisionType == CollisionType.Water)
                flag = true;
            }
            this.updateTriangle(this.triangleGLs[selected], ts, oldA, false, selected);
            if (flag)
              --selected;
          }
        }
      }
      else
      {
        int num = this.currentImage - this.TextureDataList.Count;
        for (int selected = 0; selected < this.triangleGLAlphas.Count<TriangleGL>(); ++selected)
        {
          if (this.TextureSettingsAlpha[this.triangleGLAlphas[selected].textureSetting].textureData == num)
          {
            TextureSetting ts = TextureSetting.clone(this.TextureSettingsAlpha[this.triangleGLAlphas[selected].textureSetting]);
            byte[] oldA = new byte[3];
            for (int index = 0; index < 3; ++index)
            {
              oldA[index] = this.triangleGLAlphas[selected].verts[index].a;
              if (this.updateColor)
              {
                this.triangleGLAlphas[selected].verts[index].r = Convert.ToByte(this.red_tb.Text);
                this.triangleGLAlphas[selected].verts[index].g = Convert.ToByte(this.green_tb.Text);
                this.triangleGLAlphas[selected].verts[index].b = Convert.ToByte(this.blue_tb.Text);
                this.triangleGLAlphas[selected].verts[index].a = Convert.ToByte(this.alpha_tb.Text);
              }
            }
            this.updateTriangle(this.triangleGLAlphas[selected], ts, oldA, true, selected);
          }
        }
      }
      this.RenderLevelWithSelection();
      this.RenderLines();
      this.RenderPick();
      this.forceRedraw = true;
    }

    public void updateVertTri(int selectedTri, int vertNumber, bool alpha)
    {
      if (this.flipUpdate)
      {
        if (!alpha)
        {
          VertGL[] vertGlArray = new VertGL[3]
          {
            this.triangleGLs[selectedTri].verts[0],
            this.triangleGLs[selectedTri].verts[1],
            this.triangleGLs[selectedTri].verts[2]
          };
          this.triangleGLs[selectedTri].verts[0] = vertGlArray[2];
          this.triangleGLs[selectedTri].verts[2] = vertGlArray[0];
        }
        else
        {
          VertGL[] vertGlArray = new VertGL[3]
          {
            this.triangleGLAlphas[selectedTri].verts[0],
            this.triangleGLAlphas[selectedTri].verts[1],
            this.triangleGLAlphas[selectedTri].verts[2]
          };
          this.triangleGLAlphas[selectedTri].verts[0] = vertGlArray[2];
          this.triangleGLAlphas[selectedTri].verts[2] = vertGlArray[0];
        }
        this.RenderPick();
        this.core.ClearScreenAndLoadIdentity();
      }
      else
      {
        try
        {
          TriangleGL tri1;
          TextureSetting ts;
          if (!alpha)
          {
            tri1 = new TriangleGL(new VertGL[3]
            {
              this.triangleGLs[selectedTri].verts[0],
              this.triangleGLs[selectedTri].verts[1],
              this.triangleGLs[selectedTri].verts[2]
            }, this.triangleGLs[selectedTri].textureSetting, this.triangleGLs[selectedTri].pickObj);
            ts = TextureSetting.clone(this.TextureSettings[tri1.textureSetting]);
          }
          else
          {
            tri1 = new TriangleGL(new VertGL[3]
            {
              this.triangleGLAlphas[selectedTri].verts[0],
              this.triangleGLAlphas[selectedTri].verts[1],
              this.triangleGLAlphas[selectedTri].verts[2]
            }, this.triangleGLAlphas[selectedTri].textureSetting, this.triangleGLAlphas[selectedTri].pickObj);
            ts = TextureSetting.clone(this.TextureSettingsAlpha[tri1.textureSetting]);
          }
          byte[] oldA = new byte[3]
          {
            tri1.verts[0].a,
            tri1.verts[1].a,
            tri1.verts[2].a
          };
          if (this.vertUpdate)
          {
            if (this.updateColor)
            {
              tri1.verts[vertNumber].r = Convert.ToByte(this.red_tb.Text);
              tri1.verts[vertNumber].g = Convert.ToByte(this.green_tb.Text);
              tri1.verts[vertNumber].b = Convert.ToByte(this.blue_tb.Text);
              tri1.verts[vertNumber].a = Convert.ToByte(this.alpha_tb.Text);
            }
            tri1.verts[vertNumber].animateVertColour = this.animVert_cb.Checked;
            tri1.verts[vertNumber].scrollTexture = false;
            tri1.verts[vertNumber].scrollTextureSlow = false;
            tri1.verts[vertNumber].scrollTextureFast = false;
            if (this.scrollTexture_cb.Checked)
            {
              if (this.scrollMode_cb.Text == "Slow")
                tri1.verts[vertNumber].scrollTextureSlow = true;
              if (this.scrollMode_cb.Text == "Normal")
                tri1.verts[vertNumber].scrollTexture = true;
              if (this.scrollMode_cb.Text == "Fast")
                tri1.verts[vertNumber].scrollTextureFast = true;
            }
          }
          else if (this.triUpdate)
          {
            if (this.updateColor)
            {
              for (int index = 0; index < 3; ++index)
              {
                tri1.verts[index].r = Convert.ToByte(this.red_tb.Text);
                tri1.verts[index].g = Convert.ToByte(this.green_tb.Text);
                tri1.verts[index].b = Convert.ToByte(this.blue_tb.Text);
                tri1.verts[index].a = Convert.ToByte(this.alpha_tb.Text);
              }
            }
            for (int index = 0; index < 3; ++index)
            {
              tri1.verts[index].animateVertColour = this.animVert_cb.Checked;
              tri1.verts[index].scrollTexture = false;
              tri1.verts[index].scrollTextureSlow = false;
              tri1.verts[index].scrollTextureFast = false;
              if (this.scrollTexture_cb.Checked)
              {
                if (this.scrollMode_cb.Text == "Slow")
                  tri1.verts[index].scrollTextureSlow = true;
                if (this.scrollMode_cb.Text == "Normal")
                  tri1.verts[index].scrollTexture = true;
                if (this.scrollMode_cb.Text == "Fast")
                  tri1.verts[index].scrollTextureFast = true;
              }
            }
          }
          tri1.genWave = this.genWaves_cb.Checked;
          if (this.sphereMap)
          {
            foreach (VertGL vert in tri1.verts)
            {
              List<TriangleGL> connectingTris = this.getConnectingTris(vert);
              List<ModelImportForm.Vector> vectorList = new List<ModelImportForm.Vector>();
              vectorList.Add(this.getTriangleNormal(tri1));
              foreach (TriangleGL tri2 in connectingTris)
                vectorList.Add(this.getTriangleNormal(tri2));
              ModelImportForm.Vector v = new ModelImportForm.Vector(0.0f, 0.0f, 0.0f);
              foreach (ModelImportForm.Vector vector in vectorList)
              {
                v.x += vector.x;
                v.y += vector.y;
                v.z += vector.z;
              }
              ModelImportForm.Vector unit = this.ReduceToUnit(v);
              byte[] numArray = new byte[3]
              {
                (double) unit.x < 0.0 ? (byte) ((double) unit.x * 128.0) : (byte) ((double) unit.x * (double) sbyte.MaxValue),
                (double) unit.y < 0.0 ? (byte) ((double) unit.y * 128.0) : (byte) ((double) unit.y * (double) sbyte.MaxValue),
                (double) unit.z < 0.0 ? (byte) ((double) unit.z * 128.0) : (byte) ((double) unit.z * (double) sbyte.MaxValue)
              };
              vert.r = numArray[0];
              vert.g = numArray[1];
              vert.b = numArray[2];
            }
          }
          this.updateTriangle(tri1, ts, oldA, alpha, selectedTri);
        }
        catch (Exception ex)
        {
        }
        this.core.ClearScreenAndLoadIdentity();
      }
    }

    private ModelImportForm.Vector getTriangleNormal(TriangleGL tri)
    {
      ModelImportForm.Vector vector1 = new ModelImportForm.Vector((float) tri.verts[0].x, (float) tri.verts[0].y, (float) tri.verts[0].z);
      ModelImportForm.Vector vector2 = new ModelImportForm.Vector((float) tri.verts[1].x, (float) tri.verts[1].y, (float) tri.verts[1].z);
      ModelImportForm.Vector vector3 = new ModelImportForm.Vector((float) tri.verts[2].x, (float) tri.verts[2].y, (float) tri.verts[2].z);
      return this.Cross(vector2 - vector1, vector3 - vector1);
    }

    private List<TriangleGL> getConnectingTris(VertGL v)
    {
      List<TriangleGL> triangleGlList = new List<TriangleGL>();
      foreach (TriangleGL triangleGl in this.triangleGLs)
      {
        foreach (VertGL vert in triangleGl.verts)
        {
          if ((int) v.x == (int) vert.x && (int) v.y == (int) vert.y && (int) v.z == (int) vert.z)
            triangleGlList.Add(triangleGl);
        }
      }
      foreach (TriangleGL triangleGlAlpha in this.triangleGLAlphas)
      {
        foreach (VertGL vert in triangleGlAlpha.verts)
        {
          if ((int) v.x == (int) vert.x && (int) v.y == (int) vert.y && (int) v.z == (int) vert.z)
            triangleGlList.Add(triangleGlAlpha);
        }
      }
      return triangleGlList;
    }

    private void updateTriangle(
      TriangleGL tri,
      TextureSetting ts,
      byte[] oldA,
      bool alpha,
      int selected)
    {
      if (this.updateCollision)
        tri.collisionType = this.getCollisionByte();
      if (this.updateSound)
        tri.soundType = this.getSoundByte();
      if (this.updateGround)
        tri.groundType = this.getGroundByte();
      if (this.updateCull)
      {
        ts.cull_back = false;
        ts.cull_front = false;
        ts.cull_none = false;
        ts.cull_both = false;
        if (this.cullMode_cb.Text == "None")
          ts.cull_none = true;
        else if (this.cullMode_cb.Text == "Front")
          ts.cull_front = true;
        else if (this.cullMode_cb.Text == "Back")
          ts.cull_back = true;
        else if (this.cullMode_cb.Text == "Both")
          ts.cull_both = true;
      }
      ts.textureMode = !this.sphereMap ? (byte) 8 : (byte) 6;
      if (this.moveToAFile)
      {
        if (alpha)
        {
          this.triangleGLAlphas.RemoveAt(selected);
          TriangleGL originalTriangleGlAlpha = this.originalTriangleGLAlphas[selected];
          this.originalTriangleGLAlphas.RemoveAt(selected);
          bool flag1 = true;
          if (this.TextureSettingsAlpha[tri.textureSetting].textureData != -1)
          {
            for (int index = 0; index < this.TextureDataList.Count & flag1; ++index)
            {
              if (((IEnumerable<byte>) this.TextureDataAlphaList[this.TextureSettingsAlpha[tri.textureSetting].textureData].n64).SequenceEqual<byte>((IEnumerable<byte>) this.TextureDataList[index].n64))
              {
                ts.textureData = index;
                flag1 = false;
              }
            }
            if (flag1)
            {
              this.TextureDataList.Add(this.TextureDataAlphaList[this.TextureSettingsAlpha[tri.textureSetting].textureData]);
              ts.textureData = this.TextureDataList.Count - 1;
              this.TextureSettings.Add(ts);
              tri.textureSetting = this.TextureSettings.Count - 1;
            }
            if (!flag1 && this.TextureSettingsAlpha[tri.textureSetting].textureData != -1)
            {
              bool flag2 = true;
              for (int index = 0; index < this.TextureSettings.Count & flag2; ++index)
              {
                if (this.TextureSettings[index].equal(ts))
                {
                  tri.textureSetting = index;
                  flag2 = false;
                }
              }
              if (flag2)
              {
                this.TextureSettings.Add(ts);
                tri.textureSetting = this.TextureSettings.Count - 1;
              }
            }
          }
          else if (this.TextureSettingsAlpha[tri.textureSetting].textureData == -1)
          {
            bool flag2 = true;
            for (int index = 0; index < this.TextureSettings.Count; ++index)
            {
              if (this.TextureSettings[index].equal(ts))
              {
                tri.textureSetting = index;
                flag2 = false;
              }
            }
            if (flag2)
            {
              this.TextureSettings.Add(ts);
              tri.textureSetting = this.TextureSettings.Count - 1;
            }
          }
          this.triangleGLs.Add(tri);
          this.originalTriangleGLs.Add(originalTriangleGlAlpha);
          this.RenderPick();
          this.core.ClearScreenAndLoadIdentity();
        }
        else if (oldA[0] == byte.MaxValue && oldA[1] == byte.MaxValue && oldA[2] == byte.MaxValue && (tri.verts[0].a < byte.MaxValue || tri.verts[1].a < byte.MaxValue || tri.verts[2].a < byte.MaxValue))
        {
          bool flag = true;
          for (int index = 0; index < this.TextureSettings.Count & flag; ++index)
          {
            if (this.TextureSettings[index].equal(ts))
            {
              tri.textureSetting = index;
              flag = false;
            }
          }
          if (flag)
          {
            this.TextureSettings.Add(ts);
            tri.textureSetting = this.TextureSettings.Count - 1;
          }
          this.triangleGLs.RemoveAt(selected);
          this.triangleGLs.Add(tri);
          TriangleGL originalTriangleGl = this.originalTriangleGLs[selected];
          this.originalTriangleGLs.RemoveAt(selected);
          this.originalTriangleGLs.Add(originalTriangleGl);
          this.RenderPick();
          this.core.ClearScreenAndLoadIdentity();
        }
        else
          this.normalUpdate(ts, tri, selected);
      }
      else if (!alpha)
      {
        if (oldA[0] == byte.MaxValue && oldA[1] == byte.MaxValue && oldA[2] == byte.MaxValue && (tri.verts[0].a < byte.MaxValue || tri.verts[1].a < byte.MaxValue || tri.verts[2].a < byte.MaxValue) || tri.collisionType == CollisionType.Water)
        {
          bool flag1 = true;
          if (this.TextureSettings[tri.textureSetting].textureData != -1)
          {
            for (int index = 0; index < this.TextureDataAlphaList.Count & flag1; ++index)
            {
              if (((IEnumerable<byte>) this.TextureDataList[this.TextureSettings[tri.textureSetting].textureData].n64).SequenceEqual<byte>((IEnumerable<byte>) this.TextureDataAlphaList[index].n64))
              {
                ts.textureData = index;
                flag1 = false;
              }
            }
            if (flag1)
            {
              this.TextureDataAlphaList.Add(this.TextureDataList[this.TextureSettings[tri.textureSetting].textureData]);
              ts.textureData = this.TextureDataAlphaList.Count - 1;
              this.TextureSettingsAlpha.Add(ts);
              tri.textureSetting = this.TextureSettingsAlpha.Count - 1;
            }
            if (!flag1 && this.TextureSettings[tri.textureSetting].textureData != -1)
            {
              bool flag2 = true;
              for (int index = 0; index < this.TextureSettingsAlpha.Count & flag2; ++index)
              {
                if (this.TextureSettingsAlpha[index].equal(ts))
                {
                  tri.textureSetting = index;
                  flag2 = false;
                }
              }
              if (flag2)
              {
                this.TextureSettingsAlpha.Add(ts);
                tri.textureSetting = this.TextureSettingsAlpha.Count - 1;
              }
            }
          }
          else if (this.TextureSettings[tri.textureSetting].textureData == -1)
          {
            bool flag2 = true;
            for (int index = 0; index < this.TextureSettingsAlpha.Count; ++index)
            {
              if (this.TextureSettingsAlpha[index].equal(ts))
              {
                tri.textureSetting = index;
                flag2 = false;
              }
            }
            if (flag2)
            {
              this.TextureSettingsAlpha.Add(ts);
              tri.textureSetting = this.TextureSettingsAlpha.Count - 1;
            }
          }
          this.triangleGLs.RemoveAt(selected);
          TriangleGL originalTriangleGl = this.originalTriangleGLs[selected];
          this.originalTriangleGLs.RemoveAt(selected);
          this.triangleGLAlphas.Insert(0, tri);
          this.originalTriangleGLAlphas.Insert(0, originalTriangleGl);
          this.RenderPick();
          this.core.ClearScreenAndLoadIdentity();
        }
        else
          this.normalUpdate(ts, tri, selected);
      }
      else
      {
        bool flag = true;
        for (int index = 0; index < this.TextureSettingsAlpha.Count & flag; ++index)
        {
          if (this.TextureSettingsAlpha[index].equal(ts))
          {
            tri.textureSetting = index;
            flag = false;
          }
        }
        if (flag)
        {
          this.TextureSettingsAlpha.Add(ts);
          tri.textureSetting = this.TextureSettingsAlpha.Count - 1;
        }
        this.triangleGLAlphas[selected] = tri;
        this.RenderPick();
        this.core.ClearScreenAndLoadIdentity();
      }
    }

    private void normalUpdate(TextureSetting ts, TriangleGL tri, int selected)
    {
      bool flag = true;
      for (int index = 0; index < this.TextureSettings.Count & flag; ++index)
      {
        if (this.TextureSettings[index].equal(ts))
        {
          tri.textureSetting = index;
          flag = false;
        }
      }
      if (flag)
      {
        this.TextureSettings.Add(ts);
        tri.textureSetting = this.TextureSettings.Count - 1;
      }
      this.triangleGLs[selected] = tri;
    }

    private void browse_btn_Click(object sender, EventArgs e)
    {
      this.forceRedraw = true;
      this.precision = Convert.ToSingle(this.scale_tb.Text);
      if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        this.clearAll();
        this.objFile = this.openFileDialog1.FileName;
        ObjImporter objImporter = new ObjImporter();
        try
        {
          this.TextureSettings.Clear();
          this.TextureDataList.Clear();
          this.TextureSettingsAlpha.Clear();
          this.TextureDataAlphaList.Clear();
          this.triangleGLs.Clear();
          this.triangleGLAlphas.Clear();
          float precision = this.precision;
          objImporter.ImportObj(this.objFile, ref this.triangleGLs, ref this.triangleGLAlphas, ref this.TextureDataList, ref this.TextureDataAlphaList, ref this.TextureSettings, ref this.TextureSettingsAlpha, ref this.precision);
          if ((double) this.precision != (double) precision)
          {
            int num1 = (int) MessageBox.Show("Your scale of " + (object) precision + " could not be used, " + (object) this.precision + " has been used instead");
            int num2 = (int) this.precision;
            if (num2 < 1)
              num2 = 1;
            this.scale_tbar.Value = num2;
            this.scale_tb.Text = this.precision.ToString();
          }
          for (int index = 0; index < this.triangleGLs.Count; ++index)
            this.originalTriangleGLs.Add(TriangleGL.clone(this.triangleGLs[index]));
          for (int index = 0; index < this.triangleGLAlphas.Count; ++index)
            this.originalTriangleGLAlphas.Add(TriangleGL.clone(this.triangleGLAlphas[index]));
          this.scale(Convert.ToSingle(this.scale_tb.Text));
          Core.InitGl();
          this.RenderLines();
          this.RenderLevelWithSelection();
          this.RenderPick();
          this.Redraw();
          this.moveX_tb.Enabled = true;
          this.moveY_tb.Enabled = true;
          this.moveZ_tb.Enabled = true;
          this.moveX_tb.Text = "0";
          this.moveY_tb.Text = "0";
          this.moveZ_tb.Text = "0";
          this.currentImage = 0;
          this.setImage();
        }
        catch (Exception ex)
        {
        }
      }
      this.forceRedraw = true;
    }

    private void clearAll()
    {
      this.triangleGLs.Clear();
      this.triangleGLAlphas.Clear();
      this.originalTriangleGLAlphas.Clear();
      this.originalTriangleGLs.Clear();
      this.tID = 0;
      this.textureNames.Clear();
      this.alphaTextureNames.Clear();
      this.alphaTextureBytes.Clear();
      this.VTXCommands.Clear();
      this.AlphaVTXCommands.Clear();
      this.VTXLocations.Clear();
      this.AlphaVTXLocations.Clear();
      this.textureLocations.Clear();
      this.textureOrder.Clear();
      this.textureOffsets.Clear();
      this.alphaTextureOffsets.Clear();
      this.alphaTextureLocations.Clear();
      this.alphaTextureOrder.Clear();
      this.TextureSettings.Clear();
      this.TextureDataList.Clear();
      this.TextureSettingsAlpha.Clear();
      this.TextureDataAlphaList.Clear();
    }

    private void openBinFiles()
    {
      this.scale_tbar.Value = 1;
      this.scale_tb.Text = "1";
      this.precision = 1f;
      this.clearAll();
      if (File.Exists(this.tmpFile))
        this.ConvertToInternalStructure(this.tmpFile, false, true);
      if (File.Exists(this.tmpFileA))
        this.ConvertToInternalStructure(this.tmpFileA, true, true);
      int num1 = -1;
      int num2 = -1;
      for (int index = 0; index < this.TextureSettings.Count; ++index)
      {
        if (this.TextureSettings[index].height == 0)
        {
          num1 = index;
          break;
        }
      }
      for (int index = 0; index < this.TextureSettingsAlpha.Count; ++index)
      {
        if (this.TextureSettingsAlpha[index].height == 0)
        {
          num2 = index;
          break;
        }
      }
      for (int index = 0; index < this.triangleGLs.Count; ++index)
      {
        if (this.triangleGLs[index].textureSetting == -1)
        {
          if (num1 == -1)
          {
            this.TextureSettings.Add(new TextureSetting(0, 0, 0, 0, -1));
            num1 = this.TextureSettings.Count - 1;
          }
          this.triangleGLs[index].textureSetting = num1;
        }
      }
      for (int index = 0; index < this.triangleGLAlphas.Count; ++index)
      {
        if (this.triangleGLAlphas[index].textureSetting == -1)
        {
          if (num2 == -1)
          {
            this.TextureSettingsAlpha.Add(new TextureSetting(0, 0, 0, 0, -1));
            num2 = this.TextureSettingsAlpha.Count - 1;
          }
          this.triangleGLs[index].textureSetting = num2;
        }
      }
      for (int index = 0; index < this.triangleGLs.Count; ++index)
        this.originalTriangleGLs.Add(TriangleGL.clone(this.triangleGLs[index]));
      for (int index = 0; index < this.triangleGLAlphas.Count; ++index)
        this.originalTriangleGLAlphas.Add(TriangleGL.clone(this.triangleGLAlphas[index]));
      this.scale((float) this.scale_tbar.Value);
      Core.InitGl();
      this.RenderLevelWithSelection();
      this.RenderLines();
      this.RenderPick();
      this.Redraw();
      this.moveX_tb.Enabled = true;
      this.moveY_tb.Enabled = true;
      this.moveZ_tb.Enabled = true;
      this.moveX_tb.Text = "0";
      this.moveY_tb.Text = "0";
      this.moveZ_tb.Text = "0";
      this.currentImage = 0;
      this.setImage();
    }

    private void openBinToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.forceRedraw = true;
      this.canDeleteTmp = false;
      this.openFD_bin.Title = "A File";
      if (this.openFD_bin.ShowDialog() == DialogResult.OK)
      {
        this.tmpFile = this.openFD_bin.FileName;
        this.tmpFileA = "";
        this.openFD_bin.Title = "B File (Leave blank if none)";
        if (this.openFD_bin.ShowDialog() == DialogResult.OK)
          this.tmpFileA = this.openFD_bin.FileName;
        this.openBinFiles();
      }
      this.forceRedraw = true;
    }

    private void ConvertToInternalStructure(string model_, bool alpha, bool fromBin)
    {
      List<CollisionTriangle> collisionTriangleList = new List<CollisionTriangle>();
      if (!alpha)
        this.triangleGLs = new List<TriangleGL>();
      else
        this.triangleGLAlphas = new List<TriangleGL>();
      List<VertGL> source = new List<VertGL>();
      List<VertGL> vertGlList = new List<VertGL>();
      List<int> intList = new List<int>();
      VertGL vertGl1 = new VertGL((short) 0, (short) 0, (short) 0, (byte) 0, (byte) 0, (byte) 0, (byte) 0, (short) 0, (short) 0);
      for (int index = 0; index < 64; ++index)
      {
        vertGlList.Add(vertGl1);
        intList.Add(0);
      }
      int num1 = 0;
      List<byte[]> numArrayList = new List<byte[]>();
      bool flag1 = false;
      int textureData_ = 0;
      float sScale = 0.0f;
      float tScale = 0.0f;
      int num2 = 0;
      int num3 = 0;
      int cms_ = 0;
      int cmt_ = 0;
      int num4 = 0;
      int textureSetting_ = -1;
      if (!File.Exists(model_))
        return;
      try
      {
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(model_, FileMode.Open));
        long length1 = binaryReader.BaseStream.Length;
        byte[] numArray1 = new byte[length1];
        binaryReader.BaseStream.Read(numArray1, 0, (int) length1);
        binaryReader.Close();
        if (numArray1[3] == (byte) 11)
        {
          int num5 = (int) numArray1[28] * 16777216 + (int) numArray1[29] * 65536 + (int) numArray1[30] * 256 + (int) numArray1[31];
          int num6 = (int) numArray1[12] * 16777216 + (int) numArray1[13] * 65536 + (int) numArray1[14] * 256 + (int) numArray1[15] + 8;
          int num7 = (int) numArray1[num6 - 6] * 256 + (int) numArray1[num6 - 5];
          int index1 = (int) numArray1[16] * 16777216 + (int) numArray1[17] * 65536 + (int) numArray1[18] * 256 + (int) numArray1[19] + 24;
          int textureCount = (int) numArray1[60] * 256 + (int) numArray1[61];
          Texture[] textureArray = new Texture[textureCount];
          if (textureCount == 0)
          {
            textureArray = new Texture[1];
            if (alpha)
              this.TextureDataAlphaList.Add(new TextureData());
            else
              this.TextureDataList.Add(new TextureData());
          }
          int num8 = textureCount * 16 + 64;
          int index2 = 0;
          for (int textureTableOffset_ = 64; textureTableOffset_ < num8; textureTableOffset_ += 16)
          {
            int num9 = (int) numArray1[textureTableOffset_] * 16777216 + (int) numArray1[textureTableOffset_ + 1] * 65536 + (int) numArray1[textureTableOffset_ + 2] * 256 + (int) numArray1[textureTableOffset_ + 3];
            int textureWidth_ = (int) numArray1[textureTableOffset_ + 8];
            int textureHeight_ = (int) numArray1[textureTableOffset_ + 9];
            textureArray[index2] = new Texture(textureTableOffset_, (uint) num9, textureWidth_, textureHeight_);
            if (alpha)
              this.TextureDataAlphaList.Add(new TextureData());
            else
              this.TextureDataList.Add(new TextureData());
            ++index2;
          }
          int length2 = (int) numArray1[57] * 65536 + (int) numArray1[58] * 256 + (int) numArray1[59] - textureCount * 16 - 8;
          if (length2 > 0)
          {
            byte[] numArray2 = new byte[length2];
            if (num8 + length2 <= numArray1.Length)
            {
              for (int index3 = 0; index3 < length2; ++index3)
                numArray2[index3] = numArray1[num8 + index3];
            }
          }
          else
            textureArray[0] = new Texture(0, 0U, 1, 1);
          int num10 = (int) numArray1[50] * 256 + (int) numArray1[51];
          if (index1 + num10 * 16 == 0)
          {
            int length3 = numArray1.Length;
          }
          try
          {
            for (int index3 = 0; index3 < num10; ++index3)
            {
              int num9 = (int) (short) ((int) numArray1[index1] * 256 + (int) numArray1[index1 + 1]);
              short num11 = (short) ((int) numArray1[index1 + 2] * 256 + (int) numArray1[index1 + 3]);
              short num12 = (short) ((int) numArray1[index1 + 4] * 256 + (int) numArray1[index1 + 5]);
              short num13 = (short) ((int) numArray1[index1 + 8] * 256 + (int) numArray1[index1 + 9]);
              short num14 = (short) ((int) numArray1[index1 + 10] * 256 + (int) numArray1[index1 + 11]);
              byte num15 = numArray1[index1 + 12];
              byte num16 = numArray1[index1 + 13];
              byte num17 = numArray1[index1 + 14];
              byte num18 = numArray1[index1 + 15];
              int num19 = (int) num11;
              int num20 = (int) num12;
              int num21 = (int) num15;
              int num22 = (int) num16;
              int num23 = (int) num17;
              int num24 = (int) num18;
              int num25 = (int) num13;
              int num26 = (int) num14;
              VertGL vertGl2 = new VertGL((short) num9, (short) num19, (short) num20, (byte) num21, (byte) num22, (byte) num23, (byte) num24, (short) num25, (short) num26);
              source.Add(vertGl2);
              index1 += 16;
            }
          }
          catch (Exception ex)
          {
          }
          int num27 = (int) numArray1[num5 + 16] * 256 + (int) numArray1[num5 + 17];
          int num28 = num5 + 24 + num27 * 4;
          int num29 = (int) numArray1[num28 - 4] * 256 + (int) numArray1[num28 - 3] + ((int) numArray1[num28 - 2] * 256 + (int) numArray1[num28 - 1]);
          int index4 = num28;
          for (int index3 = 0; index3 < num29; ++index3)
          {
            int num9 = (int) numArray1[index4] * 256 + (int) numArray1[index4 + 1];
            int num11 = (int) numArray1[index4 + 2] * 256 + (int) numArray1[index4 + 3];
            int num12 = (int) numArray1[index4 + 4] * 256 + (int) numArray1[index4 + 5];
            SoundType soundType_ = (SoundType) numArray1[index4 + 10];
            CollisionType collisionType_ = (CollisionType) numArray1[index4 + 9];
            GroundType groundType_ = (GroundType) numArray1[index4 + 11];
            CollisionTriangle collisionTriangle = new CollisionTriangle(new int[3]
            {
              num9,
              num11,
              num12
            }, collisionType_, groundType_, soundType_);
            collisionTriangleList.Add(collisionTriangle);
            index4 += 12;
          }
          int num30 = num6;
          for (int index3 = 0; index3 < num7; ++index3)
          {
            byte[] numArray2 = new byte[8];
            for (int index5 = 0; index5 < 8; ++index5)
              numArray2[index5] = numArray1[num30 + index5];
            numArrayList.Add(numArray2);
            num30 += 8;
          }
          bool flag2 = false;
          bool flag3 = false;
          bool flag4 = false;
          bool flag5 = false;
          bool flag6 = true;
          try
          {
            for (int index3 = 0; index3 < num7; ++index3)
            {
              byte[] numArray2 = numArrayList[index3];
              uint num9 = (uint) ((int) numArray2[4] * 16777216 + (int) numArray2[5] * 65536 + (int) numArray2[6] * 256) + (uint) numArray2[7];
              uint num11 = (uint) ((int) numArray2[1] * 65536 + (int) numArray2[2] * 256) + (uint) numArray2[3];
              if (numArray2[0] == (byte) 253)
              {
                uint num12 = num9 << 8 >> 8;
                bool flag7 = false;
                for (int index5 = 0; index5 < textureCount && !flag7; ++index5)
                {
                  if ((int) textureArray[index5].textureOffset == (int) num12 || (int) textureArray[index5].indexOffset == (int) num12)
                  {
                    textureData_ = index5;
                    flag7 = true;
                  }
                }
                if (numArrayList[index3 + 2][0] != (byte) 240)
                  flag1 = true;
              }
              if (numArray2[0] == (byte) 184)
              {
                if (index3 + 4 < numArrayList.Count)
                {
                  if (numArrayList[index3 + 4][0] == (byte) 231)
                    GL.Disable(EnableCap.Texture2D);
                }
                else
                  GL.Disable(EnableCap.Texture2D);
                flag1 = false;
                flag6 = true;
              }
              if (numArray2[0] == (byte) 183)
              {
                flag5 = false;
                flag4 = false;
                int num12 = (int) ((uint) (((int) num9 & (int) ushort.MaxValue) << 8) >> 8);
                flag2 = (num12 & 4096) == 4096;
                flag3 = (num12 & 8192) == 8192;
                if (flag3 & flag2)
                {
                  flag3 = false;
                  flag2 = false;
                  flag4 = true;
                }
                if (!flag3 && !flag2)
                {
                  flag3 = false;
                  flag2 = false;
                  flag4 = false;
                  flag5 = true;
                }
              }
              if (numArray2[0] == (byte) 245)
              {
                GL.Enable(EnableCap.Texture2D);
                num3 = (int) (byte) ((uint) numArray2[1] >> 5);
                num2 = (int) (byte) ((uint) (byte) ((int) numArray2[1] >> 3 << 6) >> 6);
                num4 = (int) (num11 >> 9) & 15;
                cmt_ = (int) (num9 >> 18) & 2;
                cms_ = (int) (num9 >> 8) & 3;
              }
              if (numArray2[0] == (byte) 240)
              {
                int palSize = (int) ((num9 << 8 >> 8 & 16773120U) >> 14) * 2 + 2;
                textureArray[textureData_].loadPalette(numArray1, textureCount, palSize);
                flag1 = true;
              }
              if (numArray2[0] == (byte) 187)
              {
                sScale = (float) (num9 >> 16) / 65536f;
                tScale = (float) (num9 & (uint) ushort.MaxValue) / 65536f;
              }
              if (numArray2[0] == (byte) 6 && flag6)
              {
                if (!flag1)
                {
                  TextureSetting textureSetting = new TextureSetting(0, 0, cms_, cmt_, -1);
                  textureSetting.name = "";
                  if (flag2)
                    textureSetting.cull_front = flag2;
                  if (flag3)
                    textureSetting.cull_back = flag3;
                  if (flag4)
                    textureSetting.cull_both = flag4;
                  if (flag5)
                    textureSetting.cull_none = flag5;
                  if (alpha)
                  {
                    this.TextureSettingsAlpha.Add(textureSetting);
                    textureSetting_ = this.TextureSettingsAlpha.Count - 1;
                  }
                  else
                  {
                    this.TextureSettings.Add(textureSetting);
                    textureSetting_ = this.TextureSettings.Count - 1;
                  }
                }
                flag6 = false;
              }
              if (numArray2[0] == (byte) 4)
              {
                byte num12 = (byte) ((uint) numArray2[1] >> 1);
                byte num13 = (byte) ((uint) numArray2[2] >> 2);
                if (num12 > (byte) 63)
                  num12 = (byte) 63;
                uint num14 = (num9 << 8 >> 8) / 16U;
                try
                {
                  for (int index5 = (int) num12; index5 < (int) num13 + (int) num12; ++index5)
                  {
                    if ((long) num14 < (long) source.Count<VertGL>())
                    {
                      vertGlList[index5] = source[(int) num14];
                      intList[index5] = (int) num14;
                    }
                    ++num14;
                  }
                }
                catch (Exception ex)
                {
                }
                if (flag1)
                {
                  if (textureArray[textureData_].textureHeight == 1)
                  {
                    textureSetting_ = !alpha ? -1 : -1;
                    flag1 = false;
                  }
                  else
                  {
                    int num15 = textureArray[textureData_].palSize;
                    if (num15 == 0)
                      num15 = 16;
                    byte[] numArray3 = new byte[textureArray[textureData_].textureWidth * textureArray[textureData_].textureHeight * 4];
                    int index5 = 0;
                    byte[] numArray4 = new byte[textureArray[textureData_].textureSize];
                    int num16 = !textureArray[textureData_].palLoaded ? (int) textureArray[textureData_].textureOffset + 64 + textureCount * 16 : (int) textureArray[textureData_].indexOffset + 64 + textureCount * 16;
                    try
                    {
                      for (int index6 = 0; index6 < numArray4.Length; ++index6)
                      {
                        if (num16 + index6 < numArray1.Length)
                          numArray4[index6] = numArray1[num16 + index6];
                        else
                          break;
                      }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (textureArray[textureData_].pixels == null)
                    {
                      if (num3 == 0)
                      {
                        if (num2 == 2)
                        {
                          uint num17 = 0;
                          try
                          {
                            for (int index6 = 0; index6 < textureArray[textureData_].textureHeight; ++index6)
                            {
                              for (int index7 = 0; index7 < textureArray[textureData_].textureWidth; ++index7)
                              {
                                ushort num18 = (ushort) ((uint) numArray4[(int) num17] * 256U + (uint) numArray4[(int) num17 + 1]);
                                byte num19 = (byte) ((uint) (byte) ((uint) numArray4[(int) num17 + 1] << 7) >> 7) != (byte) 0 ? byte.MaxValue : (byte) 0;
                                numArray3[index5] = (byte) (((int) num18 & 63488) >> 8);
                                numArray3[index5 + 1] = (byte) (((int) num18 & 1984) << 5 >> 8);
                                numArray3[index5 + 2] = (byte) (((int) num18 & 62) << 18 >> 16);
                                numArray3[index5 + 3] = num19;
                                num17 += 2U;
                                index5 += 4;
                              }
                              if (num4 > 0)
                                num17 += (uint) (num4 * 4 - textureArray[textureData_].textureWidth);
                            }
                          }
                          catch (Exception ex)
                          {
                          }
                        }
                      }
                      else
                      {
                        if (num2 == 0)
                        {
                          num15 = 16;
                          try
                          {
                            int index6 = 0;
                            for (int index7 = 0; index7 < textureArray[textureData_].textureHeight; ++index7)
                            {
                              for (int index8 = 0; index8 < textureArray[textureData_].textureWidth / 2; ++index8)
                              {
                                byte num17 = (byte) ((uint) numArray4[index6] >> 4);
                                byte num18 = (byte) ((uint) (byte) ((uint) numArray4[index6] << 4) >> 4);
                                numArray3[index5] = textureArray[textureData_].red[(int) num17];
                                numArray3[index5 + 1] = textureArray[textureData_].green[(int) num17];
                                numArray3[index5 + 2] = textureArray[textureData_].blue[(int) num17];
                                numArray3[index5 + 3] = textureArray[textureData_].alpha[(int) num17];
                                numArray3[index5 + 4] = textureArray[textureData_].red[(int) num18];
                                numArray3[index5 + 5] = textureArray[textureData_].green[(int) num18];
                                numArray3[index5 + 6] = textureArray[textureData_].blue[(int) num18];
                                numArray3[index5 + 7] = textureArray[textureData_].alpha[(int) num18];
                                index5 += 8;
                                ++index6;
                              }
                              index6 += num4 * 8 - textureArray[textureData_].textureWidth / 2;
                            }
                          }
                          catch (Exception ex)
                          {
                          }
                        }
                        if (num2 == 1)
                        {
                          num15 = 256;
                          try
                          {
                            int index6 = 0;
                            for (int index7 = 0; index7 < textureArray[textureData_].textureHeight; ++index7)
                            {
                              for (int index8 = 0; index8 < textureArray[textureData_].textureWidth; ++index8)
                              {
                                numArray3[index5] = textureArray[textureData_].red[(int) numArray4[index6]];
                                numArray3[index5 + 1] = textureArray[textureData_].green[(int) numArray4[index6]];
                                numArray3[index5 + 2] = textureArray[textureData_].blue[(int) numArray4[index6]];
                                numArray3[index5 + 3] = textureArray[textureData_].alpha[(int) numArray4[index6]];
                                index5 += 4;
                                ++index6;
                              }
                              index6 += num4 * 8 - textureArray[textureData_].textureWidth;
                            }
                          }
                          catch (Exception ex)
                          {
                          }
                        }
                      }
                      textureArray[textureData_].pixels = numArray3;
                      List<byte> byteList = new List<byte>();
                      if (textureArray[textureData_].palette != null)
                        byteList.AddRange((IEnumerable<byte>) textureArray[textureData_].palette);
                      byteList.AddRange((IEnumerable<byte>) numArray4);
                      if (alpha)
                      {
                        this.TextureDataAlphaList[textureData_].gl = numArray3;
                        this.TextureDataAlphaList[textureData_].n64 = byteList.ToArray();
                        this.TextureDataAlphaList[textureData_].width = textureArray[textureData_].textureWidth;
                        this.TextureDataAlphaList[textureData_].height = textureArray[textureData_].textureHeight;
                      }
                      else
                      {
                        this.TextureDataList[textureData_].gl = numArray3;
                        this.TextureDataList[textureData_].n64 = byteList.ToArray();
                        this.TextureDataList[textureData_].width = textureArray[textureData_].textureWidth;
                        this.TextureDataList[textureData_].height = textureArray[textureData_].textureHeight;
                      }
                    }
                    int pixel = (int) textureArray[textureData_].pixels[3];
                    TextureSetting t = new TextureSetting(textureArray[textureData_].textureWidth, textureArray[textureData_].textureHeight, cms_, cmt_, textureData_);
                    t.setRatio(sScale, tScale);
                    if (flag2)
                      t.cull_front = flag2;
                    if (flag3)
                      t.cull_back = flag3;
                    if (flag4)
                      t.cull_both = flag4;
                    if (flag5)
                      t.cull_none = flag5;
                    t.palSize = num15;
                    if (alpha)
                    {
                      bool flag7 = true;
                      for (int index6 = 0; index6 < this.TextureSettingsAlpha.Count & flag7; ++index6)
                      {
                        if (this.TextureSettingsAlpha[index6].equal(t))
                        {
                          flag7 = false;
                          textureSetting_ = index6;
                        }
                      }
                      if (flag7)
                      {
                        this.TextureSettingsAlpha.Add(t);
                        textureSetting_ = this.TextureSettingsAlpha.Count - 1;
                      }
                    }
                    else
                    {
                      bool flag7 = true;
                      for (int index6 = 0; index6 < this.TextureSettings.Count & flag7; ++index6)
                      {
                        if (this.TextureSettings[index6].equal(t))
                        {
                          flag7 = false;
                          textureSetting_ = index6;
                        }
                      }
                      if (flag7)
                      {
                        this.TextureSettings.Add(t);
                        textureSetting_ = this.TextureSettings.Count - 1;
                      }
                    }
                    flag1 = false;
                  }
                }
              }
              if (numArray2[0] == (byte) 191)
              {
                short num12 = (short) ((int) numArray2[5] / 2);
                short num13 = (short) ((int) numArray2[6] / 2);
                short num14 = (short) ((int) numArray2[7] / 2);
                TriangleGL triangleGl = new TriangleGL(new VertGL[3]
                {
                  vertGlList[(int) num12],
                  vertGlList[(int) num13],
                  vertGlList[(int) num14]
                }, textureSetting_);
                bool flag7 = false;
                for (int index5 = 0; index5 < collisionTriangleList.Count && !flag7; ++index5)
                {
                  int[] verts = collisionTriangleList[index5].verts;
                  if (verts[0] == intList[(int) num12] && verts[1] == intList[(int) num13] && verts[2] == intList[(int) num14])
                  {
                    triangleGl.groundType = collisionTriangleList[index5].groundType;
                    triangleGl.soundType = collisionTriangleList[index5].soundType;
                    triangleGl.collisionType = collisionTriangleList[index5].collisionType;
                    flag7 = true;
                  }
                }
                if (fromBin && !flag7)
                  triangleGl.collisionType = CollisionType.NoCollision;
                if (!alpha)
                  this.triangleGLs.Add(triangleGl);
                else
                  this.triangleGLAlphas.Add(triangleGl);
                ++num1;
              }
              else if (numArray2[0] == (byte) 177)
              {
                short num12 = (short) ((int) numArray2[1] / 2);
                short num13 = (short) ((int) numArray2[2] / 2);
                short num14 = (short) ((int) numArray2[3] / 2);
                short num15 = (short) ((int) numArray2[5] / 2);
                short num16 = (short) ((int) numArray2[6] / 2);
                short num17 = (short) ((int) numArray2[7] / 2);
                TriangleGL triangleGl1 = new TriangleGL(new VertGL[3]
                {
                  vertGlList[(int) num12],
                  vertGlList[(int) num13],
                  vertGlList[(int) num14]
                }, textureSetting_);
                TriangleGL triangleGl2 = new TriangleGL(new VertGL[3]
                {
                  vertGlList[(int) num15],
                  vertGlList[(int) num16],
                  vertGlList[(int) num17]
                }, textureSetting_);
                bool flag7 = false;
                bool flag8 = false;
                for (int index5 = 0; index5 < collisionTriangleList.Count; ++index5)
                {
                  int[] verts = collisionTriangleList[index5].verts;
                  if (verts[0] == intList[(int) num12] && verts[1] == intList[(int) num13] && verts[2] == intList[(int) num14])
                  {
                    triangleGl1.groundType = collisionTriangleList[index5].groundType;
                    triangleGl1.soundType = collisionTriangleList[index5].soundType;
                    triangleGl1.collisionType = collisionTriangleList[index5].collisionType;
                    flag7 = true;
                  }
                  if (verts[0] == intList[(int) num15] && verts[1] == intList[(int) num16] && verts[2] == intList[(int) num17])
                  {
                    triangleGl2.groundType = collisionTriangleList[index5].groundType;
                    triangleGl2.soundType = collisionTriangleList[index5].soundType;
                    triangleGl2.collisionType = collisionTriangleList[index5].collisionType;
                    flag8 = true;
                  }
                }
                if (fromBin && !flag7)
                  triangleGl1.collisionType = CollisionType.NoCollision;
                if (fromBin && !flag8)
                  triangleGl2.collisionType = CollisionType.NoCollision;
                if (!alpha)
                  this.triangleGLs.Add(triangleGl1);
                else
                  this.triangleGLAlphas.Add(triangleGl1);
                int num18 = num1 + 1;
                if (!alpha)
                  this.triangleGLs.Add(triangleGl2);
                else
                  this.triangleGLAlphas.Add(triangleGl2);
                num1 = num18 + 1;
              }
            }
          }
          catch (Exception ex)
          {
          }
        }
        else
        {
          int num31 = (int) MessageBox.Show("INVALID MODEL FILE");
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void DrawInternalStructureLines(bool alpha)
    {
      Core.InitGl();
      if (!alpha)
      {
        for (int index = 0; index < this.triangleGLs.Count<TriangleGL>(); ++index)
        {
          GL.Begin(BeginMode.Lines);
          GL.Color3(0.0f, 0.0f, 0.0f);
          GL.LineWidth(0.2f);
          GL.Vertex3(this.triangleGLs[index].verts[0].x, this.triangleGLs[index].verts[0].y, this.triangleGLs[index].verts[0].z);
          GL.Vertex3(this.triangleGLs[index].verts[1].x, this.triangleGLs[index].verts[1].y, this.triangleGLs[index].verts[1].z);
          GL.Vertex3(this.triangleGLs[index].verts[0].x, this.triangleGLs[index].verts[0].y, this.triangleGLs[index].verts[0].z);
          GL.Vertex3(this.triangleGLs[index].verts[2].x, this.triangleGLs[index].verts[2].y, this.triangleGLs[index].verts[2].z);
          GL.Vertex3(this.triangleGLs[index].verts[1].x, this.triangleGLs[index].verts[1].y, this.triangleGLs[index].verts[1].z);
          GL.Vertex3(this.triangleGLs[index].verts[2].x, this.triangleGLs[index].verts[2].y, this.triangleGLs[index].verts[2].z);
          GL.End();
        }
      }
      else
      {
        for (int index = 0; index < this.triangleGLAlphas.Count<TriangleGL>(); ++index)
        {
          GL.Begin(BeginMode.Lines);
          GL.Color3(0.0f, 0.0f, 0.0f);
          GL.LineWidth(0.2f);
          GL.Vertex3(this.triangleGLAlphas[index].verts[0].x, this.triangleGLAlphas[index].verts[0].y, this.triangleGLAlphas[index].verts[0].z);
          GL.Vertex3(this.triangleGLAlphas[index].verts[1].x, this.triangleGLAlphas[index].verts[1].y, this.triangleGLAlphas[index].verts[1].z);
          GL.Vertex3(this.triangleGLAlphas[index].verts[0].x, this.triangleGLAlphas[index].verts[0].y, this.triangleGLAlphas[index].verts[0].z);
          GL.Vertex3(this.triangleGLAlphas[index].verts[2].x, this.triangleGLAlphas[index].verts[2].y, this.triangleGLAlphas[index].verts[2].z);
          GL.Vertex3(this.triangleGLAlphas[index].verts[1].x, this.triangleGLAlphas[index].verts[1].y, this.triangleGLAlphas[index].verts[1].z);
          GL.Vertex3(this.triangleGLAlphas[index].verts[2].x, this.triangleGLAlphas[index].verts[2].y, this.triangleGLAlphas[index].verts[2].z);
          GL.End();
        }
      }
      Core.InitGl();
      this.Refresh();
    }

    private void DrawCollisionMap(bool alpha)
    {
      Core.InitGl();
      List<TriangleGL> source = this.triangleGLs;
      if (alpha)
        source = this.triangleGLAlphas;
      for (int index = 0; index < source.Count<TriangleGL>(); ++index)
      {
        TriangleGL triangleGl = source[index];
        GL.Begin(BeginMode.Triangles);
        if (triangleGl.collisionType == CollisionType.Water)
          GL.Color4(new byte[4]
          {
            (byte) 0,
            (byte) 0,
            (byte) 100,
            (byte) 100
          });
        else if (triangleGl.collisionType == CollisionType.Ground && triangleGl.groundType < GroundType.Talon)
          GL.Color3(Color.Green);
        else if (triangleGl.collisionType == CollisionType.DoubleSided)
          GL.Color3(Color.Cyan);
        else if (triangleGl.groundType >= GroundType.Talon && triangleGl.groundType < GroundType.Unclimbable)
          GL.Color3(Color.Red);
        else if (triangleGl.groundType >= GroundType.Unclimbable)
          GL.Color3(Color.Gray);
        if (triangleGl.collisionType == CollisionType.NoCollision)
          GL.Color4(new byte[4]
          {
            (byte) 0,
            (byte) 0,
            (byte) 100,
            (byte) 100
          });
        GL.Vertex3(triangleGl.verts[0].x, triangleGl.verts[0].y, triangleGl.verts[0].z);
        GL.Vertex3(triangleGl.verts[1].x, triangleGl.verts[1].y, triangleGl.verts[1].z);
        GL.Vertex3(triangleGl.verts[2].x, triangleGl.verts[2].y, triangleGl.verts[2].z);
        GL.End();
      }
      Core.InitGl();
    }

    private void DrawSoundMap(bool alpha)
    {
      Core.InitGl();
      List<TriangleGL> source = this.triangleGLs;
      if (alpha)
        source = this.triangleGLAlphas;
      for (int index = 0; index < source.Count<TriangleGL>(); ++index)
      {
        TriangleGL triangleGl = source[index];
        GL.Begin(BeginMode.Triangles);
        if (triangleGl.soundType == SoundType.Normal)
          GL.Color3(Color.Green);
        else if (triangleGl.soundType == SoundType.Metal)
          GL.Color3(Color.Gray);
        else if (triangleGl.soundType == SoundType.HardGround)
          GL.Color3(0, 50, 0);
        else if (triangleGl.soundType == SoundType.Stone)
          GL.Color3(192, 192, 192);
        else if (triangleGl.soundType == SoundType.Wood)
          GL.Color3(Color.BurlyWood);
        else if (triangleGl.soundType == SoundType.Snow)
          GL.Color3(Color.White);
        else if (triangleGl.soundType == SoundType.Leaves)
          GL.Color3(Color.Orange);
        else if (triangleGl.soundType == SoundType.Swamp)
          GL.Color3(58, 120, 109);
        else if (triangleGl.soundType == SoundType.Sand)
          GL.Color3(Color.Yellow);
        else if (triangleGl.soundType == SoundType.Slush)
          GL.Color3(Color.WhiteSmoke);
        GL.Vertex3(triangleGl.verts[0].x, triangleGl.verts[0].y, triangleGl.verts[0].z);
        GL.Vertex3(triangleGl.verts[1].x, triangleGl.verts[1].y, triangleGl.verts[1].z);
        GL.Vertex3(triangleGl.verts[2].x, triangleGl.verts[2].y, triangleGl.verts[2].z);
        GL.End();
      }
      Core.InitGl();
    }

    private void DrawInternalStructure(bool alpha, bool pickingMode)
    {
      try
      {
        Core.InitGl();
        int num = -1;
        int textures = 0;
        List<TriangleGL> source = this.triangleGLs;
        if (alpha)
          source = this.triangleGLAlphas;
        for (int index = 0; index < source.Count<TriangleGL>(); ++index)
        {
          TriangleGL triangleGl = source[index];
          TextureSetting textureSetting = new TextureSetting(0, 0, 0, 0, -1);
          byte[] numArray = new byte[4];
          if (triangleGl.textureSetting != -1)
            textureSetting = !alpha ? this.TextureSettings[triangleGl.textureSetting] : this.TextureSettingsAlpha[triangleGl.textureSetting];
          if (!pickingMode)
          {
            if (triangleGl.textureSetting != num)
            {
              byte[] pixels = (byte[]) null;
              if (alpha)
              {
                if (this.TextureSettingsAlpha[triangleGl.textureSetting].textureData != -1)
                  pixels = this.TextureDataAlphaList[this.TextureSettingsAlpha[triangleGl.textureSetting].textureData].gl;
              }
              else if (this.TextureSettings[triangleGl.textureSetting].textureData != -1)
                pixels = this.TextureDataList[this.TextureSettings[triangleGl.textureSetting].textureData].gl;
              if (pixels != null)
              {
                GL.DeleteTextures(1, ref textures);
                GL.GenTextures(1, out textures);
                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, textures);
                GL.TexImage2D<byte>(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, textureSetting.width, textureSetting.height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, pixels);
                GL.TexParameter(TextureTarget.Texture2D, (TextureParameterName) 34046, 16);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                if (textureSetting.cms == 0)
                  GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, Convert.ToInt32((object) TextureWrapMode.Repeat));
                if (textureSetting.cms == 2)
                  GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, 33071);
                if (textureSetting.cmt == 0)
                  GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, Convert.ToInt32((object) TextureWrapMode.Repeat));
                if (textureSetting.cmt == 2)
                  GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, 33071);
              }
              else
              {
                GL.DeleteTextures(1, ref textures);
                GL.Disable(EnableCap.Texture2D);
              }
              num = triangleGl.textureSetting;
            }
          }
          else
            GL.Disable(EnableCap.Texture2D);
          GL.Disable(EnableCap.CullFace);
          if (textureSetting.cull_front)
            GL.CullFace(CullFaceMode.Front);
          else if (textureSetting.cull_back)
            GL.CullFace(CullFaceMode.Back);
          else if (textureSetting.cull_both)
            GL.CullFace(CullFaceMode.FrontAndBack);
          if (textureSetting.cull_front || textureSetting.cull_back || textureSetting.cull_both)
            GL.Enable(EnableCap.CullFace);
          GL.Begin(BeginMode.Triangles);
          if (pickingMode)
          {
            GL.Color4((float) triangleGl.pickObj.m_colorID[0] / (float) byte.MaxValue, (float) triangleGl.pickObj.m_colorID[1] / (float) byte.MaxValue, (float) triangleGl.pickObj.m_colorID[2] / (float) byte.MaxValue, 1f);
            GL.Vertex3(triangleGl.verts[0].x, triangleGl.verts[0].y, triangleGl.verts[0].z);
            GL.Vertex3(triangleGl.verts[1].x, triangleGl.verts[1].y, triangleGl.verts[1].z);
            GL.Vertex3(triangleGl.verts[2].x, triangleGl.verts[2].y, triangleGl.verts[2].z);
          }
          else
          {
            GL.Color4((float) triangleGl.verts[0].r / (float) byte.MaxValue, (float) triangleGl.verts[0].g / (float) byte.MaxValue, (float) triangleGl.verts[0].b / (float) byte.MaxValue, (float) triangleGl.verts[0].a / (float) byte.MaxValue);
            if (triangleGl.textureSetting != -1)
              GL.TexCoord2((float) triangleGl.verts[0].u * textureSetting.textureWRatio, (float) triangleGl.verts[0].v * textureSetting.textureHRatio);
            GL.Vertex3(triangleGl.verts[0].x, triangleGl.verts[0].y, triangleGl.verts[0].z);
            GL.Color4((float) triangleGl.verts[1].r / (float) byte.MaxValue, (float) triangleGl.verts[1].g / (float) byte.MaxValue, (float) triangleGl.verts[1].b / (float) byte.MaxValue, (float) triangleGl.verts[1].a / (float) byte.MaxValue);
            if (triangleGl.textureSetting != -1)
              GL.TexCoord2((float) triangleGl.verts[1].u * textureSetting.textureWRatio, (float) triangleGl.verts[1].v * textureSetting.textureHRatio);
            GL.Vertex3(triangleGl.verts[1].x, triangleGl.verts[1].y, triangleGl.verts[1].z);
            GL.Color4((float) triangleGl.verts[2].r / (float) byte.MaxValue, (float) triangleGl.verts[2].g / (float) byte.MaxValue, (float) triangleGl.verts[2].b / (float) byte.MaxValue, (float) triangleGl.verts[2].a / (float) byte.MaxValue);
            if (triangleGl.textureSetting != -1)
              GL.TexCoord2((float) triangleGl.verts[2].u * textureSetting.textureWRatio, (float) triangleGl.verts[2].v * textureSetting.textureHRatio);
            GL.Vertex3(triangleGl.verts[2].x, triangleGl.verts[2].y, triangleGl.verts[2].z);
          }
          GL.End();
        }
      }
      catch (Exception ex)
      {
      }
      Core.InitGl();
    }

    public void DrawVert(short x, short y, short z, float r, float g, float b, float a)
    {
      GL.Begin(PrimitiveType.Quads);
      GL.Color4(r, g, b, a);
      GL.Vertex3((float) x + 3f, (float) y + 3f, (float) z - 3f);
      GL.Vertex3((float) x - 3f, (float) y + 3f, (float) z - 3f);
      GL.Vertex3((float) x - 3f, (float) y + 3f, (float) z + 3f);
      GL.Vertex3((float) x + 3f, (float) y + 3f, (float) z + 3f);
      GL.Vertex3((float) x + 3f, (float) y - 3f, (float) z + 3f);
      GL.Vertex3((float) x - 3f, (float) y - 3f, (float) z + 3f);
      GL.Vertex3((float) x - 3f, (float) y - 3f, (float) z - 3f);
      GL.Vertex3((float) x + 3f, (float) y - 3f, (float) z - 3f);
      GL.Vertex3((float) x + 3f, (float) y + 3f, (float) z + 3f);
      GL.Vertex3((float) x - 3f, (float) y + 3f, (float) z + 3f);
      GL.Vertex3((float) x - 3f, (float) y - 3f, (float) z + 3f);
      GL.Vertex3((float) x + 3f, (float) y - 3f, (float) z + 3f);
      GL.Vertex3((float) x + 3f, (float) y - 3f, (float) z - 3f);
      GL.Vertex3((float) x - 3f, (float) y - 3f, (float) z - 3f);
      GL.Vertex3((float) x - 3f, (float) y + 3f, (float) z - 3f);
      GL.Vertex3((float) x + 3f, (float) y + 3f, (float) z - 3f);
      GL.Vertex3((float) x - 3f, (float) y + 3f, (float) z + 3f);
      GL.Vertex3((float) x - 3f, (float) y + 3f, (float) z - 3f);
      GL.Vertex3((float) x - 3f, (float) y - 3f, (float) z - 3f);
      GL.Vertex3((float) x - 3f, (float) y - 3f, (float) z + 3f);
      GL.Vertex3((float) x + 3f, (float) y + 3f, (float) z - 3f);
      GL.Vertex3((float) x + 3f, (float) y + 3f, (float) z + 3f);
      GL.Vertex3((float) x + 3f, (float) y - 3f, (float) z + 3f);
      GL.Vertex3((float) x + 3f, (float) y - 3f, (float) z - 3f);
      GL.End();
    }

    private void ModelImportForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      try
      {
        this.timer1.Enabled = false;
      }
      catch
      {
        this.Dispose();
      }
      this.Dispose();
    }

    private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void ModelImportForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.exitProgram = true;
    }

    private void ModelImportForm_MouseDown(object sender, MouseEventArgs e)
    {
      this.Focus();
      this.forceRedraw = true;
      this.sceneClick = true;
      if (e.Button == MouseButtons.Left)
      {
        if (this.banjoMode)
          this.movingBanjoClick = true;
        else
          this.RotateSceneClick = true;
      }
      if (e.Button != MouseButtons.Right)
        return;
      if (this.banjoMode)
      {
        this.rotateBanjoClick = true;
        this.newEditX = e.X;
        this.newEditY = e.Y;
        this.oldEditX = e.X;
        this.oldEditY = e.Y;
      }
      else
      {
        this.painting = true;
        this.pickVert(e.X, e.Y);
      }
    }

    private void ModelImportForm_MouseUp(object sender, MouseEventArgs e)
    {
      this.sceneClick = false;
      this.painting = false;
      if (e.Button == MouseButtons.Left)
      {
        this.RotateSceneClick = false;
        this.movingBanjoClick = false;
      }
      if (e.Button != MouseButtons.Right)
        return;
      this.rotateBanjoClick = false;
    }

    private void LevelViewer_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.A:
          this.key_a = true;
          break;
        case Keys.D:
          this.key_d = true;
          break;
        case Keys.S:
          this.key_s = true;
          break;
        case Keys.W:
          this.key_w = true;
          break;
      }
    }

    private void LevelViewer_KeyUp(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.A:
          this.key_a = false;
          break;
        case Keys.D:
          this.key_d = false;
          break;
        case Keys.S:
          this.key_s = false;
          break;
        case Keys.W:
          this.key_w = false;
          break;
      }
    }

    private void scale(float scale)
    {
      for (int index1 = 0; index1 < this.triangleGLs.Count<TriangleGL>(); ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
          this.triangleGLs[index1].verts[index2].x = (short) ((double) this.originalTriangleGLs[index1].verts[index2].x / (double) this.precision * (double) scale);
          this.triangleGLs[index1].verts[index2].y = (short) ((double) this.originalTriangleGLs[index1].verts[index2].y / (double) this.precision * (double) scale);
          this.triangleGLs[index1].verts[index2].z = (short) ((double) this.originalTriangleGLs[index1].verts[index2].z / (double) this.precision * (double) scale);
        }
      }
      for (int index1 = 0; index1 < this.triangleGLAlphas.Count<TriangleGL>(); ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
          this.triangleGLAlphas[index1].verts[index2].x = (short) ((double) this.originalTriangleGLAlphas[index1].verts[index2].x / (double) this.precision * (double) scale);
          this.triangleGLAlphas[index1].verts[index2].y = (short) ((double) this.originalTriangleGLAlphas[index1].verts[index2].y / (double) this.precision * (double) scale);
          this.triangleGLAlphas[index1].verts[index2].z = (short) ((double) this.originalTriangleGLAlphas[index1].verts[index2].z / (double) this.precision * (double) scale);
        }
      }
      this.RenderLevelWithSelection();
      this.RenderLines();
      this.RenderPick();
    }

    private void sortCullTris()
    {
      List<TriangleGL> source1 = new List<TriangleGL>();
      List<TriangleGL> source2 = new List<TriangleGL>();
      List<TriangleGL> source3 = new List<TriangleGL>();
      List<TriangleGL> source4 = new List<TriangleGL>();
      List<TriangleGL> source5 = new List<TriangleGL>();
      List<TriangleGL> source6 = new List<TriangleGL>();
      int index1 = 0;
      for (int index2 = 0; index2 < this.triangleGLs.Count<TriangleGL>(); ++index2)
      {
        TextureSetting textureSetting = this.TextureSettings[this.triangleGLs[index2].textureSetting];
        if (textureSetting.hasAlpha || this.triangleGLs[index2].verts[0].a != byte.MaxValue || (this.triangleGLs[index2].verts[1].a != byte.MaxValue || this.triangleGLs[index2].verts[2].a != byte.MaxValue))
        {
          if (index1 == 0)
            index1 = index2;
          if (textureSetting.cull_both)
            source5.Add(this.triangleGLs[index2]);
          if (textureSetting.cull_front)
            source4.Add(this.triangleGLs[index2]);
          if (textureSetting.cull_none)
            source6.Add(this.triangleGLs[index2]);
        }
        else
        {
          if (textureSetting.cull_both)
            source2.Add(this.triangleGLs[index2]);
          if (textureSetting.cull_front)
            source1.Add(this.triangleGLs[index2]);
          if (textureSetting.cull_none)
            source3.Add(this.triangleGLs[index2]);
        }
        if (textureSetting.cull_both || textureSetting.cull_front || textureSetting.cull_none)
        {
          this.triangleGLs.RemoveAt(index2);
          --index2;
        }
      }
      if (index1 == 0)
        index1 = this.triangleGLs.Count;
      if (index1 == -1)
        index1 = 0;
      List<TriangleGL> list1 = source2.OrderBy<TriangleGL, int>((Func<TriangleGL, int>) (x => x.textureSetting)).ToList<TriangleGL>();
      List<TriangleGL> list2 = source3.OrderBy<TriangleGL, int>((Func<TriangleGL, int>) (x => x.textureSetting)).ToList<TriangleGL>();
      List<TriangleGL> list3 = source1.OrderBy<TriangleGL, int>((Func<TriangleGL, int>) (x => x.textureSetting)).ToList<TriangleGL>();
      List<TriangleGL> list4 = source5.OrderBy<TriangleGL, int>((Func<TriangleGL, int>) (x => x.textureSetting)).ToList<TriangleGL>();
      List<TriangleGL> list5 = source6.OrderBy<TriangleGL, int>((Func<TriangleGL, int>) (x => x.textureSetting)).ToList<TriangleGL>();
      List<TriangleGL> list6 = source4.OrderBy<TriangleGL, int>((Func<TriangleGL, int>) (x => x.textureSetting)).ToList<TriangleGL>();
      this.triangleGLs.InsertRange(index1, (IEnumerable<TriangleGL>) list5);
      this.triangleGLs.InsertRange(index1, (IEnumerable<TriangleGL>) list6);
      this.triangleGLs.InsertRange(index1, (IEnumerable<TriangleGL>) list4);
      this.triangleGLs.InsertRange(index1, (IEnumerable<TriangleGL>) list2);
      this.triangleGLs.InsertRange(index1, (IEnumerable<TriangleGL>) list3);
      this.triangleGLs.InsertRange(index1, (IEnumerable<TriangleGL>) list1);
    }

    private void sortCullTrisAlpha()
    {
      List<TriangleGL> source1 = new List<TriangleGL>();
      List<TriangleGL> source2 = new List<TriangleGL>();
      List<TriangleGL> source3 = new List<TriangleGL>();
      int index1 = 0;
      for (int index2 = 0; index2 < this.triangleGLAlphas.Count<TriangleGL>(); ++index2)
      {
        TextureSetting textureSetting = this.TextureSettingsAlpha[this.triangleGLAlphas[index2].textureSetting];
        if (textureSetting.cull_both)
          source2.Add(this.triangleGLAlphas[index2]);
        if (textureSetting.cull_front)
          source1.Add(this.triangleGLAlphas[index2]);
        if (textureSetting.cull_none)
          source3.Add(this.triangleGLAlphas[index2]);
        if (textureSetting.cull_both || textureSetting.cull_front || textureSetting.cull_none)
        {
          this.triangleGLAlphas.RemoveAt(index2);
          --index2;
        }
      }
      if (index1 == 0)
        index1 = this.triangleGLAlphas.Count;
      List<TriangleGL> list1 = source2.OrderBy<TriangleGL, int>((Func<TriangleGL, int>) (x => x.textureSetting)).ToList<TriangleGL>();
      List<TriangleGL> list2 = source3.OrderBy<TriangleGL, int>((Func<TriangleGL, int>) (x => x.textureSetting)).ToList<TriangleGL>();
      List<TriangleGL> list3 = source1.OrderBy<TriangleGL, int>((Func<TriangleGL, int>) (x => x.textureSetting)).ToList<TriangleGL>();
      this.triangleGLAlphas.InsertRange(index1, (IEnumerable<TriangleGL>) list2);
      this.triangleGLAlphas.InsertRange(index1, (IEnumerable<TriangleGL>) list3);
      this.triangleGLAlphas.InsertRange(index1, (IEnumerable<TriangleGL>) list1);
    }

    private void save(string file, bool objectModel)
    {
      this.textureNames.Clear();
      this.alphaTextureNames.Clear();
      this.textureOffsets.Clear();
      this.alphaTextureOffsets.Clear();
      this.textureOrder.Clear();
      this.alphaTextureOrder.Clear();
      this.VTXCommands.Clear();
      this.VTXLocations.Clear();
      this.AlphaVTXCommands.Clear();
      this.AlphaVTXLocations.Clear();
      this.textureLocations.Clear();
      this.alphaTextureLocations.Clear();
      this.solidTextureBytes.Clear();
      this.alphaTextureBytes.Clear();
      try
      {
        if (this.triangleGLAlphas.Count > 0)
        {
          this.sortCullTrisAlpha();
          this.calculateTextureOffsetsAlpha();
          this.ConfigureAlphaVertsAndVTX();
        }
      }
      catch (Exception ex)
      {
      }
      if (this.triangleGLs.Count > 0)
      {
        this.sortCullTris();
        this.calculateTextureOffsets();
        this.ConfigureVertsAndVTX();
      }
      byte[] collisionBytes = new byte[1];
      if (objectModel)
        collisionBytes = this.CreateCollisionDataSolidAdvanced(ref this.triangleGLs);
      else if (this.collisionMode == this.CollisionModeAuto)
      {
        try
        {
          collisionBytes = this.CreateCollisionDataSolidAdvanced(ref this.triangleGLs);
        }
        catch (Exception ex)
        {
        }
      }
      else if (this.collisionMode == this.CollisionMode16)
      {
        try
        {
          collisionBytes = this.CreateCollisionDataSolid16();
        }
        catch (Exception ex)
        {
        }
      }
      else
        collisionBytes = this.CreateCollisionDataSolid();
      if (this.triangleGLs.Count > 0)
        this.writeSolidModel(collisionBytes, file, objectModel);
      if (this.triangleGLAlphas.Count > 0)
        this.writeAlphaModel(this.CreateCollisionDataSolidAdvanced(ref this.triangleGLAlphas), file + ".alpha.bin");
      this.tmpFile = file;
      this.tmpFileA = file + ".alpha.bin";
      this.openBinFiles();
    }

    public void writeSolidModel(byte[] collisionBytes, string filename, bool objectModel)
    {
      List<int> intList1 = new List<int>();
      byte[] numArray1 = new byte[83886080];
      numArray1[0] = (byte) 0;
      numArray1[1] = (byte) 0;
      numArray1[2] = (byte) 0;
      numArray1[3] = (byte) 11;
      numArray1[8] = (byte) 0;
      numArray1[9] = (byte) 56;
      numArray1[10] = (byte) 0;
      bool flag1 = false;
      foreach (TextureSetting textureSetting in this.TextureSettings)
      {
        if (textureSetting.textureMode == (byte) 6)
          flag1 = true;
      }
      numArray1[11] = !flag1 ? (byte) 2 : (byte) 4;
      numArray1[29] = (byte) 4;
      numArray1[30] = (byte) 160;
      numArray1[31] = (byte) 104;
      numArray1[37] = (byte) 0;
      numArray1[38] = (byte) 0;
      numArray1[39] = (byte) 0;
      numArray1[48] = (byte) (this.triangleGLs.Count<TriangleGL>() >> 8);
      numArray1[51] = (byte) this.triangleGLs.Count<TriangleGL>();
      numArray1[50] = (byte) (this.triangleGLs.Count<TriangleGL>() * 3 >> 8);
      numArray1[51] = (byte) (this.triangleGLs.Count<TriangleGL>() * 3);
      numArray1[52] = (byte) 66;
      numArray1[53] = (byte) 200;
      numArray1[54] = (byte) 0;
      numArray1[55] = (byte) 0;
      int index1 = 64;
      if (this.TextureDataList.Count > 0)
      {
        int num1 = 0 + this.solidTextureBytes.Count<byte>();
        for (int index2 = 0; index2 < this.TextureDataList.Count; ++index2)
        {
          if (this.TextureDataList[index2].height != 0)
            num1 += 16;
        }
        int num2 = num1 + 8;
        numArray1[56] = (byte) (num2 >> 24);
        numArray1[57] = (byte) (num2 >> 16);
        numArray1[58] = (byte) (num2 >> 8);
        numArray1[59] = (byte) num2;
        List<int> intList2 = new List<int>();
        for (int index2 = 0; index2 < this.textureOffsets.Count; ++index2)
        {
          if (this.textureOffsets[index2].name != "" && !intList2.Contains(this.textureOffsets[index2].offset))
          {
            intList2.Add(this.textureOffsets[index2].offset);
            int offset = this.textureOffsets[index2].offset;
            numArray1[index1] = (byte) (offset >> 24);
            numArray1[index1 + 1] = (byte) (offset >> 16);
            numArray1[index1 + 2] = (byte) (offset >> 8);
            numArray1[index1 + 3] = (byte) offset;
            numArray1[index1 + 4] = (byte) 0;
            numArray1[index1 + 5] = (byte) 1;
            numArray1[index1 + 6] = (byte) 0;
            numArray1[index1 + 7] = (byte) 0;
            numArray1[index1 + 8] = (byte) this.textureOffsets[index2].width;
            numArray1[index1 + 9] = (byte) this.textureOffsets[index2].height;
            numArray1[index1 + 10] = (byte) 0;
            numArray1[index1 + 11] = (byte) 0;
            numArray1[index1 + 12] = (byte) 0;
            numArray1[index1 + 13] = (byte) 0;
            numArray1[index1 + 14] = (byte) 0;
            numArray1[index1 + 15] = (byte) 0;
            index1 += 16;
          }
        }
        numArray1[60] = (byte) (intList2.Count >> 8);
        numArray1[61] = (byte) intList2.Count;
        numArray1[62] = (byte) 0;
        numArray1[63] = (byte) 0;
      }
      int index3 = index1;
      for (int index2 = 0; index2 < this.solidTextureBytes.Count; ++index2)
      {
        numArray1[index3] = this.solidTextureBytes[index2];
        ++index3;
      }
      int num3 = index3;
      numArray1[12] = (byte) (num3 >> 24);
      numArray1[13] = (byte) (num3 >> 16);
      numArray1[14] = (byte) (num3 >> 8);
      numArray1[15] = (byte) num3;
      int index4 = num3;
      int f3dexlocation = num3 + 8;
      int num4 = f3dexlocation;
      int index5 = 0;
      if (this.textureOffsets != null)
      {
        if (this.textureOrder[0] != "(null)" && this.textureOffsets != null && (this.textureOrder[0] != "" && this.textureOrder[0] != "None"))
        {
          string str = this.textureOrder[0];
          for (int index2 = 0; index2 < this.textureOffsets.Count; ++index2)
          {
            if (str == this.textureOffsets[index2].name)
              index5 = index2;
          }
          if (this.textureOffsets[index5].height != 0)
          {
            int num1 = this.textureOffsets[index5].height / 16;
            int num2 = this.textureOffsets[index5].width / 16;
            int num5 = this.textureOffsets[0].width / 8;
            int num6 = this.textureOffsets[index5].width - 1;
            int num7 = this.textureOffsets[index5].height - 1;
            byte num8 = (byte) (num6 >> 2);
            byte num9 = (byte) (num6 << 6);
            byte num10 = (byte) (num7 >> 6);
            int num11 = (int) (byte) (num7 << 2);
            this.f3dex.CI2F3dex(ref numArray1, ref f3dexlocation, this.textureOffsets[index5], this.TextureSettings[this.triangleGLs[0].textureSetting].getCullMode(), this.TextureSettings[this.triangleGLs[0].textureSetting].textureMode);
          }
        }
        else
          this.f3dex.GEN_DLNoTextures(ref numArray1, ref f3dexlocation, this.TextureSettings[this.triangleGLs[0].textureSetting].getCullMode(), this.TextureSettings[this.triangleGLs[0].textureSetting].textureMode);
      }
      else
        this.f3dex.GEN_DLNoTextures(ref numArray1, ref f3dexlocation, this.TextureSettings[this.triangleGLs[0].textureSetting].getCullMode(), this.TextureSettings[this.triangleGLs[0].textureSetting].textureMode);
      ArrayList arrayList = new ArrayList();
      int index6 = 1;
      int index7 = 0;
      int num12 = 0;
      for (int index2 = 0; index2 < this.triangleGLs.Count; index2 += 2)
      {
        try
        {
          bool flag2 = false;
          if (this.textureOffsets != null && index2 != 0)
          {
            for (int index8 = 0; index8 < this.textureLocations.Count; ++index8)
            {
              if (index2 == this.textureLocations[index8])
              {
                arrayList.Clear();
                string str = this.textureOrder[index6];
                ++index6;
                for (int index9 = 0; index9 < this.textureOffsets.Count; ++index9)
                {
                  if (str == this.textureOffsets[index9].name)
                    index7 = index9;
                }
                this.f3dex.GEN_EndDL(ref numArray1, ref f3dexlocation);
                int cullMode = this.TextureSettings[this.triangleGLs[index2].textureSetting].getCullMode();
                byte textureMode = this.TextureSettings[this.triangleGLs[index2].textureSetting].textureMode;
                if (this.TextureSettings[this.triangleGLs[index2].textureSetting].textureData == -1)
                {
                  intList1.Add(f3dexlocation);
                  this.f3dex.GEN_DLNoTextures(ref numArray1, ref f3dexlocation, cullMode, textureMode);
                }
                else
                {
                  intList1.Add(f3dexlocation);
                  this.f3dex.CI2F3dex(ref numArray1, ref f3dexlocation, this.textureOffsets[index7], cullMode, textureMode);
                }
              }
            }
          }
          for (int index8 = 0; index8 < this.VTXLocations.Count; ++index8)
          {
            if (index2 == this.VTXLocations[index8])
            {
              byte[] vtxCommand = this.VTXCommands[index8];
              int num1 = ((int) vtxCommand[5] * 65536 + (int) vtxCommand[6] * 256 + (int) vtxCommand[7]) / 16;
              this.f3dex.GEN_VTX(ref numArray1, ref f3dexlocation, ref vtxCommand);
              num12 = 0;
            }
            if (index2 + 1 == this.VTXLocations[index8])
            {
              this.f3dex.GEN_TRI1(ref numArray1, ref f3dexlocation, new int[3]
              {
                num12,
                num12 + 1,
                num12 + 2
              });
              num12 += 3;
              byte[] vtxCommand = this.VTXCommands[index8];
              int num1 = ((int) vtxCommand[5] * 65536 + (int) vtxCommand[6] * 256 + (int) vtxCommand[7]) / 16;
              try
              {
                if (this.textureOffsets != null)
                {
                  for (int index9 = 0; index9 < this.textureLocations.Count; ++index9)
                  {
                    try
                    {
                      if (index2 + 1 == this.textureLocations[index9])
                      {
                        string str = this.textureOrder[index6];
                        ++index6;
                        try
                        {
                          for (int index10 = 0; index10 < this.textureOffsets.Count; ++index10)
                          {
                            if (str == this.textureOffsets[index10].name)
                              index7 = index10;
                          }
                          this.f3dex.GEN_EndDL(ref numArray1, ref f3dexlocation);
                          int cullMode = this.TextureSettings[this.triangleGLs[index2 + 1].textureSetting].getCullMode();
                          byte textureMode = this.TextureSettings[this.triangleGLs[index2 + 1].textureSetting].textureMode;
                          if (this.TextureSettings[this.triangleGLs[index2 + 1].textureSetting].textureData == -1)
                          {
                            intList1.Add(f3dexlocation);
                            this.f3dex.GEN_DLNoTextures(ref numArray1, ref f3dexlocation, cullMode, textureMode);
                          }
                          else
                          {
                            intList1.Add(f3dexlocation);
                            this.f3dex.CI2F3dex(ref numArray1, ref f3dexlocation, this.textureOffsets[index7], cullMode, textureMode);
                          }
                        }
                        catch (Exception ex)
                        {
                        }
                      }
                    }
                    catch (Exception ex)
                    {
                    }
                  }
                }
              }
              catch (Exception ex)
              {
              }
              this.f3dex.GEN_VTX(ref numArray1, ref f3dexlocation, ref vtxCommand);
              num12 = 0;
              this.f3dex.GEN_TRI1(ref numArray1, ref f3dexlocation, new int[3]
              {
                num12,
                num12 + 1,
                num12 + 2
              });
              num12 += 3;
              flag2 = true;
            }
          }
          if (!flag2)
          {
            if (index2 + 1 == this.triangleGLs.Count)
            {
              this.f3dex.GEN_TRI1(ref numArray1, ref f3dexlocation, new int[3]
              {
                num12,
                num12 + 1,
                num12 + 2
              });
              num12 += 3;
            }
            else
            {
              this.f3dex.GEN_TRI2(ref numArray1, ref f3dexlocation, new int[3]
              {
                num12,
                num12 + 1,
                num12 + 2
              }, new int[3]
              {
                num12 + 3,
                num12 + 4,
                num12 + 5
              });
              num12 += 6;
            }
          }
        }
        catch (Exception ex)
        {
        }
      }
      this.f3dex.GEN_EndDL(ref numArray1, ref f3dexlocation);
      int num13 = (f3dexlocation - index4) / 8 - 1;
      numArray1[index4] = (byte) (num13 >> 24);
      numArray1[index4 + 1] = (byte) (num13 >> 16);
      numArray1[index4 + 2] = (byte) (num13 >> 8);
      numArray1[index4 + 3] = (byte) num13;
      numArray1[17] = (byte) (f3dexlocation >> 16);
      numArray1[18] = (byte) (f3dexlocation >> 8);
      numArray1[19] = (byte) f3dexlocation;
      numArray1[f3dexlocation] = (byte) 188;
      numArray1[f3dexlocation + 1] = (byte) 47;
      numArray1[f3dexlocation + 2] = (byte) 250;
      numArray1[f3dexlocation + 3] = (byte) 31;
      numArray1[f3dexlocation + 4] = (byte) 179;
      numArray1[f3dexlocation + 5] = (byte) 186;
      numArray1[f3dexlocation + 6] = (byte) 81;
      numArray1[f3dexlocation + 7] = (byte) 82;
      f3dexlocation += 8;
      numArray1[f3dexlocation] = (byte) 48;
      numArray1[f3dexlocation + 1] = (byte) 64;
      numArray1[f3dexlocation + 2] = (byte) 52;
      numArray1[f3dexlocation + 3] = (byte) 226;
      numArray1[f3dexlocation + 4] = (byte) 6;
      numArray1[f3dexlocation + 5] = (byte) 192;
      numArray1[f3dexlocation + 6] = (byte) 21;
      numArray1[f3dexlocation + 7] = (byte) 47;
      f3dexlocation += 8;
      numArray1[f3dexlocation] = (byte) 244;
      numArray1[f3dexlocation + 1] = (byte) 78;
      numArray1[f3dexlocation + 2] = (byte) 78;
      numArray1[f3dexlocation + 3] = (byte) 175;
      numArray1[f3dexlocation + 4] = (byte) 18;
      numArray1[f3dexlocation + 5] = (byte) 59;
      numArray1[f3dexlocation + 6] = (byte) 88;
      numArray1[f3dexlocation + 7] = (byte) 40;
      f3dexlocation += 8;
      int num14 = f3dexlocation;
      int index11 = num14 - 24;
      int num15 = 0;
      short num16 = short.MaxValue;
      short num17 = short.MaxValue;
      short num18 = short.MaxValue;
      short num19 = short.MinValue;
      short num20 = short.MinValue;
      short num21 = short.MinValue;
      for (int index2 = 0; index2 < this.triangleGLs.Count; ++index2)
      {
        for (int index8 = 0; index8 < 3; ++index8)
        {
          try
          {
            numArray1[num14 + num15] = (byte) ((uint) this.triangleGLs[index2].verts[index8].x >> 8);
            numArray1[num14 + num15 + 1] = (byte) this.triangleGLs[index2].verts[index8].x;
            num15 += 2;
            numArray1[num14 + num15] = (byte) ((uint) this.triangleGLs[index2].verts[index8].y >> 8);
            numArray1[num14 + num15 + 1] = (byte) this.triangleGLs[index2].verts[index8].y;
            num15 += 2;
            numArray1[num14 + num15] = (byte) ((uint) this.triangleGLs[index2].verts[index8].z >> 8);
            numArray1[num14 + num15 + 1] = (byte) this.triangleGLs[index2].verts[index8].z;
            num15 += 2;
            numArray1[num14 + num15] = (byte) 0;
            numArray1[num14 + num15 + 1] = (byte) 0;
            num15 += 2;
            numArray1[num14 + num15] = (byte) ((uint) this.triangleGLs[index2].verts[index8].u >> 8);
            numArray1[num14 + num15 + 1] = (byte) this.triangleGLs[index2].verts[index8].u;
            num15 += 2;
            numArray1[num14 + num15] = (byte) ((uint) this.triangleGLs[index2].verts[index8].v >> 8);
            numArray1[num14 + num15 + 1] = (byte) this.triangleGLs[index2].verts[index8].v;
            num15 += 2;
            numArray1[num14 + num15] = this.triangleGLs[index2].verts[index8].r;
            ++num15;
            numArray1[num14 + num15] = this.triangleGLs[index2].verts[index8].g;
            ++num15;
            numArray1[num14 + num15] = this.triangleGLs[index2].verts[index8].b;
            ++num15;
            numArray1[num14 + num15] = this.triangleGLs[index2].verts[index8].a;
            ++num15;
            if ((int) this.triangleGLs[index2].verts[index8].x < (int) num16)
              num16 = this.triangleGLs[index2].verts[index8].x;
            if ((int) this.triangleGLs[index2].verts[index8].y < (int) num17)
              num17 = this.triangleGLs[index2].verts[index8].y;
            if ((int) this.triangleGLs[index2].verts[index8].z < (int) num18)
              num18 = this.triangleGLs[index2].verts[index8].z;
            if ((int) this.triangleGLs[index2].verts[index8].x > (int) num19)
              num19 = this.triangleGLs[index2].verts[index8].x;
            if ((int) this.triangleGLs[index2].verts[index8].y > (int) num20)
              num20 = this.triangleGLs[index2].verts[index8].y;
            if ((int) this.triangleGLs[index2].verts[index8].z > (int) num21)
              num21 = this.triangleGLs[index2].verts[index8].z;
          }
          catch (Exception ex)
          {
          }
        }
      }
      numArray1[index11] = (byte) ((uint) num16 >> 8);
      numArray1[index11 + 1] = (byte) num16;
      numArray1[index11 + 2] = (byte) ((uint) num17 >> 8);
      numArray1[index11 + 3] = (byte) num17;
      numArray1[index11 + 4] = (byte) ((uint) num18 >> 8);
      numArray1[index11 + 5] = (byte) num18;
      numArray1[index11 + 6] = (byte) ((uint) num19 >> 8);
      numArray1[index11 + 7] = (byte) num19;
      int index12 = index11 + 8;
      numArray1[index12] = (byte) ((uint) num20 >> 8);
      numArray1[index12 + 1] = (byte) num20;
      numArray1[index12 + 2] = (byte) ((uint) num21 >> 8);
      numArray1[index12 + 3] = (byte) num21;
      short num22 = (short) (((int) num16 + (int) num19) / 2);
      short num23 = (short) (((int) num17 + (int) num20) / 2);
      short num24 = (short) (((int) num18 + (int) num21) / 2);
      numArray1[index12 + 4] = (byte) ((uint) num22 >> 8);
      numArray1[index12 + 5] = (byte) num22;
      numArray1[index12 + 6] = (byte) ((uint) num23 >> 8);
      numArray1[index12 + 7] = (byte) num23;
      int index13 = index12 + 8;
      numArray1[index13] = (byte) ((uint) num24 >> 8);
      numArray1[index13 + 1] = (byte) num24;
      short num25 = (int) Math.Abs(num19) > (int) Math.Abs(num16) ? Math.Abs(num19) : Math.Abs(num16);
      short num26 = (int) Math.Abs(num20) > (int) Math.Abs(num17) ? Math.Abs(num20) : Math.Abs(num17);
      short num27 = (int) Math.Abs(num21) > (int) Math.Abs(num18) ? Math.Abs(num21) : Math.Abs(num18);
      numArray1[index13 + 2] = (byte) ((uint) (short) ((double) num25 * 1.3) >> 8);
      numArray1[index13 + 3] = (byte) (short) ((double) num25 * 1.3);
      numArray1[index13 + 4] = (byte) ((uint) (short) ((double) num26 * 1.3) >> 8);
      numArray1[index13 + 5] = (byte) (short) ((double) num26 * 1.3);
      short num28 = num25;
      if ((int) num28 < (int) num26)
        num28 = num26;
      if ((int) num28 < (int) num27)
        num28 = num27;
      numArray1[index13 + 6] = (byte) ((uint) (short) ((double) num28 * 1.3) >> 8);
      numArray1[index13 + 7] = (byte) (short) ((double) num28 * 1.3);
      int num29 = index13 + 8;
      for (int index2 = 0; index2 < this.vertsToMake; ++index2)
      {
        numArray1[num14 + num15] = (byte) ((uint) this.triangleGLs[this.triangleGLs.Count - 1].verts[0].x >> 8);
        numArray1[num14 + num15 + 1] = (byte) this.triangleGLs[this.triangleGLs.Count - 1].verts[0].x;
        int num1 = num15 + 2;
        numArray1[num14 + num1] = (byte) ((uint) this.triangleGLs[this.triangleGLs.Count - 1].verts[0].y >> 8);
        numArray1[num14 + num1 + 1] = (byte) this.triangleGLs[this.triangleGLs.Count - 1].verts[0].y;
        int num2 = num1 + 2;
        numArray1[num14 + num2] = (byte) ((uint) this.triangleGLs[this.triangleGLs.Count - 1].verts[0].z >> 8);
        numArray1[num14 + num2 + 1] = (byte) this.triangleGLs[this.triangleGLs.Count - 1].verts[0].z;
        int num5 = num2 + 2;
        numArray1[num14 + num5] = (byte) 0;
        numArray1[num14 + num5 + 1] = (byte) 0;
        int num6 = num5 + 2;
        numArray1[num14 + num6] = (byte) ((uint) this.triangleGLs[this.triangleGLs.Count - 1].verts[0].u >> 8);
        numArray1[num14 + num6 + 1] = (byte) this.triangleGLs[this.triangleGLs.Count - 1].verts[0].u;
        int num7 = num6 + 2;
        numArray1[num14 + num7] = (byte) ((uint) this.triangleGLs[this.triangleGLs.Count - 1].verts[0].v >> 8);
        numArray1[num14 + num7 + 1] = (byte) this.triangleGLs[this.triangleGLs.Count - 1].verts[0].v;
        int num8 = num7 + 2;
        numArray1[num14 + num8] = this.triangleGLs[this.triangleGLs.Count - 1].verts[0].r;
        int num9 = num8 + 1;
        numArray1[num14 + num9] = this.triangleGLs[this.triangleGLs.Count - 1].verts[0].g;
        int num10 = num9 + 1;
        numArray1[num14 + num10] = this.triangleGLs[this.triangleGLs.Count - 1].verts[0].b;
        int num11 = num10 + 1;
        numArray1[num14 + num11] = this.triangleGLs[this.triangleGLs.Count - 1].verts[0].a;
        num15 = num11 + 1;
      }
      int num30 = num14 + num15;
      numArray1[28] = (byte) (num30 >> 24);
      numArray1[29] = (byte) (num30 >> 16);
      numArray1[30] = (byte) (num30 >> 8);
      numArray1[31] = (byte) num30;
      for (int index2 = 0; index2 < collisionBytes.Length; ++index2)
        numArray1[num30 + index2] = collisionBytes[index2];
      int index14 = num30 + collisionBytes.Length;
      for (float num1 = (float) (index14 % 8); (double) num1 != 0.0; num1 = (float) (index14 % 8))
        ++index14;
      byte[] waves = this.calculateWaves(ref this.triangleGLs);
      byte[] vertexColourEffect = this.calculateVertexColourEffect(ref this.triangleGLs);
      byte[] textureScrollEffect1 = this.calculateTextureScrollEffect(ref this.triangleGLs, ScrollSpeed.Normal);
      byte[] textureScrollEffect2 = this.calculateTextureScrollEffect(ref this.triangleGLs, ScrollSpeed.Slow);
      byte[] textureScrollEffect3 = this.calculateTextureScrollEffect(ref this.triangleGLs, ScrollSpeed.Fast);
      int num31 = 0;
      if (waves.Length > 6)
        ++num31;
      if (vertexColourEffect.Length > 5)
        ++num31;
      if (textureScrollEffect1.Length > 5)
        ++num31;
      if (textureScrollEffect2.Length > 5)
        ++num31;
      if (textureScrollEffect3.Length > 5)
        ++num31;
      if (num31 > 0)
      {
        numArray1[36] = (byte) (index14 >> 24);
        numArray1[37] = (byte) (index14 >> 16);
        numArray1[38] = (byte) (index14 >> 8);
        numArray1[39] = (byte) index14;
        numArray1[index14] = (byte) (num31 >> 8);
        int index2 = index14 + 1;
        numArray1[index2] = (byte) num31;
        index14 = index2 + 1;
        if (waves.Length > 6)
        {
          for (int index8 = 0; index8 < waves.Length; ++index8)
            numArray1[index14 + index8] = waves[index8];
          index14 += waves.Length;
        }
        if (vertexColourEffect.Length > 5)
        {
          for (int index8 = 0; index8 < vertexColourEffect.Length; ++index8)
            numArray1[index14 + index8] = vertexColourEffect[index8];
          index14 += vertexColourEffect.Length;
        }
        if (textureScrollEffect1.Length > 5)
        {
          for (int index8 = 0; index8 < textureScrollEffect1.Length; ++index8)
            numArray1[index14 + index8] = textureScrollEffect1[index8];
          index14 += textureScrollEffect1.Length;
        }
        if (textureScrollEffect2.Length > 5)
        {
          for (int index8 = 0; index8 < textureScrollEffect2.Length; ++index8)
            numArray1[index14 + index8] = textureScrollEffect2[index8];
          index14 += textureScrollEffect2.Length;
        }
        if (textureScrollEffect3.Length > 5)
        {
          for (int index8 = 0; index8 < textureScrollEffect3.Length; ++index8)
            numArray1[index14 + index8] = textureScrollEffect3[index8];
          index14 += textureScrollEffect3.Length;
        }
        for (float num1 = (float) (index14 % 8); (double) num1 != 0.0; num1 = (float) (index14 % 8))
          ++index14;
        numArray1[32] = (byte) (index14 >> 24);
        numArray1[33] = (byte) (index14 >> 16);
        numArray1[34] = (byte) (index14 >> 8);
        numArray1[35] = (byte) index14;
      }
      numArray1[4] = (byte) (index14 >> 24);
      numArray1[5] = (byte) (index14 >> 16);
      numArray1[6] = (byte) (index14 >> 8);
      numArray1[7] = (byte) index14;
      List<int[]> numArrayList1 = new List<int[]>();
      List<int[]> numArrayList2 = new List<int[]>();
      List<int> intList3 = new List<int>();
      List<int> intList4 = new List<int>();
      List<int> intList5 = new List<int>();
      int num32 = (int) numArray1[12] * 16777216 + (int) numArray1[13] * 65536 + (int) numArray1[14] * 256 + (int) numArray1[15] + 8;
      List<byte[]> numArrayList3 = new List<byte[]>();
      int num33 = (int) numArray1[num32 - 6] * 256 + (int) numArray1[num32 - 5];
      int index15 = (int) numArray1[16] * 16777216 + (int) numArray1[17] * 65536 + (int) numArray1[18] * 256 + (int) numArray1[19] + 24;
      int length1 = (int) numArray1[50] * 256 + (int) numArray1[51];
      if (index15 + length1 * 16 == 0)
      {
        int length2 = numArray1.Length;
      }
      short[] numArray2 = new short[length1];
      short[] numArray3 = new short[length1];
      short[] numArray4 = new short[length1];
      short[] numArray5 = new short[length1];
      short[] numArray6 = new short[length1];
      short[] numArray7 = new short[length1];
      for (int index2 = 0; index2 < length1; ++index2)
      {
        numArray2[index2] = (short) ((int) numArray1[index15] * 256 + (int) numArray1[index15 + 1]);
        numArray3[index2] = (short) ((int) numArray1[index15 + 2] * 256 + (int) numArray1[index15 + 3]);
        numArray4[index2] = (short) ((int) numArray1[index15 + 4] * 256 + (int) numArray1[index15 + 5]);
        index15 += 16;
      }
      int num34 = num32;
      for (int index2 = 0; index2 < num33; ++index2)
      {
        byte[] numArray8 = new byte[8];
        for (int index8 = 0; index8 < 8; ++index8)
          numArray8[index8] = numArray1[num34 + index8];
        numArrayList3.Add(numArray8);
        num34 += 8;
      }
      for (int index2 = 0; index2 < num33; ++index2)
      {
        byte[] numArray8 = numArrayList3[index2];
        uint num1 = (uint) ((int) numArray8[4] * 16777216 + (int) numArray8[5] * 65536 + (int) numArray8[6] * 256) + (uint) numArray8[7];
        int num2 = (int) numArray8[1];
        int num5 = (int) numArray8[2];
        int num6 = (int) numArray8[3];
        if (numArray8[0] == (byte) 4)
        {
          byte num7 = (byte) ((uint) numArray8[1] >> 1);
          byte num8 = (byte) ((uint) numArray8[2] >> 2);
          if (num7 > (byte) 63)
            num7 = (byte) 63;
          uint num9 = (num1 << 8 >> 8) / 16U;
          try
          {
            for (int index8 = (int) num7; index8 < (int) num8 + (int) num7; ++index8)
            {
              if ((long) num9 < (long) numArray2.Length)
              {
                numArray5[index8] = numArray2[(int) num9];
                numArray6[index8] = numArray3[(int) num9];
                numArray7[index8] = numArray4[(int) num9];
              }
              ++num9;
            }
          }
          catch (Exception ex)
          {
          }
        }
        if (numArray8[0] == (byte) 184)
        {
          int[] numArray9 = new int[3];
          int[] numArray10 = new int[3];
          intList3.Sort();
          intList4.Sort();
          intList5.Sort();
          numArray9[0] = intList3[0];
          numArray9[1] = intList4[0];
          numArray9[2] = intList5[0];
          intList3.Reverse();
          intList4.Reverse();
          intList5.Reverse();
          numArray10[0] = intList3[0];
          numArray10[1] = intList4[0];
          numArray10[2] = intList5[0];
          numArrayList1.Add(numArray9);
          numArrayList2.Add(numArray10);
          intList3.Clear();
          intList4.Clear();
          intList5.Clear();
        }
        if (numArray8[0] == (byte) 191)
        {
          short num7 = (short) ((int) numArray8[5] / 2);
          short num8 = (short) ((int) numArray8[6] / 2);
          short num9 = (short) ((int) numArray8[7] / 2);
          intList3.Add((int) numArray5[(int) num7]);
          intList3.Add((int) numArray5[(int) num8]);
          intList3.Add((int) numArray5[(int) num9]);
          intList4.Add((int) numArray6[(int) num7]);
          intList4.Add((int) numArray6[(int) num8]);
          intList4.Add((int) numArray6[(int) num9]);
          intList5.Add((int) numArray7[(int) num7]);
          intList5.Add((int) numArray7[(int) num8]);
          intList5.Add((int) numArray7[(int) num9]);
        }
        else if (numArray8[0] == (byte) 177)
        {
          short num7 = (short) ((int) numArray8[1] / 2);
          short num8 = (short) ((int) numArray8[2] / 2);
          short num9 = (short) ((int) numArray8[3] / 2);
          short num10 = (short) ((int) numArray8[5] / 2);
          short num11 = (short) ((int) numArray8[6] / 2);
          short num35 = (short) ((int) numArray8[7] / 2);
          intList3.Add((int) numArray5[(int) num7]);
          intList3.Add((int) numArray5[(int) num8]);
          intList3.Add((int) numArray5[(int) num9]);
          intList4.Add((int) numArray6[(int) num7]);
          intList4.Add((int) numArray6[(int) num8]);
          intList4.Add((int) numArray6[(int) num9]);
          intList5.Add((int) numArray7[(int) num7]);
          intList5.Add((int) numArray7[(int) num8]);
          intList5.Add((int) numArray7[(int) num9]);
          intList3.Add((int) numArray5[(int) num10]);
          intList3.Add((int) numArray5[(int) num11]);
          intList3.Add((int) numArray5[(int) num35]);
          intList4.Add((int) numArray6[(int) num10]);
          intList4.Add((int) numArray6[(int) num11]);
          intList4.Add((int) numArray6[(int) num35]);
          intList5.Add((int) numArray7[(int) num10]);
          intList5.Add((int) numArray7[(int) num11]);
          intList5.Add((int) numArray7[(int) num35]);
        }
      }
      if (!objectModel)
      {
        numArray1[index14] = (byte) 0;
        numArray1[index14 + 1] = (byte) 0;
        numArray1[index14 + 2] = (byte) 0;
        numArray1[index14 + 3] = (byte) 13;
        int index2 = index14 + 4;
        numArray1[index2] = (byte) 0;
        numArray1[index2 + 1] = (byte) 0;
        numArray1[index2 + 2] = (byte) 0;
        numArray1[index2 + 3] = (byte) 40;
        int index8 = index2 + 4;
        numArray1[index8] = (byte) (numArrayList1[0][0] >> 8);
        numArray1[index8 + 1] = (byte) numArrayList1[0][0];
        numArray1[index8 + 2] = (byte) (numArrayList1[0][1] >> 8);
        numArray1[index8 + 3] = (byte) numArrayList1[0][1];
        int index9 = index8 + 4;
        numArray1[index9] = (byte) (numArrayList1[0][2] >> 8);
        numArray1[index9 + 1] = (byte) numArrayList1[0][2];
        numArray1[index9 + 2] = (byte) (numArrayList2[0][0] >> 8);
        numArray1[index9 + 3] = (byte) numArrayList2[0][0];
        int index10 = index9 + 4;
        numArray1[index10] = (byte) (numArrayList2[0][1] >> 8);
        numArray1[index10 + 1] = (byte) numArrayList2[0][1];
        numArray1[index10 + 2] = (byte) (numArrayList2[0][2] >> 8);
        numArray1[index10 + 3] = (byte) numArrayList2[0][2];
        int index16 = index10 + 4;
        numArray1[index16] = (byte) 0;
        numArray1[index16 + 1] = (byte) 24;
        numArray1[index16 + 2] = (byte) 8;
        numArray1[index16 + 3] = (byte) 211;
        index14 = index16 + 4;
      }
      numArray1[index14] = (byte) 0;
      numArray1[index14 + 1] = (byte) 0;
      numArray1[index14 + 2] = (byte) 0;
      numArray1[index14 + 3] = (byte) 3;
      int index17 = index14 + 4;
      numArray1[index17] = (byte) 0;
      numArray1[index17 + 1] = (byte) 0;
      numArray1[index17 + 2] = (byte) 0;
      numArray1[index17 + 3] = !objectModel || intList1.Count <= 1 ? (byte) 0 : (byte) 16;
      int index18 = index17 + 4;
      numArray1[index18] = (byte) 0;
      numArray1[index18 + 1] = (byte) 0;
      numArray1[index18 + 2] = (byte) 0;
      numArray1[index18 + 3] = (byte) 0;
      int index19 = index18 + 4;
      numArray1[index19] = (byte) 0;
      numArray1[index19 + 1] = (byte) 0;
      numArray1[index19 + 2] = (byte) 0;
      numArray1[index19 + 3] = (byte) 0;
      int index20 = index19 + 4;
      for (int index2 = 0; index2 < intList1.Count; ++index2)
      {
        if (!objectModel)
        {
          numArray1[index20] = (byte) 0;
          numArray1[index20 + 1] = (byte) 0;
          numArray1[index20 + 2] = (byte) 0;
          numArray1[index20 + 3] = (byte) 13;
          int index8 = index20 + 4;
          if (index2 == intList1.Count - 1)
          {
            numArray1[index8] = (byte) 0;
            numArray1[index8 + 1] = (byte) 0;
            numArray1[index8 + 2] = (byte) 0;
            numArray1[index8 + 3] = (byte) 0;
          }
          else
          {
            numArray1[index8] = (byte) 0;
            numArray1[index8 + 1] = (byte) 0;
            numArray1[index8 + 2] = (byte) 0;
            numArray1[index8 + 3] = (byte) 40;
          }
          int index9 = index8 + 4;
          int index10;
          if (index2 + 1 < numArrayList1.Count)
          {
            numArray1[index9] = (byte) (numArrayList1[index2 + 1][0] >> 8);
            numArray1[index9 + 1] = (byte) numArrayList1[index2 + 1][0];
            numArray1[index9 + 2] = (byte) (numArrayList1[index2 + 1][1] >> 8);
            numArray1[index9 + 3] = (byte) numArrayList1[index2 + 1][1];
            int index16 = index9 + 4;
            numArray1[index16] = (byte) (numArrayList1[index2 + 1][2] >> 8);
            numArray1[index16 + 1] = (byte) numArrayList1[index2 + 1][2];
            numArray1[index16 + 2] = (byte) (numArrayList2[index2 + 1][0] >> 8);
            numArray1[index16 + 3] = (byte) numArrayList2[index2 + 1][0];
            int index21 = index16 + 4;
            numArray1[index21] = (byte) (numArrayList2[index2 + 1][1] >> 8);
            numArray1[index21 + 1] = (byte) numArrayList2[index2 + 1][1];
            numArray1[index21 + 2] = (byte) (numArrayList2[index2 + 1][2] >> 8);
            numArray1[index21 + 3] = (byte) numArrayList2[index2 + 1][2];
            index10 = index21 + 4;
          }
          else
            index10 = index9 + 12;
          numArray1[index10] = (byte) 0;
          numArray1[index10 + 1] = (byte) 24;
          numArray1[index10 + 2] = (byte) 8;
          numArray1[index10 + 3] = (byte) 211;
          index20 = index10 + 4;
        }
        numArray1[index20] = (byte) 0;
        numArray1[index20 + 1] = (byte) 0;
        numArray1[index20 + 2] = (byte) 0;
        numArray1[index20 + 3] = (byte) 3;
        int index22 = index20 + 4;
        numArray1[index22] = (byte) 0;
        numArray1[index22 + 1] = (byte) 0;
        numArray1[index22 + 2] = (byte) 0;
        numArray1[index22 + 3] = !objectModel || index2 + 1 >= intList1.Count ? (byte) 0 : (byte) 16;
        int index23 = index22 + 4;
        numArray1[index23] = (byte) ((intList1[index2] - num4) / 8 >> 8);
        numArray1[index23 + 1] = (byte) ((intList1[index2] - num4) / 8);
        numArray1[index23 + 2] = (byte) 0;
        numArray1[index23 + 3] = (byte) 0;
        int index24 = index23 + 4;
        numArray1[index24] = (byte) 0;
        numArray1[index24 + 1] = (byte) 0;
        numArray1[index24 + 2] = (byte) 0;
        numArray1[index24 + 3] = (byte) 0;
        index20 = index24 + 4;
      }
      int length3 = index20;
      byte[] buffer = new byte[length3];
      for (int index2 = 0; index2 < length3; ++index2)
        buffer[index2] = numArray1[index2];
      FileStream fileStream = File.Create(filename);
      BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
      binaryWriter.Write(buffer);
      binaryWriter.Close();
      fileStream.Close();
    }

    public void writeAlphaModel(byte[] collisionBytes, string filename)
    {
      List<int> intList1 = new List<int>();
      byte[] header = new byte[5242880];
      header[0] = (byte) 0;
      header[1] = (byte) 0;
      header[2] = (byte) 0;
      header[3] = (byte) 11;
      header[8] = (byte) 0;
      header[9] = (byte) 56;
      header[10] = (byte) 0;
      bool flag1 = false;
      foreach (TextureSetting textureSetting in this.TextureSettingsAlpha)
      {
        if (textureSetting.textureMode == (byte) 6)
          flag1 = true;
      }
      header[11] = !flag1 ? (byte) 2 : (byte) 4;
      header[29] = (byte) 4;
      header[30] = (byte) 160;
      header[31] = (byte) 104;
      header[48] = (byte) (this.triangleGLAlphas.Count<TriangleGL>() >> 8);
      header[49] = (byte) this.triangleGLAlphas.Count<TriangleGL>();
      header[50] = (byte) (this.triangleGLAlphas.Count<TriangleGL>() * 3 >> 8);
      header[51] = (byte) (this.triangleGLAlphas.Count<TriangleGL>() * 3);
      header[52] = (byte) 66;
      header[53] = (byte) 200;
      header[54] = (byte) 0;
      header[55] = (byte) 0;
      int index1 = 64;
      if (this.TextureDataAlphaList.Count > 0)
      {
        int num1 = this.alphaTextureBytes.Count<byte>();
        for (int index2 = 0; index2 < this.TextureDataAlphaList.Count; ++index2)
        {
          if (this.TextureDataAlphaList[index2].height != 0)
            num1 += 16;
        }
        int num2 = num1 + 8;
        header[56] = (byte) (num2 >> 24);
        header[57] = (byte) (num2 >> 16);
        header[58] = (byte) (num2 >> 8);
        header[59] = (byte) num2;
        List<int> intList2 = new List<int>();
        for (int index2 = 0; index2 < this.alphaTextureOffsets.Count; ++index2)
        {
          if (this.alphaTextureOffsets[index2].name != "" && !intList2.Contains(this.alphaTextureOffsets[index2].offset))
          {
            intList2.Add(this.alphaTextureOffsets[index2].offset);
            int offset = this.alphaTextureOffsets[index2].offset;
            header[index1] = (byte) (offset >> 24);
            header[index1 + 1] = (byte) (offset >> 16);
            header[index1 + 2] = (byte) (offset >> 8);
            header[index1 + 3] = (byte) offset;
            header[index1 + 4] = (byte) 0;
            header[index1 + 5] = (byte) 1;
            header[index1 + 6] = (byte) 0;
            header[index1 + 7] = (byte) 0;
            header[index1 + 8] = (byte) this.alphaTextureOffsets[index2].width;
            header[index1 + 9] = (byte) this.alphaTextureOffsets[index2].height;
            header[index1 + 10] = (byte) 0;
            header[index1 + 11] = (byte) 0;
            header[index1 + 12] = (byte) 0;
            header[index1 + 13] = (byte) 0;
            header[index1 + 14] = (byte) 0;
            header[index1 + 15] = (byte) 0;
            index1 += 16;
          }
        }
        header[60] = (byte) (intList2.Count >> 8);
        header[61] = (byte) intList2.Count;
        header[62] = (byte) 0;
        header[63] = (byte) 0;
      }
      int index3 = index1;
      for (int index2 = 0; index2 < this.alphaTextureBytes.Count; ++index2)
      {
        header[index3] = this.alphaTextureBytes[index2];
        ++index3;
      }
      int num3 = index3;
      header[12] = (byte) (num3 >> 24);
      header[13] = (byte) (num3 >> 16);
      header[14] = (byte) (num3 >> 8);
      header[15] = (byte) num3;
      int index4 = num3;
      int f3dexlocation = num3 + 8;
      int num4 = f3dexlocation;
      int index5 = 0;
      if (this.alphaTextureOrder != null)
      {
        if (this.alphaTextureOrder[0] != "(null)" && this.alphaTextureOffsets != null && (this.alphaTextureOrder[0] != "" && this.alphaTextureOrder[0] != "None"))
        {
          string str = this.alphaTextureOrder[0];
          for (int index2 = 0; index2 < this.alphaTextureOffsets.Count; ++index2)
          {
            if (str == this.alphaTextureOffsets[index2].name)
              index5 = index2;
          }
          if (this.alphaTextureOffsets[index5].height != 0)
          {
            int num1 = this.alphaTextureOffsets[index5].height / 16;
            int num2 = this.alphaTextureOffsets[index5].width / 16;
            int num5 = this.alphaTextureOffsets[0].width / 8;
            int num6 = this.alphaTextureOffsets[index5].width - 1;
            int num7 = this.alphaTextureOffsets[index5].height - 1;
            byte num8 = (byte) (num6 >> 2);
            byte num9 = (byte) (num6 << 6);
            byte num10 = (byte) (num7 >> 6);
            int num11 = (int) (byte) (num7 << 2);
            this.f3dex.CI2F3dex(ref header, ref f3dexlocation, this.alphaTextureOffsets[index5], this.TextureSettingsAlpha[this.triangleGLAlphas[0].textureSetting].getCullMode(), this.TextureSettingsAlpha[this.triangleGLAlphas[0].textureSetting].textureMode);
          }
          else
            this.f3dex.GEN_DLNoTextures(ref header, ref f3dexlocation, this.TextureSettingsAlpha[this.triangleGLAlphas[0].textureSetting].getCullMode(), this.TextureSettingsAlpha[this.triangleGLAlphas[0].textureSetting].textureMode);
        }
        else
          this.f3dex.GEN_DLNoTextures(ref header, ref f3dexlocation, this.TextureSettingsAlpha[this.triangleGLAlphas[0].textureSetting].getCullMode(), this.TextureSettingsAlpha[this.triangleGLAlphas[0].textureSetting].textureMode);
      }
      else
        this.f3dex.GEN_DLNoTextures(ref header, ref f3dexlocation, this.TextureSettingsAlpha[this.triangleGLAlphas[0].textureSetting].getCullMode(), this.TextureSettingsAlpha[this.triangleGLAlphas[0].textureSetting].textureMode);
      ArrayList arrayList = new ArrayList();
      int index6 = 1;
      int index7 = 0;
      int num12 = 0;
      for (int index2 = 0; index2 < this.triangleGLAlphas.Count; index2 += 2)
      {
        try
        {
          bool flag2 = false;
          if (this.alphaTextureOffsets != null && index2 != 0)
          {
            for (int index8 = 0; index8 < this.alphaTextureLocations.Count; ++index8)
            {
              if (index2 == this.alphaTextureLocations[index8])
              {
                arrayList.Clear();
                string str = this.alphaTextureOrder[index6];
                ++index6;
                for (int index9 = 0; index9 < this.alphaTextureOffsets.Count; ++index9)
                {
                  if (str == this.alphaTextureOffsets[index9].name)
                    index7 = index9;
                }
                header[f3dexlocation] = (byte) 186;
                header[f3dexlocation + 1] = (byte) 0;
                header[f3dexlocation + 2] = (byte) 14;
                header[f3dexlocation + 3] = (byte) 2;
                header[f3dexlocation + 4] = (byte) 0;
                header[f3dexlocation + 5] = (byte) 0;
                header[f3dexlocation + 6] = (byte) 0;
                header[f3dexlocation + 7] = (byte) 0;
                f3dexlocation += 8;
                header[f3dexlocation] = (byte) 184;
                header[f3dexlocation + 1] = (byte) 0;
                header[f3dexlocation + 2] = (byte) 0;
                header[f3dexlocation + 3] = (byte) 0;
                header[f3dexlocation + 4] = (byte) 0;
                header[f3dexlocation + 5] = (byte) 0;
                header[f3dexlocation + 6] = (byte) 0;
                header[f3dexlocation + 7] = (byte) 0;
                f3dexlocation += 8;
                intList1.Add(f3dexlocation);
                if (this.TextureSettingsAlpha[this.triangleGLAlphas[index2].textureSetting].textureData == -1)
                  this.f3dex.GEN_DLNoTextures(ref header, ref f3dexlocation, this.TextureSettingsAlpha[this.triangleGLAlphas[index2].textureSetting].getCullMode(), this.TextureSettingsAlpha[this.triangleGLAlphas[index2].textureSetting].textureMode);
                else
                  this.f3dex.CI2F3dex(ref header, ref f3dexlocation, this.alphaTextureOffsets[index7], this.TextureSettingsAlpha[this.triangleGLAlphas[index2].textureSetting].getCullMode(), this.TextureSettingsAlpha[this.triangleGLAlphas[index2].textureSetting].textureMode);
              }
            }
          }
          for (int index8 = 0; index8 < this.AlphaVTXLocations.Count; ++index8)
          {
            if (index2 == this.AlphaVTXLocations[index8])
            {
              byte[] alphaVtxCommand = this.AlphaVTXCommands[index8];
              int num1 = ((int) alphaVtxCommand[5] * 65536 + (int) alphaVtxCommand[6] * 256 + (int) alphaVtxCommand[7]) / 16;
              header[f3dexlocation] = (byte) 4;
              header[f3dexlocation + 1] = (byte) 0;
              header[f3dexlocation + 2] = (byte) 129;
              header[f3dexlocation + 3] = byte.MaxValue;
              header[f3dexlocation + 4] = (byte) 1;
              header[f3dexlocation + 5] = alphaVtxCommand[5];
              header[f3dexlocation + 6] = alphaVtxCommand[6];
              header[f3dexlocation + 7] = alphaVtxCommand[7];
              f3dexlocation += 8;
              int num2 = ((int) alphaVtxCommand[5] * 65536 + (int) alphaVtxCommand[6] * 256 + (int) alphaVtxCommand[7]) / 16;
              num12 = 0;
            }
            if (index2 + 1 == this.AlphaVTXLocations[index8])
            {
              header[f3dexlocation] = (byte) 191;
              header[f3dexlocation + 1] = (byte) 0;
              header[f3dexlocation + 2] = (byte) 0;
              header[f3dexlocation + 3] = (byte) 0;
              header[f3dexlocation + 4] = (byte) 0;
              header[f3dexlocation + 5] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 6] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 7] = (byte) (num12 * 2);
              ++num12;
              f3dexlocation += 8;
              byte[] alphaVtxCommand = this.AlphaVTXCommands[index8];
              int num1 = ((int) alphaVtxCommand[5] * 65536 + (int) alphaVtxCommand[6] * 256 + (int) alphaVtxCommand[7]) / 16;
              if (this.alphaTextureOffsets != null)
              {
                for (int index9 = 0; index9 < this.alphaTextureLocations.Count; ++index9)
                {
                  if (index2 + 1 == this.alphaTextureLocations[index9])
                  {
                    string str = this.alphaTextureOrder[index6];
                    ++index6;
                    for (int index10 = 0; index10 < this.alphaTextureOffsets.Count; ++index10)
                    {
                      if (str == this.alphaTextureOffsets[index10].name)
                        index7 = index10;
                    }
                    header[f3dexlocation] = (byte) 186;
                    header[f3dexlocation + 1] = (byte) 0;
                    header[f3dexlocation + 2] = (byte) 14;
                    header[f3dexlocation + 3] = (byte) 2;
                    header[f3dexlocation + 4] = (byte) 0;
                    header[f3dexlocation + 5] = (byte) 0;
                    header[f3dexlocation + 6] = (byte) 0;
                    header[f3dexlocation + 7] = (byte) 0;
                    f3dexlocation += 8;
                    header[f3dexlocation] = (byte) 184;
                    header[f3dexlocation + 1] = (byte) 0;
                    header[f3dexlocation + 2] = (byte) 0;
                    header[f3dexlocation + 3] = (byte) 0;
                    header[f3dexlocation + 4] = (byte) 0;
                    header[f3dexlocation + 5] = (byte) 0;
                    header[f3dexlocation + 6] = (byte) 0;
                    header[f3dexlocation + 7] = (byte) 0;
                    f3dexlocation += 8;
                    intList1.Add(f3dexlocation);
                    if (this.TextureSettingsAlpha[this.triangleGLAlphas[index2 + 1].textureSetting].textureData == -1)
                      this.f3dex.GEN_DLNoTextures(ref header, ref f3dexlocation, this.TextureSettingsAlpha[this.triangleGLAlphas[index2 + 1].textureSetting].getCullMode(), this.TextureSettingsAlpha[this.triangleGLAlphas[index2 + 1].textureSetting].textureMode);
                    else
                      this.f3dex.CI2F3dex(ref header, ref f3dexlocation, this.alphaTextureOffsets[index7], this.TextureSettingsAlpha[this.triangleGLAlphas[index2 + 1].textureSetting].getCullMode(), this.TextureSettingsAlpha[this.triangleGLAlphas[index2 + 1].textureSetting].textureMode);
                  }
                }
              }
              header[f3dexlocation] = (byte) 4;
              header[f3dexlocation + 1] = (byte) 0;
              header[f3dexlocation + 2] = (byte) 129;
              header[f3dexlocation + 3] = byte.MaxValue;
              header[f3dexlocation + 4] = (byte) 1;
              header[f3dexlocation + 5] = alphaVtxCommand[5];
              header[f3dexlocation + 6] = alphaVtxCommand[6];
              header[f3dexlocation + 7] = alphaVtxCommand[7];
              f3dexlocation += 8;
              num12 = 0;
              header[f3dexlocation] = (byte) 191;
              header[f3dexlocation + 1] = (byte) 0;
              header[f3dexlocation + 2] = (byte) 0;
              header[f3dexlocation + 3] = (byte) 0;
              header[f3dexlocation + 4] = (byte) 0;
              header[f3dexlocation + 5] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 6] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 7] = (byte) (num12 * 2);
              ++num12;
              f3dexlocation += 8;
              flag2 = true;
            }
          }
          if (!flag2)
          {
            if (index2 + 1 == this.triangleGLAlphas.Count)
            {
              header[f3dexlocation] = (byte) 191;
              header[f3dexlocation + 1] = (byte) 0;
              header[f3dexlocation + 2] = (byte) 0;
              header[f3dexlocation + 3] = (byte) 0;
              header[f3dexlocation + 4] = (byte) 0;
              header[f3dexlocation + 5] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 6] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 7] = (byte) (num12 * 2);
              ++num12;
              f3dexlocation += 8;
            }
            else
            {
              header[f3dexlocation] = (byte) 177;
              header[f3dexlocation + 1] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 2] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 3] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 4] = (byte) 0;
              header[f3dexlocation + 5] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 6] = (byte) (num12 * 2);
              ++num12;
              header[f3dexlocation + 7] = (byte) (num12 * 2);
              ++num12;
              f3dexlocation += 8;
            }
          }
        }
        catch (Exception ex)
        {
        }
      }
      header[f3dexlocation] = (byte) 186;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 14;
      header[f3dexlocation + 3] = (byte) 2;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = (byte) 0;
      header[f3dexlocation + 6] = (byte) 0;
      header[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 184;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = (byte) 0;
      header[f3dexlocation + 6] = (byte) 0;
      header[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
      int num13 = (f3dexlocation - index4) / 8 - 1;
      header[index4] = (byte) (num13 >> 24);
      header[index4 + 1] = (byte) (num13 >> 16);
      header[index4 + 2] = (byte) (num13 >> 8);
      header[index4 + 3] = (byte) num13;
      header[17] = (byte) (f3dexlocation >> 16);
      header[18] = (byte) (f3dexlocation >> 8);
      header[19] = (byte) f3dexlocation;
      header[f3dexlocation] = (byte) 180;
      header[f3dexlocation + 1] = (byte) 16;
      header[f3dexlocation + 2] = (byte) 2;
      header[f3dexlocation + 3] = (byte) 105;
      header[f3dexlocation + 4] = (byte) 173;
      header[f3dexlocation + 5] = (byte) 188;
      header[f3dexlocation + 6] = (byte) 84;
      header[f3dexlocation + 7] = (byte) 96;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 12;
      header[f3dexlocation + 1] = (byte) 108;
      header[f3dexlocation + 2] = (byte) 82;
      header[f3dexlocation + 3] = (byte) 68;
      header[f3dexlocation + 4] = (byte) 4;
      header[f3dexlocation + 5] = (byte) 56;
      header[f3dexlocation + 6] = (byte) 7;
      header[f3dexlocation + 7] = (byte) 106;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 0;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 100;
      header[f3dexlocation + 3] = (byte) 44;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = (byte) 220;
      header[f3dexlocation + 6] = (byte) 103;
      header[f3dexlocation + 7] = (byte) 124;
      f3dexlocation += 8;
      int num14 = f3dexlocation;
      int index11 = num14 - 24;
      int num15 = 0;
      short num16 = short.MaxValue;
      short num17 = short.MaxValue;
      short num18 = short.MaxValue;
      short num19 = short.MinValue;
      short num20 = short.MinValue;
      short num21 = short.MinValue;
      for (int index2 = 0; index2 < this.triangleGLAlphas.Count; ++index2)
      {
        for (int index8 = 0; index8 < 3; ++index8)
        {
          try
          {
            header[num14 + num15] = (byte) ((uint) this.triangleGLAlphas[index2].verts[index8].x >> 8);
            header[num14 + num15 + 1] = (byte) this.triangleGLAlphas[index2].verts[index8].x;
            num15 += 2;
            header[num14 + num15] = (byte) ((uint) this.triangleGLAlphas[index2].verts[index8].y >> 8);
            header[num14 + num15 + 1] = (byte) this.triangleGLAlphas[index2].verts[index8].y;
            num15 += 2;
            header[num14 + num15] = (byte) ((uint) this.triangleGLAlphas[index2].verts[index8].z >> 8);
            header[num14 + num15 + 1] = (byte) this.triangleGLAlphas[index2].verts[index8].z;
            num15 += 2;
            header[num14 + num15] = (byte) 0;
            header[num14 + num15 + 1] = (byte) 0;
            num15 += 2;
            header[num14 + num15] = (byte) ((uint) this.triangleGLAlphas[index2].verts[index8].u >> 8);
            header[num14 + num15 + 1] = (byte) this.triangleGLAlphas[index2].verts[index8].u;
            num15 += 2;
            header[num14 + num15] = (byte) ((uint) this.triangleGLAlphas[index2].verts[index8].v >> 8);
            header[num14 + num15 + 1] = (byte) this.triangleGLAlphas[index2].verts[index8].v;
            num15 += 2;
            header[num14 + num15] = this.triangleGLAlphas[index2].verts[index8].r;
            ++num15;
            header[num14 + num15] = this.triangleGLAlphas[index2].verts[index8].g;
            ++num15;
            header[num14 + num15] = this.triangleGLAlphas[index2].verts[index8].b;
            ++num15;
            header[num14 + num15] = this.triangleGLAlphas[index2].verts[index8].a;
            ++num15;
            if ((int) this.triangleGLAlphas[index2].verts[index8].x < (int) num16)
              num16 = this.triangleGLAlphas[index2].verts[index8].x;
            if ((int) this.triangleGLAlphas[index2].verts[index8].y < (int) num17)
              num17 = this.triangleGLAlphas[index2].verts[index8].y;
            if ((int) this.triangleGLAlphas[index2].verts[index8].z < (int) num18)
              num18 = this.triangleGLAlphas[index2].verts[index8].z;
            if ((int) this.triangleGLAlphas[index2].verts[index8].x > (int) num19)
              num19 = this.triangleGLAlphas[index2].verts[index8].x;
            if ((int) this.triangleGLAlphas[index2].verts[index8].y > (int) num20)
              num20 = this.triangleGLAlphas[index2].verts[index8].y;
            if ((int) this.triangleGLAlphas[index2].verts[index8].z > (int) num21)
              num21 = this.triangleGLAlphas[index2].verts[index8].z;
          }
          catch (Exception ex)
          {
          }
        }
      }
      header[index11] = (byte) ((uint) num16 >> 8);
      header[index11 + 1] = (byte) num16;
      header[index11 + 2] = (byte) ((uint) num17 >> 8);
      header[index11 + 3] = (byte) num17;
      header[index11 + 4] = (byte) ((uint) num18 >> 8);
      header[index11 + 5] = (byte) num18;
      header[index11 + 6] = (byte) ((uint) num19 >> 8);
      header[index11 + 7] = (byte) num19;
      int index12 = index11 + 8;
      header[index12] = (byte) ((uint) num20 >> 8);
      header[index12 + 1] = (byte) num20;
      header[index12 + 2] = (byte) ((uint) num21 >> 8);
      header[index12 + 3] = (byte) num21;
      short num22 = (short) (((int) num16 + (int) num19) / 2);
      short num23 = (short) (((int) num17 + (int) num20) / 2);
      short num24 = (short) (((int) num18 + (int) num21) / 2);
      header[index12 + 4] = (byte) ((uint) num22 >> 8);
      header[index12 + 5] = (byte) num22;
      header[index12 + 6] = (byte) ((uint) num23 >> 8);
      header[index12 + 7] = (byte) num23;
      int index13 = index12 + 8;
      header[index13] = (byte) ((uint) num24 >> 8);
      header[index13 + 1] = (byte) num24;
      short num25 = (int) Math.Abs(num19) > (int) Math.Abs(num16) ? Math.Abs(num19) : Math.Abs(num16);
      short num26 = (int) Math.Abs(num20) > (int) Math.Abs(num17) ? Math.Abs(num20) : Math.Abs(num17);
      short num27 = (int) Math.Abs(num21) > (int) Math.Abs(num18) ? Math.Abs(num21) : Math.Abs(num18);
      header[index13 + 2] = (byte) ((uint) (short) ((double) num25 * 1.3) >> 8);
      header[index13 + 3] = (byte) (short) ((double) num25 * 1.3);
      header[index13 + 4] = (byte) ((uint) (short) ((double) num26 * 1.3) >> 8);
      header[index13 + 5] = (byte) (short) ((double) num26 * 1.3);
      short num28 = num25;
      if ((int) num28 < (int) num26)
        num28 = num26;
      if ((int) num28 < (int) num27)
        num28 = num27;
      header[index13 + 6] = (byte) ((uint) (short) ((double) num28 * 1.3) >> 8);
      header[index13 + 7] = (byte) (short) ((double) num28 * 1.3);
      int num29 = index13 + 8;
      int num30 = num14 + num15;
      header[28] = (byte) (num30 >> 24);
      header[29] = (byte) (num30 >> 16);
      header[30] = (byte) (num30 >> 8);
      header[31] = (byte) num30;
      for (int index2 = 0; index2 < collisionBytes.Length; ++index2)
        header[num30 + index2] = collisionBytes[index2];
      int index14 = num30 + collisionBytes.Length;
      for (float num1 = (float) (index14 % 8); (double) num1 != 0.0; num1 = (float) (index14 % 8))
        ++index14;
      byte[] waves = this.calculateWaves(ref this.triangleGLAlphas);
      byte[] vertexColourEffect = this.calculateVertexColourEffect(ref this.triangleGLAlphas);
      byte[] textureScrollEffect1 = this.calculateTextureScrollEffect(ref this.triangleGLAlphas, ScrollSpeed.Normal);
      byte[] textureScrollEffect2 = this.calculateTextureScrollEffect(ref this.triangleGLAlphas, ScrollSpeed.Slow);
      byte[] textureScrollEffect3 = this.calculateTextureScrollEffect(ref this.triangleGLAlphas, ScrollSpeed.Fast);
      int num31 = 0;
      if (waves.Length > 6)
        ++num31;
      if (vertexColourEffect.Length > 5)
        ++num31;
      if (textureScrollEffect1.Length > 5)
        ++num31;
      if (textureScrollEffect3.Length > 5)
        ++num31;
      if (textureScrollEffect2.Length > 5)
        ++num31;
      if (num31 > 0)
      {
        header[36] = (byte) (index14 >> 24);
        header[37] = (byte) (index14 >> 16);
        header[38] = (byte) (index14 >> 8);
        header[39] = (byte) index14;
        header[index14] = (byte) (num31 >> 8);
        int index2 = index14 + 1;
        header[index2] = (byte) num31;
        index14 = index2 + 1;
        if (waves.Length > 6)
        {
          for (int index8 = 0; index8 < waves.Length; ++index8)
            header[index14 + index8] = waves[index8];
          index14 += waves.Length;
        }
        if (vertexColourEffect.Length > 5)
        {
          for (int index8 = 0; index8 < vertexColourEffect.Length; ++index8)
            header[index14 + index8] = vertexColourEffect[index8];
          index14 += vertexColourEffect.Length;
        }
        if (textureScrollEffect1.Length > 5)
        {
          for (int index8 = 0; index8 < textureScrollEffect1.Length; ++index8)
            header[index14 + index8] = textureScrollEffect1[index8];
          index14 += textureScrollEffect1.Length;
        }
        if (textureScrollEffect2.Length > 5)
        {
          for (int index8 = 0; index8 < textureScrollEffect2.Length; ++index8)
            header[index14 + index8] = textureScrollEffect2[index8];
          index14 += textureScrollEffect2.Length;
        }
        if (textureScrollEffect3.Length > 5)
        {
          for (int index8 = 0; index8 < textureScrollEffect3.Length; ++index8)
            header[index14 + index8] = textureScrollEffect3[index8];
          index14 += textureScrollEffect3.Length;
        }
        for (float num1 = (float) (index14 % 8); (double) num1 != 0.0; num1 = (float) (index14 % 8))
          ++index14;
        header[32] = (byte) (index14 >> 24);
        header[33] = (byte) (index14 >> 16);
        header[34] = (byte) (index14 >> 8);
        header[35] = (byte) index14;
      }
      header[4] = (byte) (index14 >> 24);
      header[5] = (byte) (index14 >> 16);
      header[6] = (byte) (index14 >> 8);
      header[7] = (byte) index14;
      List<int[]> numArrayList1 = new List<int[]>();
      List<int[]> numArrayList2 = new List<int[]>();
      List<int> intList3 = new List<int>();
      List<int> intList4 = new List<int>();
      List<int> intList5 = new List<int>();
      int num32 = (int) header[12] * 16777216 + (int) header[13] * 65536 + (int) header[14] * 256 + (int) header[15] + 8;
      List<byte[]> numArrayList3 = new List<byte[]>();
      int num33 = (int) header[num32 - 6] * 256 + (int) header[num32 - 5];
      int index15 = (int) header[16] * 16777216 + (int) header[17] * 65536 + (int) header[18] * 256 + (int) header[19] + 24;
      int length1 = (int) header[50] * 256 + (int) header[51];
      if (index15 + length1 * 16 == 0)
      {
        int length2 = header.Length;
      }
      short[] numArray1 = new short[length1];
      short[] numArray2 = new short[length1];
      short[] numArray3 = new short[length1];
      short[] numArray4 = new short[length1];
      short[] numArray5 = new short[length1];
      short[] numArray6 = new short[length1];
      for (int index2 = 0; index2 < length1; ++index2)
      {
        numArray1[index2] = (short) ((int) header[index15] * 256 + (int) header[index15 + 1]);
        numArray2[index2] = (short) ((int) header[index15 + 2] * 256 + (int) header[index15 + 3]);
        numArray3[index2] = (short) ((int) header[index15 + 4] * 256 + (int) header[index15 + 5]);
        index15 += 16;
      }
      int num34 = num32;
      for (int index2 = 0; index2 < num33; ++index2)
      {
        byte[] numArray7 = new byte[8];
        for (int index8 = 0; index8 < 8; ++index8)
          numArray7[index8] = header[num34 + index8];
        numArrayList3.Add(numArray7);
        num34 += 8;
      }
      for (int index2 = 0; index2 < num33; ++index2)
      {
        byte[] numArray7 = numArrayList3[index2];
        uint num1 = (uint) ((int) numArray7[4] * 16777216 + (int) numArray7[5] * 65536 + (int) numArray7[6] * 256) + (uint) numArray7[7];
        int num2 = (int) numArray7[1];
        int num5 = (int) numArray7[2];
        int num6 = (int) numArray7[3];
        if (numArray7[0] == (byte) 4)
        {
          byte num7 = (byte) ((uint) numArray7[1] >> 1);
          byte num8 = (byte) ((uint) numArray7[2] >> 2);
          if (num7 > (byte) 63)
            num7 = (byte) 63;
          uint num9 = (num1 << 8 >> 8) / 16U;
          try
          {
            for (int index8 = (int) num7; index8 < (int) num8 + (int) num7; ++index8)
            {
              if ((long) num9 < (long) numArray1.Length)
              {
                numArray4[index8] = numArray1[(int) num9];
                numArray5[index8] = numArray2[(int) num9];
                numArray6[index8] = numArray3[(int) num9];
              }
              ++num9;
            }
          }
          catch (Exception ex)
          {
          }
        }
        if (numArray7[0] == (byte) 184)
        {
          int[] numArray8 = new int[3];
          int[] numArray9 = new int[3];
          intList3.Sort();
          intList4.Sort();
          intList5.Sort();
          numArray8[0] = intList3[0];
          numArray8[1] = intList4[0];
          numArray8[2] = intList5[0];
          intList3.Reverse();
          intList4.Reverse();
          intList5.Reverse();
          numArray9[0] = intList3[0];
          numArray9[1] = intList4[0];
          numArray9[2] = intList5[0];
          numArrayList1.Add(numArray8);
          numArrayList2.Add(numArray9);
          intList3.Clear();
          intList4.Clear();
          intList5.Clear();
        }
        if (numArray7[0] == (byte) 191)
        {
          short num7 = (short) ((int) numArray7[5] / 2);
          short num8 = (short) ((int) numArray7[6] / 2);
          short num9 = (short) ((int) numArray7[7] / 2);
          intList3.Add((int) numArray4[(int) num7]);
          intList3.Add((int) numArray4[(int) num8]);
          intList3.Add((int) numArray4[(int) num9]);
          intList4.Add((int) numArray5[(int) num7]);
          intList4.Add((int) numArray5[(int) num8]);
          intList4.Add((int) numArray5[(int) num9]);
          intList5.Add((int) numArray6[(int) num7]);
          intList5.Add((int) numArray6[(int) num8]);
          intList5.Add((int) numArray6[(int) num9]);
        }
        else if (numArray7[0] == (byte) 177)
        {
          short num7 = (short) ((int) numArray7[1] / 2);
          short num8 = (short) ((int) numArray7[2] / 2);
          short num9 = (short) ((int) numArray7[3] / 2);
          short num10 = (short) ((int) numArray7[5] / 2);
          short num11 = (short) ((int) numArray7[6] / 2);
          short num35 = (short) ((int) numArray7[7] / 2);
          intList3.Add((int) numArray4[(int) num7]);
          intList3.Add((int) numArray4[(int) num8]);
          intList3.Add((int) numArray4[(int) num9]);
          intList4.Add((int) numArray5[(int) num7]);
          intList4.Add((int) numArray5[(int) num8]);
          intList4.Add((int) numArray5[(int) num9]);
          intList5.Add((int) numArray6[(int) num7]);
          intList5.Add((int) numArray6[(int) num8]);
          intList5.Add((int) numArray6[(int) num9]);
          intList3.Add((int) numArray4[(int) num10]);
          intList3.Add((int) numArray4[(int) num11]);
          intList3.Add((int) numArray4[(int) num35]);
          intList4.Add((int) numArray5[(int) num10]);
          intList4.Add((int) numArray5[(int) num11]);
          intList4.Add((int) numArray5[(int) num35]);
          intList5.Add((int) numArray6[(int) num10]);
          intList5.Add((int) numArray6[(int) num11]);
          intList5.Add((int) numArray6[(int) num35]);
        }
      }
      header[index14] = (byte) 0;
      header[index14 + 1] = (byte) 0;
      header[index14 + 2] = (byte) 0;
      header[index14 + 3] = (byte) 13;
      int index16 = index14 + 4;
      header[index16] = (byte) 0;
      header[index16 + 1] = (byte) 0;
      header[index16 + 2] = (byte) 0;
      header[index16 + 3] = (byte) 40;
      int index17 = index16 + 4;
      header[index17] = (byte) (numArrayList1[0][0] >> 8);
      header[index17 + 1] = (byte) numArrayList1[0][0];
      header[index17 + 2] = (byte) (numArrayList1[0][1] >> 8);
      header[index17 + 3] = (byte) numArrayList1[0][1];
      int index18 = index17 + 4;
      header[index18] = (byte) (numArrayList1[0][2] >> 8);
      header[index18 + 1] = (byte) numArrayList1[0][2];
      header[index18 + 2] = (byte) (numArrayList2[0][0] >> 8);
      header[index18 + 3] = (byte) numArrayList2[0][0];
      int index19 = index18 + 4;
      header[index19] = (byte) (numArrayList2[0][1] >> 8);
      header[index19 + 1] = (byte) numArrayList2[0][1];
      header[index19 + 2] = (byte) (numArrayList2[0][2] >> 8);
      header[index19 + 3] = (byte) numArrayList2[0][2];
      int index20 = index19 + 4;
      header[index20] = (byte) 0;
      header[index20 + 1] = (byte) 24;
      header[index20 + 2] = (byte) 8;
      header[index20 + 3] = (byte) 211;
      int index21 = index20 + 4;
      header[index21] = (byte) 0;
      header[index21 + 1] = (byte) 0;
      header[index21 + 2] = (byte) 0;
      header[index21 + 3] = (byte) 3;
      int index22 = index21 + 4;
      header[index22] = (byte) 0;
      header[index22 + 1] = (byte) 0;
      header[index22 + 2] = (byte) 0;
      header[index22 + 3] = (byte) 0;
      int index23 = index22 + 4;
      header[index23] = (byte) 0;
      header[index23 + 1] = (byte) 0;
      header[index23 + 2] = (byte) 0;
      header[index23 + 3] = (byte) 0;
      int index24 = index23 + 4;
      header[index24] = (byte) 0;
      header[index24 + 1] = (byte) 0;
      header[index24 + 2] = (byte) 0;
      header[index24 + 3] = (byte) 0;
      int index25 = index24 + 4;
      for (int index2 = 0; index2 < intList1.Count; ++index2)
      {
        header[index25] = (byte) 0;
        header[index25 + 1] = (byte) 0;
        header[index25 + 2] = (byte) 0;
        header[index25 + 3] = (byte) 13;
        int index8 = index25 + 4;
        if (index2 == intList1.Count - 1)
        {
          header[index8] = (byte) 0;
          header[index8 + 1] = (byte) 0;
          header[index8 + 2] = (byte) 0;
          header[index8 + 3] = (byte) 0;
        }
        else
        {
          header[index8] = (byte) 0;
          header[index8 + 1] = (byte) 0;
          header[index8 + 2] = (byte) 0;
          header[index8 + 3] = (byte) 40;
        }
        int index9 = index8 + 4;
        header[index9] = (byte) (numArrayList1[index2 + 1][0] >> 8);
        header[index9 + 1] = (byte) numArrayList1[index2 + 1][0];
        header[index9 + 2] = (byte) (numArrayList1[index2 + 1][1] >> 8);
        header[index9 + 3] = (byte) numArrayList1[index2 + 1][1];
        int index10 = index9 + 4;
        header[index10] = (byte) (numArrayList1[index2 + 1][2] >> 8);
        header[index10 + 1] = (byte) numArrayList1[index2 + 1][2];
        header[index10 + 2] = (byte) (numArrayList2[index2 + 1][0] >> 8);
        header[index10 + 3] = (byte) numArrayList2[index2 + 1][0];
        int index26 = index10 + 4;
        header[index26] = (byte) (numArrayList2[index2 + 1][1] >> 8);
        header[index26 + 1] = (byte) numArrayList2[index2 + 1][1];
        header[index26 + 2] = (byte) (numArrayList2[index2 + 1][2] >> 8);
        header[index26 + 3] = (byte) numArrayList2[index2 + 1][2];
        int index27 = index26 + 4;
        header[index27] = (byte) 0;
        header[index27 + 1] = (byte) 24;
        header[index27 + 2] = (byte) 8;
        header[index27 + 3] = (byte) 211;
        int index28 = index27 + 4;
        header[index28] = (byte) 0;
        header[index28 + 1] = (byte) 0;
        header[index28 + 2] = (byte) 0;
        header[index28 + 3] = (byte) 3;
        int index29 = index28 + 4;
        header[index29] = (byte) 0;
        header[index29 + 1] = (byte) 0;
        header[index29 + 2] = (byte) 0;
        header[index29 + 3] = (byte) 0;
        int index30 = index29 + 4;
        header[index30] = (byte) ((intList1[index2] - num4) / 8 >> 8);
        header[index30 + 1] = (byte) ((intList1[index2] - num4) / 8);
        header[index30 + 2] = (byte) 0;
        header[index30 + 3] = (byte) 0;
        int index31 = index30 + 4;
        header[index31] = (byte) 0;
        header[index31 + 1] = (byte) 0;
        header[index31 + 2] = (byte) 0;
        header[index31 + 3] = (byte) 0;
        index25 = index31 + 4;
      }
      int length3 = index25;
      byte[] buffer = new byte[length3];
      for (int index2 = 0; index2 < length3; ++index2)
        buffer[index2] = header[index2];
      FileStream fileStream = File.Create(filename);
      BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
      binaryWriter.Write(buffer);
      binaryWriter.Close();
      fileStream.Close();
    }

    public void calculateTextureOffsets()
    {
      List<int> intList1 = new List<int>();
      List<int> intList2 = new List<int>();
      for (int index1 = 0; index1 < this.triangleGLs.Count<TriangleGL>(); ++index1)
      {
        TextureSetting textureSetting = this.TextureSettings[this.triangleGLs[index1].textureSetting];
        byte[] numArray = new byte[4];
        if (textureSetting.textureData != -1)
          numArray = this.TextureDataList[textureSetting.textureData].n64;
        if (!textureSetting.processed)
        {
          int num = textureSetting.palSize != 256 ? 32 + textureSetting.width * textureSetting.height / 2 : 512 + textureSetting.width * textureSetting.height;
          if (textureSetting.palSize == 0)
            num = 0;
          TextureOffset textureOffset = new TextureOffset();
          textureOffset.size = num;
          textureOffset.width = textureSetting.width;
          textureOffset.height = textureSetting.height;
          textureOffset.cms = textureSetting.cms;
          textureOffset.cmt = textureSetting.cmt;
          textureOffset.palSize = textureSetting.palSize;
          if (textureSetting.width != 0)
          {
            try
            {
              bool flag = false;
              int index2 = 0;
              for (int index3 = 0; index3 < intList1.Count && !flag; ++index3)
              {
                if (textureSetting.textureData == intList1[index3])
                {
                  flag = true;
                  index2 = index3;
                }
              }
              if (!flag)
              {
                textureOffset.name = this.solidTextureBytes.Count.ToString("x");
                textureOffset.offset = Convert.ToInt32(textureOffset.name, 16);
                intList1.Add(textureSetting.textureData);
                intList2.Add(textureOffset.offset);
                for (int index3 = 0; index3 < textureOffset.size; ++index3)
                  this.solidTextureBytes.Add(numArray[index3]);
              }
              else
              {
                textureOffset.name = intList2[index2].ToString("x") + "ts:" + this.triangleGLs[index1].textureSetting.ToString("x");
                textureOffset.offset = intList2[index2];
              }
              textureSetting.name = textureOffset.name;
              textureSetting.processed = true;
            }
            catch (Exception ex)
            {
            }
          }
          else
          {
            for (int index2 = 0; index2 < this.TextureSettings.Count; ++index2)
            {
              if (this.TextureSettings[index2].textureData == -1)
                this.TextureSettings[index2].processed = true;
            }
            textureSetting.processed = true;
          }
          this.textureNames.Add(textureOffset.name);
          this.textureOffsets.Add(textureOffset);
        }
      }
    }

    public void calculateTextureOffsetsAlpha()
    {
      List<int> intList1 = new List<int>();
      List<int> intList2 = new List<int>();
      for (int index1 = 0; index1 < this.triangleGLAlphas.Count<TriangleGL>(); ++index1)
      {
        TextureSetting textureSetting1 = this.TextureSettingsAlpha[this.triangleGLAlphas[index1].textureSetting];
        byte[] numArray = new byte[4];
        if (textureSetting1.textureData != -1)
          numArray = this.TextureDataAlphaList[textureSetting1.textureData].n64;
        if (!textureSetting1.processed)
        {
          int textureSetting2 = this.triangleGLAlphas[index1].textureSetting;
          int num = textureSetting1.palSize != 256 ? 32 + textureSetting1.width * textureSetting1.height / 2 : 512 + textureSetting1.width * textureSetting1.height;
          if (textureSetting1.palSize == 0)
            num = 0;
          TextureOffset textureOffset = new TextureOffset();
          textureOffset.size = num;
          textureOffset.width = textureSetting1.width;
          textureOffset.height = textureSetting1.height;
          textureOffset.cms = textureSetting1.cms;
          textureOffset.cmt = textureSetting1.cmt;
          textureOffset.palSize = textureSetting1.palSize;
          if (textureSetting1.width != 0)
          {
            try
            {
              bool flag = false;
              int index2 = 0;
              for (int index3 = 0; index3 < intList1.Count && !flag; ++index3)
              {
                if (textureSetting1.textureData == intList1[index3])
                {
                  flag = true;
                  index2 = index3;
                }
              }
              if (!flag)
              {
                textureOffset.name = this.alphaTextureBytes.Count.ToString("x");
                textureOffset.offset = Convert.ToInt32(textureOffset.name, 16);
                intList1.Add(textureSetting1.textureData);
                intList2.Add(textureOffset.offset);
                for (int index3 = 0; index3 < textureOffset.size; ++index3)
                  this.alphaTextureBytes.Add(numArray[index3]);
              }
              else
              {
                textureOffset.name = intList2[index2].ToString("x") + "ts:" + this.triangleGLAlphas[index1].textureSetting.ToString("x");
                textureOffset.offset = intList2[index2];
              }
              textureSetting1.name = textureOffset.name;
              textureSetting1.processed = true;
            }
            catch (Exception ex)
            {
            }
          }
          else
          {
            for (int index2 = 0; index2 < this.TextureSettingsAlpha.Count; ++index2)
            {
              if (this.TextureSettingsAlpha[index2].textureData == -1)
                this.TextureSettingsAlpha[index2].processed = true;
            }
            textureSetting1.processed = true;
          }
          this.alphaTextureNames.Add(textureOffset.name);
          this.alphaTextureOffsets.Add(textureOffset);
        }
      }
    }

    public void ConfigureVertsAndVTX()
    {
      try
      {
        this.VTXCommands.Add(new byte[8]
        {
          (byte) 4,
          (byte) 0,
          (byte) 129,
          byte.MaxValue,
          (byte) 1,
          (byte) 0,
          (byte) 0,
          (byte) 0
        });
        this.VTXLocations.Add(0);
        int index1 = 0;
        string name1 = this.TextureSettings[this.triangleGLs[0].textureSetting].name;
        this.textureLocations.Add(0);
        int cullMode = this.TextureSettings[this.triangleGLs[0].textureSetting].getCullMode();
        this.textureOrder.Add(this.TextureSettings[this.triangleGLs[0].textureSetting].name);
        string name2 = this.TextureSettings[this.triangleGLs[0].textureSetting].name;
        int num1 = 0;
        for (int index2 = 0; index2 < this.triangleGLs.Count; ++index2)
        {
          TextureSetting textureSetting = this.TextureSettings[this.triangleGLs[index2].textureSetting];
          if (textureSetting.name != name1 || textureSetting.getCullMode() != cullMode)
          {
            this.textureLocations.Add(index2);
            this.textureOrder.Add(textureSetting.name);
            name1 = textureSetting.name;
            int num2 = index2 * 3 * 16;
            byte[] numArray = new byte[8]
            {
              (byte) 4,
              (byte) 0,
              (byte) 129,
              byte.MaxValue,
              (byte) 1,
              (byte) (num2 >> 16),
              (byte) (num2 >> 8),
              (byte) num2
            };
            num1 = 0;
            this.VTXCommands.Add(numArray);
            this.VTXLocations.Add(index2);
            ++index1;
            cullMode = textureSetting.getCullMode();
          }
          byte[] vtxCommand = this.VTXCommands[index1];
          int num3 = ((int) vtxCommand[2] >> 2) + ((int) vtxCommand[5] * 65536 + (int) vtxCommand[6] * 256 + (int) vtxCommand[7]) / 16;
          if (num1 * 3 + 3 < 30)
          {
            string name3 = textureSetting.name;
            ++num1;
          }
          else
          {
            int num2 = index2 * 3 * 16;
            this.VTXCommands.Add(new byte[8]
            {
              (byte) 4,
              (byte) 0,
              (byte) 129,
              byte.MaxValue,
              (byte) 1,
              (byte) (num2 >> 16),
              (byte) (num2 >> 8),
              (byte) num2
            });
            this.VTXLocations.Add(index2);
            ++index1;
            num1 = 0;
          }
        }
        byte[] vtxCommand1 = this.VTXCommands[this.VTXCommands.Count - 1];
        int num4 = ((int) vtxCommand1[5] * 65536 + (int) vtxCommand1[6] * 256 + (int) vtxCommand1[7]) / 16;
        if (num4 - this.triangleGLs.Count<TriangleGL>() * 3 > 0)
          return;
        this.vertsToMake = this.triangleGLs.Count<TriangleGL>() * 3 - num4;
        this.vertsToMake = 32 - this.vertsToMake;
      }
      catch (Exception ex)
      {
      }
    }

    public void ConfigureAlphaVertsAndVTX()
    {
      try
      {
        this.AlphaVTXCommands.Add(new byte[8]
        {
          (byte) 4,
          (byte) 0,
          (byte) 129,
          byte.MaxValue,
          (byte) 1,
          (byte) 0,
          (byte) 0,
          (byte) 0
        });
        this.AlphaVTXLocations.Add(0);
        int index1 = 0;
        TextureSetting textureSetting1 = this.TextureSettingsAlpha[this.triangleGLAlphas[0].textureSetting];
        string name1 = textureSetting1.name;
        this.alphaTextureLocations.Add(0);
        int cullMode = textureSetting1.getCullMode();
        this.alphaTextureOrder.Add(textureSetting1.name);
        string name2 = textureSetting1.name;
        int num1 = 0;
        for (int index2 = 0; index2 < this.triangleGLAlphas.Count; ++index2)
        {
          TextureSetting textureSetting2 = this.TextureSettingsAlpha[this.triangleGLAlphas[index2].textureSetting];
          if (textureSetting2.name != name1 || textureSetting2.getCullMode() != cullMode)
          {
            this.alphaTextureLocations.Add(index2);
            this.alphaTextureOrder.Add(textureSetting2.name);
            name1 = textureSetting2.name;
            int num2 = index2 * 3 * 16;
            this.AlphaVTXCommands.Add(new byte[8]
            {
              (byte) 4,
              (byte) 0,
              (byte) 129,
              byte.MaxValue,
              (byte) 1,
              (byte) (num2 >> 16),
              (byte) (num2 >> 8),
              (byte) num2
            });
            this.AlphaVTXLocations.Add(index2);
            ++index1;
            num1 = 0;
            cullMode = textureSetting2.getCullMode();
          }
          byte[] alphaVtxCommand = this.AlphaVTXCommands[index1];
          int num3 = ((int) alphaVtxCommand[2] >> 2) + ((int) alphaVtxCommand[5] * 65536 + (int) alphaVtxCommand[6] * 256 + (int) alphaVtxCommand[7]) / 16;
          if (num1 * 3 + 3 < 30)
          {
            string name3 = textureSetting2.name;
            ++num1;
          }
          else
          {
            int num2 = index2 * 3 * 16;
            this.AlphaVTXCommands.Add(new byte[8]
            {
              (byte) 4,
              (byte) 0,
              (byte) 129,
              byte.MaxValue,
              (byte) 1,
              (byte) (num2 >> 16),
              (byte) (num2 >> 8),
              (byte) num2
            });
            this.AlphaVTXLocations.Add(index2);
            ++index1;
            num1 = 0;
          }
        }
        byte[] alphaVtxCommand1 = this.AlphaVTXCommands[this.AlphaVTXCommands.Count - 1];
        int num4 = ((int) alphaVtxCommand1[5] * 65536 + (int) alphaVtxCommand1[6] * 256 + (int) alphaVtxCommand1[7]) / 16;
        if (num4 - this.triangleGLAlphas.Count<TriangleGL>() * 3 > 0)
          return;
        this.alphaVertsToMake = this.triangleGLAlphas.Count<TriangleGL>() * 3 - num4;
        this.alphaVertsToMake = 32 - this.alphaVertsToMake;
      }
      catch (Exception ex)
      {
      }
    }

    public static bool LineIntersectsRect(Point p1, Point p2, Rectangle r)
    {
      if (r.Y >= 0 && r.X >= 0 && (r.Height >= 0 && r.Width >= 0) && (r.X < p1.X && r.Width > p1.X && (r.Y < p1.Y && r.Height > p1.Y) || r.X < p2.X && r.Width > p2.X && (r.Y < p2.Y && r.Height > p2.Y)) || r.Y >= 0 && r.X <= 0 && r.Height > 0 && (r.X > p1.X && r.Width < p1.X && (r.Y < p1.Y && r.Height > p1.Y) || r.X > p2.X && r.Width < p2.X && (r.Y < p2.Y && r.Height > p2.Y)) || (r.Y >= 0 && r.X >= 0 && (r.Height < 0 && r.Width >= 0) && (r.X < p1.X && r.Width > p1.X && (r.Y > p1.Y && r.Height < p1.Y) || r.X < p2.X && r.Width > p2.X && (r.Y > p2.Y && r.Height < p2.Y)) || r.Y >= 0 && r.X < 0 && r.Height > 0 && (r.X > p1.X && r.Width < p1.X && (r.Y < p1.Y && r.Height > p1.Y) || r.X > p2.X && r.Width < p2.X && (r.Y < p2.Y && r.Height > p2.Y))) || (r.Y >= 0 && r.X < 0 && r.Height < 0 && (r.X > p1.X && r.Width < p1.X && (r.Y > p1.Y && r.Height < p1.Y) || r.X > p2.X && r.Width < p2.X && (r.Y > p2.Y && r.Height < p2.Y)) || r.Y < 0 && r.X >= 0 && r.Width > 0 && (r.X < p1.X && r.Width > p1.X && (r.Y > p1.Y && r.Height < p1.Y) || r.X < p2.X && r.Width > p2.X && (r.Y > p2.Y && r.Height < p2.Y)) || (r.Y < 0 && r.X >= 0 && r.Width < 0 && (r.X > p1.X && r.Width < p1.X && (r.Y > p1.Y && r.Height < p1.Y) || r.X > p2.X && r.Width < p2.X && (r.Y > p2.Y && r.Height < p2.Y)) || r.Y < 0 && r.X < 0 && (r.Width < 0 && r.Height < 0) && (r.X > p1.X && r.Width < p1.X && (r.Y > p1.Y && r.Height < p1.Y) || r.X > p2.X && r.Width < p2.X && (r.Y > p2.Y && r.Height < p2.Y)))) || (r.Y < 0 && r.X < 0 && (r.Width > 0 && r.Height < 0) && (r.X < p1.X && r.X + r.Width > p1.X && (r.Y > p1.Y && r.Height < p1.Y) || r.X < p2.X && r.X + r.Width > p2.X && (r.Y > p2.Y && r.Height < p2.Y)) || r.Y < 0 && r.X < 0 && (r.Width < 0 && r.Height > 0) && (r.X > p1.X && r.Width < p1.X && (r.Y < p1.Y && r.Y + r.Height > p1.Y) || r.X > p2.X && r.Width < p2.X && (r.Y < p2.Y && r.Y + r.Height > p2.Y)) || (ModelImportForm.LineIntersectsLine(p1, p2, new Point(r.X, r.Y), new Point(r.X + r.Width, r.Y)) || ModelImportForm.LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y), new Point(r.X + r.Width, r.Y + r.Height)) || (ModelImportForm.LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y + r.Height), new Point(r.X, r.Y + r.Height)) || ModelImportForm.LineIntersectsLine(p1, p2, new Point(r.X, r.Y + r.Height), new Point(r.X, r.Y))))))
        return true;
      return r.Contains(p1) && r.Contains(p2);
    }

    private static bool LineIntersectsLine(Point l1p1, Point l1p2, Point l2p1, Point l2p2)
    {
      float num1 = (float) ((l1p1.Y - l2p1.Y) * (l2p2.X - l2p1.X) - (l1p1.X - l2p1.X) * (l2p2.Y - l2p1.Y));
      float num2 = (float) ((l1p2.X - l1p1.X) * (l2p2.Y - l2p1.Y) - (l1p2.Y - l1p1.Y) * (l2p2.X - l2p1.X));
      if ((double) num2 == 0.0)
        return false;
      float num3 = num1 / num2;
      float num4 = (float) ((l1p1.Y - l2p1.Y) * (l1p2.X - l1p1.X) - (l1p1.X - l2p1.X) * (l1p2.Y - l1p1.Y)) / num2;
      return (double) num3 >= 0.0 && (double) num3 <= 1.0 && ((double) num4 >= 0.0 && (double) num4 <= 1.0);
    }

    public byte[] CreateCollisionDataSolidAdvanced(ref List<TriangleGL> tris)
    {
      int num1 = int.MaxValue;
      int num2 = int.MaxValue;
      int num3 = int.MaxValue;
      int num4 = int.MinValue;
      int num5 = int.MinValue;
      int num6 = int.MinValue;
      for (int index = 0; index < tris.Count; ++index)
      {
        if ((int) tris[index].verts[0].x < num1)
          num1 = (int) tris[index].verts[0].x;
        if ((int) tris[index].verts[1].x < num1)
          num1 = (int) tris[index].verts[1].x;
        if ((int) tris[index].verts[2].x < num1)
          num1 = (int) tris[index].verts[2].x;
        if ((int) tris[index].verts[0].y < num2)
          num2 = (int) tris[index].verts[0].y;
        if ((int) tris[index].verts[1].y < num2)
          num2 = (int) tris[index].verts[1].y;
        if ((int) tris[index].verts[2].y < num2)
          num2 = (int) tris[index].verts[2].y;
        if ((int) tris[index].verts[0].z < num3)
          num3 = (int) tris[index].verts[0].z;
        if ((int) tris[index].verts[1].z < num3)
          num3 = (int) tris[index].verts[1].z;
        if ((int) tris[index].verts[2].z < num3)
          num3 = (int) tris[index].verts[2].z;
        if ((int) tris[index].verts[0].x > num4)
          num4 = (int) tris[index].verts[0].x;
        if ((int) tris[index].verts[1].x > num4)
          num4 = (int) tris[index].verts[1].x;
        if ((int) tris[index].verts[2].x > num4)
          num4 = (int) tris[index].verts[2].x;
        if ((int) tris[index].verts[0].y > num5)
          num5 = (int) tris[index].verts[0].y;
        if ((int) tris[index].verts[1].y > num5)
          num5 = (int) tris[index].verts[1].y;
        if ((int) tris[index].verts[2].y > num5)
          num5 = (int) tris[index].verts[2].y;
        if ((int) tris[index].verts[0].z > num6)
          num6 = (int) tris[index].verts[0].z;
        if ((int) tris[index].verts[1].z > num6)
          num6 = (int) tris[index].verts[1].z;
        if ((int) tris[index].verts[2].z > num6)
          num6 = (int) tris[index].verts[2].z;
      }
      int num7 = 0;
      int num8 = 10000000;
      int num9 = 0;
      int num10 = 0;
      int num11 = 0;
      int num12 = 0;
      int num13 = 0;
      int num14 = 0;
      int num15;
      int num16;
      int num17;
      for (; num8 > 1000 && num7 != 10000; num8 = num16 * num17 * num15)
      {
        num7 += 1000;
        num9 = num1 / num7;
        if (num1 % num7 != 0)
          --num9;
        num11 = num2 / num7;
        if (num2 % num7 != 0)
          --num11;
        num13 = num3 / num7;
        if (num3 % num7 != 0)
          --num13;
        num10 = num4 / num7;
        num12 = num5 / num7;
        num14 = num6 / num7;
        num16 = Math.Abs(num9) + num10 + 1;
        int num18 = Math.Abs(num11) + num12 + 1;
        num15 = Math.Abs(num13) + num14 + 1;
        num17 = num18;
      }
      List<byte> byteList = new List<byte>();
      byte[] byteArray1 = this.Int16ToByteArray((short) num9);
      byte[] byteArray2 = this.Int16ToByteArray((short) num11);
      byte[] byteArray3 = this.Int16ToByteArray((short) num13);
      byte[] byteArray4 = this.Int16ToByteArray((short) num10);
      byte[] byteArray5 = this.Int16ToByteArray((short) num12);
      byte[] byteArray6 = this.Int16ToByteArray((short) num14);
      byteList.Add(byteArray1[0]);
      byteList.Add(byteArray1[1]);
      byteList.Add(byteArray2[0]);
      byteList.Add(byteArray2[1]);
      byteList.Add(byteArray3[0]);
      byteList.Add(byteArray3[1]);
      byteList.Add(byteArray4[0]);
      byteList.Add(byteArray4[1]);
      byteList.Add(byteArray5[0]);
      byteList.Add(byteArray5[1]);
      byteList.Add(byteArray6[0]);
      byteList.Add(byteArray6[1]);
      byteList.Add((byte) 0);
      byteList.Add((byte) 4);
      byteList.Add((byte) 0);
      byteList.Add((byte) 4);
      byteList.Add((byte) 0);
      byteList.Add((byte) 16);
      byteList.Add((byte) (num7 >> 8));
      byteList.Add((byte) num7);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      byteList.Add((byte) 0);
      ArrayList arrayList1 = new ArrayList();
      ArrayList arrayList2 = new ArrayList();
      int num19 = Math.Abs(num9) + num10 + 1;
      if (num9 > 0)
        num19 = num10 - num9 + 1;
      int num20 = Math.Abs(num11) + num12 + 1;
      if (num11 > 0)
        num20 = num12 - num11 + 1;
      int num21 = Math.Abs(num13) + num14 + 1;
      if (num13 > 0)
        num21 = num14 - num13 + 1;
      for (int index1 = 0; index1 < num21; ++index1)
      {
        for (int index2 = 0; index2 < num20; ++index2)
        {
          for (int index3 = 0; index3 < num19; ++index3)
          {
            List<bool> boolList = new List<bool>();
            int num18 = (num9 + index3) * num7;
            int num22 = (num11 + index2) * num7;
            int num23 = (num13 + index1) * num7;
            int num24 = num7 / 2;
            int num25 = num18 + num24;
            int num26 = num22 + num7 / 2;
            int num27 = num23 + num7 / 2;
            for (int index4 = 0; index4 < tris.Count; ++index4)
            {
              if (!this.isectboxtri(new float[3]
              {
                (float) num25,
                (float) num26,
                (float) num27
              }, new float[3]
              {
                (float) (num7 / 2),
                (float) (num7 / 2),
                (float) (num7 / 2)
              }, new float[3][]
              {
                new float[3]
                {
                  (float) tris[index4].verts[0].x,
                  (float) tris[index4].verts[0].y,
                  (float) tris[index4].verts[0].z
                },
                new float[3]
                {
                  (float) tris[index4].verts[1].x,
                  (float) tris[index4].verts[1].y,
                  (float) tris[index4].verts[1].z
                },
                new float[3]
                {
                  (float) tris[index4].verts[2].x,
                  (float) tris[index4].verts[2].y,
                  (float) tris[index4].verts[2].z
                }
              }))
                boolList.Add(false);
              else
                boolList.Add(true);
            }
            arrayList2.Add((object) boolList);
          }
        }
      }
      List<int> source = new List<int>();
      List<byte> collision = new List<byte>();
      for (int index = 0; index < arrayList2.Count; ++index)
      {
        int num18 = this.CalcColGroup((List<bool>) arrayList2[index], tris, ref collision);
        source.Add(num18);
      }
      int num28 = 0;
      for (int index = 0; index < source.Count; ++index)
      {
        byteList.Add((byte) (num28 >> 8));
        byteList.Add((byte) num28);
        byteList.Add((byte) (source[index] >> 8));
        byteList.Add((byte) source[index]);
        num28 += source[index];
      }
      byteList[12] = (byte) (num19 >> 8);
      byteList[13] = (byte) num19;
      short num29 = (short) (num19 * num20);
      byteList[14] = (byte) ((uint) num29 >> 8);
      byteList[15] = (byte) num29;
      byteList[16] = (byte) (source.Count<int>() >> 8);
      byteList[17] = (byte) source.Count<int>();
      byteList[16] = (byte) (source.Count<int>() >> 8);
      byteList[17] = (byte) source.Count<int>();
      byteList[20] = (byte) (num28 >> 8);
      byteList[21] = (byte) num28;
      byteList.AddRange((IEnumerable<byte>) collision.ToArray());
      return byteList.ToArray();
    }

    public byte[] CreateCollisionDataSolid16()
    {
      byte[] collision = new byte[300000];
      int index1 = 0;
      collision[index1] = byte.MaxValue;
      collision[index1 + 1] = (byte) 254;
      collision[index1 + 2] = (byte) 0;
      collision[index1 + 3] = (byte) 0;
      collision[index1 + 4] = byte.MaxValue;
      collision[index1 + 5] = (byte) 254;
      collision[index1 + 6] = (byte) 0;
      collision[index1 + 7] = (byte) 1;
      collision[index1 + 8] = (byte) 0;
      collision[index1 + 9] = (byte) 0;
      collision[index1 + 10] = (byte) 0;
      collision[index1 + 11] = (byte) 1;
      collision[index1 + 12] = (byte) 0;
      collision[index1 + 13] = (byte) 4;
      collision[index1 + 14] = (byte) 0;
      collision[index1 + 15] = (byte) 4;
      collision[index1 + 16] = (byte) 0;
      collision[index1 + 17] = (byte) 16;
      collision[index1 + 18] = (byte) 9;
      collision[index1 + 19] = (byte) 196;
      collision[index1 + 20] = (byte) 0;
      collision[index1 + 21] = (byte) 96;
      int index2 = index1 + 24;
      collision[index2] = (byte) 0;
      collision[index2 + 1] = (byte) 0;
      collision[index2 + 2] = (byte) (this.triangleGLs.Count >> 8);
      collision[index2 + 3] = (byte) this.triangleGLs.Count;
      int collisionLoc = 88;
      List<TriangleGL> triangles1 = new List<TriangleGL>();
      List<TriangleGL> triangles2 = new List<TriangleGL>();
      List<TriangleGL> triangles3 = new List<TriangleGL>();
      List<TriangleGL> triangles4 = new List<TriangleGL>();
      List<TriangleGL> triangles5 = new List<TriangleGL>();
      List<TriangleGL> triangles6 = new List<TriangleGL>();
      List<TriangleGL> triangles7 = new List<TriangleGL>();
      List<TriangleGL> triangles8 = new List<TriangleGL>();
      List<TriangleGL> triangles9 = new List<TriangleGL>();
      List<TriangleGL> triangles10 = new List<TriangleGL>();
      List<TriangleGL> triangles11 = new List<TriangleGL>();
      List<TriangleGL> triangles12 = new List<TriangleGL>();
      List<TriangleGL> triangles13 = new List<TriangleGL>();
      List<TriangleGL> triangles14 = new List<TriangleGL>();
      List<TriangleGL> triangles15 = new List<TriangleGL>();
      List<TriangleGL> triangles16 = new List<TriangleGL>();
      List<int> intList1 = new List<int>();
      List<int> intList2 = new List<int>();
      List<int> intList3 = new List<int>();
      List<int> intList4 = new List<int>();
      for (int index3 = 0; index3 < this.triangleGLs.Count; ++index3)
      {
        triangles1.Add(this.triangleGLs[index3]);
        triangles2.Add(this.triangleGLs[index3]);
        triangles3.Add(this.triangleGLs[index3]);
        triangles4.Add(this.triangleGLs[index3]);
        triangles5.Add(this.triangleGLs[index3]);
        triangles6.Add(this.triangleGLs[index3]);
        triangles7.Add(this.triangleGLs[index3]);
        triangles8.Add(this.triangleGLs[index3]);
        triangles9.Add(this.triangleGLs[index3]);
        triangles10.Add(this.triangleGLs[index3]);
        triangles11.Add(this.triangleGLs[index3]);
        triangles12.Add(this.triangleGLs[index3]);
        triangles13.Add(this.triangleGLs[index3]);
        triangles14.Add(this.triangleGLs[index3]);
        triangles15.Add(this.triangleGLs[index3]);
        triangles16.Add(this.triangleGLs[index3]);
      }
      List<bool> remIndex1 = new List<bool>();
      List<bool> remIndex2 = new List<bool>();
      List<bool> remIndex3 = new List<bool>();
      List<bool> remIndex4 = new List<bool>();
      List<bool> remIndex5 = new List<bool>();
      List<bool> remIndex6 = new List<bool>();
      List<bool> remIndex7 = new List<bool>();
      List<bool> remIndex8 = new List<bool>();
      List<bool> remIndex9 = new List<bool>();
      List<bool> remIndex10 = new List<bool>();
      List<bool> remIndex11 = new List<bool>();
      List<bool> remIndex12 = new List<bool>();
      List<bool> remIndex13 = new List<bool>();
      List<bool> remIndex14 = new List<bool>();
      List<bool> remIndex15 = new List<bool>();
      List<bool> remIndex16 = new List<bool>();
      Rectangle rectangle1 = new Rectangle(-2500, -2500, -32767, -32767);
      Rectangle rectangle2 = new Rectangle(-2500, -2500, 2500, -32767);
      Rectangle rectangle3 = new Rectangle(0, -2500, 2500, -32767);
      Rectangle rectangle4 = new Rectangle(2500, -2500, (int) short.MaxValue, -32767);
      Rectangle rectangle5 = new Rectangle(-2500, 0, -32767, -2500);
      Rectangle rectangle6 = new Rectangle(-2500, -2500, 2500, 2500);
      Rectangle rectangle7 = new Rectangle(0, 0, 2500, -2500);
      Rectangle rectangle8 = new Rectangle(2500, 0, (int) short.MaxValue, -2500);
      Rectangle rectangle9 = new Rectangle(-2500, 0, -32767, 2500);
      Rectangle rectangle10 = new Rectangle(-2500, 0, 2500, 2500);
      Rectangle rectangle11 = new Rectangle(0, 0, 2500, 2500);
      Rectangle rectangle12 = new Rectangle(2500, 0, (int) short.MaxValue, 2500);
      Rectangle rectangle13 = new Rectangle(-2500, 2500, -32767, (int) short.MaxValue);
      Rectangle rectangle14 = new Rectangle(-2500, 2500, 2500, (int) short.MaxValue);
      Rectangle rectangle15 = new Rectangle(0, 2500, 2500, (int) short.MaxValue);
      Rectangle rectangle16 = new Rectangle(2500, 2500, (int) short.MaxValue, (int) short.MaxValue);
      int index4 = 0;
      for (int index3 = 0; index3 < triangles1.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles1[index3].verts[index4].x, (int) triangles1[index3].verts[index4].z);
        Point point = new Point((int) triangles1[index3].verts[index4 + 1].x, (int) triangles1[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle1;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles1[index3].verts[index4].x, (int) triangles1[index3].verts[index4].z);
          point = new Point((int) triangles1[index3].verts[index4 + 2].x, (int) triangles1[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle1;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles1[index3].verts[index4 + 1].x, (int) triangles1[index3].verts[index4 + 1].z);
          point = new Point((int) triangles1[index3].verts[index4 + 2].x, (int) triangles1[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle1;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex1.Add(false);
        else
          remIndex1.Add(true);
      }
      for (int index3 = 0; index3 < triangles2.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles2[index3].verts[index4].x, (int) triangles2[index3].verts[index4].z);
        Point point = new Point((int) triangles2[index3].verts[index4 + 1].x, (int) triangles2[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle2;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles2[index3].verts[index4].x, (int) triangles2[index3].verts[index4].z);
          point = new Point((int) triangles2[index3].verts[index4 + 2].x, (int) triangles2[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle2;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles2[index3].verts[index4 + 1].x, (int) triangles2[index3].verts[index4 + 1].z);
          point = new Point((int) triangles2[index3].verts[index4 + 2].x, (int) triangles2[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle2;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex2.Add(false);
        else
          remIndex2.Add(true);
      }
      for (int index3 = 0; index3 < triangles3.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles3[index3].verts[index4].x, (int) triangles3[index3].verts[index4].z);
        Point point = new Point((int) triangles3[index3].verts[index4 + 1].x, (int) triangles3[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle3;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles3[index3].verts[index4].x, (int) triangles3[index3].verts[index4].z);
          point = new Point((int) triangles3[index3].verts[index4 + 2].x, (int) triangles3[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle3;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles3[index3].verts[index4 + 1].x, (int) triangles3[index3].verts[index4 + 1].z);
          point = new Point((int) triangles3[index3].verts[index4 + 2].x, (int) triangles3[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle3;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex3.Add(false);
        else
          remIndex3.Add(true);
      }
      for (int index3 = 0; index3 < triangles4.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles4[index3].verts[index4].x, (int) triangles4[index3].verts[index4].z);
        Point point = new Point((int) triangles4[index3].verts[index4 + 1].x, (int) triangles4[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle4;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles4[index3].verts[index4].x, (int) triangles4[index3].verts[index4].z);
          point = new Point((int) triangles4[index3].verts[index4 + 2].x, (int) triangles4[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle4;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles4[index3].verts[index4 + 1].x, (int) triangles4[index3].verts[index4 + 1].z);
          point = new Point((int) triangles4[index3].verts[index4 + 2].x, (int) triangles4[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle4;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex4.Add(false);
        else
          remIndex4.Add(true);
      }
      for (int index3 = 0; index3 < triangles5.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles5[index3].verts[index4].x, (int) triangles5[index3].verts[index4].z);
        Point point = new Point((int) triangles5[index3].verts[index4 + 1].x, (int) triangles5[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle5;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles5[index3].verts[index4].x, (int) triangles5[index3].verts[index4].z);
          point = new Point((int) triangles5[index3].verts[index4 + 2].x, (int) triangles5[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle5;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles5[index3].verts[index4 + 1].x, (int) triangles5[index3].verts[index4 + 1].z);
          point = new Point((int) triangles5[index3].verts[index4 + 2].x, (int) triangles5[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle5;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex5.Add(false);
        else
          remIndex5.Add(true);
      }
      for (int index3 = 0; index3 < triangles6.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles6[index3].verts[index4].x, (int) triangles6[index3].verts[index4].z);
        Point point = new Point((int) triangles6[index3].verts[index4 + 1].x, (int) triangles6[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle6;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles6[index3].verts[index4].x, (int) triangles6[index3].verts[index4].z);
          point = new Point((int) triangles6[index3].verts[index4 + 2].x, (int) triangles6[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle6;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles6[index3].verts[index4 + 1].x, (int) triangles6[index3].verts[index4 + 1].z);
          point = new Point((int) triangles6[index3].verts[index4 + 2].x, (int) triangles6[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle6;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex6.Add(false);
        else
          remIndex6.Add(true);
      }
      for (int index3 = 0; index3 < triangles7.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles7[index3].verts[index4].x, (int) triangles7[index3].verts[index4].z);
        Point point = new Point((int) triangles7[index3].verts[index4 + 1].x, (int) triangles7[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle7;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles7[index3].verts[index4].x, (int) triangles7[index3].verts[index4].z);
          point = new Point((int) triangles7[index3].verts[index4 + 2].x, (int) triangles7[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle7;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles7[index3].verts[index4 + 1].x, (int) triangles7[index3].verts[index4 + 1].z);
          point = new Point((int) triangles7[index3].verts[index4 + 2].x, (int) triangles7[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle7;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex7.Add(false);
        else
          remIndex7.Add(true);
      }
      for (int index3 = 0; index3 < triangles8.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles8[index3].verts[index4].x, (int) triangles8[index3].verts[index4].z);
        Point point = new Point((int) triangles8[index3].verts[index4 + 1].x, (int) triangles8[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle8;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles8[index3].verts[index4].x, (int) triangles8[index3].verts[index4].z);
          point = new Point((int) triangles8[index3].verts[index4 + 2].x, (int) triangles8[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle8;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles8[index3].verts[index4 + 1].x, (int) triangles8[index3].verts[index4 + 1].z);
          point = new Point((int) triangles8[index3].verts[index4 + 2].x, (int) triangles8[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle8;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex8.Add(false);
        else
          remIndex8.Add(true);
      }
      for (int index3 = 0; index3 < triangles9.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles9[index3].verts[index4].x, (int) triangles9[index3].verts[index4].z);
        Point point = new Point((int) triangles9[index3].verts[index4 + 1].x, (int) triangles9[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle9;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles9[index3].verts[index4].x, (int) triangles9[index3].verts[index4].z);
          point = new Point((int) triangles9[index3].verts[index4 + 2].x, (int) triangles9[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle9;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles9[index3].verts[index4 + 1].x, (int) triangles9[index3].verts[index4 + 1].z);
          point = new Point((int) triangles9[index3].verts[index4 + 2].x, (int) triangles9[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle9;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex9.Add(false);
        else
          remIndex9.Add(true);
      }
      for (int index3 = 0; index3 < triangles10.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles10[index3].verts[index4].x, (int) triangles10[index3].verts[index4].z);
        Point point = new Point((int) triangles10[index3].verts[index4 + 1].x, (int) triangles10[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle10;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles10[index3].verts[index4].x, (int) triangles10[index3].verts[index4].z);
          point = new Point((int) triangles10[index3].verts[index4 + 2].x, (int) triangles10[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle10;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles10[index3].verts[index4 + 1].x, (int) triangles10[index3].verts[index4 + 1].z);
          point = new Point((int) triangles10[index3].verts[index4 + 2].x, (int) triangles10[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle10;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex10.Add(false);
        else
          remIndex10.Add(true);
      }
      for (int index3 = 0; index3 < triangles11.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles11[index3].verts[index4].x, (int) triangles11[index3].verts[index4].z);
        Point point = new Point((int) triangles11[index3].verts[index4 + 1].x, (int) triangles11[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle11;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles11[index3].verts[index4].x, (int) triangles11[index3].verts[index4].z);
          point = new Point((int) triangles11[index3].verts[index4 + 2].x, (int) triangles11[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle11;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles11[index3].verts[index4 + 1].x, (int) triangles11[index3].verts[index4 + 1].z);
          point = new Point((int) triangles11[index3].verts[index4 + 2].x, (int) triangles11[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle11;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex11.Add(false);
        else
          remIndex11.Add(true);
      }
      for (int index3 = 0; index3 < triangles12.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles12[index3].verts[index4].x, (int) triangles12[index3].verts[index4].z);
        Point point = new Point((int) triangles12[index3].verts[index4 + 1].x, (int) triangles12[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle12;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles12[index3].verts[index4].x, (int) triangles12[index3].verts[index4].z);
          point = new Point((int) triangles12[index3].verts[index4 + 2].x, (int) triangles12[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle12;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles12[index3].verts[index4 + 1].x, (int) triangles12[index3].verts[index4 + 1].z);
          point = new Point((int) triangles12[index3].verts[index4 + 2].x, (int) triangles12[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle12;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex12.Add(false);
        else
          remIndex12.Add(true);
      }
      for (int index3 = 0; index3 < triangles13.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles13[index3].verts[index4].x, (int) triangles13[index3].verts[index4].z);
        Point point = new Point((int) triangles13[index3].verts[index4 + 1].x, (int) triangles13[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle13;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles13[index3].verts[index4].x, (int) triangles13[index3].verts[index4].z);
          point = new Point((int) triangles13[index3].verts[index4 + 2].x, (int) triangles13[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle13;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles13[index3].verts[index4 + 1].x, (int) triangles13[index3].verts[index4 + 1].z);
          point = new Point((int) triangles13[index3].verts[index4 + 2].x, (int) triangles13[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle13;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex13.Add(false);
        else
          remIndex13.Add(true);
      }
      for (int index3 = 0; index3 < triangles14.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles14[index3].verts[index4].x, (int) triangles14[index3].verts[index4].z);
        Point point = new Point((int) triangles14[index3].verts[index4 + 1].x, (int) triangles14[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle14;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles14[index3].verts[index4].x, (int) triangles14[index3].verts[index4].z);
          point = new Point((int) triangles14[index3].verts[index4 + 2].x, (int) triangles14[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle14;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles14[index3].verts[index4 + 1].x, (int) triangles14[index3].verts[index4 + 1].z);
          point = new Point((int) triangles14[index3].verts[index4 + 2].x, (int) triangles14[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle14;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex14.Add(false);
        else
          remIndex14.Add(true);
      }
      for (int index3 = 0; index3 < triangles15.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles15[index3].verts[index4].x, (int) triangles15[index3].verts[index4].z);
        Point point = new Point((int) triangles15[index3].verts[index4 + 1].x, (int) triangles15[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle15;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles15[index3].verts[index4].x, (int) triangles15[index3].verts[index4].z);
          point = new Point((int) triangles15[index3].verts[index4 + 2].x, (int) triangles15[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle15;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles15[index3].verts[index4 + 1].x, (int) triangles15[index3].verts[index4 + 1].z);
          point = new Point((int) triangles15[index3].verts[index4 + 2].x, (int) triangles15[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle15;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex15.Add(false);
        else
          remIndex15.Add(true);
      }
      for (int index3 = 0; index3 < triangles16.Count; ++index3)
      {
        Point p1_1 = new Point((int) triangles16[index3].verts[index4].x, (int) triangles16[index3].verts[index4].z);
        Point point = new Point((int) triangles16[index3].verts[index4 + 1].x, (int) triangles16[index3].verts[index4 + 1].z);
        Point p2_1 = point;
        Rectangle r1 = rectangle16;
        bool flag = ModelImportForm.LineIntersectsRect(p1_1, p2_1, r1);
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles16[index3].verts[index4].x, (int) triangles16[index3].verts[index4].z);
          point = new Point((int) triangles16[index3].verts[index4 + 2].x, (int) triangles16[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle16;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
        {
          Point p1_2 = new Point((int) triangles16[index3].verts[index4 + 1].x, (int) triangles16[index3].verts[index4 + 1].z);
          point = new Point((int) triangles16[index3].verts[index4 + 2].x, (int) triangles16[index3].verts[index4 + 2].z);
          Point p2_2 = point;
          Rectangle r2 = rectangle16;
          flag = ModelImportForm.LineIntersectsRect(p1_2, p2_2, r2);
        }
        if (!flag)
          remIndex16.Add(false);
        else
          remIndex16.Add(true);
      }
      int num1 = this.CalcColGroup(remIndex1, triangles1, ref collision, ref collisionLoc);
      int num2 = this.CalcColGroup(remIndex2, triangles2, ref collision, ref collisionLoc);
      int num3 = this.CalcColGroup(remIndex3, triangles3, ref collision, ref collisionLoc);
      int num4 = this.CalcColGroup(remIndex4, triangles4, ref collision, ref collisionLoc);
      int num5 = this.CalcColGroup(remIndex5, triangles5, ref collision, ref collisionLoc);
      int num6 = this.CalcColGroup(remIndex6, triangles6, ref collision, ref collisionLoc);
      int num7 = this.CalcColGroup(remIndex7, triangles7, ref collision, ref collisionLoc);
      int num8 = this.CalcColGroup(remIndex8, triangles8, ref collision, ref collisionLoc);
      int num9 = this.CalcColGroup(remIndex9, triangles9, ref collision, ref collisionLoc);
      int num10 = this.CalcColGroup(remIndex10, triangles10, ref collision, ref collisionLoc);
      int num11 = this.CalcColGroup(remIndex11, triangles11, ref collision, ref collisionLoc);
      int num12 = this.CalcColGroup(remIndex12, triangles12, ref collision, ref collisionLoc);
      int num13 = this.CalcColGroup(remIndex13, triangles13, ref collision, ref collisionLoc);
      int num14 = this.CalcColGroup(remIndex14, triangles14, ref collision, ref collisionLoc);
      int num15 = this.CalcColGroup(remIndex15, triangles15, ref collision, ref collisionLoc);
      int num16 = this.CalcColGroup(remIndex16, triangles16, ref collision, ref collisionLoc);
      collision[20] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 + num12 + num13 + num14 + num15 + num16 >> 8);
      collision[21] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 + num12 + num13 + num14 + num15 + num16);
      collision[26] = (byte) (num1 >> 8);
      collision[27] = (byte) num1;
      collision[28] = (byte) (num1 >> 8);
      collision[29] = (byte) num1;
      collision[30] = (byte) (num2 >> 8);
      collision[31] = (byte) num2;
      collision[32] = (byte) (num2 + num1 >> 8);
      collision[33] = (byte) (num2 + num1);
      collision[34] = (byte) (num3 >> 8);
      collision[35] = (byte) num3;
      collision[36] = (byte) (num3 + num1 + num2 >> 8);
      collision[37] = (byte) (num3 + num1 + num2);
      collision[38] = (byte) (num4 >> 8);
      collision[39] = (byte) num4;
      collision[40] = (byte) (num3 + num1 + num2 + num4 >> 8);
      collision[41] = (byte) (num3 + num1 + num2 + num4);
      collision[42] = (byte) (num5 >> 8);
      collision[43] = (byte) num5;
      collision[44] = (byte) (num3 + num1 + num2 + num4 + num5 >> 8);
      collision[45] = (byte) (num3 + num1 + num2 + num4 + num5);
      collision[46] = (byte) (num6 >> 8);
      collision[47] = (byte) num6;
      collision[48] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 >> 8);
      collision[49] = (byte) (num3 + num1 + num2 + num4 + num5 + num6);
      collision[50] = (byte) (num7 >> 8);
      collision[51] = (byte) num7;
      collision[52] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 >> 8);
      collision[53] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7);
      collision[54] = (byte) (num8 >> 8);
      collision[55] = (byte) num8;
      collision[56] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 >> 8);
      collision[57] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8);
      collision[58] = (byte) (num9 >> 8);
      collision[59] = (byte) num9;
      collision[60] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 >> 8);
      collision[61] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9);
      collision[62] = (byte) (num10 >> 8);
      collision[63] = (byte) num10;
      collision[64] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 >> 8);
      collision[65] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10);
      collision[66] = (byte) (num11 >> 8);
      collision[67] = (byte) num11;
      collision[68] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 >> 8);
      collision[69] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11);
      collision[70] = (byte) (num12 >> 8);
      collision[71] = (byte) num12;
      collision[72] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 + num12 >> 8);
      collision[73] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 + num12);
      collision[74] = (byte) (num13 >> 8);
      collision[75] = (byte) num13;
      collision[76] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 + num12 + num13 >> 8);
      collision[77] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 + num12 + num13);
      collision[78] = (byte) (num14 >> 8);
      collision[79] = (byte) num14;
      collision[80] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 + num12 + num13 + num14 >> 8);
      collision[81] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 + num12 + num13 + num14);
      collision[82] = (byte) (num15 >> 8);
      collision[83] = (byte) num15;
      collision[84] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 + num12 + num13 + num14 + num15 >> 8);
      collision[85] = (byte) (num3 + num1 + num2 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11 + num12 + num13 + num14 + num15);
      collision[86] = (byte) (num16 >> 8);
      collision[87] = (byte) num16;
      byte[] numArray = new byte[collisionLoc];
      for (int index3 = 0; index3 < collisionLoc; ++index3)
        numArray[index3] = collision[index3];
      return numArray;
    }

    private int CalcColGroup(
      List<bool> remIndex,
      List<TriangleGL> triangles,
      ref List<byte> collision)
    {
      int num1 = 0;
      int num2 = 0;
      for (int index = 0; index < triangles.Count; ++index)
      {
        if (remIndex[index])
        {
          if (triangles[index].collisionType != CollisionType.NoCollision)
          {
            collision.Add((byte) (num2 >> 8));
            collision.Add((byte) num2);
            int num3 = num2 + 1;
            collision.Add((byte) (num3 >> 8));
            collision.Add((byte) num3);
            int num4 = num3 + 1;
            collision.Add((byte) (num4 >> 8));
            collision.Add((byte) num4);
            num2 = num4 + 1;
            collision.Add((byte) 0);
            collision.Add((byte) 0);
            if (triangles[index].collisionType != CollisionType.Water && triangles[index].collisionType != CollisionType.Water2)
            {
              collision.Add((byte) 136);
              collision.Add((byte) triangles[index].collisionType);
              collision.Add((byte) triangles[index].soundType);
              collision.Add((byte) triangles[index].groundType);
            }
            else
            {
              collision.Add((byte) 0);
              collision.Add((byte) triangles[index].collisionType);
              collision.Add((byte) 0);
              collision.Add((byte) 0);
            }
            ++num1;
          }
          else
            num2 += 3;
        }
        else
          num2 += 3;
      }
      return num1;
    }

    private int CalcColGroup(
      List<bool> remIndex,
      List<TriangleGL> triangles,
      ref byte[] collision,
      ref int collisionLoc)
    {
      int num1 = 0;
      int num2 = 0;
      for (int index = 0; index < triangles.Count; ++index)
      {
        if (remIndex[index])
        {
          if (triangles[index].collisionType != CollisionType.NoCollision)
          {
            collision[collisionLoc] = (byte) (num2 >> 8);
            collision[collisionLoc + 1] = (byte) num2;
            int num3 = num2 + 1;
            collision[collisionLoc + 2] = (byte) (num3 >> 8);
            collision[collisionLoc + 3] = (byte) num3;
            int num4 = num3 + 1;
            collision[collisionLoc + 4] = (byte) (num4 >> 8);
            collision[collisionLoc + 5] = (byte) num4;
            num2 = num4 + 1;
            collision[collisionLoc + 6] = (byte) 0;
            collision[collisionLoc + 7] = (byte) 0;
            collision[collisionLoc + 8] = (byte) 136;
            collision[collisionLoc + 9] = (byte) triangles[index].collisionType;
            collision[collisionLoc + 10] = (byte) triangles[index].soundType;
            collision[collisionLoc + 11] = (byte) triangles[index].groundType;
            if (triangles[index].collisionType == CollisionType.Water)
            {
              collision[collisionLoc + 8] = (byte) 0;
              collision[collisionLoc + 10] = (byte) 0;
              collision[collisionLoc + 11] = (byte) 0;
            }
            collisionLoc += 12;
            ++num1;
          }
          else
            num2 += 3;
        }
        else
          num2 += 3;
      }
      return num1;
    }

    public byte[] CreateCollisionDataSolid()
    {
      byte[] numArray1 = new byte[300000];
      int index1 = 0;
      numArray1[index1] = byte.MaxValue;
      numArray1[index1 + 1] = (byte) 254;
      numArray1[index1 + 2] = (byte) 0;
      numArray1[index1 + 3] = (byte) 0;
      numArray1[index1 + 4] = byte.MaxValue;
      numArray1[index1 + 5] = (byte) 254;
      numArray1[index1 + 6] = (byte) 0;
      numArray1[index1 + 7] = (byte) 1;
      numArray1[index1 + 8] = (byte) 0;
      numArray1[index1 + 9] = (byte) 0;
      numArray1[index1 + 10] = (byte) 0;
      numArray1[index1 + 11] = (byte) 1;
      numArray1[index1 + 12] = (byte) 0;
      numArray1[index1 + 13] = (byte) 4;
      numArray1[index1 + 14] = (byte) 0;
      numArray1[index1 + 15] = (byte) 4;
      numArray1[index1 + 16] = (byte) 0;
      numArray1[index1 + 17] = (byte) 1;
      numArray1[index1 + 18] = (byte) 0;
      numArray1[index1 + 19] = (byte) 0;
      int index2 = index1 + 24;
      numArray1[index2] = (byte) 0;
      numArray1[index2 + 1] = (byte) 0;
      int num1 = 0;
      for (int index3 = 0; index3 < this.triangleGLs.Count; ++index3)
      {
        if (this.triangleGLs[index3].collisionType != CollisionType.NoCollision)
          ++num1;
      }
      numArray1[20] = (byte) (num1 >> 8);
      numArray1[21] = (byte) num1;
      numArray1[index2 + 2] = (byte) (num1 >> 8);
      numArray1[index2 + 3] = (byte) num1;
      int length = index2 + 4;
      int num2 = 0;
      for (int index3 = 0; index3 < this.triangleGLs.Count; ++index3)
      {
        if (this.triangleGLs[index3].collisionType != CollisionType.NoCollision)
        {
          numArray1[length] = (byte) (num2 >> 8);
          numArray1[length + 1] = (byte) num2;
          int num3 = num2 + 1;
          numArray1[length + 2] = (byte) (num3 >> 8);
          numArray1[length + 3] = (byte) num3;
          int num4 = num3 + 1;
          numArray1[length + 4] = (byte) (num4 >> 8);
          numArray1[length + 5] = (byte) num4;
          num2 = num4 + 1;
          numArray1[length + 6] = (byte) 0;
          numArray1[length + 7] = (byte) 0;
          numArray1[length + 8] = (byte) 136;
          numArray1[length + 10] = (byte) this.triangleGLs[index3].soundType;
          numArray1[length + 9] = (byte) this.triangleGLs[index3].collisionType;
          numArray1[length + 11] = (byte) this.triangleGLs[index3].groundType;
          length += 12;
        }
        else
          num2 += 3;
      }
      byte[] numArray2 = new byte[length];
      for (int index3 = 0; index3 < length; ++index3)
        numArray2[index3] = numArray1[index3];
      return numArray2;
    }

    public byte[] CreateCollisionDataAlpha()
    {
      byte[] numArray1 = new byte[300000];
      int index1 = 0;
      numArray1[index1] = byte.MaxValue;
      numArray1[index1 + 1] = (byte) 254;
      numArray1[index1 + 2] = (byte) 0;
      numArray1[index1 + 3] = (byte) 0;
      numArray1[index1 + 4] = byte.MaxValue;
      numArray1[index1 + 5] = (byte) 254;
      numArray1[index1 + 6] = (byte) 0;
      numArray1[index1 + 7] = (byte) 1;
      numArray1[index1 + 8] = (byte) 0;
      numArray1[index1 + 9] = (byte) 0;
      numArray1[index1 + 10] = (byte) 0;
      numArray1[index1 + 11] = (byte) 1;
      numArray1[index1 + 12] = (byte) 0;
      numArray1[index1 + 13] = (byte) 4;
      numArray1[index1 + 14] = (byte) 0;
      numArray1[index1 + 15] = (byte) 4;
      numArray1[index1 + 16] = (byte) 0;
      numArray1[index1 + 17] = (byte) 1;
      numArray1[index1 + 18] = (byte) 0;
      numArray1[index1 + 19] = (byte) 0;
      numArray1[index1 + 20] = (byte) 0;
      numArray1[index1 + 21] = (byte) 96;
      int index2 = index1 + 24;
      numArray1[index2] = (byte) 0;
      numArray1[index2 + 1] = (byte) 0;
      numArray1[index2 + 2] = (byte) (this.triangleGLAlphas.Count >> 8);
      numArray1[index2 + 3] = (byte) this.triangleGLAlphas.Count;
      int length = index2 + 4;
      int num1 = 0;
      int num2 = 0;
      for (int index3 = 0; index3 < this.triangleGLAlphas.Count; ++index3)
      {
        if (this.triangleGLAlphas[index3].collisionType != CollisionType.NoCollision)
        {
          ++num1;
          numArray1[length] = (byte) (num2 >> 8);
          numArray1[length + 1] = (byte) num2;
          int num3 = num2 + 1;
          numArray1[length + 2] = (byte) (num3 >> 8);
          numArray1[length + 3] = (byte) num3;
          int num4 = num3 + 1;
          numArray1[length + 4] = (byte) (num4 >> 8);
          numArray1[length + 5] = (byte) num4;
          num2 = num4 + 1;
          numArray1[length + 6] = (byte) 0;
          numArray1[length + 7] = (byte) 0;
          numArray1[length + 8] = (byte) 136;
          numArray1[length + 10] = (byte) this.triangleGLAlphas[index3].soundType;
          numArray1[length + 11] = (byte) this.triangleGLAlphas[index3].groundType;
          if (this.triangleGLAlphas[index3].collisionType == CollisionType.Water)
          {
            numArray1[length + 8] = (byte) 0;
            numArray1[length + 10] = (byte) 0;
            numArray1[length + 11] = (byte) 0;
          }
          numArray1[length + 9] = (byte) this.triangleGLAlphas[index3].collisionType;
          length += 12;
        }
        else
          num2 += 3;
      }
      numArray1[20] = (byte) (num1 >> 8);
      numArray1[21] = (byte) num1;
      numArray1[26] = (byte) (num1 >> 8);
      numArray1[27] = (byte) num1;
      byte[] numArray2 = new byte[length];
      for (int index3 = 0; index3 < length; ++index3)
        numArray2[index3] = numArray1[index3];
      return numArray2;
    }

    private void scale_tb_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      if (!char.IsLetter(e.KeyChar) && !char.IsSymbol(e.KeyChar) && (!char.IsWhiteSpace(e.KeyChar) && !char.IsPunctuation(e.KeyChar)))
        return;
      e.Handled = true;
    }

    private void drawBanjo_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.drawBanjoToolStripMenuItem.Checked)
        this.showBanjo = true;
      else
        this.showBanjo = false;
    }

    private void banjo_rb_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.banjo_rb.Checked)
        return;
      this.camera_rb.Checked = false;
      this.banjoMode = true;
      this.triangleMode = false;
    }

    private void simpleOpenGlControl1_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.movingBanjoClick)
      {
        this.core.ClearScreenAndLoadIdentity();
        GL.PushMatrix();
        this.SetCameraView();
        this.Redraw();
        this.banjoLocation = this.core.screenToWorld(e.X - this.simpleOpenGlControl1.Location.X, e.Y, this.xrot, this.yrot, this.zrot);
        GL.PopMatrix();
      }
      if (this.rotateBanjoClick)
      {
        this.newEditX = e.X;
        this.newEditY = e.Y;
        int num = this.newEditX - this.oldEditX;
        this.oldEditX = this.newEditX;
        this.oldEditY = this.newEditY;
        this.banjoRotation += num;
      }
      if (!this.painting)
        return;
      this.pickVert(e.X, e.Y);
    }

    private void simpleOpenGlControl1_MouseLeave(object sender, EventArgs e)
    {
      this.RotateSceneClick = false;
      this.movingBanjoClick = false;
      this.rotateBanjoClick = false;
      this.painting = false;
    }

    private void camera_rb_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.camera_rb.Checked)
        return;
      this.banjo_rb.Checked = false;
      this.banjoMode = false;
      this.triangleMode = false;
    }

    private void ModelImportForm_MouseClick(object sender, MouseEventArgs e)
    {
      this.Focus();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.camera();
      this.simpleOpenGlControl1.Invalidate();
    }

    private void clearSelection_btn_Click(object sender, EventArgs e)
    {
      this.vertMode = false;
      Core.InitGl();
      this.RenderLevelWithSelection();
    }

    private void CamSpeed_tb_Scroll(object sender, EventArgs e)
    {
      this.speed = (double) (this.CamSpeed_tb.Value * 2);
    }

    private void save_btn_Click(object sender, EventArgs e)
    {
      if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        this.save(this.saveFileDialog1.FileName, false);
        int num = (int) MessageBox.Show(this.saveFileDialog1.FileName + " was successfully created");
      }
      this.forceRedraw = true;
    }

    private void saveAsObjectModelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        this.save(this.saveFileDialog1.FileName, true);
        int num = (int) MessageBox.Show(this.saveFileDialog1.FileName + " was successfully created");
      }
      this.forceRedraw = true;
    }

    private void numOnlyLocation_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      if (e.KeyChar == '\r')
      {
        this.simpleOpenGlControl1.Focus();
        e.Handled = true;
      }
      try
      {
        if (((IEnumerable<string>) new string[11]
        {
          "1",
          "2",
          "3",
          "4",
          "5",
          "6",
          "7",
          "8",
          "9",
          "0",
          "-"
        }).Contains<string>(e.KeyChar.ToString()) || e.KeyChar == '\b')
          return;
        e.Handled = true;
      }
      catch
      {
      }
    }

    private void numOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      try
      {
        if (!((IEnumerable<string>) new string[10]
        {
          "1",
          "2",
          "3",
          "4",
          "5",
          "6",
          "7",
          "8",
          "9",
          "0"
        }).Contains<string>(e.KeyChar.ToString()) && e.KeyChar != '\b')
          e.Handled = true;
        string str1 = this.red_tb.Text;
        string str2 = this.green_tb.Text;
        string str3 = this.blue_tb.Text;
        string str4 = this.alpha_tb.Text;
        if (this.red_tb.Text == "")
          str1 = "0";
        if (this.green_tb.Text == "")
          str2 = "0";
        if (this.blue_tb.Text == "")
          str3 = "0";
        if (this.alpha_tb.Text == "")
          str4 = "0";
        if (Convert.ToInt16(this.red_tb.Text) > (short) byte.MaxValue)
          this.red_tb.Text = "255";
        if (Convert.ToInt16(this.green_tb.Text) > (short) byte.MaxValue)
          this.green_tb.Text = "255";
        if (Convert.ToInt16(this.blue_tb.Text) > (short) byte.MaxValue)
          this.blue_tb.Text = "255";
        if (Convert.ToInt16(this.alpha_tb.Text) > (short) byte.MaxValue)
          this.alpha_tb.Text = "255";
        if (Convert.ToInt16(this.red_tb.Text) < (short) 0)
          str1 = "0";
        if (Convert.ToInt16(this.green_tb.Text) < (short) 0)
          str2 = "0";
        if (Convert.ToInt16(this.blue_tb.Text) < (short) 0)
          str3 = "0";
        if (Convert.ToInt16(this.alpha_tb.Text) < (short) 0)
          str4 = "0";
        this.pnlPreview.BackColor = Color.FromArgb((int) Convert.ToByte(str4), (int) Convert.ToByte(str1), (int) Convert.ToByte(str2), (int) Convert.ToByte(str3));
      }
      catch
      {
      }
    }

    private void floatOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      if (((IEnumerable<string>) new string[11]
      {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "0",
        "."
      }).Contains<string>(e.KeyChar.ToString()) || e.KeyChar == '\b')
        return;
      e.Handled = true;
    }

    private void colorPick_pbx_MouseDown(object sender, MouseEventArgs e)
    {
      this.isSelecting = true;
      this.colorPick_pbx_MouseMove(sender, e);
    }

    private void colorPick_pbx_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        if (!this.isSelecting)
          return;
        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(this.colorPick_pbx.Width, this.colorPick_pbx.Height);
        using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage((Image) bitmap))
        {
          graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
          graphics.DrawImage(this.colorPick_pbx.Image, 0, 0, bitmap.Width, bitmap.Height);
        }
        Color pixel = bitmap.GetPixel(e.X, e.Y);
        this.red_tb.Text = pixel.R.ToString();
        TextBox greenTb = this.green_tb;
        byte num = pixel.G;
        string str1 = num.ToString();
        greenTb.Text = str1;
        TextBox blueTb = this.blue_tb;
        num = pixel.B;
        string str2 = num.ToString();
        blueTb.Text = str2;
        this.pnlPreview.BackColor = pixel;
      }
      catch
      {
      }
    }

    private void colorPick_pbx_MouseUp(object sender, MouseEventArgs e)
    {
      this.isSelecting = false;
    }

    private void colorPick_pbx_MouseLeave(object sender, EventArgs e)
    {
      this.isSelecting = false;
    }

    private void scale_tbar_Scroll(object sender, EventArgs e)
    {
      this.scale_tb.Text = this.scale_tbar.Value.ToString();
      this.scale((float) this.scale_tbar.Value);
      this.forceRedraw = true;
    }

    private void vertUpdate_rb_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.vertUpdate_rb.Checked)
        return;
      this.triUpdate_rb.Checked = false;
      this.flipUpdate_rb.Checked = false;
      this.triUpdate = false;
      this.vertUpdate = true;
      this.flipUpdate = false;
    }

    private void triUpdate_rb_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.triUpdate_rb.Checked)
        return;
      this.vertUpdate_rb.Checked = false;
      this.flipUpdate_rb.Checked = false;
      this.vertUpdate = false;
      this.triUpdate = true;
      this.flipUpdate = false;
    }

    private void flipUpdate_rb_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.flipUpdate_rb.Checked)
        return;
      this.vertUpdate_rb.Checked = false;
      this.triUpdate_rb.Checked = false;
      this.vertUpdate = false;
      this.triUpdate = false;
      this.flipUpdate = true;
    }

    private void scale_tb_TextChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.scale_tb.Text != "")
        {
          this.scale(Convert.ToSingle(this.scale_tb.Text));
          int num = (int) Convert.ToSingle(this.scale_tb.Text);
          if (num < 1)
            num = 1;
          else if (num > 1000)
            num = 1000;
          this.scale_tbar.Value = num;
        }
        this.forceRedraw = true;
      }
      catch (Exception ex)
      {
      }
    }

    private void drawBanjoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.drawBanjoToolStripMenuItem.Checked = !this.drawBanjoToolStripMenuItem.Checked;
      this.forceRedraw = true;
    }

    private void drawEdgesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.drawEdges)
      {
        this.drawEdges = false;
        this.drawEdgesToolStripMenuItem.Checked = false;
      }
      else
      {
        this.drawEdges = true;
        this.drawEdgesToolStripMenuItem.Checked = true;
      }
      this.forceRedraw = true;
    }

    private void pal_MouseClick(object sender, MouseEventArgs e)
    {
      Panel panel = sender as Panel;
      if (e.Button == MouseButtons.Right)
      {
        Color color = Color.FromArgb((int) Convert.ToByte(this.alpha_tb.Text), (int) Convert.ToByte(this.red_tb.Text), (int) Convert.ToByte(this.green_tb.Text), (int) Convert.ToByte(this.blue_tb.Text));
        panel.BackColor = color;
      }
      else
      {
        Color backColor = panel.BackColor;
        TextBox redTb = this.red_tb;
        byte num = backColor.R;
        string str1 = num.ToString();
        redTb.Text = str1;
        TextBox greenTb = this.green_tb;
        num = backColor.G;
        string str2 = num.ToString();
        greenTb.Text = str2;
        TextBox blueTb = this.blue_tb;
        num = backColor.B;
        string str3 = num.ToString();
        blueTb.Text = str3;
        TextBox alphaTb = this.alpha_tb;
        num = backColor.A;
        string str4 = num.ToString();
        alphaTb.Text = str4;
        this.pnlPreview.BackColor = backColor;
      }
    }

    private void colour_tb_Leave(object sender, EventArgs e)
    {
      if (this.red_tb.Text == "")
        this.red_tb.Text = "0";
      if (this.green_tb.Text == "")
        this.green_tb.Text = "0";
      if (this.blue_tb.Text == "")
        this.blue_tb.Text = "0";
      if (this.alpha_tb.Text == "")
        this.alpha_tb.Text = "0";
      if (Convert.ToInt16(this.red_tb.Text) > (short) byte.MaxValue)
        this.red_tb.Text = "255";
      if (Convert.ToInt16(this.green_tb.Text) > (short) byte.MaxValue)
        this.green_tb.Text = "255";
      if (Convert.ToInt16(this.blue_tb.Text) > (short) byte.MaxValue)
        this.blue_tb.Text = "255";
      if (Convert.ToInt16(this.alpha_tb.Text) > (short) byte.MaxValue)
        this.alpha_tb.Text = "255";
      if (Convert.ToInt16(this.red_tb.Text) < (short) 0)
        this.red_tb.Text = "0";
      if (Convert.ToInt16(this.green_tb.Text) < (short) 0)
        this.red_tb.Text = "0";
      if (Convert.ToInt16(this.blue_tb.Text) < (short) 0)
        this.red_tb.Text = "0";
      if (Convert.ToInt16(this.alpha_tb.Text) < (short) 0)
        this.red_tb.Text = "0";
      this.pnlPreview.BackColor = Color.FromArgb((int) Convert.ToByte(this.alpha_tb.Text), (int) Convert.ToByte(this.red_tb.Text), (int) Convert.ToByte(this.green_tb.Text), (int) Convert.ToByte(this.blue_tb.Text));
    }

    private void moveToA_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.moveToA_cb.Checked)
        this.moveToAFile = true;
      else
        this.moveToAFile = false;
    }

    private void resetModelMovement(int axis)
    {
      float single = Convert.ToSingle(this.scale_tb.Text);
      for (int index1 = 0; index1 < this.triangleGLs.Count<TriangleGL>(); ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
          switch (axis)
          {
            case 0:
              this.triangleGLs[index1].verts[index2].x = (short) ((double) this.originalTriangleGLs[index1].verts[index2].x / (double) this.precision * (double) single);
              break;
            case 1:
              this.triangleGLs[index1].verts[index2].y = (short) ((double) this.originalTriangleGLs[index1].verts[index2].y / (double) this.precision * (double) single);
              break;
            case 2:
              this.triangleGLs[index1].verts[index2].z = (short) ((double) this.originalTriangleGLs[index1].verts[index2].z / (double) this.precision * (double) single);
              break;
          }
        }
      }
      for (int index1 = 0; index1 < this.triangleGLAlphas.Count<TriangleGL>(); ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
          switch (axis)
          {
            case 0:
              this.triangleGLAlphas[index1].verts[index2].x = (short) ((double) this.originalTriangleGLAlphas[index1].verts[index2].x / (double) this.precision * (double) single);
              break;
            case 1:
              this.triangleGLAlphas[index1].verts[index2].y = (short) ((double) this.originalTriangleGLAlphas[index1].verts[index2].y / (double) this.precision * (double) single);
              break;
            case 2:
              this.triangleGLAlphas[index1].verts[index2].z = (short) ((double) this.originalTriangleGLAlphas[index1].verts[index2].z / (double) this.precision * (double) single);
              break;
          }
        }
      }
    }

    private void moveModel(int axis)
    {
      float single = Convert.ToSingle(this.scale_tb.Text);
      bool flag = false;
      if (this.moveX_tb.Text == "" && axis == 0)
        flag = true;
      if (this.moveY_tb.Text == "" && axis == 1)
        flag = true;
      if (this.moveZ_tb.Text == "" && axis == 2)
        flag = true;
      if (flag)
        this.resetModelMovement(axis);
      short num = 0;
      try
      {
        switch (axis)
        {
          case 0:
            num = Convert.ToInt16(this.moveX_tb.Text);
            if (num > (short) 10000)
            {
              this.moveX_tb.Text = "10000";
              num = (short) 10000;
            }
            if (num < (short) -10000)
            {
              this.moveX_tb.Text = "-10000";
              num = (short) -10000;
              break;
            }
            break;
          case 1:
            num = Convert.ToInt16(this.moveY_tb.Text);
            if (num > (short) 10000)
            {
              this.moveY_tb.Text = "10000";
              num = (short) 10000;
            }
            if (num < (short) -10000)
            {
              this.moveY_tb.Text = "-10000";
              num = (short) -10000;
              break;
            }
            break;
          case 2:
            num = Convert.ToInt16(this.moveZ_tb.Text);
            if (num > (short) 10000)
            {
              this.moveZ_tb.Text = "10000";
              num = (short) 10000;
            }
            if (num < (short) -10000)
            {
              this.moveZ_tb.Text = "-10000";
              num = (short) -10000;
              break;
            }
            break;
        }
        for (int index1 = 0; index1 < this.triangleGLs.Count<TriangleGL>(); ++index1)
        {
          for (int index2 = 0; index2 < 3; ++index2)
          {
            switch (axis)
            {
              case 0:
                this.triangleGLs[index1].verts[index2].x = (short) ((double) num + (double) this.originalTriangleGLs[index1].verts[index2].x / (double) this.precision * (double) single);
                break;
              case 1:
                this.triangleGLs[index1].verts[index2].y = (short) ((double) num + (double) this.originalTriangleGLs[index1].verts[index2].y / (double) this.precision * (double) single);
                break;
              case 2:
                this.triangleGLs[index1].verts[index2].z = (short) ((double) num + (double) this.originalTriangleGLs[index1].verts[index2].z / (double) this.precision * (double) single);
                break;
            }
          }
        }
        for (int index1 = 0; index1 < this.triangleGLAlphas.Count<TriangleGL>(); ++index1)
        {
          for (int index2 = 0; index2 < 3; ++index2)
          {
            switch (axis)
            {
              case 0:
                this.triangleGLAlphas[index1].verts[index2].x = (short) ((double) num + (double) this.originalTriangleGLAlphas[index1].verts[index2].x / (double) this.precision * (double) single);
                break;
              case 1:
                this.triangleGLAlphas[index1].verts[index2].y = (short) ((double) num + (double) this.originalTriangleGLAlphas[index1].verts[index2].y / (double) this.precision * (double) single);
                break;
              case 2:
                this.triangleGLAlphas[index1].verts[index2].z = (short) ((double) num + (double) this.originalTriangleGLAlphas[index1].verts[index2].z / (double) this.precision * (double) single);
                break;
            }
          }
        }
      }
      catch
      {
        switch (axis)
        {
          case 0:
            this.moveX_tb.Text = "0";
            break;
          case 1:
            this.moveY_tb.Text = "0";
            break;
          case 2:
            this.moveZ_tb.Text = "0";
            break;
        }
        this.resetModelMovement(axis);
      }
      this.RenderPick();
      this.RenderLines();
      this.RenderLevelWithSelection();
      this.core.ClearScreenAndLoadIdentity();
    }

    private void moveX_tb_Leave(object sender, EventArgs e)
    {
      if (this.moveX_tb.Text == "")
        this.moveX_tb.Text = "0";
      this.moveModel(0);
      this.forceRedraw = true;
    }

    private void moveY_tb_Leave(object sender, EventArgs e)
    {
      if (this.moveY_tb.Text == "")
        this.moveY_tb.Text = "0";
      this.moveModel(1);
      this.forceRedraw = true;
    }

    private void moveZ_tb_Leave(object sender, EventArgs e)
    {
      if (this.moveZ_tb.Text == "")
        this.moveZ_tb.Text = "0";
      this.moveModel(2);
      this.forceRedraw = true;
    }

    private void drawCollisionMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.drawColMap)
      {
        this.drawColMap = true;
        this.drawSoundMap = false;
        this.drawSoundMapToolStripMenuItem.Checked = false;
        this.drawCollisionMapToolStripMenuItem.Checked = true;
      }
      else
      {
        this.drawColMap = false;
        this.drawCollisionMapToolStripMenuItem.Checked = false;
      }
      this.forceRedraw = true;
    }

    private void ModelImportForm_KeyUp(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.A:
          this.key_a = false;
          break;
        case Keys.D:
          this.key_d = false;
          break;
        case Keys.S:
          this.key_s = false;
          break;
        case Keys.W:
          this.key_w = false;
          break;
      }
    }

    private void colPick_btn_Click(object sender, EventArgs e)
    {
      if (this.colPickMode)
      {
        this.colPickMode = false;
        this.simpleOpenGlControl1.Cursor = Cursors.Default;
        this.colPick_btn.BackColor = SystemColors.Control;
      }
      else
      {
        this.colPickMode = true;
        this.simpleOpenGlControl1.Cursor = new Cursor("./resources/eyedrop.cur");
        this.colPick_btn.BackColor = SystemColors.ActiveCaption;
      }
    }

    private void simpleOpenGlControl1_SizeChanged(object sender, EventArgs e)
    {
      this.core.SetView(this.simpleOpenGlControl1.Height, this.simpleOpenGlControl1.Width);
    }

    private void flipV_btn_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.triangleGLs.Count; ++index)
      {
        this.triangleGLs[index].verts[0].v *= (short) -1;
        this.triangleGLs[index].verts[1].v *= (short) -1;
        this.triangleGLs[index].verts[2].v *= (short) -1;
      }
      for (int index = 0; index < this.triangleGLAlphas.Count; ++index)
      {
        this.triangleGLAlphas[index].verts[0].v *= (short) -1;
        this.triangleGLAlphas[index].verts[1].v *= (short) -1;
        this.triangleGLAlphas[index].verts[2].v *= (short) -1;
      }
      this.RenderPick();
      this.RenderLines();
      this.RenderLevelWithSelection();
      this.core.ClearScreenAndLoadIdentity();
      this.forceRedraw = true;
    }

    public byte[] Int16ToByteArray(short number)
    {
      return new byte[2]
      {
        (byte) ((uint) number >> 8),
        (byte) ((uint) number & (uint) byte.MaxValue)
      };
    }

    public byte[] Int32ToByteArray(int number)
    {
      return new byte[4]
      {
        (byte) (number >> 24),
        (byte) (number >> 16),
        (byte) (number >> 8),
        (byte) (number & (int) byte.MaxValue)
      };
    }

    private void drawSoundMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.drawSoundMap)
      {
        this.drawSoundMap = true;
        this.drawSoundMapToolStripMenuItem.Checked = true;
        this.drawColMap = false;
        this.drawCollisionMapToolStripMenuItem.Checked = false;
      }
      else
      {
        this.drawSoundMap = false;
        this.drawSoundMapToolStripMenuItem.Checked = false;
      }
      this.forceRedraw = true;
    }

    private void uncheckAllCollision()
    {
      this.collisionGroup16_tsmi.Checked = false;
      this.groupCollisionAuto_tsmi.Checked = false;
    }

    private void collisionGroup16_tsmi_Click(object sender, EventArgs e)
    {
      this.collisionMode = this.CollisionMode16;
      this.uncheckAllCollision();
      this.collisionGroup16_tsmi.Checked = true;
    }

    private void groupCollisionAuto_tsmi_Click(object sender, EventArgs e)
    {
      this.collisionMode = this.CollisionModeAuto;
      this.uncheckAllCollision();
      this.groupCollisionAuto_tsmi.Checked = true;
    }

    private void updateCull_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.updateCull = this.updateCull_cb.Checked;
    }

    private void updateGround_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.updateGround = this.updateGround_cb.Checked;
    }

    private void updateSound_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.updateSound = this.updateSound_cb.Checked;
    }

    private void updateColor_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.updateColor = this.updateColor_cb.Checked;
    }

    private void ModelImportForm_SizeChanged(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
        this.timer1.Stop();
      if (this.WindowState == FormWindowState.Normal)
      {
        this.timer1.Start();
        this.forceRedraw = true;
      }
      if (this.WindowState != FormWindowState.Maximized)
        return;
      this.timer1.Start();
      this.forceRedraw = true;
    }

    private void applyAll_btn_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure?", "Apply Base Coat", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      for (int index1 = 0; index1 < this.triangleGLs.Count<TriangleGL>(); ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
          this.triangleGLs[index1].verts[index2].r = Convert.ToByte(this.red_tb.Text);
          this.triangleGLs[index1].verts[index2].g = Convert.ToByte(this.green_tb.Text);
          this.triangleGLs[index1].verts[index2].b = Convert.ToByte(this.blue_tb.Text);
        }
      }
      for (int index1 = 0; index1 < this.triangleGLAlphas.Count<TriangleGL>(); ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
          this.triangleGLAlphas[index1].verts[index2].r = Convert.ToByte(this.red_tb.Text);
          this.triangleGLAlphas[index1].verts[index2].g = Convert.ToByte(this.green_tb.Text);
          this.triangleGLAlphas[index1].verts[index2].b = Convert.ToByte(this.blue_tb.Text);
        }
      }
      this.RenderLevelWithSelection();
      this.RenderLines();
      this.RenderPick();
      this.forceRedraw = true;
    }

    private void setImage()
    {
      if (this.TextureDataList.Count <= 0)
        return;
      try
      {
        TextureData textureData = this.currentImage >= this.TextureDataList.Count ? this.TextureDataAlphaList[this.currentImage - this.TextureDataList.Count] : this.TextureDataList[this.currentImage];
        if (textureData.height != 0)
        {
          byte[] source = (byte[]) textureData.gl.Clone();
          for (int index = 0; index < source.Length; index += 4)
          {
            byte num1 = source[index];
            byte num2 = source[index + 1];
            byte num3 = source[index + 2];
            byte num4 = source[index + 3];
            source[index] = num3;
            source[index + 1] = num2;
            source[index + 2] = num1;
            source[index + 3] = num4;
          }
          System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(textureData.width, textureData.height);
          Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
          BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
          IntPtr scan0 = bitmapdata.Scan0;
          Marshal.Copy(source, 0, scan0, source.Length);
          bitmap.UnlockBits(bitmapdata);
          this.tex_pb.Image = (Image) bitmap;
          this.clampU_cb.Checked = false;
          this.clampV_cb.Checked = false;
        }
        else
        {
          this.tex_pb.Image = (Image) null;
          this.clampU_cb.Checked = false;
          this.clampV_cb.Checked = false;
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void nxt_btn_Click(object sender, EventArgs e)
    {
      if (this.TextureDataList.Count <= 0)
        return;
      if (this.currentImage + 1 < this.TextureDataList.Count<TextureData>())
        ++this.currentImage;
      else if (this.currentImage + 1 - this.TextureDataList.Count<TextureData>() < this.TextureDataAlphaList.Count<TextureData>())
        ++this.currentImage;
      else
        this.currentImage = 0;
      this.setImage();
    }

    private void pr_btn_Click(object sender, EventArgs e)
    {
      if (this.TextureDataList.Count <= 0)
        return;
      if (this.currentImage - 1 >= 0)
        --this.currentImage;
      else
        this.currentImage = this.TextureDataList.Count<TextureData>() + this.TextureDataAlphaList.Count<TextureData>() - 1;
      this.setImage();
    }

    private void clampU_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.TextureDataList.Count <= 0)
        return;
      int num1 = this.clampU_cb.Checked ? 2 : 0;
      int currentImage = this.currentImage;
      if (this.currentImage >= this.TextureDataList.Count)
      {
        int num2 = this.currentImage - this.TextureDataList.Count;
        for (int index = 0; index < this.triangleGLAlphas.Count; ++index)
        {
          if (this.TextureSettingsAlpha[this.triangleGLAlphas[index].textureSetting].textureData == num2)
            this.TextureSettingsAlpha[this.triangleGLAlphas[index].textureSetting].cms = num1;
        }
      }
      else
      {
        for (int index = 0; index < this.triangleGLs.Count; ++index)
        {
          if (this.TextureSettings[this.triangleGLs[index].textureSetting].textureData == currentImage)
            this.TextureSettings[this.triangleGLs[index].textureSetting].cms = num1;
        }
      }
      this.RenderLevelWithSelection();
      this.RenderLines();
      this.RenderPick();
      this.forceRedraw = true;
    }

    private void clampV_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.TextureDataList.Count <= 0)
        return;
      int num1 = this.clampV_cb.Checked ? 2 : 0;
      int currentImage = this.currentImage;
      if (this.currentImage >= this.TextureDataList.Count)
      {
        int num2 = this.currentImage - this.TextureDataList.Count;
        for (int index = 0; index < this.triangleGLAlphas.Count; ++index)
        {
          if (this.TextureSettingsAlpha[this.triangleGLAlphas[index].textureSetting].textureData == num2)
            this.TextureSettingsAlpha[this.triangleGLAlphas[index].textureSetting].cmt = num1;
        }
      }
      else
      {
        for (int index = 0; index < this.triangleGLs.Count; ++index)
        {
          if (this.TextureSettings[this.triangleGLs[index].textureSetting].textureData == currentImage)
            this.TextureSettings[this.triangleGLs[index].textureSetting].cmt = num1;
        }
      }
      this.RenderLevelWithSelection();
      this.RenderLines();
      this.RenderPick();
      this.forceRedraw = true;
    }

    private void col_model_mod_btn_Click(object sender, EventArgs e)
    {
      this.col_model_mod_btn.Text = this.col_model_mod_btn.Text.Contains("-") ? "+ Model Modifiers" : "- Model Modifiers";
      this.col_modelMods_gb.Visible = !this.col_model_mod_btn.Text.Contains("+");
    }

    private void col_vertPaint_btn_Click(object sender, EventArgs e)
    {
      this.col_vertPaint_btn.Text = this.col_vertPaint_btn.Text.Contains("-") ? "+ Vert Painting" : "- Vert Painting";
      this.vertPaint_gb.Visible = !this.col_vertPaint_btn.Text.Contains("+");
    }

    private void col_mouse_btn_Click(object sender, EventArgs e)
    {
      this.col_mouse_btn.Text = this.col_mouse_btn.Text.Contains("-") ? "+ Mouse Settings" : "- Mouse Settings";
      this.mouseSettings_gb.Visible = !this.col_mouse_btn.Text.Contains("+");
    }

    private void cb_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      e.Handled = true;
    }

    private float Dot(ModelImportForm.Vector v1, ModelImportForm.Vector v2)
    {
      return (float) ((double) v1.x * (double) v2.x + (double) v1.y * (double) v2.y + (double) v1.z * (double) v2.z);
    }

    private float Dot(ModelImportForm.Point_ p1, ModelImportForm.Vector v2)
    {
      return (float) ((double) p1.x * (double) v2.x + (double) p1.y * (double) v2.y + (double) p1.z * (double) v2.z);
    }

    public ModelImportForm.Vector Cross(
      ModelImportForm.Vector v1,
      ModelImportForm.Vector v2)
    {
      ModelImportForm.Vector vector;
      vector.x = (float) ((double) v1.y * (double) v2.z - (double) v2.y * (double) v1.z);
      vector.y = (float) ((double) v1.z * (double) v2.x - (double) v1.x * (double) v2.z);
      vector.z = (float) ((double) v1.x * (double) v2.y - (double) v1.y * (double) v2.x);
      return vector;
    }

    private ModelImportForm.Vector ReduceToUnit(ModelImportForm.Vector v)
    {
      float num = (float) Math.Sqrt((double) v.x * (double) v.x + (double) v.y * (double) v.y + (double) v.z * (double) v.z);
      if ((double) num == 0.0)
        num = 1f;
      return new ModelImportForm.Vector()
      {
        x = v.x / num,
        y = v.y / num,
        z = v.z / num
      };
    }

    private float getmin(List<ModelImportForm.Point_> points, ModelImportForm.Vector axis)
    {
      float num1 = float.MaxValue;
      for (int index = 0; index < points.Count<ModelImportForm.Point_>(); ++index)
      {
        float num2 = this.Dot(points[index], axis);
        if ((double) num2 < (double) num1)
          num1 = num2;
      }
      return num1;
    }

    private float getmax(List<ModelImportForm.Point_> points, ModelImportForm.Vector axis)
    {
      float num1 = float.MinValue;
      for (int index = 0; index < points.Count<ModelImportForm.Point_>(); ++index)
      {
        float num2 = this.Dot(points[index], axis);
        if ((double) num2 > (double) num1)
          num1 = num2;
      }
      return num1;
    }

    private bool isect(
      List<ModelImportForm.Point_> points1,
      List<ModelImportForm.Point_> points2,
      ModelImportForm.Vector axis)
    {
      return (double) this.getmin(points1, axis) <= (double) this.getmax(points2, axis) && (double) this.getmax(points1, axis) >= (double) this.getmin(points2, axis);
    }

    private bool isectboxtri(float[] center, float[] r, float[][] triverts)
    {
      List<ModelImportForm.Point_> points1 = new List<ModelImportForm.Point_>();
      points1.Add(new ModelImportForm.Point_(center[0] + r[0], center[1] + r[1], center[2] + r[2]));
      points1.Add(new ModelImportForm.Point_(center[0] + r[0], center[1] + r[1], center[2] - r[2]));
      points1.Add(new ModelImportForm.Point_(center[0] + r[0], center[1] - r[1], center[2] + r[2]));
      points1.Add(new ModelImportForm.Point_(center[0] + r[0], center[1] - r[1], center[2] - r[2]));
      points1.Add(new ModelImportForm.Point_(center[0] - r[0], center[1] + r[1], center[2] + r[2]));
      points1.Add(new ModelImportForm.Point_(center[0] - r[0], center[1] + r[1], center[2] - r[2]));
      points1.Add(new ModelImportForm.Point_(center[0] - r[0], center[1] - r[1], center[2] + r[2]));
      points1.Add(new ModelImportForm.Point_(center[0] - r[0], center[1] - r[1], center[2] - r[2]));
      List<ModelImportForm.Point_> points2 = new List<ModelImportForm.Point_>();
      points2.Add(new ModelImportForm.Point_(triverts[0][0], triverts[0][1], triverts[0][2]));
      points2.Add(new ModelImportForm.Point_(triverts[1][0], triverts[1][1], triverts[1][2]));
      points2.Add(new ModelImportForm.Point_(triverts[2][0], triverts[2][1], triverts[2][2]));
      if (!this.isect(points1, points2, new ModelImportForm.Vector(1f, 0.0f, 0.0f)) || !this.isect(points1, points2, new ModelImportForm.Vector(0.0f, 1f, 0.0f)) || !this.isect(points1, points2, new ModelImportForm.Vector(0.0f, 0.0f, 1f)))
        return false;
      ModelImportForm.Vector vector = points2[1] - points2[0];
      ModelImportForm.Vector v2_1 = points2[2] - points2[1];
      ModelImportForm.Vector axis = this.Cross(vector, v2_1);
      if (!this.isect(points1, points2, axis))
        return false;
      ModelImportForm.Vector v2_2 = points2[0] - points2[2];
      ModelImportForm.Vector v1_1 = new ModelImportForm.Vector(1f, 0.0f, 0.0f);
      ModelImportForm.Vector v1_2 = new ModelImportForm.Vector(0.0f, 1f, 0.0f);
      ModelImportForm.Vector v1_3 = new ModelImportForm.Vector(0.0f, 0.0f, 1f);
      return this.isect(points1, points2, this.Cross(v1_1, vector)) && this.isect(points1, points2, this.Cross(v1_1, v2_1)) && (this.isect(points1, points2, this.Cross(v1_1, v2_2)) && this.isect(points1, points2, this.Cross(v1_2, vector))) && (this.isect(points1, points2, this.Cross(v1_2, v2_1)) && this.isect(points1, points2, this.Cross(v1_2, v2_2)) && (this.isect(points1, points2, this.Cross(v1_3, vector)) && this.isect(points1, points2, this.Cross(v1_3, v2_1)))) && this.isect(points1, points2, this.Cross(v1_3, v2_2));
    }

    private void sphereMap_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.sphereMap = this.sphereMap_cb.Checked;
    }

    private void simpleOpenGlControl1_Load(object sender, EventArgs e)
    {
      this.simpleOpenGlControl1.MakeCurrent();
      this.timer1.Enabled = true;
      Core.InitGl();
      this.core.SetView(this.simpleOpenGlControl1.Height, this.simpleOpenGlControl1.Width);
      this.BanjoDL();
      this.scale_tb.Text = this.scale_tbar.Value.ToString();
      this.speed = (double) (this.CamSpeed_tb.Value * 2);
      this.forceRedraw = true;
      this.camera();
      this.forceRedraw = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ModelImportForm));
      this.saveFileDialog1 = new SaveFileDialog();
      this.openFileDialog1 = new OpenFileDialog();
      this.timer1 = new Timer(this.components);
      this.label8 = new Label();
      this.red_tb = new TextBox();
      this.green_tb = new TextBox();
      this.label7 = new Label();
      this.alpha_tb = new TextBox();
      this.label9 = new Label();
      this.blue_tb = new TextBox();
      this.label10 = new Label();
      this.label11 = new Label();
      this.collisionType_cb = new ComboBox();
      this.vertPaint_gb = new GroupBox();
      this.tex_lbl = new Label();
      this.clampV_cb = new CheckBox();
      this.clampU_cb = new CheckBox();
      this.apply_texShade_btn = new Button();
      this.nxt_btn = new Button();
      this.collision_gb = new Panel();
      this.panel9 = new Panel();
      this.label21 = new Label();
      this.scrollTexture_cb = new CheckBox();
      this.panel8 = new Panel();
      this.label20 = new Label();
      this.animVert_cb = new CheckBox();
      this.panel7 = new Panel();
      this.label15 = new Label();
      this.genWaves_cb = new CheckBox();
      this.panel6 = new Panel();
      this.label14 = new Label();
      this.sphereMap_cb = new CheckBox();
      this.panel5 = new Panel();
      this.label1 = new Label();
      this.updateColor_cb = new CheckBox();
      this.panel4 = new Panel();
      this.updateCull_cb = new CheckBox();
      this.label16 = new Label();
      this.cullMode_cb = new ComboBox();
      this.panel2 = new Panel();
      this.updateSound_cb = new CheckBox();
      this.soundType_cb = new ComboBox();
      this.label5 = new Label();
      this.ground_cb = new ComboBox();
      this.panel1 = new Panel();
      this.updateCollision_cb = new CheckBox();
      this.panel3 = new Panel();
      this.label4 = new Label();
      this.updateGround_cb = new CheckBox();
      this.colour6_pnl = new Panel();
      this.applyAll_btn = new Button();
      this.pr_btn = new Button();
      this.colPick_btn = new Button();
      this.tex_pb = new PictureBox();
      this.colour5_pnl = new Panel();
      this.colour4_pnl = new Panel();
      this.colour3_pnl = new Panel();
      this.colour2_pnl = new Panel();
      this.colour1_pnl = new Panel();
      this.pnlPreview = new Panel();
      this.colorPick_pbx = new PictureBox();
      this.label12 = new Label();
      this.mouseSettings_gb = new GroupBox();
      this.moveToA_cb = new CheckBox();
      this.groupBox2 = new GroupBox();
      this.flipUpdate_rb = new RadioButton();
      this.triUpdate_rb = new RadioButton();
      this.vertUpdate_rb = new RadioButton();
      this.groupBox4 = new GroupBox();
      this.banjo_rb = new RadioButton();
      this.camera_rb = new RadioButton();
      this.flipV_btn = new Button();
      this.scale_tb = new TextBox();
      this.label13 = new Label();
      this.scale_tbar = new TrackBar();
      this.label2 = new Label();
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.importOBJToolStripMenuItem = new ToolStripMenuItem();
      this.openBinToolStripMenuItem = new ToolStripMenuItem();
      this.saveToolStripMenuItem = new ToolStripMenuItem();
      this.saveAsObjectModelToolStripMenuItem = new ToolStripMenuItem();
      this.viewToolStripMenuItem = new ToolStripMenuItem();
      this.drawBanjoToolStripMenuItem = new ToolStripMenuItem();
      this.drawEdgesToolStripMenuItem = new ToolStripMenuItem();
      this.drawCollisionMapToolStripMenuItem = new ToolStripMenuItem();
      this.drawSoundMapToolStripMenuItem = new ToolStripMenuItem();
      this.collisionToolStripMenuItem = new ToolStripMenuItem();
      this.collisionGroup16_tsmi = new ToolStripMenuItem();
      this.groupCollisionAuto_tsmi = new ToolStripMenuItem();
      this.openFD_bin = new OpenFileDialog();
      this.CamSpeed_tb = new TrackBar();
      this.label3 = new Label();
      this.moveZ_tb = new TextBox();
      this.col_modelMods_gb = new GroupBox();
      this.tableLayoutPanel3 = new TableLayoutPanel();
      this.label19 = new Label();
      this.moveX_tb = new TextBox();
      this.label18 = new Label();
      this.moveY_tb = new TextBox();
      this.label17 = new Label();
      this.label6 = new Label();
      this.flowLayoutPanel1 = new FlowLayoutPanel();
      this.col_model_mod_btn = new Button();
      this.col_vertPaint_btn = new Button();
      this.col_mouse_btn = new Button();
      this.simpleOpenGlControl1 = new GLControl();
      this.scrollMode_cb = new ComboBox();
      this.vertPaint_gb.SuspendLayout();
      this.collision_gb.SuspendLayout();
      this.panel9.SuspendLayout();
      this.panel8.SuspendLayout();
      this.panel7.SuspendLayout();
      this.panel6.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      ((ISupportInitialize) this.tex_pb).BeginInit();
      ((ISupportInitialize) this.colorPick_pbx).BeginInit();
      this.mouseSettings_gb.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.scale_tbar.BeginInit();
      this.menuStrip1.SuspendLayout();
      this.CamSpeed_tb.BeginInit();
      this.col_modelMods_gb.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.saveFileDialog1.DefaultExt = "bin";
      this.saveFileDialog1.Filter = "Bin File | *.bin";
      this.openFileDialog1.FileName = "model.obj";
      this.openFileDialog1.Filter = "OBJ Files|*.obj";
      this.timer1.Interval = 25;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.label8.AutoSize = true;
      this.label8.Location = new Point(6, 136);
      this.label8.Name = "label8";
      this.label8.Size = new Size(15, 13);
      this.label8.TabIndex = 20;
      this.label8.Text = "R";
      this.red_tb.Location = new Point(27, 133);
      this.red_tb.MaxLength = 3;
      this.red_tb.Name = "red_tb";
      this.red_tb.Size = new Size(25, 20);
      this.red_tb.TabIndex = 6;
      this.red_tb.Text = "255";
      this.red_tb.TextAlign = HorizontalAlignment.Right;
      this.red_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.red_tb.Leave += new EventHandler(this.colour_tb_Leave);
      this.green_tb.Location = new Point(77, 133);
      this.green_tb.MaxLength = 3;
      this.green_tb.Name = "green_tb";
      this.green_tb.Size = new Size(25, 20);
      this.green_tb.TabIndex = 8;
      this.green_tb.Text = "255";
      this.green_tb.TextAlign = HorizontalAlignment.Right;
      this.green_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.green_tb.Leave += new EventHandler(this.colour_tb_Leave);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(56, 136);
      this.label7.Name = "label7";
      this.label7.Size = new Size(15, 13);
      this.label7.TabIndex = 22;
      this.label7.Text = "G";
      this.alpha_tb.Location = new Point(174, 133);
      this.alpha_tb.MaxLength = 3;
      this.alpha_tb.Name = "alpha_tb";
      this.alpha_tb.Size = new Size(25, 20);
      this.alpha_tb.TabIndex = 9;
      this.alpha_tb.Text = "255";
      this.alpha_tb.TextAlign = HorizontalAlignment.Right;
      this.alpha_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.alpha_tb.Leave += new EventHandler(this.colour_tb_Leave);
      this.label9.AutoSize = true;
      this.label9.Location = new Point(156, 136);
      this.label9.Name = "label9";
      this.label9.Size = new Size(14, 13);
      this.label9.TabIndex = 26;
      this.label9.Text = "A";
      this.blue_tb.Location = new Point(125, 133);
      this.blue_tb.MaxLength = 3;
      this.blue_tb.Name = "blue_tb";
      this.blue_tb.Size = new Size(25, 20);
      this.blue_tb.TabIndex = 7;
      this.blue_tb.Text = "255";
      this.blue_tb.TextAlign = HorizontalAlignment.Right;
      this.blue_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.blue_tb.Leave += new EventHandler(this.colour_tb_Leave);
      this.label10.AutoSize = true;
      this.label10.Location = new Point(105, 136);
      this.label10.Name = "label10";
      this.label10.Size = new Size(14, 13);
      this.label10.TabIndex = 24;
      this.label10.Text = "B";
      this.label11.AutoSize = true;
      this.label11.BackColor = SystemColors.AppWorkspace;
      this.label11.Location = new Point(3, 5);
      this.label11.Name = "label11";
      this.label11.Size = new Size(75, 13);
      this.label11.TabIndex = 29;
      this.label11.Text = "Collision Type:";
      this.collisionType_cb.FormattingEnabled = true;
      this.collisionType_cb.Items.AddRange(new object[4]
      {
        (object) "Ground",
        (object) "Water",
        (object) "No Collision",
        (object) "Double Sided"
      });
      this.collisionType_cb.Location = new Point(85, 30);
      this.collisionType_cb.Name = "collisionType_cb";
      this.collisionType_cb.Size = new Size(94, 21);
      this.collisionType_cb.TabIndex = 10;
      this.collisionType_cb.Text = "Ground";
      this.collisionType_cb.KeyPress += new KeyPressEventHandler(this.cb_KeyPress);
      this.vertPaint_gb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.vertPaint_gb.Controls.Add((Control) this.tex_lbl);
      this.vertPaint_gb.Controls.Add((Control) this.clampV_cb);
      this.vertPaint_gb.Controls.Add((Control) this.clampU_cb);
      this.vertPaint_gb.Controls.Add((Control) this.apply_texShade_btn);
      this.vertPaint_gb.Controls.Add((Control) this.nxt_btn);
      this.vertPaint_gb.Controls.Add((Control) this.collision_gb);
      this.vertPaint_gb.Controls.Add((Control) this.colour6_pnl);
      this.vertPaint_gb.Controls.Add((Control) this.applyAll_btn);
      this.vertPaint_gb.Controls.Add((Control) this.pr_btn);
      this.vertPaint_gb.Controls.Add((Control) this.colPick_btn);
      this.vertPaint_gb.Controls.Add((Control) this.tex_pb);
      this.vertPaint_gb.Controls.Add((Control) this.colour5_pnl);
      this.vertPaint_gb.Controls.Add((Control) this.colour4_pnl);
      this.vertPaint_gb.Controls.Add((Control) this.colour3_pnl);
      this.vertPaint_gb.Controls.Add((Control) this.colour2_pnl);
      this.vertPaint_gb.Controls.Add((Control) this.colour1_pnl);
      this.vertPaint_gb.Controls.Add((Control) this.pnlPreview);
      this.vertPaint_gb.Controls.Add((Control) this.colorPick_pbx);
      this.vertPaint_gb.Controls.Add((Control) this.red_tb);
      this.vertPaint_gb.Controls.Add((Control) this.label8);
      this.vertPaint_gb.Controls.Add((Control) this.label7);
      this.vertPaint_gb.Controls.Add((Control) this.green_tb);
      this.vertPaint_gb.Controls.Add((Control) this.label10);
      this.vertPaint_gb.Controls.Add((Control) this.blue_tb);
      this.vertPaint_gb.Controls.Add((Control) this.label9);
      this.vertPaint_gb.Controls.Add((Control) this.alpha_tb);
      this.vertPaint_gb.Location = new Point(3, 219);
      this.vertPaint_gb.Name = "vertPaint_gb";
      this.vertPaint_gb.Size = new Size(211, 552);
      this.vertPaint_gb.TabIndex = 54;
      this.vertPaint_gb.TabStop = false;
      this.tex_lbl.AutoSize = true;
      this.tex_lbl.Location = new Point(83, 305);
      this.tex_lbl.Name = "tex_lbl";
      this.tex_lbl.Size = new Size(0, 13);
      this.tex_lbl.TabIndex = 79;
      this.clampV_cb.AutoSize = true;
      this.clampV_cb.Location = new Point(105, 287);
      this.clampV_cb.Name = "clampV_cb";
      this.clampV_cb.Size = new Size(65, 17);
      this.clampV_cb.TabIndex = 78;
      this.clampV_cb.Text = "Clamp V";
      this.clampV_cb.UseVisualStyleBackColor = true;
      this.clampV_cb.CheckedChanged += new EventHandler(this.clampV_cb_CheckedChanged);
      this.clampU_cb.AutoSize = true;
      this.clampU_cb.Location = new Point(105, 264);
      this.clampU_cb.Name = "clampU_cb";
      this.clampU_cb.Size = new Size(66, 17);
      this.clampU_cb.TabIndex = 77;
      this.clampU_cb.Text = "Clamp U";
      this.clampU_cb.UseVisualStyleBackColor = true;
      this.clampU_cb.CheckedChanged += new EventHandler(this.clampU_cb_CheckedChanged);
      this.apply_texShade_btn.Location = new Point(105, 210);
      this.apply_texShade_btn.Name = "apply_texShade_btn";
      this.apply_texShade_btn.Size = new Size(75, 47);
      this.apply_texShade_btn.TabIndex = 73;
      this.apply_texShade_btn.Text = "Apply To Texture";
      this.apply_texShade_btn.UseVisualStyleBackColor = true;
      this.apply_texShade_btn.Click += new EventHandler(this.apply_texShade_btn_Click);
      this.nxt_btn.Location = new Point(46, 280);
      this.nxt_btn.Name = "nxt_btn";
      this.nxt_btn.Size = new Size(25, 25);
      this.nxt_btn.TabIndex = 76;
      this.nxt_btn.Text = ">";
      this.nxt_btn.UseVisualStyleBackColor = true;
      this.nxt_btn.Click += new EventHandler(this.nxt_btn_Click);
      this.collision_gb.Controls.Add((Control) this.panel9);
      this.collision_gb.Controls.Add((Control) this.panel8);
      this.collision_gb.Controls.Add((Control) this.panel7);
      this.collision_gb.Controls.Add((Control) this.panel6);
      this.collision_gb.Controls.Add((Control) this.panel5);
      this.collision_gb.Controls.Add((Control) this.panel4);
      this.collision_gb.Controls.Add((Control) this.panel2);
      this.collision_gb.Controls.Add((Control) this.collisionType_cb);
      this.collision_gb.Controls.Add((Control) this.ground_cb);
      this.collision_gb.Controls.Add((Control) this.panel1);
      this.collision_gb.Controls.Add((Control) this.panel3);
      this.collision_gb.Location = new Point(0, 311);
      this.collision_gb.Name = "collision_gb";
      this.collision_gb.Size = new Size(207, 235);
      this.collision_gb.TabIndex = 65;
      this.panel9.BackColor = SystemColors.AppWorkspace;
      this.panel9.BorderStyle = BorderStyle.FixedSingle;
      this.panel9.Controls.Add((Control) this.scrollMode_cb);
      this.panel9.Controls.Add((Control) this.label21);
      this.panel9.Controls.Add((Control) this.scrollTexture_cb);
      this.panel9.Location = new Point(6, 207);
      this.panel9.Name = "panel9";
      this.panel9.Size = new Size(196, 26);
      this.panel9.TabIndex = 75;
      this.label21.AutoSize = true;
      this.label21.BackColor = SystemColors.AppWorkspace;
      this.label21.Location = new Point(3, 5);
      this.label21.Name = "label21";
      this.label21.Size = new Size(72, 13);
      this.label21.TabIndex = 29;
      this.label21.Text = "Scroll Texture";
      this.scrollTexture_cb.AutoSize = true;
      this.scrollTexture_cb.Location = new Point(177, 4);
      this.scrollTexture_cb.Name = "scrollTexture_cb";
      this.scrollTexture_cb.RightToLeft = RightToLeft.Yes;
      this.scrollTexture_cb.Size = new Size(15, 14);
      this.scrollTexture_cb.TabIndex = 71;
      this.scrollTexture_cb.UseVisualStyleBackColor = true;
      this.panel8.BackColor = SystemColors.AppWorkspace;
      this.panel8.BorderStyle = BorderStyle.FixedSingle;
      this.panel8.Controls.Add((Control) this.label20);
      this.panel8.Controls.Add((Control) this.animVert_cb);
      this.panel8.Location = new Point(6, 182);
      this.panel8.Name = "panel8";
      this.panel8.Size = new Size(196, 26);
      this.panel8.TabIndex = 74;
      this.label20.AutoSize = true;
      this.label20.BackColor = SystemColors.AppWorkspace;
      this.label20.Location = new Point(3, 5);
      this.label20.Name = "label20";
      this.label20.Size = new Size(116, 13);
      this.label20.TabIndex = 29;
      this.label20.Text = "Animate Vertex Colours";
      this.animVert_cb.AutoSize = true;
      this.animVert_cb.Location = new Point(177, 4);
      this.animVert_cb.Name = "animVert_cb";
      this.animVert_cb.RightToLeft = RightToLeft.Yes;
      this.animVert_cb.Size = new Size(15, 14);
      this.animVert_cb.TabIndex = 71;
      this.animVert_cb.UseVisualStyleBackColor = true;
      this.panel7.BackColor = SystemColors.AppWorkspace;
      this.panel7.BorderStyle = BorderStyle.FixedSingle;
      this.panel7.Controls.Add((Control) this.label15);
      this.panel7.Controls.Add((Control) this.genWaves_cb);
      this.panel7.Location = new Point(6, 157);
      this.panel7.Name = "panel7";
      this.panel7.Size = new Size(196, 26);
      this.panel7.TabIndex = 73;
      this.label15.AutoSize = true;
      this.label15.BackColor = SystemColors.AppWorkspace;
      this.label15.Location = new Point(3, 5);
      this.label15.Name = "label15";
      this.label15.Size = new Size(83, 13);
      this.label15.TabIndex = 29;
      this.label15.Text = "Generate Wave";
      this.genWaves_cb.AutoSize = true;
      this.genWaves_cb.Location = new Point(177, 4);
      this.genWaves_cb.Name = "genWaves_cb";
      this.genWaves_cb.RightToLeft = RightToLeft.Yes;
      this.genWaves_cb.Size = new Size(15, 14);
      this.genWaves_cb.TabIndex = 71;
      this.genWaves_cb.UseVisualStyleBackColor = true;
      this.panel6.BackColor = SystemColors.AppWorkspace;
      this.panel6.BorderStyle = BorderStyle.FixedSingle;
      this.panel6.Controls.Add((Control) this.label14);
      this.panel6.Controls.Add((Control) this.sphereMap_cb);
      this.panel6.Location = new Point(6, 132);
      this.panel6.Name = "panel6";
      this.panel6.Size = new Size(196, 26);
      this.panel6.TabIndex = 72;
      this.panel6.Visible = false;
      this.label14.AutoSize = true;
      this.label14.BackColor = SystemColors.AppWorkspace;
      this.label14.Location = new Point(3, 5);
      this.label14.Name = "label14";
      this.label14.Size = new Size(93, 13);
      this.label14.TabIndex = 29;
      this.label14.Text = "Environment Map:";
      this.label14.Visible = false;
      this.sphereMap_cb.AutoSize = true;
      this.sphereMap_cb.Location = new Point(177, 4);
      this.sphereMap_cb.Name = "sphereMap_cb";
      this.sphereMap_cb.RightToLeft = RightToLeft.Yes;
      this.sphereMap_cb.Size = new Size(15, 14);
      this.sphereMap_cb.TabIndex = 71;
      this.sphereMap_cb.UseVisualStyleBackColor = true;
      this.sphereMap_cb.Visible = false;
      this.sphereMap_cb.CheckedChanged += new EventHandler(this.sphereMap_cb_CheckedChanged);
      this.panel5.BackColor = SystemColors.AppWorkspace;
      this.panel5.BorderStyle = BorderStyle.FixedSingle;
      this.panel5.Controls.Add((Control) this.label1);
      this.panel5.Controls.Add((Control) this.updateColor_cb);
      this.panel5.Location = new Point(6, 3);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(196, 26);
      this.panel5.TabIndex = 71;
      this.label1.AutoSize = true;
      this.label1.BackColor = SystemColors.AppWorkspace;
      this.label1.Location = new Point(3, 5);
      this.label1.Name = "label1";
      this.label1.Size = new Size(78, 13);
      this.label1.TabIndex = 29;
      this.label1.Text = "Update Colour:";
      this.updateColor_cb.AutoSize = true;
      this.updateColor_cb.Checked = true;
      this.updateColor_cb.CheckState = CheckState.Checked;
      this.updateColor_cb.Location = new Point(174, 5);
      this.updateColor_cb.Name = "updateColor_cb";
      this.updateColor_cb.RightToLeft = RightToLeft.Yes;
      this.updateColor_cb.Size = new Size(15, 14);
      this.updateColor_cb.TabIndex = 71;
      this.updateColor_cb.UseVisualStyleBackColor = true;
      this.updateColor_cb.CheckedChanged += new EventHandler(this.updateColor_cb_CheckedChanged);
      this.panel4.BackColor = SystemColors.AppWorkspace;
      this.panel4.BorderStyle = BorderStyle.FixedSingle;
      this.panel4.Controls.Add((Control) this.updateCull_cb);
      this.panel4.Controls.Add((Control) this.label16);
      this.panel4.Controls.Add((Control) this.cullMode_cb);
      this.panel4.Location = new Point(6, 106);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(196, 26);
      this.panel4.TabIndex = 70;
      this.updateCull_cb.AutoSize = true;
      this.updateCull_cb.Checked = true;
      this.updateCull_cb.CheckState = CheckState.Checked;
      this.updateCull_cb.Location = new Point(177, 5);
      this.updateCull_cb.Name = "updateCull_cb";
      this.updateCull_cb.Size = new Size(15, 14);
      this.updateCull_cb.TabIndex = 67;
      this.updateCull_cb.UseVisualStyleBackColor = true;
      this.updateCull_cb.CheckedChanged += new EventHandler(this.updateCull_cb_CheckedChanged);
      this.label16.AutoSize = true;
      this.label16.Location = new Point(3, 5);
      this.label16.Name = "label16";
      this.label16.Size = new Size(57, 13);
      this.label16.TabIndex = 63;
      this.label16.Text = "Cull Mode:";
      this.cullMode_cb.FormattingEnabled = true;
      this.cullMode_cb.Items.AddRange(new object[3]
      {
        (object) "None",
        (object) "Front",
        (object) "Back"
      });
      this.cullMode_cb.Location = new Point(79, 1);
      this.cullMode_cb.Name = "cullMode_cb";
      this.cullMode_cb.Size = new Size(94, 21);
      this.cullMode_cb.TabIndex = 13;
      this.cullMode_cb.Text = "Back";
      this.cullMode_cb.KeyPress += new KeyPressEventHandler(this.cb_KeyPress);
      this.panel2.BackColor = SystemColors.AppWorkspace;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.updateSound_cb);
      this.panel2.Controls.Add((Control) this.soundType_cb);
      this.panel2.Controls.Add((Control) this.label5);
      this.panel2.Location = new Point(6, 80);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(196, 26);
      this.panel2.TabIndex = 69;
      this.updateSound_cb.AutoSize = true;
      this.updateSound_cb.BackColor = SystemColors.AppWorkspace;
      this.updateSound_cb.Checked = true;
      this.updateSound_cb.CheckState = CheckState.Checked;
      this.updateSound_cb.Location = new Point(177, 3);
      this.updateSound_cb.Name = "updateSound_cb";
      this.updateSound_cb.Size = new Size(15, 14);
      this.updateSound_cb.TabIndex = 66;
      this.updateSound_cb.UseVisualStyleBackColor = false;
      this.updateSound_cb.CheckedChanged += new EventHandler(this.updateSound_cb_CheckedChanged);
      this.soundType_cb.FormattingEnabled = true;
      this.soundType_cb.Items.AddRange(new object[10]
      {
        (object) "Normal",
        (object) "Metal",
        (object) "Hard Ground",
        (object) "Stone",
        (object) "Wood",
        (object) "Snow",
        (object) "Leaves",
        (object) "Swamp",
        (object) "Sand",
        (object) "Slush"
      });
      this.soundType_cb.Location = new Point(79, 2);
      this.soundType_cb.Name = "soundType_cb";
      this.soundType_cb.Size = new Size(94, 21);
      this.soundType_cb.TabIndex = 12;
      this.soundType_cb.Text = "Normal";
      this.soundType_cb.KeyPress += new KeyPressEventHandler(this.cb_KeyPress);
      this.label5.AutoSize = true;
      this.label5.BackColor = SystemColors.AppWorkspace;
      this.label5.Location = new Point(3, 4);
      this.label5.Name = "label5";
      this.label5.Size = new Size(68, 13);
      this.label5.TabIndex = 39;
      this.label5.Text = "Sound Type:";
      this.ground_cb.FormattingEnabled = true;
      this.ground_cb.Items.AddRange(new object[3]
      {
        (object) "Normal",
        (object) "Talon Trot",
        (object) "Unclimbable"
      });
      this.ground_cb.Location = new Point(85, 56);
      this.ground_cb.Name = "ground_cb";
      this.ground_cb.Size = new Size(94, 21);
      this.ground_cb.TabIndex = 11;
      this.ground_cb.Text = "Normal";
      this.ground_cb.KeyPress += new KeyPressEventHandler(this.cb_KeyPress);
      this.panel1.BackColor = SystemColors.AppWorkspace;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.updateCollision_cb);
      this.panel1.Controls.Add((Control) this.label11);
      this.panel1.Location = new Point(6, 28);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(196, 26);
      this.panel1.TabIndex = 68;
      this.updateCollision_cb.AutoSize = true;
      this.updateCollision_cb.BackColor = SystemColors.AppWorkspace;
      this.updateCollision_cb.Checked = true;
      this.updateCollision_cb.CheckState = CheckState.Checked;
      this.updateCollision_cb.Location = new Point(177, 6);
      this.updateCollision_cb.Name = "updateCollision_cb";
      this.updateCollision_cb.Size = new Size(15, 14);
      this.updateCollision_cb.TabIndex = 64;
      this.updateCollision_cb.UseVisualStyleBackColor = false;
      this.panel3.BackColor = SystemColors.AppWorkspace;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.label4);
      this.panel3.Controls.Add((Control) this.updateGround_cb);
      this.panel3.Location = new Point(6, 54);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(196, 26);
      this.panel3.TabIndex = 69;
      this.label4.AutoSize = true;
      this.label4.BackColor = SystemColors.AppWorkspace;
      this.label4.Location = new Point(4, 4);
      this.label4.Name = "label4";
      this.label4.Size = new Size(72, 13);
      this.label4.TabIndex = 35;
      this.label4.Text = "Ground Type:";
      this.updateGround_cb.AutoSize = true;
      this.updateGround_cb.BackColor = SystemColors.AppWorkspace;
      this.updateGround_cb.Checked = true;
      this.updateGround_cb.CheckState = CheckState.Checked;
      this.updateGround_cb.Location = new Point(177, 4);
      this.updateGround_cb.Name = "updateGround_cb";
      this.updateGround_cb.Size = new Size(15, 14);
      this.updateGround_cb.TabIndex = 65;
      this.updateGround_cb.UseVisualStyleBackColor = false;
      this.updateGround_cb.CheckedChanged += new EventHandler(this.updateGround_cb_CheckedChanged);
      this.colour6_pnl.BackColor = Color.White;
      this.colour6_pnl.BorderStyle = BorderStyle.FixedSingle;
      this.colour6_pnl.Location = new Point(171, 105);
      this.colour6_pnl.Name = "colour6_pnl";
      this.colour6_pnl.Size = new Size(25, 17);
      this.colour6_pnl.TabIndex = 73;
      this.colour6_pnl.MouseClick += new MouseEventHandler(this.pal_MouseClick);
      this.applyAll_btn.Location = new Point(90, 181);
      this.applyAll_btn.Name = "applyAll_btn";
      this.applyAll_btn.Size = new Size(109, 23);
      this.applyAll_btn.TabIndex = 72;
      this.applyAll_btn.Text = "Apply as Base Coat";
      this.applyAll_btn.UseVisualStyleBackColor = true;
      this.applyAll_btn.Click += new EventHandler(this.applyAll_btn_Click);
      this.pr_btn.Location = new Point(9, 280);
      this.pr_btn.Name = "pr_btn";
      this.pr_btn.Size = new Size(25, 25);
      this.pr_btn.TabIndex = 75;
      this.pr_btn.Text = "<";
      this.pr_btn.UseVisualStyleBackColor = true;
      this.pr_btn.Click += new EventHandler(this.pr_btn_Click);
      this.colPick_btn.FlatStyle = FlatStyle.Flat;
      this.colPick_btn.Location = new Point(9, 182);
      this.colPick_btn.Name = "colPick_btn";
      this.colPick_btn.Size = new Size(75, 23);
      this.colPick_btn.TabIndex = 14;
      this.colPick_btn.Text = "Pick Colour";
      this.colPick_btn.UseVisualStyleBackColor = true;
      this.colPick_btn.Click += new EventHandler(this.colPick_btn_Click);
      this.tex_pb.Location = new Point(11, 210);
      this.tex_pb.Name = "tex_pb";
      this.tex_pb.Size = new Size(64, 64);
      this.tex_pb.SizeMode = PictureBoxSizeMode.StretchImage;
      this.tex_pb.TabIndex = 74;
      this.tex_pb.TabStop = false;
      this.colour5_pnl.BackColor = Color.White;
      this.colour5_pnl.BorderStyle = BorderStyle.FixedSingle;
      this.colour5_pnl.Location = new Point(140, 105);
      this.colour5_pnl.Name = "colour5_pnl";
      this.colour5_pnl.Size = new Size(25, 17);
      this.colour5_pnl.TabIndex = 45;
      this.colour5_pnl.MouseClick += new MouseEventHandler(this.pal_MouseClick);
      this.colour4_pnl.BackColor = Color.White;
      this.colour4_pnl.BorderStyle = BorderStyle.FixedSingle;
      this.colour4_pnl.Location = new Point(108, 105);
      this.colour4_pnl.Name = "colour4_pnl";
      this.colour4_pnl.Size = new Size(25, 17);
      this.colour4_pnl.TabIndex = 44;
      this.colour4_pnl.MouseClick += new MouseEventHandler(this.pal_MouseClick);
      this.colour3_pnl.BackColor = Color.White;
      this.colour3_pnl.BorderStyle = BorderStyle.FixedSingle;
      this.colour3_pnl.Location = new Point(77, 105);
      this.colour3_pnl.Name = "colour3_pnl";
      this.colour3_pnl.Size = new Size(25, 17);
      this.colour3_pnl.TabIndex = 43;
      this.colour3_pnl.MouseClick += new MouseEventHandler(this.pal_MouseClick);
      this.colour2_pnl.BackColor = Color.White;
      this.colour2_pnl.BorderStyle = BorderStyle.FixedSingle;
      this.colour2_pnl.Location = new Point(46, 105);
      this.colour2_pnl.Name = "colour2_pnl";
      this.colour2_pnl.Size = new Size(25, 17);
      this.colour2_pnl.TabIndex = 42;
      this.colour2_pnl.MouseClick += new MouseEventHandler(this.pal_MouseClick);
      this.colour1_pnl.BackColor = Color.White;
      this.colour1_pnl.BorderStyle = BorderStyle.FixedSingle;
      this.colour1_pnl.Location = new Point(15, 105);
      this.colour1_pnl.Name = "colour1_pnl";
      this.colour1_pnl.Size = new Size(25, 17);
      this.colour1_pnl.TabIndex = 41;
      this.colour1_pnl.MouseClick += new MouseEventHandler(this.pal_MouseClick);
      this.pnlPreview.BackColor = Color.White;
      this.pnlPreview.BorderStyle = BorderStyle.FixedSingle;
      this.pnlPreview.Location = new Point(9, 159);
      this.pnlPreview.Name = "pnlPreview";
      this.pnlPreview.Size = new Size(190, 17);
      this.pnlPreview.TabIndex = 38;
      this.colorPick_pbx.Image = (Image) componentResourceManager.GetObject("colorPick_pbx.Image");
      this.colorPick_pbx.Location = new Point(6, 19);
      this.colorPick_pbx.Name = "colorPick_pbx";
      this.colorPick_pbx.Size = new Size(199, 80);
      this.colorPick_pbx.SizeMode = PictureBoxSizeMode.StretchImage;
      this.colorPick_pbx.TabIndex = 37;
      this.colorPick_pbx.TabStop = false;
      this.colorPick_pbx.MouseDown += new MouseEventHandler(this.colorPick_pbx_MouseDown);
      this.colorPick_pbx.MouseLeave += new EventHandler(this.colorPick_pbx_MouseLeave);
      this.colorPick_pbx.MouseMove += new MouseEventHandler(this.colorPick_pbx_MouseMove);
      this.colorPick_pbx.MouseUp += new MouseEventHandler(this.colorPick_pbx_MouseUp);
      this.label12.AutoSize = true;
      this.label12.Location = new Point(7, 41);
      this.label12.Name = "label12";
      this.label12.Size = new Size(13, 13);
      this.label12.TabIndex = 58;
      this.label12.Text = "1";
      this.mouseSettings_gb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.mouseSettings_gb.Controls.Add((Control) this.moveToA_cb);
      this.mouseSettings_gb.Controls.Add((Control) this.groupBox2);
      this.mouseSettings_gb.Controls.Add((Control) this.groupBox4);
      this.mouseSettings_gb.Location = new Point(3, 800);
      this.mouseSettings_gb.Name = "mouseSettings_gb";
      this.mouseSettings_gb.Padding = new Padding(3, 3, 3, 30);
      this.mouseSettings_gb.Size = new Size(205, 158);
      this.mouseSettings_gb.TabIndex = 55;
      this.mouseSettings_gb.TabStop = false;
      this.mouseSettings_gb.Text = "Settings";
      this.moveToA_cb.AutoSize = true;
      this.moveToA_cb.Location = new Point(8, 114);
      this.moveToA_cb.Name = "moveToA_cb";
      this.moveToA_cb.Size = new Size(142, 17);
      this.moveToA_cb.TabIndex = 19;
      this.moveToA_cb.Text = "Always move to Model A";
      this.moveToA_cb.UseVisualStyleBackColor = true;
      this.moveToA_cb.CheckedChanged += new EventHandler(this.moveToA_cb_CheckedChanged);
      this.groupBox2.Controls.Add((Control) this.flipUpdate_rb);
      this.groupBox2.Controls.Add((Control) this.triUpdate_rb);
      this.groupBox2.Controls.Add((Control) this.vertUpdate_rb);
      this.groupBox2.Location = new Point(8, 65);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(188, 43);
      this.groupBox2.TabIndex = 18;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Mouse Right Click";
      this.flipUpdate_rb.AutoSize = true;
      this.flipUpdate_rb.Location = new Point(125, 19);
      this.flipUpdate_rb.Name = "flipUpdate_rb";
      this.flipUpdate_rb.Size = new Size(41, 17);
      this.flipUpdate_rb.TabIndex = 19;
      this.flipUpdate_rb.TabStop = true;
      this.flipUpdate_rb.Text = "Flip";
      this.flipUpdate_rb.UseVisualStyleBackColor = true;
      this.flipUpdate_rb.CheckedChanged += new EventHandler(this.flipUpdate_rb_CheckedChanged);
      this.triUpdate_rb.AutoSize = true;
      this.triUpdate_rb.Location = new Point(56, 19);
      this.triUpdate_rb.Name = "triUpdate_rb";
      this.triUpdate_rb.Size = new Size(63, 17);
      this.triUpdate_rb.TabIndex = 18;
      this.triUpdate_rb.TabStop = true;
      this.triUpdate_rb.Text = "Triangle";
      this.triUpdate_rb.UseVisualStyleBackColor = true;
      this.triUpdate_rb.CheckedChanged += new EventHandler(this.triUpdate_rb_CheckedChanged);
      this.vertUpdate_rb.AutoSize = true;
      this.vertUpdate_rb.Checked = true;
      this.vertUpdate_rb.Location = new Point(6, 19);
      this.vertUpdate_rb.Name = "vertUpdate_rb";
      this.vertUpdate_rb.Size = new Size(44, 17);
      this.vertUpdate_rb.TabIndex = 17;
      this.vertUpdate_rb.TabStop = true;
      this.vertUpdate_rb.Text = "Vert";
      this.vertUpdate_rb.UseVisualStyleBackColor = true;
      this.vertUpdate_rb.CheckedChanged += new EventHandler(this.vertUpdate_rb_CheckedChanged);
      this.groupBox4.Controls.Add((Control) this.banjo_rb);
      this.groupBox4.Controls.Add((Control) this.camera_rb);
      this.groupBox4.Location = new Point(8, 16);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(188, 43);
      this.groupBox4.TabIndex = 17;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Mouse Left Click";
      this.banjo_rb.AutoSize = true;
      this.banjo_rb.BackColor = Color.Transparent;
      this.banjo_rb.Location = new Point(112, 20);
      this.banjo_rb.Name = "banjo_rb";
      this.banjo_rb.Size = new Size(52, 17);
      this.banjo_rb.TabIndex = 16;
      this.banjo_rb.Text = "Banjo";
      this.banjo_rb.UseVisualStyleBackColor = false;
      this.banjo_rb.CheckedChanged += new EventHandler(this.banjo_rb_CheckedChanged);
      this.camera_rb.AutoSize = true;
      this.camera_rb.Checked = true;
      this.camera_rb.Location = new Point(9, 20);
      this.camera_rb.Name = "camera_rb";
      this.camera_rb.Size = new Size(102, 17);
      this.camera_rb.TabIndex = 15;
      this.camera_rb.TabStop = true;
      this.camera_rb.Text = "Camera |  Select";
      this.camera_rb.UseVisualStyleBackColor = true;
      this.camera_rb.CheckedChanged += new EventHandler(this.camera_rb_CheckedChanged);
      this.flipV_btn.Location = new Point(6, 114);
      this.flipV_btn.Name = "flipV_btn";
      this.flipV_btn.Size = new Size(122, 25);
      this.flipV_btn.TabIndex = 21;
      this.flipV_btn.Text = "Flip Textures Vertically";
      this.flipV_btn.UseVisualStyleBackColor = true;
      this.flipV_btn.Click += new EventHandler(this.flipV_btn_Click);
      this.scale_tb.Location = new Point(46, 13);
      this.scale_tb.Name = "scale_tb";
      this.scale_tb.Size = new Size(50, 20);
      this.scale_tb.TabIndex = 1;
      this.scale_tb.TextChanged += new EventHandler(this.scale_tb_TextChanged);
      this.scale_tb.KeyPress += new KeyPressEventHandler(this.floatOnly_KeyPress);
      this.label13.AutoSize = true;
      this.label13.Location = new Point(168, 41);
      this.label13.Name = "label13";
      this.label13.Size = new Size(31, 13);
      this.label13.TabIndex = 59;
      this.label13.Text = "1000";
      this.scale_tbar.AutoSize = false;
      this.scale_tbar.Cursor = Cursors.Hand;
      this.scale_tbar.Location = new Point(17, 39);
      this.scale_tbar.Maximum = 1000;
      this.scale_tbar.Minimum = 1;
      this.scale_tbar.Name = "scale_tbar";
      this.scale_tbar.Size = new Size(153, 19);
      this.scale_tbar.TabIndex = 2;
      this.scale_tbar.TickFrequency = 100;
      this.scale_tbar.Value = 100;
      this.scale_tbar.Scroll += new EventHandler(this.scale_tbar_Scroll);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(34, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Scale";
      this.menuStrip1.BackColor = SystemColors.ActiveCaption;
      this.menuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.viewToolStripMenuItem,
        (ToolStripItem) this.collisionToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(1094, 24);
      this.menuStrip1.TabIndex = 56;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.importOBJToolStripMenuItem,
        (ToolStripItem) this.openBinToolStripMenuItem,
        (ToolStripItem) this.saveToolStripMenuItem,
        (ToolStripItem) this.saveAsObjectModelToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      this.importOBJToolStripMenuItem.Name = "importOBJToolStripMenuItem";
      this.importOBJToolStripMenuItem.Size = new Size(189, 22);
      this.importOBJToolStripMenuItem.Text = "Import OBJ";
      this.importOBJToolStripMenuItem.Click += new EventHandler(this.browse_btn_Click);
      this.openBinToolStripMenuItem.Name = "openBinToolStripMenuItem";
      this.openBinToolStripMenuItem.Size = new Size(189, 22);
      this.openBinToolStripMenuItem.Text = "Open Bin";
      this.openBinToolStripMenuItem.Click += new EventHandler(this.openBinToolStripMenuItem_Click);
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new Size(189, 22);
      this.saveToolStripMenuItem.Text = "Save As Level Model";
      this.saveToolStripMenuItem.Click += new EventHandler(this.save_btn_Click);
      this.saveAsObjectModelToolStripMenuItem.Name = "saveAsObjectModelToolStripMenuItem";
      this.saveAsObjectModelToolStripMenuItem.Size = new Size(189, 22);
      this.saveAsObjectModelToolStripMenuItem.Text = "Save As Object Model";
      this.saveAsObjectModelToolStripMenuItem.Click += new EventHandler(this.saveAsObjectModelToolStripMenuItem_Click);
      this.viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.drawBanjoToolStripMenuItem,
        (ToolStripItem) this.drawEdgesToolStripMenuItem,
        (ToolStripItem) this.drawCollisionMapToolStripMenuItem,
        (ToolStripItem) this.drawSoundMapToolStripMenuItem
      });
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new Size(44, 20);
      this.viewToolStripMenuItem.Text = "View";
      this.drawBanjoToolStripMenuItem.Checked = true;
      this.drawBanjoToolStripMenuItem.CheckState = CheckState.Checked;
      this.drawBanjoToolStripMenuItem.Name = "drawBanjoToolStripMenuItem";
      this.drawBanjoToolStripMenuItem.Size = new Size(177, 22);
      this.drawBanjoToolStripMenuItem.Text = "Draw Banjo";
      this.drawBanjoToolStripMenuItem.CheckedChanged += new EventHandler(this.drawBanjo_cb_CheckedChanged);
      this.drawBanjoToolStripMenuItem.Click += new EventHandler(this.drawBanjoToolStripMenuItem_Click);
      this.drawEdgesToolStripMenuItem.Checked = true;
      this.drawEdgesToolStripMenuItem.CheckState = CheckState.Checked;
      this.drawEdgesToolStripMenuItem.Name = "drawEdgesToolStripMenuItem";
      this.drawEdgesToolStripMenuItem.Size = new Size(177, 22);
      this.drawEdgesToolStripMenuItem.Text = "Draw Edges";
      this.drawEdgesToolStripMenuItem.Click += new EventHandler(this.drawEdgesToolStripMenuItem_Click);
      this.drawCollisionMapToolStripMenuItem.Name = "drawCollisionMapToolStripMenuItem";
      this.drawCollisionMapToolStripMenuItem.Size = new Size(177, 22);
      this.drawCollisionMapToolStripMenuItem.Text = "Draw Collision Map";
      this.drawCollisionMapToolStripMenuItem.Click += new EventHandler(this.drawCollisionMapToolStripMenuItem_Click);
      this.drawSoundMapToolStripMenuItem.Name = "drawSoundMapToolStripMenuItem";
      this.drawSoundMapToolStripMenuItem.Size = new Size(177, 22);
      this.drawSoundMapToolStripMenuItem.Text = "Draw Sound Map";
      this.drawSoundMapToolStripMenuItem.Click += new EventHandler(this.drawSoundMapToolStripMenuItem_Click);
      this.collisionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.collisionGroup16_tsmi,
        (ToolStripItem) this.groupCollisionAuto_tsmi
      });
      this.collisionToolStripMenuItem.Name = "collisionToolStripMenuItem";
      this.collisionToolStripMenuItem.Size = new Size(65, 20);
      this.collisionToolStripMenuItem.Text = "Collision";
      this.collisionGroup16_tsmi.Name = "collisionGroup16_tsmi";
      this.collisionGroup16_tsmi.Size = new Size(241, 22);
      this.collisionGroup16_tsmi.Text = "16 Group Collision";
      this.collisionGroup16_tsmi.Click += new EventHandler(this.collisionGroup16_tsmi_Click);
      this.groupCollisionAuto_tsmi.Checked = true;
      this.groupCollisionAuto_tsmi.CheckState = CheckState.Checked;
      this.groupCollisionAuto_tsmi.Name = "groupCollisionAuto_tsmi";
      this.groupCollisionAuto_tsmi.Size = new Size(241, 22);
      this.groupCollisionAuto_tsmi.Text = "Auto Collision (Recommended)";
      this.groupCollisionAuto_tsmi.Click += new EventHandler(this.groupCollisionAuto_tsmi_Click);
      this.openFD_bin.Filter = "Bin files|*.bin";
      this.CamSpeed_tb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.CamSpeed_tb.AutoSize = false;
      this.CamSpeed_tb.BackColor = SystemColors.ActiveCaption;
      this.CamSpeed_tb.Cursor = Cursors.Hand;
      this.CamSpeed_tb.Location = new Point(944, 2);
      this.CamSpeed_tb.Maximum = 100;
      this.CamSpeed_tb.Minimum = 5;
      this.CamSpeed_tb.Name = "CamSpeed_tb";
      this.CamSpeed_tb.Size = new Size(124, 17);
      this.CamSpeed_tb.TabIndex = 0;
      this.CamSpeed_tb.TickFrequency = 5;
      this.CamSpeed_tb.Value = 30;
      this.CamSpeed_tb.Scroll += new EventHandler(this.CamSpeed_tb_Scroll);
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label3.AutoSize = true;
      this.label3.BackColor = SystemColors.ActiveCaption;
      this.label3.Location = new Point(865, 5);
      this.label3.Name = "label3";
      this.label3.Size = new Size(77, 13);
      this.label3.TabIndex = 58;
      this.label3.Text = "Camera Speed";
      this.moveZ_tb.Enabled = false;
      this.moveZ_tb.Location = new Point(153, 3);
      this.moveZ_tb.Name = "moveZ_tb";
      this.moveZ_tb.Size = new Size(42, 20);
      this.moveZ_tb.TabIndex = 5;
      this.moveZ_tb.Text = "0";
      this.moveZ_tb.TextAlign = HorizontalAlignment.Right;
      this.moveZ_tb.KeyPress += new KeyPressEventHandler(this.numOnlyLocation_KeyPress);
      this.moveZ_tb.Leave += new EventHandler(this.moveZ_tb_Leave);
      this.col_modelMods_gb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.col_modelMods_gb.Controls.Add((Control) this.flipV_btn);
      this.col_modelMods_gb.Controls.Add((Control) this.tableLayoutPanel3);
      this.col_modelMods_gb.Controls.Add((Control) this.label6);
      this.col_modelMods_gb.Controls.Add((Control) this.scale_tbar);
      this.col_modelMods_gb.Controls.Add((Control) this.label2);
      this.col_modelMods_gb.Controls.Add((Control) this.label13);
      this.col_modelMods_gb.Controls.Add((Control) this.label12);
      this.col_modelMods_gb.Controls.Add((Control) this.scale_tb);
      this.col_modelMods_gb.Location = new Point(3, 26);
      this.col_modelMods_gb.Name = "col_modelMods_gb";
      this.col_modelMods_gb.Size = new Size(207, 164);
      this.col_modelMods_gb.TabIndex = 62;
      this.col_modelMods_gb.TabStop = false;
      this.tableLayoutPanel3.ColumnCount = 6;
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.10101f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.23232f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.10101f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.23232f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.10101f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.23232f));
      this.tableLayoutPanel3.Controls.Add((Control) this.label19, 0, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.moveX_tb, 1, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.label18, 2, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.moveY_tb, 3, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.label17, 4, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.moveZ_tb, 5, 0);
      this.tableLayoutPanel3.Location = new Point(6, 80);
      this.tableLayoutPanel3.Margin = new Padding(0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel3.Size = new Size(198, 31);
      this.tableLayoutPanel3.TabIndex = 66;
      this.label19.AutoSize = true;
      this.label19.Location = new Point(3, 0);
      this.label19.Name = "label19";
      this.label19.Size = new Size(14, 13);
      this.label19.TabIndex = 28;
      this.label19.Text = "X";
      this.moveX_tb.Enabled = false;
      this.moveX_tb.Location = new Point(23, 3);
      this.moveX_tb.Name = "moveX_tb";
      this.moveX_tb.Size = new Size(39, 20);
      this.moveX_tb.TabIndex = 3;
      this.moveX_tb.Text = "0";
      this.moveX_tb.TextAlign = HorizontalAlignment.Right;
      this.moveX_tb.KeyPress += new KeyPressEventHandler(this.numOnlyLocation_KeyPress);
      this.moveX_tb.Leave += new EventHandler(this.moveX_tb_Leave);
      this.label18.AutoSize = true;
      this.label18.Location = new Point(68, 0);
      this.label18.Name = "label18";
      this.label18.Size = new Size(14, 13);
      this.label18.TabIndex = 29;
      this.label18.Text = "Y";
      this.moveY_tb.Enabled = false;
      this.moveY_tb.Location = new Point(88, 3);
      this.moveY_tb.Name = "moveY_tb";
      this.moveY_tb.Size = new Size(39, 20);
      this.moveY_tb.TabIndex = 4;
      this.moveY_tb.Text = "0";
      this.moveY_tb.TextAlign = HorizontalAlignment.Right;
      this.moveY_tb.KeyPress += new KeyPressEventHandler(this.numOnlyLocation_KeyPress);
      this.moveY_tb.Leave += new EventHandler(this.moveY_tb_Leave);
      this.label17.AutoSize = true;
      this.label17.Location = new Point(133, 0);
      this.label17.Name = "label17";
      this.label17.Size = new Size(14, 13);
      this.label17.TabIndex = 30;
      this.label17.Text = "Z";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(8, 57);
      this.label6.Name = "label6";
      this.label6.Size = new Size(48, 13);
      this.label6.TabIndex = 62;
      this.label6.Text = "Location";
      this.flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.flowLayoutPanel1.AutoScroll = true;
      this.flowLayoutPanel1.Controls.Add((Control) this.col_model_mod_btn);
      this.flowLayoutPanel1.Controls.Add((Control) this.col_modelMods_gb);
      this.flowLayoutPanel1.Controls.Add((Control) this.col_vertPaint_btn);
      this.flowLayoutPanel1.Controls.Add((Control) this.vertPaint_gb);
      this.flowLayoutPanel1.Controls.Add((Control) this.col_mouse_btn);
      this.flowLayoutPanel1.Controls.Add((Control) this.mouseSettings_gb);
      this.flowLayoutPanel1.Location = new Point(861, 30);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new Size(233, 491);
      this.flowLayoutPanel1.TabIndex = 63;
      this.col_model_mod_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.col_model_mod_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_model_mod_btn.FlatStyle = FlatStyle.Flat;
      this.col_model_mod_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_model_mod_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_model_mod_btn.Location = new Point(0, 0);
      this.col_model_mod_btn.Margin = new Padding(0);
      this.col_model_mod_btn.Name = "col_model_mod_btn";
      this.col_model_mod_btn.Size = new Size(210, 23);
      this.col_model_mod_btn.TabIndex = 63;
      this.col_model_mod_btn.Text = "- Model Modifiers";
      this.col_model_mod_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_model_mod_btn.UseVisualStyleBackColor = false;
      this.col_model_mod_btn.Click += new EventHandler(this.col_model_mod_btn_Click);
      this.col_vertPaint_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.col_vertPaint_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_vertPaint_btn.FlatStyle = FlatStyle.Flat;
      this.col_vertPaint_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_vertPaint_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_vertPaint_btn.Location = new Point(0, 193);
      this.col_vertPaint_btn.Margin = new Padding(0);
      this.col_vertPaint_btn.Name = "col_vertPaint_btn";
      this.col_vertPaint_btn.Size = new Size(210, 23);
      this.col_vertPaint_btn.TabIndex = 64;
      this.col_vertPaint_btn.Text = "- Vert Painting";
      this.col_vertPaint_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_vertPaint_btn.UseVisualStyleBackColor = false;
      this.col_vertPaint_btn.Click += new EventHandler(this.col_vertPaint_btn_Click);
      this.col_mouse_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_mouse_btn.FlatStyle = FlatStyle.Flat;
      this.col_mouse_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_mouse_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_mouse_btn.Location = new Point(0, 774);
      this.col_mouse_btn.Margin = new Padding(0);
      this.col_mouse_btn.Name = "col_mouse_btn";
      this.col_mouse_btn.Size = new Size(210, 23);
      this.col_mouse_btn.TabIndex = 66;
      this.col_mouse_btn.Text = "- Mouse Settings";
      this.col_mouse_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_mouse_btn.UseVisualStyleBackColor = false;
      this.col_mouse_btn.Click += new EventHandler(this.col_mouse_btn_Click);
      this.simpleOpenGlControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.simpleOpenGlControl1.BackColor = Color.Black;
      this.simpleOpenGlControl1.Location = new Point(0, 25);
      this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
      this.simpleOpenGlControl1.Size = new Size(855, 496);
      this.simpleOpenGlControl1.TabIndex = 64;
      this.simpleOpenGlControl1.VSync = false;
      this.simpleOpenGlControl1.Load += new EventHandler(this.simpleOpenGlControl1_Load);
      this.simpleOpenGlControl1.SizeChanged += new EventHandler(this.simpleOpenGlControl1_SizeChanged);
      this.simpleOpenGlControl1.Paint += new PaintEventHandler(this.simpleOpenGlControl1_Paint);
      this.simpleOpenGlControl1.KeyDown += new KeyEventHandler(this.LevelViewer_KeyDown);
      this.simpleOpenGlControl1.KeyUp += new KeyEventHandler(this.LevelViewer_KeyUp);
      this.simpleOpenGlControl1.MouseDown += new MouseEventHandler(this.ModelImportForm_MouseDown);
      this.simpleOpenGlControl1.MouseLeave += new EventHandler(this.simpleOpenGlControl1_MouseLeave);
      this.simpleOpenGlControl1.MouseMove += new MouseEventHandler(this.simpleOpenGlControl1_MouseMove);
      this.simpleOpenGlControl1.MouseUp += new MouseEventHandler(this.ModelImportForm_MouseUp);
      this.scrollMode_cb.FormattingEnabled = true;
      this.scrollMode_cb.Items.AddRange(new object[3]
      {
        (object) "Slow",
        (object) "Normal",
        (object) "Fast"
      });
      this.scrollMode_cb.Location = new Point(79, 2);
      this.scrollMode_cb.Name = "scrollMode_cb";
      this.scrollMode_cb.Size = new Size(94, 21);
      this.scrollMode_cb.TabIndex = 72;
      this.scrollMode_cb.Text = "Normal";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1094, 522);
      this.Controls.Add((Control) this.simpleOpenGlControl1);
      this.Controls.Add((Control) this.flowLayoutPanel1);
      this.Controls.Add((Control) this.CamSpeed_tb);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.menuStrip1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MainMenuStrip = this.menuStrip1;
      this.MinimizeBox = false;
      this.Name = nameof (ModelImportForm);
      this.ShowIcon = false;
      this.Text = "Model Importer";
      this.FormClosing += new FormClosingEventHandler(this.ModelImportForm_FormClosing);
      this.FormClosed += new FormClosedEventHandler(this.ModelImportForm_FormClosed);
      this.Load += new EventHandler(this.ModelImportForm_Load);
      this.SizeChanged += new EventHandler(this.ModelImportForm_SizeChanged);
      this.KeyUp += new KeyEventHandler(this.ModelImportForm_KeyUp);
      this.MouseClick += new MouseEventHandler(this.ModelImportForm_MouseClick);
      this.vertPaint_gb.ResumeLayout(false);
      this.vertPaint_gb.PerformLayout();
      this.collision_gb.ResumeLayout(false);
      this.panel9.ResumeLayout(false);
      this.panel9.PerformLayout();
      this.panel8.ResumeLayout(false);
      this.panel8.PerformLayout();
      this.panel7.ResumeLayout(false);
      this.panel7.PerformLayout();
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((ISupportInitialize) this.tex_pb).EndInit();
      ((ISupportInitialize) this.colorPick_pbx).EndInit();
      this.mouseSettings_gb.ResumeLayout(false);
      this.mouseSettings_gb.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.scale_tbar.EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.CamSpeed_tb.EndInit();
      this.col_modelMods_gb.ResumeLayout(false);
      this.col_modelMods_gb.PerformLayout();
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public struct Vector
    {
      public float x;
      public float y;
      public float z;

      public Vector(float a, float b, float c)
      {
        this.x = a;
        this.y = b;
        this.z = c;
      }

      public static ModelImportForm.Vector operator -(
        ModelImportForm.Vector v1,
        ModelImportForm.Vector v2)
      {
        ModelImportForm.Vector vector;
        vector.x = v1.x - v2.x;
        vector.y = v1.y - v2.y;
        vector.z = v1.z - v2.z;
        return vector;
      }

      public static ModelImportForm.Vector operator *(
        float scale,
        ModelImportForm.Vector v)
      {
        ModelImportForm.Vector vector;
        vector.x = scale * v.x;
        vector.y = scale * v.y;
        vector.z = scale * v.z;
        return vector;
      }
    }

    public struct Point_
    {
      public float x;
      public float y;
      public float z;

      public Point_(float a, float b, float c)
      {
        this.x = a;
        this.y = b;
        this.z = c;
      }

      public static ModelImportForm.Vector operator -(
        ModelImportForm.Point_ p1,
        ModelImportForm.Point_ p2)
      {
        ModelImportForm.Vector vector;
        vector.x = p1.x - p2.x;
        vector.y = p1.y - p2.y;
        vector.z = p1.z - p2.z;
        return vector;
      }

      public static ModelImportForm.Point_ operator +(
        ModelImportForm.Point_ p,
        ModelImportForm.Vector v)
      {
        ModelImportForm.Point_ point;
        point.x = p.x + v.x;
        point.y = p.y + v.y;
        point.z = p.z + v.z;
        return point;
      }

      public static ModelImportForm.Point_ operator +(
        ModelImportForm.Point_ p,
        ModelImportForm.Point_ p2)
      {
        ModelImportForm.Point_ point;
        point.x = p.x + p2.x;
        point.y = p.y + p2.y;
        point.z = p.z + p2.z;
        return point;
      }

      public static ModelImportForm.Point_ operator *(
        float scale,
        ModelImportForm.Point_ p)
      {
        ModelImportForm.Point_ point;
        point.x = scale * p.x;
        point.y = scale * p.y;
        point.z = scale * p.z;
        return point;
      }
    }
  }
}
