namespace GMAO
{
	// Token: 0x020000EC RID: 236
	public partial class Outillage_utilisation_lancement : global::System.Windows.Forms.Form
	{
		// Token: 0x06000A49 RID: 2633 RVA: 0x001978C4 File Offset: 0x00195AC4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x001978FC File Offset: 0x00195AFC
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
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.commentaire_radTextBoxControl1 = new global::Telerik.WinControls.UI.RadTextBoxControl();
			global::GMAO.Outillage_utilisation_lancement.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.intervenant_radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.date_debut_radDateTimePicker2 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.heure_debut_radTimePicker1 = new global::Telerik.WinControls.UI.RadTimePicker();
			this.label6 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.commentaire_radTextBoxControl1.BeginInit();
			global::GMAO.Outillage_utilisation_lancement.radGridView1.BeginInit();
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.BeginInit();
			this.radButton1.BeginInit();
			this.intervenant_radDropDownList1.BeginInit();
			global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.BeginInit();
			this.date_debut_radDateTimePicker2.BeginInit();
			this.heure_debut_radTimePicker1.BeginInit();
			base.SuspendLayout();
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(12, 59);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(68, 13);
			this.label5.TabIndex = 40;
			this.label5.Text = "Commentaire";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(828, 59);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(67, 13);
			this.label4.TabIndex = 38;
			this.label4.Text = "heure_debut";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(828, 18);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(63, 13);
			this.label3.TabIndex = 37;
			this.label3.Text = "Date_debut";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(428, 18);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(28, 13);
			this.label2.TabIndex = 36;
			this.label2.Text = "Outil";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(61, 13);
			this.label1.TabIndex = 35;
			this.label1.Text = "Intervenant";
			this.commentaire_radTextBoxControl1.Location = new global::System.Drawing.Point(84, 59);
			this.commentaire_radTextBoxControl1.Name = "commentaire_radTextBoxControl1";
			this.commentaire_radTextBoxControl1.Size = new global::System.Drawing.Size(730, 91);
			this.commentaire_radTextBoxControl1.TabIndex = 34;
			this.commentaire_radTextBoxControl1.ThemeName = "Crystal";
			global::GMAO.Outillage_utilisation_lancement.radGridView1.BackColor = global::System.Drawing.SystemColors.Control;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f);
			global::GMAO.Outillage_utilisation_lancement.radGridView1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.Location = new global::System.Drawing.Point(15, 176);
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.AllowAddNewRow = false;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.AllowDeleteRow = false;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.AllowEditRow = false;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column1";
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Outil";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column2";
			gridViewTextBoxColumn2.Width = 170;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Intervenant";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column3";
			gridViewTextBoxColumn3.Width = 170;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Date_debut";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column4";
			gridViewTextBoxColumn4.Width = 90;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Heure_debut";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column5";
			gridViewTextBoxColumn5.Width = 100;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Date_fin";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.IsVisible = false;
			gridViewTextBoxColumn6.Name = "column6";
			gridViewTextBoxColumn6.Width = 100;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Heure_fin";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.IsVisible = false;
			gridViewTextBoxColumn7.Name = "column7";
			gridViewTextBoxColumn7.Width = 100;
			gridViewTextBoxColumn8.EnableExpressionEditor = false;
			gridViewTextBoxColumn8.HeaderText = "Commentaire";
			gridViewTextBoxColumn8.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn8.Name = "column8";
			gridViewTextBoxColumn8.Width = 215;
			gridViewTextBoxColumn9.HeaderText = "N° OT";
			gridViewTextBoxColumn9.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn9.Name = "column11";
			gridViewTextBoxColumn9.Width = 150;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column9";
			gridViewImageColumn.Width = 100;
			gridViewTextBoxColumn10.HeaderText = "id_outil";
			gridViewTextBoxColumn10.IsVisible = false;
			gridViewTextBoxColumn10.Name = "column10";
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
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
				gridViewImageColumn,
				gridViewTextBoxColumn10
			});
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.EnableFiltering = true;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.EnablePaging = true;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.ShowFilteringRow = false;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.ShowHeaderCellButtons = true;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.Name = "radGridView1";
			global::GMAO.Outillage_utilisation_lancement.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.ShowGroupPanel = false;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.ShowHeaderCellButtons = true;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.Size = new global::System.Drawing.Size(1057, 313);
			global::GMAO.Outillage_utilisation_lancement.radGridView1.TabIndex = 31;
			global::GMAO.Outillage_utilisation_lancement.radGridView1.ThemeName = "Fluent";
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.radButton1.Location = new global::System.Drawing.Point(831, 126);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(115, 24);
			this.radButton1.TabIndex = 30;
			this.radButton1.Text = "Affecter";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.intervenant_radDropDownList1.DropDownAnimationEasing = 2;
			this.intervenant_radDropDownList1.DropDownStyle = 2;
			this.intervenant_radDropDownList1.Location = new global::System.Drawing.Point(84, 13);
			this.intervenant_radDropDownList1.Name = "intervenant_radDropDownList1";
			this.intervenant_radDropDownList1.Size = new global::System.Drawing.Size(313, 24);
			this.intervenant_radDropDownList1.TabIndex = 163;
			this.intervenant_radDropDownList1.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadDropDownListElement)this.intervenant_radDropDownList1.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(1)).AutoSize = false;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.intervenant_radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.DropDownAnimationEasing = 2;
			global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.DropDownStyle = 2;
			global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.Location = new global::System.Drawing.Point(470, 13);
			global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.Name = "outil_radDropDownList2";
			global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.Size = new global::System.Drawing.Size(344, 24);
			global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.TabIndex = 164;
			global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadDropDownListElement)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(1)).AutoSize = false;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.date_debut_radDateTimePicker2.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.date_debut_radDateTimePicker2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.date_debut_radDateTimePicker2.ForeColor = global::System.Drawing.Color.DimGray;
			this.date_debut_radDateTimePicker2.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.date_debut_radDateTimePicker2.Location = new global::System.Drawing.Point(901, 12);
			this.date_debut_radDateTimePicker2.Name = "date_debut_radDateTimePicker2";
			this.date_debut_radDateTimePicker2.Size = new global::System.Drawing.Size(163, 27);
			this.date_debut_radDateTimePicker2.TabIndex = 166;
			this.date_debut_radDateTimePicker2.TabStop = false;
			this.date_debut_radDateTimePicker2.Text = "10/02/2021";
			this.date_debut_radDateTimePicker2.ThemeName = "Crystal";
			this.date_debut_radDateTimePicker2.Value = new global::System.DateTime(2021, 2, 10, 16, 51, 18, 838);
			((global::Telerik.WinControls.UI.RadDateTimePickerElement)this.date_debut_radDateTimePicker2.GetChildAt(0)).CalendarSize = new global::System.Drawing.Size(290, 320);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.date_debut_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.date_debut_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.date_debut_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.date_debut_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.date_debut_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.date_debut_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.date_debut_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.date_debut_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.heure_debut_radTimePicker1.Location = new global::System.Drawing.Point(901, 56);
			this.heure_debut_radTimePicker1.MaxValue = new global::System.DateTime(9999, 12, 31, 23, 59, 59, 0);
			this.heure_debut_radTimePicker1.MinValue = new global::System.DateTime(0L);
			this.heure_debut_radTimePicker1.Name = "heure_debut_radTimePicker1";
			this.heure_debut_radTimePicker1.Size = new global::System.Drawing.Size(163, 24);
			this.heure_debut_radTimePicker1.TabIndex = 201;
			this.heure_debut_radTimePicker1.TabStop = false;
			this.heure_debut_radTimePicker1.ThemeName = "Crystal";
			this.heure_debut_radTimePicker1.Value = new global::System.DateTime?(new global::System.DateTime(2021, 5, 18, 23, 1, 27, 720));
			((global::Telerik.WinControls.UI.StackLayoutElement)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).NumberOfColors = 1;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.RadTimeElementUpButton)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.ArrowPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.OverflowPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(3)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.ImagePrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(4)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(5)).LineLimit = false;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(5)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(1)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.ArrowPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.OverflowPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(3)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.ImagePrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(4)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(5)).LineLimit = false;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.heure_debut_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(5)).BackColor = global::System.Drawing.Color.Firebrick;
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(828, 95);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(37, 13);
			this.label6.TabIndex = 202;
			this.label6.Text = "N° OT";
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
			this.TextBox2.Location = new global::System.Drawing.Point(901, 89);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(163, 29);
			this.TextBox2.TabIndex = 203;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 501);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.heure_debut_radTimePicker1);
			base.Controls.Add(this.date_debut_radDateTimePicker2);
			base.Controls.Add(global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2);
			base.Controls.Add(this.intervenant_radDropDownList1);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.commentaire_radTextBoxControl1);
			base.Controls.Add(global::GMAO.Outillage_utilisation_lancement.radGridView1);
			base.Controls.Add(this.radButton1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Outillage_utilisation_lancement";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.Outillage_utilisation_lancement_Load);
			this.commentaire_radTextBoxControl1.EndInit();
			global::GMAO.Outillage_utilisation_lancement.radGridView1.MasterTemplate.EndInit();
			global::GMAO.Outillage_utilisation_lancement.radGridView1.EndInit();
			this.radButton1.EndInit();
			this.intervenant_radDropDownList1.EndInit();
			global::GMAO.Outillage_utilisation_lancement.outil_radDropDownList2.EndInit();
			this.date_debut_radDateTimePicker2.EndInit();
			this.heure_debut_radTimePicker1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000D3F RID: 3391
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000D40 RID: 3392
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000D41 RID: 3393
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000D42 RID: 3394
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000D43 RID: 3395
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000D44 RID: 3396
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000D45 RID: 3397
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000D46 RID: 3398
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000D47 RID: 3399
		private global::Telerik.WinControls.UI.RadTextBoxControl commentaire_radTextBoxControl1;

		// Token: 0x04000D48 RID: 3400
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000D49 RID: 3401
		private global::Telerik.WinControls.UI.RadDropDownList intervenant_radDropDownList1;

		// Token: 0x04000D4A RID: 3402
		private global::Telerik.WinControls.UI.RadDateTimePicker date_debut_radDateTimePicker2;

		// Token: 0x04000D4B RID: 3403
		private global::Telerik.WinControls.UI.RadTimePicker heure_debut_radTimePicker1;

		// Token: 0x04000D4C RID: 3404
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000D4D RID: 3405
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04000D4E RID: 3406
		private static global::Telerik.WinControls.UI.RadDropDownList outil_radDropDownList2;

		// Token: 0x04000D4F RID: 3407
		public static global::Telerik.WinControls.UI.RadGridView radGridView1;
	}
}
