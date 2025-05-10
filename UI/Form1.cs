using Bll;
using Dto;

namespace ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //          
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Info;
            label1.Font = new Font("Segoe UI Historic", 45F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(365, 25);
            label1.Name = "label1";
            label1.Size = new Size(451, 100);
            label1.TabIndex = 16;
            label1.Text = "חיפוש בתנך";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.MenuHighlight;
            label2.Location = new Point(694, 231);
            label2.Name = "label2";
            label2.Size = new Size(160, 23);
            label2.TabIndex = 90;
            label2.BringToFront();
            label2.Text = "הקלד מילה לחיפוש";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            //
            RightToLeft = RightToLeft.Yes;
            // StartPosition = FormStartPosition.Manual;

            //קובובוקס השלמת מילים
            dataGridView1.ClearSelection();
            comboBox1.RightToLeft = RightToLeft.Yes;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection searchHistory = new AutoCompleteStringCollection();
            searchHistory.AddRange(BllClass.GetsaveSearch().ToArray());
            comboBox1.AutoCompleteCustomSource = searchHistory;
        }

        //חיפוש עפ"י אינדקסים דרישה מינימלית
        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            List<int> l = BllClass.SearchIndex(comboBox1.Text);
            for (int i = 0; i < l.Count - 1; i++)
            {
                s += l[i].ToString() + ',';
            }

        }

        //כפתור החיפוש 
        private void search_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            string sefer = textBook.Text;
            string perek = textchapter.Text;
            string pasuk = textVerse.Text;
            string word;
            if (checkBox1.Checked)
                word = " " + comboBox1.Text + " ";
            else
                word = comboBox1.Text;

            Dictionary<eTypesData, string> dic = new Dictionary<eTypesData, string>();
            List<Verse> l = new List<Verse>();
            if (word != "")
                if (!sefer.Equals("") && !Enum.IsDefined(typeof(Dto.eBooks), sefer))
                    return;
            if (!sefer.Equals("") && !perek.Equals("") && !pasuk.Equals(""))
            {
                l = BllClass.Search((eBooks)Enum.Parse(typeof(Dto.eBooks), sefer), perek, pasuk, word);
                dic.Add(eTypesData.sefer, sefer);
                dic.Add(eTypesData.perek, perek);
                dic.Add(eTypesData.pasuk, pasuk);
                dic.Add(eTypesData.word, word);
                BllClass.saveSearch(dic);
                //l = BllClass.Search2(dic);
            }
            else if (!sefer.Equals("") && !perek.Equals("") && pasuk.Equals(""))
            {
                l = BllClass.Search((eBooks)Enum.Parse(typeof(Dto.eBooks), sefer), perek, word);
                dic.Add(eTypesData.sefer, sefer);
                dic.Add(eTypesData.perek, perek);
                dic.Add(eTypesData.word, word);
                BllClass.saveSearch(dic);
                //l = BllClass.Search2(dic);
            }
            else if (!sefer.Equals("") && perek.Equals("") && !pasuk.Equals(""))
            {
                l = BllClass.SearchByVers((eBooks)Enum.Parse(typeof(Dto.eBooks), sefer), pasuk, word);
                dic.Add(eTypesData.sefer, sefer);
                dic.Add(eTypesData.pasuk, pasuk);
                dic.Add(eTypesData.word, word);
                BllClass.saveSearch(dic);
                //l = BllClass.Search2(dic);
            }
            else if (sefer.Equals("") && !perek.Equals("") && !pasuk.Equals(""))
            {
                l = BllClass.Search(perek, pasuk, word);
                dic.Add(eTypesData.perek, perek);
                dic.Add(eTypesData.pasuk, pasuk);
                dic.Add(eTypesData.word, word);
                BllClass.saveSearch(dic);
                // l = BllClass.Search2(dic);
            }
            else if (sefer.Equals("") && !perek.Equals("") && pasuk.Equals(""))
            {
                l = BllClass.Search(perek, word);
                dic.Add(eTypesData.perek, perek);
                dic.Add(eTypesData.word, word);
                BllClass.saveSearch(dic);
                // l = BllClass.Search2(dic);
            }
            else if (sefer.Equals("") && perek.Equals("") && !pasuk.Equals(""))
            {
                l = BllClass.SearchV(pasuk, word);
                dic.Add(eTypesData.pasuk, pasuk);
                dic.Add(eTypesData.word, word);
                BllClass.saveSearch(dic);
                //l = BllClass.Search2(dic);
            }
            else if (!sefer.Equals("") && perek.Equals("") && pasuk.Equals(""))
            {
                l = BllClass.Search((eBooks)Enum.Parse(typeof(Dto.eBooks), sefer), word);
                dic.Add(eTypesData.sefer, sefer);
                dic.Add(eTypesData.word, word);
                BllClass.saveSearch(dic);
                // l = BllClass.Search2(dic);
            }
            else if (sefer.Equals("") && perek.Equals("") && pasuk.Equals(""))
            {
                l = BllClass.Search(word);
                dic.Add(eTypesData.word, word);
                BllClass.saveSearch(dic);
                // l = BllClass.Search2(dic);
            }

            textBox1.Text = " עד כה נמצאו " + l.Count().ToString() + " תוצאות ";
            dataGridView1.DataSource = l.ToList();
            AutoCompleteStringCollection searchHistory = new AutoCompleteStringCollection();
            searchHistory.AddRange(BllClass.GetsaveSearch().ToArray());
            comboBox1.AutoCompleteCustomSource = searchHistory;
            dataGridView1.CellPainting += results_CellPainting;

        }

        //ארוע לשמור על כיווניות הטקסט--הקומבו שיבש אות
        private void comboBox1_KayPress(object sender, EventArgs e)
        {
            if (e.GetHashCode() >= 'א' && e.GetHashCode() <= 'ת')
            {
                comboBox1.RightToLeft = RightToLeft.Yes;
            }

        }

        //פונקציה להדגשת התוצאות
        private void results_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // בודק אם מדובר בעמודת הטקסט הרצויה
            if (e.ColumnIndex == dataGridView1.Columns["dataDataGridViewTextBoxColumn"].Index && e.RowIndex >= 0)
            {
                e.Handled = true;
                e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);
                e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

                string cellText = e.Value?.ToString();
                if (string.IsNullOrEmpty(cellText)) return;

                string searchText = comboBox1.Text;

                // חישוב המיקום ההתחלתי מהצד הימני
                Size totalTextSize = TextRenderer.MeasureText(e.Graphics, cellText, e.CellStyle.Font);
                int xPosition = e.CellBounds.Right - totalTextSize.Width;
                Point startLocation = new Point(xPosition, e.CellBounds.Y - 17);
                Size highlightSize = TextRenderer.MeasureText(e.Graphics, searchText, e.CellStyle.Font);

                int i = cellText.IndexOf(searchText);
                while (i > -1)
                {
                    if (((i == 0 || cellText[i - 1] == ' ') && (cellText[i + searchText.Length] == ' ' || cellText[i + searchText.Length] == ':')))
                    {
                        Size textBeforeSize = TextRenderer.MeasureText(e.Graphics, cellText.Substring(0, i), e.CellStyle.Font);
                        Point startLocation2 = new Point(e.CellBounds.Right - textBeforeSize.Width, e.CellBounds.Y);

                        Point highlightLocation = new Point(startLocation2.X - highlightSize.Width + 13, e.CellBounds.Y + 7);
                        Rectangle highlightRect = new Rectangle(highlightLocation.X, highlightLocation.Y, highlightSize.Width - 10, highlightSize.Height - 4);
                        e.Graphics.FillRectangle(Brushes.Turquoise, highlightRect);
                    }

                    i = cellText.IndexOf(searchText, i + 1);
                }

                TextFormatFlags textFormat = new TextFormatFlags();
                textFormat = TextFormatFlags.RightToLeft;

                TextRenderer.DrawText(e.Graphics, cellText, e.CellStyle.Font, startLocation, e.CellStyle.ForeColor, textFormat);

            }
        }

        private void resultSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BllClass.GetsaveSearch1();
        }
    }

}