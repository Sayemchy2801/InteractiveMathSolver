using System;
using System.Windows.Forms;
using System.Linq;

namespace InteractiveMathSolver
{
    public partial class LinearEquationsForm : Form
    {
        // Form Controls
        private TextBox[] coefficients;
        private Button solveButton;
        private Label resultLabel;
        
        public LinearEquationsForm()
        {
            // InitializeComponent();

            this.Text = "Solve Linear Equations";
            this.Size = new System.Drawing.Size(800, 450);  // Adjust the size as per your requirement

            Label instructionLabel = new Label
            {
                Location = new System.Drawing.Point(15, 15),
                Width = 750,
                Text = "Enter the coefficients for the two linear equations in the format: a1, b1, c1, a2, b2, c2"
            };
            this.Controls.Add(instructionLabel);

            coefficients = new TextBox[6]; // we're supporting 6 inputs for 2 equations
            for (int i = 0; i < 6; i++)
            {
                coefficients[i] = new TextBox
                {
                    Location = new System.Drawing.Point(15, 75 + i * 30),
                    Width = 200
                };
                this.Controls.Add(coefficients[i]);
            }

            solveButton = new Button
            {
                Text = "Solve",
                Location = new System.Drawing.Point(15, 285)
            };
            solveButton.Click += new EventHandler(SolveButton_Click);
            this.Controls.Add(solveButton);

            resultLabel = new Label
            {
                Location = new System.Drawing.Point(15, 320),
                Width = 500,
                Height = 100
            };
            this.Controls.Add(resultLabel);
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            try
            {
                double[] coeffs = coefficients.Select(input => double.Parse(input.Text)).ToArray();
                double[] results = SolveLinearEquations(coeffs);
                resultLabel.Text = $"Solution: x = {results[0]}, y = {results[1]}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input! Please enter only numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to solve linear equations
        private double[] SolveLinearEquations(double[] coeffs)
        {
            // coeffs = [a1, b1, c1, a2, b2, c2] for equations a1*x + b1*y = c1 and a2*x + b2*y = c2
            double a1 = coeffs[0], b1 = coeffs[1], c1 = coeffs[2], a2 = coeffs[3], b2 = coeffs[4], c2 = coeffs[5];

            double det = a1 * b2 - a2 * b1;
            if (det == 0)
            {
                throw new Exception("No unique solution exists");
            }

            double x = (b2 * c1 - b1 * c2) / det;
            double y = (a1 * c2 - a2 * c1) / det;

            return new double[] { x, y };
        }
    }
}
