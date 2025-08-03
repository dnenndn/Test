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
	// Token: 0x0200007A RID: 122
	public partial class gamme_outillage : Form
	{
		// Token: 0x060005A0 RID: 1440 RVA: 0x000EC1D8 File Offset: 0x000EA3D8
		public gamme_outillage()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(gamme_outillage.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(gamme_outillage.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x000EC244 File Offset: 0x000EA444
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 4;
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "delete gamme_ressources_outillage where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					this.select_tableau();
				}
			}
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x000EC318 File Offset: 0x000EA518
		private void select_type_outil()
		{
			this.radDropDownList3.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation from tab_type order by designation";
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
					this.radDropDownList3.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList3.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x000EC422 File Offset: 0x000EA622
		private void gamme_outillage_Load(object sender, EventArgs e)
		{
			this.select_tableau();
			this.select_type_outil();
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x000EC434 File Offset: 0x000EA634
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

		// Token: 0x060005A5 RID: 1445 RVA: 0x000EC4B8 File Offset: 0x000EA6B8
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

		// Token: 0x060005A6 RID: 1446 RVA: 0x000EC5BC File Offset: 0x000EA7BC
		private void select_tableau()
		{
			this.radGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select gamme_ressources_outillage.id, id_type, tab_type.designation, quantite from gamme_ressources_outillage inner join tab_type on gamme_ressources_outillage.id_type = tab_type.id where id_gamme = @i";
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
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x000EC704 File Offset: 0x000EA904
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList3.Text != "";
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.isnumeric(this.guna2TextBox4.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToInt32(this.guna2TextBox4.Text) > 0;
					if (flag3)
					{
						int num = 0;
						for (int i = 0; i < this.radGridView1.Rows.Count; i++)
						{
							bool flag4 = this.radGridView1.Rows[i].Cells[1].Value.ToString() == this.radDropDownList3.SelectedItem.Tag.ToString();
							if (flag4)
							{
								num = 1;
							}
						}
						bool flag5 = num == 0;
						if (flag5)
						{
							bd bd = new bd();
							string cmdText = "insert into gamme_ressources_outillage (id_type, id_gamme, quantite) values (@i1, @i2, @i3)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList3.SelectedItem.Tag.ToString();
							sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = liste_gamme_operatoire.id_gamme;
							sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = this.guna2TextBox4.Text;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.select_tableau();
						}
						else
						{
							MessageBox.Show("Erreur :La Famille d'outillage est déja ajoutée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur :La quantité doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur :La quantité doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Il faut choisir la famille d'outillage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
