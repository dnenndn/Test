using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls.Themes;

namespace GMAO
{
	// Token: 0x020000A7 RID: 167
	public partial class ot_analyse_ishikawa : Form
	{
		// Token: 0x060007AB RID: 1963 RVA: 0x00153890 File Offset: 0x00151A90
		public ot_analyse_ishikawa()
		{
			this.InitializeComponent();
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x001538A8 File Offset: 0x00151AA8
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.EndCap = LineCap.ArrowAnchor;
			pen.Width = 3f;
			e.Graphics.DrawLine(pen, 20, 220, 800, 220);
			Pen pen2 = new Pen(Color.Firebrick);
			pen2.EndCap = LineCap.ArrowAnchor;
			pen2.Width = 2f;
			e.Graphics.DrawLine(pen2, 105, 9, 65, 215);
			Pen pen3 = new Pen(Color.Firebrick);
			pen3.EndCap = LineCap.ArrowAnchor;
			pen3.Width = 2f;
			e.Graphics.DrawLine(pen3, 355, 9, 315, 215);
			Pen pen4 = new Pen(Color.Firebrick);
			pen4.EndCap = LineCap.ArrowAnchor;
			pen4.Width = 2f;
			e.Graphics.DrawLine(pen4, 605, 9, 565, 215);
			Pen pen5 = new Pen(Color.Firebrick);
			pen5.StartCap = LineCap.ArrowAnchor;
			pen5.Width = 2f;
			e.Graphics.DrawLine(pen5, 65, 222, 105, 428);
			Pen pen6 = new Pen(Color.Firebrick);
			pen6.StartCap = LineCap.ArrowAnchor;
			pen6.Width = 2f;
			e.Graphics.DrawLine(pen6, 565, 222, 605, 428);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x00153A2C File Offset: 0x00151C2C
		private void remplissage_panel(Panel p, string m)
		{
			p.Controls.Clear();
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select parametre_anomalie.anomalie from ot_diagnostic_m inner join ordre_travail on ot_diagnostic_m.id_ot = ordre_travail.id inner join parametre_anomalie on ot_diagnostic_m.id_defaillance = parametre_anomalie.id where type_m = @m and id_ot  in (" + str + ") and ordre_travail.statut = @st ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
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

		// Token: 0x060007AE RID: 1966 RVA: 0x00153BB0 File Offset: 0x00151DB0
		private void ot_analyse_ishikawa_Load(object sender, EventArgs e)
		{
			this.remplissage_panel(this.panel2, "Main-d'œuvre");
			this.remplissage_panel(this.panel3, "Matériel");
			this.remplissage_panel(this.panel4, "Matière");
			this.remplissage_panel(this.panel5, "Méthode");
			this.remplissage_panel(this.panel6, "Milieu");
		}
	}
}
