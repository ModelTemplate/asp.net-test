using System;
using Xunit;
using MVCWebApp.Models;

namespace MVCWebAppTest
{
    public class ItemModelUnitTest
    {
        [Fact]
        public void NoParamTest()
        {
            Item item = new Item();
            Assert.Equal(-1, item.ID);
            Assert.Null(item.Name);
            Assert.Null(item.Description);
            Assert.Equal(-1, item.Cost);
            Assert.Equal(-1, item.DepreciationRate);
        }

        [Theory]
        [InlineData(0, "Hammer", "My trusty hammer.", 15.99f, 0.5f)]
        [InlineData(1, "Frying Pan", "Copper non-stick pan.", 30.50f, 0.25f)]
        public void ParamTest(int id, string name, string description, float cost, float depreciationRate)
        {
            Item item = new Item(id, name, description, cost, depreciationRate);
            Assert.Equal(id, item.ID);
            Assert.Equal(name, item.Name);
            Assert.Equal(description, item.Description);
            Assert.Equal(cost, item.Cost);
            Assert.Equal(depreciationRate, item.DepreciationRate);
        }
    }
}
