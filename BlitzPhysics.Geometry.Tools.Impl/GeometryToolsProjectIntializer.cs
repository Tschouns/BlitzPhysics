//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Geometry.Tools.Impl
{
    using System;
    using Base.InversionOfControl;
    using BlitzPhysics.Base.StartUp;
    using Base.RuntimeChecks;
    using Tools.Algorithms;
    using Tools.Helpers;
    using Helpers;
    using Algorithms;
    using Elements;

    /// <summary>
    /// See <see cref="IProjectInitializer"/>.
    /// </summary>
    public class GeometryToolsProjectIntializer : IProjectInitializer
    {
        /// <summary>
        /// See <see cref="IProjectInitializer.PerformIocContainerRegistrations(IIocContainer)"/>.
        /// </summary>
        public void PerformIocContainerRegistrations(IIocContainer iocContainer)
        {
            ArgumentChecks.AssertNotNull(iocContainer, nameof(iocContainer));

            // Algorithms
            Ioc.Container.RegisterSingleton<ISupportFunctions<Circle>, CircleSupportFunctions>();
            Ioc.Container.RegisterSingleton<ISupportFunctions<Polygon>, PolygonSupportFunctions>();
            Ioc.Container.RegisterSingleton(typeof(IGjkAlgorithm<Polygon, Polygon>), typeof(GjkAlgorithm<Polygon, Polygon>));
            Ioc.Container.RegisterSingleton(typeof(IGjkAlgorithm<Circle, Polygon>), typeof(GjkAlgorithm<Circle, Polygon>));
            //// TODO: check why the hell type unbound registrations don't work.
            ////Ioc.Container.RegisterSingleton(typeof(IGjkAlgorithm<,>), typeof(GjkAlgorithm<,>));

            // Helpers
            Ioc.Container.RegisterSingleton<ILineCalculationHelper, LineCalculationHelper>();
            Ioc.Container.RegisterSingleton<ILineIntersectionHelper, LineIntersectionHelper>();
            Ioc.Container.RegisterSingleton<IPointTransformationHelper, PointTransformationHelper>();
            Ioc.Container.RegisterSingleton<IPolygonCalculationHelper, PolygonCalculationHelper>();
            Ioc.Container.RegisterSingleton<IPolygonTransformationHelper, PolygonTransformationHelper>();
            Ioc.Container.RegisterSingleton<ITriangleCalculationHelper, TriangleCalculationHelper>();
        }
    }
}
