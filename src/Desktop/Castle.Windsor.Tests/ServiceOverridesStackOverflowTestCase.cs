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

using System.Linq;
using Castle.Windsor.Tests.XmlFiles;
using Castle.Windsor.Windsor;
using Castle.Windsor.Windsor.Installer;
using NUnit.Framework;

namespace Castle.Windsor.Tests
{
	[TestFixture]
	public class ServiceOverridesStackOverflowTestCase
	{
		[Test]
		public void Should_not_StackOverflow()
		{
			var container = new WindsorContainer()
				.Install(Configuration.FromXml(Xml.Embedded("channel1.xml")));

			var channel = container.Resolve<MessageChannel>("MessageChannel1");
			var array = channel.RootDevice.Children.ToArray();

			Assert.AreSame(channel.RootDevice, container.Resolve<IDevice>("device1"));
			Assert.AreEqual(2, array.Length);
			Assert.AreSame(array[0], container.Resolve<IDevice>("device2"));
			Assert.AreSame(array[1], container.Resolve<IDevice>("device3"));
		}
	}
}