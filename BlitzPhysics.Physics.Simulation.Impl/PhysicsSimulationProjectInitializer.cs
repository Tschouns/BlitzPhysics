//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Impl
{
    using Base.InversionOfControl;
    using Base.StartUp;
    using System;

    /// <summary>
    /// See <see cref="IProjectInitializer"/>.
    /// </summary>
    public class PhysicsSimulationProjectInitializer : IProjectInitializer
    {
        /// <summary>
        /// See <see cref="IProjectInitializer.PerformIocContainerRegistrations(IIocContainer)"/>.
        /// </summary>
        public void PerformIocContainerRegistrations(IIocContainer iocContainer)
        {
            throw new NotImplementedException();
        }
    }
}
