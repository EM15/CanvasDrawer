﻿using CanvasDrawer.Creators;
using CanvasDrawer.Validators;
using System.Drawing;

namespace CanvasDrawer
{
    internal class ProgramExecutor
    {
        private readonly ICommandValidator commandValidator;
        private readonly IFigureCreator figureCreator;
        private readonly IDrawingValidator drawingValidator;
        private readonly IDrawer drawer;
        private Rectangle? canvas;
        private IList<Rectangle> drawings = new List<Rectangle>();

        public ProgramExecutor(ICommandValidator commandValidator, IFigureCreator figureCreator, IDrawingValidator drawingValidator, IDrawer drawer)
        {
            this.commandValidator = commandValidator;
            this.figureCreator = figureCreator;
            this.drawingValidator = drawingValidator;
            this.drawer = drawer;
        }

        public void ReadCanvas()
        {
            Console.WriteLine("Create a new Canvas");
            while (canvas is null)
            {
                var command = Console.ReadLine();
                var isValid = commandValidator.IsCanvasCommandValid(command);
                if (!isValid)
                {
                    ShowInvalidCommandMessage();
                    continue;
                }

                canvas = figureCreator.CreateCanvas(command!);
                drawer.DrawCanvas(canvas.Value);
            }
        }

        public void ReadCommands()
        {
            var command = GetDrawnOnCanvasCommand();
            while (command != "Q")
            {
                var isValid = commandValidator.IsDrawingCommandValid(command);
                if (!isValid)
                {
                    ShowInvalidCommandMessage();
                    command = GetDrawnOnCanvasCommand();
                    continue;
                }

                var figure = figureCreator.CreateFigure(command!);

                var canFigureBeDrawn = drawingValidator.CanFigureBeDrawnInsideCanvas(canvas.Value, figure);
                if (!canFigureBeDrawn)
                {
                    Console.WriteLine("Figure is outside canvas");
                    command = GetDrawnOnCanvasCommand();
                    continue;
                }
                
                drawings.Add(figure);
                drawer.Draw(canvas.Value, drawings);

                command = GetDrawnOnCanvasCommand();
            }
        }

        private string? GetDrawnOnCanvasCommand()
        {
            Console.WriteLine("Draw on the canvas");
            return Console.ReadLine();
        }

        private void ShowDrawOnCanvasMessage() => Console.WriteLine("Draw on the canvas");

        private void ShowInvalidCommandMessage() => Console.WriteLine("Invalid command");
    }
}
