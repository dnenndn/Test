namespace GMAO
{
	// Token: 0x020000B4 RID: 180
	public partial class ot_diagnostic_arbre : global::System.Windows.Forms.Form
	{
		// Token: 0x06000827 RID: 2087 RVA: 0x0015FA7C File Offset: 0x0015DC7C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0015FAB4 File Offset: 0x0015DCB4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.ot_diagnostic_arbre));
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radDiagram1 = new global::Telerik.WinControls.UI.RadDiagram();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.label30 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.radCheckBox1 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.radCheckBox2 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.radCheckBox3 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.radCheckBox4 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.radCheckBox5 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton3 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton4 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radDiagram1.BeginInit();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			this.radButton1.BeginInit();
			this.radCheckBox1.BeginInit();
			this.radCheckBox2.BeginInit();
			this.radCheckBox3.BeginInit();
			this.radCheckBox4.BeginInit();
			this.radCheckBox5.BeginInit();
			this.panel2.SuspendLayout();
			this.radRadioButton1.BeginInit();
			this.radRadioButton2.BeginInit();
			this.radRadioButton3.BeginInit();
			this.radRadioButton4.BeginInit();
			base.SuspendLayout();
			this.radDiagram1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radDiagram1.IsBackgroundSurfaceVisible = false;
			this.radDiagram1.IsDraggingEnabled = false;
			this.radDiagram1.IsEditable = false;
			this.radDiagram1.Location = new global::System.Drawing.Point(8, 4);
			this.radDiagram1.Name = "radDiagram1";
			this.radDiagram1.SelectionMode = 3;
			this.radDiagram1.SerializedXml = componentResourceManager.GetString("radDiagram1.SerializedXml");
			this.radDiagram1.Size = new global::System.Drawing.Size(781, 227);
			this.radDiagram1.TabIndex = 168;
			this.radDiagram1.Text = "radDiagram1";
			((global::Telerik.WinControls.UI.RadDiagramElement)this.radDiagram1.GetChildAt(0)).Zoom = 1.0;
			((global::Telerik.WinControls.UI.RadDiagramElement)this.radDiagram1.GetChildAt(0)).IsBackgroundSurfaceVisible = false;
			((global::Telerik.WinControls.UI.RadDiagramElement)this.radDiagram1.GetChildAt(0)).IsEditable = false;
			((global::Telerik.WinControls.UI.RadDiagramElement)this.radDiagram1.GetChildAt(0)).IsDraggingEnabled = false;
			((global::Telerik.WinControls.UI.RadDiagramElement)this.radDiagram1.GetChildAt(0)).IsManipulationAdornerVisible = true;
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.radCheckBox5);
			this.panel1.Controls.Add(this.radCheckBox4);
			this.panel1.Controls.Add(this.radCheckBox3);
			this.panel1.Controls.Add(this.radCheckBox2);
			this.panel1.Controls.Add(this.radCheckBox1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label30);
			this.panel1.Controls.Add(this.radButton1);
			this.panel1.Controls.Add(this.pictureBox3);
			this.panel1.Location = new global::System.Drawing.Point(813, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(238, 227);
			this.panel1.TabIndex = 169;
			this.pictureBox3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(185, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(27, 22);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 279;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click);
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(5, 200);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 278;
			this.radButton1.Text = "Enregistrer";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.DimGray;
			this.label30.Location = new global::System.Drawing.Point(3, 6);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(88, 12);
			this.label30.TabIndex = 280;
			this.label30.Text = "ID Défaillance :";
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(90, 6);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(39, 12);
			this.label1.TabIndex = 281;
			this.label1.Text = "label1";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label2.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(3, 25);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(106, 12);
			this.label2.TabIndex = 282;
			this.label2.Text = "Code Défaillance :";
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label3.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(110, 25);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(39, 12);
			this.label3.TabIndex = 283;
			this.label3.Text = "label3";
			this.radCheckBox1.Location = new global::System.Drawing.Point(5, 65);
			this.radCheckBox1.Name = "radCheckBox1";
			this.radCheckBox1.Size = new global::System.Drawing.Size(61, 18);
			this.radCheckBox1.TabIndex = 284;
			this.radCheckBox1.Text = "Milieu";
			this.radCheckBox1.ThemeName = "Crystal";
			this.radCheckBox2.Location = new global::System.Drawing.Point(5, 89);
			this.radCheckBox2.Name = "radCheckBox2";
			this.radCheckBox2.Size = new global::System.Drawing.Size(107, 18);
			this.radCheckBox2.TabIndex = 285;
			this.radCheckBox2.Text = "Main-d'œuvre";
			this.radCheckBox2.ThemeName = "Crystal";
			this.radCheckBox3.Location = new global::System.Drawing.Point(5, 113);
			this.radCheckBox3.Name = "radCheckBox3";
			this.radCheckBox3.Size = new global::System.Drawing.Size(78, 18);
			this.radCheckBox3.TabIndex = 286;
			this.radCheckBox3.Text = "Méthode";
			this.radCheckBox3.ThemeName = "Crystal";
			this.radCheckBox4.Location = new global::System.Drawing.Point(5, 137);
			this.radCheckBox4.Name = "radCheckBox4";
			this.radCheckBox4.Size = new global::System.Drawing.Size(74, 18);
			this.radCheckBox4.TabIndex = 287;
			this.radCheckBox4.Text = "Matériel";
			this.radCheckBox4.ThemeName = "Crystal";
			this.radCheckBox5.Location = new global::System.Drawing.Point(5, 161);
			this.radCheckBox5.Name = "radCheckBox5";
			this.radCheckBox5.Size = new global::System.Drawing.Size(70, 18);
			this.radCheckBox5.TabIndex = 288;
			this.radCheckBox5.Text = "Matière";
			this.radCheckBox5.ThemeName = "Crystal";
			this.label4.AutoSize = true;
			this.label4.BackColor = global::System.Drawing.Color.Transparent;
			this.label4.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label4.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label4.Location = new global::System.Drawing.Point(3, 47);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(21, 12);
			this.label4.TabIndex = 289;
			this.label4.Text = "5M";
			this.label11.AutoSize = true;
			this.label11.BackColor = global::System.Drawing.Color.Transparent;
			this.label11.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label11.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label11.Location = new global::System.Drawing.Point(110, 47);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(59, 12);
			this.label11.TabIndex = 300;
			this.label11.Text = "Détection";
			this.panel2.Controls.Add(this.radRadioButton4);
			this.panel2.Controls.Add(this.radRadioButton3);
			this.panel2.Controls.Add(this.radRadioButton2);
			this.panel2.Controls.Add(this.radRadioButton1);
			this.panel2.Location = new global::System.Drawing.Point(107, 62);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(105, 130);
			this.panel2.TabIndex = 301;
			this.radRadioButton1.Location = new global::System.Drawing.Point(3, 7);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(72, 22);
			this.radRadioButton1.TabIndex = 0;
			this.radRadioButton1.Text = "Difficile";
			this.radRadioButton1.ThemeName = "Crystal";
			this.radRadioButton2.Location = new global::System.Drawing.Point(3, 35);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(97, 22);
			this.radRadioButton2.TabIndex = 1;
			this.radRadioButton2.Text = "Démontage";
			this.radRadioButton2.ThemeName = "Crystal";
			this.radRadioButton3.Location = new global::System.Drawing.Point(3, 63);
			this.radRadioButton3.Name = "radRadioButton3";
			this.radRadioButton3.Size = new global::System.Drawing.Size(96, 22);
			this.radRadioButton3.TabIndex = 2;
			this.radRadioButton3.Text = "Vérification";
			this.radRadioButton3.ThemeName = "Crystal";
			this.radRadioButton4.Location = new global::System.Drawing.Point(4, 91);
			this.radRadioButton4.Name = "radRadioButton4";
			this.radRadioButton4.Size = new global::System.Drawing.Size(70, 22);
			this.radRadioButton4.TabIndex = 3;
			this.radRadioButton4.Text = "Alarme";
			this.radRadioButton4.ThemeName = "Crystal";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.radDiagram1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_diagnostic_arbre";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_diagnostic_arbre_Load);
			this.radDiagram1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			this.radButton1.EndInit();
			this.radCheckBox1.EndInit();
			this.radCheckBox2.EndInit();
			this.radCheckBox3.EndInit();
			this.radCheckBox4.EndInit();
			this.radCheckBox5.EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.radRadioButton1.EndInit();
			this.radRadioButton2.EndInit();
			this.radRadioButton3.EndInit();
			this.radRadioButton4.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000B1F RID: 2847
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000B20 RID: 2848
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000B21 RID: 2849
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000B22 RID: 2850
		private global::Telerik.WinControls.UI.RadDiagram radDiagram1;

		// Token: 0x04000B23 RID: 2851
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000B24 RID: 2852
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000B25 RID: 2853
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000B26 RID: 2854
		internal global::System.Windows.Forms.Label label3;

		// Token: 0x04000B27 RID: 2855
		internal global::System.Windows.Forms.Label label2;

		// Token: 0x04000B28 RID: 2856
		internal global::System.Windows.Forms.Label label1;

		// Token: 0x04000B29 RID: 2857
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000B2A RID: 2858
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox5;

		// Token: 0x04000B2B RID: 2859
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox4;

		// Token: 0x04000B2C RID: 2860
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox3;

		// Token: 0x04000B2D RID: 2861
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox2;

		// Token: 0x04000B2E RID: 2862
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox1;

		// Token: 0x04000B2F RID: 2863
		internal global::System.Windows.Forms.Label label4;

		// Token: 0x04000B30 RID: 2864
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000B31 RID: 2865
		internal global::System.Windows.Forms.Label label11;

		// Token: 0x04000B32 RID: 2866
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton4;

		// Token: 0x04000B33 RID: 2867
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton3;

		// Token: 0x04000B34 RID: 2868
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000B35 RID: 2869
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;
	}
}
