using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NavisworksPipePlugin
{
    public partial class ParseSettingsForm : Form
    {
        private string PropertyName => CategoriesBox.SelectedItem.ToString();
        private string PropertyValue => NameBox.SelectedItem.ToString();

        private Point formPointBeforeMove;
        private bool isCheckCenterPoints = false;
        private readonly Image highlighted;
        private readonly Image highlightedReversed;

        public ParseSettingsForm()
        {
            InitializeComponent();
            highlighted = StartEndPointButton.BackgroundImage;
            highlightedReversed = CenterPointButton.BackgroundImage;
            CenterPointButton.BackgroundImage = null;
            CategoriesBox.SelectedIndex = 0;
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            DefineUniquePropertiesToNameBox();
            ChoosedElementsButton.Text = $"Выбранные элементы ({PipePlugin.SelectedItems.Count})";
        }

        private void LabelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - formPointBeforeMove.X;
                Top += e.Y - formPointBeforeMove.Y;
            }
        }

        private void LabelPanel_MouseDown(object sender, MouseEventArgs e)
        {
            formPointBeforeMove = e.Location;
        }

        private void CloseButton_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void OpenFileButton_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Directory.GetCurrentDirectory());
        }

        private void ParseButton_MouseClick(object sender, MouseEventArgs e)
        {
            ParseUtils.SetupParseInfo(
                ChoosedElementsButton.Checked, 
                isCheckCenterPoints, 
                CategoriesBox.SelectedItem.ToString(), 
                PropertyValue);
        }

        private void CenterPointButton_Click(object sender, EventArgs e)
        {
            ChooseCenterPoint();
        }

        private void ChooseCenterPoint()
        {
            StartEndPointButton.BackgroundImage = null;
            CenterPointButton.BackgroundImage = highlightedReversed;
            isCheckCenterPoints = true;
        }

        private void StartEndPointButton_MouseClick(object sender, MouseEventArgs e)
        {
            ChooseStartEndPoint();
        }

        private void ChooseStartEndPoint()
        {
            isCheckCenterPoints = false;
            CenterPointButton.BackgroundImage = null;
            StartEndPointButton.BackgroundImage = highlighted;
        }

        private void ChoosedElementsButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterGroup.Visible = false;
        }

        private void FilterButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterGroup.Visible = true;
        }

        private void DefineUniquePropertiesToNameBox()
        {
            NameBox.Items.Clear();
            if (PropertyName == "Все")
            {
                NameBox.Items.Add("Все элементы");
                NameBox.SelectedIndex = 0;
            } else
            {
                Dictionary<string, int> properties = ParseUtils.GetUniqueProperties(PropertyName);
                if (properties.Count > 0)
                {
                    NameBox.Items.AddRange(properties.Keys.ToArray());
                    NameBox.SelectedItem = properties.First().Key;
                }
            }
            UpdatePropertyValueTooltip();
            UpdateFilterMatchedItemsCount();
        }

        private void UpdateFilterMatchedItemsCount()
        {
            if (PropertyName == "Все")
            {
                FilterButton.Text = $"Фильтр ({PipePlugin.AllItems.DescendantsAndSelf.Count()})";
                return;
            }
            int counter = 0;
            foreach (var model in PipePlugin.AllItems.DescendantsAndSelf)
            {
                if (model.IsHidden) continue;
                string value = ParseUtils.GetPropertStringValue(model, PropertyName);
                if (value is null) continue;
                if (value == PropertyValue)
                    counter++;
            }
            FilterButton.Text = $"Фильтр ({counter})";
        }

        private void CategoriesBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DefineUniquePropertiesToNameBox();
        }

        private void NameBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdatePropertyValueTooltip();
            UpdateFilterMatchedItemsCount();
        }

        private void UpdatePropertyValueTooltip()
        {
            NameBoxTooltip.SetToolTip(NameBox, NameBox.Items[NameBox.SelectedIndex].ToString());
        }
    }
}
