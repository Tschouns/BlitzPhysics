//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Impl.Objects.Shape
{
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Physics.Simulation.Objects;

    /// <summary>
    /// Provides a method to update the "current" state of the shape, based
    /// on position and orientation of the body.
    /// </summary>
    /// <typeparam name="TShapeFigure">
    /// See <see cref="IShape{TFigure}"/>.
    /// </typeparam>
    public interface IRigidShape<TShapeFigure> : IShape<TShapeFigure>
        where TShapeFigure : class, IFigure
    {
        /// <summary>
        /// Calculates the inertia for this shape, given a specified mass.
        /// </summary>
        double CalculateInertia(double mass);

        /// <summary>
        /// Updates the "current" state of the shape, based on position and
        /// orientation of the body.
        /// </summary>
        void Update(Point position, double orientation);
    }
}
