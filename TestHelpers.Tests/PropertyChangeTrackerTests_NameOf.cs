﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHelpers.Tests
{
    [TestClass]
    public class PropertyChangeTrackerTests_NameOf
    {
        [TestMethod]
        public void Tracker_NameOfPropertyChanged_ReturnsTrue()
        {
            var changer = new FakeClassNameOf("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            changer.LastName = "Jones";
            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Tracker_NameOfPropertyNotChanged_ReturnsFalse()
        {
            var changer = new FakeClassNameOf("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Tracker_NameOfAllPropertiesChanged_ReturnsTrue()
        {
            var changer = new FakeClassNameOf("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            changer.NotifyAllProperties();
            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsTrue(result);
        }
    }
}
