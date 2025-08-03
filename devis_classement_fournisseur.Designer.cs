namespace GMAO
{
	// Token: 0x02000067 RID: 103
	public partial class devis_classement_fournisseur : global::System.Windows.Forms.Form
	{
		// Token: 0x060004F2 RID: 1266 RVA: 0x000D42C4 File Offset: 0x000D24C4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x000D42FC File Offset: 0x000D24FC
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.devis_classement_fournisseur));
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.radGridView2 = new global::Telerik.WinControls.UI.RadGridView();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.TextBox3 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.TextBox4 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			this.saveFileDialog1 = new global::System.Windows.Forms.SaveFileDialog();
			this.radGridView2.BeginInit();
			this.radGridView2.MasterTemplate.BeginInit();
			this.radPanel1.BeginInit();
			this.radPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			base.SuspendLayout();
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(190, 9);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(49, 19);
			this.label3.TabIndex = 185;
			this.label3.Text = "label3";
			this.label3.Click += new global::System.EventHandler(this.label3_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(179, 19);
			this.label2.TabIndex = 184;
			this.label2.Text = "ID Demande offre de prix :";
			this.radGridView2.AutoScroll = true;
			this.radGridView2.BackColor = global::System.Drawing.Color.White;
			this.radGridView2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView2.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView2.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView2.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView2.Location = new global::System.Drawing.Point(16, 90);
			this.radGridView2.MasterTemplate.AllowAddNewRow = false;
			this.radGridView2.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnReorder = false;
			this.radGridView2.MasterTemplate.AllowDeleteRow = false;
			this.radGridView2.MasterTemplate.AllowDragToGroup = false;
			this.radGridView2.MasterTemplate.AllowEditRow = false;
			this.radGridView2.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.HeaderText = "id";
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column7";
			gridViewTextBoxColumn2.HeaderText = "Fournisseur";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 250;
			gridViewTextBoxColumn3.HeaderText = "Date de réponse";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 150;
			gridViewTextBoxColumn4.HeaderText = "Délai de reponse (jours)";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column3";
			gridViewTextBoxColumn4.Width = 170;
			gridViewTextBoxColumn5.HeaderText = "Livraison";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column8";
			gridViewTextBoxColumn5.Width = 120;
			gridViewTextBoxColumn6.HeaderText = "Nbre des articles non disponible";
			gridViewTextBoxColumn6.Name = "column4";
			gridViewTextBoxColumn6.Width = 220;
			gridViewTextBoxColumn7.HeaderText = "Note réactivité";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column5";
			gridViewTextBoxColumn7.Width = 130;
			gridViewTextBoxColumn8.HeaderText = "Note disponibilité des articles";
			gridViewTextBoxColumn8.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn8.Name = "column6";
			gridViewTextBoxColumn8.Width = 220;
			gridViewTextBoxColumn9.HeaderText = "Note prix";
			gridViewTextBoxColumn9.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn9.Name = "column9";
			gridViewTextBoxColumn9.Width = 100;
			gridViewTextBoxColumn10.HeaderText = "Note Total";
			gridViewTextBoxColumn10.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn10.Name = "column10";
			gridViewTextBoxColumn10.Width = 100;
			this.radGridView2.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
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
			this.radGridView2.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView2.MasterTemplate.EnableFiltering = true;
			this.radGridView2.MasterTemplate.EnableSorting = false;
			this.radGridView2.MasterTemplate.ShowFilteringRow = false;
			this.radGridView2.MasterTemplate.ShowHeaderCellButtons = true;
			this.radGridView2.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView2.Name = "radGridView2";
			this.radGridView2.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView2.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView2.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView2.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView2.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Khaki;
			this.radGridView2.PrintStyle.PrintAllPages = true;
			this.radGridView2.PrintStyle.PrintAlternatingRowColor = true;
			this.radGridView2.ReadOnly = true;
			this.radGridView2.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView2.ShowGroupPanel = false;
			this.radGridView2.ShowHeaderCellButtons = true;
			this.radGridView2.Size = new global::System.Drawing.Size(1248, 428);
			this.radGridView2.TabIndex = 195;
			this.radGridView2.ThemeName = "Fluent";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(12, 65);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(199, 19);
			this.label1.TabIndex = 196;
			this.label1.Text = "Classement des fournisseurs";
			this.radPanel1.Controls.Add(this.pictureBox4);
			this.radPanel1.Controls.Add(this.guna2Button1);
			this.radPanel1.Controls.Add(this.TextBox4);
			this.radPanel1.Controls.Add(this.label8);
			this.radPanel1.Controls.Add(this.TextBox3);
			this.radPanel1.Controls.Add(this.label7);
			this.radPanel1.Controls.Add(this.TextBox2);
			this.radPanel1.Controls.Add(this.label6);
			this.radPanel1.Controls.Add(this.TextBox1);
			this.radPanel1.Controls.Add(this.label5);
			this.radPanel1.Controls.Add(this.label4);
			this.radPanel1.Location = new global::System.Drawing.Point(269, 9);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Size = new global::System.Drawing.Size(995, 75);
			this.radPanel1.TabIndex = 197;
			this.radPanel1.TextAlignment = global::System.Drawing.ContentAlignment.TopLeft;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel1.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label4.Location = new global::System.Drawing.Point(3, 3);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(222, 19);
			this.label4.TabIndex = 185;
			this.label4.Text = "Poids des critères de classement";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Black;
			this.label5.Location = new global::System.Drawing.Point(3, 22);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(74, 19);
			this.label5.TabIndex = 198;
			this.label5.Text = "Réactivité";
			this.TextBox1.BorderRadius = 2;
			this.TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox1.DefaultText = "";
			this.TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.DisabledState.Parent = this.TextBox1;
			this.TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.FocusedState.Parent = this.TextBox1;
			this.TextBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.HoverState.Parent = this.TextBox1;
			this.TextBox1.Location = new global::System.Drawing.Point(7, 40);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(107, 29);
			this.TextBox1.TabIndex = 198;
			this.TextBox2.BorderRadius = 2;
			this.TextBox2.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox2.DefaultText = "";
			this.TextBox2.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox2.DisabledState.Parent = this.TextBox2;
			this.TextBox2.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox2.FocusedState.Parent = this.TextBox2;
			this.TextBox2.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox2.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox2.HoverState.Parent = this.TextBox2;
			this.TextBox2.Location = new global::System.Drawing.Point(124, 40);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(166, 29);
			this.TextBox2.TabIndex = 199;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.Black;
			this.label6.Location = new global::System.Drawing.Point(120, 22);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(170, 19);
			this.label6.TabIndex = 200;
			this.label6.Text = "Disponibilité des articles";
			this.TextBox3.BorderRadius = 2;
			this.TextBox3.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox3.DefaultText = "";
			this.TextBox3.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox3.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox3.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox3.DisabledState.Parent = this.TextBox3;
			this.TextBox3.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox3.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox3.FocusedState.Parent = this.TextBox3;
			this.TextBox3.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox3.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox3.HoverState.Parent = this.TextBox3;
			this.TextBox3.Location = new global::System.Drawing.Point(300, 40);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.PasswordChar = '\0';
			this.TextBox3.PlaceholderText = "";
			this.TextBox3.SelectedText = "";
			this.TextBox3.ShadowDecoration.Parent = this.TextBox3;
			this.TextBox3.Size = new global::System.Drawing.Size(107, 29);
			this.TextBox3.TabIndex = 201;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Black;
			this.label7.Location = new global::System.Drawing.Point(296, 22);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(33, 19);
			this.label7.TabIndex = 202;
			this.label7.Text = "Prix";
			this.TextBox4.BorderRadius = 2;
			this.TextBox4.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox4.DefaultText = "";
			this.TextBox4.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox4.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox4.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox4.DisabledState.Parent = this.TextBox4;
			this.TextBox4.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox4.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox4.FocusedState.Parent = this.TextBox4;
			this.TextBox4.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox4.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox4.HoverState.Parent = this.TextBox4;
			this.TextBox4.Location = new global::System.Drawing.Point(417, 40);
			this.TextBox4.Name = "TextBox4";
			this.TextBox4.PasswordChar = '\0';
			this.TextBox4.PlaceholderText = "";
			this.TextBox4.SelectedText = "";
			this.TextBox4.ShadowDecoration.Parent = this.TextBox4;
			this.TextBox4.Size = new global::System.Drawing.Size(124, 29);
			this.TextBox4.TabIndex = 203;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Black;
			this.label8.Location = new global::System.Drawing.Point(413, 22);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(119, 19);
			this.label8.TabIndex = 204;
			this.label8.Text = "Note de livraison";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(547, 40);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button1.TabIndex = 205;
			this.guna2Button1.Text = "Actualiser";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.pictureBox4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox4.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new global::System.Drawing.Point(952, 29);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(40, 40);
			this.pictureBox4.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox4.TabIndex = 206;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Click += new global::System.EventHandler(this.pictureBox4_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1291, 530);
			base.Controls.Add(this.radPanel1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radGridView2);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Name = "devis_classement_fournisseur";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.devis_classement_fournisseur_Load);
			this.radGridView2.MasterTemplate.EndInit();
			this.radGridView2.EndInit();
			this.radPanel1.EndInit();
			this.radPanel1.ResumeLayout(false);
			this.radPanel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000684 RID: 1668
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000685 RID: 1669
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000686 RID: 1670
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000687 RID: 1671
		private global::Telerik.WinControls.UI.RadGridView radGridView2;

		// Token: 0x04000688 RID: 1672
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000689 RID: 1673
		private global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x0400068A RID: 1674
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400068B RID: 1675
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400068C RID: 1676
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400068D RID: 1677
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x0400068E RID: 1678
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400068F RID: 1679
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000690 RID: 1680
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox3;

		// Token: 0x04000691 RID: 1681
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000692 RID: 1682
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox4;

		// Token: 0x04000693 RID: 1683
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000694 RID: 1684
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000695 RID: 1685
		private global::System.Windows.Forms.PictureBox pictureBox4;

		// Token: 0x04000696 RID: 1686
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog1;
	}
}
