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
    /// Creates shapes.
    /// </summary>
    public interface IShapeFactory
    {
        /// <summary>
        /// Creates a <see cref="IRigidShape{Polygon}"/> based on the specified <see cref="Polygon"/>.
        /// The centroid of the resulting <see cref="IShape{TFigure}"/> will be aligned with
        /// the origin.
        /// </summary>
        IRigidShape<Polygon> CreateOriginalPolygonShape(Polygon polygon);
    }
}
