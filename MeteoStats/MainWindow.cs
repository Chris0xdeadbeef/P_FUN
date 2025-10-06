///ETML
///Auteur : Christopher Ristic 
///Date: 08.09.2025
///Description: Contient les méthodes pour la fenêtre principale

using ScottPlot.Statistics;
using System;
using System.Data;
using System.Globalization;

namespace MeteoStats
{

    public partial class MainWindow : Form
    {
        static Dictionary<string, Dictionary<DateTime, double>> allRainData = new();
        private ToolTip toolTip = new ToolTip();

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

            toolTip.SetToolTip(pictureBox2, "Température de l'air à 2 m du sol");

        }

        private void CheckBoxRain_CheckedChanged(object sender, EventArgs e)
        {
            var plot = graphicPlot.Plot;
            plot.Clear();

            if (!checkBoxRain.Checked || allRainData.Count == 0)
            {
                graphicPlot.Refresh();
                return;
            }

            // Couleurs pour les deux villes 
            Color[] colors = { Color.CornflowerBlue, Color.Red };
            int colorIndex = 0;

            foreach (var cityKvp in allRainData)
            {
                var cityName = cityKvp.Key;
                var dailyRain = cityKvp.Value;

                if (dailyRain.Count == 0)
                    continue;

                var sortedDaily = dailyRain.OrderBy(kvp => kvp.Key).ToList();
                double[] xs = sortedDaily.Select(kvp => kvp.Key.ToOADate()).ToArray();
                double[] ys = sortedDaily.Select(kvp => kvp.Value).ToArray();

                // Calcul des statistiques
                double min = ys.Min();
                double max = ys.Max();
                double moyenne = ys.Average();

                // Ligne principale
                var sig = plot.Add.SignalXY(xs, ys);
                sig.LineWidth = 2;
                sig.LegendText = $"{cityName} | Min: {min:F2} mm, Max: {max:F2} mm, Moyenne: {moyenne:F2} mm";

                ++colorIndex;
            }

            // Axe des X en dates
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.DateTimeAutomatic();

            plot.Title("Pluviométrie journalière par ville");
            plot.XLabel("Date");
            plot.YLabel("Pluviométrie (mm)");

            plot.Legend.Alignment = ScottPlot.Alignment.UpperRight;
            plot.ShowLegend();
            plot.Axes.AutoScale();
            graphicPlot.Refresh();

            exportButton.Enabled = true;
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
            using (OpenFileDialog openFileDialog = new())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "Fichiers CSV (*.csv)|*.csv|Tous les fichiers (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true; // autoriser plusieurs fichiers

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                if (openFileDialog.FileNames.Length != 2)
                {
                    MessageBox.Show("Veuillez sélectionner exactement 2 fichiers !");
                    return;
                }

                allRainData.Clear(); // réinitialiser les séries précédentes

                DateTime minDate = DateTime.MaxValue;
                DateTime maxDate = DateTime.MinValue;
                const string dateFormat = "dd.MM.yyyy";
                const string timeFormat = "HH:mm";

                var villes = new List<string>(); // pour stocker les noms des villes

                for (int i = 0; i < 2; ++i)
                {
                    string filePath = openFileDialog.FileNames[i];

                    string[] lines = File.ReadAllLines(filePath);
                    if (lines.Length < 2) continue;

                    // Nom de la ville dans colonne 0, ligne 1
                    string cityName = lines[1].Split(';')[0].Trim('"');
                    villes.Add(cityName);

                    string[] headers = lines[0].Split(';');
                    int rainIndex = Array.FindIndex(headers, h => h.Trim('"') == "rre150z0");
                    if (rainIndex == -1)
                    {
                        MessageBox.Show($"Colonne 'rre150z0' introuvable dans {filePath} !");
                        continue;
                    }

                    var dailyRain = new Dictionary<DateTime, double>();

                    foreach (string line in lines.Skip(1))
                    {
                        var parts = line.Split(';');

                        bool isValidDate = DateTime.TryParseExact(
                            parts[1],
                            "dd.MM.yyyy HH:mm",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime date
                        );

                        bool isValidRainValue = double.TryParse(
                            parts[rainIndex],
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out double pluieRaw
                        );
                        
                        if (parts.Length <= rainIndex) continue;

                        if (isValidDate && isValidRainValue)
                        {
                            double pluie = pluieRaw;
                            DateTime day = date.Date;
                            if (!dailyRain.ContainsKey(day)) dailyRain[day] = 0;
                            dailyRain[day] += pluie;

                            // Mettre à jour min/max global
                            if (date < minDate) minDate = date;
                            if (date > maxDate) maxDate = date;
                        }
                    }

                    allRainData[cityName] = dailyRain;
                }

                if (allRainData.Count > 0)
                    checkBoxRain.Enabled = true;

                // Remplir les TextBox avec les dates début/fin et heures
                beginDateInput.Text = minDate.ToString(dateFormat);
                endDateInput.Text = maxDate.ToString(dateFormat);
                timeBeginInput.Text = minDate.ToString(timeFormat);
                timeEndInput.Text = maxDate.ToString(timeFormat);

                // Mettre à jour le label des villes
                ville.Text = $"Ville: {string.Join(", ", villes)} \nDates: {minDate:dd/MM/yyyy} - {maxDate:dd/MM/yyyy}";
            }
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

        private void functionInput_TextChanged(object sender, EventArgs e)
        {
            var plot = graphicPlot.Plot;

            string input = functionInput.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                graphicPlot.Refresh();
                return;
            }

            List<double> xs = new();
            List<double> ys = new();

            // Définir la plage X selon les données existantes
            double xMin = 0;
            double xMax = 10;

            if (allRainData.Count > 0)
            {
                var allDates = allRainData.Values.SelectMany(d => d.Keys).Select(d => d.ToOADate());
                xMin = allDates.Min();
                xMax = allDates.Max();
            }

            double step = (xMax - xMin) / 500;

            for (double x = xMin; x <= xMax; x += step)
            {
                double y = EvaluateFunction(input, x);
                xs.Add(x);
                ys.Add(y);
            }

            // Supprimer l'ancienne fonction si elle existe
            var oldFunction = plot.GetPlottables().First();
            if (oldFunction != null)
                plot.Remove(oldFunction);

            // Ajouter la nouvelle fonction
            var functionSeries = plot.Add.Scatter(xs.ToArray(), ys.ToArray());
            functionSeries.Color = ScottPlot.Color.Gray(25);
            functionSeries.LineWidth = 2;
            functionSeries.LegendText = "Function";

            plot.Axes.AutoScale();
            graphicPlot.Refresh();

        }

        private double EvaluateFunction(string function, double x)
        {
            function = function.Replace("x", x.ToString(CultureInfo.InvariantCulture));
            function = function.Replace("^", "Pow"); // pour x^2 → Pow(x,2)

            // Remplacer des fonctions mathématiques
            function = function.Replace("sin", "Math.Sin");
            function = function.Replace("cos", "Math.Cos");
            function = function.Replace("tan", "Math.Tan");
            function = function.Replace("sqrt", "Math.Sqrt");

            // Utilisation de DataTable.Compute pour des opérations simples
            var dt = new DataTable();
            var v = dt.Compute(function, "");
            return Convert.ToDouble(v);
        }
    }
}

