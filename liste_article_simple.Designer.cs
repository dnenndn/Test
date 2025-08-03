namespace GMAO
{
	// Token: 0x02000085 RID: 133
	public partial class liste_article_simple : global::System.Windows.Forms.Form
	{
		// Token: 0x06000641 RID: 1601 RVA: 0x001031A8 File Offset: 0x001013A8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x001031E0 File Offset: 0x001013E0
		private void InitializeComponent()
		{
			this.dataGridView2 = new global::System.Windows.Forms.DataGridView();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.Column1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column9 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column10 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView2).BeginInit();
			base.SuspendLayout();
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.BackgroundColor = global::System.Drawing.Color.White;
			this.dataGridView2.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dataGridView2.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.Column1,
				this.Column2,
				this.Column5,
				this.Column3,
				this.Column4,
				this.Column7,
				this.Column8,
				this.Column9,
				this.Column10,
				this.Column6
			});
			this.dataGridView2.GridColor = global::System.Drawing.Color.Black;
			this.dataGridView2.Location = new global::System.Drawing.Point(12, 66);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.Size = new global::System.Drawing.Size(1106, 483);
			this.dataGridView2.TabIndex = 173;
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
			this.TextBox1.Location = new global::System.Drawing.Point(16, 31);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox1.TabIndex = 175;
			this.TextBox1.TextChanged += new global::System.EventHandler(this.TextBox1_TextChanged);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(77, 19);
			this.label3.TabIndex = 174;
			this.label3.Text = "Recherche";
			this.Column1.HeaderText = "ID";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column2.HeaderText = "Code Article";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 120;
			this.Column5.HeaderText = "Référence";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 150;
			this.Column3.HeaderText = "Désignation";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 200;
			this.Column4.HeaderText = "Marque";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column7.HeaderText = "Stock Neuf";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.Column8.HeaderText = "Stock Usé";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			this.Column9.HeaderText = "Stock Rebuté";
			this.Column9.Name = "Column9";
			this.Column9.ReadOnly = true;
			this.Column10.HeaderText = "Stock Réparable";
			this.Column10.Name = "Column10";
			this.Column10.ReadOnly = true;
			this.Column6.HeaderText = "Prix U HT";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1130, 612);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.dataGridView2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "liste_article_simple";
			base.ShowIcon = false;
			this.Text = "liste_article_simple";
			base.Load += new global::System.EventHandler(this.liste_article_simple_Load);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400083C RID: 2108
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400083D RID: 2109
		private global::System.Windows.Forms.DataGridView dataGridView2;

		// Token: 0x0400083E RID: 2110
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x0400083F RID: 2111
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000840 RID: 2112
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column1;

		// Token: 0x04000841 RID: 2113
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column2;

		// Token: 0x04000842 RID: 2114
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column5;

		// Token: 0x04000843 RID: 2115
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column3;

		// Token: 0x04000844 RID: 2116
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column4;

		// Token: 0x04000845 RID: 2117
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column7;

		// Token: 0x04000846 RID: 2118
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column8;

		// Token: 0x04000847 RID: 2119
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column9;

		// Token: 0x04000848 RID: 2120
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column10;

		// Token: 0x04000849 RID: 2121
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column6;
	}
}
