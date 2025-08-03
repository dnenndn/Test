namespace GMAO
{
	// Token: 0x020000CA RID: 202
	public partial class ot_ordonnancement_intervention : global::System.Windows.Forms.Form
	{
		// Token: 0x06000914 RID: 2324 RVA: 0x0017B93C File Offset: 0x00179B3C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0017B974 File Offset: 0x00179B74
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.ot_ordonnancement_intervention));
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label30 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.radRadioButton4 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton3 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			this.radButton1.BeginInit();
			this.radDropDownList1.BeginInit();
			this.panel2.SuspendLayout();
			this.radRadioButton4.BeginInit();
			this.radRadioButton3.BeginInit();
			this.radRadioButton1.BeginInit();
			base.SuspendLayout();
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(12, 7);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "id";
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column7";
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Fonction";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 200;
			gridViewTextBoxColumn3.HeaderText = "Date début";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column5";
			gridViewTextBoxColumn3.Width = 120;
			gridViewTextBoxColumn4.HeaderText = "Heure début";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column6";
			gridViewTextBoxColumn4.Width = 100;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Nbre Requis";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column2";
			gridViewTextBoxColumn5.Width = 130;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Minutes Planifiées";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column3";
			gridViewTextBoxColumn6.Width = 160;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column8";
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewImageColumn
			});
			this.radGridView3.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView3.MasterTemplate.EnableFiltering = true;
			this.radGridView3.MasterTemplate.EnableSorting = false;
			this.radGridView3.MasterTemplate.ShowFilteringRow = false;
			this.radGridView3.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView3.Name = "radGridView3";
			this.radGridView3.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView3.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView3.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView3.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView3.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView3.ReadOnly = true;
			this.radGridView3.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView3.ShowGroupPanel = false;
			this.radGridView3.Size = new global::System.Drawing.Size(564, 141);
			this.radGridView3.TabIndex = 247;
			this.radGridView3.ThemeName = "Fluent";
			this.panel1.Controls.Add(this.TextBox1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.pictureBox3);
			this.panel1.Controls.Add(this.radButton1);
			this.panel1.Controls.Add(this.radDropDownList1);
			this.panel1.Controls.Add(this.label30);
			this.panel1.Location = new global::System.Drawing.Point(12, 154);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1034, 85);
			this.panel1.TabIndex = 248;
			this.pictureBox3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(1000, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(27, 22);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 278;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click);
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(907, 53);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 277;
			this.radButton1.Text = "Ajouter";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(6, 53);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(250, 24);
			this.radDropDownList1.TabIndex = 259;
			this.radDropDownList1.ThemeName = "Fluent";
			this.radDropDownList1.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList1_SelectedIndexChanged);
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.DimGray;
			this.label30.Location = new global::System.Drawing.Point(4, 38);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(114, 12);
			this.label30.TabIndex = 258;
			this.label30.Text = "Choisir intervention";
			this.panel2.Controls.Add(this.radRadioButton4);
			this.panel2.Controls.Add(this.radRadioButton3);
			this.panel2.Controls.Add(this.radRadioButton1);
			this.panel2.Location = new global::System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(255, 32);
			this.panel2.TabIndex = 249;
			this.radRadioButton4.Location = new global::System.Drawing.Point(183, 3);
			this.radRadioButton4.Name = "radRadioButton4";
			this.radRadioButton4.Size = new global::System.Drawing.Size(53, 22);
			this.radRadioButton4.TabIndex = 186;
			this.radRadioButton4.TabStop = false;
			this.radRadioButton4.Text = "Test";
			this.radRadioButton4.ThemeName = "Crystal";
			this.radRadioButton4.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton4_ToggleStateChanged);
			this.radRadioButton3.Location = new global::System.Drawing.Point(93, 3);
			this.radRadioButton3.Name = "radRadioButton3";
			this.radRadioButton3.Size = new global::System.Drawing.Size(91, 22);
			this.radRadioButton3.TabIndex = 185;
			this.radRadioButton3.TabStop = false;
			this.radRadioButton3.Text = "Diagnostic";
			this.radRadioButton3.ThemeName = "Crystal";
			this.radRadioButton3.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton3_ToggleStateChanged);
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Location = new global::System.Drawing.Point(3, 3);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(92, 22);
			this.radRadioButton1.TabIndex = 183;
			this.radRadioButton1.Text = "Réparation";
			this.radRadioButton1.ThemeName = "Crystal";
			this.radRadioButton1.ToggleState = 1;
			this.radRadioButton1.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
			this.TextBox1.BorderRadius = 2;
			this.TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox1.DefaultText = "";
			this.TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.DisabledState.Parent = this.TextBox1;
			this.TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.Enabled = false;
			this.TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.FocusedState.Parent = this.TextBox1;
			this.TextBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.HoverState.Parent = this.TextBox1;
			this.TextBox1.Location = new global::System.Drawing.Point(262, 52);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(639, 25);
			this.TextBox1.TabIndex = 279;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.radGridView3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_ordonnancement_intervention";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_ordonnancement_intervention_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			this.radButton1.EndInit();
			this.radDropDownList1.EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.radRadioButton4.EndInit();
			this.radRadioButton3.EndInit();
			this.radRadioButton1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000C22 RID: 3106
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000C23 RID: 3107
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000C24 RID: 3108
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000C25 RID: 3109
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000C26 RID: 3110
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000C27 RID: 3111
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000C28 RID: 3112
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000C29 RID: 3113
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x04000C2A RID: 3114
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000C2B RID: 3115
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000C2C RID: 3116
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton4;

		// Token: 0x04000C2D RID: 3117
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton3;

		// Token: 0x04000C2E RID: 3118
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x04000C2F RID: 3119
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;
	}
}
