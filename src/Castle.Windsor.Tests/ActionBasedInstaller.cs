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
using Castle.Windsor.MicroKernel.SubSystems.Configuration;
using Castle.Windsor.Windsor;

namespace Castle.Windsor.Tests
{
	using System;

	internal class ActionBasedInstaller : IWindsorInstaller
	{
		private readonly Action<IWindsorContainer> install;

		public ActionBasedInstaller(Action<IWindsorContainer> install)
		{
			this.install = install;
		}

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			install(container);
		}
	}
}