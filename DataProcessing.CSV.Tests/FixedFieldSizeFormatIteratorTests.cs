using NUnit.Framework;

namespace DataProcessing.CSV.Tests
{
    [TestFixture]
    public class FixedFieldSizeFormatIteratorTests
    {
        const string Data0 = "1234567812345678123412\n";

        [Test]
        public void Iterator_Only_Cares_About_Fields_Defined()
        {
            var iterator = new FixedFieldSizeFormatIterator<string>(Data0, 8, 8, 4, 2);
            var enumerator = iterator.GetEnumerator();

            enumerator.MoveNext();
            Assert.AreEqual("12345678", enumerator.Current);

            enumerator.MoveNext();
            Assert.AreEqual("12345678", enumerator.Current);

            enumerator.MoveNext();
            Assert.AreEqual("1234", enumerator.Current);

            enumerator.MoveNext();
            Assert.AreEqual("12", enumerator.Current);
        }
    }
}
