using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x020000B5 RID: 181
	public partial class ot_diagnostic_final : Form
	{
		// Token: 0x06000829 RID: 2089 RVA: 0x00160ACC File Offset: 0x0015ECCC
		public ot_diagnostic_final()
		{
			this.InitializeComponent();
			this.fermer_panel();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_diagnostic_final.select_change);
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_diagnostic_final.select_changee);
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radGridView3.ContextMenuOpening += new ContextMenuOpeningEventHandler(this.radGridView1_ContextMenuOpening);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00160B75 File Offset: 0x0015ED75
		private void ot_diagnostic_final_Load(object sender, EventArgs e)
		{
			this.select_tableau();
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00160B80 File Offset: 0x0015ED80
		public static void select_change(object sender, CellFormattingEventArgs e)
		{
			bool isCurrent = e.CellElement.IsCurrent;
			if (isCurrent)
			{
				e.CellElement.DrawFill = true;
				e.CellElement.GradientStyle = 0;
				e.CellElement.BackColor = Color.Firebrick;
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
				e.CellElement.ResetValue(VisualElement.BackColorProperty);
				e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
			}
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00160C04 File Offset: 0x0015EE04
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
				e.RowElement.BackColor = Color.LightYellow;
			}
			else
			{
				bool isSelected = e.RowElement.IsSelected;
				if (isSelected)
				{
					e.RowElement.DrawFill = true;
					e.RowElement.GradientStyle = 0;
					e.RowElement.BackColor = Color.Firebrick;
				}
				else
				{
					e.RowElement.ResetValue(LightVisualElement.DrawFillProperty);
					e.RowElement.ResetValue(VisualElement.BackColorProperty);
					e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty);
					e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
				}
			}
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x00160D07 File Offset: 0x0015EF07
		private void fermer_panel()
		{
			this.panel2.Visible = false;
			this.panel1.Visible = false;
			this.radGridView3.Size = new Size(1050, 210);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x00160D40 File Offset: 0x0015EF40
		private void select_tableau()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select parametre_anomalie.id, parametre_anomalie.code, parametre_anomalie.anomalie from ordre_travail inner join parametre_anomalie on ordre_travail.id_defaillance = parametre_anomalie.id where ordre_travail.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						"Symptôme",
						"Opération"
					});
				}
			}
			string cmdText2 = "select parametre_anomalie.id, parametre_anomalie.code, parametre_anomalie.anomalie from ot_diagnostic_def inner join parametre_anomalie on ot_diagnostic_def.id_defaillance = parametre_anomalie.id where id_ot = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable2.Rows[j].ItemArray[0].ToString(),
						dataTable2.Rows[j].ItemArray[1].ToString(),
						dataTable2.Rows[j].ItemArray[2].ToString(),
						"Symptôme",
						"Opération"
					});
				}
			}
			this.radGridView3.Templates.Clear();
			this.Loadsymptome();
			this.Loadoperation();
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x00160FA4 File Offset: 0x0015F1A4
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 3;
			if (flag)
			{
				this.panel2.Visible = true;
				this.panel1.Visible = false;
				this.radGridView3.Size = new Size(1050, 141);
				this.id_f = Convert.ToInt32(this.radGridView3.Rows[e.RowIndex].Cells[0].Value);
				this.select_symp(this.id_f);
			}
			bool flag2 = e.RowIndex >= 0 && e.ColumnIndex == 4;
			if (flag2)
			{
				this.panel2.Visible = false;
				this.panel1.Visible = true;
				this.panel1.Location = new Point(12, 118);
				this.radGridView3.Size = new Size(1050, 100);
				this.id_f = Convert.ToInt32(this.radGridView3.Rows[e.RowIndex].Cells[0].Value);
				this.radDateTimePicker1.Value = DateTime.Today;
				this.radDateTimePicker2.Value = DateTime.Today;
				this.radTimePicker1.Value = new DateTime?(DateTime.Now);
				this.radTimePicker2.Value = new DateTime?(DateTime.Now);
				this.select_operation(this.id_f);
			}
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x00161131 File Offset: 0x0015F331
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.fermer_panel();
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0016113B File Offset: 0x0015F33B
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.fermer_panel();
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x00161148 File Offset: 0x0015F348
		private void select_symp(int id)
		{
			this.radDropDownList2.Items.Clear();
			this.TextBox2.Clear();
			bd bd = new bd();
			string cmdText = "select code, designation from symptome where id in (select id_symptome from symptome_defaillance where id_defaillance = @i) and id not in (select id_symptome from ot_diagnostic_symptome where id_ot = @v)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList2.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					this.radDropDownList2.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0016127C File Offset: 0x0015F47C
		private void select_operation(int id)
		{
			this.radDropDownList1.Items.Clear();
			this.TextBox1.Clear();
			bd bd = new bd();
			string cmdText = "select code, designation from operation_diagnostic where id_defaillance = @i and id not in(select id_operation from ot_diagnostic_operation where id_ot = @v)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x001613B0 File Offset: 0x0015F5B0
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				this.TextBox1.Text = this.radDropDownList1.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x001613FC File Offset: 0x0015F5FC
		private void radDropDownList2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList2.Text != "";
			if (flag)
			{
				this.TextBox2.Text = this.radDropDownList2.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00161448 File Offset: 0x0015F648
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 3;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(52, 152, 219), "", typeof(FillPrimitive));
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 4;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement2.ForeColor = Color.White;
			}
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x001615B4 File Offset: 0x0015F7B4
		private void radButton2_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList2.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from symptome where code = @v";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList2.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string cmdText2 = "insert into ot_diagnostic_symptome (id_ot, id_symptome, id_defaillance) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				sqlCommand2.Parameters.Add("@v2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
				sqlCommand2.Parameters.Add("@v3", SqlDbType.Int).Value = this.id_f;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				this.select_symp(this.id_f);
				MessageBox.Show("Enregistrement avec succés");
				this.select_tableau();
			}
			else
			{
				MessageBox.Show("Erreur :Champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00161718 File Offset: 0x0015F918
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from operation_diagnostic where code = @v";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				int hour = Convert.ToInt32(fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 2));
				int minute = Convert.ToInt32(fonction.Mid(this.radTimePicker1.Value.ToString(), 15, 2));
				int hour2 = Convert.ToInt32(fonction.Mid(this.radTimePicker2.Value.ToString(), 12, 2));
				int minute2 = Convert.ToInt32(fonction.Mid(this.radTimePicker2.Value.ToString(), 15, 2));
				DateTime dateTime = new DateTime(this.radDateTimePicker1.Value.Year, this.radDateTimePicker1.Value.Month, this.radDateTimePicker1.Value.Day, hour, minute, 0);
				DateTime dateTime2 = new DateTime(this.radDateTimePicker2.Value.Year, this.radDateTimePicker2.Value.Month, this.radDateTimePicker2.Value.Day, hour2, minute2, 0);
				bool flag2 = dateTime2 > dateTime;
				if (flag2)
				{
					string cmdText2 = "insert into ot_diagnostic_operation (id_ot, id_operation, debut, fin) values (@v1, @v2, @v3, @v4)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					sqlCommand2.Parameters.Add("@v2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
					sqlCommand2.Parameters.Add("@v3", SqlDbType.DateTime).Value = dateTime;
					sqlCommand2.Parameters.Add("@v4", SqlDbType.DateTime).Value = dateTime2;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					this.select_operation(this.id_f);
					MessageBox.Show("Enregistrement avec succés");
					this.select_tableau();
				}
				else
				{
					MessageBox.Show("Erreur :La date de fin doit être supérieure à la date de début", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x001619F8 File Offset: 0x0015FBF8
		private void Loadsymptome()
		{
			bd bd = new bd();
			string cmdText = "select id_defaillance, ot_diagnostic_symptome.id, symptome.code, symptome.designation from ot_diagnostic_symptome inner join symptome on ot_diagnostic_symptome.id_symptome = symptome.id where id_ot = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			dataTable2.Columns.Add("column4");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Symptômes";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 400;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].IsVisible = false;
				gridViewTemplate.Columns[2].HeaderText = "";
				gridViewTemplate.Columns[2].HeaderText = "Code Symptôme";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				this.radGridView3.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView3.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView3.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView3.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x00161D80 File Offset: 0x0015FF80
		private void Loadoperation()
		{
			bd bd = new bd();
			string cmdText = "select id_defaillance, ot_diagnostic_operation.id, operation_diagnostic.code, operation_diagnostic.designation, debut, fin, datepart(hour, fin-debut), datepart(minute, fin-debut) from ot_diagnostic_operation inner join operation_diagnostic on ot_diagnostic_operation.id_operation = operation_diagnostic.id where id_ot = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			dataTable2.Columns.Add("column4");
			dataTable2.Columns.Add("column5");
			dataTable2.Columns.Add("column6");
			dataTable2.Columns.Add("column7");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[6]) == 0;
					string text;
					if (flag2)
					{
						text = dataTable.Rows[i].ItemArray[7].ToString() + " Min";
					}
					else
					{
						text = dataTable.Rows[i].ItemArray[6].ToString() + " H " + dataTable.Rows[i].ItemArray[7].ToString() + " Min";
					}
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						text
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Opérations";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 180;
				gridViewTemplate.Columns["column4"].Width = 350;
				gridViewTemplate.Columns["column5"].Width = 150;
				gridViewTemplate.Columns["column6"].Width = 150;
				gridViewTemplate.Columns["column7"].Width = 120;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].IsVisible = false;
				gridViewTemplate.Columns[2].HeaderText = "";
				gridViewTemplate.Columns[2].HeaderText = "Code Opération";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[4].HeaderText = "Début";
				gridViewTemplate.Columns[5].HeaderText = "Fin";
				gridViewTemplate.Columns[6].HeaderText = "Durée";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[6].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				this.radGridView3.Templates.Insert(this.radGridView3.Templates.Count, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView3.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView3.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView3.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0016233C File Offset: 0x0016053C
		private void radGridView1_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
		{
			GridDataCellElement targetCell = e.ContextMenuProvider as GridDataCellElement;
			bool flag = targetCell != null && targetCell.RowInfo.HierarchyLevel == 1;
			if (flag)
			{
				e.ContextMenu.Items.Clear();
				bool flag2 = targetCell.RowInfo.ViewTemplate.Caption == "Symptômes";
				if (flag2)
				{
					RadMenuItem radMenuItem = new RadMenuItem("Supprimer");
					e.ContextMenu.Items.Add(radMenuItem);
					radMenuItem.Click += delegate(object s, EventArgs f)
					{
						string value = targetCell.RowInfo.Cells[1].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "delete ot_diagnostic_symptome where id = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.select_tableau();
							this.select_symp(this.id_f);
						}
					};
				}
				bool flag3 = targetCell.RowInfo.ViewTemplate.Caption == "Opérations";
				if (flag3)
				{
					RadMenuItem radMenuItem2 = new RadMenuItem("Supprimer");
					e.ContextMenu.Items.Add(radMenuItem2);
					radMenuItem2.Click += delegate(object s, EventArgs f)
					{
						string value = targetCell.RowInfo.Cells[1].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "delete ot_diagnostic_operation where id = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.select_tableau();
							this.select_operation(this.id_f);
						}
					};
				}
			}
		}

		// Token: 0x04000B36 RID: 2870
		private int id_f = 0;
	}
}
