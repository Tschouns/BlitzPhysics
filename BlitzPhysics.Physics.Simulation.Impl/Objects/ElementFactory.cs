﻿//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Impl.Objects
{
    using BlitzPhysics.Base.RuntimeChecks;
    using BlitzPhysics.Geometry.Elements;
    using BlitzPhysics.Physics.Simulation.Impl.Objects.Shape;
    using BlitzPhysics.Physics.Simulation.Objects;
    using BlitzPhysics.Physics.Tools.Helpers;

    /// <summary>
    /// See <see cref="IElementFactory"/>.
    /// </summary>
    public class ElementFactory : IElementFactory
    {
        /// <summary>
        /// Stores the <see cref="IShapeFactory"/>.
        /// </summary>
        private readonly IShapeFactory _shapeFactory;

        /// <summary>
        /// Stores the <see cref="IBodyCalculationHelper"/>.
        /// </summary>
        private readonly IBodyCalculationHelper _bodyCalculationHelper;

        /// <summary>
        /// Stores the <see cref="IIsaacNewtonHelper"/>.
        /// </summary>
        private readonly IIsaacNewtonHelper _isaacNewtonHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementFactory"/> class.
        /// </summary>
        public ElementFactory(
            IShapeFactory shapeFactory,
            IBodyCalculationHelper bodyCalculationHelper,
            IIsaacNewtonHelper isaacNewtonHelper)
        {
            ArgumentChecks.AssertNotNull(shapeFactory, nameof(shapeFactory));
            ArgumentChecks.AssertNotNull(bodyCalculationHelper, nameof(bodyCalculationHelper));
            ArgumentChecks.AssertNotNull(isaacNewtonHelper, nameof(isaacNewtonHelper));

            this._shapeFactory = shapeFactory;
            this._bodyCalculationHelper = bodyCalculationHelper;
            this._isaacNewtonHelper = isaacNewtonHelper;
        }

        /// <summary>
        /// See <see cref="IElementFactory.CreateSpace"/>.
        /// </summary>
        public IPhysicalSpace CreateSpace()
        {
            return new PhysicalSpace();
        }

        /// <summary>
        /// See <see cref="IElementFactory.CreateParticle"/>.
        /// </summary>
        public IParticle CreateParticle(double mass, Point position)
        {
            ArgumentChecks.AssertIsStrictPositive(mass, nameof(mass));

            var particle = new Particle(
                this._isaacNewtonHelper,
                mass,
                new ParticleState
                {
                    Position = position
                });
            
            return particle;
        }

        /// <summary>
        /// See <see cref="IElementFactory.CreateRigidBody"/>.
        /// </summary>
        public IBody<Polygon> CreateRigidBody(double mass, Polygon polygon, Point position)
        {
            ArgumentChecks.AssertIsStrictPositive(mass, nameof(mass));

            var shape = this._shapeFactory.CreateOriginalPolygonShape(polygon);
            var initialState = new BodyState
            {
                Position = position
            };

            var rigidBody = new RigidBody<Polygon>(
                this._bodyCalculationHelper,
                this._isaacNewtonHelper,
                mass,
                shape,
                initialState);

            return rigidBody;
        }
    }
}
