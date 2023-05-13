using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laba4_Life;

namespace TestLife
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCountOfSteps()
        {
            Game_of_life Life = new Game_of_life(200, 200, 1, 0.5);
            Life.LoadBoard("Test1.txt");
            int steps = Life.Run(false);
            Assert.IsTrue(steps == 1103);
        }


        [TestMethod]
        public void TestStatistic1()
        {
            Game_of_life Life = new Game_of_life(20, 20, 1, 0.5);
            Life.LoadBoard("Test2.txt");
            Life.Run(false);
            int count_of_alive = Life.Board.CountAliveCells();
            int count_of_hive = Life.Board.CountHive();
            int count_of_loaf = Life.Board.CountLoaf();
            int count_of_block = Life.Board.CountBlock();
            int count_of_box = Life.Board.CountBox();
            int count_of_pond = Life.Board.CountPond();
            int count_of_snake = Life.Board.CountSnake();
            int count_of_blinker = Life.Board.CountBlinker();
            int count_of_carrier = Life.Board.CountCarrier();
            int count_of_barge = Life.Board.CountBarge();
            int count_of_boat = Life.Board.CountBoat();
            int count_of_ship = Life.Board.CountShip();
            int count_of_long_barge = Life.Board.CountLongBarge();
            int count_of_long_boat = Life.Board.CountLongBoat();
            int count_of_long_ship = Life.Board.CountLongShip();
            Assert.IsTrue((count_of_hive == 5) &&
                          (count_of_loaf == 4) &&
                          (count_of_block == 2) &&
                          (count_of_box == 2) &&
                          (count_of_blinker == 0) &&
                          (count_of_pond == 0) &&
                          (count_of_snake == 0) &&
                          (count_of_carrier == 0) &&
                          (count_of_barge == 0) &&
                          (count_of_boat == 0) &&
                          (count_of_ship == 0) &&
                          (count_of_long_barge == 0) &&
                          (count_of_long_boat == 0) &&
                          (count_of_long_ship == 0) &&
                          (count_of_alive == 74));

        }


        [TestMethod]
        public void TestStatistic2()
        {
            Game_of_life Life = new Game_of_life(20, 20, 1, 0.5);
            Life.LoadBoard("Test3.txt");
            Life.Run(false);
            int count_of_alive = Life.Board.CountAliveCells();
            int count_of_hive = Life.Board.CountHive();
            int count_of_loaf = Life.Board.CountLoaf();
            int count_of_block = Life.Board.CountBlock();
            int count_of_box = Life.Board.CountBox();
            int count_of_blinker = Life.Board.CountBlinker();
            int count_of_pond = Life.Board.CountPond();
            int count_of_snake = Life.Board.CountSnake();
            int count_of_carrier = Life.Board.CountCarrier();
            int count_of_barge = Life.Board.CountBarge();
            int count_of_boat = Life.Board.CountBoat();
            int count_of_ship = Life.Board.CountShip();
            int count_of_long_barge = Life.Board.CountLongBarge();
            int count_of_long_boat = Life.Board.CountLongBoat();
            int count_of_long_ship = Life.Board.CountLongShip();
            Assert.IsTrue((count_of_hive == 0) &&
                          (count_of_loaf == 0) &&
                          (count_of_block == 0) &&
                          (count_of_box == 0) &&
                          (count_of_blinker == 3) &&
                          (count_of_pond == 3) &&
                          (count_of_snake == 4) &&
                          (count_of_carrier == 0) &&
                          (count_of_barge == 0) &&
                          (count_of_boat == 0) &&
                          (count_of_ship == 0) &&
                          (count_of_long_barge == 0) &&
                          (count_of_long_boat == 0) &&
                          (count_of_long_ship == 0) &&
                          (count_of_alive == 57));
        }
        [TestMethod]
        public void TestStatistic3()
        {
            Game_of_life Life = new Game_of_life(20, 20, 1, 0.5);
            Life.LoadBoard("Test4.txt");
            Life.Run(false);
            int count_of_alive = Life.Board.CountAliveCells();
            int count_of_hive = Life.Board.CountHive();
            int count_of_loaf = Life.Board.CountLoaf();
            int count_of_block = Life.Board.CountBlock();
            int count_of_box = Life.Board.CountBox();
            int count_of_blinker = Life.Board.CountBlinker();
            int count_of_pond = Life.Board.CountPond();
            int count_of_snake = Life.Board.CountSnake();
            int count_of_carrier = Life.Board.CountCarrier();
            int count_of_barge = Life.Board.CountBarge();
            int count_of_boat = Life.Board.CountBoat();
            int count_of_ship = Life.Board.CountShip();
            int count_of_long_barge = Life.Board.CountLongBarge();
            int count_of_long_boat = Life.Board.CountLongBoat();
            int count_of_long_ship = Life.Board.CountLongShip();
            Assert.IsTrue((count_of_hive == 0) &&
                          (count_of_loaf == 0) &&
                          (count_of_block == 0) &&
                          (count_of_box == 0) &&
                          (count_of_blinker == 0) &&
                          (count_of_pond == 0) &&
                          (count_of_snake == 0) &&
                          (count_of_carrier == 4) &&
                          (count_of_barge == 3) &&
                          (count_of_boat == 0) &&
                          (count_of_ship == 2) &&
                          (count_of_long_barge == 0) &&
                          (count_of_long_boat == 0) &&
                          (count_of_long_ship == 0) &&
                          (count_of_alive == 54));
        }

        [TestMethod]
        public void TestStatistic4()
        {
            Game_of_life Life = new Game_of_life(20, 20, 1, 0.5);
            Life.LoadBoard("Test5.txt");
            Life.Run(false);
            int count_of_alive = Life.Board.CountAliveCells();
            int count_of_hive = Life.Board.CountHive();
            int count_of_loaf = Life.Board.CountLoaf();
            int count_of_block = Life.Board.CountBlock();
            int count_of_box = Life.Board.CountBox();
            int count_of_blinker = Life.Board.CountBlinker();
            int count_of_pond = Life.Board.CountPond();
            int count_of_snake = Life.Board.CountSnake();
            int count_of_carrier = Life.Board.CountCarrier();
            int count_of_barge = Life.Board.CountBarge();
            int count_of_boat = Life.Board.CountBoat();
            int count_of_ship = Life.Board.CountShip();
            int count_of_long_barge = Life.Board.CountLongBarge();
            int count_of_long_boat = Life.Board.CountLongBoat();
            int count_of_long_ship = Life.Board.CountLongShip();
            Assert.IsTrue((count_of_hive == 0) &&
                          (count_of_loaf == 0) &&
                          (count_of_block == 0) &&
                          (count_of_box == 0) &&
                          (count_of_blinker == 0) &&
                          (count_of_pond == 0) &&
                          (count_of_snake == 0) &&
                          (count_of_carrier == 0) &&
                          (count_of_barge == 0) &&
                          (count_of_boat == 0) &&
                          (count_of_ship == 0) &&
                          (count_of_long_barge == 5) &&
                          (count_of_long_boat == 0) &&
                          (count_of_long_ship == 4) &&
                          (count_of_alive == 72));
        }

        [TestMethod]
        public void TestStatistic5()
        {
            Game_of_life Life = new Game_of_life(20, 20, 1, 0.5);
            Life.LoadBoard("Test6.txt");
            Life.Run(false);
            int count_of_alive = Life.Board.CountAliveCells();
            int count_of_hive = Life.Board.CountHive();
            int count_of_loaf = Life.Board.CountLoaf();
            int count_of_block = Life.Board.CountBlock();
            int count_of_box = Life.Board.CountBox();
            int count_of_blinker = Life.Board.CountBlinker();
            int count_of_pond = Life.Board.CountPond();
            int count_of_snake = Life.Board.CountSnake();
            int count_of_carrier = Life.Board.CountCarrier();
            int count_of_barge = Life.Board.CountBarge();
            int count_of_boat = Life.Board.CountBoat();
            int count_of_ship = Life.Board.CountShip();
            int count_of_long_barge = Life.Board.CountLongBarge();
            int count_of_long_boat = Life.Board.CountLongBoat();
            int count_of_long_ship = Life.Board.CountLongShip();
            Assert.IsTrue((count_of_hive == 0) &&
                          (count_of_loaf == 0) &&
                          (count_of_block == 0) &&
                          (count_of_box == 0) &&
                          (count_of_blinker == 0) &&
                          (count_of_pond == 0) &&
                          (count_of_snake == 0) &&
                          (count_of_carrier == 0) &&
                          (count_of_barge == 0) &&
                          (count_of_boat == 8) &&
                          (count_of_ship == 0) &&
                          (count_of_long_barge == 0) &&
                          (count_of_long_boat == 4) &&
                          (count_of_long_ship == 0) &&
                          (count_of_alive == 68));
        }

        [TestMethod]
        public void TestSymetry1()
        {
            Game_of_life Life = new Game_of_life(6, 6, 1, 0.5);
            Life.LoadBoard("Test7.txt");
            Life.Run(false);
            double sym_ver = Life.Board.SymmetryVertical();
            double sym_hor = Life.Board.SymmetryHorizontal();
            double sym_cen = Life.Board.SymmetryCentral();
            Assert.IsTrue((sym_ver == 1) &&
                          (sym_hor == 5.0 / 9.0) &&
                          (sym_cen == 5.0 / 9.0));
        }

        [TestMethod]
        public void TestSymetry2()
        {
            Game_of_life Life = new Game_of_life(6, 6, 1, 0.5);
            Life.LoadBoard("Test8.txt");
            Life.Run(false);
            double sym_ver = Life.Board.SymmetryVertical();
            double sym_hor = Life.Board.SymmetryHorizontal();
            double sym_cen = Life.Board.SymmetryCentral();
            Assert.IsTrue((sym_ver == 5.0 / 9.0) &&
                          (sym_hor == 1) &&
                          (sym_cen == 5.0 / 9.0));
        }

        [TestMethod]
        public void TestSymetry3()
        {
            Game_of_life Life = new Game_of_life(6, 6, 1, 0.5);
            Life.LoadBoard("Test9.txt");
            Life.Run(false);
            double sym_ver = Life.Board.SymmetryVertical();
            double sym_hor = Life.Board.SymmetryHorizontal();
            double sym_cen = Life.Board.SymmetryCentral();
            Assert.IsTrue((sym_ver == 2.0 / 3.0) &&
                          (sym_hor == 2.0 / 3.0) &&
                          (sym_cen == 1));
        }
    }
}
