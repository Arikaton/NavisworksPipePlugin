using Autodesk.Navisworks.Api;
using NavisworksPipePlugin.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NavisworksPipePlugin
{
    class ParseUtils
    {
        private static string GetParentNames(ModelItem modelItem)
        {
            var parentName = new StringBuilder();
            var currentItem = modelItem;
            var counter = 1;
            while (currentItem.Parent != null)
            {
                parentName
                    .Append($" [lvl {counter++}]: ")
                    .Append(currentItem.Parent.DisplayName);
                currentItem = currentItem.Parent;
            }

            return parentName.ToString();
        }

        public static void SetupParseInfo(bool useChoosedElements, bool isCheckCenterPoints, string propertyName, string propertyValue)
        {
            if (useChoosedElements)
            {
                if (PipePlugin.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Выберите хотя бы один элемент.", "Ошибка");
                    return;
                }
                GetInfoFromModelItemCollection(PipePlugin.SelectedItems, isCheckCenterPoints);
            }
            else
            {
                if (PipePlugin.AllItems.Count == 0)
                {
                    MessageBox.Show("Загрузите файл.", "Ошибка");
                    return;
                }
                if (propertyName == "Все")
                    GetInfoFromModelItemCollection(PipePlugin.AllItems.DescendantsAndSelf, isCheckCenterPoints);
                else
                {
                    ModelItemCollection filteredCollection = new ModelItemCollection();
                    foreach (var model in PipePlugin.AllItems.DescendantsAndSelf)
                    {
                        if (model.IsHidden) continue;
                        string value = GetPropertStringValue(model, propertyName);
                        if (value is null) continue;
                        if (value == propertyValue)
                            filteredCollection.Add(model);
                    }
                    GetInfoFromModelItemCollection(filteredCollection, isCheckCenterPoints);
                }
            }
        }

        public static string GetPropertStringValue(ModelItem model, string propertyName)
        {
            var category = model.PropertyCategories.FindCategoryByName("LcOaNode");
            if (category is null) return null;
            string name = DisplayNameToName(propertyName);
            var property = category.Properties.FindPropertyByName(name);
            if (property is null) return null;
            var value = property.Value.ToDisplayString();
            return value;
        }

        public static string DisplayNameToName(string displayName)
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
                case "Материал":
                    return "LcOaNodeMaterial";
                case "Файл источника":
                    return "LcOaNodeSourceFile";
                default:
                    return "";
            }
        }

        public static void GetInfoFromModelItemCollection(IEnumerable<ModelItem> collection, bool getCenterPoint)
        {
            var pipeList = new List<PipeInfo>();
            foreach (ModelItem modelItem in collection)
            {
                BoundingBox3D box;
                PipeInfo pipeInfo;
                if (getCenterPoint)
                {
                    box = modelItem.BoundingBox();
                    pipeInfo = PipeInfoCentered.FromBoundingBox3D(box);
                }
                else
                {
                    if (!modelItem.HasGeometry) continue;
                    box = modelItem.Geometry?.BoundingBox;
                    pipeInfo = PipeInfoStartEnd.FromBoundingBox3D(box);
                }

                if (pipeInfo != null)
                {
                    pipeInfo.ElementName = modelItem.DisplayName;
                    pipeInfo.ParentNames = GetParentNames(modelItem);
                    pipeList.Add(pipeInfo);
                }
            }
            if (pipeList.Count == 0)
            {
                MessageBox.Show("Ошибка парсинга. Попробуйте выбрать другие элементы или другие значения фильтра", "Внимание");
                return;
            }
            WritePipeInfoToCSV(pipeList);
            MessageBox.Show("Готово. Для просмотра файла нажмите \"Открыть папку\" и откройте файл \"PipeInfo.csv\"");
        }

        public static void WritePipeInfoToCSV(List<PipeInfo> pipesInfo)
        {
            using (var sw = new StreamWriter("PipeInfo.csv", false))
            {
                sw.WriteLine(pipesInfo[0].FieldInfo());
                foreach (var pipeInfo in pipesInfo)
                {
                    sw.WriteLine(pipeInfo.ToString());
                }
            }
        }

        public static Dictionary<string, int> GetUniqueProperties(string propertyName)
        {
            var allModels = PipePlugin.AllItems.DescendantsAndSelf;
            var properties = new Dictionary<string, int>();
            foreach (var model in allModels)
            {
                if (model.IsHidden) continue;
                string value = GetPropertStringValue(model, propertyName);
                if (value is null) continue;
                if (properties.ContainsKey(value))
                    properties[value]++;
                else
                    properties.Add(value, 1);
            }

            return properties;
        }
    }
}
