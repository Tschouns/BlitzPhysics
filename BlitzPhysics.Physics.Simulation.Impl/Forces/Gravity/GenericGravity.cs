﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Impl.Forces.Gravity
{
    using BlitzPhysics.Base.RuntimeChecks;
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Physics.Simulation.Forces;
    using BlitzPhysics.Physics.Simulation.Objects;

    /// <summary>
    /// Simulates gravity, for any <see cref="TPhysicalObject"/>.
    /// </summary>
    /// <typeparam name="TPhysicalObject">
    /// Type of "physical object" this force can be applied to
    /// </typeparam>
    public class GenericGravity<TPhysicalObject> : IForce<TPhysicalObject>
        where TPhysicalObject : class, IPhysicalObject
    {
        /// <summary>
        /// Stores the actual force vector.
        /// </summary>
        private readonly double _gravityAcceleration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Gravity"/> class.
        /// </summary>
        public GenericGravity(double acceleration)
        {
            ArgumentChecks.AssertIsPositive(acceleration, nameof(acceleration));

            this._gravityAcceleration = acceleration;
        }

        /// <summary>
        /// See <see cref="IForce{TPhysicalObject}.IsDepleted"/>. Gravity is never depleted.
        /// </summary>
        public bool IsDepleted => false;

        /// <summary>
        /// See <see cref="IGlobalForce.Step"/>.
        /// </summary>
        public void Step(double time)
        {
            // Gravity doesn't change over time.
        }

        /// <summary>
        /// See <see cref="IGlobalForce.ApplyToObject(TPhysicalObject)"/>.
        /// </summary>
        public void ApplyToObject(TPhysicalObject physicalObject)
        {
            ArgumentChecks.AssertNotNull(physicalObject, nameof(physicalObject));

            var force = new Vector2(0, -(this._gravityAcceleration * physicalObject.Mass));

            physicalObject.ApplyForce(force);
        }
    }
}
