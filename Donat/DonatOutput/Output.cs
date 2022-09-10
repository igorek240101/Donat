using System.Data;

namespace DonatOutput
{
    public partial class Output : Form
    {
        (int, int, int) O = (100, 100, 5);
        (int, int, int) R = (10, 0, 0);
        (int, int, int) r = (0, 0, -10);
        (int, int, int) pR = (0, 10, 0);
        int x = 0, y = 0, z = 0;
        double perspective = 0.01;


        List<(int, int, int)> res = new List<(int, int, int)>();

        public Output()
        {
            InitializeComponent();
            double absR = Dist(R);
            double absr = Dist(r);

            (int, int, int) v1 = Add(R, Mult(R, (absr * 2) / absR));
            (int, int, int) v2 = Add(pR, Mult(pR, (absr * 2) / absR));
            (int, int, int) v3 = Add(Abs(r), Add(Abs(v1), Abs(v2)));
            (int, int, int) v4 = Add(Mult(Abs(r), -1), Add(Mult(Abs(v1), -1), Mult(Abs(v2), -1)));
            for (int i = v4.Item1; i <= v3.Item1; i+=3)
            {
                for (int j = v4.Item2; j <= v3.Item2; j+=3)
                {
                    for (int k = v4.Item3; k <= v3.Item3; k+=3)
                    {
                        var val = Math.Pow(Math.Sqrt((i * i) + (j * j)) - (absR + absr), 2) + (k * k) - (absr * absr);
                        if (val <= 0) //&& res.Where(t => t.Item1 == i && t.Item2 == j).All(t => t.Item3 > k))
                        {
                            //res.RemoveAll(t => t.Item1 == i && t.Item2 == j);
                            res.Add((i, j, k));
                        }
                    }
                }
            }
            for (int i = 0; i < res.Count; i++) res[i] = Add(O, res[i]);
            Invalidate();
            //Rotate(Math.PI/4);
        }

        private double Dist((int, int, int) v1, (int, int, int) v2)
        {
            return Math.Sqrt(Math.Pow(v1.Item1 - v2.Item1, 2) + Math.Pow(v1.Item2 - v2.Item2, 2) + Math.Pow(v1.Item3 - v2.Item3, 2));
        }

        private double Dist((int, int, int) v)
        {
            return Math.Sqrt(Math.Pow(v.Item1, 2) + Math.Pow(v.Item2, 2) + Math.Pow(v.Item3, 2));
        }

        private (int, int, int) Add((int, int, int) v1, (int, int, int) v2) => (v1.Item1 + v2.Item1, v1.Item2 + v2.Item2, v1.Item3 + v2.Item3);
        private (int, int, int) Remove((int, int, int) v1, (int, int, int) v2) => (v1.Item1 - v2.Item1, v1.Item2 - v2.Item2, v1.Item3 - v2.Item3);

        private void Output_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 255, 255));
            foreach (var value in res)
            {
                graphics.DrawEllipse(pen, value.Item1, value.Item2, 2, 2);
            }
        }

        private (int, int, int) Mult((int, int, int) v, double s) => ((int)(v.Item1 * s), (int)(v.Item2 * s), (int)(v.Item3 * s));

        private (int, int, int) Abs((int, int, int) v) => (Math.Abs(v.Item1), Math.Abs(v.Item2), Math.Abs(v.Item3));

        private void Rotate(double deagree)
        {
            var sin = Math.Sin(deagree);
            var cos = Math.Cos(deagree);
            for(int i = 0; i < res.Count; i++)
            {
                res[i] = ((int)((cos * res[i].Item1) + (sin * res[i].Item3) - (O.Item1 * cos) - (O.Item3 * sin) + O.Item1),
                         res[i].Item2,
                         (int)((cos * res[i].Item3) - (sin * res[i].Item1) + (O.Item2 * sin) - (O.Item3 * cos) + O.Item3));
            }
            Invalidate();
        }
    }
}
