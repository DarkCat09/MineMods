namespace MineMods
{
    partial class MineModsForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MineModsForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.модToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скачатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шрифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлСМодамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сообщитьОбОшибкеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оНасToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.мелкий5ptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обычный9ptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.крупный12ptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.огромный15ptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.модToolStripMenuItem,
            this.параметрыToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.toolStripComboBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // модToolStripMenuItem
            // 
            this.модToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьToolStripMenuItem,
            this.скачатьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.модToolStripMenuItem.Name = "модToolStripMenuItem";
            this.модToolStripMenuItem.Size = new System.Drawing.Size(43, 23);
            this.модToolStripMenuItem.Text = "Мод";
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            // 
            // скачатьToolStripMenuItem
            // 
            this.скачатьToolStripMenuItem.Name = "скачатьToolStripMenuItem";
            this.скачатьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.скачатьToolStripMenuItem.Text = "Скачать";
            this.скачатьToolStripMenuItem.Click += new System.EventHandler(this.скачатьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.CloseProgram);
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шрифтToolStripMenuItem,
            this.файлСМодамиToolStripMenuItem,
            this.сообщитьОбОшибкеToolStripMenuItem});
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(83, 23);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // шрифтToolStripMenuItem
            // 
            this.шрифтToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.мелкий5ptToolStripMenuItem,
            this.обычный9ptToolStripMenuItem,
            this.крупный12ptToolStripMenuItem,
            this.огромный15ptToolStripMenuItem});
            this.шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
            this.шрифтToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.шрифтToolStripMenuItem.Text = "Шрифт";
            // 
            // файлСМодамиToolStripMenuItem
            // 
            this.файлСМодамиToolStripMenuItem.Name = "файлСМодамиToolStripMenuItem";
            this.файлСМодамиToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.файлСМодамиToolStripMenuItem.Text = "Файл с модами";
            // 
            // сообщитьОбОшибкеToolStripMenuItem
            // 
            this.сообщитьОбОшибкеToolStripMenuItem.Name = "сообщитьОбОшибкеToolStripMenuItem";
            this.сообщитьОбОшибкеToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.сообщитьОбОшибкеToolStripMenuItem.Text = "Сообщить об ошибке";
            this.сообщитьОбОшибкеToolStripMenuItem.Click += new System.EventHandler(this.сообщитьОбОшибкеToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оНасToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 23);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оНасToolStripMenuItem
            // 
            this.оНасToolStripMenuItem.Name = "оНасToolStripMenuItem";
            this.оНасToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оНасToolStripMenuItem.Text = "О нас";
            this.оНасToolStripMenuItem.Click += new System.EventHandler(this.оНасToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Все моды",
            "Клиент",
            "Сервер,мир",
            "Еда",
            "Мебель",
            "Транспорт",
            "Электорника",
            "Графика",
            "Блоки",
            "Инструменты",
            "Другое"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.Text = "Все моды";
            this.toolStripComboBox1.TextUpdate += new System.EventHandler(this.ViewSelectedModsCategory);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "MineMods";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.button8, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(667, 273);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button8.Image = global::MineMods.Properties.Resources.blocks_mods;
            this.button8.Location = new System.Drawing.Point(501, 139);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(160, 130);
            this.button8.TabIndex = 7;
            this.button8.Text = "Блоки и другое";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Image = global::MineMods.Properties.Resources.graphics_mods;
            this.button7.Location = new System.Drawing.Point(335, 139);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(160, 130);
            this.button7.TabIndex = 6;
            this.button7.Text = "Графика";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button6.Image = global::MineMods.Properties.Resources.electro_mods;
            this.button6.Location = new System.Drawing.Point(169, 139);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(160, 130);
            this.button6.TabIndex = 5;
            this.button6.Text = "Электроника и оружие";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Image = global::MineMods.Properties.Resources.transport_mods;
            this.button5.Location = new System.Drawing.Point(3, 139);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 130);
            this.button5.TabIndex = 4;
            this.button5.Text = "Транспорт";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Image = global::MineMods.Properties.Resources.furniture_mods;
            this.button4.Location = new System.Drawing.Point(501, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 130);
            this.button4.TabIndex = 3;
            this.button4.Text = "Мебель";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(335, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 130);
            this.button3.TabIndex = 2;
            this.button3.Text = "Еда";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::MineMods.Properties.Resources.world_mods;
            this.button2.Location = new System.Drawing.Point(169, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 130);
            this.button2.TabIndex = 1;
            this.button2.Text = "Сервер,мир";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::MineMods.Properties.Resources.clientside_mods;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 130);
            this.button1.TabIndex = 0;
            this.button1.Text = "Клиент";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "mods.txt";
            this.openFileDialog1.Title = "Выберите файл с модами";
            // 
            // мелкий5ptToolStripMenuItem
            // 
            this.мелкий5ptToolStripMenuItem.Name = "мелкий5ptToolStripMenuItem";
            this.мелкий5ptToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.мелкий5ptToolStripMenuItem.Text = "Мелкий (5pt)";
            this.мелкий5ptToolStripMenuItem.Click += new System.EventHandler(this.мелкий5ptToolStripMenuItem_Click);
            // 
            // обычный9ptToolStripMenuItem
            // 
            this.обычный9ptToolStripMenuItem.Name = "обычный9ptToolStripMenuItem";
            this.обычный9ptToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обычный9ptToolStripMenuItem.Text = "Обычный (9pt)";
            this.обычный9ptToolStripMenuItem.Click += new System.EventHandler(this.обычный9ptToolStripMenuItem_Click);
            // 
            // крупный12ptToolStripMenuItem
            // 
            this.крупный12ptToolStripMenuItem.Name = "крупный12ptToolStripMenuItem";
            this.крупный12ptToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.крупный12ptToolStripMenuItem.Text = "Крупный (12pt)";
            this.крупный12ptToolStripMenuItem.Click += new System.EventHandler(this.крупный12ptToolStripMenuItem_Click);
            // 
            // огромный15ptToolStripMenuItem
            // 
            this.огромный15ptToolStripMenuItem.Name = "огромный15ptToolStripMenuItem";
            this.огромный15ptToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.огромный15ptToolStripMenuItem.Text = "Огромный (15pt)";
            this.огромный15ptToolStripMenuItem.Click += new System.EventHandler(this.огромный15ptToolStripMenuItem_Click);
            // 
            // MineModsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 338);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MineModsForm";
            this.Text = "MineMods";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem модToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скачатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шрифтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оНасToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem файлСМодамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сообщитьОбОшибкеToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem мелкий5ptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обычный9ptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem крупный12ptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem огромный15ptToolStripMenuItem;
    }
}

