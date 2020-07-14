// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NUnitApiReference {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Item {
        public static implicit operator Item(string value) => new GroupItem( value );
        public static implicit operator Item(Type value) => new TypeItem( value );
    }
    public class HeaderItem : Item {
        public readonly string Value;
        public readonly int Level;

        public static HeaderItem H1(string value) => new HeaderItem( value, 1 );
        public static HeaderItem H2(string value) => new HeaderItem( value, 2 );
        private HeaderItem(string value, int level) => (Value, Level) = (value, level);

        public override int GetHashCode() => (Value, Level).GetHashCode();
        public override bool Equals(object obj) => obj is HeaderItem obj_ && (Value, Level) == (obj_.Value, obj_.Level);
        public override string ToString() => $"{Value} ({Level})";
    }
    public class GroupItem : Item {
        public readonly string Value;

        public GroupItem(string value) => Value = value;

        public override int GetHashCode() => Value.GetHashCode();
        public override bool Equals(object obj) => obj is GroupItem obj_ && Value == obj_.Value;
        public override string ToString() => Value;
    }
    public class TypeItem : Item {
        public readonly Type Value;

        public TypeItem(Type value) => Value = value;

        public override int GetHashCode() => Value.GetHashCode();
        public override bool Equals(object obj) => obj is TypeItem obj_ && Value == obj_.Value;
        public override string ToString() => Value.Name;
    }
}