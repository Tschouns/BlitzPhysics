﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Objects
{
    /// <summary>
    /// Represents a particle in the "physical world".
    /// </summary>
    public interface IParticle : IPhysicalObject
    {
        /// <summary>
        /// Gets the current state of the particle.
        /// </summary>
        ParticleState CurrentState { get; }
    }
}
