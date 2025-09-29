
using System.Globalization;

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

            const Int16 topRightY = 40;
            const Int16 bottomRightY = 824;

            checkBoxFahrenheit.Location = new Point(newX, topRightY);
            checkBoxCelsius.Location = new Point(newX - 70, topRightY);
            importButton.Location = new Point(newX - 50, bottomRightY);
            exportButton.Location = new Point(newX - 50, bottomRightY - (importButton.Location.Y - exportButton.Location.Y));
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            string? filePath = null;

            //Affichage du fichier 
            using (OpenFileDialog openFileDialog = new())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "Fichiers CSV (*.csv)|*.csv|Tous les fichiers (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                // Quand on clique sur OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    string fileContent = File.ReadAllText(filePath);

                    MessageBox.Show("Fichier chargé : " + filePath);
                }
            }

            if (filePath == null)
                return;

            var lines = File.ReadAllLines(filePath);

            // Les données commencent après l'en-tête
            IEnumerable<string> dataLines = lines.Skip(1);

            DateTime minDate = DateTime.MaxValue;
            DateTime maxDate = DateTime.MinValue;

            const string dateFormat = "dd.MM.yyyy";
            const string timeFormat = "HH:mm";

            foreach (string line in dataLines)
            {
                // La date est le 2ème champ séparé par ;
                var parts = line.Split(';');
                if (parts.Length < 2)
                    continue;

                if (DateTime.TryParseExact(parts[1], $"{dateFormat} {timeFormat}",
                                           CultureInfo.InvariantCulture,
                                           DateTimeStyles.None,
                                           out DateTime date))
                {
                    if (date < minDate)
                        minDate = date;

                    if (date > maxDate)
                        maxDate = date;
                }
            }

            // Remplir la date
            beginDateInput.Text = minDate.ToString(dateFormat);
            endDateInput.Text = maxDate.ToString(dateFormat);

            // Remplir l'heure
            timeBeginInput.Text = minDate.ToString(timeFormat);
            timeEndInput.Text = maxDate.ToString(timeFormat);
        }
    }
}

