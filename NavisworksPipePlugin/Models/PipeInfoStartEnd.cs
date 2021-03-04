using Autodesk.Navisworks.Api;

namespace NavisworksPipePlugin.Models
{
    class PipeInfoStartEnd : PipeInfo
    {
        public Point3D StartPos;
        public Point3D EndPos;
        public float Radius;

        public PipeInfoStartEnd(Point3D startPos, Point3D endPos, float radius)
        {
            StartPos = startPos;
            EndPos = endPos;
            Radius = radius;
        }

        public static PipeInfoStartEnd FromBoundingBox3D(BoundingBox3D box)
        {
            if (box is null)
                return null;
            var distanceX = box.Max.X - box.Min.X;
            var distanceY = box.Max.Y - box.Min.Y;
            var distanceZ = box.Max.Z - box.Min.Z;
            Point3D startPoint;
            Point3D endPoint;
            float radius;

            if (FirstIsMax(distanceX, distanceY, distanceZ))
            {
                radius = (float)distanceY / 2;
                startPoint = new Point3D(box.Min.X, box.Center.Y, box.Center.Z);
                endPoint = new Point3D(box.Max.X, box.Center.Y, box.Center.Z);
                return new PipeInfoStartEnd(startPoint, endPoint, radius);
            }
            if (FirstIsMax(distanceY, distanceX, distanceZ))
            {
                radius = (float)distanceY / 2;
                startPoint = new Point3D(box.Center.X, box.Min.Y, box.Center.Z);
                endPoint = new Point3D(box.Center.X, box.Max.Y, box.Center.Z);
                return new PipeInfoStartEnd(startPoint, endPoint, radius);
            }
            if (FirstIsMax(distanceZ, distanceX, distanceY))
            {
                radius = (float)distanceY / 2;
                startPoint = new Point3D(box.Center.X, box.Center.Y, box.Min.Z);
                endPoint = new Point3D(box.Center.X, box.Center.Y, box.Max.Z);
                return new PipeInfoStartEnd(startPoint, endPoint, radius);
            }

            return null;
        }

        private static bool FirstIsMax(double first, double second, double thrid)
        {
            return first > second && first > thrid;
        }

        public override string FieldInfo()
        {
            return $"Parent Names{sep}Element Name{sep}Start X{sep}Start Y{sep}Start Z{sep}End X{sep}End Y{sep}End Z{sep}Radius";
        }

        public override string ToString()
        {
            return $"{ParentNames}{sep}{ElementName}{sep}{StartPos.X}{sep}{StartPos.Y}{sep}{StartPos.Z}{sep}{EndPos.X}{sep}{EndPos.Y}{sep}{EndPos.Z}{sep}{Radius}";
        }
    }
}
