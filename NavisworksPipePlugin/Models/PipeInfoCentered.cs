using Autodesk.Navisworks.Api;

namespace NavisworksPipePlugin.Models
{
    class PipeInfoCentered : PipeInfo
    {
        public Point3D CenterPoint;

        PipeInfoCentered(Point3D centerPoint)
        {
            CenterPoint = centerPoint;
        }

        public static PipeInfoCentered FromBoundingBox3D(BoundingBox3D box)
        {
            if (box is null)
                return null;
            return new PipeInfoCentered(box.Center);
        }

        public override string FieldInfo()
        {
            return $"Parent Names{sep}Element Name{sep}Center X{sep}Center Y{sep}Center Z";
        }

        public override string ToString()
        {
            return $"{ParentNames}{sep}{ElementName}{sep}{CenterPoint.X}{sep}{CenterPoint.Y}{sep}{CenterPoint.Z}";
        }
    }
}
