using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Linq;

public class SaveLoadTests
{
    [Test]
    public void CheckSaveLoad() {
        PlayerPrefs.DeleteAll();

        List<string[]> expectedSave = System.IO.File.ReadAllLines(@"Assets\Editor\expected save.txt")
            .Select(line => line.Split('#'))
            .ToList();

        var saveLoadTest = new SaveTestHelper();

        SaveInfomation infomation = new SaveInfomation();

        saveLoadTest.Save(infomation);

        string data = SaveHelper.Serialise<SaveInfomation>(infomation);

        data = SaveHelper.Serialise<SaveInfomation>(SaveHelper.Deserialise<SaveInfomation>(data));

        Assert.That(SaveHelper.Serialise<SaveInfomation>(saveLoadTest.Load()), Is.EqualTo(data));
    }
}
