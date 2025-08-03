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
	// Token: 0x02000077 RID: 119
	public partial class gamme_fonction : Form
	{
		// Token: 0x0600057E RID: 1406 RVA: 0x000E71D0 File Offset: 0x000E53D0
		public gamme_fonction()
		{
			this.InitializeComponent();
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(gamme_fonction.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(gamme_fonction.select_changee);
			this.radGridView2.CellClick += new GridViewCellEventHandler(this.RadGridView2_CellClick);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x000E723C File Offset: 0x000E543C
		private void select_fonction()
		{
			this.radDropDownList9.Items.Clear();
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
					this.radDropDownList9.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList9.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x000E7325 File Offset: 0x000E5525
		private void gamme_fonction_Load(object sender, EventArgs e)
		{
			this.select_tableau();
			this.select_fonction();
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x000E7338 File Offset: 0x000E5538
		private void RadGridView2_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 6;
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "delete gamme_ressources_fonction where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					this.select_tableau();
				}
			}
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x000E740C File Offset: 0x000E560C
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

		// Token: 0x06000583 RID: 1411 RVA: 0x000E7490 File Offset: 0x000E5690
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

		// Token: 0x06000584 RID: 1412 RVA: 0x000E7594 File Offset: 0x000E5794
		private void radButton2_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList9.Text != "";
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.isnumeric(this.guna2TextBox5.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToInt32(this.guna2TextBox5.Text) > 0;
					if (flag3)
					{
						bool flag4 = fonction.isnumeric(this.guna2TextBox6.Text);
						if (flag4)
						{
							bool flag5 = Convert.ToInt32(this.guna2TextBox6.Text) > 0;
							if (flag5)
							{
								string value = "Interne";
								bool isChecked = this.radRadioButton2.IsChecked;
								if (isChecked)
								{
									value = "Externe";
								}
								bd bd = new bd();
								string cmdText = "insert into gamme_ressources_fonction (id_fonction, id_gamme, nbre_requis, min_planif, type_cout) values (@i1, @i2, @i3, @i4, @i5)";
								SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
								sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList9.SelectedItem.Tag.ToString();
								sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = liste_gamme_operatoire.id_gamme;
								sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = this.guna2TextBox5.Text;
								sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = this.guna2TextBox6.Text;
								sqlCommand.Parameters.Add("@i5", SqlDbType.VarChar).Value = value;
								bd.ouverture_bd(bd.cnn);
								sqlCommand.ExecuteNonQuery();
								bd.cnn.Close();
								this.select_tableau();
							}
							else
							{
								MessageBox.Show("Erreur :Minutes planifiées doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur :Minutes planifiées doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur :Nbre Requis doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur :Nbre Requis doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Il faut choisir la fonction", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x000E77C4 File Offset: 0x000E59C4
		private void select_tableau()
		{
			this.radGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select gamme_ressources_fonction.id, id_fonction, fonction_intervenant.designation, nbre_requis, min_planif, type_cout from gamme_ressources_fonction inner join fonction_intervenant on gamme_ressources_fonction.id_fonction = fonction_intervenant.id where id_gamme = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_gamme_operatoire.id_gamme;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}
	}
}
