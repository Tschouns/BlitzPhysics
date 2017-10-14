//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.World
{
    /// <summary>
    /// Creates the "physical world" and other "physical" objects.
    /// </summary>
    public interface IWorldFactory
    {
        /// <summary>
        /// Creates a "physical world".
        /// </summary>
        IPhysicalWorld CreatePhysicalWorld();
    }
}
