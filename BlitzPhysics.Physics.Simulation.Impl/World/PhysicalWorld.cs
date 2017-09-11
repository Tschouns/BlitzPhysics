﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Impl.World
{
    using BlitzPhysics.Base.RuntimeChecks;
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Physics.Simulation.Forces;
    using BlitzPhysics.Physics.Simulation.Objects;
    using BlitzPhysics.Physics.Simulation.World;

    /// <summary>
    /// See <see cref="IPhysicalWorld"/>.
    /// </summary>
    public class PhysicalWorld : IPhysicalWorld
    {
        /// <summary>
        /// Used to create different elements.
        /// </summary>
        private readonly IElementFactory _elementFactory;

        /// <summary>
        /// Used to create different physical forces.
        /// </summary>
        private readonly IForceFactory _forceFactory;

        /// <summary>
        /// Stores the "physical space" which contains all the "physical objects" of this world.
        /// </summary>
        private readonly IPhysicalSpace _physicalSpace;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalWorld"/> class.
        /// </summary>
        public PhysicalWorld(
            IElementFactory elementFactory,
            IForceFactory forceFactory)
        {
            ArgumentChecks.AssertNotNull(elementFactory, nameof(elementFactory));
            ArgumentChecks.AssertNotNull(forceFactory, nameof(forceFactory));

            this._elementFactory = elementFactory;
            this._forceFactory = forceFactory;

            this._physicalSpace = this._elementFactory.CreateSpace();

            ////// Configure world, add gravity (this might get a little more flexible in the future).
            ////var gravity = this._forceFactory.CreateGravity(PhysicsConstants.EarthGravityAcceleration);
            ////this._physicalSpace.AddForceForParticles(gravity.ForParticles);
            ////this._physicalSpace.AddForceForBodies(gravity.ForBodies);
        }

        /// <summary>
        /// See <see cref="IPhysicalWorld.AddForce(ForceSet)"/>.
        /// </summary>
        public void AddForce(ForceSet force)
        {
            ArgumentChecks.AssertNotNull(force, nameof(force));

            this._physicalSpace.AddForceForParticles(force.ForParticles);
            this._physicalSpace.AddForceForBodies(force.ForBodies);
        }

        /// <summary>
        /// See <see cref="IPhysicalWorld.SpawnParticle"/>.
        /// </summary>
        public IParticle SpawnParticle(double mass, Point position)
        {
            ArgumentChecks.AssertIsStrictPositive(mass, nameof(mass));

            var particle = this._elementFactory.CreateParticle(mass, position);
            this._physicalSpace.AddParticle(particle);

            return particle;
        }

        /// <summary>
        /// See <see cref="IPhysicalWorld.SpawnRigidBody"/>.
        /// </summary>
        public IBody<Polygon> SpawnRigidBody(double mass, Polygon polygon, Point position)
        {
            ArgumentChecks.AssertIsStrictPositive(mass, nameof(mass));
            ArgumentChecks.AssertNotNull(polygon, nameof(polygon));

            var rigidBody = this._elementFactory.CreateRigidBody(mass, polygon, position);
            this._physicalSpace.AddBody(rigidBody);

            return rigidBody;
        }

        /// <summary>
        /// See <see cref="IPhysicalWorld.Step"/>.
        /// </summary>
        public void Step(double time)
        {
            ArgumentChecks.AssertIsPositive(time, nameof(time));

            this._physicalSpace.Step(time);
        }
    }
}
