namespace GMAO
{
	// Token: 0x0200013A RID: 314
	public partial class liste_article : global::System.Windows.Forms.Form
	{
		// Token: 0x06000E1A RID: 3610 RVA: 0x00225A14 File Offset: 0x00223C14
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00225A4C File Offset: 0x00223C4C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.liste_article));
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
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
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn3 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.button8 = new global::System.Windows.Forms.Button();
			this.button7 = new global::System.Windows.Forms.Button();
			this.button6 = new global::System.Windows.Forms.Button();
			this.button5 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new global::System.Drawing.Point(12, 21);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1104, 153);
			this.panel1.TabIndex = 0;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label3.Location = new global::System.Drawing.Point(845, 127);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(69, 19);
			this.label3.TabIndex = 171;
			this.label3.Text = "Records :";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(780, 127);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(69, 19);
			this.label2.TabIndex = 170;
			this.label2.Text = "Records :";
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Location = new global::System.Drawing.Point(12, 381);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1104, 175);
			this.panel2.TabIndex = 1;
			this.panel3.Location = new global::System.Drawing.Point(3, 41);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1081, 131);
			this.panel3.TabIndex = 81;
			this.panel5.Location = new global::System.Drawing.Point(2, 30);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(1082, 10);
			this.panel5.TabIndex = 80;
			this.panel5.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
			this.panel4.Controls.Add(this.pictureBox1);
			this.panel4.Controls.Add(this.button8);
			this.panel4.Controls.Add(this.button7);
			this.panel4.Controls.Add(this.button6);
			this.panel4.Controls.Add(this.button5);
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Location = new global::System.Drawing.Point(2, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1082, 29);
			this.panel4.TabIndex = 79;
			this.panel4.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(1052, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(27, 20);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 85;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.button8.BackColor = global::System.Drawing.Color.Firebrick;
			this.button8.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button8.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button8.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button8.ForeColor = global::System.Drawing.Color.White;
			this.button8.Location = new global::System.Drawing.Point(812, 1);
			this.button8.Name = "button8";
			this.button8.Size = new global::System.Drawing.Size(118, 28);
			this.button8.TabIndex = 84;
			this.button8.Text = "Caractéristique";
			this.button8.UseVisualStyleBackColor = false;
			this.button8.Click += new global::System.EventHandler(this.button8_Click);
			this.button7.BackColor = global::System.Drawing.Color.Firebrick;
			this.button7.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button7.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button7.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button7.ForeColor = global::System.Drawing.Color.White;
			this.button7.Location = new global::System.Drawing.Point(697, 1);
			this.button7.Name = "button7";
			this.button7.Size = new global::System.Drawing.Size(118, 28);
			this.button7.TabIndex = 83;
			this.button7.Text = "Image";
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Click += new global::System.EventHandler(this.button7_Click);
			this.button6.BackColor = global::System.Drawing.Color.Firebrick;
			this.button6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button6.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button6.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button6.ForeColor = global::System.Drawing.Color.White;
			this.button6.Location = new global::System.Drawing.Point(580, 1);
			this.button6.Name = "button6";
			this.button6.Size = new global::System.Drawing.Size(118, 28);
			this.button6.TabIndex = 82;
			this.button6.Text = "Fichier";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new global::System.EventHandler(this.button6_Click);
			this.button5.BackColor = global::System.Drawing.Color.Firebrick;
			this.button5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button5.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button5.ForeColor = global::System.Drawing.Color.White;
			this.button5.Location = new global::System.Drawing.Point(463, 1);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(118, 28);
			this.button5.TabIndex = 82;
			this.button5.Text = "Liaison Equipement";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			this.button4.BackColor = global::System.Drawing.Color.Firebrick;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(346, 1);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(118, 28);
			this.button4.TabIndex = 81;
			this.button4.Text = "Paramètre";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button3.BackColor = global::System.Drawing.Color.Firebrick;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(229, 1);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(118, 28);
			this.button3.TabIndex = 74;
			this.button3.Text = "Commentaire";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button1.BackColor = global::System.Drawing.Color.Firebrick;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(112, 1);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(118, 28);
			this.button1.TabIndex = 73;
			this.button1.Text = "Stock";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.BackColor = global::System.Drawing.Color.Firebrick;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(0, 1);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(113, 28);
			this.button2.TabIndex = 72;
			this.button2.Text = "Générale";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(12, 177);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.HeaderText = "Photo";
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column11";
			gridViewImageColumn.Width = 150;
			gridViewTextBoxColumn.DataType = typeof(uint);
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.AllowSort = false;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Code Article";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.AllowSort = false;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Référence";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 170;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Désignation";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column3";
			gridViewTextBoxColumn4.Width = 200;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Marque";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column7";
			gridViewTextBoxColumn5.Width = 200;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Quantité en stock";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column8";
			gridViewTextBoxColumn6.Width = 150;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Prix unitaire HT";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column10";
			gridViewTextBoxColumn7.Width = 150;
			gridViewTextBoxColumn8.EnableExpressionEditor = false;
			gridViewTextBoxColumn8.HeaderText = "TVA (%)";
			gridViewTextBoxColumn8.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn8.Name = "column9";
			gridViewTextBoxColumn8.Width = 150;
			gridViewTextBoxColumn9.HeaderText = "Stock Usé";
			gridViewTextBoxColumn9.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn9.Name = "column13";
			gridViewTextBoxColumn9.Width = 120;
			gridViewTextBoxColumn10.HeaderText = "Stock Rebuté";
			gridViewTextBoxColumn10.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn10.Name = "column12";
			gridViewTextBoxColumn10.Width = 120;
			gridViewTextBoxColumn11.HeaderText = "Stock Réparable";
			gridViewTextBoxColumn11.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn11.Name = "column14";
			gridViewTextBoxColumn11.Width = 140;
			gridViewImageColumn2.EnableExpressionEditor = false;
			gridViewImageColumn2.ImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			gridViewImageColumn2.Name = "column4";
			gridViewImageColumn2.Width = 60;
			gridViewImageColumn3.EnableExpressionEditor = false;
			gridViewImageColumn3.ImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			gridViewImageColumn3.Name = "column6";
			gridViewImageColumn3.Width = 60;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewImageColumn,
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
				gridViewImageColumn2,
				gridViewImageColumn3
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
			this.radGridView1.MasterTemplate.EnablePaging = true;
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
			this.radGridView1.Size = new global::System.Drawing.Size(1104, 202);
			this.radGridView1.TabIndex = 77;
			this.radGridView1.ThemeName = "Fluent";
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-supprimer-pour-toujours-100 (4).png");
			this.imageList1.Images.SetKeyName(1, "icons8-approuver-et-mettre-à-jour-96 (4).png");
			this.imageList1.Images.SetKeyName(2, "imgonline-com-ua-Transparent-background-mY80EJnxkjzbk (1).ico");
			this.panel6.Location = new global::System.Drawing.Point(68, 9);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(1059, 10);
			this.panel6.TabIndex = 79;
			this.panel6.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
			this.label1.AutoSize = true;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(68, 13);
			this.label1.TabIndex = 78;
			this.label1.Text = "Filtre avancé";
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "liste_article";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.liste_article_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040011D7 RID: 4567
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040011D8 RID: 4568
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040011D9 RID: 4569
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040011DA RID: 4570
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x040011DB RID: 4571
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040011DC RID: 4572
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040011DD RID: 4573
		public global::System.Windows.Forms.Button button4;

		// Token: 0x040011DE RID: 4574
		public global::System.Windows.Forms.Button button3;

		// Token: 0x040011DF RID: 4575
		public global::System.Windows.Forms.Button button1;

		// Token: 0x040011E0 RID: 4576
		public global::System.Windows.Forms.Button button2;

		// Token: 0x040011E1 RID: 4577
		public global::System.Windows.Forms.Button button6;

		// Token: 0x040011E2 RID: 4578
		public global::System.Windows.Forms.Button button5;

		// Token: 0x040011E3 RID: 4579
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040011E4 RID: 4580
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x040011E5 RID: 4581
		public global::System.Windows.Forms.Button button7;

		// Token: 0x040011E6 RID: 4582
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040011E7 RID: 4583
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040011E8 RID: 4584
		public global::System.Windows.Forms.Button button8;

		// Token: 0x040011E9 RID: 4585
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040011EA RID: 4586
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040011EB RID: 4587
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040011EC RID: 4588
		private global::System.Windows.Forms.Label label2;
	}
}
