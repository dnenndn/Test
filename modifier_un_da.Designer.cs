namespace GMAO
{
	// Token: 0x02000149 RID: 329
	public partial class modifier_un_da : global::System.Windows.Forms.Form
	{
		// Token: 0x06000ECD RID: 3789 RVA: 0x0023E228 File Offset: 0x0023C428
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x0023E260 File Offset: 0x0023C460
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.modifier_un_da));
			this.label6 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.TextBox5 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label1 = new global::System.Windows.Forms.Label();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.radTreeView1 = new global::Telerik.WinControls.UI.RadTreeView();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			global::GMAO.modifier_un_da.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.radDropDownList1.BeginInit();
			this.radTreeView1.BeginInit();
			global::GMAO.modifier_un_da.radGridView1.BeginInit();
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(65, 9);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(75, 19);
			this.label6.TabIndex = 12;
			this.label6.Text = "Id Parent :";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(12, 9);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(54, 19);
			this.label4.TabIndex = 11;
			this.label4.Text = "Id DA :";
			this.TextBox5.BorderRadius = 2;
			this.TextBox5.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox5.DefaultText = "";
			this.TextBox5.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox5.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox5.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox5.DisabledState.Parent = this.TextBox5;
			this.TextBox5.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox5.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox5.FocusedState.Parent = this.TextBox5;
			this.TextBox5.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox5.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox5.HoverState.Parent = this.TextBox5;
			this.TextBox5.Location = new global::System.Drawing.Point(16, 59);
			this.TextBox5.Name = "TextBox5";
			this.TextBox5.PasswordChar = '\0';
			this.TextBox5.PlaceholderText = "";
			this.TextBox5.SelectedText = "";
			this.TextBox5.ShadowDecoration.Parent = this.TextBox5;
			this.TextBox5.Size = new global::System.Drawing.Size(129, 24);
			this.TextBox5.TabIndex = 171;
			this.radDropDownList1.DropDownAnimationEasing = 2;
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(151, 59);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(165, 24);
			this.radDropDownList1.TabIndex = 170;
			this.radDropDownList1.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadDropDownListElement)this.radDropDownList1.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(12, 37);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(103, 19);
			this.label1.TabIndex = 169;
			this.label1.Text = "Délai Souhaité";
			this.guna2TextBox1.BorderRadius = 15;
			this.guna2TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox1.DefaultText = "";
			this.guna2TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.guna2TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Location = new global::System.Drawing.Point(817, 30);
			this.guna2TextBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "Recherche";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(229, 25);
			this.guna2TextBox1.TabIndex = 175;
			this.guna2TextBox1.TextChanged += new global::System.EventHandler(this.guna2TextBox1_TextChanged);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(815, 4);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(51, 19);
			this.label3.TabIndex = 174;
			this.label3.Text = "Article";
			this.radTreeView1.Location = new global::System.Drawing.Point(819, 59);
			this.radTreeView1.Name = "radTreeView1";
			this.radTreeView1.RadContextMenu = this.radContextMenu1;
			this.radTreeView1.Size = new global::System.Drawing.Size(255, 379);
			this.radTreeView1.SpacingBetweenNodes = -1;
			this.radTreeView1.TabIndex = 173;
			this.radTreeView1.ThemeName = "Office2010Silver";
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			global::GMAO.modifier_un_da.radGridView1.BackColor = global::System.Drawing.Color.White;
			global::GMAO.modifier_un_da.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			global::GMAO.modifier_un_da.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			global::GMAO.modifier_un_da.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			global::GMAO.modifier_un_da.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			global::GMAO.modifier_un_da.radGridView1.Location = new global::System.Drawing.Point(16, 101);
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.AllowAddNewRow = false;
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.AllowColumnReorder = false;
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.AllowDeleteRow = false;
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.AllowDragToGroup = false;
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 80;
			gridViewTextBoxColumn2.AllowSort = false;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Désignation";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.ReadOnly = true;
			gridViewTextBoxColumn2.Width = 225;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Quantité";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 130;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Motif";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column3";
			gridViewTextBoxColumn4.Width = 200;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column4";
			gridViewImageColumn.Width = 60;
			gridViewImageColumn2.EnableExpressionEditor = false;
			gridViewImageColumn2.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn2.Name = "column6";
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewImageColumn,
				gridViewImageColumn2
			});
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.EnableFiltering = true;
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.EnableSorting = false;
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.ShowFilteringRow = false;
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			global::GMAO.modifier_un_da.radGridView1.Name = "radGridView1";
			global::GMAO.modifier_un_da.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			global::GMAO.modifier_un_da.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.modifier_un_da.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			global::GMAO.modifier_un_da.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			global::GMAO.modifier_un_da.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			global::GMAO.modifier_un_da.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			global::GMAO.modifier_un_da.radGridView1.ShowGroupPanel = false;
			global::GMAO.modifier_un_da.radGridView1.Size = new global::System.Drawing.Size(797, 337);
			global::GMAO.modifier_un_da.radGridView1.TabIndex = 176;
			global::GMAO.modifier_un_da.radGridView1.ThemeName = "Fluent";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(707, 53);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 177;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
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
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1087, 450);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(global::GMAO.modifier_un_da.radGridView1);
			base.Controls.Add(this.guna2TextBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.radTreeView1);
			base.Controls.Add(this.TextBox5);
			base.Controls.Add(this.radDropDownList1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label4);
			base.Name = "modifier_un_da";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.modifier_un_da_Load);
			this.radDropDownList1.EndInit();
			this.radTreeView1.EndInit();
			global::GMAO.modifier_un_da.radGridView1.MasterTemplate.EndInit();
			global::GMAO.modifier_un_da.radGridView1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001294 RID: 4756
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001295 RID: 4757
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04001296 RID: 4758
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04001297 RID: 4759
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox5;

		// Token: 0x04001298 RID: 4760
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x04001299 RID: 4761
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400129A RID: 4762
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x0400129B RID: 4763
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400129C RID: 4764
		private global::Telerik.WinControls.UI.RadTreeView radTreeView1;

		// Token: 0x0400129D RID: 4765
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x0400129E RID: 4766
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x0400129F RID: 4767
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x040012A0 RID: 4768
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x040012A1 RID: 4769
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040012A2 RID: 4770
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x040012A3 RID: 4771
		private static global::Telerik.WinControls.UI.RadGridView radGridView1;
	}
}
