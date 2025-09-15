///ETML
///Auteur : Christopher Ristic 
///Date: 08.09.2025
///Description: Contient les méthodes pour la fenêtre principale

namespace MeteoStats
{

    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

        }
    


        private void CheckBoxRain_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBoxTemp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBoxUv_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBoxCelsius_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxCelsius.Refresh();
        }

        private void CheckBoxFahrenheit_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void MainWindow_Resize(object sender, EventArgs e)
        {
            int newX = ClientSize.Width - checkBoxFahrenheit.Width - 100; // marge
            
            const Int16 newY = 40; // 10 px du haut

            checkBoxFahrenheit.Location = new Point(newX, newY);
            checkBoxCelsius.Location = new Point(newX - 50, newY);
        }
    }
}

