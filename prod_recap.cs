using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using Telerik.WinControls.UI.Export;

namespace GMAO
{
	// Token: 0x0200011E RID: 286
	public partial class prod_recap : Form
	{
		// Token: 0x06000C96 RID: 3222 RVA: 0x001E8940 File Offset: 0x001E6B40
		public prod_recap()
		{
			this.InitializeComponent();
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x001E89BC File Offset: 0x001E6BBC
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			}
			else
			{
				bool isSelected = e.RowElement.IsSelected;
				if (isSelected)
				{
					e.RowElement.DrawFill = true;
					e.RowElement.GradientStyle = 0;
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

		// Token: 0x06000C98 RID: 3224 RVA: 0x001E8AA0 File Offset: 0x001E6CA0
		private void RadGridView2_ViewCellFormatting(object sender, CellFormattingEventArgs e)
		{
			e.CellElement.BorderBottomWidth = 1f;
			e.CellElement.BorderRightWidth = 1f;
			e.CellElement.BorderLeftWidth = 1f;
			e.CellElement.BorderTopWidth = 1f;
			e.CellElement.BorderRightColor = Color.DimGray;
			e.CellElement.BorderTopColor = Color.DimGray;
			e.CellElement.BorderLeftColor = Color.DimGray;
			e.CellElement.BorderBottomColor = Color.DimGray;
			e.CellElement.BorderBoxStyle = 1;
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x001E8B43 File Offset: 0x001E6D43
		private void prod_recap_Load(object sender, EventArgs e)
		{
			this.select_unite();
			this.filtre_change();
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x001E8B54 File Offset: 0x001E6D54
		private void select_qt_fabrication(RadGridView radGridView2)
		{
			radGridView2.Rows.Clear();
			radGridView2.Columns.Clear();
			radGridView2.AllowAutoSizeColumns = true;
			string cmdText = "select date_rapport,sum(quantite) from prod_rapport_fab_produit inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where  date_rapport between @d1 and @d2 group by date_rapport having sum(quantite) > 0 ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			ColumnGroupsViewDefinition columnGroupsViewDefinition = new ColumnGroupsViewDefinition();
			GridViewTextBoxColumn gridViewTextBoxColumn = new GridViewTextBoxColumn();
			gridViewTextBoxColumn.HeaderText = "Date Rapport";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn.Name = "t_date";
			gridViewTextBoxColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns.Add(gridViewTextBoxColumn);
			GridViewColumnGroup gridViewColumnGroup = new GridViewColumnGroup();
			gridViewColumnGroup.IsPinned = true;
			GridViewColumnGroupRow gridViewColumnGroupRow = new GridViewColumnGroupRow();
			gridViewColumnGroup.Text = "";
			gridViewColumnGroupRow.ColumnNames.Add("t_date");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = Convert.ToString(dataTable.Rows[i].ItemArray[0]).Substring(0, 10);
					radGridView2.Rows.Add(new object[]
					{
						text
					});
				}
			}
			columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup);
			gridViewColumnGroup.Rows.Add(gridViewColumnGroupRow);
			string cmdText2 = "select equipement.designation,sum(quantite), equipement.id from prod_rapport_fab_produit inner join equipement on prod_rapport_fab_produit.id_unite = equipement.id inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where  date_rapport between @d1 and @d2 group by equipement.id, equipement.designation having sum(quantite) > 0 ";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, this.b.cnn);
			sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				int num = 0;
				int num2 = 1;
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					GridViewColumnGroup gridViewColumnGroup2 = new GridViewColumnGroup();
					GridViewColumnGroupRow gridViewColumnGroupRow2 = new GridViewColumnGroupRow();
					gridViewColumnGroup2.Text = dataTable2.Rows[j].ItemArray[0].ToString();
					string cmdText3 = "select id, designation from prod_type_brique";
					SqlCommand selectCommand = new SqlCommand(cmdText3, this.b.cnn);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag3 = dataTable3.Rows.Count != 0;
					if (flag3)
					{
						List<double> list3 = new List<double>();
						for (int k = 0; k < dataTable3.Rows.Count; k++)
						{
							num++;
							GridViewTextBoxColumn gridViewTextBoxColumn2 = new GridViewTextBoxColumn();
							string text2 = num.ToString();
							gridViewTextBoxColumn2.Name = text2;
							gridViewTextBoxColumn2.HeaderTextAlignment = ContentAlignment.MiddleCenter;
							gridViewTextBoxColumn2.HeaderText = dataTable3.Rows[k].ItemArray[1].ToString();
							gridViewTextBoxColumn2.Width = 50;
							radGridView2.Columns.Add(gridViewTextBoxColumn2);
							gridViewColumnGroupRow2.ColumnNames.Add(text2);
						}
						num++;
						GridViewTextBoxColumn gridViewTextBoxColumn3 = new GridViewTextBoxColumn();
						string text3 = num.ToString();
						gridViewTextBoxColumn3.Name = text3;
						gridViewTextBoxColumn3.HeaderTextAlignment = ContentAlignment.MiddleCenter;
						gridViewTextBoxColumn3.HeaderText = "Total";
						gridViewTextBoxColumn3.Width = 70;
						radGridView2.Columns.Add(gridViewTextBoxColumn3);
						gridViewColumnGroupRow2.ColumnNames.Add(text3);
						columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup2);
						gridViewColumnGroup2.Rows.Add(gridViewColumnGroupRow2);
						int num3 = num2;
						for (int l = 0; l < dataTable3.Rows.Count; l++)
						{
							for (int m = 0; m < radGridView2.Rows.Count; m++)
							{
								bool flag4 = l == 0;
								if (flag4)
								{
									list3.Add(0.0);
								}
								bool isChecked = this.radRadioButton2.IsChecked;
								string cmdText4;
								if (isChecked)
								{
									cmdText4 = "select sum(quantite) from prod_rapport_fab_produit inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and id_produit = @i3";
								}
								else
								{
									cmdText4 = "select sum(tonnage) from prod_rapport_fab_produit inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and id_produit = @i3";
								}
								SqlCommand sqlCommand3 = new SqlCommand(cmdText4, this.b.cnn);
								sqlCommand3.Parameters.Add("@i1", SqlDbType.Date).Value = radGridView2.Rows[m].Cells[0].Value.ToString();
								sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[2].ToString();
								sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable3.Rows[l].ItemArray[0].ToString();
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								double num4 = 0.0;
								bool flag5 = dataTable4.Rows.Count != 0;
								if (flag5)
								{
									num4 = Convert.ToDouble(dataTable4.Rows[0].ItemArray[0]);
								}
								list3[m] += num4;
								radGridView2.Rows[m].Cells[num3].Value = Math.Round(num4, 3);
							}
							num3++;
						}
						for (int n = 0; n < radGridView2.Rows.Count; n++)
						{
							radGridView2.Rows[n].Cells[num3].Value = Math.Round(list3[n], 3);
						}
						num3++;
						num2 = num2 + dataTable3.Rows.Count + 1;
					}
				}
			}
			radGridView2.MasterTemplate.ViewDefinition = columnGroupsViewDefinition;
			bool isChecked2 = this.radRadioButton4.IsChecked;
			if (isChecked2)
			{
				this.add_dernier_ligne("Total", radGridView2);
			}
			bool isChecked3 = this.radRadioButton5.IsChecked;
			if (isChecked3)
			{
				this.add_dernier_ligne("Moy", radGridView2);
			}
			bool isChecked4 = this.radRadioButton6.IsChecked;
			if (isChecked4)
			{
				this.add_dernier_ligne("Min", radGridView2);
			}
			bool isChecked5 = this.radRadioButton7.IsChecked;
			if (isChecked5)
			{
				this.add_dernier_ligne("Max", radGridView2);
			}
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x001E9278 File Offset: 0x001E7478
		private void select_qt_four(RadGridView radGridView2)
		{
			radGridView2.Rows.Clear();
			radGridView2.Columns.Clear();
			bool flag = this.radDateTimePicker1.Value <= this.radDateTimePicker2.Value;
			if (flag)
			{
				string cmdText = "select id, designation from prod_type_brique";
				SqlCommand selectCommand = new SqlCommand(cmdText, this.b.cnn);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				radGridView2.AllowAutoSizeColumns = true;
				ColumnGroupsViewDefinition columnGroupsViewDefinition = new ColumnGroupsViewDefinition();
				GridViewTextBoxColumn gridViewTextBoxColumn = new GridViewTextBoxColumn();
				gridViewTextBoxColumn.HeaderText = "Date Rapport";
				gridViewTextBoxColumn.Width = 100;
				gridViewTextBoxColumn.Name = "t_date";
				gridViewTextBoxColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTextBoxColumn.TextAlignment = ContentAlignment.MiddleCenter;
				radGridView2.Columns.Add(gridViewTextBoxColumn);
				GridViewColumnGroup gridViewColumnGroup = new GridViewColumnGroup();
				gridViewColumnGroup.IsPinned = true;
				GridViewColumnGroupRow gridViewColumnGroupRow = new GridViewColumnGroupRow();
				gridViewColumnGroup.Text = "";
				gridViewColumnGroupRow.ColumnNames.Add("t_date");
				DateTime dateTime = this.radDateTimePicker1.Value;
				while (dateTime <= this.radDateTimePicker2.Value)
				{
					string text = Convert.ToString(dateTime).Substring(0, 10);
					radGridView2.Rows.Add(new object[]
					{
						text
					});
					dateTime = dateTime.AddDays(1.0);
				}
				columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup);
				gridViewColumnGroup.Rows.Add(gridViewColumnGroupRow);
				int num = 0;
				int num2 = 1;
				for (int i = 0; i < this.radDropDownList1.Items.Count; i++)
				{
					GridViewColumnGroup gridViewColumnGroup2 = new GridViewColumnGroup();
					GridViewColumnGroupRow gridViewColumnGroupRow2 = new GridViewColumnGroupRow();
					gridViewColumnGroup2.Text = "Entrée " + this.radDropDownList1.Items[i].Text;
					bool flag2 = dataTable.Rows.Count != 0;
					if (flag2)
					{
						List<double> list = new List<double>();
						for (int j = 0; j < dataTable.Rows.Count; j++)
						{
							num++;
							GridViewTextBoxColumn gridViewTextBoxColumn2 = new GridViewTextBoxColumn();
							string text2 = num.ToString();
							gridViewTextBoxColumn2.Name = text2;
							gridViewTextBoxColumn2.HeaderTextAlignment = ContentAlignment.MiddleCenter;
							gridViewTextBoxColumn2.TextAlignment = ContentAlignment.MiddleCenter;
							gridViewTextBoxColumn2.HeaderText = dataTable.Rows[j].ItemArray[1].ToString();
							gridViewTextBoxColumn2.Width = 60;
							radGridView2.Columns.Add(gridViewTextBoxColumn2);
							gridViewColumnGroupRow2.ColumnNames.Add(text2);
						}
						num++;
						GridViewTextBoxColumn gridViewTextBoxColumn3 = new GridViewTextBoxColumn();
						string text3 = num.ToString();
						gridViewTextBoxColumn3.Name = text3;
						gridViewTextBoxColumn3.HeaderTextAlignment = ContentAlignment.MiddleCenter;
						gridViewTextBoxColumn3.HeaderText = "Total";
						gridViewTextBoxColumn3.Width = 70;
						radGridView2.Columns.Add(gridViewTextBoxColumn3);
						gridViewColumnGroupRow2.ColumnNames.Add(text3);
						columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup2);
						gridViewColumnGroup2.Rows.Add(gridViewColumnGroupRow2);
						int num3 = num2;
						for (int k = 0; k < dataTable.Rows.Count; k++)
						{
							for (int l = 0; l < radGridView2.Rows.Count; l++)
							{
								bool flag3 = k == 0;
								if (flag3)
								{
									list.Add(0.0);
								}
								bool isChecked = this.radRadioButton2.IsChecked;
								string cmdText2;
								if (isChecked)
								{
									cmdText2 = "select isnull(sum(quantite), 0) from prod_rapport_four_entre inner join prod_rapport_general on prod_rapport_four_entre.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and id_produit = @i3";
								}
								else
								{
									cmdText2 = "select isnull(sum(tonnage), 0) from prod_rapport_four_entre inner join prod_rapport_general on prod_rapport_four_entre.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and id_produit = @i3";
								}
								SqlCommand sqlCommand = new SqlCommand(cmdText2, this.b.cnn);
								sqlCommand.Parameters.Add("@i1", SqlDbType.Date).Value = radGridView2.Rows[l].Cells[0].Value.ToString();
								sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList1.Items[i].Tag.ToString();
								sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable.Rows[k].ItemArray[0].ToString();
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								double num4 = 0.0;
								bool flag4 = dataTable2.Rows.Count != 0;
								if (flag4)
								{
									num4 = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
								}
								list[l] += num4;
								radGridView2.Rows[l].Cells[num3].Value = Math.Round(num4, 3);
							}
							num3++;
						}
						for (int m = 0; m < radGridView2.Rows.Count; m++)
						{
							radGridView2.Rows[m].Cells[num3].Value = Math.Round(list[m], 3);
						}
						num3++;
					}
					num2 = num2 + dataTable.Rows.Count + 1;
				}
				for (int n = 0; n < this.radDropDownList1.Items.Count; n++)
				{
					GridViewColumnGroup gridViewColumnGroup3 = new GridViewColumnGroup();
					GridViewColumnGroupRow gridViewColumnGroupRow3 = new GridViewColumnGroupRow();
					gridViewColumnGroup3.Text = "Sortie " + this.radDropDownList1.Items[n].Text;
					bool flag5 = dataTable.Rows.Count != 0;
					if (flag5)
					{
						for (int num5 = 0; num5 < dataTable.Rows.Count; num5++)
						{
							num++;
							GridViewTextBoxColumn gridViewTextBoxColumn4 = new GridViewTextBoxColumn();
							string text4 = num.ToString();
							gridViewTextBoxColumn4.Name = text4;
							gridViewTextBoxColumn4.HeaderTextAlignment = ContentAlignment.MiddleCenter;
							gridViewTextBoxColumn4.TextAlignment = ContentAlignment.MiddleCenter;
							gridViewTextBoxColumn4.HeaderText = dataTable.Rows[num5].ItemArray[1].ToString();
							gridViewTextBoxColumn4.Width = 60;
							radGridView2.Columns.Add(gridViewTextBoxColumn4);
							gridViewColumnGroupRow3.ColumnNames.Add(text4);
						}
						num++;
						GridViewTextBoxColumn gridViewTextBoxColumn5 = new GridViewTextBoxColumn();
						string text5 = num.ToString();
						gridViewTextBoxColumn5.Name = text5;
						gridViewTextBoxColumn5.HeaderTextAlignment = ContentAlignment.MiddleCenter;
						gridViewTextBoxColumn5.HeaderText = "Total";
						gridViewTextBoxColumn5.Width = 70;
						radGridView2.Columns.Add(gridViewTextBoxColumn5);
						gridViewColumnGroupRow3.ColumnNames.Add(text5);
					}
					columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup3);
					gridViewColumnGroup3.Rows.Add(gridViewColumnGroupRow3);
					int num6 = num2;
					List<double> list2 = new List<double>();
					for (int num7 = 0; num7 < dataTable.Rows.Count; num7++)
					{
						for (int num8 = 0; num8 < radGridView2.Rows.Count; num8++)
						{
							bool flag6 = num7 == 0;
							if (flag6)
							{
								list2.Add(0.0);
							}
							bool isChecked2 = this.radRadioButton2.IsChecked;
							string cmdText3;
							if (isChecked2)
							{
								cmdText3 = "select isnull(sum(quantite), 0) from prod_rapport_four_sortie inner join prod_rapport_general on prod_rapport_four_sortie.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and id_produit = @i3";
							}
							else
							{
								cmdText3 = "select isnull(sum(tonnage), 0) from prod_rapport_four_sortie inner join prod_rapport_general on prod_rapport_four_sortie.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and id_produit = @i3";
							}
							SqlCommand sqlCommand2 = new SqlCommand(cmdText3, this.b.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Date).Value = radGridView2.Rows[num8].Cells[0].Value.ToString();
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList1.Items[n].Tag.ToString();
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable.Rows[num7].ItemArray[0].ToString();
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand2);
							DataTable dataTable3 = new DataTable();
							sqlDataAdapter3.Fill(dataTable3);
							double num9 = 0.0;
							bool flag7 = dataTable3.Rows.Count != 0;
							if (flag7)
							{
								num9 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[0]);
							}
							list2[num8] += num9;
							radGridView2.Rows[num8].Cells[num6].Value = Math.Round(num9, 3);
						}
						num6++;
					}
					for (int num10 = 0; num10 < radGridView2.Rows.Count; num10++)
					{
						radGridView2.Rows[num10].Cells[num6].Value = Math.Round(list2[num10], 3);
					}
					num6++;
					num2 = num2 + dataTable.Rows.Count + 1;
				}
				GridViewColumnGroup gridViewColumnGroup4 = new GridViewColumnGroup();
				GridViewColumnGroupRow gridViewColumnGroupRow4 = new GridViewColumnGroupRow();
				gridViewColumnGroup4.Text = "Ecart ";
				bool flag8 = dataTable.Rows.Count != 0;
				if (flag8)
				{
					for (int num11 = 0; num11 < dataTable.Rows.Count; num11++)
					{
						num++;
						GridViewTextBoxColumn gridViewTextBoxColumn6 = new GridViewTextBoxColumn();
						string str = num.ToString();
						gridViewTextBoxColumn6.Name = "ec" + str;
						gridViewTextBoxColumn6.HeaderTextAlignment = ContentAlignment.MiddleCenter;
						gridViewTextBoxColumn6.TextAlignment = ContentAlignment.MiddleCenter;
						gridViewTextBoxColumn6.HeaderText = dataTable.Rows[num11].ItemArray[1].ToString();
						gridViewTextBoxColumn6.Width = 60;
						radGridView2.Columns.Add(gridViewTextBoxColumn6);
						gridViewColumnGroupRow4.ColumnNames.Add("ec" + str);
					}
				}
				columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup4);
				gridViewColumnGroup4.Rows.Add(gridViewColumnGroupRow4);
				int num12 = num2;
				for (int num13 = 0; num13 < dataTable.Rows.Count; num13++)
				{
					for (int num14 = 0; num14 < radGridView2.Rows.Count; num14++)
					{
						bool isChecked3 = this.radRadioButton2.IsChecked;
						string cmdText4;
						if (isChecked3)
						{
							cmdText4 = "select isnull(sum(prod_rapport_four_sortie.quantite), 0) - isnull(sum(prod_rapport_four_entre.quantite), 0) from prod_rapport_four_sortie inner join prod_rapport_general on prod_rapport_four_sortie.id_rapport = prod_rapport_general.id inner join prod_rapport_four_entre on prod_rapport_general.id = prod_rapport_four_entre.id_rapport where date_rapport = @i1  and prod_rapport_four_sortie.id_produit = @i3  and prod_rapport_four_entre.id_produit = @i5";
						}
						else
						{
							cmdText4 = "select isnull(sum(prod_rapport_four_sortie.tonnage), 0) - isnull(sum(prod_rapport_four_entre.tonnage), 0) from prod_rapport_four_sortie inner join prod_rapport_general on prod_rapport_four_sortie.id_rapport = prod_rapport_general.id inner join prod_rapport_four_entre on prod_rapport_general.id = prod_rapport_four_entre.id_rapport where date_rapport = @i1  and prod_rapport_four_sortie.id_produit = @i3  and prod_rapport_four_entre.id_produit = @i5";
						}
						SqlCommand sqlCommand3 = new SqlCommand(cmdText4, this.b.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Date).Value = radGridView2.Rows[num14].Cells[0].Value.ToString();
						sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable.Rows[num13].ItemArray[0].ToString();
						sqlCommand3.Parameters.Add("@i5", SqlDbType.Int).Value = dataTable.Rows[num13].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						double value = 0.0;
						bool flag9 = dataTable4.Rows.Count != 0;
						if (flag9)
						{
							value = Convert.ToDouble(dataTable4.Rows[0].ItemArray[0]);
						}
						radGridView2.Rows[num14].Cells[num12].Value = Math.Round(value, 3);
					}
					num12++;
				}
				num2 += dataTable.Rows.Count;
				radGridView2.MasterTemplate.ViewDefinition = columnGroupsViewDefinition;
				bool isChecked4 = this.radRadioButton4.IsChecked;
				if (isChecked4)
				{
					this.add_dernier_ligne("Total", radGridView2);
				}
				bool isChecked5 = this.radRadioButton5.IsChecked;
				if (isChecked5)
				{
					this.add_dernier_ligne("Moy", radGridView2);
				}
				bool isChecked6 = this.radRadioButton6.IsChecked;
				if (isChecked6)
				{
					this.add_dernier_ligne("Min", radGridView2);
				}
				bool isChecked7 = this.radRadioButton7.IsChecked;
				if (isChecked7)
				{
					this.add_dernier_ligne("Max", radGridView2);
				}
			}
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x001E9F83 File Offset: 0x001E8183
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.filtre_change();
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x001E9F8D File Offset: 0x001E818D
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.filtre_change();
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x001E9F98 File Offset: 0x001E8198
		private void add_dernier_ligne(string type, RadGridView radGridView2)
		{
			bool flag = radGridView2.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = type == "Total";
				if (flag2)
				{
					radGridView2.Rows.Add(new object[]
					{
						"Total"
					});
					bool flag3 = radGridView2.Columns.Count > 1;
					if (flag3)
					{
						for (int i = 1; i < radGridView2.Columns.Count; i++)
						{
							double num = 0.0;
							for (int j = 0; j < radGridView2.Rows.Count - 1; j++)
							{
								num += Convert.ToDouble(radGridView2.Rows[j].Cells[i].Value);
							}
							radGridView2.Rows[radGridView2.Rows.Count - 1].Cells[i].Value = num;
						}
					}
				}
				bool flag4 = type == "Moy";
				if (flag4)
				{
					radGridView2.Rows.Add(new object[]
					{
						"Moy"
					});
					bool flag5 = radGridView2.Columns.Count > 1;
					if (flag5)
					{
						for (int k = 1; k < radGridView2.Columns.Count; k++)
						{
							double num2 = 0.0;
							for (int l = 0; l < radGridView2.Rows.Count - 1; l++)
							{
								num2 += Convert.ToDouble(radGridView2.Rows[l].Cells[k].Value);
							}
							radGridView2.Rows[radGridView2.Rows.Count - 1].Cells[k].Value = Math.Round(num2 / (double)(radGridView2.Rows.Count - 1), 3);
						}
					}
				}
				bool flag6 = type == "Max";
				if (flag6)
				{
					radGridView2.Rows.Add(new object[]
					{
						"Max"
					});
					bool flag7 = radGridView2.Columns.Count > 1;
					if (flag7)
					{
						for (int m = 1; m < radGridView2.Columns.Count; m++)
						{
							double num3 = Convert.ToDouble(radGridView2.Rows[0].Cells[m].Value);
							for (int n = 0; n < radGridView2.Rows.Count - 1; n++)
							{
								bool flag8 = num3 < Convert.ToDouble(radGridView2.Rows[n].Cells[m].Value);
								if (flag8)
								{
									num3 = Convert.ToDouble(radGridView2.Rows[n].Cells[m].Value);
								}
							}
							radGridView2.Rows[radGridView2.Rows.Count - 1].Cells[m].Value = num3;
						}
					}
				}
				bool flag9 = type == "Min";
				if (flag9)
				{
					radGridView2.Rows.Add(new object[]
					{
						"Min"
					});
					bool flag10 = radGridView2.Columns.Count > 1;
					if (flag10)
					{
						for (int num4 = 1; num4 < radGridView2.Columns.Count; num4++)
						{
							double num5 = Convert.ToDouble(radGridView2.Rows[0].Cells[num4].Value);
							for (int num6 = 0; num6 < radGridView2.Rows.Count - 1; num6++)
							{
								bool flag11 = num5 > Convert.ToDouble(radGridView2.Rows[num6].Cells[num4].Value);
								if (flag11)
								{
									num5 = Convert.ToDouble(radGridView2.Rows[num6].Cells[num4].Value);
								}
							}
							radGridView2.Rows[radGridView2.Rows.Count - 1].Cells[num4].Value = num5;
						}
					}
				}
			}
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x001EA438 File Offset: 0x001E8638
		private void filtre_change()
		{
			RadGridView radGridView = new RadGridView();
			this.panel6.Controls.Clear();
			this.panel6.Controls.Add(radGridView);
			radGridView.Dock = DockStyle.Fill;
			this.design(radGridView);
			radGridView.ViewCellFormatting += new CellFormattingEventHandler(this.RadGridView2_ViewCellFormatting);
			radGridView.ViewRowFormatting += new RowFormattingEventHandler(prod_recap.select_changee);
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.panel2.Visible = true;
				this.label4.Visible = false;
				this.panel4.Visible = false;
				this.radDropDownList1.Visible = false;
				this.select_qt_fabrication(radGridView);
			}
			bool isChecked2 = this.radRadioButton15.IsChecked;
			if (isChecked2)
			{
				this.panel2.Visible = false;
				this.label4.Visible = false;
				this.panel4.Visible = false;
				this.radDropDownList1.Visible = false;
				this.select_fuel(radGridView);
			}
			bool isChecked3 = this.radRadioButton8.IsChecked;
			if (isChecked3)
			{
				this.panel2.Visible = true;
				this.panel4.Visible = false;
				this.select_qt_four(radGridView);
			}
			bool isChecked4 = this.radRadioButton14.IsChecked;
			if (isChecked4)
			{
				this.panel2.Visible = false;
				this.panel4.Visible = false;
				this.select_mesure_qualite_fabrication(radGridView);
			}
			bool isChecked5 = this.radRadioButton13.IsChecked;
			if (isChecked5)
			{
				this.panel2.Visible = true;
				this.panel4.Visible = false;
				this.select_production_par_poste(radGridView);
			}
			bool isChecked6 = this.radRadioButton9.IsChecked;
			if (isChecked6)
			{
				this.panel2.Visible = false;
				this.panel4.Visible = true;
				bool isChecked7 = this.radRadioButton11.IsChecked;
				if (isChecked7)
				{
					this.select_anomalie_par_poste(radGridView);
				}
				bool isChecked8 = this.radRadioButton10.IsChecked;
				if (isChecked8)
				{
					this.select_anomalie_par_anomalie(radGridView);
				}
				bool isChecked9 = this.radRadioButton12.IsChecked;
				if (isChecked9)
				{
					this.select_anomalie_par_unite(radGridView);
				}
			}
			foreach (GridViewColumn gridViewColumn in radGridView.MasterTemplate.Columns)
			{
				gridViewColumn.TextAlignment = ContentAlignment.MiddleCenter;
			}
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x001EA6AC File Offset: 0x001E88AC
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x001EA6B6 File Offset: 0x001E88B6
		private void radRadioButton5_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CA2 RID: 3234 RVA: 0x001EA6C0 File Offset: 0x001E88C0
		private void radRadioButton6_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x001EA6CA File Offset: 0x001E88CA
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x001EA6D4 File Offset: 0x001E88D4
		private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x001EA6DE File Offset: 0x001E88DE
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x001EA6E8 File Offset: 0x001E88E8
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.filtre_change();
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x001EA6F2 File Offset: 0x001E88F2
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x001EA6FC File Offset: 0x001E88FC
		private void radRadioButton3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x001EA708 File Offset: 0x001E8908
		private void select_unite()
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select distinct id_unite, equipement.designation from prod_rapport_four_entre inner join equipement on prod_rapport_four_entre.id_unite = equipement.id order by equipement.designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = prod_rapport.id_rpr;
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

		// Token: 0x06000CAA RID: 3242 RVA: 0x001EA814 File Offset: 0x001E8A14
		private void ecart_formatting(object sender, CellFormattingEventArgs e, RadGridView radGridView2)
		{
			bool flag = e.CellElement.RowInfo is GridViewDataRowInfo;
			if (flag)
			{
				foreach (GridViewColumn gridViewColumn in radGridView2.Columns)
				{
					bool flag2 = gridViewColumn.Name.Contains("ec");
					if (flag2)
					{
						double num = Convert.ToDouble(e.CellElement.RowInfo.Cells[gridViewColumn.Name].Value);
						bool flag3 = num < 0.0;
						if (flag3)
						{
							e.CellElement.DrawFill = true;
							e.CellElement.GradientStyle = 0;
							e.CellElement.BackColor = Color.Crimson;
						}
					}
					else
					{
						e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
						e.CellElement.ResetValue(VisualElement.BackColorProperty);
						e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
					}
				}
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
				e.CellElement.ResetValue(VisualElement.BackColorProperty);
				e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
			}
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x001EA96C File Offset: 0x001E8B6C
		private void select_anomalie_par_poste(RadGridView radGridView2)
		{
			radGridView2.Rows.Clear();
			radGridView2.Columns.Clear();
			radGridView2.AllowAutoSizeColumns = true;
			string cmdText = "select date_rapport, poste, equipement.designation, prod_anomalie.anomalie, duree from prod_rapport_anomalie inner join prod_rapport_general on prod_rapport_anomalie.id_rapport = prod_rapport_general.id inner join prod_anomalie on prod_rapport_anomalie.id_anomalie = prod_anomalie.id inner join equipement on prod_rapport_anomalie.id_unite = equipement.id where date_rapport between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			GridViewTextBoxColumn gridViewTextBoxColumn = new GridViewTextBoxColumn();
			GridViewTextBoxColumn gridViewTextBoxColumn2 = new GridViewTextBoxColumn();
			GridViewTextBoxColumn gridViewTextBoxColumn3 = new GridViewTextBoxColumn();
			GridViewTextBoxColumn gridViewTextBoxColumn4 = new GridViewTextBoxColumn();
			GridViewTextBoxColumn gridViewTextBoxColumn5 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn.Name = "Date";
			gridViewTextBoxColumn.HeaderText = "Date";
			gridViewTextBoxColumn2.Name = "Poste";
			gridViewTextBoxColumn2.HeaderText = "Poste";
			gridViewTextBoxColumn3.Name = "Unité";
			gridViewTextBoxColumn3.HeaderText = "Unité";
			gridViewTextBoxColumn4.Name = "Anomalie";
			gridViewTextBoxColumn4.HeaderText = "Anomalie";
			gridViewTextBoxColumn5.Name = "Durée";
			gridViewTextBoxColumn5.HeaderText = "Durée (Min)";
			radGridView2.MasterTemplate.Columns.AddRange(new GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5
			});
			radGridView2.Columns[0].Width = 100;
			radGridView2.Columns[1].Width = 60;
			radGridView2.Columns[2].Width = 350;
			radGridView2.Columns[3].Width = 350;
			radGridView2.Columns[4].Width = 100;
			radGridView2.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[0].IsVisible = true;
			radGridView2.Columns[1].IsVisible = true;
			radGridView2.Columns[2].IsVisible = true;
			radGridView2.Columns[3].IsVisible = true;
			radGridView2.Columns[4].IsVisible = true;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					radGridView2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString().Substring(0, 10),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
				}
				double num = 0.0;
				for (int j = 0; j < radGridView2.Rows.Count; j++)
				{
					num += Convert.ToDouble(radGridView2.Rows[j].Cells[4].Value);
				}
				radGridView2.Rows.Add(new object[]
				{
					"Total",
					"",
					"",
					"",
					num
				});
			}
			TableViewDefinition viewDefinition = new TableViewDefinition();
			radGridView2.MasterTemplate.ViewDefinition = viewDefinition;
		}

		// Token: 0x06000CAC RID: 3244 RVA: 0x001EAE0C File Offset: 0x001E900C
		private void select_anomalie_par_unite(RadGridView radGridView2)
		{
			radGridView2.Rows.Clear();
			radGridView2.Columns.Clear();
			radGridView2.AllowAutoSizeColumns = true;
			string cmdText = "select distinct equipement.id, equipement.designation from prod_rapport_anomalie inner join equipement on prod_rapport_anomalie.id_unite = equipement.id inner join prod_rapport_general on prod_rapport_anomalie.id_rapport = prod_rapport_general.id where date_rapport between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			GridViewTextBoxColumn gridViewTextBoxColumn = new GridViewTextBoxColumn();
			gridViewTextBoxColumn.Name = "Date";
			gridViewTextBoxColumn.HeaderText = "Date";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn);
			radGridView2.Columns[0].Width = 100;
			radGridView2.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[0].IsVisible = true;
			radGridView2.Columns[0].IsPinned = true;
			DateTime dateTime = this.radDateTimePicker1.Value;
			while (dateTime <= this.radDateTimePicker2.Value)
			{
				string text = Convert.ToString(dateTime).Substring(0, 10);
				radGridView2.Rows.Add(new object[]
				{
					text
				});
				dateTime = dateTime.AddDays(1.0);
			}
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					GridViewTextBoxColumn gridViewTextBoxColumn2 = new GridViewTextBoxColumn();
					gridViewTextBoxColumn2.Name = Convert.ToString(dataTable.Rows[i].ItemArray[0]);
					gridViewTextBoxColumn2.HeaderText = Convert.ToString(dataTable.Rows[i].ItemArray[1]);
					radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn2);
					radGridView2.Columns[i + 1].Width = 150;
					radGridView2.Columns[i + 1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
					radGridView2.Columns[i + 1].TextAlignment = ContentAlignment.MiddleCenter;
					radGridView2.Columns[i + 1].IsVisible = true;
					for (int j = 0; j < radGridView2.Rows.Count; j++)
					{
						string cmdText2 = "select sum(duree) from prod_rapport_anomalie inner join prod_rapport_general on prod_rapport_anomalie.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, this.b.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Date).Value = radGridView2.Rows[j].Cells[0].Value;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = Convert.ToString(dataTable.Rows[i].ItemArray[0]);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						double num = 0.0;
						bool flag2 = dataTable2.Rows.Count != 0;
						if (flag2)
						{
							fonction fonction = new fonction();
							bool flag3 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
							if (flag3)
							{
								num = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
							}
						}
						radGridView2.Rows[j].Cells[i + 1].Value = num;
					}
				}
			}
			TableViewDefinition viewDefinition = new TableViewDefinition();
			radGridView2.MasterTemplate.ViewDefinition = viewDefinition;
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				this.add_dernier_ligne("Total", radGridView2);
			}
			bool isChecked2 = this.radRadioButton5.IsChecked;
			if (isChecked2)
			{
				this.add_dernier_ligne("Moy", radGridView2);
			}
			bool isChecked3 = this.radRadioButton6.IsChecked;
			if (isChecked3)
			{
				this.add_dernier_ligne("Min", radGridView2);
			}
			bool isChecked4 = this.radRadioButton7.IsChecked;
			if (isChecked4)
			{
				this.add_dernier_ligne("Max", radGridView2);
			}
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x001EB298 File Offset: 0x001E9498
		private void radRadioButton9_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x001EB2A2 File Offset: 0x001E94A2
		private void radRadioButton11_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x001EB2AC File Offset: 0x001E94AC
		private void radRadioButton10_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CB0 RID: 3248 RVA: 0x001EB2B6 File Offset: 0x001E94B6
		private void radRadioButton12_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x001EB2C0 File Offset: 0x001E94C0
		private void radRadioButton13_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x001EB2CC File Offset: 0x001E94CC
		private void select_anomalie_par_anomalie(RadGridView radGridView2)
		{
			radGridView2.Rows.Clear();
			radGridView2.Columns.Clear();
			radGridView2.AllowAutoSizeColumns = true;
			string cmdText = "select  equipement.designation, prod_anomalie.anomalie,count(prod_rapport_anomalie.id) ,sum(duree) , equipement.id from prod_rapport_anomalie inner join prod_rapport_general on prod_rapport_anomalie.id_rapport = prod_rapport_general.id inner join prod_anomalie on prod_rapport_anomalie.id_anomalie = prod_anomalie.id inner join equipement on prod_rapport_anomalie.id_unite = equipement.id  where date_rapport between @d1 and @d2 group by prod_anomalie.id, prod_anomalie.anomalie, equipement.id, equipement.designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			ColumnGroupsViewDefinition columnGroupsViewDefinition = new ColumnGroupsViewDefinition();
			GridViewTextBoxColumn gridViewTextBoxColumn = new GridViewTextBoxColumn();
			gridViewTextBoxColumn.HeaderText = "Anomalie";
			gridViewTextBoxColumn.Width = 200;
			gridViewTextBoxColumn.Name = "Anomalie";
			gridViewTextBoxColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn.TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns.Add(gridViewTextBoxColumn);
			GridViewColumnGroup gridViewColumnGroup = new GridViewColumnGroup();
			gridViewColumnGroup.IsPinned = true;
			GridViewColumnGroupRow gridViewColumnGroupRow = new GridViewColumnGroupRow();
			gridViewColumnGroup.Text = "";
			gridViewColumnGroupRow.ColumnNames.Add("Anomalie");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				bool flag = radGridView2.Rows.Count != 0;
				if (flag)
				{
					bool flag2 = !radGridView2.Columns[0].DistinctValues.Contains(dataTable.Rows[i].ItemArray[1].ToString());
					if (flag2)
					{
						radGridView2.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[1].ToString()
						});
					}
				}
				else
				{
					radGridView2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[1].ToString()
					});
				}
			}
			columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup);
			gridViewColumnGroup.Rows.Add(gridViewColumnGroupRow);
			List<int> list = new List<int>();
			int num = 0;
			int num2 = 1;
			for (int j = 0; j < dataTable.Rows.Count; j++)
			{
				bool flag3 = !list.Contains(Convert.ToInt32(dataTable.Rows[j].ItemArray[4]));
				if (flag3)
				{
					list.Add(Convert.ToInt32(dataTable.Rows[j].ItemArray[4]));
					GridViewColumnGroup gridViewColumnGroup2 = new GridViewColumnGroup();
					GridViewColumnGroupRow gridViewColumnGroupRow2 = new GridViewColumnGroupRow();
					gridViewColumnGroup2.Text = dataTable.Rows[j].ItemArray[0].ToString();
					num++;
					GridViewTextBoxColumn gridViewTextBoxColumn2 = new GridViewTextBoxColumn();
					string str = num.ToString();
					gridViewTextBoxColumn2.Name = "f" + str;
					gridViewTextBoxColumn2.HeaderTextAlignment = ContentAlignment.MiddleCenter;
					gridViewTextBoxColumn2.TextAlignment = ContentAlignment.MiddleCenter;
					gridViewTextBoxColumn2.HeaderText = "Fréquence";
					gridViewTextBoxColumn2.Width = 100;
					radGridView2.Columns.Add(gridViewTextBoxColumn2);
					gridViewColumnGroupRow2.ColumnNames.Add(gridViewTextBoxColumn2.Name);
					GridViewTextBoxColumn gridViewTextBoxColumn3 = new GridViewTextBoxColumn();
					string str2 = num.ToString();
					gridViewTextBoxColumn3.Name = "d" + str2;
					gridViewTextBoxColumn3.HeaderTextAlignment = ContentAlignment.MiddleCenter;
					gridViewTextBoxColumn3.TextAlignment = ContentAlignment.MiddleCenter;
					gridViewTextBoxColumn3.HeaderText = "Durée (Min)";
					gridViewTextBoxColumn3.Width = 100;
					radGridView2.Columns.Add(gridViewTextBoxColumn3);
					gridViewColumnGroupRow2.ColumnNames.Add(gridViewTextBoxColumn3.Name);
					columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup2);
					gridViewColumnGroup2.Rows.Add(gridViewColumnGroupRow2);
					for (int k = 0; k < radGridView2.Rows.Count; k++)
					{
						double num3 = 0.0;
						double num4 = 0.0;
						string text = radGridView2.Rows[k].Cells[0].Value.ToString();
						for (int l = 0; l < dataTable.Rows.Count; l++)
						{
							bool flag4 = dataTable.Rows[l].ItemArray[0].ToString() == dataTable.Rows[j].ItemArray[0].ToString();
							if (flag4)
							{
								bool flag5 = dataTable.Rows[l].ItemArray[1].ToString() == text;
								if (flag5)
								{
									num3 = Convert.ToDouble(dataTable.Rows[l].ItemArray[2]);
									num4 = Convert.ToDouble(dataTable.Rows[l].ItemArray[3]);
								}
							}
						}
						radGridView2.Rows[k].Cells[num2].Value = num3;
						radGridView2.Rows[k].Cells[num2 + 1].Value = num4;
					}
					num2 += 2;
				}
			}
			radGridView2.MasterTemplate.ViewDefinition = columnGroupsViewDefinition;
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				this.add_dernier_ligne("Total", radGridView2);
			}
			bool isChecked2 = this.radRadioButton5.IsChecked;
			if (isChecked2)
			{
				this.add_dernier_ligne("Moy", radGridView2);
			}
			bool isChecked3 = this.radRadioButton6.IsChecked;
			if (isChecked3)
			{
				this.add_dernier_ligne("Min", radGridView2);
			}
			bool isChecked4 = this.radRadioButton7.IsChecked;
			if (isChecked4)
			{
				this.add_dernier_ligne("Max", radGridView2);
			}
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x001EB8BC File Offset: 0x001E9ABC
		private void select_production_par_poste(RadGridView radGridView2)
		{
			radGridView2.Rows.Clear();
			radGridView2.Columns.Clear();
			radGridView2.AllowAutoSizeColumns = true;
			ColumnGroupsViewDefinition columnGroupsViewDefinition = new ColumnGroupsViewDefinition();
			GridViewTextBoxColumn gridViewTextBoxColumn = new GridViewTextBoxColumn();
			gridViewTextBoxColumn.HeaderText = "Date Rapport";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn.Name = "t_date";
			gridViewTextBoxColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns.Add(gridViewTextBoxColumn);
			GridViewColumnGroup gridViewColumnGroup = new GridViewColumnGroup();
			gridViewColumnGroup.IsPinned = true;
			GridViewColumnGroupRow gridViewColumnGroupRow = new GridViewColumnGroupRow();
			gridViewColumnGroup.Text = "";
			gridViewColumnGroupRow.ColumnNames.Add("t_date");
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			DateTime dateTime = this.radDateTimePicker1.Value;
			while (dateTime <= this.radDateTimePicker2.Value)
			{
				string text = Convert.ToString(dateTime).Substring(0, 10);
				radGridView2.Rows.Add(new object[]
				{
					text
				});
				dateTime = dateTime.AddDays(1.0);
			}
			columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup);
			gridViewColumnGroup.Rows.Add(gridViewColumnGroupRow);
			string cmdText = "select equipement.designation,sum(quantite), equipement.id from prod_rapport_fab_produit inner join equipement on prod_rapport_fab_produit.id_unite = equipement.id inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where  date_rapport between @d1 and @d2 group by equipement.id, equipement.designation having sum(quantite) > 0 ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select equipement.designation,sum(quantite), equipement.id from prod_rapport_four_sortie inner join equipement on prod_rapport_four_sortie.id_unite = equipement.id inner join prod_rapport_general on prod_rapport_four_sortie.id_rapport = prod_rapport_general.id where  date_rapport between @d1 and @d2 group by equipement.id, equipement.designation having sum(quantite) > 0 ";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, this.b.cnn);
			sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			int num = 0;
			int num2 = 1;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					GridViewColumnGroup gridViewColumnGroup2 = new GridViewColumnGroup();
					GridViewColumnGroupRow gridViewColumnGroupRow2 = new GridViewColumnGroupRow();
					gridViewColumnGroup2.Text = dataTable.Rows[i].ItemArray[0].ToString();
					List<double> list3 = new List<double>();
					for (int j = 0; j < 3; j++)
					{
						string headerText = "Jour";
						bool flag2 = j == 1;
						if (flag2)
						{
							headerText = "Soir";
						}
						bool flag3 = j == 2;
						if (flag3)
						{
							headerText = "Nuit";
						}
						num++;
						GridViewTextBoxColumn gridViewTextBoxColumn2 = new GridViewTextBoxColumn();
						string text2 = num.ToString();
						gridViewTextBoxColumn2.Name = text2;
						gridViewTextBoxColumn2.HeaderTextAlignment = ContentAlignment.MiddleCenter;
						gridViewTextBoxColumn2.HeaderText = headerText;
						gridViewTextBoxColumn2.Width = 60;
						radGridView2.Columns.Add(gridViewTextBoxColumn2);
						gridViewColumnGroupRow2.ColumnNames.Add(text2);
					}
					num++;
					GridViewTextBoxColumn gridViewTextBoxColumn3 = new GridViewTextBoxColumn();
					string text3 = num.ToString();
					gridViewTextBoxColumn3.Name = text3;
					gridViewTextBoxColumn3.HeaderTextAlignment = ContentAlignment.MiddleCenter;
					gridViewTextBoxColumn3.HeaderText = "Total";
					gridViewTextBoxColumn3.Width = 70;
					radGridView2.Columns.Add(gridViewTextBoxColumn3);
					gridViewColumnGroupRow2.ColumnNames.Add(text3);
					columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup2);
					gridViewColumnGroup2.Rows.Add(gridViewColumnGroupRow2);
					int num3 = num2;
					for (int k = 0; k < 3; k++)
					{
						string value = "Jour";
						bool flag4 = k == 1;
						if (flag4)
						{
							value = "Soir";
						}
						bool flag5 = k == 2;
						if (flag5)
						{
							value = "Nuit";
						}
						for (int l = 0; l < radGridView2.Rows.Count; l++)
						{
							bool flag6 = k == 0;
							if (flag6)
							{
								list3.Add(0.0);
							}
							bool isChecked = this.radRadioButton2.IsChecked;
							string cmdText3;
							if (isChecked)
							{
								cmdText3 = "select sum(quantite) from prod_rapport_fab_produit inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and poste = @i3";
							}
							else
							{
								cmdText3 = "select sum(tonnage) from prod_rapport_fab_produit inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and poste = @i3";
							}
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, this.b.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Date).Value = radGridView2.Rows[l].Cells[0].Value.ToString();
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[2].ToString();
							sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = value;
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
							DataTable dataTable3 = new DataTable();
							sqlDataAdapter3.Fill(dataTable3);
							double num4 = 0.0;
							fonction fonction = new fonction();
							bool flag7 = dataTable3.Rows.Count != 0;
							if (flag7)
							{
								bool flag8 = fonction.is_reel(Convert.ToString(dataTable3.Rows[0].ItemArray[0]));
								if (flag8)
								{
									num4 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[0]);
								}
							}
							list3[l] += num4;
							radGridView2.Rows[l].Cells[num3].Value = Math.Round(num4, 3);
						}
						num3++;
					}
					for (int m = 0; m < radGridView2.Rows.Count; m++)
					{
						radGridView2.Rows[m].Cells[num3].Value = Math.Round(list3[m], 3);
					}
					num3++;
					num2 += 4;
				}
			}
			bool flag9 = dataTable2.Rows.Count != 0;
			if (flag9)
			{
				for (int n = 0; n < dataTable2.Rows.Count; n++)
				{
					GridViewColumnGroup gridViewColumnGroup3 = new GridViewColumnGroup();
					GridViewColumnGroupRow gridViewColumnGroupRow3 = new GridViewColumnGroupRow();
					gridViewColumnGroup3.Text = dataTable2.Rows[n].ItemArray[0].ToString();
					List<double> list4 = new List<double>();
					for (int num5 = 0; num5 < 3; num5++)
					{
						string headerText2 = "Jour";
						bool flag10 = num5 == 1;
						if (flag10)
						{
							headerText2 = "Soir";
						}
						bool flag11 = num5 == 2;
						if (flag11)
						{
							headerText2 = "Nuit";
						}
						num++;
						GridViewTextBoxColumn gridViewTextBoxColumn4 = new GridViewTextBoxColumn();
						string text4 = num.ToString();
						gridViewTextBoxColumn4.Name = text4;
						gridViewTextBoxColumn4.HeaderTextAlignment = ContentAlignment.MiddleCenter;
						gridViewTextBoxColumn4.HeaderText = headerText2;
						gridViewTextBoxColumn4.Width = 60;
						radGridView2.Columns.Add(gridViewTextBoxColumn4);
						gridViewColumnGroupRow3.ColumnNames.Add(text4);
					}
					num++;
					GridViewTextBoxColumn gridViewTextBoxColumn5 = new GridViewTextBoxColumn();
					string text5 = num.ToString();
					gridViewTextBoxColumn5.Name = text5;
					gridViewTextBoxColumn5.HeaderTextAlignment = ContentAlignment.MiddleCenter;
					gridViewTextBoxColumn5.HeaderText = "Total";
					gridViewTextBoxColumn5.Width = 70;
					radGridView2.Columns.Add(gridViewTextBoxColumn5);
					gridViewColumnGroupRow3.ColumnNames.Add(text5);
					columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup3);
					gridViewColumnGroup3.Rows.Add(gridViewColumnGroupRow3);
					int num6 = num2;
					for (int num7 = 0; num7 < 3; num7++)
					{
						string value2 = "Jour";
						bool flag12 = num7 == 1;
						if (flag12)
						{
							value2 = "Soir";
						}
						bool flag13 = num7 == 2;
						if (flag13)
						{
							value2 = "Nuit";
						}
						for (int num8 = 0; num8 < radGridView2.Rows.Count; num8++)
						{
							bool flag14 = num7 == 0;
							if (flag14)
							{
								list4.Add(0.0);
							}
							bool isChecked2 = this.radRadioButton2.IsChecked;
							string cmdText4;
							if (isChecked2)
							{
								cmdText4 = "select sum(quantite) from prod_rapport_four_sortie inner join prod_rapport_general on prod_rapport_four_sortie.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and poste = @i3";
							}
							else
							{
								cmdText4 = "select sum(tonnage) from prod_rapport_four_sortie inner join prod_rapport_general on prod_rapport_four_sortie.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and poste = @i3";
							}
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, this.b.cnn);
							sqlCommand4.Parameters.Add("@i1", SqlDbType.Date).Value = radGridView2.Rows[num8].Cells[0].Value.ToString();
							sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable2.Rows[n].ItemArray[2].ToString();
							sqlCommand4.Parameters.Add("@i3", SqlDbType.VarChar).Value = value2;
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
							DataTable dataTable4 = new DataTable();
							sqlDataAdapter4.Fill(dataTable4);
							double num9 = 0.0;
							fonction fonction2 = new fonction();
							bool flag15 = dataTable4.Rows.Count != 0;
							if (flag15)
							{
								bool flag16 = fonction2.is_reel(Convert.ToString(dataTable4.Rows[0].ItemArray[0]));
								if (flag16)
								{
									num9 = Convert.ToDouble(dataTable4.Rows[0].ItemArray[0]);
								}
							}
							list4[num8] += num9;
							radGridView2.Rows[num8].Cells[num6].Value = Math.Round(num9, 3);
						}
						num6++;
					}
					for (int num10 = 0; num10 < radGridView2.Rows.Count; num10++)
					{
						radGridView2.Rows[num10].Cells[num6].Value = Math.Round(list4[num10], 3);
					}
					num6++;
					num2 += 4;
				}
			}
			radGridView2.MasterTemplate.ViewDefinition = columnGroupsViewDefinition;
			bool isChecked3 = this.radRadioButton4.IsChecked;
			if (isChecked3)
			{
				this.add_dernier_ligne("Total", radGridView2);
			}
			bool isChecked4 = this.radRadioButton5.IsChecked;
			if (isChecked4)
			{
				this.add_dernier_ligne("Moy", radGridView2);
			}
			bool isChecked5 = this.radRadioButton6.IsChecked;
			if (isChecked5)
			{
				this.add_dernier_ligne("Min", radGridView2);
			}
			bool isChecked6 = this.radRadioButton7.IsChecked;
			if (isChecked6)
			{
				this.add_dernier_ligne("Max", radGridView2);
			}
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x001EC3E0 File Offset: 0x001EA5E0
		private void radRadioButton13_ToggleStateChanged_1(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x001EC3EC File Offset: 0x001EA5EC
		private void select_mesure_qualite_fabrication(RadGridView radGridView2)
		{
			radGridView2.Rows.Clear();
			radGridView2.Columns.Clear();
			radGridView2.AllowAutoSizeColumns = true;
			string cmdText = "select date_rapport from prod_rapport_fab_produit inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where  date_rapport between @d1 and @d2 group by date_rapport ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			ColumnGroupsViewDefinition columnGroupsViewDefinition = new ColumnGroupsViewDefinition();
			GridViewTextBoxColumn gridViewTextBoxColumn = new GridViewTextBoxColumn();
			gridViewTextBoxColumn.HeaderText = "Date Rapport";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn.Name = "t_date";
			gridViewTextBoxColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns.Add(gridViewTextBoxColumn);
			GridViewColumnGroup gridViewColumnGroup = new GridViewColumnGroup();
			GridViewColumnGroupRow gridViewColumnGroupRow = new GridViewColumnGroupRow();
			gridViewColumnGroup.Text = "";
			gridViewColumnGroupRow.ColumnNames.Add("t_date");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = Convert.ToString(dataTable.Rows[i].ItemArray[0]).Substring(0, 10);
					radGridView2.Rows.Add(new object[]
					{
						text
					});
				}
			}
			columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup);
			gridViewColumnGroup.Rows.Add(gridViewColumnGroupRow);
			string cmdText2 = "select equipement.designation, equipement.id from prod_rapport_fab_produit inner join equipement on prod_rapport_fab_produit.id_unite = equipement.id inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where  date_rapport between @d1 and @d2 group by equipement.id, equipement.designation";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, this.b.cnn);
			sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				int num = 0;
				int num2 = 1;
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					GridViewColumnGroup gridViewColumnGroup2 = new GridViewColumnGroup();
					GridViewColumnGroupRow gridViewColumnGroupRow2 = new GridViewColumnGroupRow();
					gridViewColumnGroup2.Text = dataTable2.Rows[j].ItemArray[0].ToString();
					string cmdText3 = "select id, designation from prod_saisie where cible = @a";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, this.b.cnn);
					sqlCommand3.Parameters.Add("@a", SqlDbType.Int).Value = 1;
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag3 = dataTable3.Rows.Count != 0;
					if (flag3)
					{
						List<double> list3 = new List<double>();
						for (int k = 0; k < dataTable3.Rows.Count; k++)
						{
							num++;
							GridViewTextBoxColumn gridViewTextBoxColumn2 = new GridViewTextBoxColumn();
							string text2 = num.ToString();
							gridViewTextBoxColumn2.Name = text2;
							gridViewTextBoxColumn2.HeaderTextAlignment = ContentAlignment.MiddleCenter;
							gridViewTextBoxColumn2.HeaderText = dataTable3.Rows[k].ItemArray[1].ToString();
							gridViewTextBoxColumn2.Width = 100;
							gridViewTextBoxColumn2.Multiline = true;
							radGridView2.Columns.Add(gridViewTextBoxColumn2);
							gridViewColumnGroupRow2.ColumnNames.Add(text2);
						}
						columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup2);
						gridViewColumnGroup2.Rows.Add(gridViewColumnGroupRow2);
						num++;
						int num3 = num2;
						for (int l = 0; l < dataTable3.Rows.Count; l++)
						{
							for (int m = 0; m < radGridView2.Rows.Count; m++)
							{
								string cmdText4 = "select avg(case (h1+h2+h3+h4+h5+h6+h7+h8) when 0 then 0 else (h1+h2+h3+h4+h5+h6+h7+h8)/(case h1 when 0 then 0 else 1 end + case h2 when 0 then 0 else 1 end + case h3 when 0 then 0 else 1 end + case h4 when 0 then 0 else 1 end + case h5 when 0 then 0 else 1 end + case h6 when 0 then 0 else 1 end + case h7 when 0 then 0 else 1 end + case h8 when 0 then 0 else 1 end) end) from prod_rapport_horaire_fabrication inner join prod_rapport_general on prod_rapport_horaire_fabrication.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and id_qualite = @i3 and (h1 + h2 + h3 + h4 + h5 +h6 + h7+ h8) <> @d";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, this.b.cnn);
								sqlCommand4.Parameters.Add("@i1", SqlDbType.Date).Value = radGridView2.Rows[m].Cells[0].Value.ToString();
								sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[1].ToString();
								sqlCommand4.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable3.Rows[l].ItemArray[0].ToString();
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								double value = 0.0;
								fonction fonction = new fonction();
								bool flag4 = dataTable4.Rows.Count != 0;
								if (flag4)
								{
									bool flag5 = fonction.is_reel(Convert.ToString(dataTable4.Rows[0].ItemArray[0]));
									if (flag5)
									{
										value = Convert.ToDouble(dataTable4.Rows[0].ItemArray[0]);
									}
								}
								radGridView2.Rows[m].Cells[num3].Value = Math.Round(value, 3);
							}
							num3++;
						}
						num2 += dataTable3.Rows.Count;
					}
				}
			}
			radGridView2.MasterTemplate.ViewDefinition = columnGroupsViewDefinition;
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				this.add_dernier_ligne("Total", radGridView2);
			}
			bool isChecked2 = this.radRadioButton5.IsChecked;
			if (isChecked2)
			{
				this.add_dernier_ligne("Moy", radGridView2);
			}
			bool isChecked3 = this.radRadioButton6.IsChecked;
			if (isChecked3)
			{
				this.add_dernier_ligne("Min", radGridView2);
			}
			bool isChecked4 = this.radRadioButton7.IsChecked;
			if (isChecked4)
			{
				this.add_dernier_ligne("Max", radGridView2);
			}
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x001ECA74 File Offset: 0x001EAC74
		private void radRadioButton14_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x001ECA80 File Offset: 0x001EAC80
		private void pictureBox4_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.panel6.Controls)
			{
				RadGridView radGridView = (RadGridView)obj;
				radGridView.PrintStyle = new GridPrintStyle
				{
					FitWidthMode = 0,
					PrintGrouping = true,
					PrintSummaries = false,
					PrintHeaderOnEachPage = true,
					PrintHiddenColumns = false,
					CellFont = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0),
					ChildViewPrintMode = 0,
					GroupRowBackColor = Color.Gray,
					HeaderCellBackColor = Color.Khaki
				};
				RadPrintDocument radPrintDocument = new RadPrintDocument();
				radPrintDocument.DefaultPageSettings.Landscape = true;
				radPrintDocument.MiddleHeader = "Rapport";
				radPrintDocument.HeaderFont = new Font("Arial", 50f);
				radPrintDocument.HeaderHeight = 100;
				radPrintDocument.Watermark.AllPages = false;
				radPrintDocument.Watermark.ImageOpacity = 180;
				radPrintDocument.Watermark.Pages = "1";
				radPrintDocument.Watermark.DrawInFront = true;
				string text = Path.Combine(Application.StartupPath, "Resources");
				radGridView.PrintPreview(radPrintDocument);
			}
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x001ECBF4 File Offset: 0x001EADF4
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.panel6.Controls)
			{
				RadGridView radGridView = (RadGridView)obj;
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.FileName = "";
				saveFileDialog.ShowDialog();
				bool flag = false;
				bool flag2 = saveFileDialog.FileName != "";
				if (flag2)
				{
					this.RunExportToexcel(saveFileDialog.FileName, ref flag, radGridView);
				}
			}
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x001ECC98 File Offset: 0x001EAE98
		private void RunExportToexcel(string fileName, ref bool openExportFile, RadGridView radGridView2)
		{
			new ExportToExcelML(radGridView2)
			{
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				PagingExportOption = 1,
				HiddenRowOption = 0,
				HiddenColumnOption = 0,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(radGridView2.ThemeName);
			MessageBox.Show("Enregistrement avec succés");
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x001ECCFC File Offset: 0x001EAEFC
		private void design(RadGridView rg2)
		{
			rg2.AutoScroll = true;
			rg2.BackColor = Color.White;
			rg2.Cursor = Cursors.Default;
			rg2.Font = new Font("Calibri", 11.25f);
			rg2.ForeColor = Color.Black;
			rg2.ImeMode = ImeMode.NoControl;
			rg2.Location = new Point(12, 146);
			rg2.MasterTemplate.AllowAddNewRow = false;
			rg2.MasterTemplate.AllowCellContextMenu = false;
			rg2.MasterTemplate.AllowColumnHeaderContextMenu = false;
			rg2.MasterTemplate.AllowColumnReorder = false;
			rg2.MasterTemplate.AllowDeleteRow = false;
			rg2.MasterTemplate.AllowDragToGroup = false;
			rg2.MasterTemplate.AllowEditRow = false;
			rg2.MasterTemplate.AllowRowHeaderContextMenu = false;
			rg2.MasterTemplate.EnableAlternatingRowColor = true;
			rg2.MasterTemplate.EnableFiltering = true;
			rg2.MasterTemplate.EnableSorting = false;
			rg2.MasterTemplate.ShowFilteringRow = false;
			rg2.MasterTemplate.ShowRowHeaderColumn = false;
			rg2.Padding = new Padding(1);
			rg2.PrintStyle.CellFont = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			rg2.PrintStyle.ChildViewPrintMode = 0;
			rg2.PrintStyle.GroupRowBackColor = Color.Gray;
			rg2.PrintStyle.HeaderCellBackColor = Color.Khaki;
			rg2.PrintStyle.PrintAllPages = true;
			rg2.PrintStyle.PrintAlternatingRowColor = true;
			rg2.ReadOnly = true;
			rg2.RightToLeft = RightToLeft.No;
			rg2.ShowGroupPanel = false;
			rg2.Size = new Size(1086, 454);
			rg2.ThemeName = "Crystal";
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x001ECEBE File Offset: 0x001EB0BE
		private void radRadioButton15_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.filtre_change();
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x001ECEC8 File Offset: 0x001EB0C8
		private void select_ratio_fuel_test(RadGridView radGridView2)
		{
			radGridView2.Rows.Clear();
			radGridView2.Columns.Clear();
			radGridView2.AllowAutoSizeColumns = true;
			string cmdText = "select date_rapport,sum(quantite) from prod_rapport_fab_produit inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where  date_rapport between @d1 and @d2 group by date_rapport having sum(quantite) > 0 ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			ColumnGroupsViewDefinition columnGroupsViewDefinition = new ColumnGroupsViewDefinition();
			GridViewTextBoxColumn gridViewTextBoxColumn = new GridViewTextBoxColumn();
			gridViewTextBoxColumn.HeaderText = "Date Rapport";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn.Name = "t_date";
			gridViewTextBoxColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns.Add(gridViewTextBoxColumn);
			GridViewColumnGroup gridViewColumnGroup = new GridViewColumnGroup();
			gridViewColumnGroup.IsPinned = true;
			GridViewColumnGroupRow gridViewColumnGroupRow = new GridViewColumnGroupRow();
			gridViewColumnGroup.Text = "";
			gridViewColumnGroupRow.ColumnNames.Add("t_date");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				List<string> list = new List<string>();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = Convert.ToString(dataTable.Rows[i].ItemArray[0]).Substring(0, 10);
					radGridView2.Rows.Add(new object[]
					{
						text
					});
				}
			}
			columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup);
			gridViewColumnGroup.Rows.Add(gridViewColumnGroupRow);
			string cmdText2 = "select sum(quantite) from prod_rapport_fab_produit inner join equipement on prod_rapport_fab_produit.id_unite = equipement.id inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where  date_rapport =  @d1";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, this.b.cnn);
			sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				int num = 0;
				int num2 = 1;
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					GridViewColumnGroup gridViewColumnGroup2 = new GridViewColumnGroup();
					GridViewColumnGroupRow gridViewColumnGroupRow2 = new GridViewColumnGroupRow();
					gridViewColumnGroup2.Text = dataTable2.Rows[j].ItemArray[0].ToString();
					string cmdText3 = "select id, designation from prod_type_brique";
					SqlCommand selectCommand = new SqlCommand(cmdText3, this.b.cnn);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag3 = dataTable3.Rows.Count != 0;
					if (flag3)
					{
						List<double> list2 = new List<double>();
						for (int k = 0; k < dataTable3.Rows.Count; k++)
						{
							num++;
							GridViewTextBoxColumn gridViewTextBoxColumn2 = new GridViewTextBoxColumn();
							string text2 = num.ToString();
							gridViewTextBoxColumn2.Name = text2;
							gridViewTextBoxColumn2.HeaderTextAlignment = ContentAlignment.MiddleCenter;
							gridViewTextBoxColumn2.HeaderText = dataTable3.Rows[k].ItemArray[1].ToString();
							gridViewTextBoxColumn2.Width = 50;
							radGridView2.Columns.Add(gridViewTextBoxColumn2);
							gridViewColumnGroupRow2.ColumnNames.Add(text2);
						}
						num++;
						GridViewTextBoxColumn gridViewTextBoxColumn3 = new GridViewTextBoxColumn();
						string text3 = num.ToString();
						gridViewTextBoxColumn3.Name = text3;
						gridViewTextBoxColumn3.HeaderTextAlignment = ContentAlignment.MiddleCenter;
						gridViewTextBoxColumn3.HeaderText = "Total";
						gridViewTextBoxColumn3.Width = 70;
						radGridView2.Columns.Add(gridViewTextBoxColumn3);
						gridViewColumnGroupRow2.ColumnNames.Add(text3);
						columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup2);
						gridViewColumnGroup2.Rows.Add(gridViewColumnGroupRow2);
						int num3 = num2;
						for (int l = 0; l < dataTable3.Rows.Count; l++)
						{
							for (int m = 0; m < radGridView2.Rows.Count; m++)
							{
								bool flag4 = l == 0;
								if (flag4)
								{
									list2.Add(0.0);
								}
								bool isChecked = this.radRadioButton2.IsChecked;
								string cmdText4;
								if (isChecked)
								{
									cmdText4 = "select sum(quantite) from prod_rapport_fab_produit inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and id_produit = @i3";
								}
								else
								{
									cmdText4 = "select sum(tonnage) from prod_rapport_fab_produit inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where date_rapport = @i1 and id_unite = @i2 and id_produit = @i3";
								}
								SqlCommand sqlCommand3 = new SqlCommand(cmdText4, this.b.cnn);
								sqlCommand3.Parameters.Add("@i1", SqlDbType.Date).Value = radGridView2.Rows[m].Cells[0].Value.ToString();
								sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[2].ToString();
								sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable3.Rows[l].ItemArray[0].ToString();
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								double num4 = 0.0;
								bool flag5 = dataTable4.Rows.Count != 0;
								if (flag5)
								{
									num4 = Convert.ToDouble(dataTable4.Rows[0].ItemArray[0]);
								}
								list2[m] += num4;
								radGridView2.Rows[m].Cells[num3].Value = Math.Round(num4, 3);
							}
							num3++;
						}
						for (int n = 0; n < radGridView2.Rows.Count; n++)
						{
							radGridView2.Rows[n].Cells[num3].Value = Math.Round(list2[n], 3);
						}
						num3++;
						num2 = num2 + dataTable3.Rows.Count + 1;
					}
				}
			}
			radGridView2.MasterTemplate.ViewDefinition = columnGroupsViewDefinition;
			bool isChecked2 = this.radRadioButton4.IsChecked;
			if (isChecked2)
			{
				this.add_dernier_ligne("Total", radGridView2);
			}
			bool isChecked3 = this.radRadioButton5.IsChecked;
			if (isChecked3)
			{
				this.add_dernier_ligne("Moy", radGridView2);
			}
			bool isChecked4 = this.radRadioButton6.IsChecked;
			if (isChecked4)
			{
				this.add_dernier_ligne("Min", radGridView2);
			}
			bool isChecked5 = this.radRadioButton7.IsChecked;
			if (isChecked5)
			{
				this.add_dernier_ligne("Max", radGridView2);
			}
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x001ED5BC File Offset: 0x001EB7BC
		private void select_fuel(RadGridView radGridView2)
		{
			radGridView2.Rows.Clear();
			radGridView2.Columns.Clear();
			radGridView2.AllowAutoSizeColumns = true;
			GridViewTextBoxColumn gridViewTextBoxColumn = new GridViewTextBoxColumn();
			gridViewTextBoxColumn.Name = "Date";
			gridViewTextBoxColumn.HeaderText = "Date";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn);
			radGridView2.Columns[0].Width = 100;
			radGridView2.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[0].IsVisible = true;
			radGridView2.Columns[0].IsPinned = true;
			GridViewTextBoxColumn gridViewTextBoxColumn2 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn2.Name = "Tonnage Fabrication";
			gridViewTextBoxColumn2.HeaderText = "Tonnage Fabrication";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn2);
			radGridView2.Columns[1].Width = 100;
			radGridView2.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[1].IsVisible = true;
			GridViewTextBoxColumn gridViewTextBoxColumn3 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn3.Name = "Tonnage S.Four";
			gridViewTextBoxColumn3.HeaderText = "Tonnage S.Four";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn3);
			radGridView2.Columns[2].Width = 100;
			radGridView2.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[2].IsVisible = true;
			GridViewTextBoxColumn gridViewTextBoxColumn4 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn4.Name = "wagon S.Four";
			gridViewTextBoxColumn4.HeaderText = "Wagon S.Four";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn4);
			radGridView2.Columns[3].Width = 100;
			radGridView2.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[3].IsVisible = true;
			GridViewTextBoxColumn gridViewTextBoxColumn5 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn5.Name = "Fuel_sechoir";
			gridViewTextBoxColumn5.HeaderText = "Fuel Séchoir (T)";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn5);
			radGridView2.Columns[4].Width = 110;
			radGridView2.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[4].IsVisible = true;
			GridViewTextBoxColumn gridViewTextBoxColumn6 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn6.Name = "Fuel_four";
			gridViewTextBoxColumn6.HeaderText = "Fuel Four (T)";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn6);
			radGridView2.Columns[5].Width = 110;
			radGridView2.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[5].IsVisible = true;
			GridViewTextBoxColumn gridViewTextBoxColumn7 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn7.Name = "Fuel_général";
			gridViewTextBoxColumn7.HeaderText = "Fuel Général (T)";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn7);
			radGridView2.Columns[6].Width = 110;
			radGridView2.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[6].IsVisible = true;
			GridViewTextBoxColumn gridViewTextBoxColumn8 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn8.Name = "Ratio_Fabrication";
			gridViewTextBoxColumn8.HeaderText = "Ratio_Fabrication (kg/T)";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn8);
			radGridView2.Columns[7].Width = 130;
			radGridView2.Columns[7].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[7].IsVisible = true;
			GridViewTextBoxColumn gridViewTextBoxColumn9 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn9.Name = "Ratio_Four";
			gridViewTextBoxColumn9.HeaderText = "Ratio_Four (kg/T)";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn9);
			radGridView2.Columns[8].Width = 110;
			radGridView2.Columns[8].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[8].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[8].IsVisible = true;
			GridViewTextBoxColumn gridViewTextBoxColumn10 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn10.Name = "Ratio_Général";
			gridViewTextBoxColumn10.HeaderText = "Ratio_Général (kg/T)";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn10);
			radGridView2.Columns[9].Width = 130;
			radGridView2.Columns[9].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[9].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[9].IsVisible = true;
			GridViewTextBoxColumn gridViewTextBoxColumn11 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn11.Name = "Ratio_Wagon";
			gridViewTextBoxColumn11.HeaderText = "Ratio_Wagon (T/Wg)";
			radGridView2.MasterTemplate.Columns.Add(gridViewTextBoxColumn11);
			radGridView2.Columns[10].Width = 130;
			radGridView2.Columns[10].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[10].TextAlignment = ContentAlignment.MiddleCenter;
			radGridView2.Columns[10].IsVisible = true;
			int num = 0;
			DateTime dateTime = this.radDateTimePicker1.Value;
			while (dateTime <= this.radDateTimePicker2.Value)
			{
				string text = Convert.ToString(dateTime).Substring(0, 10);
				string cmdText = "select ISNULL(SUM(tonnage), 0) from prod_rapport_fab_produit  inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where  date_rapport =  @d1";
				SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn);
				sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				double num2 = 0.0;
				bool flag = dataTable.Rows.Count != 0;
				if (flag)
				{
					num2 = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
				num2 = Math.Round(num2, 2);
				string cmdText2 = "select ISNULL(SUM(tonnage), 0), ISNULL(SUM(quantite), 0)  from prod_rapport_four_sortie  inner join prod_rapport_general on prod_rapport_four_sortie.id_rapport = prod_rapport_general.id where  date_rapport =  @d1";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, this.b.cnn);
				sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = text;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				double num3 = 0.0;
				double num4 = 0.0;
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					num3 = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
					num4 = Convert.ToDouble(dataTable2.Rows[0].ItemArray[1]);
				}
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				string cmdText3 = "select ISNULL(SUM(quantite), 0)  from prod_fuel  inner join prod_rapport_general on prod_fuel.id_rapport = prod_rapport_general.id where  date_rapport =  @d1 and type_saisie = @t";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, this.b.cnn);
				sqlCommand3.Parameters.Add("@d1", SqlDbType.Date).Value = text;
				sqlCommand3.Parameters.Add("@t", SqlDbType.Int).Value = 1;
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				bool flag3 = dataTable3.Rows.Count != 0;
				if (flag3)
				{
					num6 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[0]);
				}
				string cmdText4 = "select ISNULL(SUM(quantite), 0)  from prod_fuel  inner join prod_rapport_general on prod_fuel.id_rapport = prod_rapport_general.id where  date_rapport =  @d1 and type_saisie = @t";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, this.b.cnn);
				sqlCommand4.Parameters.Add("@d1", SqlDbType.Date).Value = text;
				sqlCommand4.Parameters.Add("@t", SqlDbType.Int).Value = 2;
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				DataTable dataTable4 = new DataTable();
				sqlDataAdapter4.Fill(dataTable4);
				bool flag4 = dataTable4.Rows.Count != 0;
				if (flag4)
				{
					num7 = Convert.ToDouble(dataTable4.Rows[0].ItemArray[0]);
				}
				string cmdText5 = "select ISNULL(SUM(quantite), 0)  from prod_fuel  inner join prod_rapport_general on prod_fuel.id_rapport = prod_rapport_general.id where  date_rapport =  @d1 and type_saisie = @t";
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, this.b.cnn);
				sqlCommand5.Parameters.Add("@d1", SqlDbType.Date).Value = text;
				sqlCommand5.Parameters.Add("@t", SqlDbType.Int).Value = 3;
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
				DataTable dataTable5 = new DataTable();
				sqlDataAdapter5.Fill(dataTable5);
				bool flag5 = dataTable5.Rows.Count != 0;
				if (flag5)
				{
					num5 = Convert.ToDouble(dataTable5.Rows[0].ItemArray[0]);
				}
				num2 = Math.Round(num2, 2);
				num3 = Math.Round(num3, 2);
				num4 = Math.Round(num4, 2);
				num5 = Math.Round(num5, 2);
				num6 = Math.Round(num6, 2);
				num7 = Math.Round(num7, 2);
				double num8 = 0.0;
				bool flag6 = num2 != 0.0;
				if (flag6)
				{
					num8 = Math.Round(num6 * 1000.0 / num2, 2);
				}
				double num9 = 0.0;
				bool flag7 = num3 != 0.0;
				if (flag7)
				{
					num9 = Math.Round(num7 * 1000.0 / num3, 2);
				}
				double num10 = 0.0;
				bool flag8 = num3 != 0.0;
				if (flag8)
				{
					num10 = Math.Round(num5 * 1000.0 / num3, 2);
				}
				double num11 = 0.0;
				bool flag9 = num4 != 0.0;
				if (flag9)
				{
					num11 = Math.Round(num5 / num4, 2);
				}
				radGridView2.Rows.Add(new object[]
				{
					text,
					num2,
					num3,
					num4,
					num6,
					num7,
					num5,
					num8,
					num9,
					num10,
					num11
				});
				num++;
				dateTime = dateTime.AddDays(1.0);
			}
			TableViewDefinition viewDefinition = new TableViewDefinition();
			radGridView2.MasterTemplate.ViewDefinition = viewDefinition;
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				this.add_dernier_ligne("Total", radGridView2);
			}
			bool isChecked2 = this.radRadioButton5.IsChecked;
			if (isChecked2)
			{
				this.add_dernier_ligne("Moy", radGridView2);
			}
			bool isChecked3 = this.radRadioButton6.IsChecked;
			if (isChecked3)
			{
				this.add_dernier_ligne("Min", radGridView2);
			}
			bool isChecked4 = this.radRadioButton7.IsChecked;
			if (isChecked4)
			{
				this.add_dernier_ligne("Max", radGridView2);
			}
		}

		// Token: 0x04001038 RID: 4152
		private bd b = new bd();
	}
}
