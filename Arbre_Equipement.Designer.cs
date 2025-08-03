namespace GMAO
{
	// Token: 0x0200001C RID: 28
	public partial class Arbre_Equipement : global::System.Windows.Forms.Form
	{
		// Token: 0x060001A5 RID: 421 RVA: 0x00046F18 File Offset: 0x00045118
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00046F50 File Offset: 0x00045150
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.Arbre_Equipement));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			global::GMAO.Arbre_Equipement.arbre = new global::Telerik.WinControls.UI.RadTreeView();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem2 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem3 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem4 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem5 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radOffice2007ScreenTipElement1 = new global::Telerik.WinControls.UI.RadOffice2007ScreenTipElement();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.aquaTheme1 = new global::Telerik.WinControls.Themes.AquaTheme();
			global::GMAO.Arbre_Equipement.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			global::GMAO.Arbre_Equipement.Panel10 = new global::Guna.UI2.WinForms.Guna2Panel();
			global::GMAO.Arbre_Equipement.panel4 = new global::System.Windows.Forms.Panel();
			global::GMAO.Arbre_Equipement.panel3 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			global::GMAO.Arbre_Equipement.button7 = new global::System.Windows.Forms.Button();
			global::GMAO.Arbre_Equipement.button6 = new global::System.Windows.Forms.Button();
			global::GMAO.Arbre_Equipement.button5 = new global::System.Windows.Forms.Button();
			global::GMAO.Arbre_Equipement.button4 = new global::System.Windows.Forms.Button();
			global::GMAO.Arbre_Equipement.button3 = new global::System.Windows.Forms.Button();
			global::GMAO.Arbre_Equipement.button2 = new global::System.Windows.Forms.Button();
			global::GMAO.Arbre_Equipement.button1 = new global::System.Windows.Forms.Button();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			global::GMAO.Arbre_Equipement.label7 = new global::System.Windows.Forms.Label();
			global::GMAO.Arbre_Equipement.label6 = new global::System.Windows.Forms.Label();
			global::GMAO.Arbre_Equipement.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			global::GMAO.Arbre_Equipement.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			global::GMAO.Arbre_Equipement.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			global::GMAO.Arbre_Equipement.panel5 = new global::System.Windows.Forms.Panel();
			global::GMAO.Arbre_Equipement.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			global::GMAO.Arbre_Equipement.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton3 = new global::Telerik.WinControls.UI.RadRadioButton();
			global::GMAO.Arbre_Equipement.arbre.BeginInit();
			global::GMAO.Arbre_Equipement.Panel10.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			global::GMAO.Arbre_Equipement.panel5.SuspendLayout();
			global::GMAO.Arbre_Equipement.radRadioButton2.BeginInit();
			global::GMAO.Arbre_Equipement.radRadioButton1.BeginInit();
			this.radRadioButton3.BeginInit();
			base.SuspendLayout();
			this.panel1.Location = new global::System.Drawing.Point(-3, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(156, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Arbre Equipement";
			global::GMAO.Arbre_Equipement.arbre.BackColor = global::System.Drawing.Color.White;
			global::GMAO.Arbre_Equipement.arbre.Cursor = global::System.Windows.Forms.Cursors.Default;
			global::GMAO.Arbre_Equipement.arbre.EnableKineticScrolling = true;
			global::GMAO.Arbre_Equipement.arbre.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			global::GMAO.Arbre_Equipement.arbre.ForeColor = global::System.Drawing.SystemColors.ControlText;
			global::GMAO.Arbre_Equipement.arbre.ImageList = this.imageList1;
			global::GMAO.Arbre_Equipement.arbre.ItemHeight = 36;
			global::GMAO.Arbre_Equipement.arbre.LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			global::GMAO.Arbre_Equipement.arbre.LineStyle = 0;
			global::GMAO.Arbre_Equipement.arbre.Location = new global::System.Drawing.Point(10, 77);
			global::GMAO.Arbre_Equipement.arbre.Name = "arbre";
			global::GMAO.Arbre_Equipement.arbre.RadContextMenu = this.radContextMenu1;
			global::GMAO.Arbre_Equipement.arbre.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			global::GMAO.Arbre_Equipement.arbre.Size = new global::System.Drawing.Size(424, 531);
			global::GMAO.Arbre_Equipement.arbre.SpacingBetweenNodes = -1;
			global::GMAO.Arbre_Equipement.arbre.TabIndex = 2;
			global::GMAO.Arbre_Equipement.arbre.ThemeName = "Office2010Silver";
			((global::Telerik.WinControls.UI.RadTreeViewElement)global::GMAO.Arbre_Equipement.arbre.GetChildAt(0)).ShowExpandCollapse = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)global::GMAO.Arbre_Equipement.arbre.GetChildAt(0)).ItemHeight = 36;
			((global::Telerik.WinControls.UI.RadTreeViewElement)global::GMAO.Arbre_Equipement.arbre.GetChildAt(0)).ShowLines = false;
			((global::Telerik.WinControls.UI.RadTreeViewElement)global::GMAO.Arbre_Equipement.arbre.GetChildAt(0)).ShowRootLines = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)global::GMAO.Arbre_Equipement.arbre.GetChildAt(0)).LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			((global::Telerik.WinControls.UI.RadTreeViewElement)global::GMAO.Arbre_Equipement.arbre.GetChildAt(0)).LineStyle = 0;
			((global::Telerik.WinControls.UI.RadTreeViewElement)global::GMAO.Arbre_Equipement.arbre.GetChildAt(0)).TreeIndent = 20;
			((global::Telerik.WinControls.UI.RadTreeViewElement)global::GMAO.Arbre_Equipement.arbre.GetChildAt(0)).FullRowSelect = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)global::GMAO.Arbre_Equipement.arbre.GetChildAt(0)).NodeSpacing = -1;
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "image1.png");
			this.imageList1.Images.SetKeyName(1, "imgonline-com-ua-Transparent-background-LmdRuXFWPTk.png");
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1,
				this.radMenuItem2,
				this.radMenuItem3,
				this.radMenuItem4,
				this.radMenuItem5
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem2.Image = null;
			this.radMenuItem2.Name = "radMenuItem2";
			this.radMenuItem2.Text = "Modifier";
			this.radMenuItem3.Name = "radMenuItem3";
			this.radMenuItem3.Text = "Afficher";
			this.radMenuItem4.Name = "radMenuItem4";
			this.radMenuItem4.Text = "Copier";
			this.radMenuItem5.Image = null;
			this.radMenuItem5.Name = "radMenuItem5";
			this.radMenuItem5.Text = "Supprimer";
			this.radOffice2007ScreenTipElement1.Description = "Override this property and provide custom screentip template description in DesignTime.";
			this.radOffice2007ScreenTipElement1.Name = "radOffice2007ScreenTipElement1";
			this.radOffice2007ScreenTipElement1.TemplateType = null;
			this.radOffice2007ScreenTipElement1.TipSize = new global::System.Drawing.Size(0, 0);
			global::GMAO.Arbre_Equipement.guna2TextBox1.BorderRadius = 15;
			global::GMAO.Arbre_Equipement.guna2TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			global::GMAO.Arbre_Equipement.guna2TextBox1.DefaultText = "";
			global::GMAO.Arbre_Equipement.guna2TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			global::GMAO.Arbre_Equipement.guna2TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			global::GMAO.Arbre_Equipement.guna2TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			global::GMAO.Arbre_Equipement.guna2TextBox1.DisabledState.Parent = global::GMAO.Arbre_Equipement.guna2TextBox1;
			global::GMAO.Arbre_Equipement.guna2TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			global::GMAO.Arbre_Equipement.guna2TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.Arbre_Equipement.guna2TextBox1.FocusedState.Parent = global::GMAO.Arbre_Equipement.guna2TextBox1;
			global::GMAO.Arbre_Equipement.guna2TextBox1.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			global::GMAO.Arbre_Equipement.guna2TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.Arbre_Equipement.guna2TextBox1.HoverState.Parent = global::GMAO.Arbre_Equipement.guna2TextBox1;
			global::GMAO.Arbre_Equipement.guna2TextBox1.Location = new global::System.Drawing.Point(10, 41);
			global::GMAO.Arbre_Equipement.guna2TextBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			global::GMAO.Arbre_Equipement.guna2TextBox1.Name = "guna2TextBox1";
			global::GMAO.Arbre_Equipement.guna2TextBox1.PasswordChar = '\0';
			global::GMAO.Arbre_Equipement.guna2TextBox1.PlaceholderText = "Recherche";
			global::GMAO.Arbre_Equipement.guna2TextBox1.SelectedText = "";
			global::GMAO.Arbre_Equipement.guna2TextBox1.ShadowDecoration.Parent = global::GMAO.Arbre_Equipement.guna2TextBox1;
			global::GMAO.Arbre_Equipement.guna2TextBox1.Size = new global::System.Drawing.Size(229, 31);
			global::GMAO.Arbre_Equipement.guna2TextBox1.TabIndex = 3;
			global::GMAO.Arbre_Equipement.guna2TextBox1.TextChanged += new global::System.EventHandler(this.guna2TextBox1_TextChanged);
			global::GMAO.Arbre_Equipement.Panel10.BorderColor = global::System.Drawing.Color.Silver;
			global::GMAO.Arbre_Equipement.Panel10.BorderThickness = 1;
			global::GMAO.Arbre_Equipement.Panel10.Controls.Add(global::GMAO.Arbre_Equipement.panel4);
			global::GMAO.Arbre_Equipement.Panel10.Controls.Add(global::GMAO.Arbre_Equipement.panel3);
			global::GMAO.Arbre_Equipement.Panel10.Controls.Add(this.panel2);
			global::GMAO.Arbre_Equipement.Panel10.Controls.Add(this.pictureBox1);
			global::GMAO.Arbre_Equipement.Panel10.Controls.Add(global::GMAO.Arbre_Equipement.label7);
			global::GMAO.Arbre_Equipement.Panel10.Controls.Add(global::GMAO.Arbre_Equipement.label6);
			global::GMAO.Arbre_Equipement.Panel10.Controls.Add(global::GMAO.Arbre_Equipement.label5);
			global::GMAO.Arbre_Equipement.Panel10.Controls.Add(this.label4);
			global::GMAO.Arbre_Equipement.Panel10.Controls.Add(this.label3);
			global::GMAO.Arbre_Equipement.Panel10.Controls.Add(this.label2);
			global::GMAO.Arbre_Equipement.Panel10.Location = new global::System.Drawing.Point(453, 77);
			global::GMAO.Arbre_Equipement.Panel10.Name = "Panel10";
			global::GMAO.Arbre_Equipement.Panel10.ShadowDecoration.Parent = global::GMAO.Arbre_Equipement.Panel10;
			global::GMAO.Arbre_Equipement.Panel10.Size = new global::System.Drawing.Size(662, 531);
			global::GMAO.Arbre_Equipement.Panel10.TabIndex = 4;
			global::GMAO.Arbre_Equipement.panel4.Location = new global::System.Drawing.Point(9, 154);
			global::GMAO.Arbre_Equipement.panel4.Name = "panel4";
			global::GMAO.Arbre_Equipement.panel4.Size = new global::System.Drawing.Size(650, 369);
			global::GMAO.Arbre_Equipement.panel4.TabIndex = 22;
			global::GMAO.Arbre_Equipement.panel3.Location = new global::System.Drawing.Point(9, 138);
			global::GMAO.Arbre_Equipement.panel3.Name = "panel3";
			global::GMAO.Arbre_Equipement.panel3.Size = new global::System.Drawing.Size(620, 10);
			global::GMAO.Arbre_Equipement.panel3.TabIndex = 21;
			global::GMAO.Arbre_Equipement.panel3.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			this.panel2.Controls.Add(global::GMAO.Arbre_Equipement.button7);
			this.panel2.Controls.Add(global::GMAO.Arbre_Equipement.button6);
			this.panel2.Controls.Add(global::GMAO.Arbre_Equipement.button5);
			this.panel2.Controls.Add(global::GMAO.Arbre_Equipement.button4);
			this.panel2.Controls.Add(global::GMAO.Arbre_Equipement.button3);
			this.panel2.Controls.Add(global::GMAO.Arbre_Equipement.button2);
			this.panel2.Controls.Add(global::GMAO.Arbre_Equipement.button1);
			this.panel2.Location = new global::System.Drawing.Point(9, 105);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(619, 33);
			this.panel2.TabIndex = 20;
			global::GMAO.Arbre_Equipement.button7.BackColor = global::System.Drawing.Color.Firebrick;
			global::GMAO.Arbre_Equipement.button7.Cursor = global::System.Windows.Forms.Cursors.Hand;
			global::GMAO.Arbre_Equipement.button7.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			global::GMAO.Arbre_Equipement.button7.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.Arbre_Equipement.button7.ForeColor = global::System.Drawing.Color.White;
			global::GMAO.Arbre_Equipement.button7.Location = new global::System.Drawing.Point(517, 0);
			global::GMAO.Arbre_Equipement.button7.Name = "button7";
			global::GMAO.Arbre_Equipement.button7.Size = new global::System.Drawing.Size(82, 33);
			global::GMAO.Arbre_Equipement.button7.TabIndex = 23;
			global::GMAO.Arbre_Equipement.button7.Text = "Fichiers";
			global::GMAO.Arbre_Equipement.button7.UseVisualStyleBackColor = false;
			global::GMAO.Arbre_Equipement.button7.Click += new global::System.EventHandler(global::GMAO.Arbre_Equipement.button7_Click);
			global::GMAO.Arbre_Equipement.button6.BackColor = global::System.Drawing.Color.Firebrick;
			global::GMAO.Arbre_Equipement.button6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			global::GMAO.Arbre_Equipement.button6.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			global::GMAO.Arbre_Equipement.button6.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.Arbre_Equipement.button6.ForeColor = global::System.Drawing.Color.White;
			global::GMAO.Arbre_Equipement.button6.Location = new global::System.Drawing.Point(436, 0);
			global::GMAO.Arbre_Equipement.button6.Name = "button6";
			global::GMAO.Arbre_Equipement.button6.Size = new global::System.Drawing.Size(82, 33);
			global::GMAO.Arbre_Equipement.button6.TabIndex = 23;
			global::GMAO.Arbre_Equipement.button6.Text = "Image";
			global::GMAO.Arbre_Equipement.button6.UseVisualStyleBackColor = false;
			global::GMAO.Arbre_Equipement.button6.Click += new global::System.EventHandler(global::GMAO.Arbre_Equipement.button6_Click);
			global::GMAO.Arbre_Equipement.button5.BackColor = global::System.Drawing.Color.Firebrick;
			global::GMAO.Arbre_Equipement.button5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			global::GMAO.Arbre_Equipement.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			global::GMAO.Arbre_Equipement.button5.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.Arbre_Equipement.button5.ForeColor = global::System.Drawing.Color.White;
			global::GMAO.Arbre_Equipement.button5.Location = new global::System.Drawing.Point(324, 0);
			global::GMAO.Arbre_Equipement.button5.Name = "button5";
			global::GMAO.Arbre_Equipement.button5.Size = new global::System.Drawing.Size(113, 33);
			global::GMAO.Arbre_Equipement.button5.TabIndex = 23;
			global::GMAO.Arbre_Equipement.button5.Text = "Données Technique";
			global::GMAO.Arbre_Equipement.button5.UseVisualStyleBackColor = false;
			global::GMAO.Arbre_Equipement.button5.Click += new global::System.EventHandler(global::GMAO.Arbre_Equipement.button5_Click);
			global::GMAO.Arbre_Equipement.button4.BackColor = global::System.Drawing.Color.Firebrick;
			global::GMAO.Arbre_Equipement.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			global::GMAO.Arbre_Equipement.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			global::GMAO.Arbre_Equipement.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.Arbre_Equipement.button4.ForeColor = global::System.Drawing.Color.White;
			global::GMAO.Arbre_Equipement.button4.Location = new global::System.Drawing.Point(243, 0);
			global::GMAO.Arbre_Equipement.button4.Name = "button4";
			global::GMAO.Arbre_Equipement.button4.Size = new global::System.Drawing.Size(82, 33);
			global::GMAO.Arbre_Equipement.button4.TabIndex = 23;
			global::GMAO.Arbre_Equipement.button4.Text = "Compteur";
			global::GMAO.Arbre_Equipement.button4.UseVisualStyleBackColor = false;
			global::GMAO.Arbre_Equipement.button4.Click += new global::System.EventHandler(global::GMAO.Arbre_Equipement.button4_Click);
			global::GMAO.Arbre_Equipement.button3.BackColor = global::System.Drawing.Color.Firebrick;
			global::GMAO.Arbre_Equipement.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			global::GMAO.Arbre_Equipement.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			global::GMAO.Arbre_Equipement.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.Arbre_Equipement.button3.ForeColor = global::System.Drawing.Color.White;
			global::GMAO.Arbre_Equipement.button3.Location = new global::System.Drawing.Point(162, 0);
			global::GMAO.Arbre_Equipement.button3.Name = "button3";
			global::GMAO.Arbre_Equipement.button3.Size = new global::System.Drawing.Size(82, 33);
			global::GMAO.Arbre_Equipement.button3.TabIndex = 22;
			global::GMAO.Arbre_Equipement.button3.Text = "Prévision";
			global::GMAO.Arbre_Equipement.button3.UseVisualStyleBackColor = false;
			global::GMAO.Arbre_Equipement.button3.Click += new global::System.EventHandler(global::GMAO.Arbre_Equipement.button3_Click);
			global::GMAO.Arbre_Equipement.button2.BackColor = global::System.Drawing.Color.Firebrick;
			global::GMAO.Arbre_Equipement.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			global::GMAO.Arbre_Equipement.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			global::GMAO.Arbre_Equipement.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.Arbre_Equipement.button2.ForeColor = global::System.Drawing.Color.White;
			global::GMAO.Arbre_Equipement.button2.Location = new global::System.Drawing.Point(81, 0);
			global::GMAO.Arbre_Equipement.button2.Name = "button2";
			global::GMAO.Arbre_Equipement.button2.Size = new global::System.Drawing.Size(82, 33);
			global::GMAO.Arbre_Equipement.button2.TabIndex = 21;
			global::GMAO.Arbre_Equipement.button2.Text = "Observation";
			global::GMAO.Arbre_Equipement.button2.UseVisualStyleBackColor = false;
			global::GMAO.Arbre_Equipement.button2.Click += new global::System.EventHandler(global::GMAO.Arbre_Equipement.button2_Click);
			global::GMAO.Arbre_Equipement.button1.BackColor = global::System.Drawing.Color.Firebrick;
			global::GMAO.Arbre_Equipement.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			global::GMAO.Arbre_Equipement.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			global::GMAO.Arbre_Equipement.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.Arbre_Equipement.button1.ForeColor = global::System.Drawing.Color.White;
			global::GMAO.Arbre_Equipement.button1.Location = new global::System.Drawing.Point(0, 0);
			global::GMAO.Arbre_Equipement.button1.Name = "button1";
			global::GMAO.Arbre_Equipement.button1.Size = new global::System.Drawing.Size(82, 33);
			global::GMAO.Arbre_Equipement.button1.TabIndex = 0;
			global::GMAO.Arbre_Equipement.button1.Text = "Générale";
			global::GMAO.Arbre_Equipement.button1.UseVisualStyleBackColor = false;
			global::GMAO.Arbre_Equipement.button1.Click += new global::System.EventHandler(global::GMAO.Arbre_Equipement.button1_Click_1);
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(474, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(168, 95);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 19;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.WaitOnLoad = true;
			global::GMAO.Arbre_Equipement.label7.AutoSize = true;
			global::GMAO.Arbre_Equipement.label7.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.Arbre_Equipement.label7.ForeColor = global::System.Drawing.Color.DimGray;
			global::GMAO.Arbre_Equipement.label7.Location = new global::System.Drawing.Point(84, 44);
			global::GMAO.Arbre_Equipement.label7.Name = "label7";
			global::GMAO.Arbre_Equipement.label7.Size = new global::System.Drawing.Size(40, 15);
			global::GMAO.Arbre_Equipement.label7.TabIndex = 18;
			global::GMAO.Arbre_Equipement.label7.Text = "label7";
			global::GMAO.Arbre_Equipement.label6.AutoSize = true;
			global::GMAO.Arbre_Equipement.label6.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.Arbre_Equipement.label6.ForeColor = global::System.Drawing.Color.DimGray;
			global::GMAO.Arbre_Equipement.label6.Location = new global::System.Drawing.Point(48, 26);
			global::GMAO.Arbre_Equipement.label6.Name = "label6";
			global::GMAO.Arbre_Equipement.label6.Size = new global::System.Drawing.Size(40, 15);
			global::GMAO.Arbre_Equipement.label6.TabIndex = 17;
			global::GMAO.Arbre_Equipement.label6.Text = "label6";
			global::GMAO.Arbre_Equipement.label5.AutoSize = true;
			global::GMAO.Arbre_Equipement.label5.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.Arbre_Equipement.label5.ForeColor = global::System.Drawing.Color.DimGray;
			global::GMAO.Arbre_Equipement.label5.Location = new global::System.Drawing.Point(26, 9);
			global::GMAO.Arbre_Equipement.label5.Name = "label5";
			global::GMAO.Arbre_Equipement.label5.Size = new global::System.Drawing.Size(40, 15);
			global::GMAO.Arbre_Equipement.label5.TabIndex = 16;
			global::GMAO.Arbre_Equipement.label5.Text = "label5";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(5, 44);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(78, 15);
			this.label4.TabIndex = 15;
			this.label4.Text = "Désignation :";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(5, 26);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(42, 15);
			this.label3.TabIndex = 14;
			this.label3.Text = "Code :";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(5, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(22, 15);
			this.label2.TabIndex = 13;
			this.label2.Text = "ID:";
			global::GMAO.Arbre_Equipement.guna2Button2.BorderRadius = 8;
			global::GMAO.Arbre_Equipement.guna2Button2.CheckedState.Parent = global::GMAO.Arbre_Equipement.guna2Button2;
			global::GMAO.Arbre_Equipement.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			global::GMAO.Arbre_Equipement.guna2Button2.CustomImages.Parent = global::GMAO.Arbre_Equipement.guna2Button2;
			global::GMAO.Arbre_Equipement.guna2Button2.FillColor = global::System.Drawing.Color.Silver;
			global::GMAO.Arbre_Equipement.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			global::GMAO.Arbre_Equipement.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			global::GMAO.Arbre_Equipement.guna2Button2.HoverState.Parent = global::GMAO.Arbre_Equipement.guna2Button2;
			global::GMAO.Arbre_Equipement.guna2Button2.Location = new global::System.Drawing.Point(1037, 45);
			global::GMAO.Arbre_Equipement.guna2Button2.Name = "guna2Button2";
			global::GMAO.Arbre_Equipement.guna2Button2.ShadowDecoration.Parent = global::GMAO.Arbre_Equipement.guna2Button2;
			global::GMAO.Arbre_Equipement.guna2Button2.Size = new global::System.Drawing.Size(78, 28);
			global::GMAO.Arbre_Equipement.guna2Button2.TabIndex = 7;
			global::GMAO.Arbre_Equipement.guna2Button2.Text = "Fermer";
			global::GMAO.Arbre_Equipement.guna2Button2.Click += new global::System.EventHandler(global::GMAO.Arbre_Equipement.guna2Button2_Click);
			global::GMAO.Arbre_Equipement.guna2Button1.BorderRadius = 8;
			global::GMAO.Arbre_Equipement.guna2Button1.CheckedState.Parent = global::GMAO.Arbre_Equipement.guna2Button1;
			global::GMAO.Arbre_Equipement.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			global::GMAO.Arbre_Equipement.guna2Button1.CustomImages.Parent = global::GMAO.Arbre_Equipement.guna2Button1;
			global::GMAO.Arbre_Equipement.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			global::GMAO.Arbre_Equipement.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			global::GMAO.Arbre_Equipement.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			global::GMAO.Arbre_Equipement.guna2Button1.HoverState.Parent = global::GMAO.Arbre_Equipement.guna2Button1;
			global::GMAO.Arbre_Equipement.guna2Button1.Location = new global::System.Drawing.Point(319, 45);
			global::GMAO.Arbre_Equipement.guna2Button1.Name = "guna2Button1";
			global::GMAO.Arbre_Equipement.guna2Button1.ShadowDecoration.Parent = global::GMAO.Arbre_Equipement.guna2Button1;
			global::GMAO.Arbre_Equipement.guna2Button1.Size = new global::System.Drawing.Size(115, 28);
			global::GMAO.Arbre_Equipement.guna2Button1.TabIndex = 157;
			global::GMAO.Arbre_Equipement.guna2Button1.Text = "Afficher Joints";
			global::GMAO.Arbre_Equipement.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			global::GMAO.Arbre_Equipement.panel5.Controls.Add(this.radRadioButton3);
			global::GMAO.Arbre_Equipement.panel5.Controls.Add(global::GMAO.Arbre_Equipement.radRadioButton2);
			global::GMAO.Arbre_Equipement.panel5.Controls.Add(global::GMAO.Arbre_Equipement.radRadioButton1);
			global::GMAO.Arbre_Equipement.panel5.Location = new global::System.Drawing.Point(453, 45);
			global::GMAO.Arbre_Equipement.panel5.Name = "panel5";
			global::GMAO.Arbre_Equipement.panel5.Size = new global::System.Drawing.Size(483, 29);
			global::GMAO.Arbre_Equipement.panel5.TabIndex = 158;
			global::GMAO.Arbre_Equipement.panel5.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
			global::GMAO.Arbre_Equipement.radRadioButton2.Location = new global::System.Drawing.Point(108, 4);
			global::GMAO.Arbre_Equipement.radRadioButton2.Name = "radRadioButton2";
			global::GMAO.Arbre_Equipement.radRadioButton2.Size = new global::System.Drawing.Size(134, 22);
			global::GMAO.Arbre_Equipement.radRadioButton2.TabIndex = 50;
			global::GMAO.Arbre_Equipement.radRadioButton2.TabStop = false;
			global::GMAO.Arbre_Equipement.radRadioButton2.Text = "Code Equipement";
			global::GMAO.Arbre_Equipement.radRadioButton2.ThemeName = "Crystal";
			global::GMAO.Arbre_Equipement.radRadioButton2.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton2_ToggleStateChanged);
			global::GMAO.Arbre_Equipement.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			global::GMAO.Arbre_Equipement.radRadioButton1.Location = new global::System.Drawing.Point(10, 4);
			global::GMAO.Arbre_Equipement.radRadioButton1.Name = "radRadioButton1";
			global::GMAO.Arbre_Equipement.radRadioButton1.Size = new global::System.Drawing.Size(99, 22);
			global::GMAO.Arbre_Equipement.radRadioButton1.TabIndex = 48;
			global::GMAO.Arbre_Equipement.radRadioButton1.Text = "Désignation";
			global::GMAO.Arbre_Equipement.radRadioButton1.ThemeName = "Crystal";
			global::GMAO.Arbre_Equipement.radRadioButton1.ToggleState = 1;
			global::GMAO.Arbre_Equipement.radRadioButton1.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
			this.radRadioButton3.Location = new global::System.Drawing.Point(237, 4);
			this.radRadioButton3.Name = "radRadioButton3";
			this.radRadioButton3.Size = new global::System.Drawing.Size(39, 22);
			this.radRadioButton3.TabIndex = 51;
			this.radRadioButton3.TabStop = false;
			this.radRadioButton3.Text = "ID";
			this.radRadioButton3.ThemeName = "Crystal";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(global::GMAO.Arbre_Equipement.panel5);
			base.Controls.Add(global::GMAO.Arbre_Equipement.guna2Button1);
			base.Controls.Add(global::GMAO.Arbre_Equipement.guna2Button2);
			base.Controls.Add(global::GMAO.Arbre_Equipement.Panel10);
			base.Controls.Add(global::GMAO.Arbre_Equipement.guna2TextBox1);
			base.Controls.Add(global::GMAO.Arbre_Equipement.arbre);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Arbre_Equipement";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.Asrbre_Equipement_Load);
			global::GMAO.Arbre_Equipement.arbre.EndInit();
			global::GMAO.Arbre_Equipement.Panel10.ResumeLayout(false);
			global::GMAO.Arbre_Equipement.Panel10.PerformLayout();
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			global::GMAO.Arbre_Equipement.panel5.ResumeLayout(false);
			global::GMAO.Arbre_Equipement.panel5.PerformLayout();
			global::GMAO.Arbre_Equipement.radRadioButton2.EndInit();
			global::GMAO.Arbre_Equipement.radRadioButton1.EndInit();
			this.radRadioButton3.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400024D RID: 589
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400024E RID: 590
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400024F RID: 591
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000250 RID: 592
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x04000251 RID: 593
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x04000252 RID: 594
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem2;

		// Token: 0x04000253 RID: 595
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem3;

		// Token: 0x04000254 RID: 596
		private global::Telerik.WinControls.UI.RadOffice2007ScreenTipElement radOffice2007ScreenTipElement1;

		// Token: 0x04000255 RID: 597
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x04000257 RID: 599
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem4;

		// Token: 0x04000258 RID: 600
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem5;

		// Token: 0x04000259 RID: 601
		private global::Telerik.WinControls.Themes.AquaTheme aquaTheme1;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400025C RID: 604
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400025F RID: 607
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton3;

		// Token: 0x04000260 RID: 608
		private static global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000261 RID: 609
		public static global::System.Windows.Forms.Label label7;

		// Token: 0x04000262 RID: 610
		public static global::System.Windows.Forms.Label label6;

		// Token: 0x04000263 RID: 611
		public static global::System.Windows.Forms.Label label5;

		// Token: 0x04000264 RID: 612
		public static global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x04000265 RID: 613
		private static global::System.Windows.Forms.Button button2;

		// Token: 0x04000266 RID: 614
		private static global::System.Windows.Forms.Button button1;

		// Token: 0x04000267 RID: 615
		private static global::System.Windows.Forms.Button button3;

		// Token: 0x04000268 RID: 616
		private static global::System.Windows.Forms.Button button7;

		// Token: 0x04000269 RID: 617
		private static global::System.Windows.Forms.Button button6;

		// Token: 0x0400026A RID: 618
		private static global::System.Windows.Forms.Button button5;

		// Token: 0x0400026B RID: 619
		private static global::System.Windows.Forms.Button button4;

		// Token: 0x0400026C RID: 620
		private static global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400026D RID: 621
		private static global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400026E RID: 622
		private static global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x0400026F RID: 623
		public static global::Guna.UI2.WinForms.Guna2Panel Panel10;

		// Token: 0x04000270 RID: 624
		public static global::Telerik.WinControls.UI.RadTreeView arbre;

		// Token: 0x04000271 RID: 625
		private static global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000272 RID: 626
		private static global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000273 RID: 627
		private static global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;
	}
}
