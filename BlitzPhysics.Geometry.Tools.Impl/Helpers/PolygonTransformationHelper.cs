﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Geometry.Tools.Impl.Helpers
{
    using System.Linq;
    using BlitzPhysics.Base.RuntimeChecks;
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Geometry.Elements.Extensions;
    using BlitzPhysics.Geometry.Tools.Helpers;

    /// <summary>
    /// See <see cref="IPolygonTransformationHelper"/>.
    /// </summary>
    public class PolygonTransformationHelper : IPolygonTransformationHelper
    {
        /// <summary>
        /// Used to transform the polygon corners.
        /// </summary>
        private readonly IPointTransformationHelper _pointTransformationHelper;

        /// <summary>
        /// Used to calculate the centroid of a polygon.
        /// </summary>
        private readonly IPolygonCalculationHelper _polygonCalculationHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonTransformationHelper"/> class.
        /// </summary>
        public PolygonTransformationHelper(
            IPointTransformationHelper pointTransformationHelper,
            IPolygonCalculationHelper polygonCalculationHelper)
        {
            ArgumentChecks.AssertNotNull(pointTransformationHelper, nameof(pointTransformationHelper));
            ArgumentChecks.AssertNotNull(polygonCalculationHelper, nameof(polygonCalculationHelper));

            this._pointTransformationHelper = pointTransformationHelper;
            this._polygonCalculationHelper = polygonCalculationHelper;
        }

        /// <summary>
        /// See <see cref="IPolygonTransformationHelper.TranslatePolygon"/>.
        /// </summary>
        public Polygon TranslatePolygon(Vector2 offset, Polygon polygon)
        {
            ArgumentChecks.AssertNotNull(polygon, nameof(polygon));

            var newPolygonCorners = this._pointTransformationHelper.TranslatePoints(
                offset,
                polygon.Corners.ToArray());

            return new Polygon(newPolygonCorners);
        }

        /// <summary>
        /// See <see cref="IPolygonTransformationHelper.RotatePolygon"/>.
        /// </summary>
        public Polygon RotatePolygon(Point origin, double angle, Polygon polygon)
        {
            ArgumentChecks.AssertNotNull(polygon, nameof(polygon));

            var newPolygonCorners = this._pointTransformationHelper.RotatePoints(
                origin,
                angle,
                polygon.Corners.ToArray());

            return new Polygon(newPolygonCorners);
        }

        /// <summary>
        /// See <see cref="IPolygonTransformationHelper.CenterOnOrigin"/>.
        /// </summary>
        public Polygon CenterOnOrigin(Polygon polygon)
        {
            ArgumentChecks.AssertNotNull(polygon, nameof(polygon));

            var centroid = this._polygonCalculationHelper.DetermineCentroid(polygon);

            // Get the origin's offset, relative to the centroid.
            var originOffset = GeometryConstants.Origin.GetOffsetFrom(centroid);
            var centeredPolygon = this.TranslatePolygon(originOffset, polygon);

            return centeredPolygon;
        }
    }
}
