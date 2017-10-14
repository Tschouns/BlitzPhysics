//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Impl
{
    using Base.InversionOfControl;
    using Base.RuntimeChecks;
    using Base.StartUp;
    using Forces;
    using Objects;
    using Objects.Shape;
    using Simulation.Forces;
    using Simulation.Objects;
    using Simulation.World;
    using World;

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
            ArgumentChecks.AssertNotNull(iocContainer, nameof(iocContainer));

            Ioc.Container.RegisterSingleton<IElementFactory, ElementFactory>();
            Ioc.Container.RegisterSingleton<IForceFactory, ForceFactory>();
            Ioc.Container.RegisterSingleton<IPhysicsFactory, PhysicsFactory>();
            Ioc.Container.RegisterSingleton<IShapeFactory, ShapeFactory>();
        }
    }
}
