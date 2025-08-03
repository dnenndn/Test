namespace GMAO
{
	// Token: 0x02000088 RID: 136
	public partial class liste_budget_fournisseur : global::System.Windows.Forms.Form
	{
		// Token: 0x06000673 RID: 1651 RVA: 0x0010FF18 File Offset: 0x0010E118
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0010FF50 File Offset: 0x0010E150
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.radRadioButton7 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton8 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.dataGridView2 = new global::System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewImageColumn1 = new global::System.Windows.Forms.DataGridViewImageColumn();
			this.radTreeView2 = new global::Telerik.WinControls.UI.RadTreeView();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.radRadioButton11 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton12 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.guna2TextBox3 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.panel4.SuspendLayout();
			this.radRadioButton7.BeginInit();
			this.radRadioButton8.BeginInit();
			this.panel5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView2).BeginInit();
			this.radTreeView2.BeginInit();
			this.panel7.SuspendLayout();
			this.radRadioButton11.BeginInit();
			this.radRadioButton12.BeginInit();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.radRadioButton7);
			this.panel4.Controls.Add(this.radRadioButton8);
			this.panel4.Location = new global::System.Drawing.Point(12, 12);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(279, 29);
			this.panel4.TabIndex = 205;
			this.radRadioButton7.Location = new global::System.Drawing.Point(77, 4);
			this.radRadioButton7.Name = "radRadioButton7";
			this.radRadioButton7.Size = new global::System.Drawing.Size(167, 22);
			this.radRadioButton7.TabIndex = 50;
			this.radRadioButton7.TabStop = false;
			this.radRadioButton7.Text = "Choisir des fournisseur";
			this.radRadioButton7.ThemeName = "Crystal";
			this.radRadioButton7.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton7_ToggleStateChanged);
			this.radRadioButton8.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton8.Location = new global::System.Drawing.Point(10, 4);
			this.radRadioButton8.Name = "radRadioButton8";
			this.radRadioButton8.Size = new global::System.Drawing.Size(57, 22);
			this.radRadioButton8.TabIndex = 48;
			this.radRadioButton8.Text = "Tous";
			this.radRadioButton8.ThemeName = "Crystal";
			this.radRadioButton8.ToggleState = 1;
			this.radRadioButton8.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton8_ToggleStateChanged);
			this.panel5.Controls.Add(this.dataGridView2);
			this.panel5.Controls.Add(this.radTreeView2);
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Controls.Add(this.guna2TextBox3);
			this.panel5.Controls.Add(this.label9);
			this.panel5.Location = new global::System.Drawing.Point(12, 57);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(674, 429);
			this.panel5.TabIndex = 206;
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.BackgroundColor = global::System.Drawing.Color.White;
			this.dataGridView2.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.dataGridView2.CellBorderStyle = global::System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.dataGridView2.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView2.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.ColumnHeadersVisible = false;
			this.dataGridView2.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewTextBoxColumn2,
				this.dataGridViewImageColumn1
			});
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = global::System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle.SelectionBackColor = global::System.Drawing.Color.Firebrick;
			dataGridViewCellStyle.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle;
			this.dataGridView2.Location = new global::System.Drawing.Point(239, 97);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.Size = new global::System.Drawing.Size(426, 329);
			this.dataGridView2.TabIndex = 215;
			this.dataGridViewTextBoxColumn1.HeaderText = "id";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Visible = false;
			this.dataGridViewTextBoxColumn2.HeaderText = "designation";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 350;
			this.dataGridViewImageColumn1.HeaderText = "Column3";
			this.dataGridViewImageColumn1.Image = global::GMAO.Properties.Resources.icons8_supprimer_pour_toujours_100__4_;
			this.dataGridViewImageColumn1.ImageLayout = global::System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.ReadOnly = true;
			this.dataGridViewImageColumn1.Width = 50;
			this.radTreeView2.Location = new global::System.Drawing.Point(9, 94);
			this.radTreeView2.Name = "radTreeView2";
			this.radTreeView2.RadContextMenu = this.radContextMenu1;
			this.radTreeView2.Size = new global::System.Drawing.Size(223, 332);
			this.radTreeView2.SpacingBetweenNodes = -1;
			this.radTreeView2.TabIndex = 214;
			this.radTreeView2.ThemeName = "Office2010Silver";
			this.panel7.Controls.Add(this.radRadioButton11);
			this.panel7.Controls.Add(this.radRadioButton12);
			this.panel7.Location = new global::System.Drawing.Point(9, 4);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(389, 29);
			this.panel7.TabIndex = 204;
			this.radRadioButton11.Location = new global::System.Drawing.Point(107, 4);
			this.radRadioButton11.Name = "radRadioButton11";
			this.radRadioButton11.Size = new global::System.Drawing.Size(88, 22);
			this.radRadioButton11.TabIndex = 203;
			this.radRadioButton11.TabStop = false;
			this.radRadioButton11.Text = "Tous Sauf";
			this.radRadioButton11.ThemeName = "Crystal";
			this.radRadioButton12.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton12.Location = new global::System.Drawing.Point(6, 4);
			this.radRadioButton12.Name = "radRadioButton12";
			this.radRadioButton12.Size = new global::System.Drawing.Size(94, 22);
			this.radRadioButton12.TabIndex = 50;
			this.radRadioButton12.Text = "Choisir Les";
			this.radRadioButton12.ThemeName = "Crystal";
			this.radRadioButton12.ToggleState = 1;
			this.guna2TextBox3.BorderRadius = 15;
			this.guna2TextBox3.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox3.DefaultText = "";
			this.guna2TextBox3.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox3.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox3.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox3.DisabledState.Parent = this.guna2TextBox3;
			this.guna2TextBox3.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox3.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox3.FocusedState.Parent = this.guna2TextBox3;
			this.guna2TextBox3.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.guna2TextBox3.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox3.HoverState.Parent = this.guna2TextBox3;
			this.guna2TextBox3.Location = new global::System.Drawing.Point(9, 61);
			this.guna2TextBox3.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox3.Name = "guna2TextBox3";
			this.guna2TextBox3.PasswordChar = '\0';
			this.guna2TextBox3.PlaceholderText = "Recherche";
			this.guna2TextBox3.SelectedText = "";
			this.guna2TextBox3.ShadowDecoration.Parent = this.guna2TextBox3;
			this.guna2TextBox3.Size = new global::System.Drawing.Size(229, 30);
			this.guna2TextBox3.TabIndex = 213;
			this.guna2TextBox3.TextChanged += new global::System.EventHandler(this.guna2TextBox3_TextChanged);
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.Black;
			this.label9.Location = new global::System.Drawing.Point(5, 38);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(91, 19);
			this.label9.TabIndex = 212;
			this.label9.Text = "Fournisseurs";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(580, 12);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button1.TabIndex = 214;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radContextMenu1.ThemeName = "Office2010Silver";
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(762, 498);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel4);
			base.Name = "liste_budget_fournisseur";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.liste_budget_fournisseur_Load);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.radRadioButton7.EndInit();
			this.radRadioButton8.EndInit();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView2).EndInit();
			this.radTreeView2.EndInit();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.radRadioButton11.EndInit();
			this.radRadioButton12.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000879 RID: 2169
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400087A RID: 2170
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400087B RID: 2171
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton7;

		// Token: 0x0400087C RID: 2172
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton8;

		// Token: 0x0400087D RID: 2173
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x0400087E RID: 2174
		private global::System.Windows.Forms.DataGridView dataGridView2;

		// Token: 0x0400087F RID: 2175
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		// Token: 0x04000880 RID: 2176
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		// Token: 0x04000881 RID: 2177
		private global::System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;

		// Token: 0x04000882 RID: 2178
		private global::Telerik.WinControls.UI.RadTreeView radTreeView2;

		// Token: 0x04000883 RID: 2179
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000884 RID: 2180
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton11;

		// Token: 0x04000885 RID: 2181
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton12;

		// Token: 0x04000886 RID: 2182
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox3;

		// Token: 0x04000887 RID: 2183
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000888 RID: 2184
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000889 RID: 2185
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x0400088A RID: 2186
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x0400088B RID: 2187
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x0400088C RID: 2188
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400088D RID: 2189
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
	}
}
