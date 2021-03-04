using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using NavisworksPipePlugin.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NvwApplication = Autodesk.Navisworks.Api.Application;

namespace NavisworksPipePlugin
{
    [Plugin("NavisworksPipePlugin", "ABCD", DisplayName = "Parse Pipes Settings")]
    public class PipeParser : AddInPlugin
    {
        public static ModelItemCollection SelectedItems => NvwApplication.ActiveDocument.CurrentSelection.SelectedItems;
        public static ModelItem FirstSelectedItem => SelectedItems.Count > 0 ? SelectedItems[0] : null;
        public static ModelItemCollection AllItems => NvwApplication.ActiveDocument.Models.CreateCollectionFromRootItems();

        private ParseSettingsForm parseForm = null;

        public override int Execute(params string[] parameters)
        {
            if (parseForm is null)
            {
                parseForm = new ParseSettingsForm();
                parseForm.FormClosed += (_, __) => parseForm = null;
                parseForm.Show();
            } else
            {
                parseForm.Focus();
                parseForm.UpdateInfo();
            }
            
            return 0;
        }

        public static void GetInfoFromModelItemCollection(IEnumerable<ModelItem> collection, bool getCenterPoint)
        {
            var pipeList = new List<PipeInfo>();
            foreach (ModelItem modelItem in collection)
            {
                if (!modelItem.IsHidden)
                {
                    BoundingBox3D box; 
                    PipeInfo pipeInfo;
                    if (getCenterPoint)
                    {
                        box = modelItem.BoundingBox();
                        if (modelItem.Children.First is null) continue;
                        pipeInfo = PipeInfoCentered.FromBoundingBox3D(box);
                    }
                    else
                    {
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
            }
            if (pipeList.Count == 0)
            {
                MessageBox.Show("Ошибка парсинга. Попробуйте другие значения фильтра", "Ошибка");
                return;
            }
            WritePipeInfoToCSV(pipeList);
        }

        private static string GetParentNames(ModelItem modelItem)
        {
            var parentName = new StringBuilder();
            var currentItem = modelItem;
            while (currentItem.Parent != null)
            {
                parentName.Append(currentItem.DisplayName)
                    .Append(" |");
                currentItem = currentItem.Parent;
            }

            return parentName.ToString();
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

        /*public static void RenderSelectedPipePoints()
        {
            PipeInfo pipeInfo = null;
            if (!NvwApplication.ActiveDocument.CurrentSelection.IsEmpty)
            {
                var box = SelectedItems.BoundingBox();
                pipeInfo = PipeInfo.FromBoundingBox3D(box);
            }

            if (!NvwApplication.IsAutomated && pipeInfo != null)
            {
                PluginRecord pluginRecord = NvwApplication.Plugins.FindPlugin("NavisworksPipePlugin.Render.ABCD");
                if (pluginRecord is RenderPluginRecord && pluginRecord.IsEnabled)
                {
                    SpherePlugin plugin = (SpherePlugin)(pluginRecord.LoadedPlugin ?? pluginRecord.LoadPlugin());
                    plugin.PipeInfo = pipeInfo;
                    NvwApplication.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.OverlayRender);
                }
            }
        }*/

    }
}
