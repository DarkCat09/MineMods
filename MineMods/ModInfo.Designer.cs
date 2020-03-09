namespace MineMods
{
    partial class ModInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.описаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.картинкуИОписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКартинкуКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьКартинкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.скачатьМодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скачатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скачатьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скачатьВZipархивеzipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скачатьВОбычномФорматеjarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьВБраузереcurseforgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьВБраузереСтраницуЗагрузкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.дополнительноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВИзбранноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(425, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.сохранитьКартинкуКакToolStripMenuItem,
            this.открытьКартинкуToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(217, 70);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.описаниеToolStripMenuItem,
            this.картинкуИОписаниеToolStripMenuItem});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // описаниеToolStripMenuItem
            // 
            this.описаниеToolStripMenuItem.Name = "описаниеToolStripMenuItem";
            this.описаниеToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.описаниеToolStripMenuItem.Text = "описание";
            this.описаниеToolStripMenuItem.Click += new System.EventHandler(this.описаниеToolStripMenuItem_Click);
            // 
            // картинкуИОписаниеToolStripMenuItem
            // 
            this.картинкуИОписаниеToolStripMenuItem.Name = "картинкуИОписаниеToolStripMenuItem";
            this.картинкуИОписаниеToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.картинкуИОписаниеToolStripMenuItem.Text = "картинку и описание";
            this.картинкуИОписаниеToolStripMenuItem.Click += new System.EventHandler(this.картинкуИОписаниеToolStripMenuItem_Click);
            // 
            // сохранитьКартинкуКакToolStripMenuItem
            // 
            this.сохранитьКартинкуКакToolStripMenuItem.Name = "сохранитьКартинкуКакToolStripMenuItem";
            this.сохранитьКартинкуКакToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.сохранитьКартинкуКакToolStripMenuItem.Text = "Сохранить картинку как...";
            // 
            // открытьКартинкуToolStripMenuItem
            // 
            this.открытьКартинкуToolStripMenuItem.Name = "открытьКартинкуToolStripMenuItem";
            this.открытьКартинкуToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.открытьКартинкуToolStripMenuItem.Text = "Открыть картинку";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(0, 232);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(425, 218);
            this.textBox1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скачатьМодToolStripMenuItem,
            this.дополнительноToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(425, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // скачатьМодToolStripMenuItem
            // 
            this.скачатьМодToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скачатьToolStripMenuItem,
            this.скачатьКакToolStripMenuItem,
            this.открытьВБраузереcurseforgeToolStripMenuItem,
            this.открытьВБраузереСтраницуЗагрузкиToolStripMenuItem});
            this.скачатьМодToolStripMenuItem.Name = "скачатьМодToolStripMenuItem";
            this.скачатьМодToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.скачатьМодToolStripMenuItem.Text = "Скачать мод";
            // 
            // скачатьToolStripMenuItem
            // 
            this.скачатьToolStripMenuItem.Name = "скачатьToolStripMenuItem";
            this.скачатьToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.скачатьToolStripMenuItem.Text = "Скачать";
            // 
            // скачатьКакToolStripMenuItem
            // 
            this.скачатьКакToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скачатьВZipархивеzipToolStripMenuItem,
            this.скачатьВОбычномФорматеjarToolStripMenuItem});
            this.скачатьКакToolStripMenuItem.Name = "скачатьКакToolStripMenuItem";
            this.скачатьКакToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.скачатьКакToolStripMenuItem.Text = "Скачать как...";
            // 
            // скачатьВZipархивеzipToolStripMenuItem
            // 
            this.скачатьВZipархивеzipToolStripMenuItem.Name = "скачатьВZipархивеzipToolStripMenuItem";
            this.скачатьВZipархивеzipToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.скачатьВZipархивеzipToolStripMenuItem.Text = "Скачать в zip-архиве (*.zip)";
            // 
            // скачатьВОбычномФорматеjarToolStripMenuItem
            // 
            this.скачатьВОбычномФорматеjarToolStripMenuItem.Name = "скачатьВОбычномФорматеjarToolStripMenuItem";
            this.скачатьВОбычномФорматеjarToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.скачатьВОбычномФорматеjarToolStripMenuItem.Text = "Скачать в обычном формате (*.jar)";
            // 
            // открытьВБраузереcurseforgeToolStripMenuItem
            // 
            this.открытьВБраузереcurseforgeToolStripMenuItem.Name = "открытьВБраузереcurseforgeToolStripMenuItem";
            this.открытьВБраузереcurseforgeToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.открытьВБраузереcurseforgeToolStripMenuItem.Text = "Открыть в браузере (curseforge)";
            this.открытьВБраузереcurseforgeToolStripMenuItem.Click += new System.EventHandler(this.открытьВБраузереcurseforgeToolStripMenuItem_Click);
            // 
            // открытьВБраузереСтраницуЗагрузкиToolStripMenuItem
            // 
            this.открытьВБраузереСтраницуЗагрузкиToolStripMenuItem.Name = "открытьВБраузереСтраницуЗагрузкиToolStripMenuItem";
            this.открытьВБраузереСтраницуЗагрузкиToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.открытьВБраузереСтраницуЗагрузкиToolStripMenuItem.Text = "Открыть в браузере страницу загрузки";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "Сохранить";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Сохранить";
            // 
            // дополнительноToolStripMenuItem
            // 
            this.дополнительноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьВИзбранноеToolStripMenuItem});
            this.дополнительноToolStripMenuItem.Name = "дополнительноToolStripMenuItem";
            this.дополнительноToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.дополнительноToolStripMenuItem.Text = "Дополнительно";
            // 
            // добавитьВИзбранноеToolStripMenuItem
            // 
            this.добавитьВИзбранноеToolStripMenuItem.Name = "добавитьВИзбранноеToolStripMenuItem";
            this.добавитьВИзбранноеToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.добавитьВИзбранноеToolStripMenuItem.Text = "Добавить в избранное";
            this.добавитьВИзбранноеToolStripMenuItem.Click += new System.EventHandler(this.добавитьВИзбранноеToolStripMenuItem_Click);
            // 
            // ModInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ModInfo";
            this.Text = "Мод";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem скачатьМодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скачатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скачатьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скачатьВZipархивеzipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скачатьВОбычномФорматеjarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьВБраузереcurseforgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьВБраузереСтраницуЗагрузкиToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem описаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem картинкуИОписаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКартинкуКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьКартинкуToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem дополнительноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьВИзбранноеToolStripMenuItem;
    }
}