using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000134 RID: 308
	internal class fonction
	{
		// Token: 0x06000D88 RID: 3464 RVA: 0x0020CC60 File Offset: 0x0020AE60
		public string DeleteSpace(string laChaine)
		{
			return laChaine.Replace(" ", string.Empty);
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x0020CC84 File Offset: 0x0020AE84
		public void Design_datagridview(DataGridView d)
		{
			d.BorderStyle = BorderStyle.None;
			d.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
			d.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			d.DefaultCellStyle.SelectionBackColor = Color.FromArgb(111, 109, 216);
			d.BackgroundColor = Color.White;
			d.EnableHeadersVisualStyles = false;
			d.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			d.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(111, 109, 216);
			d.RowHeadersVisible = false;
			d.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x0020CD2C File Offset: 0x0020AF2C
		public bool isnumeric(string nombre)
		{
			bool result;
			try
			{
				long.Parse(nombre);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x0020CD60 File Offset: 0x0020AF60
		public bool is_reel(string nombre)
		{
			bool result;
			try
			{
				float.Parse(nombre);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x0020CD94 File Offset: 0x0020AF94
		public static string Mid(string s, int a, int b)
		{
			return s.Substring(a - 1, b);
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x0020CDB4 File Offset: 0x0020AFB4
		public static double tonnage_wagon(string s)
		{
			bool flag = s == "B12";
			double result;
			if (flag)
			{
				result = 0.00324;
			}
			else
			{
				bool flag2 = s == "B8";
				if (flag2)
				{
					result = 0.00459;
				}
				else
				{
					bool flag3 = s == "PLATRIERE";
					if (flag3)
					{
						result = 0.00594;
					}
					else
					{
						bool flag4 = s == "H16";
						if (flag4)
						{
							result = 0.00237;
						}
						else
						{
							bool flag5 = s == "H19";
							if (flag5)
							{
								result = 0.00198;
							}
							else
							{
								result = 0.00324;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x0020CE78 File Offset: 0x0020B078
		public static void ouvrir_fichier(string x)
		{
			try
			{
				fonction fonction = new fonction();
				string str = "ExampleText.txt";
				string str2 = "Example.gz";
				Process.Start(new ProcessStartInfo
				{
					FileName = (x ?? ""),
					Arguments = "a -tgzip " + str2 + str + " -mx=9",
					WindowStyle = ProcessWindowStyle.Hidden
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x0020CF00 File Offset: 0x0020B100
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

		// Token: 0x06000D90 RID: 3472 RVA: 0x0020CF84 File Offset: 0x0020B184
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 12.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
				}
			}
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x0020D068 File Offset: 0x0020B268
		public static string chiffrage_signature(string s)
		{
			string text = "";
			for (int i = 1; i <= s.Length; i++)
			{
				bool flag = fonction.Mid(s, i, 1) == "0";
				if (flag)
				{
					text += "r_";
				}
				bool flag2 = fonction.Mid(s, i, 1) == "1";
				if (flag2)
				{
					text += "ahi";
				}
				bool flag3 = fonction.Mid(s, i, 1) == "2";
				if (flag3)
				{
					text += "88";
				}
				bool flag4 = fonction.Mid(s, i, 1) == "3";
				if (flag4)
				{
					text += "mt21";
				}
				bool flag5 = fonction.Mid(s, i, 1) == "4";
				if (flag5)
				{
					text += "46";
				}
				bool flag6 = fonction.Mid(s, i, 1) == "5";
				if (flag6)
				{
					text += "ar_";
				}
				bool flag7 = fonction.Mid(s, i, 1) == "6";
				if (flag7)
				{
					text += "o9py";
				}
				bool flag8 = fonction.Mid(s, i, 1) == "7";
				if (flag8)
				{
					text += "p7_op";
				}
				bool flag9 = fonction.Mid(s, i, 1) == "8";
				if (flag9)
				{
					text += "srt";
				}
				bool flag10 = fonction.Mid(s, i, 1) == "9";
				if (flag10)
				{
					text += "0099";
				}
			}
			return text;
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x0020D220 File Offset: 0x0020B420
		public bool isdate(string nombre)
		{
			bool result;
			try
			{
				DateTime.Parse(nombre);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x0020D254 File Offset: 0x0020B454
		public static void select_change1(object sender, CellFormattingEventArgs e)
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
				bool flag = e.CellElement is GridColumnGroupCellElement;
				if (flag)
				{
					e.CellElement.DrawFill = true;
					e.CellElement.GradientStyle = 0;
					e.CellElement.BackColor = Color.Silver;
					e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
				}
				else
				{
					e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
					e.CellElement.ResetValue(VisualElement.BackColorProperty);
					e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
				}
			}
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x0020D328 File Offset: 0x0020B528
		public static void select_changee1(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.BackColor = Color.White;
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
				}
			}
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x0020D3EC File Offset: 0x0020B5EC
		public static void ecran(Form child, int x, int y)
		{
			double r = (double)x / 1366.0;
			double r2 = (double)y / 768.0;
			foreach (object obj in child.Controls)
			{
				Control c = (Control)obj;
				fonction.recr(0m, 0m, 0m, 0m, r, r2, c, 0m);
			}
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x0020D49C File Offset: 0x0020B69C
		public static void recr(decimal s1, decimal s2, decimal l1, decimal l2, double r1, double r2, Control c, decimal f)
		{
			s1 = Math.Truncate(c.Size.Width * Convert.ToDecimal(r1));
			s2 = Math.Truncate(c.Size.Height * Convert.ToDecimal(r2));
			l1 = Math.Truncate(c.Location.X * Convert.ToDecimal(r1));
			l2 = Math.Truncate(c.Location.Y * Convert.ToDecimal(r2));
			c.Size = new Size(Convert.ToInt32(s1), Convert.ToInt32(s2));
			c.Location = new Point(Convert.ToInt32(l1), Convert.ToInt32(l2));
			bool flag = c.Font != null;
			if (flag)
			{
				f = Math.Truncate(Convert.ToDecimal(c.Font.Size) * Convert.ToDecimal(r1));
				c.Font = new Font(c.Font.Name, (float)f, c.Font.Style, c.Font.Unit, c.Font.GdiCharSet, true);
			}
			foreach (object obj in c.Controls)
			{
				Control c2 = (Control)obj;
				fonction.recr(s1, s2, l1, l2, r1, r2, c2, f);
			}
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x0020D654 File Offset: 0x0020B854
		public static string rendre_mois(int h)
		{
			string result = "";
			bool flag = h == 1;
			if (flag)
			{
				result = "Jan";
			}
			bool flag2 = h == 2;
			if (flag2)
			{
				result = "Fév";
			}
			bool flag3 = h == 3;
			if (flag3)
			{
				result = "Mar";
			}
			bool flag4 = h == 4;
			if (flag4)
			{
				result = "Avr";
			}
			bool flag5 = h == 5;
			if (flag5)
			{
				result = "Mai";
			}
			bool flag6 = h == 6;
			if (flag6)
			{
				result = "Juin";
			}
			bool flag7 = h == 7;
			if (flag7)
			{
				result = "Juil";
			}
			bool flag8 = h == 8;
			if (flag8)
			{
				result = "Aout";
			}
			bool flag9 = h == 9;
			if (flag9)
			{
				result = "Sep";
			}
			bool flag10 = h == 10;
			if (flag10)
			{
				result = "Oct";
			}
			bool flag11 = h == 11;
			if (flag11)
			{
				result = "Nov";
			}
			bool flag12 = h == 12;
			if (flag12)
			{
				result = "Déc";
			}
			return result;
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x0020D748 File Offset: 0x0020B948
		public static void da_systeme_formatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.RowInfo is GridViewDataRowInfo;
			if (flag)
			{
				string a = Convert.ToString(e.CellElement.RowInfo.Cells[3].Value);
				bool flag2 = a == "Système";
				if (flag2)
				{
					e.CellElement.DrawFill = true;
					e.CellElement.GradientStyle = 0;
					e.CellElement.BackColor = Color.Goldenrod;
				}
			}
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x0020D7CC File Offset: 0x0020B9CC
		public static void telecharger_tous_id_enfant(int id_prn, List<int> l)
		{
			bd bd = new bd();
			string cmdText = "with temporary as (select equipement.id from equipement where equipement.id = @i and deleted = @d union all select a.id from equipement a inner join temporary b on a.id_parent = b.id) select * from temporary ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_prn;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					l.Add(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]));
				}
			}
		}
	}
}
