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

namespace Grafika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Trackball _trackball;

        public MainWindow()
        {
            InitializeComponent();
        }

        public Point3D ToPoint(Vector3D vec)
        {
            return new Point3D(vec.X, vec.Y, vec.Z);
        }

        public Vector3D ToVector3D(Point3D point)
        {
            return new Vector3D(point.X, point.Y, point.Z);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            graphic.AddModel(CreateCoord());
        }

        private Model3D CreateCoord()
        {
            double size = 1;
            double div = 3;
            MeshGeometry3D meshX = new MeshGeometry3D
            {
                Positions = new Point3DCollection
                {
                new Point3D(0,0,0),
                new Point3D(size, 0,0),
                new Point3D(0,size/div,0)
                }
            };

            MeshGeometry3D meshY = new MeshGeometry3D
            {
                Positions = new Point3DCollection
                {
                new Point3D(0,0,0),
                new Point3D(0, size,0),
                new Point3D(0,0,size/div)
                }
            };

            MeshGeometry3D meshZ = new MeshGeometry3D
            {
                Positions = new Point3DCollection
                {
                new Point3D(0,0,0),
                new Point3D(0,0,size),
                new Point3D(size/div,0,0)
                }
            };

            var matX = new DiffuseMaterial(Brushes.Red);
            var geoX = new GeometryModel3D(meshX, matX)
            {
                BackMaterial = matX
            };

            var matY = new DiffuseMaterial(Brushes.Green);
            var geoY = new GeometryModel3D(meshY, matY)
            {
                BackMaterial = matY
            };

            var matZ = new DiffuseMaterial(Brushes.Blue);
            var geoZ = new GeometryModel3D(meshZ, matZ)
            {
                BackMaterial = matZ
            };

            var group = new Model3DGroup();
            group.Children.Add(geoX);
            group.Children.Add(geoY);
            group.Children.Add(geoZ);

            return group;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //graphic.Yaw(1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //graphic.Yaw(-1);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //graphic.Pitch(1);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //graphic.Pitch(-1);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            group.Children.Add(CreateCoord());

            // setup trackball for moving the model around
            _trackball = new Trackball();
            _trackball.Attach(this);
            _trackball.Slaves.Add(viewport);
            _trackball.Enabled = true;

        }
    }
}
