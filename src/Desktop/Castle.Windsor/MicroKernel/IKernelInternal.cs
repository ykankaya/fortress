// Copyright 2004-2012 Castle Project - http://www.castleproject.org/
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
using System.Collections;
using Castle.Core.Core.Logging;
using Castle.Windsor.Core;

namespace Castle.Windsor.MicroKernel
{
	public interface IKernelInternal : IKernel
	{
		ILogger Logger { get; set; }

		IHandler AddCustomComponent(ComponentModel model);

		IComponentActivator CreateComponentActivator(ComponentModel model);

		ILifestyleManager CreateLifestyleManager(ComponentModel model, IComponentActivator activator);

		IHandler LoadHandlerByName(string key, Type service, IDictionary arguments);

		IHandler LoadHandlerByType(string key, Type service, IDictionary arguments);

		IDisposable OptimizeDependencyResolution();

		object Resolve(Type service, IDictionary arguments, IReleasePolicy policy);

		object Resolve(string key, Type service, IDictionary arguments, IReleasePolicy policy);

		Array ResolveAll(Type service, IDictionary arguments, IReleasePolicy policy);

		IHandler CreateHandler(ComponentModel model);

		void RaiseEventsOnHandlerCreated(IHandler handler);
	}
}