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

namespace GMAO
{
	// Token: 0x02000017 RID: 23
	public partial class app_planifier_da_recomp : Form
	{
		// Token: 0x0600013E RID: 318 RVA: 0x0003D443 File Offset: 0x0003B643
		public app_planifier_da_recomp()
		{
			this.InitializeComponent();
			this.select_article();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0003D464 File Offset: 0x0003B664
		private void app_planifier_da_recomp_Load(object sender, EventArgs e)
		{
			this.select_periode();
			this.panel1.Visible = false;
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radDateTimePicker2.Value = DateTime.Today;
			this.guna2ComboBox1.Text = "Jour";
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0003D4BC File Offset: 0x0003B6BC
		private void select_periode()
		{
			this.guna2ComboBox1.Items.Clear();
			this.guna2ComboBox1.Items.Add("Jour");
			this.guna2ComboBox1.Items.Add("Mois");
			this.guna2ComboBox1.Items.Add("Année");
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0003D520 File Offset: 0x0003B720
		private void select_article()
		{
			bd bd = new bd();
			string cmdText = "select id, designation from article where deleted = @d and methode_gestion = @m order by designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@m", SqlDbType.VarChar).Value = "Recomplètement";
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

		// Token: 0x06000142 RID: 322 RVA: 0x0003D634 File Offset: 0x0003B834
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

		// Token: 0x06000143 RID: 323 RVA: 0x0003D674 File Offset: 0x0003B874
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList2.Text != "";
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.isnumeric(this.guna2TextBox1.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToInt32(this.guna2TextBox1.Text) > 0;
					if (flag3)
					{
						int num = 1;
						int num2 = 1;
						bool isChecked = this.radRadioButton2.IsChecked;
						if (isChecked)
						{
							num2 = 2;
							bool flag4 = this.radDateTimePicker1.Value > this.radDateTimePicker2.Value;
							if (flag4)
							{
								num = 0;
							}
						}
						bool flag5 = num == 1;
						if (flag5)
						{
							bd bd = new bd();
							string cmdText = "insert into ac_recompletement (id_article, delai, date_debut, heure_debut, reccurence, date_limite, periode, arr) values (@i1, @i3, @i4, @i5, @i6, @i7, @i8, @i9)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList2.SelectedItem.Tag;
							sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = this.guna2TextBox1.Text;
							sqlCommand.Parameters.Add("@i4", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
							sqlCommand.Parameters.Add("@i5", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 5);
							sqlCommand.Parameters.Add("@i6", SqlDbType.Int).Value = num2;
							sqlCommand.Parameters.Add("@i7", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
							sqlCommand.Parameters.Add("@i8", SqlDbType.VarChar).Value = this.guna2ComboBox1.Text;
							sqlCommand.Parameters.Add("@i9", SqlDbType.Int).Value = 0;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Enregistrement avec succés");
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
				MessageBox.Show("Erreur : Il faut Choisir Un article", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0003D91C File Offset: 0x0003BB1C
		private int NombreDeMois(DateTime DateDebut, DateTime DateFin)
		{
			int num = 0;
			bool flag = DateDebut.Year != DateFin.Year;
			if (flag)
			{
				for (int i = DateDebut.Month; i <= 12; i++)
				{
					num++;
				}
				num += (DateFin.Year - (DateDebut.Year + 1)) * 12;
				for (int j = 1; j <= DateFin.Month; j++)
				{
					num++;
				}
			}
			else
			{
				for (int k = DateDebut.Month; k <= DateFin.Month; k++)
				{
					num++;
				}
			}
			return num;
		}
	}
}
