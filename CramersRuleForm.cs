using System;
using System.Windows.Forms;
using System.Linq;

namespace InteractiveMathSolver
{
    public partial class CramersRuleForm : Form
    {
        // Form Controls
        private TextBox[] coefficients;
        private TextBox[] results;
        private Button solveButton;
        private Label resultLabel;

        public CramersRuleForm()
        {
            // InitializeComponent();

            this.Text = "Solve System of Linear Equations";
            this.Size = new System.Drawing.Size(800, 450);  // Adjust the size as per your requirement

            Label instructionLabel = new Label
            {
                Location = new System.Drawing.Point(15, 15),
                Width = 750,
                Height = 100,
                Text = "Enter the coefficients and results for the system of linear equations\n" +
                       "For example, for 2 equations with 2 unknowns:\n" +
                       "a1x + b1y = c1\n" +
                       "a2x + b2y = c2\n" +
                       "Enter the coefficients and results separated by commas (,)\n" +
                       "For example, to enter the coefficients and results: a1,b1,c1,a2,b2,c2"
            };
            instructionLabel.TextAlign = ContentAlignment.TopLeft;
            this.Controls.Add(instructionLabel);

            coefficients = new TextBox[6]; // Maximum size for 2 equations with 2 unknowns
            results = new TextBox[2]; // Maximum size for 2 equations

            for (int i = 0; i < 6; i++)
            {
                coefficients[i] = new TextBox
                {
                    Location = new System.Drawing.Point(15, 125 + i * 30),
                    Width = 200
                };
                this.Controls.Add(coefficients[i]);
            }

            for (int i = 0; i < 2; i++)
            {
                results[i] = new TextBox
                {
                    Location = new System.Drawing.Point(235, 125 + i * 30),
                    Width = 100
                };
                this.Controls.Add(results[i]);
            }

            solveButton = new Button
            {
                Text = "Solve",
                Location = new System.Drawing.Point(15, 325)
            };
            solveButton.Click += new EventHandler(SolveButton_Click);
            this.Controls.Add(solveButton);

            resultLabel = new Label
            {
                Location = new System.Drawing.Point(15, 360),
                Width = 500,
                Height = 50
            };
            this.Controls.Add(resultLabel);
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            try
            {
                double[] coeffs = coefficients.Select(input => double.Parse(input.Text)).ToArray();
                double[] res = results.Select(input => double.Parse(input.Text)).ToArray();

                double[] unknowns = SolveSystemOfEquations(coeffs, res);

                if (unknowns.Length == 2)
                {
                    resultLabel.Text = $"Solutions: x = {unknowns[0]}, y = {unknowns[1]}";
                }
                else if (unknowns.Length == 3)
                {
                    resultLabel.Text = $"Solutions: x = {unknowns[0]}, y = {unknowns[1]}, z = {unknowns[2]}";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input! Please enter only numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to solve a system of linear equations using Cramer's rule
        private double[] SolveSystemOfEquations(double[] coeffs, double[] res)
        {
            int numEquations = res.Length;
            int numUnknowns = coeffs.Length / numEquations;

            if (coeffs.Length % numEquations != 0)
            {
                throw new Exception("Invalid input! Number of coefficients must be divisible by the number of equations.");
            }

            double[,] matrix = new double[numEquations, numUnknowns];

            for (int i = 0; i < numEquations; i++)
            {
                for (int j = 0; j < numUnknowns; j++)
                {
                    matrix[i, j] = coeffs[i * numUnknowns + j];
                }
            }

            double determinant = CalculateDeterminant(matrix);

            if (determinant == 0)
            {
                throw new Exception("No unique solution exists");
            }

            double[] unknowns = new double[numUnknowns];

            for (int i = 0; i < numUnknowns; i++)
            {
                double[,] subMatrix = new double[numEquations, numUnknowns];

                for (int j = 0; j < numEquations; j++)
                {
                    for (int k = 0; k < numUnknowns; k++)
                    {
                        if (k == i)
                        {
                            subMatrix[j, k] = res[j];
                        }
                        else
                        {
                            subMatrix[j, k] = matrix[j, k];
                        }
                    }
                }

                unknowns[i] = CalculateDeterminant(subMatrix) / determinant;
            }

            return unknowns;
        }

        // Function to calculate determinant of a matrix
        private double CalculateDeterminant(double[,] matrix)
        {
            int size = matrix.GetLength(0);

            if (size != matrix.GetLength(1))
            {
                throw new Exception("Invalid matrix! Number of rows must be equal to the number of columns.");
            }

            if (size == 1)
            {
                return matrix[0, 0];
            }
            else if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double determinant = 0;

                for (int i = 0; i < size; i++)
                {
                    double[,] subMatrix = new double[size - 1, size - 1];

                    for (int j = 1; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (k < i)
                            {
                                subMatrix[j - 1, k] = matrix[j, k];
                            }
                            else if (k > i)
                            {
                                subMatrix[j - 1, k - 1] = matrix[j, k];
                            }
                        }
                    }

                    int sign = (i % 2 == 0) ? 1 : -1;
                    determinant += sign * matrix[0, i] * CalculateDeterminant(subMatrix);
                }

                return determinant;
            }
        }
    }
}
