using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLMCollectionsD_D
{
    public partial class DragAndDropForm : Form
    {
        private string draggedItem; //перетаскиваемый элемент
        private Point dragPosition; //позиция этого элемента
        private Form dragPreviewWindow; // Временное окно для отображения текста

        //список имён атрибутов
        //readonly List<EntityAttribute> DefaultList;
        //список атрибутов, которые юзер перетащил
        //List<EntityAttribute> Headers, Filters, Sum, Rows;
        //словарик для универсального доступа к спискам выше
        //Dictionary<string, List<EntityAttribute>> collections;

        public DragAndDropForm(/*List<EntityAttribute> attributeList*/)
        {
            //DefaultList = new();
            //attributeList.ForEach(attribute => DefaultList.Add(attribute));

            //Headers = new(); Filters = new(); Sum = new(); Rows = new();
            //collections = new() { { "HeadersCB", Headers }, { "FiltersCB", Filters }, { "SumCB", Sum }, { "RowsCB", Rows } };
            InitializeComponent();
        }

        private void Collection_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void Collection_DragDrop(object sender, DragEventArgs e)
        {
            if (dragPreviewWindow != null && !dragPreviewWindow.IsDisposed)
            {
                dragPreviewWindow.Close();
            }

            if (e.Data.GetDataPresent(typeof(string)))
            {
                var targetListBox = (ListBox)sender;
                string item = e.Data.GetData(typeof(string)).ToString();

                // Удаляем элемент из исходного ListBox
                foreach (Control control in this.Controls)
                {
                    if (control is ListBox listBox && listBox.Items.Contains(item))
                    {
                        listBox.Items.Remove(item);
                        break;
                    }
                }

                // Добавляем элемент в целевой ListBox
                targetListBox.Items.Add(item);
            }
        }

        private void Collection_MouseDown(object sender, MouseEventArgs e)
        {
            var listBox = (ListBox)sender;

            if (listBox.SelectedItem != null)
            {
                draggedItem = listBox.SelectedItem.ToString();
                listBox.DoDragDrop(draggedItem, DragDropEffects.Move);
            }
        }

        private void GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            // Отключаем стандартный курсор
            //e.UseDefaultCursors = false;

            // Получаем текущую позицию курсора
            Point cursorPosition = Cursor.Position;

            // Если окно для предпросмотра еще не создано, создаем его
            if (dragPreviewWindow == null || dragPreviewWindow.IsDisposed)
            {
                dragPreviewWindow = new Form
                {
                    FormBorderStyle = FormBorderStyle.None, // Без рамки
                    ShowInTaskbar = false, // Не показывать в панели задач
                    Size = new Size(100, 30), // Размер окна
                    BackColor = Color.LightYellow, // Цвет фона
                    TransparencyKey = Color.LightYellow, // Прозрачность фона
                    TopMost = true // Всегда поверх других окон
                };

                // Добавляем Label для отображения текста
                var tempLabel = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 10),
                    Location = new Point(5, 5)
                };
                dragPreviewWindow.Controls.Add(tempLabel);
            }

            // Обновляем текст в окне
            var label = dragPreviewWindow.Controls[0] as Label;
            label.Text = draggedItem;

            // Позиционируем окно рядом с курсором
            dragPreviewWindow.Location = new Point(cursorPosition.X + 10, cursorPosition.Y + 10);

            // Показываем окно
            dragPreviewWindow.Show();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Рисуем текст рядом с курсором, если есть перетаскиваемый элемент
            if (!string.IsNullOrEmpty(draggedItem))
            {
                using (var brush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(draggedItem, this.Font, brush, dragPosition.X + 10, dragPosition.Y + 10);
                }
            }
        }
    }
}