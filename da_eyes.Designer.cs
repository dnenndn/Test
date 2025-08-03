namespace GMAO
{
	// Token: 0x02000060 RID: 96
	public partial class da_eyes : global::System.Windows.Forms.Form
	{
		// Token: 0x0600048C RID: 1164 RVA: 0x000C1024 File Offset: 0x000BF224
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x000C105C File Offset: 0x000BF25C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.da_eyes));
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.radGridView2 = new global::Telerik.WinControls.UI.RadGridView();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radGridView2.BeginInit();
			this.radGridView2.MasterTemplate.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.radPanel1.BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(12, 5);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(54, 19);
			this.label1.TabIndex = 167;
			this.label1.Text = "ID DA :";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(11, 170);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(153, 19);
			this.label2.TabIndex = 168;
			this.label2.Text = "Les actions sur le DA :";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(65, 5);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(49, 19);
			this.label3.TabIndex = 169;
			this.label3.Text = "label3";
			this.radGridView2.AutoScroll = true;
			this.radGridView2.BackColor = global::System.Drawing.Color.White;
			this.radGridView2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView2.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView2.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView2.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView2.Location = new global::System.Drawing.Point(15, 192);
			this.radGridView2.MasterTemplate.AllowAddNewRow = false;
			this.radGridView2.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnReorder = false;
			this.radGridView2.MasterTemplate.AllowDeleteRow = false;
			this.radGridView2.MasterTemplate.AllowDragToGroup = false;
			this.radGridView2.MasterTemplate.AllowEditRow = false;
			this.radGridView2.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.HeaderText = "Action";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column1";
			gridViewTextBoxColumn.Width = 200;
			gridViewTextBoxColumn2.HeaderText = "Action par";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column4";
			gridViewTextBoxColumn2.Width = 250;
			gridViewTextBoxColumn3.DataType = typeof(global::System.DateTime);
			gridViewTextBoxColumn3.HeaderText = "Date";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 150;
			this.radGridView2.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3
			});
			this.radGridView2.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView2.MasterTemplate.EnableFiltering = true;
			this.radGridView2.MasterTemplate.EnableSorting = false;
			this.radGridView2.MasterTemplate.ShowFilteringRow = false;
			this.radGridView2.MasterTemplate.ShowHeaderCellButtons = true;
			this.radGridView2.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView2.Name = "radGridView2";
			this.radGridView2.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView2.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView2.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView2.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView2.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Khaki;
			this.radGridView2.PrintStyle.PrintAllPages = true;
			this.radGridView2.PrintStyle.PrintAlternatingRowColor = true;
			this.radGridView2.ReadOnly = true;
			this.radGridView2.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView2.ShowGroupPanel = false;
			this.radGridView2.ShowHeaderCellButtons = true;
			this.radGridView2.Size = new global::System.Drawing.Size(688, 303);
			this.radGridView2.TabIndex = 196;
			this.radGridView2.ThemeName = "Fluent";
			this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new global::System.Drawing.Point(548, 34);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(13, 13);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 200;
			this.pictureBox2.TabStop = false;
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(91, 33);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(32, 22);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 199;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.radPanel1.AutoScroll = true;
			this.radPanel1.Location = new global::System.Drawing.Point(15, 56);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Size = new global::System.Drawing.Size(688, 109);
			this.radPanel1.TabIndex = 198;
			this.radPanel1.ThemeName = "ControlDefault";
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel1.GetChildAt(0).GetChildAt(1)).GradientStyle = 0;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel1.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.ForeColor = global::System.Drawing.Color.Black;
			this.label13.Location = new global::System.Drawing.Point(11, 34);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(82, 19);
			this.label13.TabIndex = 197;
			this.label13.Text = "Documents";
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-supprimer-pour-toujours-100 (4).png");
			this.imageList1.Images.SetKeyName(1, "icons8-approuver-et-mettre-à-jour-96 (4).png");
			this.imageList1.Images.SetKeyName(2, "imgonline-com-ua-Transparent-background-mY80EJnxkjzbk (1).ico");
			this.imageList1.Images.SetKeyName(3, "icons8-word-96.png");
			this.imageList1.Images.SetKeyName(4, "icons8-ms-excel-104.png");
			this.imageList1.Images.SetKeyName(5, "icons8-pdf-40.png");
			this.imageList1.Images.SetKeyName(6, "icons8-txt-80.png");
			this.imageList1.Images.SetKeyName(7, "icons8-image-96.png");
			this.imageList1.Images.SetKeyName(8, "icons8-winrar-240.png");
			this.imageList1.Images.SetKeyName(9, "icons8-fichier-128.png");
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(730, 507);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.radGridView2);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.radPanel1);
			base.Controls.Add(this.label1);
			base.Name = "da_eyes";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.da_eyes_Load);
			this.radGridView2.MasterTemplate.EndInit();
			this.radGridView2.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.radPanel1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040005FA RID: 1530
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040005FB RID: 1531
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040005FC RID: 1532
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040005FD RID: 1533
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040005FE RID: 1534
		private global::Telerik.WinControls.UI.RadGridView radGridView2;

		// Token: 0x040005FF RID: 1535
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x04000600 RID: 1536
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000601 RID: 1537
		private global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x04000602 RID: 1538
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000603 RID: 1539
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x04000604 RID: 1540
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;
	}
}
