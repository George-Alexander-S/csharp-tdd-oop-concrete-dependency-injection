using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        [Test]
        public void shouldTurnOn()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            myPc.turnOn();

            Assert.That(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            myPc.installGame("Final Fantasy XI");

            Assert.That(1, Is.EqualTo(myPc.installedGames.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.installedGames[0].name));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            myPc.installGame("Duck Game");
            myPc.installGame("Dragon's Dogma: Dark Arisen");

            Assert.That("Playing Duck Game", Is.EqualTo(myPc.playGame("Duck Game")));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.playGame("Dragon's Dogma: Dark Arisen")));
            Assert.That("Game not installed", Is.EqualTo(myPc.playGame("Morrowind")));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            Game game1 = new Game("Dwarf Fortress");
            game1.name = "Dwarf Fortress";
            Game game2 = new Game("Baldur's Gate");
            game2.name = "Baldur's Gate";

            myPc.preInstalledGames.Add(game1);
            myPc.preInstalledGames.Add(game2);
            //myPc.preInstalledGames.Add(new Game("Baldur's Gate"));

            Assert.That(2, Is.EqualTo(myPc.preInstalledGames.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.preInstalledGames[0].name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.preInstalledGames[1].name));
        }
    }
}