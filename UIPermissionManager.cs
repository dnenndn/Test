using System.Windows.Forms;
using System.Drawing;

namespace GMAO
{
    public static class UIPermissionManager
    {
        public static void ApplyPermissions(Form1 form)
        {
            if (UserSession.res == 1)
            {
                form.label3.Text = UserSession.esm;
                form.label4.Text = UserSession.stat_user;

                if (UserSession.stat_user == "Administrateur")
                {
                    form.button3.Visible = false;
                    form.button4.Visible = false;
                    form.button10.Visible = false;
                    form.button11.Visible = false;
                    form.panel8.Visible = false;
                    form.panel8.Size = new Size(200, 45);
                    form.panel6.Size = new Size(200, 235);
                }
                if (UserSession.stat_user == "Responsable Achat")
                {
                    form.panel3.Visible = false;
                    form.button3.Visible = false;
                    form.button4.Visible = false;
                    form.panel11.Visible = false;
                    form.panel9.Visible = false;
                    form.panel8.Visible = false;
                    form.panel6.Size = new Size(200, 235);
                }
                if (UserSession.stat_user == "Responsable Magasin")
                {
                    form.panel3.Visible = false;
                    form.button3.Visible = false;
                    form.button4.Visible = false;
                    form.panel11.Visible = false;
                    form.button7.Visible = false;
                    form.button16.Visible = false;
                    form.button17.Visible = false;
                    form.button10.Visible = false;
                    form.button31.Visible = false;
                    form.panel6.Size = new Size(200, 235);
                    form.panel7.Size = new Size(200, 235);
                    form.panel8.Size = new Size(200, 100);
                    form.panel9.Visible = false;
                    form.panel8.Visible = false;
                    form.panel12.Visible = false;
                    form.panel13.Visible = false;
                }
                if (UserSession.stat_user == "Magasinier")
                {
                    form.panel3.Visible = false;
                    form.button3.Visible = false;
                    form.button4.Visible = false;
                    form.panel11.Visible = false;
                    form.button7.Visible = false;
                    form.button8.Visible = false;
                    form.button12.Visible = false;
                    form.button15.Visible = false;
                    form.button16.Visible = false;
                    form.button17.Visible = false;
                    form.button10.Visible = false;
                    form.button31.Visible = false;
                    form.button32.Visible = false;
                    form.panel6.Size = new Size(200, 235);
                    form.panel7.Size = new Size(200, 45);
                    form.panel8.Size = new Size(200, 100);
                    form.panel9.Visible = false;
                    form.panel8.Visible = false;
                    form.panel12.Visible = false;
                    form.panel13.Visible = false;
                }
                if (UserSession.stat_user == "Agent de Méthode")
                {
                    form.button7.Visible = false;
                    form.button12.Visible = false;
                    form.button14.Visible = false;
                    form.button15.Visible = false;
                    form.button16.Visible = false;
                    form.button17.Visible = false;
                    form.button10.Visible = false;
                    form.button6.Visible = false;
                    form.button31.Visible = false;
                    form.button32.Visible = false;
                    form.panel6.Size = new Size(200, 285);
                    form.panel7.Size = new Size(200, 45);
                    form.panel8.Size = new Size(200, 100);
                    form.panel9.Visible = false;
                    form.panel8.Visible = false;
                    form.panel12.Visible = false;
                    form.panel13.Visible = false;
                }
                if (UserSession.stat_user == "Responsable Technique")
                {
                    form.button7.Visible = false;
                    form.button15.Visible = false;
                    form.button16.Visible = false;
                    form.button17.Visible = false;
                    form.button10.Visible = false;
                    form.button31.Visible = false;
                    form.button32.Visible = false;
                    form.panel6.Size = new Size(200, 320);
                    form.panel7.Size = new Size(200, 151);
                    form.panel8.Size = new Size(200, 100);
                    form.panel9.Visible = false;
                    form.panel8.Visible = false;
                }
            }
        }
    }
}
