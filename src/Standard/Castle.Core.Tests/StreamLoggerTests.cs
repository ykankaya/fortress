// Copyright 2004-2009 Castle Project - http://www.castleproject.org/
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
using System.IO;
using System.Text.RegularExpressions;
using Castle.Core.Logging;
using NUnit.Framework;

namespace Castle.Core.Tests
{
	[TestFixture]
	public class StreamLoggerTests
	{
		[SetUp]
		public void SetUp()
		{
			stream = new MemoryStream();

			logger = new StreamLogger(Name, stream);
			logger.Level = LoggerLevel.Debug;
		}

		private const string Name = "Test";

		private StreamLogger logger;
		private MemoryStream stream;

		private void ValidateCall(LoggerLevel level, string expectedMessage, Exception expectedException)
		{
			stream.Seek(0, SeekOrigin.Begin);

			var reader = new StreamReader(stream);
			var line = reader.ReadLine();

			var match = Regex.Match(line, @"^\[(?<level>[^]]+)\] '(?<name>[^']+)' (?<message>.*)$");

			Assert.IsTrue(match.Success, "StreamLogger.Log did not match the format");
			Assert.AreEqual(Name, match.Groups["name"].Value, "StreamLogger.Log did not write the correct Name");
			Assert.AreEqual(level.ToString(), match.Groups["level"].Value, "StreamLogger.Log did not write the correct Level");
			Assert.AreEqual(expectedMessage, match.Groups["message"].Value, "StreamLogger.Log did not write the correct Message");

			line = reader.ReadLine();

			if (expectedException == null)
			{
				Assert.IsNull(line);
			}
			else
			{
				match = Regex.Match(line, @"^\[(?<level>[^]]+)\] '(?<name>[^']+)' (?<type>[^:]+): (?<message>.*)$");

				Assert.IsTrue(match.Success, "StreamLogger.Log did not match the format");
				Assert.AreEqual(Name, match.Groups["name"].Value, "StreamLogger.Log did not write the correct Name");
				Assert.AreEqual(level.ToString(), match.Groups["level"].Value, "StreamLogger.Log did not write the correct Level");
				Assert.AreEqual(expectedException.GetType().FullName, match.Groups["type"].Value, "StreamLogger.Log did not write the correct Exception Type");
				// Assert.AreEqual(expectedException.Message, match.Groups["message"].Value, "StreamLogger.Log did not write the correct Exception Message");
			}
		}

		[Test]
		public void Debug()
		{
			var message = "Debug message";
			var level = LoggerLevel.Debug;
			Exception exception = null;

			logger.Debug(message);

			ValidateCall(level, message, exception);
		}

		[Test]
		public void DebugWithException()
		{
			var message = "Debug message 2";
			var level = LoggerLevel.Debug;
			var exception = new Exception();

			logger.Debug(message, exception);

			ValidateCall(level, message, exception);
		}

		[Test]
		public void Error()
		{
			var message = "Error message";
			var level = LoggerLevel.Error;
			Exception exception = null;

			logger.Error(message);

			ValidateCall(level, message, exception);
		}

		[Test]
		public void ErrorWithException()
		{
			var message = "Error message 2";
			var level = LoggerLevel.Error;
			var exception = new Exception();

			logger.Error(message, exception);

			ValidateCall(level, message, exception);
		}

		[Test]
		public void FatalError()
		{
			var message = "FatalError message";
			var level = LoggerLevel.Fatal;
			Exception exception = null;

			logger.Fatal(message);

			ValidateCall(level, message, exception);
		}

		[Test]
		public void FatalErrorWithException()
		{
			var message = "FatalError message 2";
			var level = LoggerLevel.Fatal;
			var exception = new Exception();

			logger.Fatal(message, exception);

			ValidateCall(level, message, exception);
		}

		[Test]
		public void Info()
		{
			var message = "Info message";
			var level = LoggerLevel.Info;
			Exception exception = null;

			logger.Info(message);

			ValidateCall(level, message, exception);
		}

		[Test]
		public void InfoWithException()
		{
			var message = "Info message 2";
			var level = LoggerLevel.Info;
			var exception = new Exception();

			logger.Info(message, exception);

			ValidateCall(level, message, exception);
		}

		[Test]
		public void Warn()
		{
			var message = "Warn message";
			var level = LoggerLevel.Warn;
			Exception exception = null;

			logger.Warn(message);

			ValidateCall(level, message, exception);
		}

		[Test]
		public void WarnWithException()
		{
			var message = "Warn message 2";
			var level = LoggerLevel.Warn;
			var exception = new Exception();

			logger.Warn(message, exception);

			ValidateCall(level, message, exception);
		}
	}
}