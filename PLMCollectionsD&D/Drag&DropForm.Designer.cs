namespace PLMCollectionsD_D
{
    partial class DragAndDropForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RowsCB = new System.Windows.Forms.ListBox();
            SumCB = new System.Windows.Forms.ListBox();
            FiltersCB = new System.Windows.Forms.ListBox();
            HeadersCB = new System.Windows.Forms.ListBox();
            DefaultListCB = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // RowsCB
            // 
            RowsCB.AllowDrop = true;
            RowsCB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RowsCB.FormattingEnabled = true;
            RowsCB.ItemHeight = 21;
            RowsCB.Location = new System.Drawing.Point(151, 378);
            RowsCB.Name = "RowsCB";
            RowsCB.Size = new System.Drawing.Size(202, 193);
            RowsCB.TabIndex = 0;
            RowsCB.DragDrop += Collection_DragDrop;
            RowsCB.DragEnter += Collection_DragEnter;
            RowsCB.GiveFeedback += Collection_GiveFeedback;
            RowsCB.QueryContinueDrag += Collection_QueryContinueDrag;
            RowsCB.MouseDown += Collection_MouseDown;
            // 
            // SumCB
            // 
            SumCB.AllowDrop = true;
            SumCB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SumCB.FormattingEnabled = true;
            SumCB.ItemHeight = 21;
            SumCB.Location = new System.Drawing.Point(359, 378);
            SumCB.Name = "SumCB";
            SumCB.Size = new System.Drawing.Size(202, 193);
            SumCB.TabIndex = 1;
            SumCB.DragDrop += Collection_DragDrop;
            SumCB.DragEnter += Collection_DragEnter;
            SumCB.GiveFeedback += Collection_GiveFeedback;
            SumCB.QueryContinueDrag += Collection_QueryContinueDrag;
            SumCB.MouseDown += Collection_MouseDown;
            // 
            // FiltersCB
            // 
            FiltersCB.AccessibleName = "Фильтры";
            FiltersCB.AllowDrop = true;
            FiltersCB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FiltersCB.FormattingEnabled = true;
            FiltersCB.ItemHeight = 21;
            FiltersCB.Location = new System.Drawing.Point(151, 173);
            FiltersCB.Name = "FiltersCB";
            FiltersCB.Size = new System.Drawing.Size(202, 193);
            FiltersCB.TabIndex = 2;
            FiltersCB.DragDrop += Collection_DragDrop;
            FiltersCB.DragEnter += Collection_DragEnter;
            FiltersCB.GiveFeedback += Collection_GiveFeedback;
            FiltersCB.QueryContinueDrag += Collection_QueryContinueDrag;
            FiltersCB.MouseDown += Collection_MouseDown;
            // 
            // HeadersCB
            // 
            HeadersCB.AllowDrop = true;
            HeadersCB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            HeadersCB.FormattingEnabled = true;
            HeadersCB.ItemHeight = 21;
            HeadersCB.Location = new System.Drawing.Point(359, 173);
            HeadersCB.Name = "HeadersCB";
            HeadersCB.Size = new System.Drawing.Size(202, 193);
            HeadersCB.TabIndex = 3;
            HeadersCB.DragDrop += Collection_DragDrop;
            HeadersCB.DragEnter += Collection_DragEnter;
            HeadersCB.GiveFeedback += Collection_GiveFeedback;
            HeadersCB.QueryContinueDrag += Collection_QueryContinueDrag;
            HeadersCB.MouseDown += Collection_MouseDown;
            // 
            // DefaultListCB
            // 
            DefaultListCB.AllowDrop = true;
            DefaultListCB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            DefaultListCB.FormattingEnabled = true;
            DefaultListCB.ItemHeight = 21;
            DefaultListCB.Items.AddRange(new object[] { "ТестБебебе" });
            DefaultListCB.Location = new System.Drawing.Point(12, 37);
            DefaultListCB.Name = "DefaultListCB";
            DefaultListCB.Size = new System.Drawing.Size(700, 130);
            DefaultListCB.TabIndex = 4;
            DefaultListCB.DragDrop += Collection_DragDrop;
            DefaultListCB.DragEnter += Collection_DragEnter;
            DefaultListCB.GiveFeedback += Collection_GiveFeedback;
            DefaultListCB.QueryContinueDrag += Collection_QueryContinueDrag;
            DefaultListCB.MouseDown += Collection_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 25);
            label1.TabIndex = 5;
            label1.Text = "Поля";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(67, 173);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(78, 25);
            label2.TabIndex = 6;
            label2.Text = "Фильты";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(567, 173);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(88, 25);
            label3.TabIndex = 7;
            label3.Text = "Столбцы";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(71, 378);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(74, 25);
            label4.TabIndex = 8;
            label4.Text = "Строки";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(567, 378);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(102, 25);
            label5.TabIndex = 9;
            label5.Text = "Суммарно";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(24, 247);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(121, 45);
            label6.TabIndex = 10;
            label6.Text = "Для полей в этом \r\nсписке будут \r\nдобавлены фильтры";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(567, 236);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(152, 90);
            label7.TabIndex = 11;
            label7.Text = "Значения полей в этом\r\nсписке будут выведены\r\nв виде столбцов. \r\nРекомендуется добавлять \r\nполя не более чем с 5\r\nзначениями!";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(64, 457);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(81, 45);
            label8.TabIndex = 12;
            label8.Text = "Стандартное\r\nотображение\r\nполей";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(567, 437);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(129, 75);
            label9.TabIndex = 13;
            label9.Text = "Значения полей\r\nв этом списке будут\r\nпросуммированы\r\n(только для числовых\r\nполей)";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(151, 577);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(410, 72);
            button1.TabIndex = 14;
            button1.Text = "Готово";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DragAndDropForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(739, 661);
            Controls.Add(button1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DefaultListCB);
            Controls.Add(HeadersCB);
            Controls.Add(FiltersCB);
            Controls.Add(SumCB);
            Controls.Add(RowsCB);
            Name = "DragAndDropForm";
            Text = "Создание сводной таблицы";
            MouseMove += MainForm_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox RowsCB;
        private System.Windows.Forms.ListBox SumCB;
        private System.Windows.Forms.ListBox FiltersCB;
        private System.Windows.Forms.ListBox HeadersCB;
        private System.Windows.Forms.ListBox DefaultListCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}
