///ETML
///Auteur : Christopher Ristic 
///Date: 08.09.2025
///Description: Contient les méthodes pour la fenêtre principale

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
            using OpenFileDialog openFileDialog = new()
            {
                Filter = "Fichiers CSV (*.csv)|*.csv|Tous les fichiers (*.*)|*.*",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            if (openFileDialog.FileNames.Length != 2)
            {
                MessageBox.Show("Veuillez sélectionner exactement 2 fichiers !");
                return;
            }

            allRainData.Clear();

            var villes = new List<string>();
            DateTime globalMin = DateTime.MaxValue, globalMax = DateTime.MinValue;

            foreach (var filePath in openFileDialog.FileNames)
            {
                var dailyRain = filePath.ReadRainData(out string cityName, out DateTime minDate, out DateTime maxDate);
                allRainData[cityName] = dailyRain;
                villes.Add(cityName);

                if (minDate < globalMin) globalMin = minDate;
                if (maxDate > globalMax) globalMax = maxDate;
            }

            // Active les cases
            checkBoxRain.Enabled = allRainData.Count > 0;

            // Met à jour l'UI
            beginDateInput.Text = globalMin.ToString("dd.MM.yyyy");
            endDateInput.Text = globalMax.ToString("dd.MM.yyyy");
            timeBeginInput.Text = globalMin.ToString("HH:mm");
            timeEndInput.Text = globalMax.ToString("HH:mm");

            ville.Text = $"Ville: {string.Join(", ", villes)}\nDates: {globalMin:dd/MM/yyyy} - {globalMax:dd/MM/yyyy}";
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


        private void FunctionInput_TextChanged(object sender, EventArgs e)
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
            var dataTable = new DataTable();
            var computeResult = dataTable.Compute(function, "");

            return Convert.ToDouble(computeResult);
        }
    }

    public static class CsvExtensions
    {
        /// <summary>
        /// Lit un fichier CSV météo et retourne un dictionnaire des pluies journalières.
        /// </summary>
        public static Dictionary<DateTime, double> ReadRainData(this string filePath, out string cityName,
                                                                out DateTime minDate, out DateTime maxDate)
        {
            cityName = string.Empty;
            minDate = DateTime.MaxValue;
            maxDate = DateTime.MinValue;

            var result = new Dictionary<DateTime, double>();
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 2) return result;

            // Nom de la ville (colonne 0, ligne 1)
            cityName = lines[1].Split(';')[0].Trim('"');

            string[] headers = lines[0].Split(';');
            int rainIndex = Array.FindIndex(headers, h => h.Trim('"') == "rre150z0");
            if (rainIndex == -1)
                throw new Exception($"Colonne 'rre150z0' introuvable dans {filePath} !");

            foreach (string line in lines.Skip(1))
            {
                var parts = line.Split(';');
                if (parts.Length <= rainIndex) continue;

                bool isValidDate = DateTime.TryParseExact(parts[1], "dd.MM.yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                bool isValidRainValue = double.TryParse(parts[rainIndex], NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double pluieRaw);

                if (isValidDate && isValidRainValue)
                {
                    DateTime day = date.Date;
                    if (!result.ContainsKey(day)) result[day] = 0;
                    result[day] += pluieRaw;

                    if (date < minDate) minDate = date;
                    if (date > maxDate) maxDate = date;
                }
            }

            return result;
        }
    }

    public static class DictionaryExtensions
    {
        /// <summary>
        /// Retourne la date min et max à partir d'un dictionnaire de villes et de leurs données journalières.
        /// </summary>
        public static (DateTime min, DateTime max) GetDateRange(this Dictionary<string, Dictionary<DateTime, double>> data)
        {
            if (data.Count == 0)
                return (DateTime.MinValue, DateTime.MinValue);

            var allDates = data.Values.SelectMany(d => d.Keys);
            return (allDates.Min(), allDates.Max());
        }
    }

}

