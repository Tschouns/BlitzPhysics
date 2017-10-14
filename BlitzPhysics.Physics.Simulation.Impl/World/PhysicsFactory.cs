//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Physics.Simulation.Impl.World
{
    using BlitzPhysics.Base.RuntimeChecks;
    using BlitzPhysics.Physics.Simulation.Forces;
    using BlitzPhysics.Physics.Simulation.Objects;
    using BlitzPhysics.Physics.Simulation.World;

    /// <summary>
    /// See <see cref="IWorldFactory"/>.
    /// </summary>
    public class PhysicsFactory : IWorldFactory
    {
        /// <summary>
        /// Stores the <see cref="IElementFactory"/>.
        /// </summary>
        private readonly IElementFactory _elementFactory;

        /// <summary>
        /// Stores the <see cref="IForceFactory"/>.
        /// </summary>
        private readonly IForceFactory _forceFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsFactory"/> class.
        /// </summary>
        public PhysicsFactory(
            IElementFactory elementFactory,
            IForceFactory forceFactory)
        {
            ArgumentChecks.AssertNotNull(elementFactory, nameof(elementFactory));
            ArgumentChecks.AssertNotNull(forceFactory, nameof(forceFactory));

            this._elementFactory = elementFactory;
            this._forceFactory = forceFactory;
        }

        /// <summary>
        /// See <see cref="IWorldFactory.CreatePhysicalWorld"/>.
        /// </summary>
        public IPhysicalWorld CreatePhysicalWorld()
        {
            var physicalWorld = new PhysicalWorld(
                this._elementFactory,
                this._forceFactory);

            return physicalWorld;
        }
    }
}
