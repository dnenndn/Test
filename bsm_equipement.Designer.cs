namespace GMAO
{
	// Token: 0x02000032 RID: 50
	public partial class bsm_equipement : global::System.Windows.Forms.Form
	{
		// Token: 0x06000261 RID: 609 RVA: 0x00066A9C File Offset: 0x00064C9C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00066AD4 File Offset: 0x00064CD4
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			global::GMAO.bsm_equipement.radGridView2 = new global::Telerik.WinControls.UI.RadGridView();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			global::GMAO.bsm_equipement.radGridView2.BeginInit();
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Red;
			this.label4.Location = new global::System.Drawing.Point(290, 1);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(17, 19);
			this.label4.TabIndex = 186;
			this.label4.Text = "*";
			this.label5.AutoSize = true;
			this.label5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label5.Location = new global::System.Drawing.Point(24, 6);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(269, 14);
			this.label5.TabIndex = 185;
			this.label5.Text = "Choisir l'emplacement dans l'arbre équipement";
			this.label5.Click += new global::System.EventHandler(this.label5_Click);
			global::GMAO.bsm_equipement.radGridView2.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.bsm_equipement.radGridView2.Location = new global::System.Drawing.Point(27, 66);
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.AllowAddNewRow = false;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.AllowCellContextMenu = false;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.AllowColumnHeaderContextMenu = false;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.AllowColumnReorder = false;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.AllowDeleteRow = false;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.AllowDragToGroup = false;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.AllowEditRow = false;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn2.AllowSort = false;
			gridViewTextBoxColumn2.HeaderText = "Désignation";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 275;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2
			});
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.EnableAlternatingRowColor = true;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.EnableFiltering = true;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.EnableSorting = false;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.ShowColumnHeaders = false;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.ShowFilteringRow = false;
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.ViewDefinition = viewDefinition;
			global::GMAO.bsm_equipement.radGridView2.Name = "radGridView2";
			global::GMAO.bsm_equipement.radGridView2.Padding = new global::System.Windows.Forms.Padding(1);
			global::GMAO.bsm_equipement.radGridView2.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.bsm_equipement.radGridView2.PrintStyle.ChildViewPrintMode = 0;
			global::GMAO.bsm_equipement.radGridView2.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			global::GMAO.bsm_equipement.radGridView2.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			global::GMAO.bsm_equipement.radGridView2.ReadOnly = true;
			global::GMAO.bsm_equipement.radGridView2.ShowGroupPanel = false;
			global::GMAO.bsm_equipement.radGridView2.Size = new global::System.Drawing.Size(928, 53);
			global::GMAO.bsm_equipement.radGridView2.TabIndex = 187;
			global::GMAO.bsm_equipement.radGridView2.ThemeName = "Fluent";
			this.pictureBox2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox2.Image = global::GMAO.Properties.Resources.icons8_structure_en_arbre_80;
			this.pictureBox2.Location = new global::System.Drawing.Point(12, 23);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(53, 25);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 184;
			this.pictureBox2.TabStop = false;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(851, 23);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button1.TabIndex = 190;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1081, 131);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(global::GMAO.bsm_equipement.radGridView2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.pictureBox2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "bsm_equipement";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.bsm_equipement_Load);
			global::GMAO.bsm_equipement.radGridView2.MasterTemplate.EndInit();
			global::GMAO.bsm_equipement.radGridView2.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400032E RID: 814
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400032F RID: 815
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000330 RID: 816
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000331 RID: 817
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x04000332 RID: 818
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000333 RID: 819
		public static global::Telerik.WinControls.UI.RadGridView radGridView2;
	}
}
