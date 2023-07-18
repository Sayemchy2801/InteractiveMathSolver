using System;
using System.Windows.Forms;
using System.Linq;

namespace InteractiveMathSolver
{
public partial class GcdForm : Form
{
    // Form Controls
    private TextBox[] inputs;
    private Button gcdButton;
    private Label resultLabel;
    private Label instructionLabel; // New label for instructions
    
    public GcdForm()
    {
        // InitializeComponent();

        this.Text = "Find GCD";

        instructionLabel = new Label
        {
            Text = "Enter up to 5 numbers to find their GCD:",
            Location = new System.Drawing.Point(15, 15),
            Width = 750
        };
        this.Controls.Add(instructionLabel);

        inputs = new TextBox[5]; // for example, we're supporting 5 inputs
        for (int i = 0; i < 5; i++)
        {
            inputs[i] = new TextBox
            {
                Location = new System.Drawing.Point(15, 45 + i * 30), // Start a bit lower to make room for instructions
                Width = 200
            };
            this.Controls.Add(inputs[i]);
        }

        gcdButton = new Button
        {
            Text = "Find GCD",
            Location = new System.Drawing.Point(15, 195) // Position adjusted
        };
        gcdButton.Click += new EventHandler(GcdButton_Click);
        this.Controls.Add(gcdButton);

        resultLabel = new Label
        {
            Location = new System.Drawing.Point(15, 230), // Position adjusted
            Width = 200
        };
        this.Controls.Add(resultLabel);
    }
        private void GcdButton_Click(object sender, EventArgs e)
        {
            try
            {
                int[] numbers = inputs.Select(input => int.Parse(input.Text)).ToArray();
                int result = FindGCD(numbers);
                resultLabel.Text = $"GCD is {result}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input! Please enter only integers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to calculate GCD
        private int FindGCD(params int[] numbers)
        {
            return numbers.Aggregate((a, b) => GCD(a, b));
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
