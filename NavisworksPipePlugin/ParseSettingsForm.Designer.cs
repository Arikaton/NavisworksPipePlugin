
namespace NavisworksPipePlugin
{
    partial class ParseSettingsForm
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
            this.LabelPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ParseLabel = new System.Windows.Forms.Label();
            this.ParseButton = new System.Windows.Forms.Button();
            this.RenderButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CenterPointButton = new System.Windows.Forms.Button();
            this.StartEndPointButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FilterButton = new System.Windows.Forms.RadioButton();
            this.ChoosedElementsButton = new System.Windows.Forms.RadioButton();
            this.CategoriesBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.ComboBox();
            this.FilterGroup = new System.Windows.Forms.GroupBox();
            this.LabelPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.FilterGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelPanel
            // 
            this.LabelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LabelPanel.Controls.Add(this.CloseButton);
            this.LabelPanel.Controls.Add(this.ParseLabel);
            this.LabelPanel.Location = new System.Drawing.Point(0, 0);
            this.LabelPanel.Margin = new System.Windows.Forms.Padding(4);
            this.LabelPanel.Name = "LabelPanel";
            this.LabelPanel.Size = new System.Drawing.Size(585, 30);
            this.LabelPanel.TabIndex = 0;
            this.LabelPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelPanel_MouseDown);
            this.LabelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelPanel_MouseMove);
            // 
            // CloseButton
            // 
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(558, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(24, 24);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseButton_MouseClick);
            // 
            // ParseLabel
            // 
            this.ParseLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ParseLabel.AutoSize = true;
            this.ParseLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ParseLabel.Location = new System.Drawing.Point(13, 7);
            this.ParseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ParseLabel.Name = "ParseLabel";
            this.ParseLabel.Size = new System.Drawing.Size(96, 16);
            this.ParseLabel.TabIndex = 0;
            this.ParseLabel.Text = "Parse Plugin";
            // 
            // ParseButton
            // 
            this.ParseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ParseButton.Location = new System.Drawing.Point(361, 370);
            this.ParseButton.Name = "ParseButton";
            this.ParseButton.Size = new System.Drawing.Size(208, 50);
            this.ParseButton.TabIndex = 1;
            this.ParseButton.Text = "Продолжить";
            this.ParseButton.UseVisualStyleBackColor = true;
            this.ParseButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ParseButton_MouseClick);
            // 
            // RenderButton
            // 
            this.RenderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RenderButton.Location = new System.Drawing.Point(21, 370);
            this.RenderButton.Name = "RenderButton";
            this.RenderButton.Size = new System.Drawing.Size(208, 50);
            this.RenderButton.TabIndex = 2;
            this.RenderButton.Text = "Открыть";
            this.RenderButton.UseVisualStyleBackColor = true;
            this.RenderButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RenderButton_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.CenterPointButton);
            this.panel1.Controls.Add(this.StartEndPointButton);
            this.panel1.Location = new System.Drawing.Point(13, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 54);
            this.panel1.TabIndex = 3;
            // 
            // CenterPointButton
            // 
            this.CenterPointButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CenterPointButton.BackgroundImage = global::NavisworksPipePlugin.Properties.Resources.Button_Highlight_Reversed;
            this.CenterPointButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CenterPointButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.CenterPointButton.FlatAppearance.BorderSize = 0;
            this.CenterPointButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.CenterPointButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.CenterPointButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CenterPointButton.Location = new System.Drawing.Point(284, 5);
            this.CenterPointButton.Name = "CenterPointButton";
            this.CenterPointButton.Size = new System.Drawing.Size(272, 46);
            this.CenterPointButton.TabIndex = 1;
            this.CenterPointButton.Text = "Центральная точка";
            this.CenterPointButton.UseVisualStyleBackColor = true;
            this.CenterPointButton.Click += new System.EventHandler(this.CenterPointButton_Click);
            // 
            // StartEndPointButton
            // 
            this.StartEndPointButton.BackgroundImage = global::NavisworksPipePlugin.Properties.Resources.Button_Highlight;
            this.StartEndPointButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartEndPointButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.StartEndPointButton.FlatAppearance.BorderSize = 0;
            this.StartEndPointButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.StartEndPointButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.StartEndPointButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartEndPointButton.Location = new System.Drawing.Point(8, 5);
            this.StartEndPointButton.Name = "StartEndPointButton";
            this.StartEndPointButton.Size = new System.Drawing.Size(270, 46);
            this.StartEndPointButton.TabIndex = 0;
            this.StartEndPointButton.Text = "Начальная/конечная точка";
            this.StartEndPointButton.UseVisualStyleBackColor = true;
            this.StartEndPointButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StartEndPointButton_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.FilterButton);
            this.panel2.Controls.Add(this.ChoosedElementsButton);
            this.panel2.Location = new System.Drawing.Point(13, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(559, 90);
            this.panel2.TabIndex = 4;
            // 
            // FilterButton
            // 
            this.FilterButton.AutoSize = true;
            this.FilterButton.Location = new System.Drawing.Point(26, 56);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(81, 20);
            this.FilterButton.TabIndex = 1;
            this.FilterButton.Text = "Фильтр";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.CheckedChanged += new System.EventHandler(this.FilterButton_CheckedChanged);
            // 
            // ChoosedElementsButton
            // 
            this.ChoosedElementsButton.AutoSize = true;
            this.ChoosedElementsButton.Checked = true;
            this.ChoosedElementsButton.Location = new System.Drawing.Point(26, 20);
            this.ChoosedElementsButton.Name = "ChoosedElementsButton";
            this.ChoosedElementsButton.Size = new System.Drawing.Size(187, 20);
            this.ChoosedElementsButton.TabIndex = 0;
            this.ChoosedElementsButton.TabStop = true;
            this.ChoosedElementsButton.Text = "Выбранные элементы";
            this.ChoosedElementsButton.UseVisualStyleBackColor = true;
            this.ChoosedElementsButton.CheckedChanged += new System.EventHandler(this.ChoosedElementsButton_CheckedChanged);
            // 
            // CategoriesBox
            // 
            this.CategoriesBox.AccessibleDescription = "";
            this.CategoriesBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CategoriesBox.FormattingEnabled = true;
            this.CategoriesBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.CategoriesBox.ItemHeight = 16;
            this.CategoriesBox.Items.AddRange(new object[] {
            "Имя",
            "Тип",
            "Внутренний тип",
            "GUID",
            "Скрытый",
            "Обязательный",
            "Материал",
            "Файл источника"});
            this.CategoriesBox.Location = new System.Drawing.Point(9, 46);
            this.CategoriesBox.Name = "CategoriesBox";
            this.CategoriesBox.Size = new System.Drawing.Size(208, 24);
            this.CategoriesBox.TabIndex = 7;
            this.CategoriesBox.Text = "Имя";
            this.CategoriesBox.TextChanged += new System.EventHandler(this.CategoriesBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Категория";
            // 
            // NameBox
            // 
            this.NameBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NameBox.FormattingEnabled = true;
            this.NameBox.Location = new System.Drawing.Point(349, 46);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(205, 24);
            this.NameBox.TabIndex = 11;
            // 
            // FilterGroup
            // 
            this.FilterGroup.Controls.Add(this.label2);
            this.FilterGroup.Controls.Add(this.NameBox);
            this.FilterGroup.Controls.Add(this.label1);
            this.FilterGroup.Controls.Add(this.CategoriesBox);
            this.FilterGroup.Location = new System.Drawing.Point(12, 208);
            this.FilterGroup.Name = "FilterGroup";
            this.FilterGroup.Size = new System.Drawing.Size(560, 85);
            this.FilterGroup.TabIndex = 12;
            this.FilterGroup.TabStop = false;
            this.FilterGroup.Visible = false;
            // 
            // ParseSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(584, 432);
            this.Controls.Add(this.FilterGroup);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RenderButton);
            this.Controls.Add(this.ParseButton);
            this.Controls.Add(this.LabelPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ParseSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.LabelPanel.ResumeLayout(false);
            this.LabelPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.FilterGroup.ResumeLayout(false);
            this.FilterGroup.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel LabelPanel;
        private System.Windows.Forms.Label ParseLabel;
        private System.Windows.Forms.Button ParseButton;
        private System.Windows.Forms.Button RenderButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton FilterButton;
        private System.Windows.Forms.RadioButton ChoosedElementsButton;
        private System.Windows.Forms.ComboBox CategoriesBox;
        private System.Windows.Forms.Button StartEndPointButton;
        private System.Windows.Forms.Button CenterPointButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox NameBox;
        private System.Windows.Forms.GroupBox FilterGroup;
    }
}