using System;
using _1nicerTourPlanner.DataAccessLayer;
using NUnit.Framework;

namespace _1nicerTourPlanner.Test
{
    public class DB_Test
    {
        [Test]
        public void DBNotNull()
        {
            DB db = new DB();
            Assert.IsNotNull(db);
        }
    }
}
