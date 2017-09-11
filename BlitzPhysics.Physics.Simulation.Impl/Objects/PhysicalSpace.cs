﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Impl.Objects
{
    using System.Collections.Generic;
    using System.Linq;
    using BlitzPhysics.Base.RuntimeChecks;
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Physics.Simulation.Forces;
    using BlitzPhysics.Physics.Simulation.Objects;

    /// <summary>
    /// See <see cref="IPhysicalSpace"/>.
    /// </summary>
    public class PhysicalSpace : IPhysicalSpace
    {
        /// <summary>
        /// Holds the forces which are applied to particles in the space.
        /// </summary>
        private readonly IList<IForce<IParticle>> _particleForces;

        /// <summary>
        /// Holds the forces which are applied to bodies in the space.
        /// </summary>
        private readonly IList<IForce<IBody<Polygon>>> _bodyForces;

        /// <summary>
        /// Holds all particles in the space.
        /// </summary>
        private readonly IList<IParticle> _particles;

        /// <summary>
        /// Holds all bodies in the space.
        /// </summary>
        private readonly IList<IBody<Polygon>> _bodies;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalSpace"/> class.
        /// </summary>
        public PhysicalSpace()
        {
            this._particleForces = new List<IForce<IParticle>>();
            this._bodyForces = new List<IForce<IBody<Polygon>>>();
            this._particles = new List<IParticle>();
            this._bodies = new List<IBody<Polygon>>();
        }

        /// <summary>
        /// See <see cref="IPhysicalSpace.AddForceForParticles(IForce{IParticle})"/>.
        /// </summary>
        public void AddForceForParticles(IForce<IParticle> force)
        {
            ArgumentChecks.AssertNotNull(force, nameof(force));

            this._particleForces.Add(force);
        }

        /// <summary>
        /// See <see cref="IPhysicalSpace.AddForceForBodies(IForce{IBody{Polygon}})"/>.
        /// </summary>
        public void AddForceForBodies(IForce<IBody<Polygon>> force)
        {
            ArgumentChecks.AssertNotNull(force, nameof(force));

            this._bodyForces.Add(force);
        }

        /// <summary>
        /// See <see cref="IPhysicalSpace.AddParticle"/>.
        /// </summary>
        public void AddParticle(IParticle particle)
        {
            ArgumentChecks.AssertNotNull(particle, nameof(particle));

            this._particles.Add(particle);
        }

        /// <summary>
        /// See <see cref="IPhysicalSpace.AddBody"/>.
        /// </summary>
        public void AddBody(IBody<Polygon> body)
        {
            ArgumentChecks.AssertNotNull(body, nameof(body));

            this._bodies.Add(body);
        }

        /// <summary>
        /// See <see cref="IPhysicalSpace.Step"/>.
        /// </summary>
        public void Step(double time)
        {
            ArgumentChecks.AssertIsPositive(time, nameof(time));

            // Remove depleted forces.
            RemoveDepletedForces(this._particleForces);
            RemoveDepletedForces(this._bodyForces);

            // Update remaining forces.
            foreach(var force in this._particleForces)
            {
                force.Step(time);
            }

            foreach (var force in this._bodyForces)
            {
                force.Step(time);
            }

            // Update particles.
            foreach (var particle in this._particles)
            {
                foreach (var force in this._particleForces)
                {
                    force.ApplyToObject(particle);
                }

                particle.Step(time);
                particle.ResetAppliedPhysicalQuantities();
            }

            // Update bodies.
            foreach (var body in this._bodies)
            {
                foreach (var force in this._bodyForces)
                {
                    force.ApplyToObject(body);
                }

                body.Step(time);
                body.ResetAppliedPhysicalQuantities();
            }
        }

        /// <summary>
        /// Removes the depleted forces from the specified list.
        /// </summary>
        /// <typeparam name="TPhysicalObject">
        /// The type of "physical object" the force applies to
        /// </typeparam>
        private static void RemoveDepletedForces<TPhysicalObject>(IList<IForce<TPhysicalObject>> forces)
            where TPhysicalObject : class, IPhysicalObject
        {
            ArgumentChecks.AssertNotNull(forces, nameof(forces));

            var depletedForces = forces.Where(x => x.IsDepleted).ToList();
            foreach (var force in depletedForces)
            {
                forces.Remove(force);
            }
        }
    }
}
