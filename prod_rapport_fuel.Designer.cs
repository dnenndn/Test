namespace GMAO
{
	// Token: 0x0200011B RID: 283
	public partial class prod_rapport_fuel : global::System.Windows.Forms.Form
	{
		// Token: 0x06000C81 RID: 3201 RVA: 0x001E6924 File Offset: 0x001E4B24
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x001E695C File Offset: 0x001E4B5C
		private void InitializeComponent()
		{
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radTextBox1 = new global::Telerik.WinControls.UI.RadTextBox();
			this.radTextBox2 = new global::Telerik.WinControls.UI.RadTextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.radTextBox3 = new global::Telerik.WinControls.UI.RadTextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radTextBox1.BeginInit();
			this.radTextBox2.BeginInit();
			this.radTextBox3.BeginInit();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(181, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(43, 18);
			this.label2.TabIndex = 174;
			this.label2.Text = "Poste";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(37, 18);
			this.label1.TabIndex = 173;
			this.label1.Text = "Date";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(12, 53);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(108, 18);
			this.label3.TabIndex = 175;
			this.label3.Text = "Qt Fuel Séchoirs";
			this.radTextBox1.Location = new global::System.Drawing.Point(15, 74);
			this.radTextBox1.Name = "radTextBox1";
			this.radTextBox1.Size = new global::System.Drawing.Size(209, 24);
			this.radTextBox1.TabIndex = 176;
			this.radTextBox1.ThemeName = "Fluent";
			this.radTextBox2.Location = new global::System.Drawing.Point(15, 131);
			this.radTextBox2.Name = "radTextBox2";
			this.radTextBox2.Size = new global::System.Drawing.Size(209, 24);
			this.radTextBox2.TabIndex = 178;
			this.radTextBox2.ThemeName = "Fluent";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(12, 110);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(90, 18);
			this.label4.TabIndex = 177;
			this.label4.Text = "Qt Fuel Fours";
			this.radTextBox3.Location = new global::System.Drawing.Point(15, 192);
			this.radTextBox3.Name = "radTextBox3";
			this.radTextBox3.Size = new global::System.Drawing.Size(209, 24);
			this.radTextBox3.TabIndex = 180;
			this.radTextBox3.ThemeName = "Fluent";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DimGray;
			this.label5.Location = new global::System.Drawing.Point(12, 171);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(86, 18);
			this.label5.TabIndex = 179;
			this.label5.Text = "Qt Fuel Total";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(248, 192);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 24);
			this.guna2Button1.TabIndex = 184;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1132, 303);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radTextBox3);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.radTextBox2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.radTextBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "prod_rapport_fuel";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.prod_rapport_fuel_Load);
			this.radTextBox1.EndInit();
			this.radTextBox2.EndInit();
			this.radTextBox3.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001018 RID: 4120
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001019 RID: 4121
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400101A RID: 4122
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400101B RID: 4123
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400101C RID: 4124
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x0400101D RID: 4125
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400101E RID: 4126
		private global::Telerik.WinControls.UI.RadTextBox radTextBox1;

		// Token: 0x0400101F RID: 4127
		private global::Telerik.WinControls.UI.RadTextBox radTextBox2;

		// Token: 0x04001020 RID: 4128
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04001021 RID: 4129
		private global::Telerik.WinControls.UI.RadTextBox radTextBox3;

		// Token: 0x04001022 RID: 4130
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04001023 RID: 4131
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;
	}
}
