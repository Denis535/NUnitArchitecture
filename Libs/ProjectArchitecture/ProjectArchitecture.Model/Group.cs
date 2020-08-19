// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace ProjectArchitecture.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Group : INode {

        public string Name { get; }
        public Type[] Types { get; }
        public Group(string name, params Type[] types) => (Name, Types) = (name, types);
        public Group(params Type[] types) => (Name, Types) = ("Default", types);


        // Utils
        public override string ToString() {
            return $"{nameof( Group )}: {Name}";
        }


    }
}