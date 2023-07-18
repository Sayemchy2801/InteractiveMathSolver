using System;
using System.Windows.Forms;

namespace InteractiveMathSolver
{
    public partial class DeterminantForm : Form
    {
        // Form Controls
        private TextBox[,] matrixInputs;
        private Button calculateButton;
        private Label resultLabel;

        public DeterminantForm()
        {
            // InitializeComponent();

            this.Text = "Find Determinant";
            this.Size = new System.Drawing.Size(800, 450);  // Adjust the size as per your requirement

            Label instructionLabel = new Label
            {
                Location = new System.Drawing.Point(15, 15),
                Width = 750,
                Text = "Enter the elements of the matrix, For example, to enter a 2x2 matrix: a,b,c,d"
            };
            this.Controls.Add(instructionLabel);

            matrixInputs = new TextBox[4, 4]; // Maximum size of 4x4 matrix
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrixInputs[i, j] = new TextBox
                    {
                        Location = new System.Drawing.Point(15 + j * 80, 75 + i * 30),
                        Width = 60
                    };
                    this.Controls.Add(matrixInputs[i, j]);
                }
            }

            calculateButton = new Button
            {
                Text = "Calculate",
                Location = new System.Drawing.Point(15, 255)
            };
            calculateButton.Click += new EventHandler(CalculateButton_Click);
            this.Controls.Add(calculateButton);

            resultLabel = new Label
            {
                Location = new System.Drawing.Point(15, 290),
                Width = 500,
                Height = 100
            };
            this.Controls.Add(resultLabel);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                int[,] matrix = new int[4, 4]; // Maximum size of 4x4 matrix

                for (int i = 0; i < matrixInputs.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixInputs.GetLength(1); j++)
                    {
                        matrix[i, j] = int.Parse(matrixInputs[i, j].Text);
                    }
                }

                int determinant = CalculateDeterminant(matrix);

                resultLabel.Text = $"Determinant: {determinant}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input! Please enter only integers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to calculate determinant of a matrix
        private int CalculateDeterminant(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            if (size != matrix.GetLength(1))
            {
                throw new Exception("Invalid matrix! Number of rows must be equal to number of columns.");
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
                int determinant = 0;

                for (int i = 0; i < size; i++)
                {
                    int[,] subMatrix = new int[size - 1, size - 1];

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
