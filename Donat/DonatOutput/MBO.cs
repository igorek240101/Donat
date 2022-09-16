using System.Security.Cryptography.X509Certificates;

namespace DonatOutput
{
    internal class MBO
    {
        class Point : IComparable<Point>
        {
            private int[] coordinates = new int[2];

            public int X { get => coordinates[0]; }
            public int Y { get => coordinates[1]; }

            public Point(int x, int y)
            {
                coordinates[0] = x;
                coordinates[1] = y;
            }

            public double this[int index]
            {
                get { return coordinates[index]; }
            }

            public double Distance(Point other)
            {
                double dx = this[0] - other[0];
                double dy = this[1] - other[1];
                return Math.Sqrt(dx * dx + dy * dy);
            }

            public override string ToString()
            {
                return String.Format("({0}; {1})", this[0], this[1]);
            }

            public int CompareTo(Point other)
            {
                int compare = Math.Sign(other[1] - this[1]);
                if (compare == 0) compare = Math.Sign(this[0] - other[0]);
                return compare;
            }
        }

        class Line : IComparable<Line>
        {
            private Point[] points = new Point[2];
            private double? alpha = null;
            private double? length = null;

            public Line(Point a, Point b)
            {
                points[0] = a;
                points[1] = b;
            }

            public Point this[int index]
            {
                get { return points[index]; }
            }

            public double Alpha
            {
                get
                {
                    if (alpha == null)
                    {
                        alpha = Math.Atan2(this[1][1] - this[0][1], this[1][0] - this[0][0]);
                        if (alpha < 0.0) alpha += Math.PI + Math.PI;
                    }
                    return (double)alpha;
                }
            }

            public double Length
            {
                get
                {
                    if (length == null)
                    {
                        length = this[0].Distance(this[1]);
                    }
                    return (double)length;
                }
            }

            public int CompareTo(Line other)
            {
                int compare = Math.Sign(this.Alpha - other.Alpha);
                if (compare == 0) compare = Math.Sign(other.Length - this.Length);
                return compare;
            }
        }

        class Corner : IComparable<Corner>
        {
            private Line[] lines = new Line[2];
            private double? phi = null;

            public Corner(Line ab, Point c)
            {
                lines[0] = ab;
                lines[1] = new Line(ab[1], c);
            }

            public Line this[int index]
            {
                get { return lines[index]; }
            }

            public double Phi
            {
                get
                {
                    if (phi == null)
                    {
                        phi = this[1].Alpha - this[0].Alpha;
                        if (phi < 0.0) phi += Math.PI + Math.PI;
                    }
                    return (double)phi;
                }
            }

            public int CompareTo(Corner other)
            {
                int compare = Math.Sign(this.Phi - other.Phi);
                if (compare == 0) compare = Math.Sign(other[1].Length - this[1].Length);
                return compare;
            }
        }

        public static List<(int, int)> MBOMethod(List<(int, int)> inputPoints)
        {
            List<Point> points = new List<Point>();
            foreach (var value in inputPoints)
                points.Add(new Point(value.Item1, value.Item2));
            Point first = points.Max();
            Line last = points
                .Where(p => p.CompareTo(first) != 0)
                .Select(p => new Line(first, p))
                .Min();
            List<Line> lines = new List<Line>();
            lines.Add(last);
            while ((last = lines[lines.Count - 1])[1].CompareTo(first) != 0)
            {
                Corner corner = points
                    .Where(p => p.CompareTo(last[0]) != 0 && p.CompareTo(last[1]) != 0)
                    .Select(p => new Corner(last, p))
                    .Min();
                lines.Add(corner[1]);
            }
            return lines.ConvertAll(t => (t[0].X, t[0].Y));
        }
    }
}
