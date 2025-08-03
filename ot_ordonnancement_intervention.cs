using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x020000CA RID: 202
	public partial class ot_ordonnancement_intervention : Form
	{
		// Token: 0x06000904 RID: 2308 RVA: 0x0017AC94 File Offset: 0x00178E94
		public ot_ordonnancement_intervention()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_ordonnancement_intervention.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_ordonnancement_intervention.select_changee);
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0017AD06 File Offset: 0x00178F06
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			this.radGridView3.Size = new Size(1050, 210);
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x0017AD31 File Offset: 0x00178F31
		private void ot_ordonnancement_intervention_Load(object sender, EventArgs e)
		{
			this.pictureBox3_Click(sender, e);
			this.select_tableau();
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0017AD44 File Offset: 0x00178F44
		private void select_tableau()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select ot_ressources_fonction.id, fonction_intervenant.designation, nbre_requis, min_planif, date_debut, heure_debut from ot_ressources_fonction inner join fonction_intervenant on ot_ressources_fonction.id_fonction = fonction_intervenant.id where id_ot = @i";
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
						fonction.Mid(dataTable.Rows[i].ItemArray[4].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						Resources.icons8_approuver_et_mettre_à_jour_96__4_
					});
				}
			}
			this.radGridView3.Templates.Clear();
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0017AEE0 File Offset: 0x001790E0
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

		// Token: 0x06000909 RID: 2313 RVA: 0x0017AF64 File Offset: 0x00179164
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

		// Token: 0x0600090A RID: 2314 RVA: 0x0017B068 File Offset: 0x00179268
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 6;
			if (flag)
			{
				this.panel1.Visible = true;
				this.radGridView3.Size = new Size(1050, 141);
				this.id_f = Convert.ToInt32(this.radGridView3.Rows[e.RowIndex].Cells[0].Value);
				this.verif_check();
			}
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0017B0F4 File Offset: 0x001792F4
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				this.TextBox1.Text = this.radDropDownList1.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0017B140 File Offset: 0x00179340
		private void select_reparation()
		{
			this.radDropDownList1.Items.Clear();
			this.TextBox1.Clear();
			bd bd = new bd();
			string cmdText = "select code, intervention from parametre_intervention where id in (select id_intervention from ordre_travail where id = @i)";
			string cmdText2 = "select code, designation from operation_maintenance where id_intervention in (select id_intervention from ordre_travail where id = @i) and type = @t";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			sqlCommand2.Parameters.Add("@t", SqlDbType.VarChar).Value = "Réparation";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radDropDownList1.Items.Add(dataTable.Rows[0].ItemArray[0].ToString());
				this.radDropDownList1.Items[0].Tag = dataTable.Rows[0].ItemArray[1].ToString();
			}
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(dataTable2.Rows[i].ItemArray[0].ToString());
					this.radDropDownList1.Items[i + 1].Tag = dataTable2.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0017B33C File Offset: 0x0017953C
		private void select_test()
		{
			this.radDropDownList1.Items.Clear();
			this.TextBox1.Clear();
			bd bd = new bd();
			string cmdText = "select code, intervention from parametre_intervention where id in (select id_intervention from ordre_travail where id = @i)";
			string cmdText2 = "select code, designation from operation_maintenance where id_intervention in (select id_intervention from ordre_travail where id = @i) and type = @t";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			sqlCommand2.Parameters.Add("@t", SqlDbType.VarChar).Value = "Test";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radDropDownList1.Items.Add(dataTable.Rows[0].ItemArray[0].ToString());
				this.radDropDownList1.Items[0].Tag = dataTable.Rows[0].ItemArray[1].ToString();
			}
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(dataTable2.Rows[i].ItemArray[0].ToString());
					this.radDropDownList1.Items[i + 1].Tag = dataTable2.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x0017B538 File Offset: 0x00179738
		private void select_diagnostic()
		{
			this.radDropDownList1.Items.Clear();
			this.TextBox1.Clear();
			bd bd = new bd();
			string cmdText = "select code, designation from operation_diagnostic where id_defaillance in (select id_defaillance from ordre_travail where id = @i)";
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
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x0017B650 File Offset: 0x00179850
		private void verif_check()
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.select_reparation();
			}
			bool isChecked2 = this.radRadioButton3.IsChecked;
			if (isChecked2)
			{
				this.select_diagnostic();
			}
			bool isChecked3 = this.radRadioButton4.IsChecked;
			if (isChecked3)
			{
				this.select_test();
			}
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0017B6A6 File Offset: 0x001798A6
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.verif_check();
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0017B6B0 File Offset: 0x001798B0
		private void radRadioButton3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.verif_check();
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x0017B6BA File Offset: 0x001798BA
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.verif_check();
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0017B6C4 File Offset: 0x001798C4
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "delete ot_ordo_intervention where id_ressource_fonction = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_f;
				string cmdText2 = "insert into ot_ordo_intervention (id_ressource_fonction, id_operation, type_operation) values (@i1, @i2, @i3)";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = this.id_f;
				string cmdText3 = "";
				string value = "";
				bool isChecked = this.radRadioButton1.IsChecked;
				if (isChecked)
				{
					bool flag2 = this.radDropDownList1.SelectedItem.Index == 0;
					if (flag2)
					{
						cmdText3 = "select id from parametre_intervention where code = @v";
						value = "Intervention";
					}
					else
					{
						cmdText3 = "select id from operation_maintenance where code = @v";
						value = "Réparation";
					}
				}
				bool isChecked2 = this.radRadioButton4.IsChecked;
				if (isChecked2)
				{
					bool flag3 = this.radDropDownList1.SelectedItem.Index == 0;
					if (flag3)
					{
						cmdText3 = "select id from parametre_intervention where code = @v";
						value = "Intervention";
					}
					else
					{
						cmdText3 = "select id from operation_maintenance where code = @v";
						value = "Test";
					}
				}
				bool isChecked3 = this.radRadioButton3.IsChecked;
				if (isChecked3)
				{
					cmdText3 = "select id from operation_diagnostic where code = @v";
					value = "Diagnostic";
				}
				int num = 0;
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag4 = dataTable.Rows.Count != 0;
				if (flag4)
				{
					num = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
				}
				sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = num;
				sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = value;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				MessageBox.Show("Enregistrement avec succés");
				this.select_tableau();
			}
			else
			{
				MessageBox.Show("Erreur :Il faut choisir l'opération", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x04000C21 RID: 3105
		private int id_f = 0;
	}
}
