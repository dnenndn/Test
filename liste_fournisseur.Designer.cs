namespace GMAO
{
	// Token: 0x0200013D RID: 317
	public partial class liste_fournisseur : global::System.Windows.Forms.Form
	{
		// Token: 0x06000E43 RID: 3651 RVA: 0x0022D2C4 File Offset: 0x0022B4C4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x0022D2FC File Offset: 0x0022B4FC
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.liste_fournisseur));
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.breezeTheme1 = new global::Telerik.WinControls.Themes.BreezeTheme();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.office2007SilverTheme1 = new global::Telerik.WinControls.Themes.Office2007SilverTheme();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel3.SuspendLayout();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel2.Location = new global::System.Drawing.Point(1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 6;
			this.panel1.Location = new global::System.Drawing.Point(-3, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 5;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel3.Controls.Add(this.radGridView1);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Location = new global::System.Drawing.Point(8, 68);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1127, 536);
			this.panel3.TabIndex = 7;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.Location = new global::System.Drawing.Point(0, 197);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.HeaderText = "Code Fournisseur";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.HeaderText = "Nom";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 170;
			gridViewTextBoxColumn4.HeaderText = "Type";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column3";
			gridViewTextBoxColumn4.Width = 150;
			gridViewTextBoxColumn5.HeaderText = "Type d'activité";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column7";
			gridViewTextBoxColumn5.Width = 200;
			gridViewTextBoxColumn6.HeaderText = "Activité";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column8";
			gridViewTextBoxColumn6.Width = 150;
			gridViewTextBoxColumn7.HeaderText = "TVA (%)";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column9";
			gridViewTextBoxColumn7.Width = 150;
			gridViewTextBoxColumn8.HeaderText = "Remise (%)";
			gridViewTextBoxColumn8.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn8.Name = "column10";
			gridViewTextBoxColumn8.Width = 150;
			gridViewTextBoxColumn9.HeaderText = "Devise";
			gridViewTextBoxColumn9.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn9.Name = "column14";
			gridViewTextBoxColumn9.Width = 150;
			gridViewTextBoxColumn10.HeaderText = "Délai de livr (jour)";
			gridViewTextBoxColumn10.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn10.Name = "column12";
			gridViewTextBoxColumn10.Width = 150;
			gridViewTextBoxColumn11.HeaderText = "Commentaire";
			gridViewTextBoxColumn11.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn11.Name = "column11";
			gridViewTextBoxColumn11.Width = 250;
			gridViewImageColumn.HeaderText = "";
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column4";
			gridViewImageColumn.Width = 60;
			gridViewImageColumn2.HeaderText = "";
			gridViewImageColumn2.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn2.Name = "column6";
			gridViewImageColumn2.Width = 60;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7,
				gridViewTextBoxColumn8,
				gridViewTextBoxColumn9,
				gridViewTextBoxColumn10,
				gridViewTextBoxColumn11,
				gridViewImageColumn,
				gridViewImageColumn2
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
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
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.ShowHeaderCellButtons = true;
			this.radGridView1.Size = new global::System.Drawing.Size(1095, 322);
			this.radGridView1.TabIndex = 76;
			this.radGridView1.ThemeName = "Fluent";
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1127, 188);
			this.panel4.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(5, 48);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(68, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Filtre avancé";
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			this.panel5.Location = new global::System.Drawing.Point(71, 57);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(1072, 10);
			this.panel5.TabIndex = 9;
			this.panel5.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
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
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label3.Location = new global::System.Drawing.Point(888, 162);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(69, 19);
			this.label3.TabIndex = 173;
			this.label3.Text = "Records :";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(823, 162);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(69, 19);
			this.label2.TabIndex = 172;
			this.label2.Text = "Records :";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "liste_fournisseur";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.liste_fournisseur_Load);
			this.panel3.ResumeLayout(false);
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040011FC RID: 4604
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040011FD RID: 4605
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040011FE RID: 4606
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040011FF RID: 4607
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04001200 RID: 4608
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04001201 RID: 4609
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04001202 RID: 4610
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04001203 RID: 4611
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04001204 RID: 4612
		private global::Telerik.WinControls.Themes.BreezeTheme breezeTheme1;

		// Token: 0x04001205 RID: 4613
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x04001206 RID: 4614
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04001207 RID: 4615
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04001208 RID: 4616
		private global::Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;

		// Token: 0x04001209 RID: 4617
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x0400120A RID: 4618
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400120B RID: 4619
		private global::System.Windows.Forms.Label label2;
	}
}
