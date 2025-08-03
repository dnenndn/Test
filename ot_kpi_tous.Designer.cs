namespace GMAO
{
	// Token: 0x020000C3 RID: 195
	public partial class ot_kpi_tous : global::System.Windows.Forms.Form
	{
		// Token: 0x060008BB RID: 2235 RVA: 0x00172974 File Offset: 0x00170B74
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x001729AC File Offset: 0x00170BAC
		private void InitializeComponent()
		{
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
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.ProgressBar1 = new global::Bunifu.Framework.UI.BunifuProgressBar();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.radGridView3.SuspendLayout();
			base.SuspendLayout();
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Controls.Add(this.ProgressBar1);
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(12, 39);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "Code Equipement";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column11";
			gridViewTextBoxColumn.Width = 200;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Désignation";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column7";
			gridViewTextBoxColumn2.Width = 300;
			gridViewTextBoxColumn3.HeaderText = "Nbre OT";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 70;
			gridViewTextBoxColumn4.HeaderText = "TTR";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column2";
			gridViewTextBoxColumn4.Width = 70;
			gridViewTextBoxColumn5.HeaderText = "MTTR";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column3";
			gridViewTextBoxColumn5.Width = 70;
			gridViewTextBoxColumn6.HeaderText = "TBF";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column4";
			gridViewTextBoxColumn6.Width = 70;
			gridViewTextBoxColumn7.HeaderText = "MTBF";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column5";
			gridViewTextBoxColumn7.Width = 70;
			gridViewTextBoxColumn8.HeaderText = "Da";
			gridViewTextBoxColumn8.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn8.Name = "column6";
			gridViewTextBoxColumn8.Width = 60;
			gridViewTextBoxColumn9.HeaderText = "λ";
			gridViewTextBoxColumn9.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn9.Name = "column8";
			gridViewTextBoxColumn9.Width = 60;
			gridViewTextBoxColumn10.HeaderText = "µ";
			gridViewTextBoxColumn10.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn10.Name = "column9";
			gridViewTextBoxColumn10.Width = 60;
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
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
				gridViewTextBoxColumn10
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
			this.radGridView3.Size = new global::System.Drawing.Size(1087, 408);
			this.radGridView3.TabIndex = 249;
			this.radGridView3.ThemeName = "Fluent";
			this.ProgressBar1.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.ProgressBar1.BorderRadius = 5;
			this.ProgressBar1.Location = new global::System.Drawing.Point(338, 146);
			this.ProgressBar1.MaximumValue = 100;
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.ProgressColor = global::System.Drawing.Color.Firebrick;
			this.ProgressBar1.Size = new global::System.Drawing.Size(435, 20);
			this.ProgressBar1.TabIndex = 251;
			this.ProgressBar1.Value = 0;
			this.label20.AutoSize = true;
			this.label20.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label20.ForeColor = global::System.Drawing.Color.DimGray;
			this.label20.Location = new global::System.Drawing.Point(12, 12);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(302, 15);
			this.label20.TabIndex = 250;
			this.label20.Text = "NB : Les grandeurs de temps sont exprimées en Heures";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(879, 2);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(201, 15);
			this.label1.TabIndex = 251;
			this.label1.Text = "λ : Taux de défaillance (en Heure -1)";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(879, 22);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(221, 15);
			this.label2.TabIndex = 252;
			this.label2.Text = "µ : Taux de maintenabilité (en Heure -1)";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1100, 454);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label20);
			base.Controls.Add(this.radGridView3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_kpi_tous";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_kpi_tous_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.radGridView3.ResumeLayout(false);
			this.radGridView3.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000BD6 RID: 3030
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000BD7 RID: 3031
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000BD8 RID: 3032
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000BD9 RID: 3033
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000BDA RID: 3034
		private global::Bunifu.Framework.UI.BunifuProgressBar ProgressBar1;

		// Token: 0x04000BDB RID: 3035
		private global::System.Windows.Forms.Label label20;

		// Token: 0x04000BDC RID: 3036
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000BDD RID: 3037
		private global::System.Windows.Forms.Label label2;
	}
}
