//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Geometry.Tools.Impl.Algorithms
{
    using BlitzPhysics.Base.RuntimeChecks;
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Geometry.Tools.Algorithms;
    using BlitzPhysics.Geometry.Elements.Extensions;

    /// <summary>
    /// Implements <see cref="ISupportFunctions{TFigure}"/> for <see cref="Circle"/>.
    /// </summary>
    public class CircleSupportFunctions : ISupportFunctions<Circle>
    {
        /// <summary>
        /// See <see cref="ISupportFunctions{TFigure}.GetSupportPoint"/>.
        /// </summary>
        public Point GetSupportPoint(Circle figure, Vector2 direction)
        {
            ArgumentChecks.AssertNotNull(figure, nameof(figure));

            var normalizedDirection = direction.Norm();
            var supportPointOffsetFromCenter = normalizedDirection.Multiply(figure.Radius);

            var supportPoint = figure.Center.AddVector(supportPointOffsetFromCenter);

            return supportPoint;
        }

        /// <summary>
        /// See <see cref="ISupportFunctions{TFigure}.GetFigureOutlinePointClosestToPosition(TFigure, Point)"/>.
        /// </summary>
        public Point GetFigureOutlinePointClosestToPosition(Circle figure, Point position)
        {
            ArgumentChecks.AssertNotNull(figure, nameof(figure));

            var directionFromCircleCenterToPosition = position.GetOffsetFrom(figure.Center);

            return this.GetSupportPoint(figure, directionFromCircleCenterToPosition);
        }
    }
}
