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
	// Token: 0x020000D1 RID: 209
	public partial class ot_ressources_pdr : Form
	{
		// Token: 0x0600095F RID: 2399 RVA: 0x00182B1C File Offset: 0x00180D1C
		public ot_ressources_pdr()
		{
			this.InitializeComponent();
			ot_ressources_pdr.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_ressources_pdr.select_change);
			ot_ressources_pdr.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_ressources_pdr.select_changee);
			ot_ressources_pdr.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.panel1.Visible = false;
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00182B98 File Offset: 0x00180D98
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

		// Token: 0x06000961 RID: 2401 RVA: 0x00182C1C File Offset: 0x00180E1C
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

		// Token: 0x06000962 RID: 2402 RVA: 0x00182D20 File Offset: 0x00180F20
		public static void select_pdr()
		{
			bd bd = new bd();
			ot_ressources_pdr.radGridView3.Rows.Clear();
			string cmdText = "select ot_ressources_pdr.id, code_article, reference, article.designation, quantite, parametre_unite_article.designation, date_sh from ot_ressources_pdr inner join article on ot_ressources_pdr.id_article = article.id inner join tableau_article_unite on article.id = tableau_article_unite.id_article inner join parametre_unite_article on tableau_article_unite.id_unite = parametre_unite_article.id where id_ot = @i";
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
					ot_ressources_pdr.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x00182EC4 File Offset: 0x001810C4
		private void ot_ressources_pdr_Load(object sender, EventArgs e)
		{
			ot_ressources_pdr.select_pdr();
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x00182ED0 File Offset: 0x001810D0
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 8;
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "delete ot_ressources_pdr where id = @i";
					int num = Convert.ToInt32(ot_ressources_pdr.radGridView3.Rows[e.RowIndex].Cells[0].Value);
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = num;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					ot_ressources_pdr.select_pdr();
				}
			}
			bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
			if (flag3)
			{
				this.panel1.Show();
				this.id_modifier = Convert.ToInt32(ot_ressources_pdr.radGridView3.Rows[e.RowIndex].Cells[0].Value);
				this.TextBox1.Text = ot_ressources_pdr.radGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
				this.radDateTimePicker1.Value = Convert.ToDateTime(fonction.Mid(ot_ressources_pdr.radGridView3.Rows[e.RowIndex].Cells[1].Value.ToString(), 1, 10));
				this.radTimePicker1.Value = new DateTime?(Convert.ToDateTime(fonction.Mid(ot_ressources_pdr.radGridView3.Rows[e.RowIndex].Cells[1].Value.ToString(), 12, 5)));
			}
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x001830C7 File Offset: 0x001812C7
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x001830D8 File Offset: 0x001812D8
		private void radButton1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(this.TextBox1.Text);
			if (flag)
			{
				bool flag2 = Convert.ToDouble(this.TextBox1.Text) > 0.0;
				if (flag2)
				{
					bd bd = new bd();
					int hour = Convert.ToInt32(fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 2));
					int minute = Convert.ToInt32(fonction.Mid(this.radTimePicker1.Value.ToString(), 15, 2));
					DateTime dateTime = new DateTime(this.radDateTimePicker1.Value.Year, this.radDateTimePicker1.Value.Month, this.radDateTimePicker1.Value.Day, hour, minute, 0);
					string cmdText = "update ot_ressources_pdr set quantite = @v, date_sh = @d where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@v", SqlDbType.Real).Value = Convert.ToDouble(this.TextBox1.Text);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_modifier;
					sqlCommand.Parameters.Add("@d", SqlDbType.DateTime).Value = dateTime;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Modification avec succés");
					ot_ressources_pdr.select_pdr();
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

		// Token: 0x06000967 RID: 2407 RVA: 0x001832B0 File Offset: 0x001814B0
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			ot_liste_article_reservation ot_liste_article_reservation = new ot_liste_article_reservation();
			ot_liste_article_reservation.Show();
		}

		// Token: 0x04000C72 RID: 3186
		private int id_modifier = 0;
	}
}
