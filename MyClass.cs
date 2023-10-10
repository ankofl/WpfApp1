using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp1.Geometry;

namespace WpfApp1
{
    public static class MyClass
    {
        private static MainWindow? mw = null;
        public static void MyMethod()
        {
            mw = new MainWindow();
            mw.btnStart.Click += BtnStart_Click;
            mw.ShowDialog();
        }
        private static void BtnStart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (mw != null)
            {
                mw.txtResult.Clear();
                try
                {
                    XYZ A = new XYZ(Convert.ToDouble(mw.txtAx.Text), Convert.ToDouble(mw.txtAy.Text), Convert.ToDouble(mw.txtAz.Text));
                    XYZ B = new XYZ(Convert.ToDouble(mw.txtBx.Text), Convert.ToDouble(mw.txtBy.Text), Convert.ToDouble(mw.txtBz.Text));
                    XYZ C = new XYZ(Convert.ToDouble(mw.txtCx.Text), Convert.ToDouble(mw.txtCy.Text), Convert.ToDouble(mw.txtCz.Text));
                    XYZ D = new XYZ(Convert.ToDouble(mw.txtDx.Text), Convert.ToDouble(mw.txtDy.Text), Convert.ToDouble(mw.txtDz.Text));

                    Line AB = new Line(A, B);
                    Line CD = new Line(C, D);
                    try
                    {
                        int i = 100000000;
                        while (i > 0)
                        {
                            foreach (XYZ pt in AB.Inter(CD))
                            {
                                //mw.txtResult.Text += pt.Write() + '\n';
                            }
                            i--;
                        }
                    }
                    catch { }
                    mw.btnStart.Background = Brushes.LightGray;
                }
                catch
                {
                    mw.btnStart.Background = Brushes.Red;
                }
            }
        }
    }
}
