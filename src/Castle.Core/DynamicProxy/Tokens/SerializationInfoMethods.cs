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
using System.Reflection;
using System.Runtime.Serialization;

namespace Castle.Core.DynamicProxy.Tokens
{
	public static class SerializationInfoMethods
	{
		public static readonly MethodInfo AddValue_Bool =
			typeof(SerializationInfo).GetMethod("AddValue", new[] { typeof(String), typeof(bool) });

		public static readonly MethodInfo AddValue_Int32 =
			typeof(SerializationInfo).GetMethod("AddValue", new[] { typeof(String), typeof(int) });

		public static readonly MethodInfo AddValue_Object =
			typeof(SerializationInfo).GetMethod("AddValue", new[] { typeof(String), typeof(Object) });

		public static readonly MethodInfo GetValue =
			typeof(SerializationInfo).GetMethod("GetValue", new[] { typeof(String), typeof(Type) });

		public static readonly MethodInfo SetType =
			typeof(SerializationInfo).GetMethod("SetType");
	}
}
