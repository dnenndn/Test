namespace GMAO
{
	// Token: 0x0200013B RID: 315
	public partial class liste_da : global::System.Windows.Forms.Form
	{
		// Token: 0x06000E25 RID: 3621 RVA: 0x00228E54 File Offset: 0x00227054
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x00228E8C File Offset: 0x0022708C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.liste_da));
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn3 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			global::GMAO.liste_da.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			global::GMAO.liste_da.radGridView1.BeginInit();
			global::GMAO.liste_da.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
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
			this.imageList1.Images.SetKeyName(10, "icons8-visible-96.png");
			global::GMAO.liste_da.radGridView1.BackColor = global::System.Drawing.Color.White;
			global::GMAO.liste_da.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			global::GMAO.liste_da.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			global::GMAO.liste_da.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			global::GMAO.liste_da.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			global::GMAO.liste_da.radGridView1.Location = new global::System.Drawing.Point(17, 15);
			global::GMAO.liste_da.radGridView1.MasterTemplate.AllowAddNewRow = false;
			global::GMAO.liste_da.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			global::GMAO.liste_da.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			global::GMAO.liste_da.radGridView1.MasterTemplate.AllowColumnReorder = false;
			global::GMAO.liste_da.radGridView1.MasterTemplate.AllowDeleteRow = false;
			global::GMAO.liste_da.radGridView1.MasterTemplate.AllowDragToGroup = false;
			global::GMAO.liste_da.radGridView1.MasterTemplate.AllowEditRow = false;
			global::GMAO.liste_da.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			global::GMAO.liste_da.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.AllowSort = false;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Date";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.AllowSort = false;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Heure";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 170;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Créateur";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column3";
			gridViewTextBoxColumn4.Width = 150;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Demandeur";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column7";
			gridViewTextBoxColumn5.Width = 200;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Delai Souhaité";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column8";
			gridViewTextBoxColumn6.Width = 150;
			gridViewCommandColumn.EnableExpressionEditor = false;
			gridViewCommandColumn.Name = "column10";
			gridViewCommandColumn.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewCommandColumn.Width = 80;
			gridViewCommandColumn2.EnableExpressionEditor = false;
			gridViewCommandColumn2.Name = "column11";
			gridViewCommandColumn2.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewCommandColumn2.Width = 80;
			gridViewCommandColumn3.EnableExpressionEditor = false;
			gridViewCommandColumn3.Name = "column12";
			gridViewCommandColumn3.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewCommandColumn3.Width = 120;
			gridViewCommandColumn4.EnableExpressionEditor = false;
			gridViewCommandColumn4.Name = "column13";
			gridViewCommandColumn4.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewCommandColumn4.Width = 80;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column4";
			gridViewImageColumn.Width = 60;
			gridViewImageColumn2.EnableExpressionEditor = false;
			gridViewImageColumn2.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn2.Name = "column6";
			gridViewImageColumn2.Width = 60;
			gridViewImageColumn3.EnableExpressionEditor = false;
			gridViewImageColumn3.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn3.Name = "column9";
			global::GMAO.liste_da.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewCommandColumn,
				gridViewCommandColumn2,
				gridViewCommandColumn3,
				gridViewCommandColumn4,
				gridViewImageColumn,
				gridViewImageColumn2,
				gridViewImageColumn3
			});
			global::GMAO.liste_da.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			global::GMAO.liste_da.radGridView1.MasterTemplate.EnableFiltering = true;
			global::GMAO.liste_da.radGridView1.MasterTemplate.EnablePaging = true;
			global::GMAO.liste_da.radGridView1.MasterTemplate.EnableSorting = false;
			global::GMAO.liste_da.radGridView1.MasterTemplate.ShowFilteringRow = false;
			global::GMAO.liste_da.radGridView1.MasterTemplate.ShowHeaderCellButtons = true;
			global::GMAO.liste_da.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			global::GMAO.liste_da.radGridView1.Name = "radGridView1";
			global::GMAO.liste_da.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			global::GMAO.liste_da.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.liste_da.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			global::GMAO.liste_da.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			global::GMAO.liste_da.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			global::GMAO.liste_da.radGridView1.ReadOnly = true;
			global::GMAO.liste_da.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			global::GMAO.liste_da.radGridView1.ShowGroupPanel = false;
			global::GMAO.liste_da.radGridView1.ShowHeaderCellButtons = true;
			global::GMAO.liste_da.radGridView1.Size = new global::System.Drawing.Size(1095, 528);
			global::GMAO.liste_da.radGridView1.TabIndex = 79;
			global::GMAO.liste_da.radGridView1.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(global::GMAO.liste_da.radGridView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "liste_da";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.liste_da_Load);
			global::GMAO.liste_da.radGridView1.MasterTemplate.EndInit();
			global::GMAO.liste_da.radGridView1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040011EF RID: 4591
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040011F0 RID: 4592
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x040011F1 RID: 4593
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040011F2 RID: 4594
		private static global::Telerik.WinControls.UI.RadGridView radGridView1;
	}
}
