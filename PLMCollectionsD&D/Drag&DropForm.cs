using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PLMCollectionsD_D
{
    public partial class DragAndDropForm : Form
    {
        private string draggedItem; //перетаскиваемый элемент
        private Form dragPreviewWindow; // Временное окно для отображения текста

        //список имён атрибутов
        private readonly List<AttributeDef> DefaultList;

        //список атрибутов, которые юзер перетащил
        public List<AttributeDef> Headers, Filters, Sum, Rows;

        //словарик для универсального доступа к спискам выше
        public List<(ListBox, List<AttributeDef>)> collections;

        //флаг, что форму закрыли корректно - что можно вытаскивать значения
        public bool isCanceled;

        public DragAndDropForm(List<AttributeDef> attributeList)
        {
            isCanceled = true;

            DefaultList = new();
            attributeList.ForEach(attribute => DefaultList.Add(attribute));

            Headers = new(); Filters = new(); Sum = new(); Rows = new();
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
            // Скрываем окно предпросмотра
            if (dragPreviewWindow != null && !dragPreviewWindow.IsDisposed)
            {
                dragPreviewWindow.Close();
            }

            // Остальная логика DragDrop
            if (e.Data.GetDataPresent(typeof(string)))
            {
                var targetListBox = (ListBox)sender;
                string item = e.Data.GetData(typeof(string)).ToString();
                var attrItem = DefaultList.FirstOrDefault(e => e.NameUI == item);
                //суммировать можем только числа
                if (attrItem != null && !(attrItem.DataType == AttributeDefBase.DataTypeEnum.IntegerNumber || attrItem.DataType == AttributeDefBase.DataTypeEnum.Number) && targetListBox == SumCB)
                    return;

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

        private void Collection_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
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
            if (!dragPreviewWindow.Visible)
            {
                dragPreviewWindow.Show();
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragPreviewWindow != null && !dragPreviewWindow.IsDisposed)
            {
                // Получаем текущую позицию курсора
                Point cursorPosition = Cursor.Position;

                // Позиционируем окно рядом с курсором
                dragPreviewWindow.Location = new Point(cursorPosition.X + 10, cursorPosition.Y + 10);
            }
        }

        private void Collection_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            // Если пользователь отпустил кнопку мыши, завершаем Drag-and-Drop
            if (e.Action == DragAction.Cancel || e.Action == DragAction.Drop)
            {
                // Скрываем окно предпросмотра
                if (dragPreviewWindow != null && !dragPreviewWindow.IsDisposed)
                {
                    dragPreviewWindow.Close();
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //заполняем списки атрибутов, которые хотим настроить
            foreach (var col in collections)
            {
                col.Item2.AddRange(col.Item1.Items.ToArrayOfType<string>().Select(name => DefaultList.FirstOrDefault(e => e.NameUI == name)));
            }
            //а всё. Остальное вытащим потом. Поставим только флаг, что всё завершилось удачно
            isCanceled = false;
            this.Close();
        }
    }
}