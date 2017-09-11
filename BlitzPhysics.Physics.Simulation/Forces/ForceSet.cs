﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Forces
{
    using BlitzPhysics.Base.RuntimeChecks;
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Physics.Simulation.Objects;

    /// <summary>
    /// Contains a set of forces, one for each known type of "physical object".
    /// </summary>
    public class ForceSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForceSet"/> class.
        /// </summary>
        public ForceSet(
            IForce<IParticle> forParticles,
            IForce<IBody<Polygon>> forBodies)
        {
            ArgumentChecks.AssertNotNull(forParticles, nameof(forParticles));
            ArgumentChecks.AssertNotNull(forBodies, nameof(forBodies));

            this.ForParticles = forParticles;
            this.ForBodies = forBodies;
        }

        /// <summary>
        /// Gets the force to apply to particles.
        /// </summary>
        public IForce<IParticle> ForParticles { get; }

        /// <summary>
        /// Gets the force to apply to polygon bodies.
        /// </summary>
        public IForce<IBody<Polygon>> ForBodies { get; }
    }
}
