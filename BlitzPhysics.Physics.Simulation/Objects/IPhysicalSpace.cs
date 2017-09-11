﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Objects
{
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Physics.Simulation.Forces;

    /// <summary>
    /// Represents a "physical space", although 2D you know... not really a "space". But we'll call it that ;)
    /// </summary>
    public interface IPhysicalSpace
    {
        /// <summary>
        /// Adds a force, which is applied to particles within the "physical space".
        /// </summary>
        void AddForceForParticles(IForce<IParticle> force);
        
        /// <summary>
        /// Adds a force, which is applied to bodies within the "physical space".
        /// </summary>
        void AddForceForBodies(IForce<IBody<Polygon>> force);

        /// <summary>
        /// Adds a particle to the "physical space".
        /// </summary>
        void AddParticle(IParticle particle);

        /// <summary>
        /// Adds a body to the "physical space".
        /// </summary>
        void AddBody(IBody<Polygon> body);

        /// <summary>
        /// Steps forward in time, by the specified number (fraction) of seconds.
        /// </summary>
        void Step(double time);
    }
}
