namespace GMAO
{
	// Token: 0x0200008D RID: 141
	public partial class liste_gamme_operatoire : global::System.Windows.Forms.Form
	{
		// Token: 0x0600069F RID: 1695 RVA: 0x0011FA68 File Offset: 0x0011DC68
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0011FAA0 File Offset: 0x0011DCA0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.liste_gamme_operatoire));
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.office2013LightTheme1 = new global::Telerik.WinControls.Themes.Office2013LightTheme();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			global::GMAO.liste_gamme_operatoire.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.crystalTheme2 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme2 = new global::Telerik.WinControls.Themes.FluentTheme();
			global::GMAO.liste_gamme_operatoire.radGridView1.BeginInit();
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.BeginInit();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
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
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.BackColor = global::System.Drawing.Color.White;
			global::GMAO.liste_gamme_operatoire.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			global::GMAO.liste_gamme_operatoire.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			global::GMAO.liste_gamme_operatoire.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			global::GMAO.liste_gamme_operatoire.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			global::GMAO.liste_gamme_operatoire.radGridView1.Location = new global::System.Drawing.Point(12, 12);
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.AllowAddNewRow = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.AllowColumnReorder = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.AllowDeleteRow = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.AllowDragToGroup = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.AllowEditRow = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.AllowSort = false;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Plan de Maintenance";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column2";
			gridViewTextBoxColumn2.Width = 200;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Code Gamme Opératoire";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column3";
			gridViewTextBoxColumn3.Width = 200;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Désignation";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column7";
			gridViewTextBoxColumn4.Width = 350;
			gridViewTextBoxColumn5.HeaderText = "Opération";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column6";
			gridViewTextBoxColumn5.Width = 150;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column1";
			gridViewImageColumn2.EnableExpressionEditor = false;
			gridViewImageColumn2.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn2.Name = "column4";
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewImageColumn,
				gridViewImageColumn2
			});
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.EnableFiltering = true;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.EnablePaging = true;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.EnableSorting = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.ShowFilteringRow = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.ShowHeaderCellButtons = true;
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			global::GMAO.liste_gamme_operatoire.radGridView1.Name = "radGridView1";
			global::GMAO.liste_gamme_operatoire.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			global::GMAO.liste_gamme_operatoire.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.liste_gamme_operatoire.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			global::GMAO.liste_gamme_operatoire.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			global::GMAO.liste_gamme_operatoire.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			global::GMAO.liste_gamme_operatoire.radGridView1.ReadOnly = true;
			global::GMAO.liste_gamme_operatoire.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			global::GMAO.liste_gamme_operatoire.radGridView1.ShowGroupPanel = false;
			global::GMAO.liste_gamme_operatoire.radGridView1.ShowHeaderCellButtons = true;
			global::GMAO.liste_gamme_operatoire.radGridView1.Size = new global::System.Drawing.Size(1077, 190);
			global::GMAO.liste_gamme_operatoire.radGridView1.TabIndex = 171;
			global::GMAO.liste_gamme_operatoire.radGridView1.ThemeName = "Fluent";
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Location = new global::System.Drawing.Point(12, 208);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1080, 291);
			this.panel1.TabIndex = 172;
			this.panel2.Location = new global::System.Drawing.Point(3, 30);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1074, 258);
			this.panel2.TabIndex = 270;
			this.panel4.Controls.Add(this.pictureBox3);
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Location = new global::System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1074, 25);
			this.panel4.TabIndex = 269;
			this.pictureBox3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(1036, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(27, 22);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 270;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click);
			this.button4.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.Black;
			this.button4.Location = new global::System.Drawing.Point(383, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(124, 25);
			this.button4.TabIndex = 4;
			this.button4.Text = "Fonction";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button3.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.Black;
			this.button3.Location = new global::System.Drawing.Point(259, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(124, 25);
			this.button3.TabIndex = 3;
			this.button3.Text = "Outillage";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button2.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.Black;
			this.button2.Location = new global::System.Drawing.Point(135, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(124, 25);
			this.button2.TabIndex = 2;
			this.button2.Text = "PDR";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button1.BackColor = global::System.Drawing.Color.White;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.Black;
			this.button1.Location = new global::System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(135, 25);
			this.button1.TabIndex = 1;
			this.button1.Text = "Général";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 501);
			base.Controls.Add(this.panel1);
			base.Controls.Add(global::GMAO.liste_gamme_operatoire.radGridView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "liste_gamme_operatoire";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.liste_gamme_operatoire_Load);
			global::GMAO.liste_gamme_operatoire.radGridView1.MasterTemplate.EndInit();
			global::GMAO.liste_gamme_operatoire.radGridView1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040008CC RID: 2252
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040008CD RID: 2253
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x040008CE RID: 2254
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040008CF RID: 2255
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x040008D0 RID: 2256
		private global::Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;

		// Token: 0x040008D1 RID: 2257
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x040008D2 RID: 2258
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x040008D3 RID: 2259
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x040008D4 RID: 2260
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040008D5 RID: 2261
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040008D6 RID: 2262
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x040008D7 RID: 2263
		public global::System.Windows.Forms.Button button4;

		// Token: 0x040008D8 RID: 2264
		public global::System.Windows.Forms.Button button3;

		// Token: 0x040008D9 RID: 2265
		public global::System.Windows.Forms.Button button2;

		// Token: 0x040008DA RID: 2266
		public global::System.Windows.Forms.Button button1;

		// Token: 0x040008DB RID: 2267
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040008DC RID: 2268
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme2;

		// Token: 0x040008DD RID: 2269
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme2;

		// Token: 0x040008DE RID: 2270
		private static global::Telerik.WinControls.UI.RadGridView radGridView1;
	}
}
