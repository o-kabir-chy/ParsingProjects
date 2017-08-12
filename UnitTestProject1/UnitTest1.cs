using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagMatchLib;
using System.Linq;

namespace UnitTestProject1
{
    //[TestClass]
    //public class UnitTest1
    //{
    //    [TestMethod]
    //    public void TestMethod1()
    //    {
    //    }
    //}

    [TestClass()]
    public class TagMatchTests
    {

        ITagMatch tagmatch;
        [TestMethod()]
        public void TagMatchCreationTest()
        {
            tagmatch = new TagMatch();
            Assert.IsNotNull(tagmatch);
        }


        [TestMethod()]
        public void TagMatchValidStartTest()
        {
            tagmatch = new TagMatch();
            tagmatch.tag = "FlowDocument";
            tagmatch.inputStr = "<FlowDocument><Paragraph><Bold>Some bold text in the paragraph.</Bold>Some text that is not bold. </ Paragraph >  </FlowDocument>";
            bool hasValidStart = tagmatch.ValidateStart();
            Assert.IsTrue(hasValidStart);
        }
        [TestMethod()]
        public void TagMatchValidEndTest()
        {
            tagmatch = new TagMatch();
            tagmatch.tag = "FlowDocument";
            tagmatch.inputStr = "<FlowDocument><Paragraph><Bold>Some bold text in the paragraph.</Bold>Some text that is not bold. </ Paragraph >  </FlowDocument>";
            bool hasValidEnd = tagmatch.ValidateEnd();
            Assert.IsTrue(hasValidEnd);
        }
        [TestMethod()]
        public void ExtractAllTagObjectsTest()
        {
            tagmatch = new TagMatch();
            tagmatch.tag = "Paragraph";
            tagmatch.inputStr = "<FlowDocument><Paragraph><Bold>Some bold text in the paragraph.</Bold>Some text that is not bold. </ Paragraph >  </FlowDocument>";
            var paragraps = tagmatch.ExtractAllTagObjects(tagmatch.inputStr);
            Assert.IsTrue(paragraps.Count() == 1);
        }

        [TestMethod()]
        public void ExtractBodyTest()
        {
            tagmatch = new TagMatch();
            tagmatch.tag = "FlowDocument";
            tagmatch.inputStr = "<FlowDocument><Paragraph><Bold>Some bold text in the paragraph.</Bold>Some text that is not bold. </ Paragraph >  </FlowDocument>";
            string body = tagmatch.ExtractBody();
            Assert.AreEqual("<Paragraph><Bold>Some bold text in the paragraph.</Bold>Some text that is not bold. </ Paragraph >  ", body);
        }

        [TestMethod()]
        public void ExtractTopLevelsTagsTest()
        {
            tagmatch = new TagMatch();
            var tags = tagmatch.AllTopLevelTags("<Aa>asdh fkahds</aa>asdfasd<bbc>asd asdfasdf<CC>asdfa</CC></bbc>");
            //var tags = tagmatch.AllTopLevelTags("<aa>asdh fkahds</aa>");
            Assert.AreEqual(2, tags.Count());
        }

        [TestMethod()]
        public void ValidateStartTest()
        {
            tagmatch = new TagMatch();
            var tagname = tagmatch.TagName("<Aa>asdh fkahds</aa>");
            Assert.AreEqual("Aa", tagname);
        }
    }
}
