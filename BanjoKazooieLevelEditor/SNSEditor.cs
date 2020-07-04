// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SNSEditor
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: C:\Users\runem\Desktop\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class SNSEditor : Form
  {
    private List<SNSItem> SNSItems = new List<SNSItem>();
    private List<SetupFile> SetupFiles;
    private SNSItem selectedItem;
    private bool isSelecting;
    public List<byte> F37F90;
    public List<byte> F9CAE0;
    public bool updatedRom;
    private IContainer components;
    private ListBox level_lb;
    private Label label3;
    private Button update_btn;
    private Label label1;
    private ListBox items_lb;
    private Panel particle_pnl;
    private Label label2;
    private PictureBox colorPick_pbx;
    private Label lbl4;
    private TextBox unknown_tb;

    public SNSEditor(List<byte> F37F90_, List<byte> F9CAE0_, List<SetupFile> SetupFiles_)
    {
      this.InitializeComponent();
      this.F37F90 = F37F90_;
      this.F9CAE0 = F9CAE0_;
      this.SetupFiles = SetupFiles_;
      this.createSNSItems();
      this.populateLevelList();
      this.disableEditing();
    }

    private void createSNSItems()
    {
      this.SNSItems.Add(new SNSItem(22912, (int) this.F37F90[22914] * 256 + (int) this.F37F90[22915], this.F37F90[22919], (byte) 0));
      for (int loc_ = 22920; loc_ < 22976; loc_ += 12)
        this.SNSItems.Add(new SNSItem(loc_, (int) this.F37F90[loc_ + 2] * 256 + (int) this.F37F90[loc_ + 3], this.F37F90[loc_ + 7], this.F37F90[loc_ + 11]));
      for (int index1 = 220; index1 < 237; index1 += 3)
      {
        for (int index2 = 0; index2 < this.SNSItems.Count; ++index2)
        {
          if ((int) this.SNSItems[index2].colorOffset == index1)
            this.SNSItems[index2].SetColour(this.F9CAE0[index1], this.F9CAE0[index1 + 1], this.F9CAE0[index1 + 2]);
        }
      }
      foreach (SNSItem snsItem in this.SNSItems)
        this.items_lb.Items.Add((object) snsItem.name);
    }

    private void populateLevelList()
    {
      for (int index = 0; index < this.SetupFiles.Count; ++index)
        this.level_lb.Items.Add((object) this.SetupFiles[index].name);
    }

    private void items_lb_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        this.selectedItem = this.SNSItems[this.items_lb.SelectedIndex];
        this.particle_pnl.BackColor = this.selectedItem.particle;
        this.unknown_tb.Text = this.selectedItem.unknown.ToString("x");
        this.enableEditing();
      }
      catch
      {
        this.disableEditing();
      }
    }

    private void disableEditing()
    {
      this.level_lb.Enabled = false;
      this.update_btn.Enabled = false;
    }

    private void enableEditing()
    {
      this.level_lb.Enabled = true;
      this.update_btn.Enabled = true;
      this.level_lb.SelectedIndex = 0;
      for (int index = 0; index < this.SetupFiles.Count<SetupFile>(); ++index)
      {
        if (this.selectedItem.level == this.SetupFiles[index].sceneID)
          this.level_lb.SelectedIndex = index;
      }
    }

    private void update_btn_Click(object sender, EventArgs e)
    {
      this.F37F90[this.selectedItem.loc + 3] = (byte) this.SetupFiles[this.level_lb.SelectedIndex].sceneID;
      this.F37F90[this.selectedItem.loc + 7] = Convert.ToByte(this.unknown_tb.Text, 16);
      this.F9CAE0[(int) this.selectedItem.colorOffset] = this.particle_pnl.BackColor.R;
      this.F9CAE0[(int) this.selectedItem.colorOffset + 1] = this.particle_pnl.BackColor.G;
      this.F9CAE0[(int) this.selectedItem.colorOffset + 2] = this.particle_pnl.BackColor.B;
      this.updatedRom = true;
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
        Bitmap bitmap = new Bitmap(this.colorPick_pbx.Width, this.colorPick_pbx.Height);
        using (Graphics graphics = Graphics.FromImage((Image) bitmap))
        {
          graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
          graphics.DrawImage(this.colorPick_pbx.Image, 0, 0, bitmap.Width, bitmap.Height);
        }
        this.particle_pnl.BackColor = bitmap.GetPixel(e.X, e.Y);
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SNSEditor));
            this.level_lb = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.update_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.items_lb = new System.Windows.Forms.ListBox();
            this.particle_pnl = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.colorPick_pbx = new System.Windows.Forms.PictureBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.unknown_tb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorPick_pbx)).BeginInit();
            this.SuspendLayout();
            // 
            // level_lb
            // 
            this.level_lb.FormattingEnabled = true;
            this.level_lb.ItemHeight = 16;
            this.level_lb.Location = new System.Drawing.Point(348, 44);
            this.level_lb.Margin = new System.Windows.Forms.Padding(4);
            this.level_lb.Name = "level_lb";
            this.level_lb.Size = new System.Drawing.Size(272, 388);
            this.level_lb.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Item";
            // 
            // update_btn
            // 
            this.update_btn.Location = new System.Drawing.Point(633, 44);
            this.update_btn.Margin = new System.Windows.Forms.Padding(4);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(100, 28);
            this.update_btn.TabIndex = 10;
            this.update_btn.Text = "Update";
            this.update_btn.UseVisualStyleBackColor = true;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Level";
            // 
            // items_lb
            // 
            this.items_lb.FormattingEnabled = true;
            this.items_lb.ItemHeight = 16;
            this.items_lb.Location = new System.Drawing.Point(23, 44);
            this.items_lb.Margin = new System.Windows.Forms.Padding(4);
            this.items_lb.Name = "items_lb";
            this.items_lb.Size = new System.Drawing.Size(272, 244);
            this.items_lb.TabIndex = 8;
            this.items_lb.SelectedIndexChanged += new System.EventHandler(this.items_lb_SelectedIndexChanged);
            // 
            // particle_pnl
            // 
            this.particle_pnl.BackColor = System.Drawing.Color.White;
            this.particle_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.particle_pnl.Location = new System.Drawing.Point(25, 313);
            this.particle_pnl.Margin = new System.Windows.Forms.Padding(4);
            this.particle_pnl.Name = "particle_pnl";
            this.particle_pnl.Size = new System.Drawing.Size(270, 39);
            this.particle_pnl.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 293);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Particle Colour";
            // 
            // colorPick_pbx
            // 
            this.colorPick_pbx.Image = ((System.Drawing.Image)(resources.GetObject("colorPick_pbx.Image")));
            this.colorPick_pbx.Location = new System.Drawing.Point(25, 359);
            this.colorPick_pbx.Margin = new System.Windows.Forms.Padding(4);
            this.colorPick_pbx.Name = "colorPick_pbx";
            this.colorPick_pbx.Size = new System.Drawing.Size(273, 103);
            this.colorPick_pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.colorPick_pbx.TabIndex = 41;
            this.colorPick_pbx.TabStop = false;
            this.colorPick_pbx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPick_pbx_MouseDown);
            this.colorPick_pbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorPick_pbx_MouseMove);
            this.colorPick_pbx.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPick_pbx_MouseUp);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(344, 449);
            this.lbl4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(70, 17);
            this.lbl4.TabIndex = 42;
            this.lbl4.Text = "Unknown:";
            // 
            // unknown_tb
            // 
            this.unknown_tb.Location = new System.Drawing.Point(488, 446);
            this.unknown_tb.Margin = new System.Windows.Forms.Padding(4);
            this.unknown_tb.Name = "unknown_tb";
            this.unknown_tb.Size = new System.Drawing.Size(132, 22);
            this.unknown_tb.TabIndex = 43;
            // 
            // SNSEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 485);
            this.Controls.Add(this.unknown_tb);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.colorPick_pbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.particle_pnl);
            this.Controls.Add(this.level_lb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.update_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.items_lb);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SNSEditor";
            this.ShowIcon = false;
            this.Text = "SNS Editor";
            ((System.ComponentModel.ISupportInitialize)(this.colorPick_pbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
