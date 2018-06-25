using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pos.Web.UnitTests
{
    public static partial class AssertEx
    {
        public static void Contains<T>(IEnumerable<T> collection, params T[] elements)
        {
            Contains(collection, null, elements);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.FormatCultureInvariant(System.String,System.Object,System.Object)")]
        public static void Contains<T>(IEnumerable<T> collection, Func<T, T, bool> equality, params T[] elements)
        {
            if (elements.Length == 0)
                return;

            bool contains = CollectionContainsElements(collection, elements, equality, out var notContained);

            Assert.IsTrue(contains, string.Format("{0} expected to be contained by {1}", elements[notContained], collection));
        }

        public static void NotContains<T>(IEnumerable<T> collection, params T[] elements)
        {
            NotContains(collection, null, elements);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.FormatCultureInvariant(System.String,System.Object,System.Object)")]
        public static void NotContains<T>(IEnumerable<T> collection, Func<T, T, bool> equality, params T[] elements)
        {
            if (elements.Length == 0)
                return;

            bool contains = CollectionContainsElements(collection, elements, equality, out var notContained);

            Assert.IsFalse(contains, string.Format("{0} not expected to be contained by {1}", elements[notContained], collection));
        }

        public static void AreEquivalent<T>(IEnumerable<T> collection, params T[] elements)
        {
            AreEquivalent(collection, null, elements);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.FormatCultureInvariant(System.String,System.Object,System.Object)")]
        public static void AreEquivalent<T>(IEnumerable<T> collection, Func<T, T, bool> equality, params T[] elements)
        {
            Assert.AreEqual(elements.Length, collection.Count(), "Collections do not have same number of elements");

            if (elements.Length == 0)
                return;

            bool contains = CollectionContainsElements(collection, elements, equality, out var notContained);

            Assert.IsTrue(contains, string.Format("{0} expected to be contained by {1}", elements[notContained], collection));
        }

        private static bool CollectionContainsElements<T>(IEnumerable<T> collection, T[] elements, Func<T, T, bool> equality, out int index)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (!collection.Contains<T>(elements[i], new Comparer<T>(equality)))
                {
                    index = i;
                    return false;
                }
            }

            index = 0;
            return true;
        }

        private class Comparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> equalityFunc;

            public Comparer(Func<T, T, bool> equalityFunc)
            {
                this.equalityFunc = equalityFunc;
            }

            public bool Equals(T x, T y)
            {
                if (equalityFunc == null)
                    return x.Equals(y);

                return equalityFunc(x, y);
            }

            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}