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

            Controls.Add(graphicPlot);
            double[] xs = { 0, 1, 2, 3, 4 };
            double[] ys = { 0, 1, 4, 9, 16 };

            graphicPlot.Plot.Add.Scatter(xs, ys);

            graphicPlot.Refresh();
        }

        private void CheckBoxRain_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxTemp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxUv_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxCelsius_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxFahr_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
