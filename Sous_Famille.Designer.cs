namespace GMAO
{
	// Token: 0x02000161 RID: 353
	public partial class Sous_Famille : global::System.Windows.Forms.Form
	{
		// Token: 0x06000F81 RID: 3969 RVA: 0x00257458 File Offset: 0x00255658
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x00257490 File Offset: 0x00255690
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.Sous_Famille));
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.ComboBox1 = new global::Guna.UI2.WinForms.Guna2ComboBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.label5 = new global::System.Windows.Forms.Label();
			global::GMAO.Sous_Famille.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			global::GMAO.Sous_Famille.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			global::GMAO.Sous_Famille.radPanel1.BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Century Gothic", 14.25f, global::System.Drawing.FontStyle.Bold | global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(123, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Sous Famille";
			this.panel1.Location = new global::System.Drawing.Point(-3, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 4;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label2.Location = new global::System.Drawing.Point(12, 57);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(149, 19);
			this.label2.TabIndex = 49;
			this.label2.Text = "Ajouter Sous Famille";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(12, 90);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(56, 19);
			this.label10.TabIndex = 67;
			this.label10.Text = "Famille";
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
			this.ComboBox1.Location = new global::System.Drawing.Point(16, 112);
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.ShadowDecoration.Parent = this.ComboBox1;
			this.ComboBox1.Size = new global::System.Drawing.Size(274, 30);
			this.ComboBox1.TabIndex = 68;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(295, 90);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(125, 19);
			this.label3.TabIndex = 69;
			this.label3.Text = "Code sous famille";
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
			this.TextBox1.Location = new global::System.Drawing.Point(299, 112);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(284, 29);
			this.TextBox1.TabIndex = 70;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(591, 90);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(87, 19);
			this.label4.TabIndex = 71;
			this.label4.Text = "Désignation";
			this.TextBox2.BorderRadius = 2;
			this.TextBox2.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox2.DefaultText = "";
			this.TextBox2.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox2.DisabledState.Parent = this.TextBox2;
			this.TextBox2.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox2.FocusedState.Parent = this.TextBox2;
			this.TextBox2.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox2.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox2.HoverState.Parent = this.TextBox2;
			this.TextBox2.Location = new global::System.Drawing.Point(595, 112);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(318, 29);
			this.TextBox2.TabIndex = 72;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(925, 112);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 73;
			this.guna2Button1.Text = "Ajouter";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.Location = new global::System.Drawing.Point(16, 203);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "ID Sous Famille";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.Width = 140;
			gridViewTextBoxColumn2.HeaderText = "Famille";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column3";
			gridViewTextBoxColumn2.Width = 130;
			gridViewTextBoxColumn3.AllowSort = false;
			gridViewTextBoxColumn3.HeaderText = "Code Sous Famille";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 160;
			gridViewTextBoxColumn4.AllowSort = false;
			gridViewTextBoxColumn4.HeaderText = "Désignation";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column2";
			gridViewTextBoxColumn4.Width = 200;
			gridViewImageColumn.HeaderText = "";
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column4";
			gridViewImageColumn.Width = 60;
			gridViewImageColumn2.HeaderText = "";
			gridViewImageColumn2.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn2.Name = "column6";
			gridViewImageColumn2.Width = 60;
			gridViewCommandColumn.HeaderText = "";
			gridViewCommandColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewCommandColumn.Name = "column7";
			gridViewCommandColumn.Width = 140;
			gridViewCommandColumn2.HeaderText = "";
			gridViewCommandColumn2.Name = "column8";
			gridViewCommandColumn2.Width = 160;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewImageColumn,
				gridViewImageColumn2,
				gridViewCommandColumn,
				gridViewCommandColumn2
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
			this.radGridView1.MasterTemplate.EnablePaging = true;
			this.radGridView1.MasterTemplate.EnableSorting = false;
			this.radGridView1.MasterTemplate.ShowFilteringRow = false;
			this.radGridView1.MasterTemplate.ShowHeaderCellButtons = true;
			this.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView1.ReadOnly = true;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.ShowHeaderCellButtons = true;
			this.radGridView1.Size = new global::System.Drawing.Size(1103, 219);
			this.radGridView1.TabIndex = 74;
			this.radGridView1.ThemeName = "Fluent";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label5.Location = new global::System.Drawing.Point(12, 170);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(128, 19);
			this.label5.TabIndex = 73;
			this.label5.Text = "Liste Sous Famille";
			global::GMAO.Sous_Famille.radPanel1.AutoScroll = true;
			global::GMAO.Sous_Famille.radPanel1.Location = new global::System.Drawing.Point(16, 428);
			global::GMAO.Sous_Famille.radPanel1.Name = "radPanel1";
			global::GMAO.Sous_Famille.radPanel1.Size = new global::System.Drawing.Size(1013, 172);
			global::GMAO.Sous_Famille.radPanel1.TabIndex = 75;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.Sous_Famille.radPanel1.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			global::GMAO.Sous_Famille.guna2Button2.BorderRadius = 8;
			global::GMAO.Sous_Famille.guna2Button2.CheckedState.Parent = global::GMAO.Sous_Famille.guna2Button2;
			global::GMAO.Sous_Famille.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			global::GMAO.Sous_Famille.guna2Button2.CustomImages.Parent = global::GMAO.Sous_Famille.guna2Button2;
			global::GMAO.Sous_Famille.guna2Button2.FillColor = global::System.Drawing.Color.Silver;
			global::GMAO.Sous_Famille.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			global::GMAO.Sous_Famille.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			global::GMAO.Sous_Famille.guna2Button2.HoverState.Parent = global::GMAO.Sous_Famille.guna2Button2;
			global::GMAO.Sous_Famille.guna2Button2.Location = new global::System.Drawing.Point(1037, 428);
			global::GMAO.Sous_Famille.guna2Button2.Name = "guna2Button2";
			global::GMAO.Sous_Famille.guna2Button2.ShadowDecoration.Parent = global::GMAO.Sous_Famille.guna2Button2;
			global::GMAO.Sous_Famille.guna2Button2.Size = new global::System.Drawing.Size(78, 28);
			global::GMAO.Sous_Famille.guna2Button2.TabIndex = 76;
			global::GMAO.Sous_Famille.guna2Button2.Text = "Fermer";
			global::GMAO.Sous_Famille.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-supprimer-pour-toujours-100 (4).png");
			this.imageList1.Images.SetKeyName(1, "icons8-approuver-et-mettre-à-jour-96 (4).png");
			this.imageList1.Images.SetKeyName(2, "imgonline-com-ua-Transparent-background-mY80EJnxkjzbk (1).ico");
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(global::GMAO.Sous_Famille.guna2Button2);
			base.Controls.Add(global::GMAO.Sous_Famille.radPanel1);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.ComboBox1);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Sous_Famille";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.Sous_Famille_Load);
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			global::GMAO.Sous_Famille.radPanel1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001394 RID: 5012
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001395 RID: 5013
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04001396 RID: 5014
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04001397 RID: 5015
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04001398 RID: 5016
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04001399 RID: 5017
		private global::Guna.UI2.WinForms.Guna2ComboBox ComboBox1;

		// Token: 0x0400139A RID: 5018
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400139B RID: 5019
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x0400139C RID: 5020
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400139D RID: 5021
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x0400139E RID: 5022
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x0400139F RID: 5023
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x040013A0 RID: 5024
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040013A1 RID: 5025
		private static global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x040013A2 RID: 5026
		private static global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x040013A3 RID: 5027
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040013A4 RID: 5028
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x040013A5 RID: 5029
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
	}
}
