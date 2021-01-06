using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Extensions.SystemExt.CollectionsExt;
using Extensions.SystemExt.DrawingExt;
using Extensions.SystemExt.MathExt;
using System.Runtime.Serialization;

namespace Fractal.Fractals.LSytemFractals
{
    public sealed class Fractal2DByLSystem : IFractal
    {
        private const double StandartPixeMove = 1000;
        private readonly string _startSystemСondition;
        private readonly double _rotateAngle;
        private readonly IReadOnlyList<GenerativeRules> _generativeRules;
        private _2SLSystemState _state;

        public Fractal2DByLSystem(
            [NotNull] string startSystemСondition,
            double rotateAngle,
            [NotNull, ItemNotNull] IReadOnlyList<GenerativeRules> generativeRules)
        {
            _startSystemСondition = startSystemСondition ?? throw new Exception($"NotNull parameter {startSystemСondition} exception");
            _generativeRules = generativeRules ?? throw new Exception($"NotNull parameter {generativeRules} exception");
            _rotateAngle = GeometricExtensions.ToRadians(rotateAngle);
            _state = null;
        }

        public IReadOnlyList<PointF> Points(int stepCount)
        {
            IReadOnlyList<PointF> points;
            if (_state == null || stepCount != _state.StepCount)
            {
                points = GetNewPoints(stepCount);
                _state = new _2SLSystemState(stepCount, points);
            }

            points = _state.Points;
            if (_state.Equals(stepCount))
            {
                return points;
            }

            _state = new _2SLSystemState(stepCount, points);
            return points;
        }

        [NotNull, ItemNotNull]
        private IReadOnlyList<PointF> GetNewPoints(
            int stepCount)
        {
            var condition = GetNewCondition(stepCount);
            return GeometricExtensions.MovePointsToZero(
                GetPoints(condition));
        }

        [NotNull]
        private string GetNewCondition(int stepCount)
        {
            var newSystemString = new string(_startSystemСondition);
            for (var step = 0; step < stepCount; step++)
            {
                _generativeRules.ForEach(rule => newSystemString = newSystemString.Replace(rule.From, rule.To));
            }
            return newSystemString;
        }

        private IReadOnlyList<PointF> GetPoints(
            string systemString)
        {
            var startPoint = new PointF(0, 0);

            List<PointF> coordinates = new List<PointF>() { startPoint };

            PointF currentPoint = startPoint;
            double angle = 0;
            foreach (var item in systemString)
            {
                switch (item)
                {
                    case '+':
                        angle -= _rotateAngle;
                        break;
                    case '-':
                        angle += _rotateAngle;
                        break;
                    default:
                        currentPoint = GetNextPoint(currentPoint, angle);
                        coordinates.Add(currentPoint);
                        break;
                }
            }

            return coordinates;
        }

        private PointF GetNextPoint(
            PointF previousPoint,
            double angle)
        {
            var moveVector = new PointF(
                x: (float)(StandartPixeMove * Math.Cos(angle)),
                y: (float)(StandartPixeMove * Math.Sin(angle)));

            return previousPoint.Add(moveVector);
        }
    }
}
