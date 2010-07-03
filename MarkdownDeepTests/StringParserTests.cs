﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MarkdownDeep;

namespace MarkdownDeepTests
{
	[TestFixture]
	class StringParserTests
	{
		[Test]
		public void Tests()
		{
			var p = new StringParser();

			p.Reset("This is a string with something [bracketed]");
			Assert.IsTrue(p.bof);
			Assert.IsFalse(p.eof);
			Assert.IsTrue(p.Skip("This"));
			Assert.IsFalse(p.bof);
			Assert.IsFalse(p.eof);
			Assert.IsFalse(p.Skip("huh?"));
			Assert.IsTrue(p.SkipLinespace());
			Assert.IsTrue(p.Skip('i'));
			Assert.IsTrue(p.Skip('s'));
			Assert.IsTrue(p.SkipWhitespace());
			Assert.IsTrue(p.DoesMatchAny(new char[] { 'r', 'a', 't'} ));
			Assert.IsFalse(p.Find("Not here"));
			Assert.IsFalse(p.Find("WITH"));
			Assert.IsFalse(p.FindI("Not here"));
			Assert.IsTrue(p.FindI("WITH"));
			Assert.IsTrue(p.Find('['));
			p.Skip(1);
			p.Mark();
			Assert.IsTrue(p.Find(']'));
			Assert.AreEqual("bracketed", p.Extract());
			Assert.IsTrue(p.Skip(']'));
			Assert.IsTrue(p.eof);
		}
	}
}