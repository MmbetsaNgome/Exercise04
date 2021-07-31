using System;
using System.Collections.Generic;
using static Exercise04.Program.Shape;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

namespace Exercise04
{
    class Program
    {
        static void Main(string[] args)
        { }
        //creates the shapes class
        public class Shape {
            public class Circle
            {
                public string Colour;
                public double Radius;
            }
            public class Rectangle
            {
                public string Colour;
                public double Height;
                public double Width;
            } }
        // handling the xml 
        public static void SaveData(object IClass, string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer xml = new XmlSerializer((IClass.GetType()));
                writer = new StreamWriter(filename);
                xml.Serialize(writer, IClass);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
                writer = null;
            }
        }
        public class xmlLoad<T>
        {
            public static Type type;

            public xmlLoad()
            {
                type = typeof(T);
            }

            public T LoadData(string filename)
            {
                T result;
                XmlSerializer xml = new XmlSerializer(type);
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                result = (T)xml.Deserialize(fs);
                fs.Close();
                return result;
            }
        }
        // end of handling xml
        public partial class ShapeData
        {
            //saving the shapes to the xml file
            private void Click(object sender, EventArgs e)
            {
                saveFileDialog.InitialDirectory = @"C:\Users\Asena\Documents\Visual Studio 2019\Projects\Exercise04";
                saveFileDialog.Filter = "xml Files (*.xml)|*.xml";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Shape shape = new Shape();
                    new Circle { Colour = "Red", Radius = 2.5 };
                    new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 };
                    new Circle { Colour = "Red", Radius = 2.5 };
                    new Circle { Colour = "Red", Radius = 2.5 };
                    new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 };
                }
            }
        }
        //loading the data from the xml file
            private void Shape_Load(object sender, EventArgs e)
            {
                Shape shapes = new Shape();
                xmlLoad<Shape> loadShape = new xmlLoad<Shape>();

                shapes = loadShape.LoadData("shape.xml");
                foreach ( shape in shapes)
                {
                    Console.WriteLine("{0} is shape {1} and has an area of {area}");
                    item.GetType().Name, item.Colour, item.Area;
                }
            }
        }



    }
       
    }
