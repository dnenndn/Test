namespace GMAO
{
	// Token: 0x02000127 RID: 295
	public partial class st_matiere_pr : global::System.Windows.Forms.Form
	{
		// Token: 0x06000D0F RID: 3343 RVA: 0x001F9724 File Offset: 0x001F7924
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x001F975C File Offset: 0x001F795C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.st_matiere_pr));
			this.label8 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.guna2TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.radTreeView1 = new global::Telerik.WinControls.UI.RadTreeView();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.office2013LightTheme1 = new global::Telerik.WinControls.Themes.Office2013LightTheme();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radTreeView1.BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label8.Location = new global::System.Drawing.Point(12, 9);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(109, 19);
			this.label8.TabIndex = 210;
			this.label8.Text = "Liste MP sortie";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(659, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(97, 19);
			this.label1.TabIndex = 211;
			this.label1.Text = "ID Demande :";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(759, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(23, 19);
			this.label2.TabIndex = 212;
			this.label2.Text = "ID";
			this.guna2TextBox2.BorderRadius = 15;
			this.guna2TextBox2.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox2.DefaultText = "";
			this.guna2TextBox2.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox2.DisabledState.Parent = this.guna2TextBox2;
			this.guna2TextBox2.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox2.FocusedState.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.guna2TextBox2.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox2.HoverState.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Location = new global::System.Drawing.Point(16, 69);
			this.guna2TextBox2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox2.Name = "guna2TextBox2";
			this.guna2TextBox2.PasswordChar = '\0';
			this.guna2TextBox2.PlaceholderText = "Recherche";
			this.guna2TextBox2.SelectedText = "";
			this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Size = new global::System.Drawing.Size(229, 30);
			this.guna2TextBox2.TabIndex = 213;
			this.guna2TextBox2.TextChanged += new global::System.EventHandler(this.guna2TextBox2_TextChanged);
			this.radTreeView1.Location = new global::System.Drawing.Point(22, 106);
			this.radTreeView1.Name = "radTreeView1";
			this.radTreeView1.RadContextMenu = this.radContextMenu1;
			this.radTreeView1.Size = new global::System.Drawing.Size(223, 352);
			this.radTreeView1.SpacingBetweenNodes = -1;
			this.radTreeView1.TabIndex = 214;
			this.radTreeView1.ThemeName = "Office2010Silver";
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(263, 74);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 80;
			gridViewTextBoxColumn2.AllowSort = false;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Désignation";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.ReadOnly = true;
			gridViewTextBoxColumn2.Width = 225;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Quantité";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 100;
			gridViewTextBoxColumn4.HeaderText = "Unité";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column3";
			gridViewTextBoxColumn4.ReadOnly = true;
			gridViewTextBoxColumn4.Width = 120;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column4";
			gridViewImageColumn.Width = 60;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
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
			this.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.Size = new global::System.Drawing.Size(664, 384);
			this.radGridView1.TabIndex = 215;
			this.radGridView1.ThemeName = "Fluent";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(263, 38);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 216;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radContextMenu1.ThemeName = "Office2010Silver";
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-supprimer-pour-toujours-100 (4).png");
			this.imageList1.Images.SetKeyName(1, "icons8-approuver-et-mettre-à-jour-96 (4).png");
			this.imageList1.Images.SetKeyName(2, "imgonline-com-ua-Transparent-background-mY80EJnxkjzbk (1).ico");
			this.imageList1.Images.SetKeyName(3, "icons8-word-96.png");
			this.imageList1.Images.SetKeyName(4, "icons8-ms-excel-104.png");
			this.imageList1.Images.SetKeyName(5, "icons8-pdf-40.png");
			this.imageList1.Images.SetKeyName(6, "icons8-txt-80.png");
			this.imageList1.Images.SetKeyName(7, "icons8-image-96.png");
			this.imageList1.Images.SetKeyName(8, "icons8-winrar-240.png");
			this.imageList1.Images.SetKeyName(9, "icons8-fichier-128.png");
			this.guna2Button2.BorderRadius = 8;
			this.guna2Button2.CheckedState.Parent = this.guna2Button2;
			this.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button2.CustomImages.Parent = this.guna2Button2;
			this.guna2Button2.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.HoverState.Parent = this.guna2Button2;
			this.guna2Button2.Location = new global::System.Drawing.Point(373, 38);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
			this.guna2Button2.Size = new global::System.Drawing.Size(154, 30);
			this.guna2Button2.TabIndex = 217;
			this.guna2Button2.Text = "Annuler Modification";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(939, 470);
			base.Controls.Add(this.guna2Button2);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.radTreeView1);
			base.Controls.Add(this.guna2TextBox2);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label8);
			base.Name = "st_matiere_pr";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.st_matiere_pr_Load);
			this.radTreeView1.EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400108C RID: 4236
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400108D RID: 4237
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400108E RID: 4238
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400108F RID: 4239
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04001090 RID: 4240
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;

		// Token: 0x04001091 RID: 4241
		private global::Telerik.WinControls.UI.RadTreeView radTreeView1;

		// Token: 0x04001092 RID: 4242
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04001093 RID: 4243
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04001094 RID: 4244
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x04001095 RID: 4245
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x04001096 RID: 4246
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04001097 RID: 4247
		private global::Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;

		// Token: 0x04001098 RID: 4248
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x04001099 RID: 4249
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400109A RID: 4250
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x0400109B RID: 4251
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;
	}
}
