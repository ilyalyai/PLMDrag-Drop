using System.Drawing;
using System.Windows.Forms;

namespace PLMCollectionsD_D
{
    public partial class DragAndDropForm : Form
    {
        private string draggedItem; //перетаскиваемый элемент
        private Form dragPreviewWindow; // Временное окно для отображения текста

        //список имён атрибутов
        readonly List<EntityAttribute> DefaultList;
        //список атрибутов, которые юзер перетащил
        List<EntityAttribute> Headers, Filters, Sum, Rows;
        //словарик для универсального доступа к спискам выше
        Dictionary<string, List<EntityAttribute>> collections;
        //флаг, что форму закрыли корректно - что можно вытаскивать значения
        private bool isCanceled;

        public DragAndDropForm(list<entityattribute> attributelist)
        {
            DefaultList = new();
            attributelist.foreach (attribute => defaultlist.add(attribute)) ;

            Headers = new(); Filters = new(); Sum = new(); Rows = new();
            collections = new() { { "headersCB", Headers }, { "FiltersCB", Filters }, { "SumCB", Sum }, { "RowsCB", Rows } };
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
                col.Item2.AddRange(col.Item1.Items.ToArrayOfType<string>().Select(name => DefaultList.FirstOrDefault(e => e.GetFriendlyName() == name)));
            }
            //а всё. Остальное вытащим потом. Поставим только флаг, что всё завершилось удачно
            isCanceled = false;
            this.Close();
        }
    }
}