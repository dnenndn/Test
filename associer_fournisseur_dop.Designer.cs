namespace GMAO
{
	// Token: 0x02000026 RID: 38
	public partial class associer_fournisseur_dop : global::System.Windows.Forms.Form
	{
		// Token: 0x060001FF RID: 511 RVA: 0x00053C18 File Offset: 0x00051E18
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00053C50 File Offset: 0x00051E50
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.guna2Button3 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label5 = new global::System.Windows.Forms.Label();
			this.radDropDownList2 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label6 = new global::System.Windows.Forms.Label();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radDropDownList6.BeginInit();
			this.panel1.SuspendLayout();
			this.radDropDownList1.BeginInit();
			this.radDropDownList2.BeginInit();
			base.SuspendLayout();
			this.radGridView1.AutoScroll = true;
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(12, 112);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Fournisseur";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 500;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column9";
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewImageColumn
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
			this.radGridView1.Size = new global::System.Drawing.Size(629, 310);
			this.radGridView1.TabIndex = 171;
			this.radGridView1.ThemeName = "Fluent";
			this.radDropDownList6.DropDownAnimationEasing = 2;
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(12, 59);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(267, 24);
			this.radDropDownList6.TabIndex = 172;
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
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(8, 37);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(151, 19);
			this.label1.TabIndex = 173;
			this.label1.Text = "Choisir un fournisseur";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(8, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(179, 19);
			this.label2.TabIndex = 174;
			this.label2.Text = "ID Demande offre de prix :";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(186, 9);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(49, 19);
			this.label3.TabIndex = 175;
			this.label3.Text = "label3";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(285, 59);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 24);
			this.guna2Button1.TabIndex = 176;
			this.guna2Button1.Text = "Ajouter";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label4.Location = new global::System.Drawing.Point(669, 112);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(180, 19);
			this.label4.TabIndex = 182;
			this.label4.Text = "Liaison Article Fournisseur";
			this.panel1.Controls.Add(this.guna2Button3);
			this.panel1.Controls.Add(this.radDropDownList1);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.radDropDownList2);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Location = new global::System.Drawing.Point(673, 136);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(284, 171);
			this.panel1.TabIndex = 181;
			this.guna2Button3.BorderRadius = 8;
			this.guna2Button3.CheckedState.Parent = this.guna2Button3;
			this.guna2Button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button3.CustomImages.Parent = this.guna2Button3;
			this.guna2Button3.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button3.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button3.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button3.HoverState.Parent = this.guna2Button3;
			this.guna2Button3.Location = new global::System.Drawing.Point(167, 131);
			this.guna2Button3.Name = "guna2Button3";
			this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
			this.guna2Button3.Size = new global::System.Drawing.Size(104, 24);
			this.guna2Button3.TabIndex = 179;
			this.guna2Button3.Text = "Enregistrer";
			this.guna2Button3.Click += new global::System.EventHandler(this.guna2Button3_Click);
			this.radDropDownList1.DropDownAnimationEasing = 2;
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(7, 93);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(264, 24);
			this.radDropDownList1.TabIndex = 182;
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
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Black;
			this.label5.Location = new global::System.Drawing.Point(3, 71);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(151, 19);
			this.label5.TabIndex = 181;
			this.label5.Text = "Choisir un fournisseur";
			this.radDropDownList2.DropDownAnimationEasing = 2;
			this.radDropDownList2.DropDownStyle = 2;
			this.radDropDownList2.Location = new global::System.Drawing.Point(7, 31);
			this.radDropDownList2.Name = "radDropDownList2";
			this.radDropDownList2.Size = new global::System.Drawing.Size(264, 24);
			this.radDropDownList2.TabIndex = 180;
			this.radDropDownList2.ThemeName = "Crystal";
			this.radDropDownList2.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList2_SelectedIndexChanged);
			((global::Telerik.WinControls.UI.RadDropDownListElement)this.radDropDownList2.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.Black;
			this.label6.Location = new global::System.Drawing.Point(3, 9);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(119, 19);
			this.label6.TabIndex = 179;
			this.label6.Text = "Choisir un article";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(986, 450);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.radGridView1);
			base.Name = "associer_fournisseur_dop";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.associer_fournisseur_dop_Load);
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radDropDownList6.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radDropDownList1.EndInit();
			this.radDropDownList2.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002CA RID: 714
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002CB RID: 715
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x040002CC RID: 716
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x040002CD RID: 717
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002CE RID: 718
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002CF RID: 719
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002D0 RID: 720
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040002D1 RID: 721
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x040002D2 RID: 722
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x040002D3 RID: 723
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040002D4 RID: 724
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040002D5 RID: 725
		private global::Guna.UI2.WinForms.Guna2Button guna2Button3;

		// Token: 0x040002D6 RID: 726
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x040002D7 RID: 727
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040002D8 RID: 728
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList2;

		// Token: 0x040002D9 RID: 729
		private global::System.Windows.Forms.Label label6;
	}
}
