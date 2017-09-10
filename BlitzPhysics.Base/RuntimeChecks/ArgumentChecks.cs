//-----------------------------------------------------------------------
// <copyright file="BiteMe.cs" company="Jonas Aklin">
//     Copyright (c) Jonas Aklin. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BlitzPhysics.Base.RuntimeChecks
{
    using System;

    /// <summary>
    /// Checks method arguments, and throws exceptions.
    /// </summary>
    public static class ArgumentChecks
    {
        /// <summary>
        /// Asserts that the specified floating point number is positive, including 0.
        /// </summary>
        public static void AssertIsPositive(double argument, string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentException($"The floating point number {argument}, specified in argument {argumentName}, must be positive.");
            }
        }

        /// <summary>
        /// Asserts that the specified floating point number is positive, including 0.
        /// </summary>
        public static void AssertIsPositive(float argument, string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentException($"The floating point number {argument}, specified in argument {argumentName}, must be positive.");
            }
        }

        /// <summary>
        /// Asserts that the specified floating point number is positive and greater than 0.
        /// </summary>
        public static void AssertIsStrictPositive(double argument, string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentException($"The floating point number {argument}, specified in argument {argumentName}, must be greater than 0.");
            }
        }

        /// <summary>
        /// Asserts that the specified floating point number is positive and greater than 0.
        /// </summary>
        public static void AssertIsStrictPositive(float argument, string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentException($"The floating point number {argument}, specified in argument {argumentName}, must be greater than 0.");
            }
        }

        /// <summary>
        /// Asserts that the specified argument is not <c>null</c>, otherwise throws an <see cref="ArgumentNullException"/>.
        /// </summary>
        public static void AssertNotNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
