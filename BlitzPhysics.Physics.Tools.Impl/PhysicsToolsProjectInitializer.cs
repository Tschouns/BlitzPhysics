//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Tools.Impl
{
    using Base.InversionOfControl;
    using Base.RuntimeChecks;
    using BlitzPhysics.Base.StartUp;
    using Helpers;
    using System;
    using Tools.Helpers;

    /// <summary>
    /// See <see cref="IProjectInitializer"/>.
    /// </summary>
    public class PhysicsToolsProjectInitializer : IProjectInitializer
    {
        /// <summary>
        /// See <see cref="IProjectInitializer.PerformIocContainerRegistrations(IIocContainer)"/>.
        /// </summary>
        public void PerformIocContainerRegistrations(IIocContainer iocContainer)
        {
            ArgumentChecks.AssertNotNull(iocContainer, nameof(iocContainer));

            Ioc.Container.RegisterSingleton<IBodyCalculationHelper, BodyCalculationHelper>();
            Ioc.Container.RegisterSingleton<IIsaacNewtonHelper, IsaacNewtonHelper>();
        }
    }
}
