namespace GMAO
{
	// Token: 0x0200003D RID: 61
	public partial class cloturer_dop : global::System.Windows.Forms.Form
	{
		// Token: 0x060002B2 RID: 690 RVA: 0x00071A18 File Offset: 0x0006FC18
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00071A50 File Offset: 0x0006FC50
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
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.radTreeView1 = new global::Telerik.WinControls.UI.RadTreeView();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radTreeView1.BeginInit();
			this.radDropDownList6.BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.radTreeView1.Location = new global::System.Drawing.Point(12, 31);
			this.radTreeView1.Name = "radTreeView1";
			this.radTreeView1.RadContextMenu = this.radContextMenu1;
			this.radTreeView1.Size = new global::System.Drawing.Size(255, 427);
			this.radTreeView1.SpacingBetweenNodes = -1;
			this.radTreeView1.TabIndex = 168;
			this.radTreeView1.ThemeName = "Office2010Silver";
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(51, 19);
			this.label2.TabIndex = 169;
			this.label2.Text = "Article";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(285, 31);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(77, 19);
			this.label1.TabIndex = 170;
			this.label1.Text = "ID Article :";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(285, 53);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(95, 19);
			this.label3.TabIndex = 171;
			this.label3.Text = "Désignation :";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(286, 75);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(92, 19);
			this.label4.TabIndex = 172;
			this.label4.Text = "Fournisseur :";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Black;
			this.label5.Location = new global::System.Drawing.Point(381, 31);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(49, 19);
			this.label5.TabIndex = 173;
			this.label5.Text = "label5";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.Black;
			this.label6.Location = new global::System.Drawing.Point(381, 53);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(49, 19);
			this.label6.TabIndex = 174;
			this.label6.Text = "label6";
			this.radDropDownList6.DropDownAnimationEasing = 2;
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(385, 74);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(455, 24);
			this.radDropDownList6.TabIndex = 179;
			this.radDropDownList6.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadDropDownListElement)this.radDropDownList6.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.radGridView1.AutoScroll = true;
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(290, 104);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID article";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "id_fournisseur";
			gridViewTextBoxColumn2.IsVisible = false;
			gridViewTextBoxColumn2.Name = "column8";
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Fournisseur";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 200;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Code Article";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column1";
			gridViewTextBoxColumn4.ReadOnly = true;
			gridViewTextBoxColumn4.Width = 150;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Désignation";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column3";
			gridViewTextBoxColumn5.ReadOnly = true;
			gridViewTextBoxColumn5.Width = 200;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Prix HT";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column6";
			gridViewTextBoxColumn6.Width = 150;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Remise";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column4";
			gridViewTextBoxColumn7.Width = 150;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column7";
			gridViewTextBoxColumn8.HeaderText = "column9";
			gridViewTextBoxColumn8.IsVisible = false;
			gridViewTextBoxColumn8.Name = "column9";
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7,
				gridViewImageColumn,
				gridViewTextBoxColumn8
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
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
			this.radGridView1.ReadOnly = true;
			this.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.ShowHeaderCellButtons = true;
			this.radGridView1.Size = new global::System.Drawing.Size(957, 354);
			this.radGridView1.TabIndex = 181;
			this.radGridView1.ThemeName = "Fluent";
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Black;
			this.label7.Location = new global::System.Drawing.Point(286, 9);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(31, 19);
			this.label7.TabIndex = 182;
			this.label7.Text = "ID :";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Black;
			this.label8.Location = new global::System.Drawing.Point(312, 9);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(49, 19);
			this.label8.TabIndex = 183;
			this.label8.Text = "label8";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(846, 75);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 23);
			this.guna2Button1.TabIndex = 184;
			this.guna2Button1.Text = "Ajouter";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.guna2Button2.BorderRadius = 8;
			this.guna2Button2.CheckedState.Parent = this.guna2Button2;
			this.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button2.CustomImages.Parent = this.guna2Button2;
			this.guna2Button2.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.HoverState.Parent = this.guna2Button2;
			this.guna2Button2.Location = new global::System.Drawing.Point(956, 75);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
			this.guna2Button2.Size = new global::System.Drawing.Size(104, 23);
			this.guna2Button2.TabIndex = 185;
			this.guna2Button2.Text = "Enregistrer";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1259, 513);
			base.Controls.Add(this.guna2Button2);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.radTreeView1);
			base.Name = "cloturer_dop";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.cloturer_dop_Load);
			this.radTreeView1.EndInit();
			this.radDropDownList6.EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000390 RID: 912
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000391 RID: 913
		private global::Telerik.WinControls.UI.RadTreeView radTreeView1;

		// Token: 0x04000392 RID: 914
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000393 RID: 915
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000394 RID: 916
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000395 RID: 917
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000396 RID: 918
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000397 RID: 919
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000398 RID: 920
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x04000399 RID: 921
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x0400039A RID: 922
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400039B RID: 923
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400039C RID: 924
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400039D RID: 925
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x0400039E RID: 926
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x0400039F RID: 927
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x040003A0 RID: 928
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x040003A1 RID: 929
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x040003A2 RID: 930
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;
	}
}
