namespace ProjectArchitecture.Model {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class NamespaceFactory {


        public static Namespace AsNamespace(this string name) {
            return new Namespace( name );
        }


        public static Namespace[] ToHierarchy(this object[] objects) {
            return objects.ToHierarchy<Namespace>().Select( i => ToNamespace( i.Object, i.Inner ) ).ToArray();
        }
        private static Namespace ToNamespace(Namespace @namespace, object[] inner) {
            var groups = inner.ToHierarchy<Group>().Select( i => ToGroup( i.Object, i.Inner ) ).ToArray();
            return new Namespace( @namespace.Name, groups );
        }
        private static Group ToGroup(Group group, object[] inner) {
            return new Group( group.Name, inner.Cast<Type>().Select( i => (TypeItem) i ).ToArray() );
        }


        // Helpers
        private static IEnumerable<(T Object, object[] Inner)> ToHierarchy<T>(this IEnumerable enumerable) {
            var enumerator = enumerable.GetEnumerator();
            var hasNext = enumerator.MoveNext();
            while (hasNext) {
                var key = default( T )!;
                var values = new List<object>();
                if (hasNext && enumerator.Current is T item_) {
                    key = item_;
                    hasNext = enumerator.MoveNext();
                }
                while (hasNext && enumerator.Current is T == false) {
                    values.Add( enumerator.Current );
                    hasNext = enumerator.MoveNext();
                }
                yield return (key, values.ToArray());
            }
        }


    }
}
