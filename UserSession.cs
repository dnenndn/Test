namespace GMAO
{
    public static class UserSession
    {
        public static int res { get; set; }
        public static string esm { get; set; }
        public static int id_user { get; set; }
        public static string stat_user { get; set; }
        public static string ConnectionName { get; set; }

        public static void Clear()
        {
            res = 0;
            esm = null;
            id_user = 0;
            stat_user = null;
            ConnectionName = null;
        }
    }
}
