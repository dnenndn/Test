using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
    // Token: 0x02000042 RID: 66
    public partial class commande_cloture : Form
    {
        // Token: 0x060002F8 RID: 760 RVA: 0x00080644 File Offset: 0x0007E844
        public commande_cloture()
        {
            this.InitializeComponent();
            LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
            this.radGridView1.CellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
            this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
        }

        // Token: 0x060002F9 RID: 761 RVA: 0x000806A8 File Offset: 0x0007E8A8
        private static string select_utilisateur(string i)
        {
            bd bd = new bd();
            string result = "";
            string cmdText = "select login from utilisateur where id = @i";
            SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
            sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = i;
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

        // Token: 0x060002FA RID: 762 RVA: 0x00080740 File Offset: 0x0007E940
        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
            if (flag)
            {
                RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
                radButtonElement.Image = (Image)new Bitmap("C:\\GMAO\\GMAO\\bin\\Debug\\img\\icons8-cabas-100.png");
                radButtonElement.ImageAlignment = ContentAlignment.MiddleCenter;
            }
            bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
            if (flag2)
            {
                RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
                radButtonElement2.Image = (Image)new Bitmap("C:\\GMAO\\GMAO\\bin\\Debug\\img\\icons8-impression-100.png");
                radButtonElement2.ImageAlignment = ContentAlignment.MiddleCenter;
            }
            bool flag3 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 8;
            if (flag3)
            {
                RadButtonElement radButtonElement3 = (RadButtonElement)e.CellElement.Children[0];
                radButtonElement3.Image = (Image)new Bitmap("C:\\GMAO\\GMAO\\bin\\Debug\\img\\icons8-historique-des-commandes-100.png");
                radButtonElement3.ImageAlignment = ContentAlignment.MiddleCenter;
            }
        }

        // Token: 0x060002FB RID: 763 RVA: 0x000808B0 File Offset: 0x0007EAB0
        private void remplissage_tableau(int o)
        {
            this.radGridView1.Rows.Clear();
            this.radGridView1.AllowDragToGroup = false;
            this.radGridView1.AllowAddNewRow = false;
            this.radGridView1.EnablePaging = true;
            this.radGridView1.PageSize = 14;
            this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
            this.radGridView1.EnableSorting = true;
            string cmdText = "select commande.id, date_commande, heure_commande, createur,  fournisseur.nom, urgence, n_commande from commande inner join fournisseur on commande.id_fournisseur = fournisseur.id where statut = @i";
            bd bd = new bd();
            SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
            sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 2;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            bool flag = dataTable.Rows.Count != 0;
            if (flag)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    this.radGridView1.Rows.Add(new object[]
                    {
                        dataTable.Rows[i].ItemArray[0].ToString(),
                        dataTable.Rows[i].ItemArray[6].ToString(),
                        dataTable.Rows[i].ItemArray[1].ToString(),
                        dataTable.Rows[i].ItemArray[2].ToString(),
                        commande_cloture.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
                        dataTable.Rows[i].ItemArray[4].ToString()
                    });
                    this.radGridView1.Rows[i].Cells[6].Value = "Réceptionner";
                    this.radGridView1.Rows[i].Cells[7].Value = "Imprimer";
                    this.radGridView1.Rows[i].Cells[8].Value = "Historique";
                }
                bool flag2 = UserSession.CurrentUser.Statut != "Responsable Achat" & UserSession.CurrentUser.Statut != "Responsable Méthode" & UserSession.CurrentUser.Statut != "Administrateur";
                if (flag2)
                {
                    this.radGridView1.Columns[8].IsVisible = false;
                }
                bool flag3 = UserSession.CurrentUser.Statut != "Responsable Achat";
                if (flag3)
                {
                    this.radGridView1.Columns[6].IsVisible = false;
                }
            }
            bool flag4 = this.radGridView1.Rows.Count != 0;
            if (flag4)
            {
                bool flag5 = o == 0;
                if (flag5)
                {
                    this.radGridView1.MasterTemplate.MoveToFirstPage();
                    this.radGridView1.Rows[0].IsCurrent = true;
                }
                bool flag6 = o == 1;
                if (flag6)
                {
                    this.radGridView1.MasterTemplate.MoveToLastPage();
                }
                bool flag7 = o == 2;
                if (flag7)
                {
                    this.radGridView1.Rows[this.row_act].IsCurrent = true;
                }
                bool flag8 = o == 3;
                if (flag8)
                {
                    bool flag9 = this.row_act != 0;
                    if (flag9)
                    {
                        this.radGridView1.Rows[this.row_act - 1].IsCurrent = true;
                    }
                    else
                    {
                        this.radGridView1.MasterTemplate.MoveToFirstPage();
                        this.radGridView1.Rows[0].IsCurrent = true;
                    }
                }
            }
            this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
        }

        // Token: 0x060002FC RID: 764 RVA: 0x00080C80 File Offset: 0x0007EE80
        private void action_tableau(object sender, GridViewCellEventArgs e)
        {
            bool flag = this.radGridView1.Rows.Count != 0;
            if (flag)
            {
                bool flag2 = e.RowIndex >= 0 && e.ColumnIndex == 6;
                if (flag2)
                {
                    string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    this.row_act = e.RowIndex;
                    bd bd = new bd();
                    DialogResult dialogResult = MessageBox.Show("Vous voulez réceptionner cette commande ?", "Réception", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    bool flag3 = dialogResult == DialogResult.Yes;
                    if (flag3)
                    {
                        string cmdText = "update commande set statut = @d where id = @i";
                        SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
                        sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
                        sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 3;
                        bd.ouverture_bd(bd.cnn);
                        sqlCommand.ExecuteNonQuery();
                        bd.cnn.Close();
                        this.remplissage_tableau(3);
                    }
                }
                bool flag4 = e.RowIndex >= 0 && e.ColumnIndex == 8;
                if (flag4)
                {
                    string value2 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    this.id_historique = value2;
                    this.liste_id.Clear();
                    this.id_pos = 0;
                    bd bd2 = new bd();
                    string cmdText2 = "select id from commande_modification_base where id_commande = @i";
                    SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
                    sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value2;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    bool flag5 = dataTable.Rows.Count != 0;
                    if (flag5)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            this.liste_id.Add(dataTable.Rows[i].ItemArray[0].ToString());
                        }
                    }
                    this.afficher_modification(0);
                    this.label9.Text = (this.id_pos + 1).ToString() + " Sur " + this.liste_id.Count.ToString();
                    this.radPanel2.Show();
                }
            }
        }

        // Token: 0x060002FD RID: 765 RVA: 0x00080F16 File Offset: 0x0007F116
        private void commande_cloture_Load(object sender, EventArgs e)
        {
            this.radPanel2.Hide();
            this.remplissage_tableau(0);
        }

        // Token: 0x060002FE RID: 766 RVA: 0x00080F2C File Offset: 0x0007F12C
        private void afficher_modification(int p)
        {
            this.dataGridView2.Rows.Clear();
            bool flag = p == 0;
            if (flag)
            {
                this.label2.Text = "Créer le :";
                this.label3.Text = "Créer par :";
                this.label5.Text = this.id_historique;
            }
            else
            {
                this.label2.Text = "Modifié le :";
                this.label3.Text = "Modifié par :";
                this.label5.Text = this.id_historique;
            }
            bd bd = new bd();
            string cmdText = "select modifier_par, date_modification, heure_modification from commande_modification_base where id = @i";
            SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
            sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.liste_id[p];
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.label6.Text = fonction.Mid(dataTable.Rows[0].ItemArray[1].ToString(), 1, 10) + " à " + dataTable.Rows[0].ItemArray[2].ToString() + " H";
            this.label7.Text = (commande_cloture.select_utilisateur(dataTable.Rows[0].ItemArray[0].ToString() ?? "") ?? "");
            string cmdText2 = "select  article.code_article, article.designation, commande_modifier_article.qt, commande_modifier_article.prix_ht, commande_modifier_article.remise from commande_modifier_article inner join article on commande_modifier_article.id_article = article.id   where id_modification = @i";
            SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
            sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.liste_id[p];
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            bool flag2 = dataTable2.Rows.Count != 0;
            if (flag2)
            {
                for (int i = 0; i < dataTable2.Rows.Count; i++)
                {
                    this.dataGridView2.Rows.Add(new object[]
                    {
                        dataTable2.Rows[i].ItemArray[0].ToString(),
                        dataTable2.Rows[i].ItemArray[1].ToString(),
                        dataTable2.Rows[i].ItemArray[2].ToString(),
                        dataTable2.Rows[i].ItemArray[3].ToString(),
                        dataTable2.Rows[i].ItemArray[4].ToString()
                    });
                }
            }
        }

        // Token: 0x060002FF RID: 767 RVA: 0x000811E4 File Offset: 0x0007F3E4
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bool flag = this.liste_id.Count != 0;
            if (flag)
            {
                bool flag2 = this.id_pos == this.liste_id.Count - 1;
                if (flag2)
                {
                    this.id_pos = 0;
                }
                else
                {
                    this.id_pos++;
                }
                this.label9.Text = (this.id_pos + 1).ToString() + " Sur " + this.liste_id.Count.ToString();
                this.afficher_modification(this.id_pos);
            }
        }

        // Token: 0x06000300 RID: 768 RVA: 0x00081280 File Offset: 0x0007F480
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bool flag = this.liste_id.Count != 0;
            if (flag)
            {
                bool flag2 = this.id_pos == 0;
                if (flag2)
                {
                    this.id_pos = this.liste_id.Count - 1;
                }
                else
                {
                    this.id_pos--;
                }
                this.label9.Text = (this.id_pos + 1).ToString() + " Sur " + this.liste_id.Count.ToString();
                this.afficher_modification(this.id_pos);
            }
        }

        // Token: 0x06000301 RID: 769 RVA: 0x0008131A File Offset: 0x0007F51A
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.radPanel2.Hide();
        }

        // Token: 0x06000302 RID: 770 RVA: 0x00081328 File Offset: 0x0007F528
        private void filtrage(object sender, EventArgs e)
        {
            this.radGridView1.Rows.Clear();
            this.radGridView1.AllowDragToGroup = false;
            this.radGridView1.AllowAddNewRow = false;
            this.radGridView1.EnablePaging = true;
            this.radGridView1.PageSize = 14;
            this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
            this.radGridView1.EnableSorting = true;
            string cmdText = "select commande.id, date_commande, heure_commande, createur,  fournisseur.nom, urgence, n_commande from commande inner join fournisseur on commande.id_fournisseur = fournisseur.id where statut = @i and date_commande between @d1 and @d2";
            bd bd = new bd();
            SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
            sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 2;
            sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
            sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            bool flag = dataTable.Rows.Count != 0;
            if (flag)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    this.radGridView1.Rows.Add(new object[]
                    {
                        dataTable.Rows[i].ItemArray[0].ToString(),
                        dataTable.Rows[i].ItemArray[6].ToString(),
                        dataTable.Rows[i].ItemArray[1].ToString(),
                        dataTable.Rows[i].ItemArray[2].ToString(),
                        commande_cloture.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
                        dataTable.Rows[i].ItemArray[4].ToString()
                    });
                    this.radGridView1.Rows[i].Cells[6].Value = "Réceptionner";
                    this.radGridView1.Rows[i].Cells[7].Value = "Imprimer";
                    this.radGridView1.Rows[i].Cells[8].Value = "Historique";
                }
                bool flag2 = UserSession.CurrentUser.Statut != "Responsable Achat" & UserSession.CurrentUser.Statut != "Responsable Méthode" & UserSession.CurrentUser.Statut != "Administrateur";
                if (flag2)
                {
                    this.radGridView1.Columns[8].IsVisible = false;
                }
                bool flag3 = UserSession.CurrentUser.Statut != "Responsable Achat";
                if (flag3)
                {
                    this.radGridView1.Columns[6].IsVisible = false;
                }
            }
            this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
        }

        // Token: 0x06000303 RID: 771 RVA: 0x0008162A File Offset: 0x0007F82A
        private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.filtrage(sender, e);
        }

        // Token: 0x06000304 RID: 772 RVA: 0x00081634 File Offset: 0x0007F834
        private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.filtrage(sender, e);
        }

        // Token: 0x04000429 RID: 1065
        private int row_act;

        // Token: 0x0400042A RID: 1066
        private string id_historique;

        // Token: 0x0400042B RID: 1067
        private List<string> liste_id = new List<string>();

        // Token: 0x0400042C RID: 1068
        private int id_pos;

        // Token: 0x0400042D RID: 1069
        public static string id_art;
    }
}
