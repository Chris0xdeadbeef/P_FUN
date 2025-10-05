///ETML
///Auteur : Christopher Ristic 
///Date: 08.09.2025
///Description: Contient les méthodes pour la fenêtre principale

using System.Globalization;


namespace MeteoStats
{

    public partial class MainWindow : Form
    {
        static Dictionary<DateTime, double> dailyRain = new ();

        public MainWindow()
        {
            InitializeComponent();

            //Par défaut les boutons ne sont pas cliquable
            checkBoxRain.Enabled = false;
            checkBoxUv.Enabled = false;
            checkBoxTemp.Enabled = false;
            checkBoxFahrenheit.Enabled = false;
            checkBoxCelsius.Enabled = false;
            exportButton.Enabled = false;

        }

        private void CheckBoxRain_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxRain.Checked)
            {
                graphicPlot.Plot.Clear();
                graphicPlot.Refresh();
                return;
            }

            if (dailyRain.Count == 0)
            {
                MessageBox.Show("Aucune donnée de pluie à afficher");
                checkBoxRain.Checked = false;
                return;
            }

            // Trier les données par date
            var sortedDaily = dailyRain.OrderBy(kvp => kvp.Key).ToList();

            // Convertir les dates et valeurs pour ScottPlot
            double[] xs = sortedDaily.Select(kvp => kvp.Key.ToOADate()).ToArray();
            double[] ys = sortedDaily.Select(kvp => kvp.Value).ToArray();

            var plot = graphicPlot.Plot;
            plot.Clear();

            // 1️ Tracé de la courbe principale
            var sig = plot.Add.SignalXY(xs, ys);
            sig.LineWidth = 2;
            sig.Color = ScottPlot.Colors.CornflowerBlue;

            // 2️ Tracé de l’aire sous la courbe 
            // On crée deux tableaux X et Y concaténés manuellement
            double[] xsFilled = new double[xs.Length * 2];
            double[] ysFilled = new double[ys.Length * 2];

            // Première moitié = la courbe
            Array.Copy(xs, xsFilled, xs.Length);
            Array.Copy(ys, ysFilled, ys.Length);

            // Seconde moitié = retour à zéro (dans l’ordre inverse)
            for (int i = 0; i < xs.Length; ++i)
            {
                xsFilled[xs.Length + i] = xs[xs.Length - 1 - i];
                ysFilled[ys.Length + i] = 0;
            }

            var fill = plot.Add.Polygon(xsFilled, ysFilled);
            fill.FillColor = ScottPlot.Colors.CornflowerBlue.WithAlpha(0.3);
            fill.LineWidth = 0;

            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.DateTimeAutomatic();

            plot.Title("Pluviométrie journalière");
            plot.XLabel("Date");
            plot.YLabel("Pluviométrie (mm)");

            //Forcer le focus sur toutes les données
            plot.Axes.AutoScale();

            graphicPlot.Refresh();
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

            // Sélection du fichier CSV
            using (OpenFileDialog openFileDialog = new())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "Fichiers CSV (*.csv)|*.csv|Tous les fichiers (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    MessageBox.Show("Fichier chargé : " + filePath);
                }
            }

            if (filePath == null)
                return;

            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length < 2)
                return;

            // Identifier l'index de la colonne "rre150z0"
            string[] headers = lines[0].Split(';');
            int rainIndex = Array.FindIndex(headers, h => h.Trim('"') == "rre150z0");
            if (rainIndex == -1)
            {
                MessageBox.Show("Colonne 'rre150z0' introuvable !");
                return;
            }

            // Les données commencent après l'en-tête
            IEnumerable<string> dataLines = lines.Skip(1);

            const string dateFormat = "dd.MM.yyyy";
            const string timeFormat = "HH:mm";

            dailyRain.Clear();

            DateTime minDate = DateTime.MaxValue;
            DateTime maxDate = DateTime.MinValue;

            foreach (string line in dataLines)
            {
                var parts = line.Split(';');
                if (parts.Length <= rainIndex)
                    continue;

                if (DateTime.TryParseExact(parts[1], $"{dateFormat} {timeFormat}",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out DateTime date) &&
                           double.TryParse(parts[rainIndex], NumberStyles.Any, CultureInfo.InvariantCulture, out double pluieRaw))
                {
                    double pluie = pluieRaw / 100.0; // Ajustement échelle

                    // Agrégation journalière
                    DateTime day = date.Date;
                    if (!dailyRain.ContainsKey(day))
                        dailyRain[day] = 0;
                    dailyRain[day] += pluie;

                    // Mise à jour min/max date
                    if (date < minDate) minDate = date;
                    if (date > maxDate) maxDate = date;
                }
            }

            // Remplir les champs date et heure
            beginDateInput.Text = minDate.ToString(dateFormat);
            endDateInput.Text = maxDate.ToString(dateFormat);
            timeBeginInput.Text = minDate.ToString(timeFormat);
            timeEndInput.Text = maxDate.ToString(timeFormat);

            // Affichage console pour vérification
            foreach (var kvp in dailyRain.OrderBy(x => x.Key))
                Console.WriteLine($"{kvp.Key:dd.MM.yyyy} : {kvp.Value} mm");

            checkBoxRain.Enabled = true;
            exportButton.Enabled = true;
        }

        private void OnClickExport(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new())
            {
                saveFileDialog.Filter = "Images PNG (*.png)|*.png";
                saveFileDialog.FileName = "graphique.png"; // nom par défaut

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Sauvegarde le graphique ScottPlot
                    graphicPlot.Plot.SavePng(saveFileDialog.FileName, graphicPlot.Size.Width, graphicPlot.Size.Height);
                    MessageBox.Show("Graphique sauvegardé en PNG !");
                }
            }
        }
    }
}

