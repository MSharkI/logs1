using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace logs
{
    public partial class Form1 : Form
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                int intValue = Convert.ToInt32(intTextBox.Text);
                DateTime dateValue = Convert.ToDateTime(dateTextBox.Text);
                char charValue = Convert.ToChar(charTextBox.Text);

                MessageBox.Show($"Целое число: {intValue}\nДата: {dateValue}\nСимвол: {charValue}", "Успех");
            }
            catch (FormatException ex)
            {
                logger.Error(ex, "Ошибка формата. Пожалуйста, введите корректные значения.");
                throw;
            }
            catch (OverflowException ex)
            {
                logger.Error(ex, "Ошибка переполнения. Пожалуйста, введите более подходящие значения.");
                throw;
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Произошла ошибка: {0}", ex.Message);
            }
        }
    }
}
