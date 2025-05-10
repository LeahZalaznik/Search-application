using System.Windows.Forms;
namespace ui
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            search = new Button();
            textVerse = new TextBox();
            textchapter = new TextBox();
            textBook = new TextBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            seferDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            parashaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            perekDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pasukDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            verseBindingSource = new BindingSource(components);
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            panel2 = new Panel();
            resultSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)verseBindingSource).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // search
            // 
            search.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            search.ForeColor = SystemColors.MenuHighlight;
            search.Location = new Point(236, 3);
            search.Name = "search";
            search.Size = new Size(433, 59);
            search.TabIndex = 1;
            search.Text = "חפש";
            search.UseVisualStyleBackColor = true;
            search.Click += search_Click;
            // 
            // textVerse
            // 
            textVerse.ForeColor = Color.Aqua;
            textVerse.Location = new Point(1177, 33);
            textVerse.Name = "textVerse";
            textVerse.PlaceholderText = "פסוק";
            textVerse.Size = new Size(245, 27);
            textVerse.TabIndex = 4;
            textVerse.TextAlign = HorizontalAlignment.Center;
            // 
            // textchapter
            // 
            textchapter.BackColor = SystemColors.Window;
            textchapter.ForeColor = Color.Aqua;
            textchapter.Location = new Point(926, 33);
            textchapter.Name = "textchapter";
            textchapter.PlaceholderText = "פרק";
            textchapter.Size = new Size(245, 27);
            textchapter.TabIndex = 6;
            textchapter.TextAlign = HorizontalAlignment.Center;
            // 
            // textBook
            // 
            textBook.BorderStyle = BorderStyle.FixedSingle;
            textBook.ForeColor = Color.DeepSkyBlue;
            textBook.Location = new Point(675, 33);
            textBook.Name = "textBook";
            textBook.PlaceholderText = "ספר";
            textBook.Size = new Size(245, 27);
            textBook.TabIndex = 7;
            textBook.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.GhostWhite;
            textBox1.Enabled = false;
            textBox1.ForeColor = SystemColors.Highlight;
            textBox1.Location = new Point(3, 32);
            textBox1.Name = "textBox1";
            textBox1.RightToLeft = RightToLeft.Yes;
            textBox1.Size = new Size(233, 27);
            textBox1.TabIndex = 12;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { seferDataGridViewTextBoxColumn, parashaDataGridViewTextBoxColumn, perekDataGridViewTextBoxColumn, pasukDataGridViewTextBoxColumn, dataDataGridViewTextBoxColumn });
            dataGridView1.DataSource = verseBindingSource;
            dataGridView1.Location = new Point(15, 260);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RightToLeft = RightToLeft.Yes;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1425, 553);
            dataGridView1.TabIndex = 13;
            // 
            // seferDataGridViewTextBoxColumn
            // 
            seferDataGridViewTextBoxColumn.DataPropertyName = "Sefer";
            seferDataGridViewTextBoxColumn.HeaderText = "ספר";
            seferDataGridViewTextBoxColumn.MinimumWidth = 6;
            seferDataGridViewTextBoxColumn.Name = "seferDataGridViewTextBoxColumn";
            seferDataGridViewTextBoxColumn.Width = 125;
            // 
            // parashaDataGridViewTextBoxColumn
            // 
            parashaDataGridViewTextBoxColumn.DataPropertyName = "Parasha";
            parashaDataGridViewTextBoxColumn.HeaderText = "פרשה";
            parashaDataGridViewTextBoxColumn.MinimumWidth = 6;
            parashaDataGridViewTextBoxColumn.Name = "parashaDataGridViewTextBoxColumn";
            parashaDataGridViewTextBoxColumn.Width = 125;
            // 
            // perekDataGridViewTextBoxColumn
            // 
            perekDataGridViewTextBoxColumn.DataPropertyName = "Perek";
            perekDataGridViewTextBoxColumn.HeaderText = "פרק";
            perekDataGridViewTextBoxColumn.MinimumWidth = 6;
            perekDataGridViewTextBoxColumn.Name = "perekDataGridViewTextBoxColumn";
            perekDataGridViewTextBoxColumn.Width = 125;
            // 
            // pasukDataGridViewTextBoxColumn
            // 
            pasukDataGridViewTextBoxColumn.DataPropertyName = "Pasuk";
            pasukDataGridViewTextBoxColumn.HeaderText = "פסוק";
            pasukDataGridViewTextBoxColumn.MinimumWidth = 6;
            pasukDataGridViewTextBoxColumn.Name = "pasukDataGridViewTextBoxColumn";
            pasukDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            dataDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            dataDataGridViewTextBoxColumn.HeaderText = "Data";
            dataDataGridViewTextBoxColumn.MinimumWidth = 7;
            dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            dataDataGridViewTextBoxColumn.Width = 70;
            // 
            // verseBindingSource
            // 
            verseBindingSource.DataSource = typeof(Dto.Verse);
            // 
            // comboBox1
            // 
            comboBox1.FlatStyle = FlatStyle.System;
            comboBox1.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(675, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(747, 28);
            comboBox1.TabIndex = 14;
            comboBox1.KeyPress += comboBox1_KayPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Font = new Font("Segoe UI Historic", 45F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(365, 25);
            label1.Name = "label1";
            label1.Size = new Size(488, 100);
            label1.TabIndex = 16;
            label1.Text = "חיפוש בתנ\"ך";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.MenuHighlight;
            label2.Location = new Point(681, 5);
            label2.Name = "label2";
            label2.Size = new Size(160, 23);
            label2.TabIndex = 90;
            label2.Text = "הקלד מילה לחיפוש";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Location = new Point(12, 853);
            panel1.Name = "panel1";
            panel1.Size = new Size(1425, 49);
            panel1.TabIndex = 18;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(74, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(156, 24);
            checkBox1.TabIndex = 19;
            checkBox1.Text = "חיפוש מילה שלמה";
            checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(checkBox1);
            panel2.Controls.Add(search);
            panel2.Controls.Add(textVerse);
            panel2.Controls.Add(textchapter);
            panel2.Controls.Add(textBook);
            panel2.Controls.Add(textBox1);
            panel2.Location = new Point(12, 195);
            panel2.Name = "panel2";
            panel2.Size = new Size(1428, 70);
            panel2.TabIndex = 5;
            // 
            // resultSearch
            // 
            resultSearch.Location = new Point(12, 100);
            resultSearch.Name = "resultSearch";
            resultSearch.Size = new Size(202, 54);
            resultSearch.TabIndex = 115;
            resultSearch.Text = "חיפושים אחרונים";
            resultSearch.UseVisualStyleBackColor = true;
            resultSearch.Click += resultSearch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1469, 914);
            Controls.Add(resultSearch);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Name = "Form1";
            RightToLeft = RightToLeft.Yes;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)verseBindingSource).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button search;
        private TextBox textVerse;
        private TextBox textchapter;
        private TextBox textBook;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private BindingSource verseBindingSource;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn seferDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn parashaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn perekDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pasukDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private Label label1;
        private Panel panel1;
        private CheckBox checkBox1;
        private Panel panel2;
        private Button resultSearch;
    }
}