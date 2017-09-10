﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Geometry.Tools.Impl.Algorithms
{
    using System.Linq;
    using Base.RuntimeChecks;
    using Elements;
    using BlitzPhysics.Geometry.Elements.Extensions;
    using BlitzPhysics.Geometry.Tools.Algorithms;
    using BlitzPhysics.Geometry.Tools.Helpers;

    /// <summary>
    /// Implements <see cref="ISupportFunctions{TFigure}"/> for <see cref="Polygon"/>.
    /// </summary>
    public class PolygonSupportFunctions : ISupportFunctions<Polygon>
    {
        /// <summary>
        /// Used to get the point on a line closest to a specific position.
        /// </summary>
        private readonly ILineCalculationHelper _lineCalculationHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonSupportFunctions"/> class.
        /// </summary>
        public PolygonSupportFunctions(ILineCalculationHelper lineCalculationHelper)
        {
            ArgumentChecks.AssertNotNull(lineCalculationHelper, nameof(lineCalculationHelper));

            this._lineCalculationHelper = lineCalculationHelper;
        }

        /// <summary>
        /// See <see cref="ISupportFunctions{TFigure}.GetSupportPoint"/>.
        /// </summary>
        public Point GetSupportPoint(Polygon figure, Vector2 direction)
        {
            ArgumentChecks.AssertNotNull(figure, nameof(figure));

            var point = new Point(0, 0);
            var maxDot = double.MinValue;

            foreach (var corner in figure.Corners)
            {
                var dot = corner.AsVector().Dot(direction);
                if (dot > maxDot)
                {
                    maxDot = dot;
                    point = corner;
                }
            }

            return point;
        }

        /// <summary>
        /// See <see cref="ISupportFunctions{TFigure}.GetFigureOutlinePointClosestToPosition(TFigure, Point)"/>.
        /// </summary>
        public Point GetFigureOutlinePointClosestToPosition(Polygon figure, Point position)
        {
            ArgumentChecks.AssertNotNull(figure, nameof(figure));

            var cornersOrderedByDistance = figure.Corners
                .OrderBy(x => x.GetOffsetFrom(position).SquaredMagnitude())
                .ToList();

            var closestCorner = cornersOrderedByDistance[0];
            var secondClosestCorner = cornersOrderedByDistance[1];

            // If the offset of the closes corner and the line segment between the two closest corners are within 90 degrees,...
            if (position.GetOffsetFrom(closestCorner).IsDirectionWithin90Degrees(secondClosestCorner.GetOffsetFrom(closestCorner)))
            {
                // ... then the closest point is somewhere on the line segment.
                var closestPointOnLineSegment = this._lineCalculationHelper.GetIntersectionWithPerpendicularThroughPoint(
                    new Line(closestCorner, secondClosestCorner),
                    position);

                return closestPointOnLineSegment;
            }

            // Otherwise, the closest corner is the closest point.
            return closestCorner;
        }
    }
}
