//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Facade.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains tests that verify the initialization of this facade works.
    /// </summary>
    [TestClass]
    public class InitializationTests
    {
        /// <summary>
        /// Verifies that the initialization runs through, and that all the components can
        /// be accessed (i.e. are not null) afterwards.
        /// </summary>
        [TestMethod]
        public void Initialize_Access_ComponentsAreNotNull()
        {
            // Arrange
            BlitzPhysicsInitializer.Initialize();

            // Act
            var elementFactory = Simulation.Element;
            var forceFactory = Simulation.Force;
            var worldFactory = Simulation.World;

            // Assert
            Assert.IsNotNull(elementFactory);
            Assert.IsNotNull(forceFactory);
            Assert.IsNotNull(worldFactory);
        }
    }
}
