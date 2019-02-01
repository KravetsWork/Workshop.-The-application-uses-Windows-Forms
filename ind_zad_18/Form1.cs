using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ind_zad_18
{
    [Serializable]
    public partial class Form1 : Form
    {
        public string ERROR = "An error occurred!\n";
        public string MyExceptionError = "Вы не выбрали элемент(Исключение перехвачено классом MyExceptions)";
        List<Workshop> wShop = new List<Workshop>();
        Lumber lumber = new Lumber();
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            groupBoxWorkshop.BackColor = Color.Transparent;
            groupBox1.BackColor = Color.Transparent;
            groupBox2.BackColor = Color.Transparent;
            groupBoxLumber.BackColor = Color.Transparent;
            buttonAddWorkshop.Enabled = false;
            buttonAddWood.Enabled = false;
            ToolTip tooltip1 = new ToolTip();
            tooltip1.SetToolTip(this.buttonDeleteWorkshop, "Удалить выбранную мастерскую!");
            tooltip1.SetToolTip(this.buttonDeleteLumber, "Удалить выбранный пиломатериал!");
            tooltip1.SetToolTip(this.buttonDeleteAll, "Удалить все!");
            tooltip1.SetToolTip(this.buttonExit, "Выход из программы!");
            tooltip1.SetToolTip(this.buttonCompareCost, "Сравнить цены пиломатериалов!");
        }

        #region MyExceptions

        private void buttonAddWood_Click(object sender, EventArgs e)
        {
            try
            {
                int mark = rand.Next(10000000, 100000000);
                int amountOfWood = Convert.ToInt32(textBoxAmountOfWood.Text);
                int price = Convert.ToInt32(comboBoxWood.Text.Substring(37, 2));
                int selectedWorkshop = listBoxWorkshop.SelectedIndex;

                if (selectedWorkshop == -1) // если не выбрана мастерская - выбрасываем исключение 
                {
                    throw new MyExceptions(MyExceptionError);
                }

                int day = Convert.ToInt32(dateTimePicker1.Text.Substring(0, 2));
                int month = Convert.ToInt32(dateTimePicker1.Text.Substring(3, 2));
                int year = Convert.ToInt32(dateTimePicker1.Text.Substring(6, 4));
                DateTime date1 = new DateTime(year, month, day, 12, 0, 0);

                SawingOptions so = SawingOptions.пусто;

                switch (comboBoxSavingOptions.SelectedIndex)
                {
                    case 0: so = SawingOptions.брус; break;
                    case 1: so = SawingOptions.доска_необрезанная; break;
                    case 2: so = SawingOptions.доска_обрезанная; break;
                    case 3: so = SawingOptions.рейка; break;
                }

                Lumber lm = new Lumber(comboBoxWood.Text.Substring(3, 10), comboBoxWood.Text.Substring(17, 4), comboBoxWood.Text.Substring(25, 8), amountOfWood, date1, so, mark, price);

                wShop[selectedWorkshop].AddLumber(lm);
                EnterLumber();               
            }
            catch (MyExceptions ex)
            {
                show(ex.Message);
            }
        } // создание объекта "пилометириал"

        private void EnterLumber()
        {
            try
            {
                listBoxLumber.Items.Clear();
                for (int a = 0; a < wShop[numWorkshop()].LumberWorkshop.Count; a++)
                {
                    listBoxLumber.Items.Add(wShop[numWorkshop()].LumberWorkshop[a].BriefStr());
                }
            }
            catch { }
        } // обновление списка пиломатериалов

        private void buttonDeleteLumber_Click(object sender, EventArgs e)
        {
            delLumber();
        } // кнопка удаления пиломатериалов

        private void delLumber()
        {
            int n = numLumber();
            try
            {
                if (n == -1) // в случае если элемент не выбран выбрасываем исключение
                {
                    throw new MyExceptions(MyExceptionError);
                }
                wShop[numWorkshop()].LumberWorkshop.RemoveAt(n);
            }
            catch (MyExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            listBoxLumber.Items.Clear();
            EnterLumber();
        } //Удаление пиломатериалов

        private int numLumber()
        {
            try
            {
                return listBoxLumber.SelectedIndex;
            }
            catch
            {
                return -1;
            }
        } // Номер выделеного пиломатериала

        private void listBoxWorkshop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedWshop = numWorkshop();
                if (selectedWshop == -1) // если не выбрана мастерская - выбрасываем исключение 
                {
                    throw new MyExceptions(MyExceptionError);
                }
                EnabledAddWood();
                listBoxLumber.Items.Clear();
                for (int a = 0; a < wShop[selectedWshop].LumberWorkshop.Count; a++)
                {
                    listBoxLumber.Items.Add(wShop[selectedWshop].LumberWorkshop[a].BriefStr());
                }
            }
            catch (MyExceptions ex)
            {
                show(ex.Message);
            }
        }//Обновление списка пиломатериалов при выборе мастерской из списка

        private void buttonAddWorkshop_Click(object sender, EventArgs e)
        {
            int numberhouse = Convert.ToInt32(textBoxNumberWorkshop.Text);
            int cost = Convert.ToInt32(textBoxCost.Text);
            Workshop workshop = new Workshop(numberhouse, cost);
            wShop.Add(workshop);
            EnterWorkshop();
        }//Добавление новой мастерской

        private void buttonDeleteWorkshop_Click(object sender, EventArgs e)
        {
            delWorkshop();
        } //кнопка удаления мастерской

        private void delWorkshop()
        {
            int n = numWorkshop();
            try
            {
                if (n == -1) // если не выбрана мастерская - выбрасываем исключение 
                {
                    throw new MyExceptions(MyExceptionError);
                }
                wShop.RemoveAt(n);
            }
            catch (MyExceptions ex)
            {
                show(ex.Message);
            }
            listBoxWorkshop.Items.Clear();
            EnterWorkshop();
            listBoxLumber.Items.Clear();
        } //Удаление мастерской

        private int numWorkshop()
        {
            if (wShop.Count != 0)
                return listBoxWorkshop.SelectedIndex;
            return -1;
        } // номер выделенной мастерской

        private void EnterWorkshop()
        {
            listBoxWorkshop.Items.Clear();
            for (int i = 0; i < wShop.Count; i++)
            {
                listBoxWorkshop.Items.Add($"№ {wShop[i].NumberWorkshop(i + 1)} {wShop[i].BriefWorkshop()}");
            }
        } // Обновление списка мастерских

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonFullinfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (numWorkshop() == -1) // если не выбрана мастерская - выбрасываем исключение 
                {
                    throw new MyExceptions(MyExceptionError);
                }
                FullInfo Fullinfo = new FullInfo();
                Fullinfo.richTextBoxFullInfo.Text = $"№ {(numWorkshop() + 1)} {wShop[numWorkshop()].ToString()}";
                for (int a = 0; a < wShop[numWorkshop()].LumberWorkshop.Count; a++)
                {
                    Fullinfo.richTextBoxFullInfo.Text += $"\n******\n {(wShop[numWorkshop()].LumberWorkshop[a].ToString())}";
                }
                Fullinfo.Show();
            }
            catch (MyExceptions ex)
            {
                show(ex.Message);
            }
        } //вывод в форму full info

        private void buttonBriefinfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (numWorkshop() == -1) // если не выбрана мастерская - выбрасываем исключение 
                {
                    throw new MyExceptions(MyExceptionError);
                }
                BriefInfo Briefinfo = new BriefInfo();
                int sum = 0;

                for (int a = 0; a < wShop[numWorkshop()].LumberWorkshop.Count; a++)
                    sum += wShop[numWorkshop()].LumberWorkshop[a].PriceAmountOfWood(); // узнаем общую стоимость

                Briefinfo.labelWorkshop.Text = $"Workshop № {numWorkshop() + 1}";
                Briefinfo.labelWorkshopCost.Text = $"\nОбщая стоимость полученных материалов составила : {Convert.ToString(sum)} $";
                Briefinfo.Show();
            }
            catch (MyExceptions ex)
            {
                show(ex.Message);
            }
        } // вывод в форму Brief info

        private void buttonCompareCost_Click(object sender, EventArgs e)
        {
            try
            {
                if (numWorkshop() == -1) // если не выбрана мастерская - выбрасываем исключение 
                {
                    throw new MyExceptions(MyExceptionError);
                }
                Price_comparison comp = new Price_comparison(wShop[numWorkshop()].LumberWorkshop);
                comp.Show();
            }
            catch (MyExceptions ex)
            {
                show(ex.Message);
            }
        }

        #endregion

        #region Exception

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                while (true)
                    wShop.RemoveAt(0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                listBoxWorkshop.Items.Clear();
                EnterWorkshop();
                listBoxLumber.Items.Clear();
                EnterLumber();
                show("Информация о мастерских уничтожена(Перехвачено классом Exception)");
            }
        } // all delete
        
        #endregion

        #region corrected errors
        private void textBoxCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8) // 8 - Backspace
                e.Handled = true;
        }
        
        private void textBoxNumberWorkshop_TextChanged(object sender, EventArgs e)
        {
            EnabledAddWorkshop();
        }

        private void textBoxCost_TextChanged(object sender, EventArgs e)
        {
            EnabledAddWorkshop();
        }

        public void EnabledAddWorkshop()
        {
            if (textBoxCost.TextLength == 0 || textBoxNumberWorkshop.TextLength == 0)
                buttonAddWorkshop.Enabled = false;
            else
                buttonAddWorkshop.Enabled = true;
            CheckMark();
        }

        public void EnabledAddWood()
        {
            if (comboBoxWood.Text == "" || comboBoxSavingOptions.Text == "" || dateTimePicker1.Text == "" || textBoxAmountOfWood.TextLength == 0 || numWorkshop() < 0)  
                buttonAddWood.Enabled = false;
            else
                buttonAddWood.Enabled = true;
            CheckMark();
        }

        public void CheckMark()
        {
            if (textBoxNumberWorkshop.TextLength == 0)
            {
                pictureBox5.Visible = false;
                pictureBox10.Visible = true;
            }
            else
            {
                pictureBox5.Visible = true;
                pictureBox10.Visible = false;
            }
            if (textBoxCost.TextLength == 0)
            {
                pictureBox6.Visible = false;
                pictureBox11.Visible = true;
            }
            else
            {
                pictureBox6.Visible = true;
                pictureBox11.Visible = false;
            }
            if (comboBoxWood.Text == "")
            {
                pictureBox7.Visible = false;
                pictureBox12.Visible = true;
            }
            else
            {
                pictureBox7.Visible = true;
                pictureBox12.Visible = false;
            }
            if (comboBoxSavingOptions.Text == "")
            {
                pictureBox8.Visible = false;
                pictureBox13.Visible = true;
            }
            else
            {
                pictureBox8.Visible = true;
                pictureBox13.Visible = false;
            }
            if (textBoxAmountOfWood.TextLength == 0)
            {
                pictureBox9.Visible = false;
                pictureBox14.Visible = true;
            }
            else
            {
                pictureBox9.Visible = true;
                pictureBox14.Visible = false;
            }
        } // галочка

        private void comboBoxWood_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnabledAddWood();
        }

        private void comboBoxSavingOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnabledAddWood();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            EnabledAddWood();
        }

        private void textBoxAmountOfWood_TextChanged(object sender, EventArgs e)
        {
            EnabledAddWood();
        }

        private void show(string s)
        {
            MessageBox.Show(s);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox15.Visible = false;
            button1.Visible = false;
        }
        #endregion

        #region serializer

        const string FileName = @"serializable.txt"; // путь к файлу хранения

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // сериализация wShop при закрытии приложения 
        {
            Stream TestFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(TestFileStream, wShop);
            TestFileStream.Close();
        }

        private void Form1_Load(object sender, EventArgs e) // десериализация при запуске приложения 
        {
            if (File.Exists(FileName)) // проверяем на существование файл
            {
                Stream TestFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter(); 
                wShop = (List<Workshop>)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
            }
            // вытаскиваем информацию из сериализируемого объекта 
            try
            {
                listBoxWorkshop.Items.Clear();
                for (int i = 0; i < wShop.Count; i++)
                {
                    listBoxWorkshop.Items.Add($"№ {wShop[i].NumberWorkshop(i + 1)} {wShop[i].BriefWorkshop()}"); // выводим мастерские
                }

                int selectedWshop = numWorkshop();
                EnabledAddWood();
                listBoxLumber.Items.Clear();
                for (int a = 0; a < wShop[selectedWshop].LumberWorkshop.Count; a++)
                {
                    listBoxLumber.Items.Add(wShop[selectedWshop].LumberWorkshop[a].BriefStr()); // выводим пиломатериалы в выбранной мастерской 
                }
            }
            catch (Exception) {  } 
        }

        #endregion
    }
}
