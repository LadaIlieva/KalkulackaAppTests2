using Microsoft.VisualStudio.TestTools.UnitTesting;
using KalkulackaApp;
using System;

namespace KalkulackaAppTests
{
    [TestClass]
    public class KalkulackaTests
    {
        private Kalkulacka kalkulacka;

        [TestInitialize]
        public void Initialize()
        {
            kalkulacka = new Kalkulacka(); // Vytvoří novou kalkulačku před každým testem
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void Secti()
        {
            //K porovnávání výstupu metody s očekávanou hodnotou používáme statické metody na třídě Assert
            //Nejčastěji asi použijete metodu AreEqual(), která přijímá jako první parametr očekávanou hodnotu a jako druhý parametr hodnotu aktuální.
            Assert.AreEqual(2, kalkulacka.Secti(1, 1));
            Assert.AreEqual(1.42, kalkulacka.Secti(3.14, -1.72), 0.001);    //třetí parametr a to je delta, tedy kladná tolerance, o kolik se může očekávaná a aktuální hodnota lišit, aby test stále prošel
            Assert.AreEqual(2.0 / 3, kalkulacka.Secti(1.0 / 3, 1.0 / 3), 0.001);

            //zkusíme celočíselné, desetinné i negativní vstupy, odděleně, a ověříme výsledky. V některých případech by nás mohla zajímat také maximální hodnota datových typů a podobně.
        }

        [TestMethod]
        public void Odecti()
        {
            Assert.AreEqual(0, kalkulacka.Odecti(1, 1));
            Assert.AreEqual(4.86, kalkulacka.Odecti(3.14, -1.72), 0.001);
            Assert.AreEqual(2.0 / 3, kalkulacka.Odecti(1.0 / 3, -1.0 / 3), 0.001);
        }

        [TestMethod]
        public void Vynasob()
        {
            Assert.AreEqual(2, kalkulacka.Vynasob(1, 2));
            Assert.AreEqual(-5.4008, kalkulacka.Vynasob(3.14, -1.72), 0.001);
            Assert.AreEqual(0.111, kalkulacka.Vynasob(1.0 / 3, 1.0 / 3), 0.001);
        }

        [TestMethod]
        public void Vydel()
        {
            Assert.AreEqual(2, kalkulacka.Vydel(4, 2));
            Assert.AreEqual(-1.826, kalkulacka.Vydel(3.14, -1.72), 0.001);
            Assert.AreEqual(1, kalkulacka.Vydel(1.0 / 3, 1.0 / 3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VydelVyjimka()
        {
            kalkulacka.Vydel(2, 0);
        }

        //Poslední test ověřuje, zda metoda Vydel() opravdu vyvolá výjimku při nulovém děliteli.Jak vidíte, nemusíme se zatěžovat s try-catch bloky, 
        //stačí nad metodu přidat atribut[ExpectedException] a uvést zde typ výjimky, která se očekává.Pokud výjimka nenastane, test selže.
    }
}
