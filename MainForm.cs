using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FishingFleetQuotaApp
{
    public partial class MainForm : Form
    {
        private ComboBox boatComboBox;
        private Label nameLabel;
        private TextBox nameTextBox;
        private Label licenseLabel;
        private TextBox licenseTextBox;
        private Label loadSizeLabel;
        private TextBox loadSizeTextBox;
        private ListBox speciesListBox;
        private Button addBoatButton;
        private Button viewBoatsButton;
        private Button addCatchButton;
        private Label speciesLabel;
        private TextBox catchTextBox;
        private ListBox catchListBox;
        private Button calculateQuotaButton;
        private Label quotaLabel;
        private ListBox quotaListBox;
        private RadioButton kgRadioButton;
        private RadioButton tonnesRadioButton;

        private List<Boat> boats;
        private List<string> speciesList;

        public MainForm()
        {
            InitializeComponent();
            boats = new List<Boat>();
            speciesList = new List<string>() { "Cod", "Salmon", "Tuna", "Snapper" };
            InitializeSpeciesList();
        }

        private void InitializeComponent()
        {

            // Species ListBox
            this.speciesListBox = new ListBox();
            this.speciesListBox.Location = new System.Drawing.Point(20, 180);
            this.speciesListBox.Size = new System.Drawing.Size(200, 100);
            this.speciesListBox.SelectionMode = SelectionMode.MultiSimple;
            
            // Add controls to the form
            this.boatComboBox = new ComboBox();
            this.nameLabel = new Label();
            this.nameTextBox = new TextBox();
            this.licenseLabel = new Label();
            this.licenseTextBox = new TextBox();
            this.loadSizeLabel = new Label();
            this.loadSizeTextBox = new TextBox();
            this.speciesListBox = new ListBox();
            this.addBoatButton = new Button();
            this.viewBoatsButton = new Button();
            this.addCatchButton = new Button();
            this.speciesLabel = new Label();
            this.catchTextBox = new TextBox();
            this.catchListBox = new ListBox();
            this.calculateQuotaButton = new Button();
            this.quotaLabel = new Label();
            this.quotaListBox = new ListBox();
            this.kgRadioButton = new RadioButton();
            this.tonnesRadioButton = new RadioButton();

            this.SuspendLayout();

            // MainForm
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Fishing Fleet Quota App";

            // Boat ComboBox
            this.boatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.boatComboBox.Location = new System.Drawing.Point(20, 20);
            this.boatComboBox.Size = new System.Drawing.Size(200, 25);
            this.boatComboBox.SelectedIndexChanged += new EventHandler(BoatComboBox_SelectedIndexChanged);

            // Name Label
            this.nameLabel.Text = "Name:";
            this.nameLabel.Location = new System.Drawing.Point(20, 60);
            this.nameLabel.AutoSize = true;

            // Name TextBox
            this.nameTextBox.Location = new System.Drawing.Point(120, 60);
            this.nameTextBox.Size = new System.Drawing.Size(200, 25);

            // License Label
            this.licenseLabel.Text = "License Number:";
            this.licenseLabel.Location = new System.Drawing.Point(20, 100);
            this.licenseLabel.AutoSize = true;

            // License TextBox
            this.licenseTextBox.Location = new System.Drawing.Point(120, 100);
            this.licenseTextBox.Size = new System.Drawing.Size(200, 25);

            // Load Size Label
            this.loadSizeLabel.Text = "Max Load Size (kg or tonnes):";
            this.loadSizeLabel.Location = new System.Drawing.Point(20, 140);
            this.loadSizeLabel.AutoSize = true;

            // Load Size TextBox
            this.loadSizeTextBox.Location = new System.Drawing.Point(200, 140);
            this.loadSizeTextBox.Size = new System.Drawing.Size(120, 25);

            // Species ListBox
            this.speciesListBox.Location = new System.Drawing.Point(20, 180);
            this.speciesListBox.Size = new System.Drawing.Size(200, 100);
            this.speciesListBox.SelectionMode = SelectionMode.MultiSimple;

            // Add Boat Button
            this.addBoatButton.Text = "Add Boat";
            this.addBoatButton.Location = new System.Drawing.Point(20, 300);
            this.addBoatButton.Size = new System.Drawing.Size(100, 30);
            this.addBoatButton.Click += new EventHandler(AddBoatButton_Click);

            // View Boats Button
            this.viewBoatsButton.Text = "View Boats";
            this.viewBoatsButton.Location = new System.Drawing.Point(140, 300);
            this.viewBoatsButton.Size = new System.Drawing.Size(100, 30);
            this.viewBoatsButton.Click += new EventHandler(ViewBoatsButton_Click);

            // Add Catch Button
            this.addCatchButton.Text = "Add Catch";
            this.addCatchButton.Location = new System.Drawing.Point(20, 340);
            this.addCatchButton.Size = new System.Drawing.Size(100, 30);
            this.addCatchButton.Click += new EventHandler(AddCatchButton_Click);

            // Species Label
            this.speciesLabel.Text = "Species:";
            this.speciesLabel.Location = new System.Drawing.Point(20, 160);
            this.speciesLabel.AutoSize = true;

            // Catch TextBox
            this.catchTextBox.Location = new System.Drawing.Point(140, 340);
            this.catchTextBox.Size = new System.Drawing.Size(80, 25);

            // Catch ListBox
            this.catchListBox.Location = new System.Drawing.Point(20, 380);
            this.catchListBox.Size = new System.Drawing.Size(320, 100);

            // Calculate Quota Button
            this.calculateQuotaButton.Text = "Calculate Quota";
            this.calculateQuotaButton.Location = new System.Drawing.Point(20, 500);
            this.calculateQuotaButton.Size = new System.Drawing.Size(120, 30);
            this.calculateQuotaButton.Click += new EventHandler(CalculateQuotaButton_Click);

            // Quota Label
            this.quotaLabel.Text = "Quota:";
            this.quotaLabel.Location = new System.Drawing.Point(20, 540);
            this.quotaLabel.AutoSize = true;

            // Quota ListBox
            this.quotaListBox.Location = new System.Drawing.Point(20, 570);
            this.quotaListBox.Size = new System.Drawing.Size(320, 100);

            // KG RadioButton
            this.kgRadioButton.Text = "KG";
            this.kgRadioButton.Location = new System.Drawing.Point(20, 670);
            this.kgRadioButton.AutoSize = true;

            // Tonnes RadioButton
            this.tonnesRadioButton.Text = "Tonnes";
            this.tonnesRadioButton.Location = new System.Drawing.Point(70, 670);
            this.tonnesRadioButton.AutoSize = true;

            // Add controls to the form
            this.Controls.Add(this.boatComboBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.licenseLabel);
            this.Controls.Add(this.licenseTextBox);
            this.Controls.Add(this.loadSizeLabel);
            this.Controls.Add(this.loadSizeTextBox);
            this.Controls.Add(this.speciesListBox);
            this.Controls.Add(this.addBoatButton);
            this.Controls.Add(this.viewBoatsButton);
            this.Controls.Add(this.addCatchButton);
            this.Controls.Add(this.speciesLabel);
            this.Controls.Add(this.catchTextBox);
            this.Controls.Add(this.catchListBox);
            this.Controls.Add(this.calculateQuotaButton);
            this.Controls.Add(this.quotaLabel);
            this.Controls.Add(this.quotaListBox);
            this.Controls.Add(this.kgRadioButton);
            this.Controls.Add(this.tonnesRadioButton);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeSpeciesList()
        {
            foreach (string species in speciesList)
            {
                speciesListBox.Items.Add(species);
            }
        }

        private void AddBoatButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string licenseNumber = licenseTextBox.Text;
            string loadSize = loadSizeTextBox.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(licenseNumber) || string.IsNullOrEmpty(loadSize))
            {
                MessageBox.Show("Please enter all boat details.");
                return;
            }

            Boat boat = new Boat(name, licenseNumber, loadSize);
            boats.Add(boat);
            boatComboBox.Items.Add(boat);
            ClearBoatFields();
        }

        private void ViewBoatsButton_Click(object sender, EventArgs e)
        {
            if (boats.Count == 0)
            {
                MessageBox.Show("No boats added.");
                return;
            }

            string boatDetails = string.Join("\n", boats);
            MessageBox.Show($"Number of boats: {boats.Count}\n\nBoat Details:\n{boatDetails}");
        }

        private void AddCatchButton_Click(object sender, EventArgs e)
        {
            Boat selectedBoat = (Boat)boatComboBox.SelectedItem;
            if (selectedBoat == null)
            {
                MessageBox.Show("Please select a boat.");
                return;
            }

            string species = speciesListBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(species))
            {
                MessageBox.Show("Please select one or more species.");
                return;
            }

            if (!double.TryParse(catchTextBox.Text, out double weight))
            {
                MessageBox.Show("Please enter a valid catch weight.");
                return;
            }

            selectedBoat.AddCatch(species, weight);
            catchListBox.Items.Add($"{selectedBoat.Name} - Species: {species} - Weight: {weight} {(kgRadioButton.Checked ? "KG" : "Tonnes")}");

            ClearCatchFields();
        }

        private void CalculateQuotaButton_Click(object sender, EventArgs e)
        {
            Boat selectedBoat = (Boat)boatComboBox.SelectedItem;
            if (selectedBoat == null)
            {
                MessageBox.Show("Please select a boat.");
                return;
            }

            Dictionary<string, double> catchSummary = selectedBoat.GetCatchSummary();

            double totalQuota = 0;
            quotaListBox.Items.Clear();
            foreach (KeyValuePair<string, double> entry in catchSummary)
            {
                string species = entry.Key;
                double weight = entry.Value;
                double quota = selectedBoat.GetQuota(species);
                totalQuota += quota;

                quotaListBox.Items.Add($"{species} caught = {weight} {(kgRadioButton.Checked ? "KG" : "Tonnes")} | Quota = {quota} {(kgRadioButton.Checked ? "KG" : "Tonnes")}");
            }

            quotaListBox.Items.Add($"Total Quota: {totalQuota} {(kgRadioButton.Checked ? "KG" : "Tonnes")}");
        }

        private void ClearBoatFields()
        {
            nameTextBox.Text = string.Empty;
            licenseTextBox.Text = string.Empty;
            loadSizeTextBox.Text = string.Empty;
        }

        private void ClearCatchFields()
        {
            catchTextBox.Text = string.Empty;
        }

        private void BoatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boat selectedBoat = (Boat)boatComboBox.SelectedItem;
            if (selectedBoat == null)
                return;

            catchListBox.Items.Clear();
            catchListBox.Items.Add($"Selected Boat: {selectedBoat.Name}\nLicense Number: {selectedBoat.LicenseNumber}\nLoad Size: {selectedBoat.LoadSize}");
        }
    }

    public class Boat
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public string LoadSize { get; set; }
        public Dictionary<string, double> Catch { get; set; }

        public Boat(string name, string licenseNumber, string loadSize)
        {
            Name = name;
            LicenseNumber = licenseNumber;
            LoadSize = loadSize;
            Catch = new Dictionary<string, double>();
        }

        public void AddCatch(string species, double weight)
        {
            if (Catch.ContainsKey(species))
            {
                Catch[species] += weight;
            }
            else
            {
                Catch.Add(species, weight);
            }
        }

        public Dictionary<string, double> GetCatchSummary()
        {
            return Catch;
        }

        public double GetQuota(string species)
        {
            // Placeholder implementation
            switch (species)
            {
                case "Cod":
                    return 4.0; // Assuming a quota of 4 tonnes for Cod
                case "Salmon":
                    return 2.5; // Assuming a quota of 2.5 tonnes for Salmon
                case "Tuna":
                    return 3.0; // Assuming a quota of 3 tonnes for Tuna
                case "Snapper":
                    return 1.8; // Assuming a quota of 1.8 tonnes for Snapper
                default:
                    return 0; // If the species is not found or quota information is missing, return 0
            }
        }

        public override string ToString()
        {
            return $"{Name} - License Number: {LicenseNumber} - Load Size: {LoadSize}";
        }
    }
}
