using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicControl
{
    /// <summary>
    /// Interaction logic for GraphicControl.xaml
    /// </summary>
    public partial class GraphicControl : UserControl
    {
        private readonly Trackball _trackball;      

        public GraphicControl()
        {
            InitializeComponent();

            _trackball = new Trackball();
            _trackball.Attach(this);
            _trackball.Slaves.Add(viewport);
            _trackball.Enabled = true;
        }

        public void AddModel(Model3D model)
        {
            group.Children.Add(model);
        }

        public Point3D ToPoint(Vector3D vec)
        {
            return new Point3D(vec.X, vec.Y, vec.Z);
        }

        public Vector3D ToVector3D(Point3D point)
        {
            return new Vector3D(point.X, point.Y, point.Z);
        }
    }
}
