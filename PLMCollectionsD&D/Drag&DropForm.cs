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
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Collection_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                var targetListBox = (ListBox)sender;
                string item = e.Data.GetData(typeof(string)).ToString();

                // Находим исходный ListBox
                foreach (Control control in this.Controls)
                {
                    if (control is ListBox listBox && listBox.Items.Contains(item))
                    {
                        // Удаляем элемент из исходного ListBox
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
                listBox.DoDragDrop(listBox.SelectedItem.ToString(), DragDropEffects.Move);
            }
        }
    }
}