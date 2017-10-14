//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Facade
{
    using Base.InversionOfControl;
    using Physics.Simulation.Forces;
    using Physics.Simulation.Objects;
    using Physics.Simulation.World;
    using System;

    /// <summary>
    /// Provides access to physics simulation tools.
    /// </summary>
    public static class Simulation
    {
        private static readonly Lazy<IElementFactory> mLazyElementFactory = new Lazy<IElementFactory>(() => Ioc.Container.Resolve<IElementFactory>());
        private static readonly Lazy<IForceFactory> mLazyForceFactory = new Lazy<IForceFactory>(() => Ioc.Container.Resolve<IForceFactory>());
        private static readonly Lazy<IWorldFactory> mLazyWorldFactory = new Lazy<IWorldFactory>(() => Ioc.Container.Resolve<IWorldFactory>());

        /// <summary>
        /// Gets the <see cref="IElementFactory"/>.
        /// </summary>
        public static IElementFactory Element => mLazyElementFactory.Value;

        /// <summary>
        /// Gets the <see cref="IForceFactory"/>.
        /// </summary>
        public static IForceFactory Force => mLazyForceFactory.Value;

        /// <summary>
        /// Gets the <see cref="IWorldFactory"/>.
        /// </summary>
        public static IWorldFactory World => mLazyWorldFactory.Value;
    }
}
