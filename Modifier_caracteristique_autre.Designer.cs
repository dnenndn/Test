namespace GMAO
{
	// Token: 0x0200009A RID: 154
	public partial class Modifier_caracteristique_autre : global::System.Windows.Forms.Form
	{
		// Token: 0x06000706 RID: 1798 RVA: 0x001335F4 File Offset: 0x001317F4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x0013362C File Offset: 0x0013182C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.Modifier_caracteristique_autre));
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn = new global::Telerik.WinControls.UI.GridViewCheckBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radCheckBox1 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.ComboBox1 = new global::Guna.UI2.WinForms.Guna2ComboBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.desertTheme1 = new global::Telerik.WinControls.Themes.DesertTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radCheckBox1.BeginInit();
			this.panel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(627, 19);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 98;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.radCheckBox1.CheckAlignment = global::System.Drawing.ContentAlignment.MiddleRight;
			this.radCheckBox1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radCheckBox1.Location = new global::System.Drawing.Point(586, 104);
			this.radCheckBox1.Name = "radCheckBox1";
			this.radCheckBox1.Size = new global::System.Drawing.Size(145, 18);
			this.radCheckBox1.TabIndex = 97;
			this.radCheckBox1.Text = "Champs Obligatoire";
			this.radCheckBox1.ThemeName = "Crystal";
			this.TextBox1.BorderRadius = 2;
			this.TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox1.DefaultText = "";
			this.TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.DisabledState.Parent = this.TextBox1;
			this.TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.FocusedState.Parent = this.TextBox1;
			this.TextBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.HoverState.Parent = this.TextBox1;
			this.TextBox1.Location = new global::System.Drawing.Point(12, 97);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(284, 29);
			this.TextBox1.TabIndex = 96;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(8, 75);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(39, 19);
			this.label3.TabIndex = 95;
			this.label3.Text = "Nom";
			this.ComboBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.ComboBox1.BorderRadius = 2;
			this.ComboBox1.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.ComboBox1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox1.FocusedColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.ComboBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.ComboBox1.FocusedState.Parent = this.ComboBox1;
			this.ComboBox1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ComboBox1.ForeColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.ComboBox1.HoverState.Parent = this.ComboBox1;
			this.ComboBox1.ItemHeight = 24;
			this.ComboBox1.ItemsAppearance.Parent = this.ComboBox1;
			this.ComboBox1.Location = new global::System.Drawing.Point(306, 97);
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.ShadowDecoration.Parent = this.ComboBox1;
			this.ComboBox1.Size = new global::System.Drawing.Size(274, 30);
			this.ComboBox1.TabIndex = 94;
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(302, 75);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(39, 19);
			this.label10.TabIndex = 93;
			this.label10.Text = "Type";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(12, 47);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(166, 19);
			this.label1.TabIndex = 92;
			this.label1.Text = "Modifier Caractéristique";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(145, 19);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(49, 19);
			this.label6.TabIndex = 91;
			this.label6.Text = "label6";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(12, 19);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(136, 19);
			this.label4.TabIndex = 90;
			this.label4.Text = "ID caractéristique :";
			this.panel3.Controls.Add(this.pictureBox1);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.guna2TextBox1);
			this.panel3.Location = new global::System.Drawing.Point(16, 133);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(617, 85);
			this.panel3.TabIndex = 99;
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(300, 31);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(46, 29);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 84;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.Black;
			this.label9.Location = new global::System.Drawing.Point(6, 9);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(53, 19);
			this.label9.TabIndex = 80;
			this.label9.Text = "Option";
			this.guna2TextBox1.BorderRadius = 2;
			this.guna2TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox1.DefaultText = "";
			this.guna2TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Location = new global::System.Drawing.Point(10, 31);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(284, 29);
			this.guna2TextBox1.TabIndex = 83;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.Location = new global::System.Drawing.Point(12, 224);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.AllowSort = false;
			gridViewTextBoxColumn.HeaderText = "Option";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column1";
			gridViewTextBoxColumn.Width = 250;
			gridViewCheckBoxColumn.HeaderText = "Valeur par défaut";
			gridViewCheckBoxColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewCheckBoxColumn.Name = "column4";
			gridViewCheckBoxColumn.Width = 150;
			gridViewImageColumn.HeaderText = "";
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column6";
			gridViewImageColumn.Width = 60;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewCheckBoxColumn,
				gridViewImageColumn
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
			this.radGridView1.MasterTemplate.EnableSorting = false;
			this.radGridView1.MasterTemplate.ShowFilteringRow = false;
			this.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.Size = new global::System.Drawing.Size(621, 236);
			this.radGridView1.TabIndex = 100;
			this.radGridView1.ThemeName = "Desert";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(800, 498);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radCheckBox1);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.ComboBox1);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label4);
			base.Name = "Modifier_caracteristique_autre";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.Modifier_caracteristique_autre_Load);
			this.radCheckBox1.EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000976 RID: 2422
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000977 RID: 2423
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000978 RID: 2424
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox1;

		// Token: 0x04000979 RID: 2425
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x0400097A RID: 2426
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400097B RID: 2427
		private global::Guna.UI2.WinForms.Guna2ComboBox ComboBox1;

		// Token: 0x0400097C RID: 2428
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400097D RID: 2429
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400097E RID: 2430
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400097F RID: 2431
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000980 RID: 2432
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000981 RID: 2433
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000982 RID: 2434
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000983 RID: 2435
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000984 RID: 2436
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04000985 RID: 2437
		private global::Telerik.WinControls.Themes.DesertTheme desertTheme1;

		// Token: 0x04000986 RID: 2438
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
	}
}
