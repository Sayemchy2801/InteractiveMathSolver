using System;
using System.Linq;
using System.Windows.Forms;

namespace InteractiveMathSolver
{
    public partial class LcmForm : Form
    {
        // Form Controls
        private TextBox[] inputs;
        private Button lcmButton;
        private Label resultLabel;
        private Label instructionLabel; // Label for instructions
        
        public LcmForm()
        {
            // InitializeComponent();

            this.Text = "Find LCM";

            instructionLabel = new Label
            {
                Text = "Enter 2 numbers to find their LCM:",
                Location = new System.Drawing.Point(15, 15),
                Width = 750
            };
            this.Controls.Add(instructionLabel);

            inputs = new TextBox[2]; // for example, we're supporting 2 inputs
            for (int i = 0; i < 2; i++)
            {
                inputs[i] = new TextBox
                {
                    Location = new System.Drawing.Point(15, 45 + i * 30), // Start a bit lower to make room for instructions
                    Width = 200
                };
                this.Controls.Add(inputs[i]);
            }

            lcmButton = new Button
            {
                Text = "Find LCM",
                Location = new System.Drawing.Point(15, 105) // Position adjusted
            };
            lcmButton.Click += new EventHandler(LcmButton_Click);
            this.Controls.Add(lcmButton);

            resultLabel = new Label
            {
                Location = new System.Drawing.Point(15, 140), // Position adjusted
                Width = 200
            };
            this.Controls.Add(resultLabel);
        }

        private void LcmButton_Click(object sender, EventArgs e)
        {
            try
            {
                int[] numbers = inputs.Select(input => int.Parse(input.Text)).ToArray();
                int result = FindLCM(numbers[0], numbers[1]);
                resultLabel.Text = $"LCM is {result}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input! Please enter only integers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to calculate LCM
        private int FindLCM(int a, int b)
        {
            return a * (b / GCD(a, b));
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
