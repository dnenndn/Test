using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000C9 RID: 201
	public partial class ot_ordonnancement_employe : Form
	{
		// Token: 0x060008F4 RID: 2292 RVA: 0x00179200 File Offset: 0x00177400
		public ot_ordonnancement_employe()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_ordonnancement_employe.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_ordonnancement_employe.select_changee);
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radGridView3.ContextMenuOpening += new ContextMenuOpeningEventHandler(this.radGridView1_ContextMenuOpening);
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x001792B4 File Offset: 0x001774B4
		private void radGanttView1_TextViewCellFormatting(object sender, GanttViewTextViewCellFormattingEventArgs e)
		{
			e.CellElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x001792D8 File Offset: 0x001774D8
		private void remplissage_gantt()
		{
			bd bd = new bd();
			string cmdText = "select ot_ressources_fonction.id, fonction_intervenant.designation, nbre_requis, min_planif, type_cout, date_debut, heure_debut from ot_ressources_fonction inner join fonction_intervenant on ot_ressources_fonction.id_fonction = fonction_intervenant.id where id_ot = @i order by date_debut, heure_debut";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				DateTime dateTime = default(DateTime);
				DateTime dateTime2 = default(DateTime);
				dateTime = Convert.ToDateTime(dataTable.Rows[0].ItemArray[5]);
				dateTime2 = Convert.ToDateTime(dataTable.Rows[dataTable.Rows.Count - 1].ItemArray[5]).AddDays(1.0);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int hour = Convert.ToInt32(fonction.Mid(dataTable.Rows[i].ItemArray[6].ToString(), 1, 2));
					int minute = Convert.ToInt32(fonction.Mid(dataTable.Rows[i].ItemArray[6].ToString(), 4, 2));
					DateTime dateTime3 = new DateTime(Convert.ToDateTime(dataTable.Rows[i].ItemArray[5]).Year, Convert.ToDateTime(dataTable.Rows[i].ItemArray[5]).Month, Convert.ToDateTime(dataTable.Rows[i].ItemArray[5]).Day, hour, minute, 0);
					DateTime end = default(DateTime);
					end = dateTime3.AddMinutes((double)Convert.ToInt32(dataTable.Rows[i].ItemArray[3]));
					GanttViewDataItem ganttViewDataItem = new GanttViewDataItem();
					ganttViewDataItem.Start = Convert.ToDateTime(dataTable.Rows[i].ItemArray[5]);
					ganttViewDataItem.End = end;
					ganttViewDataItem.Progress = 30m;
					ganttViewDataItem.Title = (i + 1).ToString();
				}
			}
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00179527 File Offset: 0x00177727
		private void ot_ordonnancement_employe_Load(object sender, EventArgs e)
		{
			this.pictureBox3_Click(sender, e);
			this.select_tableau();
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0017953C File Offset: 0x0017773C
		private void select_tableau()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select ot_ressources_fonction.id, fonction_intervenant.designation, nbre_requis, min_planif, date_debut, heure_debut, type_cout from ot_ressources_fonction inner join fonction_intervenant on ot_ressources_fonction.id_fonction = fonction_intervenant.id where id_ot = @i";
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
						fonction.Mid(dataTable.Rows[i].ItemArray[4].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						Resources.icons8_approuver_et_mettre_à_jour_96__4_
					});
				}
			}
			this.radGridView3.Templates.Clear();
			this.Loadinterv();
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x001796FC File Offset: 0x001778FC
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

		// Token: 0x060008FA RID: 2298 RVA: 0x00179780 File Offset: 0x00177980
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

		// Token: 0x060008FB RID: 2299 RVA: 0x00179883 File Offset: 0x00177A83
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			this.radGridView3.Size = new Size(1050, 210);
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x001798B0 File Offset: 0x00177AB0
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 7;
			if (flag)
			{
				this.panel1.Visible = true;
				this.radGridView3.Size = new Size(1050, 141);
				this.src = this.radGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
				this.verif_interv(Convert.ToInt32(this.radGridView3.Rows[e.RowIndex].Cells[0].Value), this.src);
				this.id_f = Convert.ToInt32(this.radGridView3.Rows[e.RowIndex].Cells[0].Value);
			}
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x001799A0 File Offset: 0x00177BA0
		private void verif_interv(int o, string sr)
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select intervenant.id , intervenant.nom from intervenant where id_fonction in (select id_fonction from ot_ressources_fonction where id = @i) and deleted = @d and type_cout = @s order by intervenant.nom";
			string cmdText2 = "select date_debut, heure_debut, min_planif, nbre_requis from ot_ressources_fonction where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = o;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = o;
			sqlCommand2.Parameters.Add("@s", SqlDbType.VarChar).Value = sr;
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = sr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				int hour = Convert.ToInt32(fonction.Mid(dataTable2.Rows[0].ItemArray[1].ToString(), 1, 2));
				int minute = Convert.ToInt32(fonction.Mid(dataTable2.Rows[0].ItemArray[1].ToString(), 4, 2));
				DateTime dateTime = default(DateTime);
				dateTime = Convert.ToDateTime(dataTable2.Rows[0].ItemArray[0]);
				DateTime dateTime2 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, minute, 0);
				int num = Convert.ToInt32(dataTable2.Rows[0].ItemArray[2]);
				DateTime dateTime3 = dateTime2.AddMinutes((double)num);
				this.bideya = dateTime2;
				this.nihaya = dateTime3;
				this.nbr_autor = Convert.ToInt32(dataTable2.Rows[0].ItemArray[3]);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText3 = "select id from ot_ordo_intervenant where id_intervenant = @i and ((debut between @d1 and @d2) or (fin between @d1 and @d2))";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					sqlCommand3.Parameters.Add("@d1", SqlDbType.DateTime).Value = dateTime2;
					sqlCommand3.Parameters.Add("@d2", SqlDbType.DateTime).Value = dateTime3;
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag2 = dataTable3.Rows.Count == 0;
					if (flag2)
					{
						this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
						this.radDropDownList1.Items[this.radDropDownList1.Items.Count - 1].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					}
				}
			}
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00179CF9 File Offset: 0x00177EF9
		private void afficher_agenda(int id_interv)
		{
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00179CFC File Offset: 0x00177EFC
		private void radButton1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				string cmdText = "select id from ot_ordo_intervenant where id_ressource_fonction = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_f;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string cmdText2 = "select taux_horaire from intervenant where id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag;
				double num = 0.0;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					num = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
				}
				bool flag3 = dataTable.Rows.Count < this.nbr_autor;
				if (flag3)
				{
					string cmdText3 = "insert into ot_ordo_intervenant (id_ressource_fonction, id_intervenant, debut, fin, cout_horaire) values (@v1, @v2, @v3, @v4, @v5)";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = this.id_f;
					sqlCommand3.Parameters.Add("@v2", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag;
					sqlCommand3.Parameters.Add("@v3", SqlDbType.DateTime).Value = this.bideya;
					sqlCommand3.Parameters.Add("@v4", SqlDbType.DateTime).Value = this.nihaya;
					sqlCommand3.Parameters.Add("@v5", SqlDbType.Real).Value = num;
					bd.ouverture_bd(bd.cnn);
					sqlCommand3.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Enregistrement avec succés");
					this.verif_interv(this.id_f, this.src);
					this.select_tableau();
				}
				else
				{
					MessageBox.Show("Erreur :Impossible de dépasser le nombre requis des intervenants", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Il faut choisir l'intervenant", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00179F6C File Offset: 0x0017816C
		private void Loadinterv()
		{
			bd bd = new bd();
			string cmdText = "select id_ressource_fonction, intervenant.nom, ot_ordo_intervenant.id from ot_ressources_fonction inner join ot_ordo_intervenant on ot_ressources_fonction.id = ot_ordo_intervenant.id_ressource_fonction inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where id_ot = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Employés";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 300;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[2].IsVisible = false;
				gridViewTemplate.Columns[2].HeaderText = "";
				gridViewTemplate.Columns[1].HeaderText = "Employés";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				this.radGridView3.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView3.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView3.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView3.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x0017A280 File Offset: 0x00178480
		private void radGridView1_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
		{
			GridDataCellElement targetCell = e.ContextMenuProvider as GridDataCellElement;
			bool flag = targetCell != null && targetCell.RowInfo.HierarchyLevel == 1;
			if (flag)
			{
				e.ContextMenu.Items.Clear();
				bool flag2 = targetCell.RowInfo.ViewTemplate.Caption == "Employés";
				if (flag2)
				{
					RadMenuItem radMenuItem = new RadMenuItem("Supprimer");
					e.ContextMenu.Items.Add(radMenuItem);
					radMenuItem.Click += delegate(object s, EventArgs f)
					{
						string value = targetCell.RowInfo.Cells[2].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer l'employé ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag3 = dialogResult == DialogResult.Yes;
						if (flag3)
						{
							bd bd = new bd();
							string cmdText = "delete ot_ordo_intervenant where id = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.select_tableau();
							this.verif_interv(this.id_f, this.src);
						}
					};
				}
			}
		}

		// Token: 0x04000C13 RID: 3091
		private int id_f = 0;

		// Token: 0x04000C14 RID: 3092
		private string src = "";

		// Token: 0x04000C15 RID: 3093
		private DateTime bideya = default(DateTime);

		// Token: 0x04000C16 RID: 3094
		private DateTime nihaya = default(DateTime);

		// Token: 0x04000C17 RID: 3095
		private int nbr_autor = 0;
	}
}
