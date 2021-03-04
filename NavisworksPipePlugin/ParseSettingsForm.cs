using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavisworksPipePlugin
{
    public partial class ParseSettingsForm : Form
    {
        private Point formPointBeforeMove;
        private bool isCheckCenterPoints = false;
        private Image Highlighted;
        private Image HighlightedReversed;

        public ParseSettingsForm()
        {
            InitializeComponent();
            Highlighted = StartEndPointButton.BackgroundImage;
            HighlightedReversed = CenterPointButton.BackgroundImage;
            CenterPointButton.BackgroundImage = null;
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            DefineUniquePropertiesToNameBox();
            ChoosedElementsButton.Text = $"Выбранные элементы ({PipeParser.SelectedItems.Count})";
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

        private void RenderButton_MouseClick(object sender, MouseEventArgs e)
        {
            var item = PipeParser.FirstSelectedItem;
            if (item is null) return;
            StringBuilder result = new StringBuilder();
            var category = item.PropertyCategories.FindCategoryByName("LcOaNode");
            foreach (var property in category.Properties)
            {
                result.Append("Name: " + property.Name)
                    .Append("\n")
                    .Append("Combined Name: " + property.CombinedName)
                    .Append("\n")
                    .Append("Display Name: " + property.DisplayName)
                    .Append("\n\n");
            }
            MessageBox.Show(result.ToString());
        }

        private void ParseButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (ChoosedElementsButton.Checked)
            {
                if (PipeParser.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Выберите хотя бы один элемент.", "Ошибка");
                    return;
                }
                PipeParser.GetInfoFromModelItemCollection(PipeParser.SelectedItems, isCheckCenterPoints);
            } else
            {
                if (PipeParser.AllItems.Count == 0)
                {
                    MessageBox.Show("Загрузите файл.", "Ошибка");
                    return;
                }
                PipeParser.GetInfoFromModelItemCollection(PipeParser.AllItems.Descendants, isCheckCenterPoints);
            }

        }

        private void CenterPointButton_Click(object sender, EventArgs e)
        {
            ChooseCenterPoint();
        }

        private void ChooseCenterPoint()
        {
            StartEndPointButton.BackgroundImage = null;
            CenterPointButton.BackgroundImage = HighlightedReversed;
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
            StartEndPointButton.BackgroundImage = Highlighted;
        }

        private void ChoosedElementsButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterGroup.Visible = false;
            ChoosedElementsButton.Text = $"Выбранные элементы ({PipeParser.SelectedItems.Count})";
        }

        private void FilterButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterGroup.Visible = true;
        }

        private void CategoriesBox_TextChanged(object sender, EventArgs e)
        {
            DefineUniquePropertiesToNameBox();
        }

        private void DefineUniquePropertiesToNameBox()
        {
            NameBox.Items.Clear();
            Dictionary<string, int> properties = GetUniqueProperties();
            if (properties.Count > 0)
            {
                NameBox.Items.AddRange(properties.Keys.ToArray());
                NameBox.Text = properties.First().Key;
            }
        }

        private Dictionary<string, int> GetUniqueProperties()
        {
            var allModels = PipeParser.AllItems.DescendantsAndSelf;
            var properties = new Dictionary<string, int>();
            foreach (var model in allModels)
            {
                var category = model.PropertyCategories.FindCategoryByName("LcOaNode");
                if (category is null) continue;
                var property = category.Properties.FindPropertyByName(DisplayNameToName(CategoriesBox.Text));
                if (property is null) continue;
                string value;
                try
                {
                    value = property.Value.ToDisplayString();
                }
                catch
                {
                    value = property.Value.ToString();
                }
                if (properties.ContainsKey(value))
                    properties[value]++;
                else
                    properties.Add(value, 1);
            }

            return properties;
        }

        private string DisplayNameToName(string displayName)
        {
            switch (displayName)
            {
                case "Имя":
                    return "LcOaSceneBaseUserName";
                case "Тип":
                    return "LcOaSceneBaseClassUserName";
                case "Внутренний тип":
                    return "LcOaSceneBaseClassName";
                case "GUID":
                    return "LcOaNodeGUID";
                case "Скрытый":
                    return "LcOaNodeHidden";
                case "Обязательный":
                    return "LcOaNodeRequired";
                case "Материал":
                    return "LcOaNodeMaterial";
                case "Файл источника":
                    return "LcOaNodeSourceFile";
                default:
                    throw new ArgumentException($"Argument {displayName} not supported");
            }
        }
    }
}
