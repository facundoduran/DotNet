using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Services;
using System.Collections.Generic;
using AdvancedTechniques.UP.Persistence.Sql;
using System.Data.Entity;

namespace AdvancedTechniquesUP.Test
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void UnitOfWork_Test()
        {
            Mock<IDbContext> dbContextMock = new Mock<IDbContext>();

            dbContextMock.Setup(x => x.Set<Booking>()).Returns(Mock.Of<IDbSet<Booking>>);

            var unitOfWorkMock = new Mock<IUnitOfWork>();

            unitOfWorkMock.Setup(x => x.GetDbContext()).Returns(dbContextMock.Object);

            unitOfWorkMock.Verify(a => a.Commit(), Times.Exactly(0));
        }
    }
}
