///ETML
///Auteur : Christopher Ristic 
///Date: 08.09.2025
///Description: Programme principale de l'application MeteoStats


namespace MeteoStats
{
    internal static class MainMeteoStats
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());

        }
    }
}