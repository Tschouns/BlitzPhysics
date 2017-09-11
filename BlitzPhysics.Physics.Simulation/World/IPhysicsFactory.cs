//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.World
{
    using BlitzPhysics.Physics.Simulation.Forces;

    /// <summary>
    /// Creates the "physical world" and other "physical" objects.
    /// </summary>
    public interface IPhysicsFactory
    {
        /// <summary>
        /// Gets the <see cref="IForceFactory"/>.
        /// </summary>
        IForceFactory Forces { get; }

        /// <summary>
        /// Creates a "physical world".
        /// </summary>
        IPhysicalWorld CreatePhysicalWorld();
    }
}
