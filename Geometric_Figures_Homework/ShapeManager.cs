namespace Geometric_Figures_Homework
{
    using System;

    public class ShapeManager
    {
        private GeometricFigure[] repository;

        public ShapeManager()
        {
            this.repository = new GeometricFigure[0];
        }

        public void RenderShapes(bool boundingBoxActive, bool renderingActive)
        {
            for (int index = 0; index < this.repository.Length; index++)
            {
                try
                {
                    this.repository[index].Draw(boundingBoxActive, renderingActive);
                }
                catch (ArgumentOutOfRangeException) 
                {   
                    // Not allowed to write a message on the console.
                }
            }
        }

        public void AddCircle()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();
            Circle circle = new Circle
            {
                Radius = ShapeManagerUtils.GetIntInputFromUser("radius", 1, int.MaxValue),
                X = ShapeManagerUtils.GetIntInputFromUser("X coordinate", int.MinValue, int.MaxValue),
                Y = ShapeManagerUtils.GetIntInputFromUser("Y coordinate", int.MinValue, int.MaxValue),

                OuterChar = ShapeManagerUtils.GetCharInputFromUser("outer"),
                OuterBackgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("background", "outer"),
                OuterForgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("foreground", "outer"),

                InnerChar = ShapeManagerUtils.GetCharInputFromUser("inner"),
                InnerBackgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("background", "inner"),
                InnerForgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("foreground", "inner")
            };
            this.AddShapeToRepo(circle);
        }

        public void AddRectangle()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();
            Rectangle rectangle = new Rectangle
            {
                Height = ShapeManagerUtils.GetIntInputFromUser("height", 2, int.MaxValue),
                Width = ShapeManagerUtils.GetIntInputFromUser("width", 2, int.MaxValue),
                X = ShapeManagerUtils.GetIntInputFromUser("X", int.MinValue, int.MaxValue),
                Y = ShapeManagerUtils.GetIntInputFromUser("Y", int.MinValue, int.MaxValue),

                OuterChar = ShapeManagerUtils.GetCharInputFromUser("outer"),
                OuterBackgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("background", "outer"),
                OuterForgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("foreground", "outer"),

                InnerChar = ShapeManagerUtils.GetCharInputFromUser("inner"),
                InnerBackgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("background", "inner"),
                InnerForgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("foreground", "inner")
            };
            this.AddShapeToRepo(rectangle);
        }

        public void AddTriangle()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();
            Triangle triangle = new Triangle
            {
                Height = ShapeManagerUtils.GetIntInputFromUser("height", 2, int.MaxValue),
                Orientation = ShapeManagerUtils.PickOrientation(),

                X = ShapeManagerUtils.GetIntInputFromUser("X", int.MinValue, int.MaxValue),
                Y = ShapeManagerUtils.GetIntInputFromUser("Y", int.MinValue, int.MaxValue),

                OuterChar = ShapeManagerUtils.GetCharInputFromUser("outer"),
                OuterBackgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("background", "outer"),
                OuterForgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("foreground", "outer"),

                InnerChar = ShapeManagerUtils.GetCharInputFromUser("inner"),
                InnerBackgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("background", "inner"),
                InnerForgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("foreground", "inner")
            };
            this.AddShapeToRepo(triangle);
        }

        public void SortByCircumference()
        {
            if (this.repository.Length == 1)
            {
                this.repository[0].X = 3;
                this.repository[0].Y = 3;
                return;
            }

            for (int outerLoop = 0; outerLoop < this.repository.Length; outerLoop++)
            {
                for (int innerLoop = 0; innerLoop < this.repository.Length - 1; innerLoop++)
                {
                    if (this.repository[innerLoop].CalculateCircumference() > this.repository[innerLoop + 1].CalculateCircumference())
                    {
                        GeometricFigure tempHolding = this.repository[innerLoop];
                        this.repository[innerLoop] = this.repository[innerLoop + 1];
                        this.repository[innerLoop + 1] = tempHolding;
                    }
                }
            }

            this.ArrangeAccordingToPositionInArray();
        }

        public void SortByArea()
        {
            if (this.repository.Length == 1)
            {
                this.repository[0].X = 3;
                this.repository[0].Y = 3;
                return;
            }

            for (int outerLoop = 0; outerLoop < this.repository.Length; outerLoop++)
            {
                for (int innerLoop = 0; innerLoop < this.repository.Length - 1; innerLoop++)
                {
                    if (this.repository[innerLoop].CalculateArea() > this.repository[innerLoop + 1].CalculateArea())
                    {
                        GeometricFigure tempHolding = this.repository[innerLoop];
                        this.repository[innerLoop] = this.repository[innerLoop + 1];
                        this.repository[innerLoop + 1] = tempHolding;
                    }
                }
            }

            this.ArrangeAccordingToPositionInArray();
        }

        public void EditShap()
        {
            this.DisplayShapInfos();

            if (this.repository.Length == 0)
            {
                Console.WriteLine("oops! No shapes to edit");
                Console.ReadKey();
                return;
            }

            int selectedIndexToEdit = ShapeManagerUtils.GetIntInputFromUser("index to edit", 0, this.repository.Length);
            do
            {
                this.EditShape(selectedIndexToEdit);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            this.AllowUserToSwapIndexes(selectedIndexToEdit);
        }

        public void DeleteShape()
        {
            this.DisplayShapInfos();

            if (this.repository.Length == 0)
            {
                Console.WriteLine("oops! No shapes to delete");
                Console.ReadKey();
                return;
            }

            int selectedIndexToDelete = ShapeManagerUtils.GetIntInputFromUser("index to delete", 0, this.repository.Length);
            this.DeleteShapFromRepo(selectedIndexToDelete);
        }

        private void AllowUserToSwapIndexes(int selectedIndexToEdit)
        {
            Console.Clear();
            Console.WriteLine("If you would u like to change the internal index of the shape write 'yes' \nor press any key to go back to main menu!");
            while (true)
            {
                string answer = Console.ReadLine().ToUpper();
                if (answer == "YES")
                {
                    int selectedIndexToSwapWith = ShapeManagerUtils.GetIntInputFromUser("index to swap with", 0, this.repository.Length);
                    GeometricFigure temporaryHolding = this.repository[selectedIndexToEdit];
                    this.repository[selectedIndexToEdit] = this.repository[selectedIndexToSwapWith];
                    this.repository[selectedIndexToSwapWith] = temporaryHolding;
                }
                else
                {
                    return;
                }
            }
        }

        private void DisplayShapInfos()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();
            for (int index = 0; index < this.repository.Length; index++)
            {
                this.repository[index].PrintInfo(index);
            }
        }

        private void EditShape(int selectedIndexToDelete)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();
            GeometricFigure geometricFigure = this.repository[selectedIndexToDelete];
            geometricFigure.PrintInfo(selectedIndexToDelete);
            geometricFigure.EditInfo();
        }

        private void AddShapeToRepo(GeometricFigure figure)
        {
            int maxLength = this.repository.Length;
            GeometricFigure[] newRepository = new GeometricFigure[this.repository.Length + 1];

            for (int index = 0; index < maxLength; index++)
            {
                newRepository[index] = this.repository[index];
            }

            newRepository[maxLength] = figure;
            this.repository = newRepository;
        }

        private void DeleteShapFromRepo(int selectedIndexToDelete)
        {
            GeometricFigure[] newRepository = new GeometricFigure[this.repository.Length - 1];

            for (int index = 0; index < selectedIndexToDelete; index++)
            {
                newRepository[index] = this.repository[index];
            }

            for (int index = selectedIndexToDelete + 1; index < this.repository.Length; index++)
            {
                newRepository[index - 1] = this.repository[index];
            }

            this.repository = newRepository;
        }

        private void ArrangeAccordingToPositionInArray()
        {
            for (int index = 1; index <= this.repository.Length; index++)
            {
                GeometricFigure tempHolding = this.repository[index - 1];
                tempHolding.X = index * 3;
                tempHolding.Y = index * 3;
            }
        }
    }
}