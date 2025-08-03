using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200008E RID: 142
	public partial class liste_intervenant : Form
	{
		// Token: 0x060006A1 RID: 1697 RVA: 0x00120834 File Offset: 0x0011EA34
		public liste_intervenant()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x001208AA File Offset: 0x0011EAAA
		private void liste_intervenant_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x001208B4 File Offset: 0x0011EAB4
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 5;
			string cmdText = "select intervenant.id, nom, taux_horaire ,fonction_intervenant.designation, type_cout,chef_equipe from intervenant inner join fonction_intervenant on intervenant.id_fonction = fonction_intervenant.id where deleted = @d";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "Non";
					bool flag2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[5]) == 1;
					if (flag2)
					{
						text = "Oui";
					}
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[2]).ToString("0.000"),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						text,
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			bool flag3 = this.radGridView1.Rows.Count != 0;
			if (flag3)
			{
				this.radGridView1.MasterTemplate.MoveToFirstPage();
				this.radGridView1.Rows[0].IsCurrent = true;
			}
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00120B1C File Offset: 0x0011ED1C
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update intervenant set deleted = @d where id = @a";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = value;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau();
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag5)
					{
						liste_intervenant.id_modifier = value;
						this.select_fonction();
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
						this.radDropDownList6.Text = this.radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
						string a = this.radGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
						string a2 = this.radGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
						bool flag6 = a == "Interne";
						if (flag6)
						{
							this.radRadioButton1.IsChecked = true;
						}
						else
						{
							this.radRadioButton2.IsChecked = true;
						}
						bool flag7 = a2 == "Non";
						if (flag7)
						{
							this.radRadioButton4.IsChecked = true;
						}
						else
						{
							this.radRadioButton3.IsChecked = true;
						}
						int selectedIndex = 0;
						for (int i = 0; i < this.radDropDownList6.Items.Count; i++)
						{
							bool flag8 = this.radDropDownList6.Items[i].ToString() == this.radDropDownList6.Text;
							if (flag8)
							{
								selectedIndex = i;
							}
						}
						this.radDropDownList6.SelectedIndex = selectedIndex;
					}
				}
			}
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00120E44 File Offset: 0x0011F044
		private void select_fonction()
		{
			this.radDropDownList6.Items.Clear();
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
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList6.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00120F30 File Offset: 0x0011F130
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.is_reel(this.TextBox2.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToDouble(this.TextBox2.Text) > 0.0;
					if (flag3)
					{
						string cmdText = "select id from intervenant where nom = @i1 and id <> @a";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = liste_intervenant.id_modifier;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count == 0;
						if (flag4)
						{
							string value = "Interne";
							int num = 0;
							bool isChecked = this.radRadioButton2.IsChecked;
							if (isChecked)
							{
								value = "Externe";
							}
							bool isChecked2 = this.radRadioButton3.IsChecked;
							if (isChecked2)
							{
								num = 1;
							}
							bool flag5 = this.radDropDownList6.Text != "";
							if (flag5)
							{
								string cmdText2 = "update intervenant set nom = @i1, taux_horaire = @i2, id_fonction = @i3, type_cout = @i5, chef_equipe = @i6 where id = @i";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
								sqlCommand2.Parameters.Add("@i2", SqlDbType.Real).Value = this.TextBox2.Text;
								sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
								sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = liste_intervenant.id_modifier;
								sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = value;
								sqlCommand2.Parameters.Add("@i6", SqlDbType.Int).Value = num;
								bd.ouverture_bd(bd.cnn);
								sqlCommand2.ExecuteNonQuery();
								bd.cnn.Close();
								MessageBox.Show("Modification avec succés avec succés");
								this.TextBox1.Clear();
								this.TextBox2.Clear();
								this.select_fonction();
								this.remplissage_tableau();
							}
						}
						else
						{
							MessageBox.Show("Erreur : L'intervenant est déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Taux horaire doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Taux horaire doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x040008DF RID: 2271
		private static string id_modifier;
	}
}
