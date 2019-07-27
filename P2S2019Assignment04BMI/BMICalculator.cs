using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2S2019Assignment04BMI
{
    //Name: Shemar Stcyr Student number: 301037086 Data: 7/26/29 Discription: BMI Calculator 
    public partial class BMICalculatorForm : Form
    {
        public string outputString { get; set; }
        public bool decimalExists { get; set; }
        public float outputValue { get; set; }
        public bool heighttxt { get; set; }
        public bool weighttext { get; set; }

        public string units { get; set; }

        public string bmiscale { get; set; }
        // public double bmi { get; set; }

        public BMICalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            var TheButton = sender as Button;
            var tag = TheButton.Tag.ToString();

            int buttonValue;
            bool resultCondition = int.TryParse(tag, out buttonValue);

            // If the use pressed a number button
            if (resultCondition)
            {
                int maxSize = 3;
                if (decimalExists)
                {
                    maxSize = 5;
                }

                if ((outputString != "0") && (ResultLabel.Text.Count() < maxSize))
                {
                    outputString += tag;
                    ResultLabel.Text = outputString;
                }
            }

            // if the user pressed a button that is not a number
            if (!resultCondition)
            {
                switch (tag)
                {
                    case "clear":
                        clearNumericKeyboard();
                        break;

                    case "back":
                        removeLastCharacterFromResultLabel();
                        break;

                    case "done":
                        finalizeOutput();
                        break;

                    case "decimal":
                        addDecimalToResultLabel();
                        break;
                }
            }
        }

        private void finalizeOutput()
        {
            if (outputString == string.Empty)
            {
                outputString = "0";
            }
            outputValue = float.Parse(outputString);
            if (heighttxt == true)
            {
                Heighttext.Text = outputValue.ToString();
                heighttxt = false;
            }
            if (weighttext == true)
            {
                Weighttext.Text = outputValue.ToString();
                weighttext = false;
            }
            clearNumericKeyboard();
            CalculatorButtonTableLayoutPanel.Visible = false;
        }

        private void removeLastCharacterFromResultLabel()
        {
            if (outputString.Length > 0)
            {
                var lastChar = outputString.Substring(outputString.Length - 1);
                if (lastChar == ".")
                {
                    decimalExists = false;
                }
                outputString = outputString.Remove(outputString.Length - 1);

                if (outputString.Length == 0)
                {
                    outputString = "0";
                }
                ResultLabel.Text = outputString;
            }
        }

        private void clearNumericKeyboard()
        {
            ResultLabel.Text = "0";
            outputString = String.Empty;
            decimalExists = false;
            outputValue = 0.0f;
        }

        private void Heighttext_Click(object sender, EventArgs e)
        {
            heighttxt = true;
            CalculatorButtonTableLayoutPanel.Visible = true;
        }

        private void addDecimalToResultLabel()
        {
            if (!decimalExists)
            {
                outputString += ".";
                decimalExists = true;
            }
        }

        private void BMICalculator_Load(object sender, EventArgs e)
        {
            clearNumericKeyboard();
        }

        private void Weighttext_Click(object sender, EventArgs e)
        {
            weighttext = true;
            CalculatorButtonTableLayoutPanel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BmiCalculateLayout.Visible = true;
            //ResultLabel.Visible = true;
            double weight = double.Parse(Weighttext.Text);
            double height = double.Parse(Heighttext.Text);
            if (units == "metric" && weight > 0 && height > 0)
            {
                double bmi = weight / (height * height);
                //double bmi = metric;
                if (18.5 > bmi)
                {
                    bmiscale = "Underweight";
                }
                if (bmi >= 18.5 && 24.9 > bmi)
                {
                    bmiscale = "Normal";
                }
                if (bmi >= 25 && 29.9 > bmi)
                {
                    bmiscale = "Overweight";
                }
                if (30 >= bmi && bmi > 29.9)
                {
                    bmiscale = "Obese";
                }
                BMILabeltxt.Text = bmi.ToString() + " " + bmiscale;
            }
            if (units == "imperial" && weight > 0 && height > 0)
            {
                double bmi = weight * 703 / (height * height);

                if (18.5 > bmi)
                {
                    bmiscale = "Underweight";
                }
                if (bmi >= 18.5 && bmi > 24.9)
                {
                    bmiscale = "Normal";
                }
                if (bmi >= 25 && 29.9 > bmi)
                {
                    bmiscale = "Overweight";
                }
                if (30 >= bmi && bmi > 29.9)
                {
                    bmiscale = "Obese";
                }
                BMILabeltxt.Text = bmiscale + " " + bmi.ToString();
            }
            else
            {
               // Application.Exit();
            }
        }

        private void MetricButton_CheckedChanged(object sender, EventArgs e)
        {
            Calculatebutton.Visible = true;
            units = "metric";
        }

        private void ImperialButton_CheckedChanged(object sender, EventArgs e)
        {
            Calculatebutton.Visible = true;
            units = "imperial";
        }

        //private void CalculatorButtonTableLayoutPanel_Click(object sender, EventArgs e)
        //{
        //    var TheButton = sender as Button;
        //    var tag = TheButton.Tag.ToString();

        //    int buttonValue;
        //    bool resultCondition = int.TryParse(tag, out buttonValue);

        //    // If the use pressed a number button
        //    if (resultCondition)
        //    {
        //        int maxSize = 3;
        //        if (decimalExists)
        //        {
        //            maxSize = 5;
        //        }

        //        if ((outputString != "0") && (ResultLabel.Text.Count() < maxSize))
        //        {
        //            outputString += tag;
        //            ResultLabel.Text = outputString;
        //        }
        //    }

        //    // if the user pressed a button that is not a number
        //    if (!resultCondition)
        //    {
        //        switch (tag)
        //        {
        //            case "clear":
        //                clearNumericKeyboard();
        //                break;

        //            case "back":
        //                removeLastCharacterFromResultLabel();
        //                break;

        //            case "done":
        //                finalizeOutput();
        //                break;

        //            case "decimal":
        //                addDecimalToResultLabel();
        //                break;
        //        }
        //    }
        //}
    }
}