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
using System.Collections.Generic;
using Castle.Windsor.Core;
using Castle.Windsor.Core.Internal;
using Castle.Windsor.MicroKernel.Context;

namespace Castle.Windsor.MicroKernel.Resolvers.SpecializedResolvers
{
	public class ListResolver : CollectionResolver
	{
		public ListResolver(IKernel kernel)
			: base(kernel, false)
		{
		}

		public ListResolver(IKernel kernel, bool allowEmptyList)
			: base(kernel, allowEmptyList)
		{
		}

		public override object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver,
		                               ComponentModel model,
		                               DependencyModel dependency)
		{
			var items = base.Resolve(context, contextHandlerResolver, model, dependency);
			var listType = BuildListType(dependency);
			return listType.CreateInstance<object>(items);
		}

		protected override Type GetItemType(Type targetItemType)
		{
			if (targetItemType.IsGenericType == false ||
			    targetItemType.GetGenericTypeDefinition() != typeof(IList<>))
			{
				return null;
			}
			return targetItemType.GetGenericArguments()[0];
		}

		private Type BuildListType(DependencyModel dependency)
		{
			return typeof(List<>).MakeGenericType(GetItemType(dependency.TargetItemType));
		}
	}
}