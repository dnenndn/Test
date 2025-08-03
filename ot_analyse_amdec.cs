using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000A6 RID: 166
	public partial class ot_analyse_amdec : Form
	{
		// Token: 0x060007A2 RID: 1954 RVA: 0x001518F0 File Offset: 0x0014FAF0
		public ot_analyse_amdec()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_analyse_amdec.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_analyse_amdec.select_changee);
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00151944 File Offset: 0x0014FB44
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

		// Token: 0x060007A4 RID: 1956 RVA: 0x001519C8 File Offset: 0x0014FBC8
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

		// Token: 0x060007A5 RID: 1957 RVA: 0x00151ACB File Offset: 0x0014FCCB
		private void ot_analyse_amdec_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x00151AD0 File Offset: 0x0014FCD0
		private void radButton2_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			this.radGridView3.Rows.Clear();
			bool flag = fonction.is_reel(this.radTextBox1.Text) & fonction.is_reel(this.radTextBox2.Text) & fonction.is_reel(this.radTextBox4.Text) & fonction.is_reel(this.radTextBox10.Text) & fonction.is_reel(this.radTextBox11.Text) & fonction.is_reel(this.radTextBox12.Text);
			if (flag)
			{
				double num = Convert.ToDouble(this.radTextBox1.Text);
				double num2 = Convert.ToDouble(this.radTextBox2.Text);
				double num3 = Convert.ToDouble(this.radTextBox4.Text);
				bool flag2 = num < num2 & num2 < num3;
				if (flag2)
				{
					double num4 = Convert.ToDouble(this.radTextBox10.Text);
					double num5 = Convert.ToDouble(this.radTextBox11.Text);
					double num6 = Convert.ToDouble(this.radTextBox12.Text);
					bool flag3 = num4 < num5 & num5 < num6;
					if (flag3)
					{
						bd bd = new bd();
						string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
						string cmdText = "select ot_diagnostic_detection.id_defaillance,type_d ,parametre_anomalie.anomalie, id_parent, count(ordre_travail.id), avg(datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0) from ot_diagnostic_detection inner join parametre_anomalie on ot_diagnostic_detection.id_defaillance = parametre_anomalie.id inner join relation_anomalie on parametre_anomalie.id = relation_anomalie.id_anomalie inner join ordre_travail on ot_diagnostic_detection.id_ot = ordre_travail.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @st group by ot_diagnostic_detection.id_defaillance ,parametre_anomalie.anomalie, id_parent,type_d ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
						sqlCommand.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
						sqlCommand.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count != 0;
						if (flag4)
						{
							for (int i = 0; i < dataTable.Rows.Count; i++)
							{
								double v = Convert.ToDouble(dataTable.Rows[i].ItemArray[4]);
								double v2 = Convert.ToDouble(dataTable.Rows[i].ItemArray[5]);
								int num7 = this.retourner_valeur(v, num, num2, num3);
								int num8 = this.retourner_valeur(v2, num4, num5, num6);
								int num9 = Convert.ToInt32(dataTable.Rows[i].ItemArray[1]);
								int num10 = num7 * num8 * num9;
								string text = this.retourner_parent(dataTable.Rows[i].ItemArray[4].ToString());
								string text2 = dataTable.Rows[i].ItemArray[2].ToString();
								this.radGridView3.Rows.Add(new object[]
								{
									text,
									text2,
									num7,
									num8,
									num9,
									num10
								});
							}
						}
					}
				}
			}
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00151DFC File Offset: 0x0014FFFC
		private int retourner_valeur(double v, double c1, double c2, double c3)
		{
			bool flag = v <= c1;
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				bool flag2 = v > c1 & v <= c2;
				if (flag2)
				{
					result = 2;
				}
				else
				{
					bool flag3 = v > c2 & v <= c3;
					if (flag3)
					{
						result = 3;
					}
					else
					{
						result = 4;
					}
				}
			}
			return result;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x00151E58 File Offset: 0x00150058
		private string retourner_parent(string id_def)
		{
			string result = "";
			bd bd = new bd();
			string cmdText = "select anomalie from parametre_anomalie where id = @id_def";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@id_def", SqlDbType.Int).Value = id_def;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				result = dataTable.Rows[0].ItemArray[0].ToString();
			}
			return result;
		}
	}
}
