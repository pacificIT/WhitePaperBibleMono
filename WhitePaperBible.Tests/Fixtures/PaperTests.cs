using System;
using System.Collections.Generic;
using NUnit.Framework;
using WhitePaperBibleCore.Services;
using WhitePaperBibleCore.Models;

namespace WhitePaperBible.Tests
{
	[TestFixture]
    public class PaperTests
	{
		
		PaperService svc;	
		
		[SetUp]
		public void Init()
		{
			svc = new PaperService();
		}
		
		[TearDown]
		public void Dispose()
		{
			
		}
		
		
		[Test]
		public void CanMakePapersService ()
		{
			Assert.NotNull(svc, "Service should not be null");
		}
		
		[Test]
		public void CanCallGetPapers ()
		{
			svc.GetPapers(onPapersReceived, onErrorReceived);
			Assert.True(true, "PapersService should have a method getPapers");
		}
		
        private void onErrorReceived(string error)
        {
            Assert.Fail("received an error, you fail");
        }

        private void onPapersReceived(List<PaperNode> papers)
        {
            Assert.NotNull(papers, "papers should not be null");
            Assert.True(papers.Count > 1, "should have more than 1 paper");
			
        }
		
		[Test]
		public void CanGetPaperReferences ()
		{
			svc.GetPaperReferences(71, onPaperReferencesReceived, onReferencesErrorReceived);
		}
		
		private void onReferencesErrorReceived(string error)
        {
            Assert.Fail("received an error, you fail");
        }

        private void onPaperReferencesReceived(List<ReferenceNode> references)
        {
            Assert.NotNull(references, "references should not be null");
            Assert.True(references.Count > 0, "should have at least 1 references");
			
        }

		
	}
}
