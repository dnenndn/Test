namespace GMAO
{
	// Token: 0x020000E8 RID: 232
	public partial class outillage_parametre_type : global::System.Windows.Forms.Form
	{
		// Token: 0x06000A23 RID: 2595 RVA: 0x00194160 File Offset: 0x00192360
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00194198 File Offset: 0x00192398
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.radButton2 = new global::Telerik.WinControls.UI.RadButton();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.radTextBox2 = new global::Telerik.WinControls.UI.RadTextBox();
			this.radTextBox1 = new global::Telerik.WinControls.UI.RadTextBox();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radButton2.BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radButton1.BeginInit();
			this.radTextBox2.BeginInit();
			this.radTextBox1.BeginInit();
			base.SuspendLayout();
			this.radButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton2.ForeColor = global::System.Drawing.Color.Firebrick;
			this.radButton2.Location = new global::System.Drawing.Point(773, 35);
			this.radButton2.Name = "radButton2";
			this.radButton2.Size = new global::System.Drawing.Size(110, 24);
			this.radButton2.TabIndex = 34;
			this.radButton2.Text = "Annuler";
			this.radButton2.ThemeName = "Crystal";
			this.radButton2.Visible = false;
			this.radButton2.Click += new global::System.EventHandler(this.radButton2_Click);
			this.radGridView1.BackColor = global::System.Drawing.SystemColors.Control;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f);
			this.radGridView1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(44, 96);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column1";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Code";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column2";
			gridViewTextBoxColumn2.Width = 250;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Désigantion";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column3";
			gridViewTextBoxColumn3.Width = 300;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column4";
			gridViewImageColumn.Width = 100;
			gridViewImageColumn2.EnableExpressionEditor = false;
			gridViewImageColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewImageColumn2.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn2.Name = "column5";
			gridViewImageColumn2.Width = 100;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewImageColumn,
				gridViewImageColumn2
			});
			this.radGridView1.MasterTemplate.EnablePaging = true;
			this.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.ReadOnly = true;
			this.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.Size = new global::System.Drawing.Size(1019, 369);
			this.radGridView1.TabIndex = 38;
			this.radGridView1.ThemeName = "Fluent";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(295, 42);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(63, 13);
			this.label3.TabIndex = 37;
			this.label3.Text = "Désignation";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(41, 38);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(32, 13);
			this.label2.TabIndex = 36;
			this.label2.Text = "Code";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(72, 38);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(0, 13);
			this.label1.TabIndex = 35;
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.radButton1.Location = new global::System.Drawing.Point(648, 35);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 33;
			this.radButton1.Text = "Ajouter";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.radTextBox2.Location = new global::System.Drawing.Point(370, 35);
			this.radTextBox2.Name = "radTextBox2";
			this.radTextBox2.Size = new global::System.Drawing.Size(256, 24);
			this.radTextBox2.TabIndex = 31;
			this.radTextBox2.ThemeName = "Crystal";
			this.radTextBox1.Location = new global::System.Drawing.Point(90, 35);
			this.radTextBox1.Name = "radTextBox1";
			this.radTextBox1.Size = new global::System.Drawing.Size(181, 24);
			this.radTextBox1.TabIndex = 32;
			this.radTextBox1.ThemeName = "Crystal";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 501);
			base.Controls.Add(this.radButton2);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radButton1);
			base.Controls.Add(this.radTextBox2);
			base.Controls.Add(this.radTextBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "outillage_parametre_type";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.outillage_parametre_type_Load);
			this.radButton2.EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radButton1.EndInit();
			this.radTextBox2.EndInit();
			this.radTextBox1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000D16 RID: 3350
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000D17 RID: 3351
		private global::Telerik.WinControls.UI.RadButton radButton2;

		// Token: 0x04000D18 RID: 3352
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04000D19 RID: 3353
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000D1A RID: 3354
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000D1B RID: 3355
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000D1C RID: 3356
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000D1D RID: 3357
		private global::Telerik.WinControls.UI.RadTextBox radTextBox2;

		// Token: 0x04000D1E RID: 3358
		private global::Telerik.WinControls.UI.RadTextBox radTextBox1;

		// Token: 0x04000D1F RID: 3359
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000D20 RID: 3360
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
	}
}
