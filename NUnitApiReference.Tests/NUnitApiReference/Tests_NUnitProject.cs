// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NUnitApiReference {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using ArchitectureModel.Utils;
    using NUnit.Framework;

    public class Tests_NUnitProject {


        [Test]
        public void Test_NUnitProject() {
            var actual = new NUnitProject();
            var expected = Assembly.Load( "nunit.framework" );

            var missing = actual.GetMissing( expected ).ToList();
            var extra = actual.GetExtra( expected ).ToList();

            if (missing.Any() || extra.Any()) {
                var builder = new StringBuilder();
                builder.AppendLine( "NUnitProject is invalid" );
                if (missing.Any()) {
                    builder.AppendLine( $"Missing ({missing.Count}):" );
                    foreach (var item in missing) builder.AppendLine( item.FullName );
                }
                if (extra.Any()) {
                    builder.AppendLine( $"Extra ({extra.Count}):" );
                    foreach (var item in extra) builder.AppendLine( item.FullName );
                }
                Assert.Fail( builder.ToString() );
            }
        }


    }
}