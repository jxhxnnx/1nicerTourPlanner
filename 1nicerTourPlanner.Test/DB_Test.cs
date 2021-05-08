using System;
using _1nicerTourPlanner.DataAccessLayer;
using NUnit.Framework;

namespace _1nicerTourPlanner.Test
{
    public class DB_Test
    {
        DB db = new DB();
        [Test]
        public void DBNotNull()
        {
            Assert.IsNotNull(db);
        }

        [Test]
        public void NameExists()
        {
            Assert.IsTrue(db.NameExists("Filip"));
        }
    }
}
    