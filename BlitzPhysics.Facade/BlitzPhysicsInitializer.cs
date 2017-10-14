//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Facade
{
    using Base.InversionOfControl;
    using BlitzPhysics.Base.StartUp;
    using Geometry.Tools.Impl;
    using Physics.Simulation.Impl;
    using Physics.Tools.Impl;
    using System.Collections.Generic;

    /// <summary>
    /// Provides a method to initialize all the components accessible through this facade.
    /// </summary>
    public static class BlitzPhysicsInitializer
    {
        /// <summary>
        /// Initializes all the components accessible through this facade.
        /// </summary>
        public static void Initialize()
        {
            var projectInitializers = new List<IProjectInitializer>();

            projectInitializers.Add(new GeometryToolsProjectIntializer());
            projectInitializers.Add(new PhysicsToolsProjectInitializer());
            projectInitializers.Add(new PhysicsSimulationProjectInitializer());

            foreach (var initializer in projectInitializers)
            {
                initializer.PerformIocContainerRegistrations(Ioc.Container);
            }
        }
    }
}
