namespace GMAO
{
	// Token: 0x020000DC RID: 220
	public partial class ot_tb_cout_mo : global::System.Windows.Forms.Form
	{
		// Token: 0x060009BD RID: 2493 RVA: 0x0018A694 File Offset: 0x00188894
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0018A6CC File Offset: 0x001888CC
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.bunifuCards1 = new global::Bunifu.Framework.UI.BunifuCards();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label30 = new global::System.Windows.Forms.Label();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.bunifuCards1.SuspendLayout();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.bunifuCards1.BackColor = global::System.Drawing.Color.White;
			this.bunifuCards1.BorderRadius = 5;
			this.bunifuCards1.BottomSahddow = true;
			this.bunifuCards1.color = global::System.Drawing.Color.Firebrick;
			this.bunifuCards1.Controls.Add(this.label1);
			this.bunifuCards1.Controls.Add(this.label30);
			this.bunifuCards1.LeftSahddow = false;
			this.bunifuCards1.Location = new global::System.Drawing.Point(3, 12);
			this.bunifuCards1.Name = "bunifuCards1";
			this.bunifuCards1.RightSahddow = true;
			this.bunifuCards1.ShadowDepth = 20;
			this.bunifuCards1.Size = new global::System.Drawing.Size(398, 31);
			this.bunifuCards1.TabIndex = 253;
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(93, 11);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(39, 12);
			this.label1.TabIndex = 256;
			this.label1.Text = "label1";
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.Black;
			this.label30.Location = new global::System.Drawing.Point(3, 11);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(92, 12);
			this.label30.TabIndex = 255;
			this.label30.Text = "Coût Total MO : ";
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(3, 45);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.HeaderText = "Intervenant";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.Width = 300;
			gridViewTextBoxColumn2.HeaderText = "Coût Unitaire";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column3";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.HeaderText = "Heures d'intervention";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 200;
			gridViewTextBoxColumn4.HeaderText = "Coût Total";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column2";
			gridViewTextBoxColumn4.Width = 150;
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4
			});
			this.radGridView3.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView3.MasterTemplate.EnableFiltering = true;
			this.radGridView3.MasterTemplate.EnableSorting = false;
			this.radGridView3.MasterTemplate.ShowFilteringRow = false;
			this.radGridView3.MasterTemplate.VerticalScrollState = 2;
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
			this.radGridView3.Size = new global::System.Drawing.Size(895, 402);
			this.radGridView3.TabIndex = 252;
			this.radGridView3.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1091, 449);
			base.Controls.Add(this.bunifuCards1);
			base.Controls.Add(this.radGridView3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_tb_cout_mo";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_tb_cout_mo_Load);
			this.bunifuCards1.ResumeLayout(false);
			this.bunifuCards1.PerformLayout();
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000CB5 RID: 3253
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000CB6 RID: 3254
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000CB7 RID: 3255
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000CB8 RID: 3256
		private global::Bunifu.Framework.UI.BunifuCards bunifuCards1;

		// Token: 0x04000CB9 RID: 3257
		internal global::System.Windows.Forms.Label label1;

		// Token: 0x04000CBA RID: 3258
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000CBB RID: 3259
		public global::Telerik.WinControls.UI.RadGridView radGridView3;
	}
}
