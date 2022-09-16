using DonatAbstract;

namespace DonatOutput
{
    public partial class Output : Form
    {
        Vector O = new Vector(0, 0, 5);
        Vector R = new Vector(1, 0, 0);
        Vector r = new Vector(0, 0, -1);
        Vector pR = new Vector(0, 1, 0);
        double angel;
        int x = -300, y = 300, z = -300;
        double perspective = 0.01;
        readonly int dist = 1;
        Vector point1;
        Vector point2;

        public int Angel
        {
            set { angel = value*Math.PI/180; }
        }


        List<(Vector, byte)> res = new List<(Vector, byte)>();

        public Output(int i, int j, int k, Vector point1, Vector point2, int angel)
        {
            InitializeComponent();
            dist = i;
            R *= k;
            pR *= k;
            r *= j;
            this.point1 = point1;
            this.point2 = point2;
            this.Angel = angel;
            Init();
        }

        public Output()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            double absR = R.Distance();
            double absr = r.Distance();
            /*
            for (int i = 0; i <= 25; i++)
            {
                for (int j = 0; j <= 25; j++)
                {
                    for (int k = 0; k <= 25; k++)
                    {
                        Vector v = new Vector(i, j, k);
                        double dist = v.Distance();
                        double normal = Math.Sqrt((v.X * v.X) + (v.Y * v.Y) + (v.Z * v.Z));
                        if (normal == 0) continue;
                        double x = v.X / normal, y = v.Y / normal, z = v.Z / normal;
                        double d = Math.Sqrt(y * y + z * z);
                        if (d != 0)
                        {
                            v = new Vector(
                                v.X,
                                (int)Math.Round(((z / d) * v.Y) - ((y / d) * v.Z)),
                                (int)Math.Round(((y / d) * v.Y) + ((z / d) * v.Z)));
                            if (v.Y != 0 && v.Distance() == Math.Round(dist)) throw new Exception();
                            normal = Math.Sqrt((v.X * v.X) + (v.Z * v.Z));
                            if (normal == 0) continue;
                            x = v.X / normal;
                            z = v.Z / normal;
                            d = Math.Sqrt(x * x + z * z);
                            if (d != 0)
                            {
                                v = new Vector(
                                (int)Math.Round(((z / d) * v.X) - ((x / d) * v.Z)),
                                v.Y,
                                (int)Math.Round(((x / d) * v.X) + ((z / d) * v.Z)));
                                if (v.X != 0) throw new Exception();
                            }
                        }
                    }
                }
            }
            */
            Vector v1 = R + (R * ((absr * 2) / absR));
            Vector v2 = pR + (pR * ((absr * 2) / absR));
            Vector v3 = r.Abs() + v1.Abs() + v2.Abs();
            Vector v4 = -r.Abs() - v1.Abs() - v2.Abs();
            for (int i = v4.X; i <= v3.X; i += dist)
            {
                for (int j = v4.Y; j <= v3.Y; j += dist)
                {
                    for (int k = v4.Z; k <= v3.Z; k += dist)
                    {
                        var val = Math.Pow(Math.Sqrt((i * i) + (j * j)) - (absR + absr), 2) + (k * k) - (absr * absr);
                        if (val <= 0)
                        {
                            if (k < 0)
                            {
                                if (j < 0)
                                {
                                    if (i < 0)
                                        res.Add((new Vector(i, j, k), 0));
                                    else
                                        res.Add((new Vector(i, j, k), 1));
                                }
                                else
                                {
                                    if (i < 0)
                                        res.Add((new Vector(i, j, k), 2));
                                    else
                                        res.Add((new Vector(i, j, k), 3));
                                }
                            }
                            else
                            {
                                if (j < 0)
                                {
                                    if (i < 0)
                                        res.Add((new Vector(i, j, k), 4));
                                    else
                                        res.Add((new Vector(i, j, k), 5));
                                }
                                else
                                {
                                    if (i < 0)
                                        res.Add((new Vector(i, j, k), 6));
                                    else
                                        res.Add((new Vector(i, j, k), 7));
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < res.Count; i++) res[i] = (res[i].Item1 + O, res[i].Item2);
            Refresh();
        }

        private void Output_Paint(object sender, PaintEventArgs e)
        {
            Dictionary<(int, int), (Vector, byte)> values = new Dictionary<(int, int), (Vector, byte)>();
            foreach (var value in res)
            {
                (Vector, byte) now;
                if (values.TryGetValue((value.Item1.X, value.Item1.Y), out now))
                {
                    if (now.Item1.Z > value.Item1.Z)
                    {
                        values.Remove((value.Item1.X, value.Item1.Y));
                        values.Add((value.Item1.X, value.Item1.Y), value);
                    }
                }
                else
                {
                    values.Add((value.Item1.X, value.Item1.Y), value);
                }
            }
            Graphics graphics = this.CreateGraphics();
            Pen white = new Pen(Color.White);
            Pen red = new Pen(Color.Red);
            Pen green = new Pen(Color.Green);
            Pen blue = new Pen(Color.Blue);
            Pen brown = new Pen(Color.Brown);
            Pen yellow = new Pen(Color.Yellow);
            Pen orange = new Pen(Color.Orange);
            Pen purple = new Pen(Color.Purple);
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush redBrush = new SolidBrush(Color.Red);
            Brush greenBrush = new SolidBrush(Color.Green);
            Brush blueBrush = new SolidBrush(Color.Blue);
            Brush brownBrush = new SolidBrush(Color.Brown);
            Brush yellowBrush = new SolidBrush(Color.Yellow);
            Brush orangeBrush = new SolidBrush(Color.Orange);
            Brush purpleBrush = new SolidBrush(Color.Purple);
            graphics.DrawLine(new Pen(Color.White, 10), point1.X - x, y - point1.Y, point2.X - x, y - point2.Y);
            var resValues = values.Values.ToList().ConvertAll(t => (new Vector(t.Item1.X - x, y - t.Item1.Y, t.Item1.Z),t.Item2)).OrderByDescending(t => t.Item1.Z);
            /*
            List<List<KeyValuePair<(int, int), (Vector, Vector, Vector, Vector, byte)>>> sort = new List<List<KeyValuePair<(int, int), (Vector, Vector, Vector, Vector, byte)>>>();
            for (int i = 0; i < 7; i++)
            {
                var value = values.Where(t => t.Value.Item5 == i).ToList();
                if (value.Count > 0)
                {
                    var count = value.Min(t => t.Value.Item1);
                    bool mark = false;
                    /*
                    for (int j = 0; j < sort.Count; j++)
                    {
                        if (sort[j].Value >= count)
                        {
                            sort.Insert(j, KeyValuePair.Create(value, count));
                            mark = true;
                            break;
                        }
                    }
                    if (i == 0 || mark)
            sort.Add(value);
                }
            }
            foreach (var pair in sort)
            {
                if (pair.Count > 2)
                {
                    graphics.FillPolygon(pair.FirstOrDefault().Value.Item5 switch
                    {
                        0 => whiteBrush,
                        1 => redBrush,
                        2 => greenBrush,
                        3 => blueBrush,
                        4 => brownBrush,
                        5 => yellowBrush,
                        6 => orangeBrush,
                        7 => purpleBrush
                    }, MBO.MBOMethod(pair.ConvertAll(t => (t.Key.Item1, t.Key.Item2))).ConvertAll(t => new Point(t.Item1, t.Item2)).ToArray());
                }
            }
            */
            foreach (var value in resValues)
            {
                switch (value.Item2)
                {
                    case 0:
                        {
                            graphics.FillRectangle(whiteBrush, value.Item1.X, value.Item1.Y, dist, dist);
                        }
                        break;
                    case 1:
                        {
                            graphics.FillRectangle(redBrush, value.Item1.X, value.Item1.Y, dist, dist);
                        }
                        break;
                    case 2:
                        {
                            graphics.FillRectangle(greenBrush, value.Item1.X, value.Item1.Y, dist, dist);
                        }
                        break;
                    case 3:
                        {
                            graphics.FillRectangle(blueBrush, value.Item1.X, value.Item1.Y, dist, dist);
                        }
                        break;
                    case 4:
                        {
                            graphics.FillRectangle(brownBrush, value.Item1.X, value.Item1.Y, dist, dist);
                        }
                        break;
                    case 5:
                        {
                            graphics.FillRectangle(yellowBrush, value.Item1.X, value.Item1.Y, dist, dist);
                        }
                        break;
                    case 6:
                        {
                            graphics.FillRectangle(orangeBrush, value.Item1.X, value.Item1.Y, dist, dist);
                        }
                        break;
                    case 7:
                        {
                            graphics.FillRectangle(purpleBrush, value.Item1.X, value.Item1.Y, dist, dist);
                        }
                        break;
                }
            }
        }

        private (int, int, int) Mult((int, int, int) v, double s) => ((int)(v.Item1 * s), (int)(v.Item2 * s), (int)(v.Item3 * s));

        private void Output_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        Rotate(-angel);
                        break;
                    }
                case Keys.Right:
                    {
                        Rotate(angel);
                        break;
                    }
            }
        }

        private (int, int, int) Abs((int, int, int) v) => (Math.Abs(v.Item1), Math.Abs(v.Item2), Math.Abs(v.Item3));

        private void Rotate(double deagree)
        {

            var sin = Math.Sin(deagree);
            var cos = Math.Cos(deagree);
            for (int i = 0; i < res.Count; i++)
            {
                res[i] = (new Vector(res[i].Item1.X - point1.X,
                                    res[i].Item1.Y - point1.Y,
                                    res[i].Item1.Z - point1.Z), res[i].Item2);
                Vector e1 = point2 - point1;
                Vector? e2 = null;
                double normal = Math.Sqrt((e1.X * e1.X) + (e1.Y * e1.Y) + (e1.Z * e1.Z));
                double cosX = 0, sinX = 0, cosY = 0, sinY = 0;
                if(normal != 0)
                {
                    double y = e1.Y / normal, z = e1.Z / normal;
                    double d = Math.Sqrt(y * y + z * z);
                    if (d != 0)
                    {
                        cosX = z / d;
                        sinX = y / d;
                        e2 = new Vector(
                                e1.X,
                                (int)Math.Round((cosX * e1.Y) - (sinX * e1.Z)),
                                (int)Math.Round((sinX * e1.Y) + (cosX * e1.Z)));
                        res[i] = (new Vector(
                                res[i].Item1.X,
                                (int)Math.Round((cosX * res[i].Item1.Y) - (sinX * res[i].Item1.Z)),
                                (int)Math.Round((sinX * res[i].Item1.Y) + (cosX * res[i].Item1.Z))), res[i].Item2);
                    }
                    if (e2 == null) e2 = e1;
                    normal = Math.Sqrt((e2.Value.X * e2.Value.X) + (e2.Value.Z * e2.Value.Z));
                    if (normal != 0)
                    {
                        double x = e2.Value.X / normal;
                        z = e2.Value.Z / normal;
                        d = Math.Sqrt(x * x + z * z);
                        cosY = z / d;
                        sinY = x / d;
                        Vector e3 = new Vector(
                                (int)Math.Round((cosY * e2.Value.X) - (sinY * e2.Value.Z)),
                                e2.Value.Y,
                                (int)Math.Round((sinY * e2.Value.X) + (cosY * e2.Value.Z)));
                        res[i] = (new Vector(
                                (int)Math.Round((cosY * res[i].Item1.X) - (sinY * res[i].Item1.Z)),
                                res[i].Item1.Y,
                                (int)Math.Round((sinY * res[i].Item1.X) + (cosY * res[i].Item1.Z))), res[i].Item2);
                    }
                }
                res[i] = (new Vector(
                                (int)Math.Round((cos * res[i].Item1.X) - (sin * res[i].Item1.Y)),
                                (int)Math.Round((sin * res[i].Item1.X) + (cos * res[i].Item1.Y)),
                                res[i].Item1.Z), res[i].Item2);
                if (cosY != 0 || sinY != 0)
                    res[i] = (new Vector(
                                    (int)Math.Round((cosY * res[i].Item1.X) + (sinY * res[i].Item1.Z)),
                                    res[i].Item1.Y,
                                    (int)Math.Round((-sinY * res[i].Item1.X) + (cosY * res[i].Item1.Z))), res[i].Item2);
                if (cosX != 0 || sinX != 0)
                    res[i] = (new Vector(
                                res[i].Item1.X,
                                (int)Math.Round((cosX * res[i].Item1.Y) + (sinX * res[i].Item1.Z)),
                                (int)Math.Round((-sinX * res[i].Item1.Y) + (cosX * res[i].Item1.Z))), res[i].Item2);
                res[i] = (new Vector(res[i].Item1.X + point1.X,
                                    res[i].Item1.Y + point1.Y,
                                    res[i].Item1.Z + point1.Z), res[i].Item2);
                /*
                res[i] = (new Vector((int)Math.Round((cos * res[i].Item1.X) + (sin * res[i].Item1.Z) - (O.X * cos) - (O.Z * sin) + O.X),
                         res[i].Item1.Y,
                         (int)Math.Round((cos * res[i].Item1.Z) - (sin * res[i].Item1.X) + (O.Y * sin) - (O.Z * cos) + O.Z)), res[i].Item2);*/
            }
            Refresh();
        }
    }
}
