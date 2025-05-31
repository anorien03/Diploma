// See https://aka.ms/new-console-template for more information
using Diploma;
using Diploma.Models;
using Diploma.Packers;

//Console.WriteLine("Hello, World!");

//var sh = new ShipHold(100, 100, 120, 200);
//List<Container> c = new List<Container>() {
//new Container(1, 13, 17, 14, 1),
//new Container(2, 13, 47, 24, 2),
//new Container(3, 13, 27, 34, 3),
//new Container(4, 13, 27, 24, 2),
//new Container(5, 23, 17, 34, 3),
//new Container(6, 23, 37, 14, 1),
//new Container(7, 23, 37, 24, 2),
//new Container(8, 23, 27, 14, 1),
//new Container(9, 33, 77, 14, 1),
//new Container(10, 33, 17, 34, 3),
//new Container(11, 33, 27, 34, 3),
//new Container(12, 33, 27, 24, 2),
//new Container(13, 13, 17, 14, 1),
//new Container(14, 13, 17, 24, 2),
//new Container(15, 13, 27, 14, 1),
//new Container(16, 13, 87, 24, 2),
//new Container(17, 23, 17, 34, 3),
//new Container(18, 23, 37, 14, 1),
//new Container(19, 23, 37, 24, 2),
//new Container(20, 23, 27, 14, 1),
//new Container(21, 33, 27, 14, 1),
//new Container(22, 33, 17, 34, 3),
//new Container(23, 33, 27, 34, 3),
//new Container(24, 33, 17, 24, 2),
//new Container(25, 43, 27, 14, 1),
//new Container(26, 13, 27, 24, 2),
//new Container(27, 23, 57, 34, 3),
//new Container(28, 23, 37, 14, 1),
//new Container(29, 23, 37, 24, 2),
//new Container(30, 23, 27, 14, 1),
//new Container(31, 33, 27, 14, 1),
//new Container(32, 33, 17, 34, 3),
//new Container(33, 33, 27, 34, 3),
//new Container(34, 33, 17, 24, 2),
//new Container(35, 13, 27, 14, 1),
//new Container(36, 13, 27, 24, 2),
//new Container(37, 23, 17, 34, 3),
//new Container(38, 23, 37, 14, 1),
//new Container(39, 23, 37, 24, 2),
//new Container(40, 23, 27, 14, 1),
//new Container(41, 33, 27, 14, 1),
//new Container(42, 33, 17, 34, 3),
//new Container(43, 33, 27, 34, 3),
//new Container(44, 33, 17, 24, 2),
//new Container(45, 13, 27, 14, 1),
//new Container(46, 13, 27, 24, 2),
//new Container(47, 23, 17, 34, 3),
//new Container(48, 23, 37, 14, 1),
//new Container(49, 23, 37, 24, 2),
//new Container(50, 23, 27, 14, 1),
//new Container(51, 33, 27, 14, 1),
//new Container(52, 33, 17, 34, 3),
//new Container(53, 33, 27, 34, 3),
//new Container(54, 33, 17, 24, 2),
//new Container(55, 13, 27, 14, 1),
//new Container(56, 13, 27, 24, 2),
//new Container(57, 23, 17, 34, 3),
//new Container(58, 23, 37, 14, 1),
//new Container(59, 23, 37, 24, 2),
//new Container(60, 23, 27, 14, 1),
//new Container(61, 33, 27, 14, 1),
//new Container(62, 33, 17, 34, 3),
//new Container(63, 33, 27, 34, 3),
//new Container(64, 33, 17, 24, 2),
//new Container(65, 13, 27, 14, 1),
//new Container(66, 13, 27, 24, 2),
//new Container(67, 23, 17, 34, 3),
//new Container(68, 23, 37, 14, 1),
//new Container(69, 23, 37, 24, 2),
//new Container(70, 23, 27, 14, 1),
//new Container(71, 33, 27, 14, 1),
//new Container(72, 33, 17, 34, 3),
//new Container(73, 33, 27, 34, 3),
//new Container(74, 33, 17, 24, 2),
//new Container(75, 13, 27, 14, 1),
//new Container(76, 13, 27, 24, 2),
//new Container(77, 23, 17, 34, 3),
//new Container(78, 23, 37, 14, 1),
//new Container(79, 23, 37, 24, 2),
//new Container(80, 23, 27, 14, 1),
//new Container(81, 33, 27, 14, 1),
//new Container(82, 33, 17, 34, 3),
//new Container(83, 33, 27, 34, 3),
//new Container(84, 33, 17, 24, 2),
//new Container(85, 13, 27, 14, 1),
//new Container(86, 13, 27, 24, 2),
//new Container(87, 23, 17, 34, 3),
//new Container(88, 23, 37, 14, 1),
//new Container(89, 23, 37, 24, 2),
//new Container(90, 23, 27, 14, 1),
//new Container(91, 33, 27, 14, 1),
//new Container(92, 33, 17, 34, 3),
//new Container(93, 33, 27, 34, 3),
//new Container(94, 33, 17, 24, 2),
//new Container(95, 13, 27, 14, 1),
//new Container(96, 13, 27, 24, 2),
//new Container(97, 23, 17, 34, 3),
//new Container(98, 23, 37, 14, 1),
//new Container(99, 23, 37, 24, 2),
//new Container(100, 23, 27, 14, 1),
    //new Container(56, 1, 2, 2, 3),
    //new Container(57, 2, 1, 3, 1),
    //new Container(58, 2, 3, 1, 1),
    //new Container(59, 2, 3, 2, 1),
    //new Container(60, 2, 2, 1, 1),
    //new Container(61, 3, 2, 1, 1),
    //new Container(62, 3, 1, 3, 2),
    //new Container(63, 3, 2, 3, 1),
//};

//for (int z = 1; z < 101; z++) { Console.Write($"{z}, "); }


List<int> chr = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };
//List<(int id, int x0, int y0, int z0, int x1, int y1, int z1)> coor = new();

//List<EMS> ems = new List<EMS>() { new EMS(0, 0, 0, sh.Length, sh.Width, sh.Height) };

//int i = 0;
//int weight = 0;

//while (i < chr.Count)
//{
//    var con = c.First(cont => cont.Id == chr[i]);
//    var used_ems = new EMS(0, 0, 0, 0, 0, 0);

//    if (weight + con.Weight > sh.LiftCapacity)
//    {
//        Console.WriteLine($"oops, doesn't fit weight. Box {con.Id}");
//        i++;
//        continue;
//    }


//    foreach (var e in ems)
//    {
//        if (e.fits(con))
//        {
//            used_ems = e;
//            break;
//        }
//    }

//    if (used_ems.X1 == 0)
//    {
//        Console.WriteLine($"oops, doesn't fit. Box {con}, ems {ems}");
//        i++;
//        continue;
//    }


//    var packed_box = new EMS(used_ems.X0, used_ems.Y0, used_ems.Z0, used_ems.X0 + con.Length, used_ems.Y0 + con.Width, used_ems.Z0 + con.Height);
//    coor.Add((con.Id, packed_box.X0, packed_box.Y0, packed_box.Z0, packed_box.X1, packed_box.Y1, packed_box.Z1));
//    weight += con.Weight;


//    foreach (var e in ems.ToList())
//    {
//        if (e.overlaps(packed_box) | e.covers(packed_box))
//        {
//            ems.Remove(e);

//            var new_emss = new List<EMS>()
//            {
//                new EMS(e.X0, e.Y0, e.Z0, packed_box.X0, e.Y1, e.Z1),
//                new EMS(packed_box.X1, e.Y0, e.Z0, e.X1, e.Y1, e.Z1),
//                new EMS(e.X0, e.Y0, e.Z0, e.X1, packed_box.Y0, e.Z1),
//                new EMS(e.X0, packed_box.Y1, e.Z0, e.X1, e.Y1, e.Z1),
//                new EMS(e.X0, e.Y0, e.Z0, e.X1, e.Y1, packed_box.Z0),
//                new EMS(e.X0, e.Y0, packed_box.Z1, e.X1, e.Y1, e.Z1),
//            };

//            foreach (var new_ems in new_emss)
//            {
//                var valid = new_ems.isValid();

//                int ind = ems.Count - 1;

//                while (ind >= 0 & valid)
//                {
//                    if (ems[ind].covers(new_ems)) { valid = false; }
//                    if (new_ems.covers(ems[ind])) { ems.RemoveAt(ind); }
//                    ind -= 1;
//                }

//                if (valid) { ems.Add(new_ems); }
//            }

//        }
//    }

//    i++;

//}


//var packer = new PackerEMS();
//var res = packer.PackContainers(sh, c, chr);
//var coor = res.PackedContainers;

////Console.WriteLine(weight);
//foreach (var a in coor) { Console.WriteLine($"({a.Container.Id})),"); }
//foreach (var a in coor) { Console.WriteLine($"(({a.X0}, {a.Y0}, {a.Z0}), ({a.X1 - a.X0}, {a.Y1 - a.Y0}, {a.Z1 - a.Z0})),"); }

//foreach (var a in res.UnpackedWeightContainersId) { Console.WriteLine($"wei ({a})),"); }
//foreach (var a in res.UnpackedSpaceContainersId) { Console.WriteLine($"sp ({a})),"); }

//Console.WriteLine(res.TotalVolume);
//Console.WriteLine(res.TotalWeight);

//for (int i = 0; i < coor.Count; i++)
//{
//    for (int j = i + 1; j < coor.Count; j++)
//    {
//        if ((coor[i].X0 >= coor[j].X1 | coor[i].X1 <= coor[j].X0 | coor[i].Y0 >= coor[j].Y1 | coor[i].Y1 <= coor[j].Y0 | coor[i].Z0 >= coor[j].Z1 | coor[i].Z1 <= coor[j].Z0) == false)
//        {
//            Console.WriteLine($"oops overlaps {coor[i].Container.Id}, {coor[j].Container.Id}");
//        }
//    }
//}


//foreach (var con in c)
//{
//    Console.WriteLine($"{con.Id}, {con.Length}, {con.Width}, {con.Height}, {con.Weight}");
//}


//var genetic = new GeneticAlgorithm(packer, 200, 200, 30, 2, 5);
//var fitnessList = new List<int>();
//var res = genetic.Run(sh, c, out fitnessList);

//var coor = res.PackedContainers;

////Console.WriteLine(weight);
//foreach (var a in coor) { Console.WriteLine($"({a.Container.Id})),"); }
//foreach (var a in coor) { Console.WriteLine($"(({a.X0}, {a.Y0}, {a.Z0}), ({a.X1 - a.X0}, {a.Y1 - a.Y0}, {a.Z1 - a.Z0})),"); }

//foreach (var a in res.UnpackedWeightContainersId) { Console.WriteLine($"wei ({a})),"); }
//foreach (var a in res.UnpackedSpaceContainersId) { Console.WriteLine($"sp ({a})),"); }

//Console.WriteLine(res.TotalVolume);
//Console.WriteLine(res.TotalWeight);

//for (int i = 0; i < coor.Count; i++)
//{
//    for (int j = i + 1; j < coor.Count; j++)
//    {
//        if ((coor[i].X0 >= coor[j].X1 | coor[i].X1 <= coor[j].X0 | coor[i].Y0 >= coor[j].Y1 | coor[i].Y1 <= coor[j].Y0 | coor[i].Z0 >= coor[j].Z1 | coor[i].Z1 <= coor[j].Z0) == false)
//        {
//            Console.WriteLine($"oops overlaps {coor[i].Container.Id}, {coor[j].Container.Id}");
//        }
//    }
//}







var sh = new ShipHold(250, 200, 177, 2200);
List<Container> cont = new List<Container>() {
// Оригинальные контейнеры с исправленными ID
new Container(1, 30, 24, 26, 6),   // 10-foot
new Container(2, 30, 24, 29, 7),
new Container(3, 30, 25, 26, 9),
new Container(4, 30, 25, 29, 10),
new Container(5, 61, 24, 26, 19),  // 20-foot
new Container(6, 61, 24, 29, 11),
new Container(7, 61, 25, 26, 23),
new Container(8, 61, 25, 29, 25),
new Container(9, 92, 24, 26, 19),  // 30-foot
new Container(10, 92, 24, 29, 14),
new Container(11, 92, 25, 26, 16),
new Container(12, 92, 25, 29, 15),
new Container(13, 122, 24, 26, 12), // 40-foot
new Container(14, 122, 24, 29, 11),
new Container(15, 122, 25, 26, 16),
new Container(16, 122, 25, 29, 28),
new Container(17, 138, 24, 26, 18), // 45-foot
new Container(18, 138, 24, 29, 21),
new Container(19, 138, 25, 26, 24),
new Container(20, 138, 25, 29, 28),
new Container(21, 162, 26, 29, 30), // 53-foot
new Container(22, 162, 26, 31, 36),
new Container(23, 19, 25, 25, 3),   // 6-foot
new Container(24, 19, 25, 29, 4),
new Container(25, 22, 25, 25, 4),   // 7-foot
new Container(26, 22, 25, 29, 5),
new Container(27, 25, 25, 25, 4),   // 8-foot
new Container(28, 25, 25, 26, 6),
new Container(29, 28, 25, 25, 6),   // 9-foot
new Container(30, 28, 26, 25, 8),
new Container(31, 49, 25, 25, 10),  // 16-foot
new Container(32, 49, 25, 29, 13),
new Container(33, 74, 25, 25, 18),  // 24-foot
new Container(34, 74, 25, 26, 19),
new Container(35, 147, 25, 25, 28), // 48-foot
new Container(36, 147, 25, 29, 32),

// Добавленные контейнеры (37-200) - вариации с изменением одного параметра
// Группа 10-foot (основа: ID 1-4)
new Container(37, 33, 24, 26, 5),   // +3L -16.7%W
new Container(38, 30, 27, 26, 7),   // +3W
new Container(39, 30, 24, 31, 6),   // +5H
new Container(40, 27, 24, 26, 7),   // -3L +16.7%W
new Container(41, 30, 21, 26, 8),   // -3W +14.3%W
new Container(42, 30, 24, 23, 9),   // -3H
new Container(43, 35, 24, 26, 6),   // +5L
new Container(44, 30, 20, 29, 8),   // -4W +14.3%W
new Container(45, 30, 25, 33, 8),   // +7H -11.1%W
new Container(46, 25, 25, 29, 11),  // -5L +10%W

// Группа 20-foot (основа: ID 5-8)
new Container(47, 66, 24, 26, 17),  // +5L -10.5%W
new Container(48, 61, 27, 29, 9),   // +3W -18.2%W
new Container(49, 61, 25, 31, 22),  // +5H -4.3%W
new Container(50, 56, 24, 26, 21), // -5L +10.5%W
new Container(51, 61, 21, 29, 13), // -3W +18.2%W
new Container(52, 61, 25, 21, 24),  // -5H +4.3%W
new Container(53, 70, 24, 26, 18),  // +9L -5.3%W
new Container(54, 61, 28, 29, 10),  // +4W -9.1%W
new Container(55, 61, 25, 34, 21),  // +8H -8.7%W
new Container(56, 55, 25, 29, 27),  // -6L +8%W

// Группа 30-foot (основа: ID 9-12)
new Container(57, 97, 24, 26, 18),  // +5L -5.3%W
new Container(58, 92, 27, 29, 13),  // +3W -7.1%W
new Container(59, 92, 25, 31, 15),  // +5H -6.3%W
new Container(60, 87, 24, 26, 20),  // -5L +5.3%W
new Container(61, 92, 21, 29, 16),  // -3W +14.3%W
new Container(62, 92, 25, 21, 17),  // -5H +6.3%W
new Container(63, 100, 24, 26, 18), // +8L -5.3%W
new Container(64, 92, 20, 29, 15),  // -4W +7.1%W
new Container(65, 92, 25, 35, 14), // +9H
new Container(66, 85, 25, 29, 18),  // -7L +20%W

// Группа 40-foot (основа: ID 13-16)
new Container(67, 127, 24, 26, 11), // +5L -8.3%W
new Container(68, 122, 27, 29, 10), // +3W -9.1%W
new Container(69, 122, 25, 31, 15), // +5H -6.3%W
new Container(70, 117, 24, 26, 13), // -5L +8.3%W
new Container(71, 122, 21, 29, 13), // -3W +18.2%W
new Container(72, 122, 25, 21, 17), // -5H +6.3%W
new Container(73, 130, 24, 26, 11), // +8L -8.3%W
new Container(74, 122, 20, 29, 12), // -4W +9.1%W
new Container(75, 122, 25, 35, 14), // +9H -12.5%W
new Container(76, 115, 25, 29, 19), // -7L +18.8%W

// Группа 45-foot (основа: ID 17-20)
new Container(77, 143, 24, 26, 16), // +5L -11.1%W
new Container(78, 138, 27, 29, 19), // +3W -9.5%W
new Container(79, 138, 25, 31, 23), // +5H -4.2%W
new Container(80, 133, 24, 26, 20), // -5L +11.1%W
new Container(81, 138, 21, 29, 25), // -3W +19%W
new Container(82, 138, 25, 21, 26), // -5H +8.3%W
new Container(83, 145, 24, 26, 17), // +7L -5.6%W
new Container(84, 138, 20, 29, 22), // -4W +4.8%W
new Container(85, 138, 25, 35, 21), // +9H -12.5%W
new Container(86, 130, 25, 29, 30), // -8L +25%W

// Группа 53-foot (основа: ID 21-22)
new Container(87, 167, 26, 29, 28), // +5L -6.7%W
new Container(88, 162, 29, 31, 33), // +3W -8.3%W
new Container(89, 162, 26, 36, 29), // +7H -3.3%W
new Container(90, 157, 26, 29, 32), // -5L +6.7%W
new Container(91, 162, 23, 31, 39), // -3W +8.3%W
new Container(92, 162, 26, 25, 33), // -6H +10%W
new Container(93, 170, 26, 29, 27), // +8L -10%W
new Container(94, 162, 20, 31, 37), // -6W +2.8%W
new Container(95, 162, 26, 38, 28), // +9H -6.7%W
new Container(96, 155, 26, 29, 34), // -7L +13.3%W

// Группа малых контейнеров (6-9 foot, основа: ID 23-30)
new Container(97, 22, 25, 25, 3),   // +3L
new Container(98, 19, 28, 29, 3),   // +3W -25%W
new Container(99, 19, 25, 32, 4),   // +7H
new Container(100, 16, 25, 25, 5),  // -3L +66.7%W
// 16-foot контейнеры (основа: ID 31-32)
new Container(101, 52, 25, 25, 9),   // +3L -10%W
new Container(102, 49, 28, 29, 12),  // +3W -7.7%W
new Container(103, 49, 25, 32, 11),  // +7H -15.4%W
new Container(104, 46, 25, 25, 12),  // -3L +20%W
new Container(105, 49, 22, 29, 14),  // -3W +7.7%W
new Container(106, 49, 25, 22, 15),  // -3H +15.4%W
new Container(107, 54, 25, 25, 8),   // +5L -20%W
new Container(108, 49, 20, 29, 15),  // -5W +15.4%W
new Container(109, 49, 25, 35, 10),  // +10H -23.1%W
new Container(110, 44, 25, 29, 16),  // -5L +23.1%W

// 24-foot контейнеры (основа: ID 33-34)
new Container(111, 77, 25, 25, 17),  // +3L -5.6%W
new Container(112, 74, 28, 26, 18),  // +3W -5.3%W
new Container(113, 74, 25, 31, 17),  // +5H -5.6%W
new Container(114, 71, 25, 25, 19),  // -3L +5.6%W
new Container(115, 74, 22, 26, 20),  // -3W +5.3%W
new Container(116, 74, 25, 21, 20),  // -5H +5.6%W
new Container(117, 80, 25, 25, 16),  // +6L -11.1%W
new Container(118, 74, 20, 26, 21),  // -5W +10.5%W
new Container(119, 74, 25, 35, 15),  // +10H -16.7%W
new Container(120, 68, 25, 26, 22),  // -6L +15.8%W

// 48-foot контейнеры (основа: ID 35-36)
new Container(121, 150, 25, 25, 26), // +3L -7.1%W
new Container(122, 147, 28, 29, 30), // +3W -6.3%W
new Container(123, 147, 25, 32, 27), // +7H -3.6%W
new Container(124, 144, 25, 25, 30), // -3L +7.1%W
new Container(125, 147, 22, 29, 33), // -3W +3.1%W
new Container(126, 147, 25, 22, 30), // -3H +7.1%W
new Container(127, 155, 25, 25, 25), // +8L -10.7%W
new Container(128, 147, 20, 29, 35), // -5W +9.4%W
new Container(129, 147, 25, 38, 26), // +10H -7.1%W
new Container(130, 140, 25, 29, 34), // -7L +6.3%W

// Дополнительные 10-foot вариации
new Container(131, 36, 24, 26, 5),  // +6L -16.7%W
new Container(132, 30, 30, 29, 6),   // +6W -14.3%W
new Container(133, 30, 24, 34, 7),   // +8H
new Container(134, 24, 24, 26, 8),   // -6L +33.3%W
new Container(135, 30, 18, 29, 9),   // -6W +28.6%W

// Дополнительные 20-foot вариации
new Container(136, 70, 24, 26, 17),  // +9L -10.5%W
new Container(137, 61, 30, 29, 9),   // +6W -18.2%W
new Container(138, 61, 24, 35, 20),  // +9H -13%W
new Container(139, 55, 24, 26, 22),  // -6L +15.8%W
new Container(140, 61, 18, 29, 13),  // -6W +18.2%W

// Дополнительные 30-foot вариации
new Container(141, 100, 24, 26, 18), // +8L -5.3%W
new Container(142, 92, 30, 29, 12),  // +6W -14.3%W
new Container(143, 92, 24, 35, 15),  // +9H -6.3%W
new Container(144, 85, 24, 26, 20),  // -7L +5.3%W
new Container(145, 92, 18, 29, 16),  // -6W +14.3%W

// Дополнительные 40-foot вариации
new Container(146, 130, 24, 26, 11), // +8L -8.3%W
new Container(147, 122, 30, 29, 9),  // +6W -18.2%W
new Container(148, 122, 24, 35, 14), // +9H -12.5%W
new Container(149, 115, 24, 26, 13), // -7L +8.3%W
new Container(150, 122, 18, 29, 13), // -6W +18.2%W

// Дополнительные 45-foot вариации
new Container(151, 145, 24, 26, 17), // +7L -5.6%W
new Container(152, 138, 30, 29, 18), // +6W -14.3%W
new Container(153, 138, 24, 35, 21), // +9H -12.5%W
new Container(154, 130, 24, 26, 20), // -8L +11.1%W
new Container(155, 138, 18, 29, 25), // -6W +19%W

// Дополнительные 53-foot вариации
new Container(156, 170, 26, 29, 27), // +8L -10%W
new Container(157, 162, 32, 31, 33), // +6W -8.3%W
new Container(158, 162, 26, 38, 29), // +9H -3.3%W
new Container(159, 155, 26, 29, 32), // -7L +6.7%W
new Container(160, 162, 20, 31, 37), // -6W +2.8%W

// Дополнительные 6-foot вариации
new Container(161, 22, 25, 25, 3),   // +3L
new Container(162, 19, 28, 29, 3),   // +3W -25%W
new Container(163, 19, 25, 32, 4),   // +7H
new Container(164, 16, 25, 25, 5),   // -3L +66.7%W
new Container(165, 19, 22, 29, 4),   // -3W

// Дополнительные 7-foot вариации
new Container(166, 25, 25, 25, 4),   // +3L
new Container(167, 22, 28, 29, 4),   // +3W -20%W
new Container(168, 22, 25, 32, 5),   // +7H
new Container(169, 19, 25, 25, 6),   // -3L +50%W
new Container(170, 22, 22, 29, 6),   // -3W +20%W

// Дополнительные 8-foot вариации
new Container(171, 28, 25, 25, 4),   // +3L
new Container(172, 25, 28, 26, 5),   // +3W -16.7%W
new Container(173, 25, 25, 32, 6),   // +7H
new Container(174, 22, 25, 25, 7),   // -3L +16.7%W
new Container(175, 25, 22, 26, 7),   // -3W +16.7%W

// Дополнительные 9-foot вариации
new Container(176, 31, 25, 25, 6),   // +3L
new Container(177, 28, 28, 25, 5),   // +3W -16.7%W
new Container(178, 28, 26, 32, 7),   // +7H -12.5%W
new Container(179, 25, 25, 25, 8),   // -3L +33.3%W
new Container(180, 28, 22, 25, 7),   // -3W +16.7%W

// Специальные смешанные вариации
new Container(181, 40, 22, 28, 8),   // комбинированные изменения
new Container(182, 55, 27, 24, 15),
new Container(183, 88, 23, 30, 17),
new Container(184, 118, 27, 25, 14),
new Container(185, 140, 23, 32, 26),
new Container(186, 160, 28, 30, 31),
new Container(187, 20, 27, 27, 5),
new Container(188, 45, 23, 30, 12),
new Container(189, 75, 27, 23, 19),
new Container(190, 110, 23, 32, 15),

// Экстремальные вариации (±10 единиц)
new Container(191, 20, 24, 26, 7),   // -10L +16.7%W
new Container(192, 30, 34, 29, 6),   // +10W -14.3%W
new Container(193, 30, 24, 36, 5),   // +10H -16.7%W
new Container(194, 71, 24, 26, 21),  // +10L +10.5%W
new Container(195, 61, 34, 29, 9),   // +10W -18.2%W
new Container(196, 61, 24, 36, 18),  // +10H -21.7%W
new Container(197, 132, 24, 26, 14), // +10L +16.7%W
new Container(198, 122, 34, 29, 9),  // +10W -18.2%W
new Container(199, 122, 24, 36, 13), // +10H +8.3%W
new Container(200, 152, 26, 29, 33)  // -10L +10%W
};


var fitnessList = new List<int>();

var packer = new PackerEMS();
//var res = packer.PackContainers(sh,cont, new List<int>() { 4, 8, 3, 5, 6, 7, 2, 1, 9 });
var genetic = new GeneticAlgorithm(packer, 400, 800, 30, 2, 5);
var res = genetic.Run(sh, cont, out fitnessList);

Console.WriteLine(res.TotalVolume * 100 / sh.Volume);
Console.WriteLine(sh.Volume - res.TotalVolume);
Console.WriteLine(res.UnpackedSpaceContainersId.Count);
Console.WriteLine(res.UnpackedWeightContainersId.Count);
Console.WriteLine(res.TotalWeight);
Console.WriteLine();
foreach (var a in fitnessList) { Console.Write($"{a}, "); }

Console.WriteLine();

Console.WriteLine();
//foreach (var a in fitnessList) { Console.Write($"65260, "); }

var total = 0;
foreach (var c in cont) { total += c.Volume; }
//int n = 9;

Console.WriteLine(total);

foreach (var a in res.PackedContainers) { Console.WriteLine($"(({a.X0}, {a.Y0}, {a.Z0}), ({a.X1 - a.X0}, {a.Y1 - a.Y0}, {a.Z1 - a.Z0})),"); }
foreach (var a in res.PackedContainers) { Console.WriteLine($"({a.Container.Id})),"); }


//var chrom = new List<List<int>>();
//for (int i1 = 1; i1 <= n; i1++)
//{
//    for (int i2 = 1; i2 <= n; i2++)
//    {
//        if (i2 == i1) { continue; }
//        for (int i3 = 1; i3 <= n; i3++)
//        {
//            if (i3 == i1 | i3 == i2) { continue; }
//            for (int i4 = 1; i4 <= n; i4++)
//            {
//                if (i4 == i1 | i4 == i2 | i4 == i3) { continue; }
//                for (int i5 = 1; i5 <= n; i5++)
//                {
//                    if (i5 == i1 | i5 == i2 | i5 == i3 | i5 == i4) { continue; }
//                    for (int i6 = 1; i6 <= n; i6++)
//                    {
//                        if (i6 == i1 | i6 == i2 | i6 == i3 | i6 == i4 | i6 == i5) { continue; }
//                        for (int i7 = 1; i7 <= n; i7++)
//                        {
//                            if (i7 == i1 | i7 == i2 | i7 == i3 | i7 == i4 | i7 == i5 | i7 == i6) { continue; }
//                            for (int i8 = 1; i8 <= n; i8++)
//                            {
//                                if (i8 == i1 | i8 == i2 | i8 == i3 | i8 == i4 | i8 == i5 | i8 == i6 | i8 == i7) { continue; }
//                                for (int i9 = 1; i9 <= n; i9++)
//                                {
//                                    if (i9 == i1 | i9 == i2 | i9 == i3 | i9 == i4 | i9 == i5 | i9 == i6 | i9 == i7 | i9 == i8) { continue; }
//                                    chrom.Add(new List<int>() { i1, i2, i3, i4, i5, i6, i7, i8, i9});
//                                    //    for (int i10 = 1; i10 <= n; i10++)
//                                    //    {
//                                    //        if (i10 == i1 | i10 == i2 | i10 == i3 | i10 == i4 | i10 == i5 | i10 == i6 | i10 == i7 | i10 == i8 | i10 == i9) { continue; }
//                                    //        for (int i11 = 1; i11 <= n; i11++)
//                                    //        {
//                                    //            if (i11 == i1 | i11 == i2 | i11 == i3 | i11 == i4 | i11 == i5 | i11 == i6 | i11 == i7 | i11 == i8 | i11 == i9 | i11 == i10) { continue; }
//                                    //            chrom.Add(new List<int>() { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11 });
//                                    //            //for (int i12 = 1; i12 <= n; i12++)
//                                    //            //{
//                                    //            //    if (i12 == i1 | i12 == i2 | i12 == i3 | i12 == i4 | i12 == i5 | i12 == i6 | i12 == i7 | i12 == i8 | i12 == i9 | i12 == i10 | i12 == i11) { continue; }
//                                    //            //    for (int i13 = 1; i13 <= n; i13++)
//                                    //            //    {
//                                    //            //        if (i13 == i1 | i13 == i2 | i13 == i3 | i13 == i4 | i13 == i5 | i13 == i6 | i13 == i7 | i13 == i8 | i13 == i9 | i13 == i10 | i13 == i11 | i13 == i12) { continue; }
//                                    //            //        for (int i14 = 1; i14 <= n; i14++)
//                                    //            //        {
//                                    //            //            if (i14 == i1 | i14 == i2 | i14 == i3 | i14 == i4 | i14 == i5 | i14 == i6 | i14 == i7 | i14 == i8 | i14 == i9 | i14 == i10 | i14 == i11 | i14 == i12 | i14 == i13) { continue; }
//                                    //            //            for (int i15 = 1; i15 <= n; i15++)
//                                    //            //            {
//                                    //            //                if (i15 == i1 | i15 == i2 | i15 == i3 | i15 == i4 | i15 == i5 | i15 == i6 | i15 == i7 | i15 == i8 | i15 == i9 | i15 == i10 | i15 == i11 | i15 == i12 | i15 == i13 | i15 == i14) { continue; }
//                                    //            //                chrom.Add(new List<int>() { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15 });
//                                    //            //            }
//                                    //            //        }
//                                    //            //    }
//                                    //            //}
//                                    //        }
//                                    //    }
//                                    }
//                                }
//                        }
//                    }
//                }
//            }
//        }
//    }
//}



//var packer1 = new PackerEMS();
//var max = 0;

//for (int x = 0; x < 16; x++)
//{
//    foreach (var c in chrom)
//    {
//        //foreach (var a in c) { Console.Write($"{a} "); }
//        var res1 = packer1.PackContainers(sh, cont, c);
//        //Console.Write($"{res.TotalVolume} ");
//        //Console.WriteLine($"{res.PackedContainers.Count} ");

//        if (res1.TotalVolume > max)
//        {
//            max = res1.TotalVolume;
//            foreach (var a in c) { Console.Write($"{a} "); }
//            Console.WriteLine($"{res1.TotalVolume}");
//        }
//    }
//}

//Console.WriteLine(max);