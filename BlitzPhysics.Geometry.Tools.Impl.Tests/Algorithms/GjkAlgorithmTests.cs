﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Geometry.Tools.Impl.Tests.Algorithms
{
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Geometry.Tools.Helpers;
    using BlitzPhysics.Geometry.Tools.Impl.Algorithms;
    using BlitzPhysics.Geometry.Tools.Impl.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains unit tests for <see cref="GjkAlgorithm"/>.
    /// </summary>
    [TestClass]
    public class GjkAlgorithmTests
    {
        /// <summary>
        /// Stores the tolerance for the X and Y deviation from the expected result.
        /// </summary>
        private const double Tolerance = 0.00001f;

        /// <summary>
        /// Stores the test candidate.
        /// </summary>
        private GjkAlgorithm<Polygon, Polygon> _polygonPolygonTestCandidate;

        /// <summary>
        /// Stores the test candidate.
        /// </summary>
        private GjkAlgorithm<Polygon, Circle> _polygonCircleTestCandidate;

        /// <summary>
        /// Sets up each test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            var lineCalculationHelper = new LineCalculationHelper();

            this._polygonPolygonTestCandidate = new GjkAlgorithm<Polygon, Polygon>(
                new PolygonSupportFunctions(lineCalculationHelper),
                new PolygonSupportFunctions(lineCalculationHelper),
                lineCalculationHelper,
                new TriangleCalculationHelper());

            this._polygonCircleTestCandidate = new GjkAlgorithm<Polygon, Circle>(
                new PolygonSupportFunctions(lineCalculationHelper),
                new CircleSupportFunctions(),
                lineCalculationHelper,
                new TriangleCalculationHelper());
        }

        /// <summary>
        /// Does a test.
        /// </summary>
        [TestMethod]
        public void DoFiguresIntersect_PolygonsDoNotIntersectNormal_ReturnsFalse()
        {
            // Arrange
            var polygon1 = new Polygon(
                new Point(1, 1),
                new Point(2, 1.1),
                new Point(3, 1.9),
                new Point(4, 6),
                new Point(3, 5.3),
                new Point(1, 2));

            var polygon2 = new Polygon(
                new Point(-2, 1),
                new Point(-2, 4),
                new Point(0.5, 4),
                new Point(0.5, 1));

            // Act 
            var figureIntersectionResult = this._polygonPolygonTestCandidate.DoFiguresIntersect(polygon1, polygon2);

            // Assert
            Assert.IsFalse(figureIntersectionResult.DoFiguresIntersect);
        }

        /// <summary>
        /// Does a test.
        /// </summary>
        [TestMethod]
        public void DoFiguresIntersect_PolygonsDoIntersectNormal_ReturnsTrue()
        {
            // Arrange
            var polygon1 = new Polygon(
                new Point(1, 1),
                new Point(2, 1.1),
                new Point(3, 1.9),
                new Point(4, 6),
                new Point(3, 5.3),
                new Point(1, 2));

            var polygon2 = new Polygon(
                new Point(-2, 1),
                new Point(-2, 4),
                new Point(1.5, 4),
                new Point(2.5, 1));

            // Act 
            var figureIntersectionResult = this._polygonPolygonTestCandidate.DoFiguresIntersect(polygon1, polygon2);

            // Assert
            Assert.IsTrue(figureIntersectionResult.DoFiguresIntersect);
        }

        /// <summary>
        /// Does a test.
        /// </summary>
        [TestMethod]
        public void DoFiguresIntersect_PolygonsTouchOnOneEdge_ReturnsTrue()
        {
            // Arrange
            var polygon1 = new Polygon(
                new Point(1, 1),
                new Point(2, 1.1),
                new Point(3, 1.9),
                new Point(4, 6),
                new Point(3, 5.3),
                new Point(1, 2));

            var polygon2 = new Polygon(
                new Point(-2, 1),
                new Point(-2, 4),
                new Point(1, 4),
                new Point(1.3, -1));

            // Act 
            var figureIntersectionResult = this._polygonPolygonTestCandidate.DoFiguresIntersect(polygon1, polygon2);

            // Assert
            Assert.IsTrue(figureIntersectionResult.DoFiguresIntersect);
        }
    }
}
