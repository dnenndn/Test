using System;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x0200015A RID: 346
	internal static class Program
	{
		// Token: 0x06000F53 RID: 3923 RVA: 0x00251158 File Offset: 0x0024F358
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new page_loginn());
		}
	}
}
