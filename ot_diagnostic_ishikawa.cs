using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000B6 RID: 182
	public partial class ot_diagnostic_ishikawa : Form
	{
		// Token: 0x0600083E RID: 2110 RVA: 0x00163B2A File Offset: 0x00161D2A
		public ot_diagnostic_ishikawa()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x00163B44 File Offset: 0x00161D44
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.EndCap = LineCap.ArrowAnchor;
			pen.Width = 3f;
			e.Graphics.DrawLine(pen, 20, 118, 800, 118);
			Pen pen2 = new Pen(Color.Firebrick);
			pen2.EndCap = LineCap.ArrowAnchor;
			pen2.Width = 2f;
			e.Graphics.DrawLine(pen2, 105, 33, 65, 121);
			Pen pen3 = new Pen(Color.Firebrick);
			pen3.EndCap = LineCap.ArrowAnchor;
			pen3.Width = 2f;
			e.Graphics.DrawLine(pen3, 355, 33, 315, 121);
			Pen pen4 = new Pen(Color.Firebrick);
			pen4.EndCap = LineCap.ArrowAnchor;
			pen4.Width = 2f;
			e.Graphics.DrawLine(pen4, 605, 33, 565, 121);
			Pen pen5 = new Pen(Color.Firebrick);
			pen5.StartCap = LineCap.ArrowAnchor;
			pen5.Width = 2f;
			e.Graphics.DrawLine(pen5, 65, 125, 105, 213);
			Pen pen6 = new Pen(Color.Firebrick);
			pen6.StartCap = LineCap.ArrowAnchor;
			pen6.Width = 2f;
			e.Graphics.DrawLine(pen6, 565, 125, 605, 213);
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00163CB4 File Offset: 0x00161EB4
		private void remplissage_panel(Panel p, string m, string id)
		{
			p.Controls.Clear();
			bd bd = new bd();
			string cmdText = "select parametre_anomalie.anomalie from ot_diagnostic_m inner join parametre_anomalie on ot_diagnostic_m.id_defaillance = parametre_anomalie.id where type_m = @m and id_ot = @i and id_defaillance <> @h";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			sqlCommand.Parameters.Add("@h", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@m", SqlDbType.VarChar).Value = m;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					Label label = new Label();
					label.Text = dataTable.Rows[i].ItemArray[0].ToString();
					label.AutoSize = true;
					label.Font = new Font("Trebuchet MS", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
					label.ForeColor = Color.Black;
					label.Location = new Point(3, 15 * i + 2);
					p.Controls.Add(label);
				}
			}
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00163E10 File Offset: 0x00162010
		private void ot_diagnostic_ishikawa_Load(object sender, EventArgs e)
		{
			this.label1.Text = "";
			bd bd = new bd();
			string cmdText = "select parametre_anomalie.anomalie, parametre_anomalie.id from ordre_travail inner join parametre_anomalie on ordre_travail.id_defaillance = parametre_anomalie.id where ordre_travail.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.label1.Text = dataTable.Rows[0].ItemArray[0].ToString();
				string id = dataTable.Rows[0].ItemArray[1].ToString();
				this.remplissage_panel(this.panel2, "Main-d'œuvre", id);
				this.remplissage_panel(this.panel3, "Matériel", id);
				this.remplissage_panel(this.panel4, "Matière", id);
				this.remplissage_panel(this.panel5, "Méthode", id);
				this.remplissage_panel(this.panel6, "Milieu", id);
			}
		}
	}
}
