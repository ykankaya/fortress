// Copyright 2004-2013 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using Castle.Windsor.MicroKernel;
using Castle.Windsor.MicroKernel.Handlers;
using Castle.Windsor.MicroKernel.Registration;
using Castle.Windsor.MicroKernel.Resolvers;
using Castle.Windsor.Tests.RuntimeParameters;
using NUnit.Framework;

namespace Castle.Windsor.Tests
{
	[TestFixture]
	public class RuntimeParametersTestCase : AbstractContainerTestCase
	{
		private readonly Dictionary<string, object> dependencies = new Dictionary<string, object> { { "cc", new CompC(12) }, { "myArgument", "ernst" } };

		private void AssertDependencies(CompB compb)
		{
			Assert.IsNotNull(compb, "Component B should have been resolved");

			Assert.IsNotNull(compb.Compc, "CompC property should not be null");
			Assert.IsTrue(compb.MyArgument != string.Empty, "MyArgument property should not be empty");

			Assert.AreSame(dependencies["cc"], compb.Compc, "CompC property should be the same instnace as in the hashtable argument");
			Assert.IsTrue("ernst".Equals(compb.MyArgument),
			              string.Format("The MyArgument property of compb should be equal to ernst, found {0}", compb.MyArgument));
		}

		[Test]
		public void AddingDependencyToServiceWithCustomDependency()
		{
			var kernel = new DefaultKernel();
			kernel.Register(Component.For<NeedClassWithCustomerDependency>(),
			                Component.For<HasCustomDependency>().DependsOn(new Dictionary<object, object> { { "name", new CompA() } }));

			Assert.AreEqual(HandlerState.Valid, kernel.GetHandler(typeof(HasCustomDependency)).CurrentState);
			Assert.IsNotNull(kernel.Resolve(typeof(NeedClassWithCustomerDependency)));
		}


		[Test]
		public void Parameter_takes_precedence_over_registered_service()
		{
			Container.Register(Component.For<CompA>(),
			                   Component.For<CompB>().DependsOn(Dependency.OnValue<string>("some string")),
			                   Component.For<CompC>().Instance(new CompC(0)));

			var c2 = new CompC(42);
			var args = new Arguments(new object[] { c2 });
			var b = Container.Resolve<CompB>(args);

			Assert.AreSame(c2, b.Compc);
		}

		[Test]
		public void ParametersPrecedence()
		{
			Container.Register(Component.For<CompA>().Named("compa"),
			                   Component.For<CompB>().Named("compb").DependsOn(dependencies));

			var instance_with_model = Container.Resolve<CompB>();
			Assert.AreSame(dependencies["cc"], instance_with_model.Compc, "Model dependency should override kernel dependency");

			var deps2 = new Dictionary<string, object> { { "cc", new CompC(12) }, { "myArgument", "ayende" } };

			var instance_with_args = Container.Resolve<CompB>(deps2);

			Assert.AreSame(deps2["cc"], instance_with_args.Compc, "Should get it from resolve params");
			Assert.AreEqual("ayende", instance_with_args.MyArgument);
		}

		[Test]
		public void ResolveUsingParameters()
		{
			Container.Register(Component.For<CompA>().Named("compa"),
			                   Component.For<CompB>().Named("compb"));
			var compb = Container.Resolve<CompB>(dependencies);

			AssertDependencies(compb);
		}

		[Test]
		public void ResolveUsingParametersWithinTheHandler()
		{
			Container.Register(Component.For<CompA>().Named("compa"),
			                   Component.For<CompB>().Named("compb").DependsOn(dependencies));

			var compb = Container.Resolve<CompB>();

			AssertDependencies(compb);
		}

		[Test]
		public void WillAlwaysResolveCustomParameterFromServiceComponent()
		{
			Container.Register(Component.For<CompA>(),
			                   Component.For<CompB>().DependsOn(new { myArgument = "foo" }),
			                   Component.For<CompC>().DependsOn(new { test = 15 }));
			var b = Kernel.Resolve<CompB>();
			Assert.IsNotNull(b);
			Assert.AreEqual(15, b.Compc.test);
		}

	}
}