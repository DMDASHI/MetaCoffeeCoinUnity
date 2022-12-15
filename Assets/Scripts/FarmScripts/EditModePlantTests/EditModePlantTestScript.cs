using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Farm;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

namespace Farm
{
    public class PlantTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void PlantTestScriptSimplePasses()
        {
            GameObject fm = new GameObject();
            fm.AddComponent<FarmManager>();
            FarmManager build = fm.GetComponent<FarmManager>();
            Assert.GreaterOrEqual(15, build.FarmMoneyTest());
            // Use the Assert class to test conditions
        }

    }
}

