using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TowersWindows
{
    public partial class Form1 : Form
    {
        int selectedDisk = 0; // значение выбранного кольца
        int selectedTowerIndex = 0; // индекс башни, откуда взято кольцо

        private List<List<int>> towers = new List<List<int>>();
        public Form1()
        {
            towers.Add(new List<int>());
            towers.Add(new List<int>());
            towers.Add(new List<int>());

            InitializeComponent();

            for (int i = 1; i <= 6; i++)
            {
                towers[0].Add(i);
            }

            textBox1.Text = string.Join(Environment.NewLine, towers[0]); //Environment.NewLine делает перенос на новую строку
        }

        private void towerClick(object button, EventArgs e) // функция клика по башне
        {
            Button clickedButton = (Button)button;

            if (selectedDisk == 0) // условие из которого мы понимаем какой это клик
            {
                firstClick(clickedButton.TabIndex);
            }
            else
            {
                secondClick(clickedButton.TabIndex);
            }
        }

        private void firstClick(int index)
        {
            if (towers[index].Count > 0)
            {
                selectedTowerIndex = index;   //запись индекса башни, откуда взято кольцо
                selectedDisk = towers[index][0];   //запись значения кольца
            }
        }

        private void secondClick(int index)

        {
            // проверка на наличие в башне колец // проверка на значение верхнего кольца
            if (((towers[index].Count > 0) && (towers[index][0] > selectedDisk)) || towers[index].Count == 0)
            {
                changeDiskLocation(index);
            }
            else
            {
                Console.WriteLine("Cброс");
                selectedDisk = 0;
                selectedTowerIndex = 0;
            }
        }


        private void changeDiskLocation(int index)
        {
            towers[selectedTowerIndex].Remove(selectedDisk); //удаляем значение диска в списке башни, откуда взяли диск

            towers[index].Reverse();
            towers[index].Add(selectedDisk);
            towers[index].Reverse();

            // передаем элементу textBox значение списка
            textBox1.Text = string.Join(Environment.NewLine, towers[0]); //Environment.NewLine делает перенос на новую строку
            textBox2.Text = string.Join(Environment.NewLine, towers[1]);
            textBox3.Text = string.Join(Environment.NewLine, towers[2]);


            selectedDisk = 0;
            selectedTowerIndex = 0;

            if (index != 0 && towers[index].Count == 6)
            {
                Console.WriteLine("Вы выиграли");
                return;
            }
        }
    }
}