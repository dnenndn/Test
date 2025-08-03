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
	// Token: 0x020000D0 RID: 208
	public partial class ot_ressources_outillage : Form
	{
		// Token: 0x06000955 RID: 2389 RVA: 0x001816A0 File Offset: 0x0017F8A0
		public ot_ressources_outillage()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_ressources_outillage.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_ressources_outillage.select_changee);
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0018170B File Offset: 0x0017F90B
		private void ot_ressources_outillage_Load(object sender, EventArgs e)
		{
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radTimePicker1.Value = new DateTime?(DateTime.Now);
			this.select_type_outil();
			this.select_tableau();
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00181744 File Offset: 0x0017F944
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

		// Token: 0x06000958 RID: 2392 RVA: 0x001817C8 File Offset: 0x0017F9C8
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

		// Token: 0x06000959 RID: 2393 RVA: 0x001818CC File Offset: 0x0017FACC
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 4;
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "delete ot_ressources_outil where id = @i";
					int num = Convert.ToInt32(this.radGridView3.Rows[e.RowIndex].Cells[0].Value);
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = num;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					this.select_type_outil();
					this.select_tableau();
				}
			}
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x001819B0 File Offset: 0x0017FBB0
		private void select_tableau()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select ot_ressources_outil.id, tab_type.designation, date_sh, quantite from ot_ressources_outil inner join tab_type on ot_ressources_outil.id_type = tab_type.id where id_ot = @i";
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
						dataTable.Rows[i].ItemArray[3].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00181AF8 File Offset: 0x0017FCF8
		private void select_type_outil()
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation from tab_type where id not in (select id_type from ot_ressources_outil where id_ot = @i) order by designation";
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
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x00181C04 File Offset: 0x0017FE04
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDateTimePicker1.Text != "";
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.isnumeric(this.TextBox1.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToInt32(this.TextBox1.Text) > 0;
					if (flag3)
					{
						bd bd = new bd();
						int hour = Convert.ToInt32(fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 2));
						int minute = Convert.ToInt32(fonction.Mid(this.radTimePicker1.Value.ToString(), 15, 2));
						DateTime dateTime = new DateTime(this.radDateTimePicker1.Value.Year, this.radDateTimePicker1.Value.Month, this.radDateTimePicker1.Value.Day, hour, minute, 0);
						string cmdText = "insert into ot_ressources_outil (id_type, id_ot, date_sh, quantite) values (@v1, @v2, @v3, @v4)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag.ToString();
						sqlCommand.Parameters.Add("@v2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand.Parameters.Add("@v3", SqlDbType.DateTime).Value = dateTime;
						sqlCommand.Parameters.Add("@v4", SqlDbType.Int).Value = this.TextBox1.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.select_type_outil();
						this.select_tableau();
						this.TextBox1.Clear();
						MessageBox.Show("Ajout avec succés");
					}
					else
					{
						MessageBox.Show("Erreur : La quantité doit être un entier strictement positif ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : La quantité doit être un entier strictement positif ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Veuillez choisir la famille de l'outillage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
