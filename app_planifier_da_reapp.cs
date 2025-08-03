using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x02000016 RID: 22
	public partial class app_planifier_da_reapp : Form
	{
		// Token: 0x06000135 RID: 309 RVA: 0x0003AD0A File Offset: 0x00038F0A
		public app_planifier_da_reapp()
		{
			this.InitializeComponent();
			this.select_article();
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0003AD2C File Offset: 0x00038F2C
		private void app_planifier_da_reapp_Load(object sender, EventArgs e)
		{
			this.select_periode();
			this.label2.Text = "";
			this.panel1.Visible = false;
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radDateTimePicker2.Value = DateTime.Today;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0003AD84 File Offset: 0x00038F84
		private void select_periode()
		{
			this.guna2ComboBox1.Items.Clear();
			this.guna2ComboBox1.Items.Add("Jour");
			this.guna2ComboBox1.Items.Add("Mois");
			this.guna2ComboBox1.Items.Add("Année");
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0003ADE8 File Offset: 0x00038FE8
		private void select_article()
		{
			bd bd = new bd();
			string cmdText = "select id, designation from article where deleted = @d  order by designation";
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
					this.radDropDownList2.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList2.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0003AEE0 File Offset: 0x000390E0
		private void radDropDownList2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.label2.Text = "";
			bd bd = new bd();
			string cmdText = "select parametre_unite_article.designation from article inner join tableau_article_unite on article.id = tableau_article_unite.id_article inner join parametre_unite_article on tableau_article_unite.id_unite = parametre_unite_article.id where article.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radDropDownList2.SelectedItem.Tag;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.label2.Text = dataTable.Rows[0].ItemArray[0].ToString();
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0003AF94 File Offset: 0x00039194
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				this.panel1.Visible = true;
			}
			else
			{
				this.panel1.Visible = false;
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0003AFD4 File Offset: 0x000391D4
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList2.Text != "";
			if (flag)
			{
				bool flag2 = this.guna2ComboBox1.Text != "";
				if (flag2)
				{
					fonction fonction = new fonction();
					bool flag3 = fonction.is_reel(this.TextBox4.Text);
					if (flag3)
					{
						bool flag4 = Convert.ToDouble(this.TextBox4.Text) > 0.0;
						if (flag4)
						{
							bool flag5 = fonction.isnumeric(this.guna2TextBox1.Text);
							if (flag5)
							{
								bool flag6 = Convert.ToInt32(this.guna2TextBox1.Text) > 0;
								if (flag6)
								{
									int num = 1;
									int num2 = 1;
									bool isChecked = this.radRadioButton2.IsChecked;
									if (isChecked)
									{
										num2 = 2;
										bool flag7 = this.radDateTimePicker1.Value > this.radDateTimePicker2.Value;
										if (flag7)
										{
											num = 0;
										}
									}
									bool flag8 = num == 1;
									if (flag8)
									{
										bd bd = new bd();
										string cmdText = "insert into ac_reapprovisionnement (id_article, qt, delai, date_debut, heure_debut, reccurence, date_limite, periode, arr) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9)";
										SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
										sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList2.SelectedItem.Tag;
										sqlCommand.Parameters.Add("@i2", SqlDbType.Real).Value = this.TextBox4.Text;
										sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = this.guna2TextBox1.Text;
										sqlCommand.Parameters.Add("@i4", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
										sqlCommand.Parameters.Add("@i5", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 5);
										sqlCommand.Parameters.Add("@i6", SqlDbType.Int).Value = num2;
										sqlCommand.Parameters.Add("@i7", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
										sqlCommand.Parameters.Add("@i8", SqlDbType.VarChar).Value = this.guna2ComboBox1.Text;
										sqlCommand.Parameters.Add("@i9", SqlDbType.VarChar).Value = 0;
										bd.ouverture_bd(bd.cnn);
										sqlCommand.ExecuteNonQuery();
										bd.cnn.Close();
										MessageBox.Show("Enregistrement avec succés");
										this.TextBox4.Clear();
										this.guna2TextBox1.Clear();
									}
									else
									{
										MessageBox.Show("Erreur : La Date Limite doit être supérieure ou égale à la date de début", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
								}
								else
								{
									MessageBox.Show("Erreur : Le Délai doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							else
							{
								MessageBox.Show("Erreur : Le Délai doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur : La quantité doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : La quantité doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Il faut Choisir La Période", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Il faut Choisir Un article", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
