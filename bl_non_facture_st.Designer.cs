namespace GMAO
{
	// Token: 0x0200002B RID: 43
	public partial class bl_non_facture_st : global::System.Windows.Forms.Form
	{
		// Token: 0x0600022D RID: 557 RVA: 0x0005CB20 File Offset: 0x0005AD20
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0005CB58 File Offset: 0x0005AD58
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.bl_non_facture_st));
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn = new global::Telerik.WinControls.UI.GridViewCheckBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.label10 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.panel1.SuspendLayout();
			this.radDateTimePicker1.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.TextBox2);
			this.panel1.Controls.Add(this.radDateTimePicker1);
			this.panel1.Controls.Add(this.pictureBox3);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.guna2Button2);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.TextBox1);
			this.panel1.Location = new global::System.Drawing.Point(907, 50);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(181, 269);
			this.panel1.TabIndex = 180;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(4, 136);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(63, 15);
			this.label1.TabIndex = 213;
			this.label1.Text = "N° Facture";
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
			this.TextBox2.Location = new global::System.Drawing.Point(8, 158);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(169, 29);
			this.TextBox2.TabIndex = 214;
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(7, 91);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(148, 27);
			this.radDateTimePicker1.TabIndex = 210;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "10/02/2021";
			this.radDateTimePicker1.ThemeName = "Crystal";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 2, 10, 16, 51, 18, 838);
			((global::Telerik.WinControls.UI.RadDateTimePickerElement)this.radDateTimePicker1.GetChildAt(0)).CalendarSize = new global::System.Drawing.Size(290, 320);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.pictureBox3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(149, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(27, 22);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 193;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click);
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DimGray;
			this.label5.Location = new global::System.Drawing.Point(4, 73);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(76, 15);
			this.label5.TabIndex = 209;
			this.label5.Text = "Date Facture";
			this.guna2Button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.guna2Button2.BorderRadius = 8;
			this.guna2Button2.CheckedState.Parent = this.guna2Button2;
			this.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button2.CustomImages.Parent = this.guna2Button2;
			this.guna2Button2.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.HoverState.Parent = this.guna2Button2;
			this.guna2Button2.Location = new global::System.Drawing.Point(3, 214);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
			this.guna2Button2.Size = new global::System.Drawing.Size(124, 30);
			this.guna2Button2.TabIndex = 178;
			this.guna2Button2.Text = "Enregistrer";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.DimGray;
			this.label10.Location = new global::System.Drawing.Point(3, 13);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(38, 15);
			this.label10.TabIndex = 174;
			this.label10.Text = "TVA %";
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
			this.TextBox1.Location = new global::System.Drawing.Point(7, 32);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(169, 29);
			this.TextBox1.TabIndex = 175;
			this.guna2Button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(907, 14);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(169, 30);
			this.guna2Button1.TabIndex = 179;
			this.guna2Button1.Text = "Créer Facture";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(4, 14);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.HeaderText = "N° BL";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column8";
			gridViewTextBoxColumn2.Width = 100;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Date BL";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.ReadOnly = true;
			gridViewTextBoxColumn3.Width = 120;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Date Saisie";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column2";
			gridViewTextBoxColumn4.ReadOnly = true;
			gridViewTextBoxColumn4.Width = 150;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Créateur";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column3";
			gridViewTextBoxColumn5.ReadOnly = true;
			gridViewTextBoxColumn5.Width = 150;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Fournisseur";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column6";
			gridViewTextBoxColumn6.ReadOnly = true;
			gridViewTextBoxColumn6.Width = 200;
			gridViewTextBoxColumn7.HeaderText = "Tot HT";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column9";
			gridViewTextBoxColumn7.Width = 120;
			gridViewCheckBoxColumn.EnableExpressionEditor = false;
			gridViewCheckBoxColumn.MinWidth = 20;
			gridViewCheckBoxColumn.Name = "column4";
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column7";
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7,
				gridViewCheckBoxColumn,
				gridViewImageColumn
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
			this.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.ShowHeaderCellButtons = true;
			this.radGridView1.Size = new global::System.Drawing.Size(886, 475);
			this.radGridView1.TabIndex = 178;
			this.radGridView1.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 501);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radGridView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "bl_non_facture_st";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.bl_non_facture_st_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radDateTimePicker1.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000302 RID: 770
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000303 RID: 771
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000304 RID: 772
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04000305 RID: 773
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000306 RID: 774
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000307 RID: 775
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x04000308 RID: 776
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000309 RID: 777
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x0400030A RID: 778
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x0400030B RID: 779
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x0400030C RID: 780
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400030D RID: 781
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400030E RID: 782
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;
	}
}
