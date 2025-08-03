namespace GMAO
{
	// Token: 0x0200000C RID: 12
	public partial class ajouter_caractéristique : global::System.Windows.Forms.Form
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x000212C0 File Offset: 0x0001F4C0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000212F8 File Offset: 0x0001F4F8
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn = new global::Telerik.WinControls.UI.GridViewCheckBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.ajouter_caractéristique));
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.ComboBox1 = new global::Guna.UI2.WinForms.Guna2ComboBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.radCheckBox1 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.aquaTheme1 = new global::Telerik.WinControls.Themes.AquaTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			global::GMAO.ajouter_caractéristique.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.desertTheme1 = new global::Telerik.WinControls.Themes.DesertTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			global::GMAO.ajouter_caractéristique.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.materialBlueGreyTheme1 = new global::Telerik.WinControls.Themes.MaterialBlueGreyTheme();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radCheckBox1.BeginInit();
			global::GMAO.ajouter_caractéristique.radGridView1.BeginInit();
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.DimGray;
			this.label7.Location = new global::System.Drawing.Point(115, 35);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(49, 19);
			this.label7.TabIndex = 14;
			this.label7.Text = "label7";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(127, 9);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(49, 19);
			this.label6.TabIndex = 13;
			this.label6.Text = "label6";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DimGray;
			this.label5.Location = new global::System.Drawing.Point(12, 35);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(97, 19);
			this.label5.TabIndex = 12;
			this.label5.Text = "Désignation :";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(12, 9);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(118, 19);
			this.label4.TabIndex = 11;
			this.label4.Text = "Id Sous Famille :";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(12, 72);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(159, 19);
			this.label1.TabIndex = 74;
			this.label1.Text = "Ajouter Caractéristique";
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
			this.TextBox1.Location = new global::System.Drawing.Point(16, 125);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(284, 29);
			this.TextBox1.TabIndex = 78;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(12, 103);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(39, 19);
			this.label3.TabIndex = 77;
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
			this.ComboBox1.Location = new global::System.Drawing.Point(310, 125);
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.ShadowDecoration.Parent = this.ComboBox1;
			this.ComboBox1.Size = new global::System.Drawing.Size(274, 30);
			this.ComboBox1.TabIndex = 76;
			this.ComboBox1.SelectedIndexChanged += new global::System.EventHandler(this.ComboBox1_SelectedIndexChanged);
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(306, 103);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(39, 19);
			this.label10.TabIndex = 75;
			this.label10.Text = "Type";
			this.radCheckBox1.CheckAlignment = global::System.Drawing.ContentAlignment.MiddleRight;
			this.radCheckBox1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radCheckBox1.Location = new global::System.Drawing.Point(590, 132);
			this.radCheckBox1.Name = "radCheckBox1";
			this.radCheckBox1.Size = new global::System.Drawing.Size(145, 18);
			this.radCheckBox1.TabIndex = 79;
			this.radCheckBox1.Text = "Champs Obligatoire";
			this.radCheckBox1.ThemeName = "Crystal";
			global::GMAO.ajouter_caractéristique.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.ajouter_caractéristique.radGridView1.Location = new global::System.Drawing.Point(16, 240);
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.AllowAddNewRow = false;
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.AllowColumnReorder = false;
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.AllowDeleteRow = false;
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.AllowDragToGroup = false;
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
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
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewCheckBoxColumn,
				gridViewImageColumn
			});
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.EnableFiltering = true;
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.EnableSorting = false;
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.ShowFilteringRow = false;
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			global::GMAO.ajouter_caractéristique.radGridView1.Name = "radGridView1";
			global::GMAO.ajouter_caractéristique.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			global::GMAO.ajouter_caractéristique.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.ajouter_caractéristique.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			global::GMAO.ajouter_caractéristique.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			global::GMAO.ajouter_caractéristique.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			global::GMAO.ajouter_caractéristique.radGridView1.ShowGroupPanel = false;
			global::GMAO.ajouter_caractéristique.radGridView1.Size = new global::System.Drawing.Size(568, 173);
			global::GMAO.ajouter_caractéristique.radGridView1.TabIndex = 85;
			global::GMAO.ajouter_caractéristique.radGridView1.ThemeName = "Desert";
			this.panel2.Location = new global::System.Drawing.Point(6, 160);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(617, 77);
			this.panel2.TabIndex = 87;
			global::GMAO.ajouter_caractéristique.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			global::GMAO.ajouter_caractéristique.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			global::GMAO.ajouter_caractéristique.imageList1.Images.SetKeyName(0, "icons8-supprimer-pour-toujours-100.png");
			global::GMAO.ajouter_caractéristique.imageList1.Images.SetKeyName(1, "icons8-approuver-et-mettre-à-jour-96 (1).png");
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(631, 9);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 88;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(800, 443);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(global::GMAO.ajouter_caractéristique.radGridView1);
			base.Controls.Add(this.radCheckBox1);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.ComboBox1);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Name = "ajouter_caractéristique";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new global::System.EventHandler(this.ajouter_caractéristique_Load);
			this.radCheckBox1.EndInit();
			global::GMAO.ajouter_caractéristique.radGridView1.MasterTemplate.EndInit();
			global::GMAO.ajouter_caractéristique.radGridView1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000FE RID: 254
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000103 RID: 259
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000104 RID: 260
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000105 RID: 261
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000106 RID: 262
		private global::Guna.UI2.WinForms.Guna2ComboBox ComboBox1;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000108 RID: 264
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox1;

		// Token: 0x04000109 RID: 265
		private global::Telerik.WinControls.Themes.AquaTheme aquaTheme1;

		// Token: 0x0400010A RID: 266
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400010C RID: 268
		private global::Telerik.WinControls.Themes.DesertTheme desertTheme1;

		// Token: 0x0400010D RID: 269
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400010E RID: 270
		private global::Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;

		// Token: 0x0400010F RID: 271
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000110 RID: 272
		private static global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04000111 RID: 273
		private static global::System.Windows.Forms.ImageList imageList1;
	}
}
