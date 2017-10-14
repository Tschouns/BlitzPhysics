//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Base.StartUp
{
    using BlitzPhysics.Base.InversionOfControl;
    
    /// <summary>
    /// Provides a common interface for project initializer classes.
    /// </summary>
    public interface IProjectInitializer
    {
        /// <summary>
        /// Performs IOC container registrations for all the implementations in this project.
        /// </summary>
        void PerformIocContainerRegistrations(IIocContainer iocContainer);
    }
}
