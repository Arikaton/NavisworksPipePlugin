using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using NavisworksPipePlugin.Models;

namespace NavisworksPipePlugin
{
    [Plugin("NavisworksPipePlugin.Render", "ABCD", Options = PluginOptions.SupportsControls, SupportsIsSelfEnabled = true)]
    class SpherePlugin : RenderPlugin
    {
        private const float sphereBigRadius = 0.06f;
        private const float sphereSmallRadius = 0.01f;

        public PipeInfoStartEnd PipeInfo = null;

        public override void Render(View view, Autodesk.Navisworks.Api.Graphics graphics)
        {
            if (PipeInfo != null)
            {
                graphics.Color(Color.Red, 1);
                graphics.Sphere(PipeInfo.StartPos, sphereSmallRadius);
                graphics.Sphere(PipeInfo.EndPos, sphereSmallRadius);
            }
            base.Render(view, graphics);
        }
        public override void OverlayRender(View view, Autodesk.Navisworks.Api.Graphics graphics)
        {
            base.OverlayRender(view, graphics);
        }
    }
}
