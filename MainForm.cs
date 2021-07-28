using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExchangeParserNBU
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
            // ParserNBU.WriteInFileAllCurrency();
        }

        private void ShowGraph()
        {
            // autoclearing
            Graph1.Series[0].Points.Clear();
            Graph2.Series[0].Points.Clear();

            // days
            double[] x = { 1, 2, 3, 4, 5, 6, 7 };
            double[] y1 = { Convert.ToDouble(labelCurrency1_1.Text),
                            Convert.ToDouble(labelCurrency1_2.Text),
                            Convert.ToDouble(labelCurrency1_3.Text),
                            Convert.ToDouble(labelCurrency1_4.Text),
                            Convert.ToDouble(labelCurrency1_5.Text),
                            Convert.ToDouble(labelCurrency1_6.Text),
                            Convert.ToDouble(labelCurrency1_7.Text),
                          };
            double[] y2 = { Convert.ToDouble(labelCurrency2_1.Text),
                            Convert.ToDouble(labelCurrency2_2.Text),
                            Convert.ToDouble(labelCurrency2_3.Text),
                            Convert.ToDouble(labelCurrency2_4.Text),
                            Convert.ToDouble(labelCurrency2_5.Text),
                            Convert.ToDouble(labelCurrency2_6.Text),
                            Convert.ToDouble(labelCurrency2_7.Text),
                          };

            // Setup for the first Graph
            Graph1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(labelMinCur1.Text); 
            Graph1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(labelMaxCur1.Text);

            Graph1.ChartAreas[0].AxisX.Minimum = 1;
            Graph1.ChartAreas[0].AxisX.Maximum = 7;

            Graph1.Series[0].Name = labelCurrency1.Text;

            this.Graph1.Series[0].BorderWidth = 4;
            // Setup for the second Graph


            Graph2.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(labelMinCur2.Text);
            Graph2.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(labelMaxCur2.Text);

            Graph2.ChartAreas[0].AxisX.Minimum = 1;
            Graph2.ChartAreas[0].AxisX.Maximum = 7;

            Graph2.Series[0].Name = labelCurrency2.Text;

            this.Graph2.Series[0].BorderWidth = 4;

            for (int i = 0; i < 7; i++)
            {
                this.Graph1.Series[0].Points.AddXY(x[i], y1[i]);
                this.Graph2.Series[0].Points.AddXY(x[i], y2[i]);
            }
            //this.Graph.Series[1].Points.AddXY(x, (-Math.Pow(x, 2) + 2 * x));
            
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = comboBox_First.SelectedItem.ToString();
                string ID2 = comboBox_Second.SelectedItem.ToString();

                try
                {
                    
                    labelCurrency1_1.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID, labelDate1.Text)).ToString();
                    labelCurrency1_2.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID, labelDate2.Text)).ToString();
                    labelCurrency1_3.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID, labelDate3.Text)).ToString();
                    labelCurrency1_4.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID, labelDate4.Text)).ToString();
                    labelCurrency1_5.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID, labelDate5.Text)).ToString();
                    labelCurrency1_6.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID, labelDate6.Text)).ToString();
                    labelCurrency1_7.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID, labelDate7.Text)).ToString();


                    labelCurrency2_1.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID2, labelDate1.Text)).ToString();
                    labelCurrency2_2.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID2, labelDate2.Text)).ToString();
                    labelCurrency2_3.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID2, labelDate3.Text)).ToString();
                    labelCurrency2_4.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID2, labelDate4.Text)).ToString();
                    labelCurrency2_5.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID2, labelDate5.Text)).ToString();
                    labelCurrency2_6.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID2, labelDate6.Text)).ToString();
                    labelCurrency2_7.Text = Exchange.ParsedExchangeCourse(ParserNBU.Parse(ID2, labelDate7.Text)).ToString();

                    try
                    {
                        MinMaxDefinition();

                        try
                        {
                            AfterDataLabelChangeCoords();
                            ShowGraph();
                        }
                        catch
                        {
                            MessageBox.Show(
                                   "Graph creation error!",
                                   "Error!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show(
                       "Min/max defitinion error!",
                       "Error!");
                    }
                    
                }
                catch
                {
                    MessageBox.Show(
                   "Choose correct date!",
                   "Error!");
                }

            } 
            catch
            {
                MessageBox.Show(
                "Choose both currencies!",
                "Error!");
            }
        }

        private void MinMaxDefinition()
        {
            List<double> currencyList = new List<double>();


            currencyList.Add(Convert.ToDouble(labelCurrency1_1.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency1_2.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency1_3.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency1_4.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency1_5.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency1_6.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency1_7.Text));

            labelMaxCur1.Text = currencyList.Max().ToString();
            labelMinCur1.Text = currencyList.Min().ToString();

            currencyList.Clear();

            currencyList.Add(Convert.ToDouble(labelCurrency2_1.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency2_2.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency2_3.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency2_4.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency2_5.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency2_6.Text));
            currencyList.Add(Convert.ToDouble(labelCurrency2_7.Text));

            labelMaxCur2.Text = currencyList.Max().ToString();
            labelMinCur2.Text = currencyList.Min().ToString();

            currencyList.Clear();

            labelCurrency1.Text = comboBox_First.SelectedItem.ToString();
            labelCurrency2.Text = comboBox_Second.SelectedItem.ToString();



        }
        private void ChangeDaysByCalendar(object sender, EventArgs e)
        {
            labelDate1.Text = DateTimePicker.Value.ToShortDateString();
            labelDate2.Text = DateTimePicker.Value.AddDays(1).ToShortDateString();
            labelDate3.Text = DateTimePicker.Value.AddDays(2).ToShortDateString();
            labelDate4.Text = DateTimePicker.Value.AddDays(3).ToShortDateString();
            labelDate5.Text = DateTimePicker.Value.AddDays(4).ToShortDateString();
            labelDate6.Text = DateTimePicker.Value.AddDays(5).ToShortDateString();
            labelDate7.Text = DateTimePicker.Value.AddDays(6).ToShortDateString();
        }

        private void AfterDataLabelChangeCoords()
        {
            labelCurrency1_1.Location = new Point(214, labelCurrency1_1.Location.Y);
            labelCurrency1_2.Location = new Point(214, labelCurrency1_2.Location.Y);
            labelCurrency1_3.Location = new Point(214, labelCurrency1_3.Location.Y);
            labelCurrency1_4.Location = new Point(214, labelCurrency1_4.Location.Y);
            labelCurrency1_5.Location = new Point(214, labelCurrency1_5.Location.Y);
            labelCurrency1_6.Location = new Point(214, labelCurrency1_6.Location.Y);
            labelCurrency1_7.Location = new Point(214, labelCurrency1_7.Location.Y);

            labelCurrency2_1.Location = new Point(399, labelCurrency2_1.Location.Y);
            labelCurrency2_2.Location = new Point(399, labelCurrency2_2.Location.Y);
            labelCurrency2_3.Location = new Point(399, labelCurrency2_3.Location.Y);
            labelCurrency2_4.Location = new Point(399, labelCurrency2_4.Location.Y);
            labelCurrency2_5.Location = new Point(399, labelCurrency2_5.Location.Y);
            labelCurrency2_6.Location = new Point(399, labelCurrency2_6.Location.Y);
            labelCurrency2_7.Location = new Point(399, labelCurrency2_7.Location.Y);

            labelMaxCur1.Location = new Point(130, labelMaxCur1.Location.Y);
            labelMaxCur2.Location = new Point(130, labelMaxCur2.Location.Y);
            labelMinCur1.Location = new Point(250, labelMinCur1.Location.Y);
            labelMinCur2.Location = new Point(250, labelMinCur2.Location.Y);

            labelCurrency1.Location = new Point(30, labelCurrency1.Location.Y);
            labelCurrency2.Location = new Point(30, labelCurrency2.Location.Y);
        }

    }
}
