namespace GMAO
{
	// Token: 0x02000087 RID: 135
	public partial class liste_budget_categorie : global::System.Windows.Forms.Form
	{
		// Token: 0x06000666 RID: 1638 RVA: 0x0010EA34 File Offset: 0x0010CC34
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0010EA6C File Offset: 0x0010CC6C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.dataGridView1 = new global::System.Windows.Forms.DataGridView();
			this.Column1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new global::System.Windows.Forms.DataGridViewImageColumn();
			this.radTreeView1 = new global::Telerik.WinControls.UI.RadTreeView();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.guna2TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.radRadioButton6 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton9 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton10 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.label8 = new global::System.Windows.Forms.Label();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
			this.radTreeView1.BeginInit();
			this.panel6.SuspendLayout();
			this.radRadioButton6.BeginInit();
			this.radRadioButton9.BeginInit();
			this.radRadioButton10.BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.guna2Button1);
			this.panel1.Controls.Add(this.dataGridView1);
			this.panel1.Controls.Add(this.radTreeView1);
			this.panel1.Controls.Add(this.guna2TextBox2);
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Location = new global::System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(674, 476);
			this.panel1.TabIndex = 201;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(559, 3);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button1.TabIndex = 213;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.BackgroundColor = global::System.Drawing.Color.White;
			this.dataGridView1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.dataGridView1.CellBorderStyle = global::System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.dataGridView1.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ColumnHeadersVisible = false;
			this.dataGridView1.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.Column1,
				this.Column2,
				this.Column3
			});
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = global::System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle.SelectionBackColor = global::System.Drawing.Color.Firebrick;
			dataGridViewCellStyle.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle;
			this.dataGridView1.Location = new global::System.Drawing.Point(237, 91);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new global::System.Drawing.Size(426, 382);
			this.dataGridView1.TabIndex = 212;
			this.Column1.HeaderText = "id";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Visible = false;
			this.Column2.HeaderText = "designation";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 350;
			this.Column3.HeaderText = "Column3";
			this.Column3.Image = global::GMAO.Properties.Resources.icons8_supprimer_pour_toujours_100__4_;
			this.Column3.ImageLayout = global::System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 50;
			this.radTreeView1.Location = new global::System.Drawing.Point(9, 91);
			this.radTreeView1.Name = "radTreeView1";
			this.radTreeView1.RadContextMenu = this.radContextMenu1;
			this.radTreeView1.Size = new global::System.Drawing.Size(223, 382);
			this.radTreeView1.SpacingBetweenNodes = -1;
			this.radTreeView1.TabIndex = 211;
			this.radTreeView1.ThemeName = "Office2010Silver";
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem1.UseCompatibleTextRendering = false;
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
			this.guna2TextBox2.Location = new global::System.Drawing.Point(9, 58);
			this.guna2TextBox2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox2.Name = "guna2TextBox2";
			this.guna2TextBox2.PasswordChar = '\0';
			this.guna2TextBox2.PlaceholderText = "Recherche";
			this.guna2TextBox2.SelectedText = "";
			this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Size = new global::System.Drawing.Size(229, 30);
			this.guna2TextBox2.TabIndex = 210;
			this.guna2TextBox2.TextChanged += new global::System.EventHandler(this.guna2TextBox2_TextChanged);
			this.panel6.Controls.Add(this.radRadioButton6);
			this.panel6.Controls.Add(this.radRadioButton9);
			this.panel6.Controls.Add(this.radRadioButton10);
			this.panel6.Location = new global::System.Drawing.Point(17, 3);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(389, 29);
			this.panel6.TabIndex = 203;
			this.radRadioButton6.Location = new global::System.Drawing.Point(179, 4);
			this.radRadioButton6.Name = "radRadioButton6";
			this.radRadioButton6.Size = new global::System.Drawing.Size(88, 22);
			this.radRadioButton6.TabIndex = 203;
			this.radRadioButton6.TabStop = false;
			this.radRadioButton6.Text = "Tous Sauf";
			this.radRadioButton6.ThemeName = "Crystal";
			this.radRadioButton9.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton9.Location = new global::System.Drawing.Point(78, 4);
			this.radRadioButton9.Name = "radRadioButton9";
			this.radRadioButton9.Size = new global::System.Drawing.Size(94, 22);
			this.radRadioButton9.TabIndex = 50;
			this.radRadioButton9.Text = "Choisir Les";
			this.radRadioButton9.ThemeName = "Crystal";
			this.radRadioButton9.ToggleState = 1;
			this.radRadioButton10.Location = new global::System.Drawing.Point(10, 4);
			this.radRadioButton10.Name = "radRadioButton10";
			this.radRadioButton10.Size = new global::System.Drawing.Size(57, 22);
			this.radRadioButton10.TabIndex = 48;
			this.radRadioButton10.TabStop = false;
			this.radRadioButton10.Text = "Tous";
			this.radRadioButton10.ThemeName = "Crystal";
			this.radRadioButton10.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton10_ToggleStateChanged);
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Black;
			this.label8.Location = new global::System.Drawing.Point(5, 35);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(49, 19);
			this.label8.TabIndex = 209;
			this.label8.Text = "label8";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(762, 498);
			base.Controls.Add(this.panel1);
			base.Name = "liste_budget_categorie";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.liste_budget_categorie_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
			this.radTreeView1.EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.radRadioButton6.EndInit();
			this.radRadioButton9.EndInit();
			this.radRadioButton10.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000865 RID: 2149
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000866 RID: 2150
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000867 RID: 2151
		private global::System.Windows.Forms.DataGridView dataGridView1;

		// Token: 0x04000868 RID: 2152
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column1;

		// Token: 0x04000869 RID: 2153
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column2;

		// Token: 0x0400086A RID: 2154
		private global::System.Windows.Forms.DataGridViewImageColumn Column3;

		// Token: 0x0400086B RID: 2155
		private global::Telerik.WinControls.UI.RadTreeView radTreeView1;

		// Token: 0x0400086C RID: 2156
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;

		// Token: 0x0400086D RID: 2157
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x0400086E RID: 2158
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton6;

		// Token: 0x0400086F RID: 2159
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton9;

		// Token: 0x04000870 RID: 2160
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton10;

		// Token: 0x04000871 RID: 2161
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000872 RID: 2162
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x04000873 RID: 2163
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x04000874 RID: 2164
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x04000875 RID: 2165
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000876 RID: 2166
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000877 RID: 2167
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;
	}
}
