// Copyright 2004-2015 Castle Project - http://www.castleproject.org/
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
using System.Reflection;

namespace Castle.Core.Compatibility
{
	// This allows us to use the new reflection API while still supporting .NET 3.5 and 4.0.
	//
	// Methods like Type.GetInterfaceMap no longer exist in .NET Core so this provides a shim
	// for .NET 3.5 and 4.0.
	internal static class RuntimeReflectionExtensions
	{
		// Delegate to the old name for this method.
		public static InterfaceMapping GetRuntimeInterfaceMap(this Type type, Type interfaceType)
		{
			return type.GetInterfaceMap(interfaceType);
		}
	}
}
