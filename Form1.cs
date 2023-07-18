using System;
using System.Windows.Forms;

namespace InteractiveMathSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "Interactive Math Solver";

            Button gcdButton = new Button
            {
                Text = "Find GCD",
                Location = new System.Drawing.Point(30, 30),
                Width = 200 

            };
            gcdButton.Click += (sender, e) => { new GcdForm().Show(); };
            this.Controls.Add(gcdButton);

            Button lcmButton = new Button
            {
                Text = "Find LCM",
                Location = new System.Drawing.Point(30, 70),
                Width = 200 

            };
            lcmButton.Click += (sender, e) => { new LcmForm().Show(); };
            this.Controls.Add(lcmButton);

            Button linearEqButton = new Button
            {
                Text = "Solve Linear Equations",
                Location = new System.Drawing.Point(30, 110),
                Width = 200 

            };
            linearEqButton.Click += (sender, e) => { new LinearEquationsForm().Show(); };
            this.Controls.Add(linearEqButton);

            Button quadraticEquationsButton = new Button
            {
                Text = "Solve Quadratic Equations",
                Location = new System.Drawing.Point(30, 150),
                Width = 200 

            };
            quadraticEquationsButton.Click += (sender, e) => { new QuadraticEquationsForm().Show(); };
            this.Controls.Add(quadraticEquationsButton);

            Button determinantButton = new Button
            {
                Text = "Find Determinant",
                Location = new System.Drawing.Point(30, 190),
                Width = 200 

            };
            determinantButton.Click += (sender, e) => { new DeterminantForm().Show(); };
            this.Controls.Add(determinantButton);

            Button cramerRuleButton = new Button
            {
                Text = "Solve Linear Equations using Cramer's Rule",
                Location = new System.Drawing.Point(30, 230),
                Width = 200 

            };
            cramerRuleButton.Click += (sender, e) => { new CramersRuleForm().Show(); };
            this.Controls.Add(cramerRuleButton);
        }
    }
}
