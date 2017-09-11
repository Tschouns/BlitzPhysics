//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Objects
{
    using BlitzPhysics.Geometry.Elements;

    /// <summary>
    /// Represents the variable state of a particle at a specific point in time.
    /// </summary>
    public struct ParticleState
    {
        /// <summary>
        /// Gets or sets the current position.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Gets or sets the current velocity.
        /// </summary>
        public Vector2 Velocity { get; set; }
    }
}
