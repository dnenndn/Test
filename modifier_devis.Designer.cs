namespace GMAO
{
	// Token: 0x0200009C RID: 156
	public partial class modifier_devis : global::System.Windows.Forms.Form
	{
		// Token: 0x0600071E RID: 1822 RVA: 0x00136FA8 File Offset: 0x001351A8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x00136FE0 File Offset: 0x001351E0
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
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.modifier_devis));
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.label12 = new global::System.Windows.Forms.Label();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label13 = new global::System.Windows.Forms.Label();
			this.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.label14 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radDropDownList6.BeginInit();
			this.radDropDownList1.BeginInit();
			this.radPanel1.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(710, 196);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 24);
			this.guna2Button1.TabIndex = 187;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.radGridView1.AutoScroll = true;
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(12, 226);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID article";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.HeaderText = "Code Article";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.ReadOnly = true;
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Désignation";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column3";
			gridViewTextBoxColumn3.ReadOnly = true;
			gridViewTextBoxColumn3.Width = 200;
			gridViewTextBoxColumn4.HeaderText = "Quantité disponible";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column4";
			gridViewTextBoxColumn4.Width = 200;
			gridViewTextBoxColumn5.HeaderText = "Prix U HT";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column6";
			gridViewTextBoxColumn5.Width = 150;
			gridViewTextBoxColumn6.HeaderText = "Remise";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column7";
			gridViewTextBoxColumn6.Width = 160;
			gridViewTextBoxColumn7.HeaderText = "Prix Tot HT";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column2";
			gridViewTextBoxColumn7.ReadOnly = true;
			gridViewTextBoxColumn7.Width = 150;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7
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
			this.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.ShowHeaderCellButtons = true;
			this.radGridView1.Size = new global::System.Drawing.Size(1084, 365);
			this.radGridView1.TabIndex = 186;
			this.radGridView1.ThemeName = "Fluent";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(12, 38);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(151, 19);
			this.label1.TabIndex = 185;
			this.label1.Text = "Choisir un fournisseur";
			this.radDropDownList6.DropDownAnimationEasing = 2;
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(16, 60);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(407, 24);
			this.radDropDownList6.TabIndex = 184;
			this.radDropDownList6.ThemeName = "Crystal";
			this.radDropDownList6.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList6_SelectedIndexChanged);
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
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(190, 9);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(49, 19);
			this.label3.TabIndex = 183;
			this.label3.Text = "label3";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(179, 19);
			this.label2.TabIndex = 182;
			this.label2.Text = "ID Demande offre de prix :";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(667, 7);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(71, 19);
			this.label4.TabIndex = 188;
			this.label4.Text = "ID Devis :";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Black;
			this.label5.Location = new global::System.Drawing.Point(667, 27);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(73, 19);
			this.label5.TabIndex = 189;
			this.label5.Text = "Créer par:";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.Black;
			this.label6.Location = new global::System.Drawing.Point(667, 47);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(121, 19);
			this.label6.TabIndex = 190;
			this.label6.Text = "Date de création:";
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Black;
			this.label7.Location = new global::System.Drawing.Point(667, 66);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(52, 19);
			this.label7.TabIndex = 191;
			this.label7.Text = "Heure:";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Black;
			this.label8.Location = new global::System.Drawing.Point(738, 7);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(49, 19);
			this.label8.TabIndex = 192;
			this.label8.Text = "label8";
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.Black;
			this.label9.Location = new global::System.Drawing.Point(739, 27);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(49, 19);
			this.label9.TabIndex = 193;
			this.label9.Text = "label9";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(784, 47);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(57, 19);
			this.label10.TabIndex = 194;
			this.label10.Text = "label10";
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.ForeColor = global::System.Drawing.Color.Black;
			this.label11.Location = new global::System.Drawing.Point(714, 66);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(57, 19);
			this.label11.TabIndex = 195;
			this.label11.Text = "label11";
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label12.ForeColor = global::System.Drawing.Color.Black;
			this.label12.Location = new global::System.Drawing.Point(425, 38);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(67, 19);
			this.label12.TabIndex = 197;
			this.label12.Text = "Livraison";
			this.radDropDownList1.DropDownAnimationEasing = 2;
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(429, 60);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(206, 24);
			this.radDropDownList1.TabIndex = 196;
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
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.ForeColor = global::System.Drawing.Color.Black;
			this.label13.Location = new global::System.Drawing.Point(12, 89);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(82, 19);
			this.label13.TabIndex = 201;
			this.label13.Text = "Documents";
			this.radPanel1.AutoScroll = true;
			this.radPanel1.Location = new global::System.Drawing.Point(16, 111);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Size = new global::System.Drawing.Size(688, 109);
			this.radPanel1.TabIndex = 202;
			this.radPanel1.ThemeName = "ControlDefault";
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel1.GetChildAt(0).GetChildAt(1)).GradientStyle = 0;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel1.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
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
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label14.Location = new global::System.Drawing.Point(955, 201);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(57, 19);
			this.label14.TabIndex = 208;
			this.label14.Text = "label14";
			this.label15.AutoSize = true;
			this.label15.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label15.ForeColor = global::System.Drawing.Color.Black;
			this.label15.Location = new global::System.Drawing.Point(870, 201);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(91, 19);
			this.label15.TabIndex = 207;
			this.label15.Text = "Prix Tot HT : ";
			this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new global::System.Drawing.Point(549, 89);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(13, 13);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 204;
			this.pictureBox2.TabStop = false;
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(92, 88);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(32, 22);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 203;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1108, 603);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.label15);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.radPanel1);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.radDropDownList1);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Name = "modifier_devis";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.modifier_devis_Load);
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radDropDownList6.EndInit();
			this.radDropDownList1.EndInit();
			this.radPanel1.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000994 RID: 2452
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000995 RID: 2453
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000996 RID: 2454
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04000997 RID: 2455
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000998 RID: 2456
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x04000999 RID: 2457
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400099A RID: 2458
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400099B RID: 2459
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400099C RID: 2460
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400099D RID: 2461
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400099E RID: 2462
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400099F RID: 2463
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040009A0 RID: 2464
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040009A1 RID: 2465
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040009A2 RID: 2466
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040009A3 RID: 2467
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x040009A4 RID: 2468
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040009A5 RID: 2469
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040009A6 RID: 2470
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x040009A7 RID: 2471
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x040009A8 RID: 2472
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040009A9 RID: 2473
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040009AA RID: 2474
		private global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x040009AB RID: 2475
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x040009AC RID: 2476
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040009AD RID: 2477
		private global::System.Windows.Forms.Label label15;
	}
}
