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

namespace GMAO
{
	// Token: 0x020000CF RID: 207
	public partial class ot_ressources_fonction : Form
	{
		// Token: 0x0600094A RID: 2378 RVA: 0x0017F9DC File Offset: 0x0017DBDC
		public ot_ressources_fonction()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_ressources_fonction.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_ressources_fonction.select_changee);
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0017FA47 File Offset: 0x0017DC47
		private void ot_ressources_fonction_Load(object sender, EventArgs e)
		{
			this.select_date_heure();
			this.select_tableau();
			this.select_fonction();
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0017FA60 File Offset: 0x0017DC60
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

		// Token: 0x0600094D RID: 2381 RVA: 0x0017FAE4 File Offset: 0x0017DCE4
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

		// Token: 0x0600094E RID: 2382 RVA: 0x0017FBE8 File Offset: 0x0017DDE8
		private void select_tableau()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select ot_ressources_fonction.id, fonction_intervenant.designation, nbre_requis, min_planif, type_cout, date_debut, heure_debut from ot_ressources_fonction inner join fonction_intervenant on ot_ressources_fonction.id_fonction = fonction_intervenant.id where id_ot = @i";
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
						fonction.Mid(dataTable.Rows[i].ItemArray[5].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0017FD90 File Offset: 0x0017DF90
		private void select_fonction()
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation from fonction_intervenant";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0017FE7C File Offset: 0x0017E07C
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.isnumeric(this.TextBox1.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToInt32(this.TextBox1.Text) > 0;
					if (flag3)
					{
						bool flag4 = fonction.isnumeric(this.TextBox2.Text);
						if (flag4)
						{
							bool flag5 = Convert.ToInt32(this.TextBox2.Text) > 0;
							if (flag5)
							{
								string value = "Interne";
								bool isChecked = this.radRadioButton2.IsChecked;
								if (isChecked)
								{
									value = "Externe";
								}
								bd bd = new bd();
								string cmdText = "insert into ot_ressources_fonction (id_fonction, id_ot, nbre_requis, min_planif, type_cout, date_debut, heure_debut) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
								SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
								sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag.ToString();
								sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
								sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = this.TextBox1.Text;
								sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = this.TextBox2.Text;
								sqlCommand.Parameters.Add("@i5", SqlDbType.VarChar).Value = value;
								sqlCommand.Parameters.Add("@i6", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
								sqlCommand.Parameters.Add("@i7", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 5);
								bd.ouverture_bd(bd.cnn);
								sqlCommand.ExecuteNonQuery();
								bd.cnn.Close();
								MessageBox.Show("Ajout avec succés");
								this.TextBox1.Clear();
								this.TextBox2.Clear();
								this.select_tableau();
							}
							else
							{
								MessageBox.Show("Erreur :Minutes Planifiées doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur :Minutes Planifiées doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur :Nbre Requis doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur :Nbre Requis doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Il faut choisir la fonction", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00180134 File Offset: 0x0017E334
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 7;
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "delete ot_ressources_fonction where id = @i";
					string cmdText2 = "delete ot_ordo_intervenant where id_ressource_fonction = @i";
					int num = Convert.ToInt32(this.radGridView3.Rows[e.RowIndex].Cells[0].Value);
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = num;
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = num;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					this.select_tableau();
				}
			}
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00180250 File Offset: 0x0017E450
		private void select_date_heure()
		{
			bd bd = new bd();
			string cmdText = "select date_debut, heure_debut from ordre_travail where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radDateTimePicker1.Value = Convert.ToDateTime(dataTable.Rows[0].ItemArray[0]);
				this.radTimePicker1.Value = new DateTime?(Convert.ToDateTime(dataTable.Rows[0].ItemArray[1]));
			}
		}
	}
}
