﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Impl.Objects.Shape
{
    using BlitzPhysics.Base.RuntimeChecks;
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Geometry.Elements.Extensions;
    using BlitzPhysics.Geometry.Tools;
    using BlitzPhysics.Geometry.Tools.Helpers;
    using BlitzPhysics.Physics.Simulation.Objects;
    using BlitzPhysics.Physics.Tools.Helpers;

    /// <summary>
    /// Implementation of <see cref="IRigidShape{Polygon}"/>
    /// </summary>
    public class RigidPolygonShape : IRigidShape<Polygon>
    {
        /// <summary>
        /// Used to transform the shape, based on position and orientation.
        /// </summary>
        private readonly IPolygonTransformationHelper _polygonTransformationHelper;
        
        /// <summary>
        /// Used to calculate the moment of inertia.
        /// </summary>
        private readonly IBodyCalculationHelper _bodyCalculationHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RigidPolygonShape"/> class.
        /// </summary>
        public RigidPolygonShape(
            IPolygonTransformationHelper polygonTransformationHelper,
            IBodyCalculationHelper bodyCalculationHelper,
            double volume,
            Polygon originalPolygon)
        {
            ArgumentChecks.AssertNotNull(polygonTransformationHelper, nameof(polygonTransformationHelper));
            ArgumentChecks.AssertNotNull(bodyCalculationHelper, nameof(bodyCalculationHelper));
            ArgumentChecks.AssertIsStrictPositive(volume, nameof(volume));
            ArgumentChecks.AssertNotNull(originalPolygon, nameof(originalPolygon));

            this._polygonTransformationHelper = polygonTransformationHelper;
            this._bodyCalculationHelper = bodyCalculationHelper;
            this.Volume = volume;
            this.Original = originalPolygon;
            this.Current = this.Original;
        }

        /// <summary>
        /// Gets... <see cref="IShape{TFigure}.Volume"/>.
        /// </summary>
        public double Volume { get; }

        /// <summary>
        /// Gets... <see cref="IShape{TGeometricFigure}.Original"/>.
        /// </summary>
        public Polygon Original { get; }

        /// <summary>
        /// Gets... <see cref="IShape{TGeometricFigure}.Current"/>.
        /// </summary>
        public Polygon Current { get; private set; }

        /// <summary>
        /// See <see cref="IRigidShape{TGeometricFigure}.CalculateInertia"/>.
        /// </summary>
        public double CalculateInertia(double mass)
        {
            ArgumentChecks.AssertIsStrictPositive(mass, nameof(mass));

            var inertia = this._bodyCalculationHelper.CalculateMomentOfInertiaAboutOrigin(
                this.Original,
                mass);

            return inertia;
        }

        /// <summary>
        /// See <see cref="IRigidShape{TGeometricFigure}.Update"/>.
        /// </summary>
        public void Update(Point position, double orientation)
        {
            // Rotate around the center of mass (which for the "original" is the origin).
            var rotatedPolygon = this._polygonTransformationHelper.RotatePolygon(
                GeometryConstants.Origin,
                orientation,
                this.Original);

            // Translate by the offset of the target position, relative to the center of mass which is its "original position".
            var targetPositionOffset = position.GetOffsetFrom(GeometryConstants.Origin);
            var translatedAndRotatedPolygon = this._polygonTransformationHelper.TranslatePolygon(
                targetPositionOffset,
                rotatedPolygon);

            this.Current = translatedAndRotatedPolygon;
        }
    }
}
