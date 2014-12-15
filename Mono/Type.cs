//
// TypeCode.cs
//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Copyright (c) 2008 - 2014 Jb Evain
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Reflection;

#if CORECLR
using System.Collections.Generic;
#endif

namespace Mono {

#if CORECLR
	enum TypeCode {
		Empty = 0,
		Object = 1,
		DBNull = 2,
		Boolean = 3,
		Char = 4,
		SByte = 5,
		Byte = 6,
		Int16 = 7,
		UInt16 = 8,
		Int32 = 9,
		UInt32 = 10,
		Int64 = 11,
		UInt64 = 12,
		Single = 13,
		Double = 14,
		Decimal = 15,
		DateTime = 16,
		String = 18
	}
#endif

	static class TypeExtensions {

#if CORECLR
		private static readonly Dictionary<Type, TypeCode> TypeCodeMap = new Dictionary<Type, TypeCode>
		{
			{ typeof (object), TypeCode.Object },
			{ typeof (bool), TypeCode.Boolean },
			{ typeof (char), TypeCode.Char },
			{ typeof (sbyte), TypeCode.SByte },
			{ typeof (byte), TypeCode.Byte },
			{ typeof (short), TypeCode.Int16 },
			{ typeof (ushort), TypeCode.UInt16 },
			{ typeof (int), TypeCode.Int32 },
			{ typeof (uint), TypeCode.UInt32 },
			{ typeof (long), TypeCode.Int64 },
			{ typeof (ulong), TypeCode.UInt64 },
			{ typeof (float), TypeCode.Single },
			{ typeof (double), TypeCode.Double },
			{ typeof (decimal), TypeCode.Decimal },
			{ typeof (DateTime), TypeCode.DateTime },
			{ typeof (string), TypeCode.String },
		};
#endif

		public static TypeCode GetTypeCode (this Type type)
		{
#if CORECLR
			TypeCode code;
			if (!TypeCodeMap.TryGetValue (type, out code))
				throw new NotSupportedException ();

			return code;
#else
			return Type.GetTypeCode (type);
#endif
		}

		public static Assembly GetAssembly (this Type type)
		{
#if CORECLR
			return type.GetTypeInfo ().Assembly;
#else
			return type.Assembly;
#endif
		}
	}
}

