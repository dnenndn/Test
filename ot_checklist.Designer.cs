namespace GMAO
{
	// Token: 0x020000B2 RID: 178
	public partial class ot_checklist : global::System.Windows.Forms.Form
	{
		// Token: 0x06000810 RID: 2064 RVA: 0x0015D5F0 File Offset: 0x0015B7F0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x0015D628 File Offset: 0x0015B828
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
			global::Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn = new global::Telerik.WinControls.UI.GridViewCheckBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.radRadioButton8 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton7 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radDropDownList3 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label3 = new global::System.Windows.Forms.Label();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.panel3.SuspendLayout();
			this.radButton1.BeginInit();
			this.radRadioButton8.BeginInit();
			this.radRadioButton7.BeginInit();
			this.panel1.SuspendLayout();
			this.radDropDownList3.BeginInit();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.panel3.Controls.Add(this.radButton1);
			this.panel3.Controls.Add(this.radRadioButton8);
			this.panel3.Controls.Add(this.radRadioButton7);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1107, 40);
			this.panel3.TabIndex = 10;
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(951, 4);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 276;
			this.radButton1.Text = "Afficher";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.radRadioButton8.Location = new global::System.Drawing.Point(133, 3);
			this.radRadioButton8.Name = "radRadioButton8";
			this.radRadioButton8.Size = new global::System.Drawing.Size(45, 18);
			this.radRadioButton8.TabIndex = 10;
			this.radRadioButton8.TabStop = false;
			this.radRadioButton8.Text = "Tous";
			this.radRadioButton8.ThemeName = "Fluent";
			this.radRadioButton8.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton8_ToggleStateChanged);
			this.radRadioButton7.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton7.Location = new global::System.Drawing.Point(3, 3);
			this.radRadioButton7.Name = "radRadioButton7";
			this.radRadioButton7.Size = new global::System.Drawing.Size(125, 18);
			this.radRadioButton7.TabIndex = 2;
			this.radRadioButton7.TabStop = false;
			this.radRadioButton7.Text = "Plan de maintenance";
			this.radRadioButton7.ThemeName = "Fluent";
			this.radRadioButton7.ToggleState = 1;
			this.radRadioButton7.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton7_ToggleStateChanged);
			this.panel1.Controls.Add(this.radDropDownList3);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1107, 44);
			this.panel1.TabIndex = 11;
			this.radDropDownList3.DropDownStyle = 2;
			this.radDropDownList3.Location = new global::System.Drawing.Point(5, 18);
			this.radDropDownList3.Name = "radDropDownList3";
			this.radDropDownList3.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList3.TabIndex = 264;
			this.radDropDownList3.ThemeName = "Fluent";
			this.radDropDownList3.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList3_SelectedIndexChanged);
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label3.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(3, 3);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(122, 12);
			this.label3.TabIndex = 263;
			this.label3.Text = "Plan de maintenance";
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(0, 84);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.HeaderText = "id_ot";
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column7";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn2.HeaderText = "id_gamme";
			gridViewTextBoxColumn2.IsVisible = false;
			gridViewTextBoxColumn2.Name = "column3";
			gridViewTextBoxColumn2.ReadOnly = true;
			gridViewTextBoxColumn3.HeaderText = "Equipement";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column5";
			gridViewTextBoxColumn3.ReadOnly = true;
			gridViewTextBoxColumn3.Width = 180;
			gridViewTextBoxColumn4.HeaderText = "Gamme Opératoire";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column11";
			gridViewTextBoxColumn4.ReadOnly = true;
			gridViewTextBoxColumn4.Width = 200;
			gridViewTextBoxColumn5.HeaderText = "Etat";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column1";
			gridViewTextBoxColumn5.ReadOnly = true;
			gridViewTextBoxColumn5.Width = 130;
			gridViewTextBoxColumn6.HeaderText = "Superviseur";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column2";
			gridViewTextBoxColumn6.ReadOnly = true;
			gridViewTextBoxColumn6.Width = 200;
			gridViewTextBoxColumn7.HeaderText = "Opération";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column6";
			gridViewTextBoxColumn7.ReadOnly = true;
			gridViewTextBoxColumn7.Width = 150;
			gridViewTextBoxColumn8.HeaderText = "Début Prévu";
			gridViewTextBoxColumn8.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn8.Name = "column8";
			gridViewTextBoxColumn8.ReadOnly = true;
			gridViewTextBoxColumn8.Width = 120;
			gridViewTextBoxColumn9.HeaderText = "fin prevue";
			gridViewTextBoxColumn9.IsVisible = false;
			gridViewTextBoxColumn9.Name = "column9";
			gridViewCheckBoxColumn.HeaderText = "";
			gridViewCheckBoxColumn.Name = "column4";
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
				gridViewCheckBoxColumn
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
			this.radGridView3.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView3.ShowGroupPanel = false;
			this.radGridView3.Size = new global::System.Drawing.Size(1107, 383);
			this.radGridView3.TabIndex = 258;
			this.radGridView3.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1107, 520);
			base.Controls.Add(this.radGridView3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_checklist";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_checklist_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radButton1.EndInit();
			this.radRadioButton8.EndInit();
			this.radRadioButton7.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radDropDownList3.EndInit();
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000B0B RID: 2827
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000B0C RID: 2828
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000B0D RID: 2829
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton8;

		// Token: 0x04000B0E RID: 2830
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton7;

		// Token: 0x04000B0F RID: 2831
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000B10 RID: 2832
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000B11 RID: 2833
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000B12 RID: 2834
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList3;

		// Token: 0x04000B13 RID: 2835
		internal global::System.Windows.Forms.Label label3;

		// Token: 0x04000B14 RID: 2836
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000B15 RID: 2837
		public global::Telerik.WinControls.UI.RadGridView radGridView3;
	}
}
