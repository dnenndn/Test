namespace GMAO
{
	// Token: 0x02000154 RID: 340
	public partial class parametre_fournisseur_compte : global::System.Windows.Forms.Form
	{
		// Token: 0x06000F28 RID: 3880 RVA: 0x00249E04 File Offset: 0x00248004
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F29 RID: 3881 RVA: 0x00249E3C File Offset: 0x0024803C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.parametre_fournisseur_compte));
			this.label2 = new global::System.Windows.Forms.Label();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.TextBox3 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.TextBox4 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.guna2ComboBox1 = new global::Guna.UI2.WinForms.Guna2ComboBox();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.breezeTheme1 = new global::Telerik.WinControls.Themes.BreezeTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radChartView1.BeginInit();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label2.Location = new global::System.Drawing.Point(12, 18);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(189, 19);
			this.label2.TabIndex = 74;
			this.label2.Text = "Ajouter Compte Fournisseur";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(465, 142);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 86;
			this.guna2Button1.Text = "Ajouter";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
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
			this.TextBox2.Location = new global::System.Drawing.Point(177, 78);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(282, 29);
			this.TextBox2.TabIndex = 85;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(173, 56);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(87, 19);
			this.label3.TabIndex = 84;
			this.label3.Text = "Désignation";
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
			this.TextBox1.Location = new global::System.Drawing.Point(16, 78);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(141, 29);
			this.TextBox1.TabIndex = 83;
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(12, 56);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(78, 19);
			this.label10.TabIndex = 82;
			this.label10.Text = "N° Compte";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(12, 121);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(134, 19);
			this.label1.TabIndex = 87;
			this.label1.Text = "Estimation (Dinars)";
			this.TextBox3.BorderRadius = 2;
			this.TextBox3.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox3.DefaultText = "";
			this.TextBox3.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox3.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox3.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox3.DisabledState.Parent = this.TextBox3;
			this.TextBox3.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox3.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox3.FocusedState.Parent = this.TextBox3;
			this.TextBox3.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox3.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox3.HoverState.Parent = this.TextBox3;
			this.TextBox3.Location = new global::System.Drawing.Point(16, 143);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.PasswordChar = '\0';
			this.TextBox3.PlaceholderText = "";
			this.TextBox3.SelectedText = "";
			this.TextBox3.ShadowDecoration.Parent = this.TextBox3;
			this.TextBox3.Size = new global::System.Drawing.Size(141, 29);
			this.TextBox3.TabIndex = 88;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(173, 121);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(110, 19);
			this.label4.TabIndex = 89;
			this.label4.Text = "Sur une Période";
			this.TextBox4.BorderRadius = 2;
			this.TextBox4.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox4.DefaultText = "";
			this.TextBox4.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox4.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox4.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox4.DisabledState.Parent = this.TextBox4;
			this.TextBox4.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox4.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox4.FocusedState.Parent = this.TextBox4;
			this.TextBox4.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox4.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox4.HoverState.Parent = this.TextBox4;
			this.TextBox4.Location = new global::System.Drawing.Point(177, 143);
			this.TextBox4.Name = "TextBox4";
			this.TextBox4.PasswordChar = '\0';
			this.TextBox4.PlaceholderText = "";
			this.TextBox4.SelectedText = "";
			this.TextBox4.ShadowDecoration.Parent = this.TextBox4;
			this.TextBox4.Size = new global::System.Drawing.Size(141, 29);
			this.TextBox4.TabIndex = 90;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Black;
			this.label5.Location = new global::System.Drawing.Point(332, 121);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(58, 19);
			this.label5.TabIndex = 91;
			this.label5.Text = "Période";
			this.guna2ComboBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ComboBox1.BorderRadius = 2;
			this.guna2ComboBox1.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.guna2ComboBox1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.guna2ComboBox1.FocusedColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2ComboBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2ComboBox1.FocusedState.Parent = this.guna2ComboBox1;
			this.guna2ComboBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2ComboBox1.ForeColor = global::System.Drawing.Color.FromArgb(68, 88, 112);
			this.guna2ComboBox1.HoverState.Parent = this.guna2ComboBox1;
			this.guna2ComboBox1.ItemHeight = 23;
			this.guna2ComboBox1.ItemsAppearance.Parent = this.guna2ComboBox1;
			this.guna2ComboBox1.Location = new global::System.Drawing.Point(336, 143);
			this.guna2ComboBox1.Name = "guna2ComboBox1";
			this.guna2ComboBox1.ShadowDecoration.Parent = this.guna2ComboBox1;
			this.guna2ComboBox1.Size = new global::System.Drawing.Size(123, 29);
			this.guna2ComboBox1.TabIndex = 92;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.Location = new global::System.Drawing.Point(16, 178);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "id";
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column7";
			gridViewTextBoxColumn2.HeaderText = "N° Compte";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column5";
			gridViewTextBoxColumn2.Width = 80;
			gridViewTextBoxColumn3.AllowSort = false;
			gridViewTextBoxColumn3.HeaderText = "Désignation";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 180;
			gridViewTextBoxColumn4.AllowSort = false;
			gridViewTextBoxColumn4.HeaderText = "Estimation";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column2";
			gridViewTextBoxColumn4.Width = 110;
			gridViewTextBoxColumn5.HeaderText = "Période";
			gridViewTextBoxColumn5.Name = "column3";
			gridViewTextBoxColumn5.Width = 120;
			gridViewImageColumn.HeaderText = "";
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column4";
			gridViewImageColumn.Width = 60;
			gridViewImageColumn2.HeaderText = "";
			gridViewImageColumn2.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn2.Name = "column6";
			gridViewImageColumn2.Width = 60;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewImageColumn,
				gridViewImageColumn2
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
			this.radGridView1.MasterTemplate.EnablePaging = true;
			this.radGridView1.MasterTemplate.EnableSorting = false;
			this.radGridView1.MasterTemplate.ShowFilteringRow = false;
			this.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView1.ReadOnly = true;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.Size = new global::System.Drawing.Size(680, 284);
			this.radGridView1.TabIndex = 93;
			this.radGridView1.ThemeName = "Fluent";
			this.radChartView1.AreaType = 3;
			this.radChartView1.Location = new global::System.Drawing.Point(721, 18);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.Size = new global::System.Drawing.Size(370, 444);
			this.radChartView1.TabIndex = 94;
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-supprimer-pour-toujours-100 (4).png");
			this.imageList1.Images.SetKeyName(1, "icons8-approuver-et-mettre-à-jour-96 (4).png");
			this.imageList1.Images.SetKeyName(2, "imgonline-com-ua-Transparent-background-mY80EJnxkjzbk.png");
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1114, 504);
			base.Controls.Add(this.radChartView1);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.guna2ComboBox1);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.TextBox4);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.TextBox3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "parametre_fournisseur_compte";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.parametre_fournisseur_compte_Load);
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radChartView1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001312 RID: 4882
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001313 RID: 4883
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04001314 RID: 4884
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04001315 RID: 4885
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04001316 RID: 4886
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04001317 RID: 4887
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04001318 RID: 4888
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04001319 RID: 4889
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400131A RID: 4890
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox3;

		// Token: 0x0400131B RID: 4891
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400131C RID: 4892
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox4;

		// Token: 0x0400131D RID: 4893
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400131E RID: 4894
		private global::Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;

		// Token: 0x0400131F RID: 4895
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04001320 RID: 4896
		private global::Telerik.WinControls.UI.RadChartView radChartView1;

		// Token: 0x04001321 RID: 4897
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x04001322 RID: 4898
		private global::Telerik.WinControls.Themes.BreezeTheme breezeTheme1;

		// Token: 0x04001323 RID: 4899
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;
	}
}
