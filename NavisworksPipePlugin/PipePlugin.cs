using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using NvwApplication = Autodesk.Navisworks.Api.Application;

namespace NavisworksPipePlugin
{
    [Plugin("NavisworksPipePlugin", "ABCD", DisplayName = "Parse Pipes Settings")]
    public class PipePlugin : AddInPlugin
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
    }
}
