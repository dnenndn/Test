using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x02000015 RID: 21
	public partial class app_gerer_planning : Form
	{
		// Token: 0x06000129 RID: 297 RVA: 0x000392B4 File Offset: 0x000374B4
		public app_gerer_planning()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(app_gerer_planning.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(app_gerer_planning.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0003931F File Offset: 0x0003751F
		private void app_gerer_planning_Load(object sender, EventArgs e)
		{
			this.select_type();
			this.update_ac();
			this.select_reapprovisionnement();
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00039338 File Offset: 0x00037538
		private void select_type()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Réapprovisionnement");
			this.radDropDownList1.Items.Add("Recomplètement");
			this.radDropDownList1.Text = "Réapprovisionnement";
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00039394 File Offset: 0x00037594
		private void select_reapprovisionnement()
		{
			this.radGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select ac_reapprovisionnement.id, article.code_article, article.designation, ac_reapprovisionnement.qt, delai, date_debut, heure_debut, reccurence,date_limite, periode, arr from ac_reapprovisionnement inner join article on ac_reapprovisionnement.id_article = article.id";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "";
					int num = Convert.ToInt32(dataTable.Rows[i].ItemArray[7]);
					string text2 = "infinie";
					bool flag2 = num == 2;
					if (flag2)
					{
						text = dataTable.Rows[i].ItemArray[8].ToString().Substring(0, 9);
						text2 = "limité";
					}
					int num2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[10]);
					bool flag3 = num2 == 0;
					if (flag3)
					{
						GridViewRowCollection rows = this.radGridView1.Rows;
						object[] array = new object[13];
						array[0] = dataTable.Rows[i].ItemArray[0];
						array[1] = dataTable.Rows[i].ItemArray[1];
						array[2] = dataTable.Rows[i].ItemArray[2];
						array[3] = dataTable.Rows[i].ItemArray[3];
						array[4] = dataTable.Rows[i].ItemArray[5].ToString().Substring(0, 9);
						array[5] = dataTable.Rows[i].ItemArray[6];
						int num3 = 6;
						object obj = dataTable.Rows[i].ItemArray[4];
						string str = (obj != null) ? obj.ToString() : null;
						string str2 = " ";
						object obj2 = dataTable.Rows[i].ItemArray[9];
						array[num3] = str + str2 + ((obj2 != null) ? obj2.ToString() : null);
						array[7] = text2;
						array[8] = text;
						array[9] = Resources.icons8_arrêter_96;
						array[10] = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
						array[11] = Resources.icons8_supprimer_pour_toujours_100__4_;
						array[12] = num2;
						rows.Add(array);
					}
					else
					{
						GridViewRowCollection rows2 = this.radGridView1.Rows;
						object[] array2 = new object[13];
						array2[0] = dataTable.Rows[i].ItemArray[0];
						array2[1] = dataTable.Rows[i].ItemArray[1];
						array2[2] = dataTable.Rows[i].ItemArray[2];
						array2[3] = dataTable.Rows[i].ItemArray[3];
						array2[4] = dataTable.Rows[i].ItemArray[5].ToString().Substring(0, 9);
						array2[5] = dataTable.Rows[i].ItemArray[6];
						int num4 = 6;
						object obj3 = dataTable.Rows[i].ItemArray[4];
						string str3 = (obj3 != null) ? obj3.ToString() : null;
						string str4 = " ";
						object obj4 = dataTable.Rows[i].ItemArray[9];
						array2[num4] = str3 + str4 + ((obj4 != null) ? obj4.ToString() : null);
						array2[7] = text2;
						array2[8] = text;
						array2[9] = Resources.icons8_jouer_52;
						array2[10] = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
						array2[11] = Resources.icons8_supprimer_pour_toujours_100__4_;
						array2[12] = num2;
						rows2.Add(array2);
					}
				}
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00039728 File Offset: 0x00037928
		private void select_recompletement()
		{
			this.radGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select ac_recompletement.id, article.code_article, article.designation, delai,delai, date_debut, heure_debut, reccurence,date_limite, periode, arr from ac_recompletement inner join article on ac_recompletement.id_article = article.id";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "";
					int num = Convert.ToInt32(dataTable.Rows[i].ItemArray[7]);
					string text2 = "infinie";
					bool flag2 = num == 2;
					if (flag2)
					{
						text = dataTable.Rows[i].ItemArray[8].ToString().Substring(0, 9);
						text2 = "limité";
					}
					int num2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[10]);
					bool flag3 = num2 == 0;
					if (flag3)
					{
						GridViewRowCollection rows = this.radGridView1.Rows;
						object[] array = new object[13];
						array[0] = dataTable.Rows[i].ItemArray[0];
						array[1] = dataTable.Rows[i].ItemArray[1];
						array[2] = dataTable.Rows[i].ItemArray[2];
						array[3] = "-";
						array[4] = dataTable.Rows[i].ItemArray[5].ToString().Substring(0, 9);
						array[5] = dataTable.Rows[i].ItemArray[6];
						int num3 = 6;
						object obj = dataTable.Rows[i].ItemArray[4];
						string str = (obj != null) ? obj.ToString() : null;
						string str2 = " ";
						object obj2 = dataTable.Rows[i].ItemArray[9];
						array[num3] = str + str2 + ((obj2 != null) ? obj2.ToString() : null);
						array[7] = text2;
						array[8] = text;
						array[9] = Resources.icons8_arrêter_96;
						array[10] = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
						array[11] = Resources.icons8_supprimer_pour_toujours_100__4_;
						array[12] = num2;
						rows.Add(array);
					}
					else
					{
						GridViewRowCollection rows2 = this.radGridView1.Rows;
						object[] array2 = new object[13];
						array2[0] = dataTable.Rows[i].ItemArray[0];
						array2[1] = dataTable.Rows[i].ItemArray[1];
						array2[2] = dataTable.Rows[i].ItemArray[2];
						array2[3] = "-";
						array2[4] = dataTable.Rows[i].ItemArray[5].ToString().Substring(0, 9);
						array2[5] = dataTable.Rows[i].ItemArray[6];
						int num4 = 6;
						object obj3 = dataTable.Rows[i].ItemArray[4];
						string str3 = (obj3 != null) ? obj3.ToString() : null;
						string str4 = " ";
						object obj4 = dataTable.Rows[i].ItemArray[9];
						array2[num4] = str3 + str4 + ((obj4 != null) ? obj4.ToString() : null);
						array2[7] = text2;
						array2[8] = text;
						array2[9] = Resources.icons8_jouer_52;
						array2[10] = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
						array2[11] = Resources.icons8_supprimer_pour_toujours_100__4_;
						array2[12] = num2;
						rows2.Add(array2);
					}
				}
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00039A9C File Offset: 0x00037C9C
		private void update_ac()
		{
			bd bd = new bd();
			string cmdText = "update ac_reapprovisionnement set arr = @d";
			string cmdText2 = "update ac_recompletement set arr = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			sqlCommand2.ExecuteNonQuery();
			bd.cnn.Close();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00039B3C File Offset: 0x00037D3C
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

		// Token: 0x06000130 RID: 304 RVA: 0x00039BC0 File Offset: 0x00037DC0
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

		// Token: 0x06000131 RID: 305 RVA: 0x00039CC4 File Offset: 0x00037EC4
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text == "Réapprovisionnement";
			if (flag)
			{
				this.select_reapprovisionnement();
			}
			else
			{
				this.select_recompletement();
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00039D00 File Offset: 0x00037F00
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex >= 0 && e.ColumnIndex == 9;
				if (flag2)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					bd bd = new bd();
					bool flag3 = this.radDropDownList1.Text == "Réapprovisionnement";
					if (flag3)
					{
						bool flag4 = this.radGridView1.Rows[e.RowIndex].Cells[12].Value.ToString() == "0";
						if (flag4)
						{
							DialogResult dialogResult = MessageBox.Show("Vous voulez Arrêter cette Planification ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							bool flag5 = dialogResult == DialogResult.Yes;
							if (flag5)
							{
								string cmdText = "update ac_reapprovisionnement set arr = @d where id = @i";
								SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
								sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
								sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
								bd.ouverture_bd(bd.cnn);
								sqlCommand.ExecuteNonQuery();
								bd.cnn.Close();
								this.select_reapprovisionnement();
							}
						}
						else
						{
							DialogResult dialogResult2 = MessageBox.Show("Vous voulez Démarrer cette Planification ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							bool flag6 = dialogResult2 == DialogResult.Yes;
							if (flag6)
							{
								string cmdText2 = "update ac_reapprovisionnement set arr = @d where id = @i";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								bd.ouverture_bd(bd.cnn);
								sqlCommand2.ExecuteNonQuery();
								bd.cnn.Close();
								this.select_reapprovisionnement();
							}
						}
					}
					else
					{
						bool flag7 = this.radGridView1.Rows[e.RowIndex].Cells[12].Value.ToString() == "0";
						if (flag7)
						{
							DialogResult dialogResult3 = MessageBox.Show("Vous voulez Arrêter cette Planification ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							bool flag8 = dialogResult3 == DialogResult.Yes;
							if (flag8)
							{
								string cmdText3 = "update ac_recompletement set arr = @d where id = @i";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 1;
								bd.ouverture_bd(bd.cnn);
								sqlCommand3.ExecuteNonQuery();
								bd.cnn.Close();
								this.select_recompletement();
							}
						}
						else
						{
							DialogResult dialogResult4 = MessageBox.Show("Vous voulez Démarrer cette Planification ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							bool flag9 = dialogResult4 == DialogResult.Yes;
							if (flag9)
							{
								string cmdText4 = "update ac_recompletement set arr = @d where id = @i";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
								sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value;
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								bd.ouverture_bd(bd.cnn);
								sqlCommand4.ExecuteNonQuery();
								bd.cnn.Close();
								this.select_recompletement();
							}
						}
					}
				}
				bool flag10 = e.RowIndex >= 0 && e.ColumnIndex == 11;
				if (flag10)
				{
					string value2 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					bd bd2 = new bd();
					bool flag11 = this.radDropDownList1.Text == "Réapprovisionnement";
					if (flag11)
					{
						DialogResult dialogResult5 = MessageBox.Show("Vous voulez Supprimer cette Planification ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag12 = dialogResult5 == DialogResult.Yes;
						if (flag12)
						{
							string cmdText5 = "delete ac_reapprovisionnement where id = @i";
							string cmdText6 = "delete ac_reapprovisionnement_ech where id_rep = @i";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value2;
							sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value2;
							bd2.ouverture_bd(bd2.cnn);
							sqlCommand5.ExecuteNonQuery();
							sqlCommand6.ExecuteNonQuery();
							bd2.cnn.Close();
							this.select_reapprovisionnement();
						}
					}
					else
					{
						DialogResult dialogResult6 = MessageBox.Show("Vous voulez Supprimer cette Planification ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag13 = dialogResult6 == DialogResult.Yes;
						if (flag13)
						{
							string cmdText7 = "delete ac_recompletement where id = @i";
							string cmdText8 = "delete ac_recompletement_ech where id_rep = @i";
							SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd2.cnn);
							SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd2.cnn);
							sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = value2;
							sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = value2;
							bd2.ouverture_bd(bd2.cnn);
							sqlCommand7.ExecuteNonQuery();
							sqlCommand8.ExecuteNonQuery();
							bd2.cnn.Close();
							this.select_recompletement();
						}
					}
				}
			}
		}
	}
}
