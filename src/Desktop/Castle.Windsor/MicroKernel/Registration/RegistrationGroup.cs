// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
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

using Castle.Windsor.MicroKernel.ModelBuilder;
using Castle.Windsor.MicroKernel.ModelBuilder.Descriptors;

namespace Castle.Windsor.MicroKernel.Registration
{
	public abstract class RegistrationGroup<S>
		where S : class
	{
		public RegistrationGroup(ComponentRegistration<S> registration)
		{
			Registration = registration;
		}

		public ComponentRegistration<S> Registration { get; }

		protected ComponentRegistration<S> AddAttributeDescriptor(string name, string value)
		{
			return Registration.AddDescriptor(new AttributeDescriptor<S>(name, value));
		}

		protected ComponentRegistration<S> AddDescriptor(IComponentModelDescriptor descriptor)
		{
			return Registration.AddDescriptor(descriptor);
		}
	}
}