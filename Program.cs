using System;

namespace CSharpExample
{
    // Base class demonstrating inheritance
    class Shape
    {
        public double Area;

        // Constructor overloading
        public Shape()
        {
            Area = 0;
        }

        public Shape(double area)
        {
            Area = area;
        }

        // Destructor
        ~Shape()
        {
            Console.WriteLine("Shape object is being destroyed");
        }

        // Static variable to count the number of Shape objects
        public static int shapeCount = 0;

        // Method to display area
        public void DisplayArea()
        {
            Console.WriteLine("Area: " + Area);
        }
    }

    // Derived class demonstrating inheritance
    class Rectangle : Shape
    {
        public double Length;
        public double Width;

        // Constructor overloading
        public Rectangle(double length, double width) : base()
        {
            Length = length;
            Width = width;
            Area = length * width;
            shapeCount++;
        }

        public Rectangle(double length, double width, double area) : base(area)
        {
            Length = length;
            Width = width;
            Area = area;
            shapeCount++;
        }

        // Function Overloading
        public void SetDimensions(double length, double width)
        {
            Length = length;
            Width = width;
            Area = length * width;
        }

        public void SetDimensions(double area)
        {
            Area = area;
        }

        // Operator Overloading
        public static Rectangle operator +(Rectangle r1, Rectangle r2)
        {
            double newLength = r1.Length + r2.Length;
            double newWidth = r1.Width + r2.Width;
            return new Rectangle(newLength, newWidth);
        }

        // Copy Constructor
        public Rectangle(Rectangle other)
        {
            Length = other.Length;
            Width = other.Width;
            Area = other.Area;
            shapeCount++;
        }

        // Destructor
        ~Rectangle()
        {
            Console.WriteLine("Rectangle object is being destroyed");
        }

        // Method to display the rectangle details
        public void DisplayRectangle()
        {
            Console.WriteLine($"Length: {Length}, Width: {Width}, Area: {Area}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Taking user input for Rectangle dimensions
            Console.WriteLine("Enter length of rectangle:");
            double length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter width of rectangle:");
            double width = Convert.ToDouble(Console.ReadLine());

            // Create Rectangle object using constructor overloading
            Rectangle rect1 = new Rectangle(length, width);
            rect1.DisplayRectangle();

            // Create another Rectangle object using constructor overloading
            Rectangle rect2 = new Rectangle(10, 5, 50);
            rect2.DisplayRectangle();

            // Demonstrating function overloading
            rect1.SetDimensions(12, 6);
            Console.WriteLine("Updated rectangle 1 dimensions:");
            rect1.DisplayRectangle();

            // Operator overloading
            Rectangle rect3 = rect1 + rect2; // Adds the dimensions of rect1 and rect2
            Console.WriteLine("Rectangle 3 (sum of rect1 and rect2) dimensions:");
            rect3.DisplayRectangle();

            // Copy constructor
            Rectangle rect4 = new Rectangle(rect1); // Copy rect1 into rect4
            Console.WriteLine("Rectangle 4 (copied from rect1) dimensions:");
            rect4.DisplayRectangle();

            // Displaying the static variable
            Console.WriteLine("Total number of Shape objects created: " + Shape.shapeCount);

            // Wait for user input to close the console
            Console.ReadLine();
        }
    }
}
