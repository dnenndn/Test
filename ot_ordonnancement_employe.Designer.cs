namespace GMAO
{
	// Token: 0x020000C9 RID: 201
	public partial class ot_ordonnancement_employe : global::System.Windows.Forms.Form
	{
		// Token: 0x06000902 RID: 2306 RVA: 0x0017A338 File Offset: 0x00178538
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x0017A370 File Offset: 0x00178570
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.ot_ordonnancement_employe));
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label30 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.radDropDownList1.BeginInit();
			this.panel1.SuspendLayout();
			this.radButton1.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
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
			gridViewTextBoxColumn7.HeaderText = "Type des coûts";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column4";
			gridViewTextBoxColumn7.Width = 150;
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
				gridViewTextBoxColumn7,
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
			this.radGridView3.TabIndex = 246;
			this.radGridView3.ThemeName = "Fluent";
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(5, 24);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(250, 24);
			this.radDropDownList1.TabIndex = 259;
			this.radDropDownList1.ThemeName = "Fluent";
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.DimGray;
			this.label30.Location = new global::System.Drawing.Point(3, 9);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(128, 12);
			this.label30.TabIndex = 258;
			this.label30.Text = "Choisir un intervenant";
			this.panel1.Controls.Add(this.pictureBox3);
			this.panel1.Controls.Add(this.radButton1);
			this.panel1.Controls.Add(this.radDropDownList1);
			this.panel1.Controls.Add(this.label30);
			this.panel1.Location = new global::System.Drawing.Point(12, 154);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(564, 66);
			this.panel1.TabIndex = 247;
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(273, 24);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 277;
			this.radButton1.Text = "Ajouter";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.pictureBox3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(396, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(27, 22);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 278;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.radGridView3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_ordonnancement_employe";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_ordonnancement_employe_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.radDropDownList1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radButton1.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000C18 RID: 3096
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000C19 RID: 3097
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000C1A RID: 3098
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000C1B RID: 3099
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000C1C RID: 3100
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x04000C1D RID: 3101
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000C1E RID: 3102
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000C1F RID: 3103
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000C20 RID: 3104
		private global::System.Windows.Forms.PictureBox pictureBox3;
	}
}
