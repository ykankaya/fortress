// Copyright 2004-2010 Castle Project - http://www.castleproject.org/
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

using Castle.Windsor.MicroKernel.Registration;
using Castle.Windsor.Windsor;

namespace Castle.Windsor.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class RegisteringTwoServicesForSameType
	{
		[Test]
		public void ResolvingComponentIsDoneOnFirstComeBasis()
		{
			IWindsorContainer windsor = new WindsorContainer();
			windsor.Register(Component.For<IService>().ImplementedBy<Srv1>().Named("1"));
			windsor.Register(Component.For<IService>().ImplementedBy<Srv1>().Named("2"));

			Assert.IsInstanceOf<Srv1>(windsor.Resolve<IService>());
		}

		[Test]
		public void ResolvingComponentIsDoneOnFirstComeBasisWhenNamesAreNotOrdered()
		{
			IWindsorContainer windsor = new WindsorContainer();
			windsor.Register(Component.For<IService>().ImplementedBy<Srv1>().Named("3"));
			windsor.Register(Component.For<IService>().ImplementedBy<Srv1>().Named("2"));

			Assert.IsInstanceOf<Srv1>(windsor.Resolve<IService>());
		}

		public interface IService
		{
		}

		public class Srv1 : IService
		{
		}

		public class Srv2 : IService
		{
		}
	}
}