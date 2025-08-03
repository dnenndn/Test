using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000065 RID: 101
	internal class design
	{
		// Token: 0x060004DC RID: 1244 RVA: 0x000D21F0 File Offset: 0x000D03F0
		public static void radCheckedDropDownList_TextBlockFormatting(object sender, TextBlockFormattingEventArgs e)
		{
			TokenizedTextBlockElement tokenizedTextBlockElement = e.TextBlock as TokenizedTextBlockElement;
			bool flag = tokenizedTextBlockElement != null;
			if (flag)
			{
				tokenizedTextBlockElement.ForeColor = Color.Black;
				tokenizedTextBlockElement.DrawFill = false;
				tokenizedTextBlockElement.BorderColor = Color.DarkRed;
				tokenizedTextBlockElement.BorderWidth = 1.3f;
				tokenizedTextBlockElement.DrawBorder = true;
				tokenizedTextBlockElement.BorderGradientStyle = 0;
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x000D2250 File Offset: 0x000D0450
		public static void design_datagridview(DataGridView dataGridView1)
		{
			dataGridView1.BorderStyle = BorderStyle.None;
			dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
			dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Firebrick;
			dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
			dataGridView1.BackgroundColor = Color.White;
			dataGridView1.EnableHeadersVisualStyles = false;
			dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
			dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
		}
	}
}
