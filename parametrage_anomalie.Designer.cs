namespace GMAO
{
	// Token: 0x020000EE RID: 238
	public partial class parametrage_anomalie : global::System.Windows.Forms.Form
	{
		// Token: 0x06000A5A RID: 2650 RVA: 0x0019AC18 File Offset: 0x00198E18
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x0019AC50 File Offset: 0x00198E50
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.label3 = new global::System.Windows.Forms.Label();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.radPanel1.BeginInit();
			this.radPanel1.SuspendLayout();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.radPanel1.Controls.Add(this.guna2Button2);
			this.radPanel1.Controls.Add(this.TextBox1);
			this.radPanel1.Controls.Add(this.guna2Button1);
			this.radPanel1.Controls.Add(this.TextBox2);
			this.radPanel1.Controls.Add(this.label1);
			this.radPanel1.Controls.Add(this.label10);
			this.radPanel1.Controls.Add(this.label2);
			this.radPanel1.Location = new global::System.Drawing.Point(12, 12);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Size = new global::System.Drawing.Size(1080, 158);
			this.radPanel1.TabIndex = 0;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel1.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button2.BorderRadius = 8;
			this.guna2Button2.CheckedState.Parent = this.guna2Button2;
			this.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button2.CustomImages.Parent = this.guna2Button2;
			this.guna2Button2.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.HoverState.Parent = this.guna2Button2;
			this.guna2Button2.Location = new global::System.Drawing.Point(825, 38);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
			this.guna2Button2.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button2.TabIndex = 166;
			this.guna2Button2.Text = "Annuler";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
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
			this.TextBox1.Location = new global::System.Drawing.Point(17, 75);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(252, 29);
			this.TextBox1.TabIndex = 165;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(935, 38);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 83;
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
			this.TextBox2.Location = new global::System.Drawing.Point(287, 75);
			this.TextBox2.Multiline = true;
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(752, 67);
			this.TextBox2.TabIndex = 164;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(283, 49);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(83, 19);
			this.label1.TabIndex = 163;
			this.label1.Text = "Défaillance";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(13, 49);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(120, 19);
			this.label10.TabIndex = 76;
			this.label10.Text = "Code Défaillance";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label2.Location = new global::System.Drawing.Point(13, 15);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(130, 19);
			this.label2.TabIndex = 75;
			this.label2.Text = "Ajouter Anomalie";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label3.Location = new global::System.Drawing.Point(12, 191);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(142, 19);
			this.label3.TabIndex = 76;
			this.label3.Text = "Liste des Anomalies";
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.Location = new global::System.Drawing.Point(12, 213);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "id_famille";
			gridViewTextBoxColumn.Width = 150;
			gridViewTextBoxColumn2.HeaderText = "Code Défaillance";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 170;
			gridViewTextBoxColumn3.AllowSort = false;
			gridViewTextBoxColumn3.HeaderText = "Défaillance";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 580;
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
				gridViewImageColumn,
				gridViewImageColumn2
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
			this.radGridView1.ReadOnly = true;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.Size = new global::System.Drawing.Size(1087, 276);
			this.radGridView1.TabIndex = 82;
			this.radGridView1.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 501);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.radPanel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "parametrage_anomalie";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.parametrage_anomalie_Load);
			this.radPanel1.EndInit();
			this.radPanel1.ResumeLayout(false);
			this.radPanel1.PerformLayout();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000D59 RID: 3417
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000D5A RID: 3418
		private global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x04000D5B RID: 3419
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000D5C RID: 3420
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000D5D RID: 3421
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000D5E RID: 3422
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000D5F RID: 3423
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000D60 RID: 3424
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04000D61 RID: 3425
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000D62 RID: 3426
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04000D63 RID: 3427
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000D64 RID: 3428
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000D65 RID: 3429
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;
	}
}
