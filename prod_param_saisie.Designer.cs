namespace GMAO
{
	// Token: 0x0200010C RID: 268
	public partial class prod_param_saisie : global::System.Windows.Forms.Form
	{
		// Token: 0x06000C02 RID: 3074 RVA: 0x001D6790 File Offset: 0x001D4990
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x001D67C8 File Offset: 0x001D49C8
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button5 = new global::System.Windows.Forms.Button();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.radCheckBox1 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.radCheckBox2 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.panel4.SuspendLayout();
			this.panel1.SuspendLayout();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radCheckBox1.BeginInit();
			this.panel2.SuspendLayout();
			this.radCheckBox2.BeginInit();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button5);
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1116, 29);
			this.panel4.TabIndex = 74;
			this.button2.BackColor = global::System.Drawing.Color.Gray;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(0, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(247, 29);
			this.button2.TabIndex = 72;
			this.button2.Text = "Champs d'échantillonnage qualité fabrication";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.panel3.Location = new global::System.Drawing.Point(-10, 29);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1148, 10);
			this.panel3.TabIndex = 75;
			this.panel3.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.radGridView1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.guna2TextBox1);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.guna2Button1);
			this.panel1.Controls.Add(this.TextBox1);
			this.panel1.Location = new global::System.Drawing.Point(12, 45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1104, 501);
			this.panel1.TabIndex = 76;
			this.button1.BackColor = global::System.Drawing.Color.Gray;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(247, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(184, 29);
			this.button1.TabIndex = 73;
			this.button1.Text = "Champs de saisie Fabrication";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button3.BackColor = global::System.Drawing.Color.Gray;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(431, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(177, 29);
			this.button3.TabIndex = 74;
			this.button3.Text = "Champs de saisie Sortie Four";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button4.BackColor = global::System.Drawing.Color.Gray;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(608, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(123, 29);
			this.button4.TabIndex = 75;
			this.button4.Text = "Préparation Général";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button5.BackColor = global::System.Drawing.Color.Gray;
			this.button5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button5.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button5.ForeColor = global::System.Drawing.Color.White;
			this.button5.Location = new global::System.Drawing.Point(731, 0);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(123, 29);
			this.button5.TabIndex = 76;
			this.button5.Text = "Tableau Préparation";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(387, 30);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 85;
			this.guna2Button1.Text = "Ajouter";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
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
			this.TextBox1.Location = new global::System.Drawing.Point(9, 31);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(205, 29);
			this.TextBox1.TabIndex = 84;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(5, 9);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(123, 19);
			this.label4.TabIndex = 169;
			this.label4.Text = "Champs de saisie";
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
			this.guna2TextBox1.Location = new global::System.Drawing.Point(220, 31);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(161, 29);
			this.guna2TextBox1.TabIndex = 170;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(216, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(44, 19);
			this.label1.TabIndex = 171;
			this.label1.Text = "Unité";
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.Location = new global::System.Drawing.Point(9, 113);
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
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "id_famille";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 150;
			gridViewTextBoxColumn2.HeaderText = "Champs de saisie";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column3";
			gridViewTextBoxColumn2.Width = 300;
			gridViewTextBoxColumn3.AllowSort = false;
			gridViewTextBoxColumn3.HeaderText = "Unité";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 180;
			gridViewTextBoxColumn4.HeaderText = "Produit Préparation";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column1";
			gridViewTextBoxColumn4.Width = 200;
			gridViewImageColumn.HeaderText = "";
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column6";
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
			this.radGridView1.Size = new global::System.Drawing.Size(1029, 373);
			this.radGridView1.TabIndex = 172;
			this.radGridView1.ThemeName = "Fluent";
			this.radCheckBox1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radCheckBox1.Location = new global::System.Drawing.Point(6, 8);
			this.radCheckBox1.Name = "radCheckBox1";
			this.radCheckBox1.Size = new global::System.Drawing.Size(59, 18);
			this.radCheckBox1.TabIndex = 173;
			this.radCheckBox1.Text = "Argile";
			this.radCheckBox1.ThemeName = "Crystal";
			this.panel2.Controls.Add(this.radCheckBox2);
			this.panel2.Controls.Add(this.radCheckBox1);
			this.panel2.Location = new global::System.Drawing.Point(3, 66);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(211, 37);
			this.panel2.TabIndex = 174;
			this.radCheckBox2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radCheckBox2.Location = new global::System.Drawing.Point(71, 8);
			this.radCheckBox2.Name = "radCheckBox2";
			this.radCheckBox2.Size = new global::System.Drawing.Size(58, 18);
			this.radCheckBox2.TabIndex = 174;
			this.radCheckBox2.Text = "Sable";
			this.radCheckBox2.ThemeName = "Crystal";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "prod_param_saisie";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.prod_param_saisie_Load);
			this.panel4.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radCheckBox1.EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.radCheckBox2.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000F96 RID: 3990
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000F97 RID: 3991
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000F98 RID: 3992
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000F99 RID: 3993
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000F9A RID: 3994
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000F9B RID: 3995
		public global::System.Windows.Forms.Button button3;

		// Token: 0x04000F9C RID: 3996
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04000F9D RID: 3997
		public global::System.Windows.Forms.Button button4;

		// Token: 0x04000F9E RID: 3998
		public global::System.Windows.Forms.Button button5;

		// Token: 0x04000F9F RID: 3999
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000FA0 RID: 4000
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000FA1 RID: 4001
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000FA2 RID: 4002
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000FA3 RID: 4003
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000FA4 RID: 4004
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000FA5 RID: 4005
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000FA6 RID: 4006
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04000FA7 RID: 4007
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000FA8 RID: 4008
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox1;

		// Token: 0x04000FA9 RID: 4009
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox2;
	}
}
