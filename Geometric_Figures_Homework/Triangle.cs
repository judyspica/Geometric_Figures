namespace Geometric_Figures_Homework
{
    using System;

    public class Triangle : GeometricFigure
    {
        public Orientation Orientation { get; set; }

        public int Height { get; set; }

        public override double CalculateArea()
        {
            return 0.5 * this.Height * this.Height;
        }

        public override double CalculateCircumference()
        {
            return Math.Sqrt((this.Height * this.Height) + (this.Height * this.Height)) + this.Height + this.Height;
        }

        public override void Draw(bool boundingBoxActive, bool renderingActive)
        {
            if (this.X >= Console.LargestWindowWidth || this.Y >= Console.LargestWindowHeight)
            {
                return;
            } 

            Console.SetCursorPosition(this.X, this.Y);

            switch (Orientation)
            {
                case Orientation.CORNER_BOTTOM_LEFT:
                    this.DrawTriangleCornerBottomLeft(renderingActive);
                    break;
                case Orientation.CORNER_BOTTOM_RIGHT:
                    this.DrawTriangleCornerBottomRight(renderingActive);
                    break;
                case Orientation.CORNER_TOP_LEFT:
                    this.DrawTriangleCornerTopLeft(renderingActive);
                    break;
                case Orientation.CORNER_TOP_RIGHT:
                    this.DrawTriangleCornerTopRight(renderingActive);
                    break;
            }

            if (boundingBoxActive)
            {
                this.DrawBoundingBoxOnTop();
            }
        }

        public override void EditInfo()
        {
            string attributeToChange = SelectAttributeToChange("Orientation", "Hight", "X", "Y", "OuterChar", "OuterBackgroundColor", "OuterForgroundColor", "InnerChar", "InnerBackgroundColor", "InnerForgroundColor");
            this.ChangeAttribute(attributeToChange);
            ShapeManagerUtils.ShowEditSuccessMessage();
        }

        public override void PrintInfo(int index)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Triangle @ index {index}: Height: {Height} | X: {X} | Y: {Y} | Inner char: {InnerChar} | Inner foreground color: {InnerForgroundColor} | Inner background color: {InnerBackgroundColor} | Outer char: {OuterChar} | Outer foreground color : {OuterForgroundColor} | Outer background color : {OuterBackgroundColor}");
            Console.ResetColor();
        }

        private void DrawBoundingBoxOnTop()
        {
            Console.SetCursorPosition(this.X, this.Y);
            int row = this.Height;
            int col = this.Height;
            char[,] rectangle = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (j + this.X >= Console.LargestWindowWidth || i + this.Y >= Console.LargestWindowHeight)
                    {
                        break;
                    }

                    if (i == 0 || j == 0 || i == row - 1)
                    {
                        Console.SetCursorPosition(j + this.X, i + this.Y);
                        rectangle[i, j] = '+';
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(rectangle[i, j]);
                        Console.ResetColor();
                    }

                    if (j == col - 1)
                    {
                        Console.SetCursorPosition(j + this.X, i + this.Y);
                        rectangle[i, j] = '+';
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(rectangle[i, j]);
                        Console.ResetColor();
                    }
                }

                Console.SetCursorPosition(this.X, this.Y + i);
            }
        }

        private void DrawTriangleCornerTopRight(bool renderingActive)
        {
            for (int i = 1; i <= this.Height; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    Console.Write(" ");
                    if (Console.CursorLeft + 1 >= Console.LargestWindowWidth)
                    {
                        break;
                    }
                }

                for (int j = i; j <= this.Height; j++)
                {
                    if (Console.CursorLeft + 1 >= Console.LargestWindowWidth)
                    {
                        break;
                    }

                    if (j == i || j == this.Height || i == 1)
                    {
                        Console.ForegroundColor = this.OuterForgroundColor;
                        Console.BackgroundColor = this.OuterBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromeColor();
                        }

                        Console.Write(this.OuterChar);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = this.InnerForgroundColor;
                        Console.BackgroundColor = this.InnerBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromeColor();
                        }

                        Console.Write(this.InnerChar);
                        Console.ResetColor();
                    }
                }

                Console.SetCursorPosition(this.X, this.Y + i);
            }
        }

        private void DrawTriangleCornerTopLeft(bool renderingActive)
        {
            for (int i = 1; i <= this.Height; i++)
            {
                for (int j = i; j <= this.Height; j++)
                {
                    if (this.X + j >= Console.LargestWindowWidth)
                    {
                        break;
                    }

                    if (i == 1 || j == i || j == this.Height)
                    {
                        Console.ForegroundColor = this.OuterForgroundColor;
                        Console.BackgroundColor = this.OuterBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromeColor();
                        }

                        Console.Write(this.OuterChar);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = this.InnerForgroundColor;
                        Console.BackgroundColor = this.InnerBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromeColor();
                        }

                        Console.Write(this.InnerChar);
                        Console.ResetColor();
                    }
                }

                for (int k = 1; k < i; k++)
                {
                    Console.Write(" ");
                }

                Console.SetCursorPosition(this.X, this.Y + i);
            }
        }

        private void DrawTriangleCornerBottomRight(bool renderingActive)
        {
            for (int i = 1; i <= this.Height; i++)
            {
                for (int k = i; k < this.Height; k++)
                {
                    Console.Write(" ");
                    if (Console.CursorLeft + 1 >= Console.LargestWindowWidth)
                    {
                        break;
                    }
                }

                for (int j = 1; j <= i; j++)
                {
                    if (Console.CursorLeft + 1 >= Console.LargestWindowWidth)
                    {
                        break;
                    } 

                    if (j == 1 || j == i || i == this.Height)
                    {
                        Console.ForegroundColor = this.OuterForgroundColor;
                        Console.BackgroundColor = this.OuterBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromeColor();
                        }

                        Console.Write(this.OuterChar);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = this.InnerForgroundColor;
                        Console.BackgroundColor = this.InnerBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromeColor();
                        }

                        Console.Write(this.InnerChar);
                        Console.ResetColor();
                    }
                }

                Console.SetCursorPosition(this.X, this.Y + i);
            }
        }

        private void DrawTriangleCornerBottomLeft(bool renderingActive)
        {
            for (int i = 1; i <= this.Height; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (this.X + j >= Console.LargestWindowWidth)
                    {
                        break;
                    }

                    if (j == 1 || j == i || i == this.Height)
                    {
                        Console.ForegroundColor = this.OuterForgroundColor;
                        Console.BackgroundColor = this.OuterBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromeColor();
                        }

                        Console.Write(this.OuterChar);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = this.InnerForgroundColor;
                        Console.BackgroundColor = this.InnerBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromeColor();
                        }

                        Console.Write(this.InnerChar);
                        Console.ResetColor();
                    }
                }

                for (int k = i; k < this.Height; k++)
                {
                    Console.Write(" ");
                }

                Console.SetCursorPosition(this.X, this.Y + i);
            }
        }

        private void SetMonochromeColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void ChangeAttribute(string attributeToChange)
        {
            switch (attributeToChange)
            {
                case "Orientation":
                    this.Orientation = ShapeManagerUtils.PickOrientation();
                    break;
                case "Hight":
                    this.Height = ShapeManagerUtils.GetIntInputFromUser("hight", 0, int.MaxValue);
                    break;
                case "X":
                    this.X = ShapeManagerUtils.GetIntInputFromUser("X", int.MinValue, int.MaxValue);
                    break;
                case "Y":
                    this.Y = ShapeManagerUtils.GetIntInputFromUser("Y", int.MinValue, int.MaxValue);
                    break;
                case "OuterChar":
                    this.OuterChar = ShapeManagerUtils.GetCharInputFromUser("outer char");
                    break;
                case "OuterBackgroundColor":
                    this.OuterBackgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("outer", "background");
                    break;
                case "OuterForgroundColor":
                    this.OuterForgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("outer", "forground");
                    break;
                case "InnerChar":
                    this.InnerChar = ShapeManagerUtils.GetCharInputFromUser("inner char");
                    break;
                case "InnerBackgroundColor":
                    this.InnerBackgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("inner", "background");
                    break;
                case "InnerForgroundColor":
                    this.InnerForgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("inner", "forground");
                    break;
            }
        }
    }
}
