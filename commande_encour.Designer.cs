namespace GMAO
{
	// Token: 0x02000045 RID: 69
	public partial class commande_encour : global::System.Windows.Forms.Form
	{
		// Token: 0x06000322 RID: 802 RVA: 0x00088434 File Offset: 0x00086634
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0008846C File Offset: 0x0008666C
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.commande_encour));
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radPanel2 = new global::Telerik.WinControls.UI.RadPanel();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.dataGridView2 = new global::System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn3 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radPanel2.BeginInit();
			this.radPanel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView2).BeginInit();
			base.SuspendLayout();
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(12, 32);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "column9";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column9";
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "N° Comd";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column5";
			gridViewTextBoxColumn2.Width = 100;
			gridViewTextBoxColumn3.DataType = typeof(global::System.DateTime);
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.FormatString = "{0:dd/MM/yyyy}";
			gridViewTextBoxColumn3.HeaderText = "Date Création";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 150;
			gridViewTextBoxColumn4.DataType = typeof(global::System.DateTime);
			gridViewTextBoxColumn4.FormatString = "{0:dd/MM/yyyy}";
			gridViewTextBoxColumn4.HeaderText = "Date Signature";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column8";
			gridViewTextBoxColumn4.Width = 150;
			gridViewTextBoxColumn5.AllowSort = false;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Heure";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column2";
			gridViewTextBoxColumn5.Width = 170;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Créateur";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column3";
			gridViewTextBoxColumn6.Width = 150;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Fournisseur";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column7";
			gridViewTextBoxColumn7.Width = 200;
			gridViewCommandColumn.EnableExpressionEditor = false;
			gridViewCommandColumn.Name = "column13";
			gridViewCommandColumn.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewCommandColumn.Width = 150;
			gridViewCommandColumn2.EnableExpressionEditor = false;
			gridViewCommandColumn2.Name = "column4";
			gridViewCommandColumn2.Width = 140;
			gridViewCommandColumn3.EnableExpressionEditor = false;
			gridViewCommandColumn3.Name = "column6";
			gridViewCommandColumn3.Width = 120;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7,
				gridViewCommandColumn,
				gridViewCommandColumn2,
				gridViewCommandColumn3
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
			this.radGridView1.MasterTemplate.EnablePaging = true;
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
			this.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.ShowHeaderCellButtons = true;
			this.radGridView1.Size = new global::System.Drawing.Size(1095, 275);
			this.radGridView1.TabIndex = 169;
			this.radGridView1.ThemeName = "Fluent";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(8, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(148, 19);
			this.label1.TabIndex = 168;
			this.label1.Text = "Commandes en cours";
			this.radPanel2.Controls.Add(this.pictureBox3);
			this.radPanel2.Controls.Add(this.label7);
			this.radPanel2.Controls.Add(this.label9);
			this.radPanel2.Controls.Add(this.label6);
			this.radPanel2.Controls.Add(this.label8);
			this.radPanel2.Controls.Add(this.label5);
			this.radPanel2.Controls.Add(this.pictureBox2);
			this.radPanel2.Controls.Add(this.pictureBox1);
			this.radPanel2.Controls.Add(this.label4);
			this.radPanel2.Controls.Add(this.dataGridView2);
			this.radPanel2.Controls.Add(this.label3);
			this.radPanel2.Controls.Add(this.label2);
			this.radPanel2.Location = new global::System.Drawing.Point(12, 313);
			this.radPanel2.Name = "radPanel2";
			this.radPanel2.Size = new global::System.Drawing.Size(1104, 242);
			this.radPanel2.TabIndex = 170;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel2.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Silver;
			this.pictureBox3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(1068, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(27, 22);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 192;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click);
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.DimGray;
			this.label7.Location = new global::System.Drawing.Point(82, 43);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(45, 15);
			this.label7.TabIndex = 176;
			this.label7.Text = "label 5";
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.DimGray;
			this.label9.Location = new global::System.Drawing.Point(954, 45);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(45, 15);
			this.label9.TabIndex = 191;
			this.label9.Text = "label 9";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(82, 24);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(45, 15);
			this.label6.TabIndex = 175;
			this.label6.Text = "label 5";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.DimGray;
			this.label8.Location = new global::System.Drawing.Point(901, 45);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(54, 15);
			this.label8.TabIndex = 190;
			this.label8.Text = "Record : ";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DimGray;
			this.label5.Location = new global::System.Drawing.Point(93, 6);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(45, 15);
			this.label5.TabIndex = 174;
			this.label5.Text = "label 5";
			this.pictureBox2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new global::System.Drawing.Point(946, 6);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(36, 29);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 189;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new global::System.EventHandler(this.pictureBox2_Click);
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(904, 6);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(36, 29);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 188;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(3, 6);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(89, 15);
			this.label4.TabIndex = 173;
			this.label4.Text = "ID Commande :";
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.BackgroundColor = global::System.Drawing.Color.White;
			this.dataGridView2.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dataGridView2.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn3,
				this.dataGridViewTextBoxColumn4,
				this.dataGridViewTextBoxColumn5,
				this.dataGridViewTextBoxColumn6,
				this.dataGridViewTextBoxColumn7
			});
			this.dataGridView2.GridColor = global::System.Drawing.Color.Black;
			this.dataGridView2.Location = new global::System.Drawing.Point(6, 63);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.Size = new global::System.Drawing.Size(995, 170);
			this.dataGridView2.TabIndex = 172;
			this.dataGridViewTextBoxColumn3.HeaderText = "Code Article";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 200;
			this.dataGridViewTextBoxColumn4.HeaderText = "Désignation";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 300;
			this.dataGridViewTextBoxColumn5.HeaderText = "Qt commandée";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Width = 150;
			this.dataGridViewTextBoxColumn6.HeaderText = "Prix U HT";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 150;
			this.dataGridViewTextBoxColumn7.HeaderText = "Remise (%)";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Width = 150;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(3, 43);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(64, 15);
			this.label3.TabIndex = 171;
			this.label3.Text = "Créer par :";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(3, 24);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(55, 15);
			this.label2.TabIndex = 170;
			this.label2.Text = "Créer le :";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.radPanel2);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "commande_encour";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.commande_encour_Load);
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radPanel2.EndInit();
			this.radPanel2.ResumeLayout(false);
			this.radPanel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400045B RID: 1115
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400045C RID: 1116
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x0400045D RID: 1117
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400045E RID: 1118
		private global::Telerik.WinControls.UI.RadPanel radPanel2;

		// Token: 0x0400045F RID: 1119
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000460 RID: 1120
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000461 RID: 1121
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000462 RID: 1122
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000463 RID: 1123
		private global::System.Windows.Forms.DataGridView dataGridView2;

		// Token: 0x04000464 RID: 1124
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000465 RID: 1125
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000466 RID: 1126
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000467 RID: 1127
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000468 RID: 1128
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000469 RID: 1129
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400046A RID: 1130
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x0400046B RID: 1131
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400046C RID: 1132
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		// Token: 0x0400046D RID: 1133
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		// Token: 0x0400046E RID: 1134
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		// Token: 0x0400046F RID: 1135
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		// Token: 0x04000470 RID: 1136
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
	}
}
