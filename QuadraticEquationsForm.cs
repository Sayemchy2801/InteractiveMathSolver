using System;
using System.Windows.Forms;

namespace InteractiveMathSolver
{
    public partial class QuadraticEquationsForm : Form
    {
        // Form Controls
        private TextBox coefficientA;
        private TextBox coefficientB;
        private TextBox coefficientC;
        private Button solveButton;
        private Label resultLabel;

        public QuadraticEquationsForm()
        {
            // InitializeComponent();

            this.Text = "Solve Quadratic Equations";
            this.Size = new System.Drawing.Size(800, 450);  // Adjust the size as per your requirement

            Label instructionLabel = new Label
            {
                Location = new System.Drawing.Point(15, 15),
                Width = 750,
                Text = "Enter the coefficients for the quadratic equation of the form ax^2 + bx + c = 0"
            };
            this.Controls.Add(instructionLabel);

            coefficientA = new TextBox
            {
                Location = new System.Drawing.Point(15, 75),
                Width = 200
            };
            this.Controls.Add(coefficientA);

            coefficientB = new TextBox
            {
                Location = new System.Drawing.Point(15, 105),
                Width = 200
            };
            this.Controls.Add(coefficientB);

            coefficientC = new TextBox
            {
                Location = new System.Drawing.Point(15, 135),
                Width = 200
            };
            this.Controls.Add(coefficientC);

            solveButton = new Button
            {
                Text = "Solve",
                Location = new System.Drawing.Point(15, 195)
            };
            solveButton.Click += new EventHandler(SolveButton_Click);
            this.Controls.Add(solveButton);

            resultLabel = new Label
            {
                Location = new System.Drawing.Point(15, 230),
                Width = 500,
                Height = 100
            };
            this.Controls.Add(resultLabel);
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(coefficientA.Text);
                double b = double.Parse(coefficientB.Text);
                double c = double.Parse(coefficientC.Text);

                double[] results = SolveQuadraticEquation(a, b, c);

                if (results.Length == 2)
                {
                    resultLabel.Text = $"Solutions: x = {results[0]}, x = {results[1]}";
                }
                else
                {
                    resultLabel.Text = $"Solution: x = {results[0]}";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input! Please enter only numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to solve quadratic equations
        private double[] SolveQuadraticEquation(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                throw new Exception("No real solutions exist");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                return new double[] { x };
            }
            else
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return new double[] { x1, x2 };
            }
        }
    }
}
