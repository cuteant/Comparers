﻿namespace Nito.Comparers.Util
{
    /// <summary>Common implementations for comparers.</summary>
    /// <typeparam name="T">The type of objects being compared.</typeparam>
    internal abstract class ComparerBase<T> : EqualityComparerBase<T>, IFullComparer<T>
    {
        /// <summary>Compares two objects and returns a value less than 0 if <paramref name="x"/> is less than <paramref name="y"/>, 0 if <paramref name="x"/> is equal to <paramref name="y"/>, or greater than 0 if <paramref name="x"/> is greater than <paramref name="y"/>.</summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>A value less than 0 if <paramref name="x"/> is less than <paramref name="y"/>, 0 if <paramref name="x"/> is equal to <paramref name="y"/>, or greater than 0 if <paramref name="x"/> is greater than <paramref name="y"/>.</returns>
        protected abstract int DoCompare(T x, T y);

        /// <summary>Compares two objects and returns <c>true</c> if they are equal and <c>false</c> if they are not equal.</summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns><c>true</c> if <paramref name="x"/> is equal to <paramref name="y"/>; otherwise, <c>false</c>.</returns>
        protected override bool DoEquals(T x, T y)
        {
            return Compare(x, y) == 0;
        }

        /// <summary>Initializes a new instance of the <see cref="ComparerBase{T}"/> class.</summary>
        /// <param name="specialNullHandling">A value indicating whether <c>null</c> values are passed to <see cref="EqualityComparerBase{T}.DoGetHashCode"/> and <see cref="DoCompare"/>. If <c>false</c>, then <c>null</c> values are considered less than any non-<c>null</c> values and are not passed to <see cref="EqualityComparerBase{T}.DoGetHashCode"/> nor <see cref="DoCompare"/>.</param>
        protected ComparerBase(bool specialNullHandling)
            : base(specialNullHandling)
        {
        }

        /// <summary>Compares two objects and returns a value less than 0 if <paramref name="x"/> is less than <paramref name="y"/>, 0 if <paramref name="x"/> is equal to <paramref name="y"/>, or greater than 0 if <paramref name="x"/> is greater than <paramref name="y"/>.</summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>A value less than 0 if <paramref name="x"/> is less than <paramref name="y"/>, 0 if <paramref name="x"/> is equal to <paramref name="y"/>, or greater than 0 if <paramref name="x"/> is greater than <paramref name="y"/>.</returns>
        int System.Collections.IComparer.Compare(object x, object y)
        {
            if (!SpecialNullHandling)
            {
                if (x == null)
                {
                    if (y == null)
                        return 0;
                    return -1;
                }
                else if (y == null)
                {
                    return 1;
                }
            }

            return DoCompare((T)x, (T)y);
        }

        /// <summary>Compares two objects and returns a value less than 0 if <paramref name="x"/> is less than <paramref name="y"/>, 0 if <paramref name="x"/> is equal to <paramref name="y"/>, or greater than 0 if <paramref name="x"/> is greater than <paramref name="y"/>.</summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>A value less than 0 if <paramref name="x"/> is less than <paramref name="y"/>, 0 if <paramref name="x"/> is equal to <paramref name="y"/>, or greater than 0 if <paramref name="x"/> is greater than <paramref name="y"/>.</returns>
        public int Compare(T x, T y)
        {
            if (!SpecialNullHandling)
            {
                if (x == null)
                {
                    if (y == null)
                        return 0;
                    return -1;
                }
                else if (y == null)
                {
                    return 1;
                }
            }

            return DoCompare(x, y);
        }
    }
}
