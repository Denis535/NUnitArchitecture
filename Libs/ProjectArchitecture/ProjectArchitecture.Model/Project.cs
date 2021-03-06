// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace ProjectArchitecture.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Project : INode {

        public abstract string Name { get; }
        INode[] INode.Children => Modules;
        public abstract Module[] Modules { get; }


        // Flatten
        public IEnumerable<INode> Flatten() {
            yield return this;

            foreach (var module in Modules) {
                yield return module;

                foreach (var @namespace in module.Namespaces) {
                    yield return @namespace;

                    foreach (var group in @namespace.Groups) {
                        yield return group;

                        foreach (var type in group.Types) {
                            yield return type;
                        }
                    }
                }
            }
        }
        public IEnumerable<T> Flatten<T>() where T : INode {
            return Flatten().OfType<T>();
        }


        // Utils
        public override string ToString() {
            return "Project: " + Name;
        }
        public string ToLongString() {
            var builder = new StringBuilder();
            builder.AppendLine( "Project: " + Name );

            foreach (var module in Modules) {
                builder.AppendLine( "Module: " + module.Name );

                foreach (var @namespace in module.Namespaces) {
                    builder.AppendLine( "Namespace: " + @namespace.Name );

                    foreach (var group in @namespace.Groups) {
                        builder.AppendLine( "Group: " + group.Name );

                        foreach (var type in group.Types) {
                            builder.AppendLine( "Type: " + type.Name );
                        }
                    }
                }
            }
            return builder.ToString();
        }


    }
}
