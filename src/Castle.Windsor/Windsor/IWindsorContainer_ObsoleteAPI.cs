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

using System;
using System.Collections;
using System.ComponentModel;
using Castle.Windsor.Core;
using Castle.Windsor.MicroKernel;

namespace Castle.Windsor.Windsor
{
	public partial interface IWindsorContainer : IDisposable
	{
		[Obsolete("Use Resolve<object>(key) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		object this[String key] { get; }

		[Obsolete("Use Resolve(service) or generic version instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		object this[Type service] { get; }

		[Obsolete("Use Register(Component.For(classType).Named(key)) or generic version instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponent(String key, Type classType);

		[Obsolete("Use Register(Component.For(serviceType).ImplementedBy(classType).Named(key)) or generic version instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponent(String key, Type serviceType, Type classType);

		[Obsolete("Use Register(Component.For<T>()) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponent<T>();

		[Obsolete("Use Register(Component.For<T>().Named(key)) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponent<T>(String key);

		[Obsolete("Use Register(Component.For<I>().ImplementedBy<T>()) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponent<I, T>() where T : class;

		[Obsolete("Use Register(Component.For<I>().ImplementedBy<T>().Named(key)) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponent<I, T>(String key) where T : class;

		[Obsolete("Use Register(Component.For(classType).Named(key).Lifestyle.Is(lifestyle)) or generic version instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentLifeStyle(String key, Type classType, LifestyleType lifestyle);

		[Obsolete(
			"Use Register(Component.For(serviceType).ImplementedBy(classType).Named(key).Lifestyle.Is(lifestyle)) or generic version instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentLifeStyle(String key, Type serviceType, Type classType, LifestyleType lifestyle);

		[Obsolete("Use Register(Component.For<T>().Lifestyle.Is(lifestyle)) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentLifeStyle<T>(LifestyleType lifestyle);

		[Obsolete("Use Register(Component.For<T>().Named(key).Lifestyle.Is(lifestyle)) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentLifeStyle<T>(String key, LifestyleType lifestyle);

		[Obsolete("Use Register(Component.For<I>().ImplementedBy<T>().Lifestyle.Is(lifestyle)) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentLifeStyle<I, T>(LifestyleType lifestyle) where T : class;

		[Obsolete("Use Register(Component.For<I>().ImplementedBy<T>().Named(key).Lifestyle.Is(lifestyle)) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentLifeStyle<I, T>(String key, LifestyleType lifestyle) where T : class;

		[Obsolete("Use Register(Component.For<I>().ImplementedBy<T>().ExtendedProperties(extendedProperties)) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentProperties<I, T>(IDictionary extendedProperties) where T : class;

		[Obsolete(
			"Use Register(Component.For<I>().ImplementedBy<T>().Named(key).ExtendedProperties(extendedProperties)) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentProperties<I, T>(String key, IDictionary extendedProperties) where T : class;

		[Obsolete("Use Register(Component.For(classType).Named(key).ExtendedProperties(extendedProperties)) or generic version instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentWithProperties(String key, Type classType, IDictionary extendedProperties);

		[Obsolete(
			"Use Register(Component.For(serviceType).ImplementedBy(classType).Named(key).ExtendedProperties(extendedProperties)) or generic version instead."
			)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentWithProperties(String key, Type serviceType, Type classType,
		                                             IDictionary extendedProperties);

		[Obsolete("Use Register(Component.For<T>().ExtendedProperties(extendedProperties)) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentWithProperties<T>(IDictionary extendedProperties);

		[Obsolete("Use Register(Component.For<T>().Named(key).ExtendedProperties(extendedProperties)) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddComponentWithProperties<T>(String key, IDictionary extendedProperties);

		[Obsolete("Use AddFacility(IFacility) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddFacility(String idInConfiguration, IFacility facility);

		[Obsolete("Use AddFacility<TFacility>(Action<TFacility> onCreate) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddFacility<TFacility>(String idInConfiguration) where TFacility : IFacility, new();

		[Obsolete("Use AddFacility<TFacility>(Action<TFacility>) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IWindsorContainer AddFacility<TFacility>(String idInConfiguration, Action<TFacility> configureFacility)
			where TFacility : IFacility, new();

		[Obsolete("Use Resolve<object>(key, arguments) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		object Resolve(String key, IDictionary arguments);

		[Obsolete("Use Resolve<object>(key, argumentsAsAnonymousType) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		object Resolve(String key, object argumentsAsAnonymousType);
	}
}