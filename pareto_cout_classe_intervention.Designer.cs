namespace GMAO
{
	// Token: 0x020000F4 RID: 244
	public partial class pareto_cout_classe_intervention : global::System.Windows.Forms.Form
	{
		// Token: 0x06000AA0 RID: 2720 RVA: 0x001A0C7C File Offset: 0x0019EE7C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x001A0CB4 File Offset: 0x0019EEB4
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
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::Telerik.WinControls.UI.CartesianArea areaDesign = new global::Telerik.WinControls.UI.CartesianArea();
			global::Telerik.WinControls.UI.RadListDataItem radListDataItem = new global::Telerik.WinControls.UI.RadListDataItem();
			global::Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new global::Telerik.WinControls.UI.RadListDataItem();
			global::Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new global::Telerik.WinControls.UI.RadListDataItem();
			global::Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new global::Telerik.WinControls.UI.RadListDataItem();
			global::Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new global::Telerik.WinControls.UI.RadListDataItem();
			global::Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new global::Telerik.WinControls.UI.RadListDataItem();
			global::Telerik.WinControls.UI.RadListDataItem radListDataItem7 = new global::Telerik.WinControls.UI.RadListDataItem();
			global::Telerik.WinControls.UI.RadListDataItem radListDataItem8 = new global::Telerik.WinControls.UI.RadListDataItem();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radRadioButton8 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton7 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radDomainUpDown4 = new global::Telerik.WinControls.UI.RadDomainUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			this.radDomainUpDown3 = new global::Telerik.WinControls.UI.RadDomainUpDown();
			this.label3 = new global::System.Windows.Forms.Label();
			this.radDomainUpDown2 = new global::Telerik.WinControls.UI.RadDomainUpDown();
			this.label2 = new global::System.Windows.Forms.Label();
			this.radDomainUpDown1 = new global::Telerik.WinControls.UI.RadDomainUpDown();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.radChartView1.BeginInit();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.radRadioButton8.BeginInit();
			this.radRadioButton7.BeginInit();
			this.radDomainUpDown4.BeginInit();
			this.radDomainUpDown3.BeginInit();
			this.radDomainUpDown2.BeginInit();
			this.radDomainUpDown1.BeginInit();
			base.SuspendLayout();
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(3, 52);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "Classe d'intervention";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column11";
			gridViewTextBoxColumn.Width = 250;
			gridViewTextBoxColumn2.HeaderText = "Coût MO";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 100;
			gridViewTextBoxColumn3.HeaderText = "Coût PDR";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 100;
			gridViewTextBoxColumn4.HeaderText = "Coût Rép. externe";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column3";
			gridViewTextBoxColumn4.Width = 120;
			gridViewTextBoxColumn5.HeaderText = "Coût Projet";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column4";
			gridViewTextBoxColumn5.Width = 100;
			gridViewTextBoxColumn6.HeaderText = "Coût Total";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column5";
			gridViewTextBoxColumn6.Width = 100;
			gridViewTextBoxColumn7.HeaderText = "Pourcentage";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column6";
			gridViewTextBoxColumn7.Width = 100;
			gridViewTextBoxColumn8.HeaderText = "Pourcentage cum";
			gridViewTextBoxColumn8.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn8.Name = "column8";
			gridViewTextBoxColumn8.Width = 150;
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7,
				gridViewTextBoxColumn8
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
			this.radGridView3.Size = new global::System.Drawing.Size(1087, 372);
			this.radGridView3.TabIndex = 254;
			this.radGridView3.ThemeName = "Fluent";
			this.radChartView1.AreaDesign = areaDesign;
			this.radChartView1.Location = new global::System.Drawing.Point(3, 53);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.Size = new global::System.Drawing.Size(1079, 374);
			this.radChartView1.TabIndex = 253;
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.radDomainUpDown4);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.radDomainUpDown3);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.radDomainUpDown2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.radDomainUpDown1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new global::System.Drawing.Point(3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1092, 48);
			this.panel1.TabIndex = 251;
			this.panel3.Controls.Add(this.radRadioButton8);
			this.panel3.Controls.Add(this.radRadioButton7);
			this.panel3.Location = new global::System.Drawing.Point(381, 1);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(388, 47);
			this.panel3.TabIndex = 9;
			this.radRadioButton8.Location = new global::System.Drawing.Point(3, 24);
			this.radRadioButton8.Name = "radRadioButton8";
			this.radRadioButton8.Size = new global::System.Drawing.Size(60, 18);
			this.radRadioButton8.TabIndex = 10;
			this.radRadioButton8.TabStop = false;
			this.radRadioButton8.Text = "Tableau";
			this.radRadioButton8.ThemeName = "Fluent";
			this.radRadioButton8.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton8_ToggleStateChanged);
			this.radRadioButton7.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton7.Location = new global::System.Drawing.Point(3, 3);
			this.radRadioButton7.Name = "radRadioButton7";
			this.radRadioButton7.Size = new global::System.Drawing.Size(73, 18);
			this.radRadioButton7.TabIndex = 2;
			this.radRadioButton7.TabStop = false;
			this.radRadioButton7.Text = "Graphique";
			this.radRadioButton7.ThemeName = "Fluent";
			this.radRadioButton7.ToggleState = 1;
			this.radRadioButton7.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton7_ToggleStateChanged);
			radListDataItem.Text = "1";
			radListDataItem2.Text = "0";
			this.radDomainUpDown4.Items.Add(radListDataItem);
			this.radDomainUpDown4.Items.Add(radListDataItem2);
			this.radDomainUpDown4.Location = new global::System.Drawing.Point(292, 20);
			this.radDomainUpDown4.Name = "radDomainUpDown4";
			this.radDomainUpDown4.ReadOnly = true;
			this.radDomainUpDown4.Size = new global::System.Drawing.Size(83, 24);
			this.radDomainUpDown4.TabIndex = 7;
			this.radDomainUpDown4.ThemeName = "Fluent";
			this.radDomainUpDown4.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDomainUpDown4_SelectedIndexChanged);
			this.label4.AutoSize = true;
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(289, 4);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(34, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Projet";
			radListDataItem3.Text = "1";
			radListDataItem4.Text = "0";
			this.radDomainUpDown3.Items.Add(radListDataItem3);
			this.radDomainUpDown3.Items.Add(radListDataItem4);
			this.radDomainUpDown3.Location = new global::System.Drawing.Point(189, 20);
			this.radDomainUpDown3.Name = "radDomainUpDown3";
			this.radDomainUpDown3.ReadOnly = true;
			this.radDomainUpDown3.Size = new global::System.Drawing.Size(94, 24);
			this.radDomainUpDown3.TabIndex = 5;
			this.radDomainUpDown3.ThemeName = "Fluent";
			this.radDomainUpDown3.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDomainUpDown3_SelectedIndexChanged);
			this.label3.AutoSize = true;
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(186, 4);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(97, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Réparation externe";
			radListDataItem5.Text = "1";
			radListDataItem6.Text = "0";
			this.radDomainUpDown2.Items.Add(radListDataItem5);
			this.radDomainUpDown2.Items.Add(radListDataItem6);
			this.radDomainUpDown2.Location = new global::System.Drawing.Point(98, 20);
			this.radDomainUpDown2.Name = "radDomainUpDown2";
			this.radDomainUpDown2.ReadOnly = true;
			this.radDomainUpDown2.Size = new global::System.Drawing.Size(83, 24);
			this.radDomainUpDown2.TabIndex = 3;
			this.radDomainUpDown2.ThemeName = "Fluent";
			this.radDomainUpDown2.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDomainUpDown2_SelectedIndexChanged);
			this.label2.AutoSize = true;
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(95, 4);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(30, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "PDR";
			radListDataItem7.Text = "1";
			radListDataItem8.Text = "0";
			this.radDomainUpDown1.Items.Add(radListDataItem7);
			this.radDomainUpDown1.Items.Add(radListDataItem8);
			this.radDomainUpDown1.Location = new global::System.Drawing.Point(6, 20);
			this.radDomainUpDown1.Name = "radDomainUpDown1";
			this.radDomainUpDown1.ReadOnly = true;
			this.radDomainUpDown1.Size = new global::System.Drawing.Size(83, 24);
			this.radDomainUpDown1.TabIndex = 1;
			this.radDomainUpDown1.ThemeName = "Fluent";
			this.radDomainUpDown1.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDomainUpDown1_SelectedIndexChanged);
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(3, 4);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(24, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "MO";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1098, 430);
			base.Controls.Add(this.radGridView3);
			base.Controls.Add(this.radChartView1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "pareto_cout_classe_intervention";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.pareto_cout_classe_intervention_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.radChartView1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radRadioButton8.EndInit();
			this.radRadioButton7.EndInit();
			this.radDomainUpDown4.EndInit();
			this.radDomainUpDown3.EndInit();
			this.radDomainUpDown2.EndInit();
			this.radDomainUpDown1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000D98 RID: 3480
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000D99 RID: 3481
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000D9A RID: 3482
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000D9B RID: 3483
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000D9C RID: 3484
		private global::Telerik.WinControls.UI.RadChartView radChartView1;

		// Token: 0x04000D9D RID: 3485
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000D9E RID: 3486
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000D9F RID: 3487
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton8;

		// Token: 0x04000DA0 RID: 3488
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton7;

		// Token: 0x04000DA1 RID: 3489
		private global::Telerik.WinControls.UI.RadDomainUpDown radDomainUpDown4;

		// Token: 0x04000DA2 RID: 3490
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000DA3 RID: 3491
		private global::Telerik.WinControls.UI.RadDomainUpDown radDomainUpDown3;

		// Token: 0x04000DA4 RID: 3492
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000DA5 RID: 3493
		private global::Telerik.WinControls.UI.RadDomainUpDown radDomainUpDown2;

		// Token: 0x04000DA6 RID: 3494
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000DA7 RID: 3495
		private global::Telerik.WinControls.UI.RadDomainUpDown radDomainUpDown1;

		// Token: 0x04000DA8 RID: 3496
		private global::System.Windows.Forms.Label label1;
	}
}
