// See https://aka.ms/new-console-template for more information
using Diploma;
using Diploma.Models;
using Diploma.Packers;

Console.WriteLine("Hello, World!");

var sh = new ShipHold(7, 7, 7, 100);
List<Container> c = new List<Container>() {
    new Container(1, 1, 1, 1, 2),
    new Container(2, 1, 1, 2, 1),
    new Container(3, 1, 2, 1, 1),
    new Container(4, 1, 2, 2, 3),
    new Container(5, 2, 1, 3, 1),
    new Container(6, 2, 3, 1, 1),
    new Container(7, 2, 3, 2, 1),
    new Container(8, 2, 2, 1, 1),
    new Container(9, 3, 2, 1, 1),
    new Container(10, 3, 1, 3, 2),
    new Container(11, 3, 2, 3, 1),
    new Container(12, 3, 1, 2, 1),
    new Container(13, 1, 1, 1, 2),
    new Container(14, 1, 1, 2, 1),
    new Container(15, 1, 2, 1, 1),
    new Container(16, 1, 2, 2, 3),
    new Container(17, 2, 1, 3, 1),
    new Container(18, 2, 3, 1, 1),
    new Container(19, 2, 3, 2, 1),
    new Container(20, 2, 2, 1, 1),
    new Container(21, 3, 2, 1, 1),
    new Container(22, 3, 1, 3, 2),
    new Container(23, 3, 2, 3, 1),
    new Container(24, 3, 1, 2, 1),
    new Container(25, 1, 2, 1, 1),
    new Container(26, 1, 2, 2, 3),
    new Container(27, 2, 1, 3, 1),
    new Container(28, 2, 3, 1, 1),
    new Container(29, 2, 3, 2, 1),
    new Container(30, 2, 2, 1, 1),
    new Container(31, 3, 2, 1, 1),
    new Container(32, 3, 1, 3, 2),
    new Container(33, 3, 2, 3, 1),
    new Container(34, 3, 1, 2, 1),
    new Container(35, 1, 2, 1, 1),
    new Container(36, 1, 2, 2, 3),
    new Container(37, 2, 1, 3, 1),
    new Container(38, 2, 3, 1, 1),
    new Container(39, 2, 3, 2, 1),
    new Container(40, 2, 2, 1, 1),
    new Container(41, 3, 2, 1, 1),
    new Container(42, 3, 1, 3, 2),
    new Container(43, 3, 2, 3, 1),
    new Container(44, 3, 1, 2, 1),
    new Container(45, 1, 2, 1, 1),
    new Container(46, 1, 2, 2, 3),
    new Container(47, 2, 1, 3, 1),
    new Container(48, 2, 3, 1, 1),
    new Container(49, 2, 3, 2, 1),
    new Container(50, 2, 2, 1, 1),
    new Container(51, 3, 2, 1, 1),
    new Container(52, 3, 1, 3, 2),
    new Container(53, 3, 2, 3, 1),
    new Container(54, 3, 1, 2, 1),
    new Container(55, 1, 2, 1, 1),
    //new Container(56, 1, 2, 2, 3),
    //new Container(57, 2, 1, 3, 1),
    //new Container(58, 2, 3, 1, 1),
    //new Container(59, 2, 3, 2, 1),
    //new Container(60, 2, 2, 1, 1),
    //new Container(61, 3, 2, 1, 1),
    //new Container(62, 3, 1, 3, 2),
    //new Container(63, 3, 2, 3, 1),
};

//for (int z = 1; z < 55; z++) { Console.Write($"{z}, "); }


List<int> chr = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55 };
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


var packer = new PackerEMS();
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


var genetic = new GeneticAlgorithm(packer, 30, 30, 30, 2, 10);
var res = genetic.Run(sh, c);

var coor = res.PackedContainers;

//Console.WriteLine(weight);
foreach (var a in coor) { Console.WriteLine($"({a.Container.Id})),"); }
foreach (var a in coor) { Console.WriteLine($"(({a.X0}, {a.Y0}, {a.Z0}), ({a.X1 - a.X0}, {a.Y1 - a.Y0}, {a.Z1 - a.Z0})),"); }

foreach (var a in res.UnpackedWeightContainersId) { Console.WriteLine($"wei ({a})),"); }
foreach (var a in res.UnpackedSpaceContainersId) { Console.WriteLine($"sp ({a})),"); }

Console.WriteLine(res.TotalVolume);
Console.WriteLine(res.TotalWeight);

for (int i = 0; i < coor.Count; i++)
{
    for (int j = i + 1; j < coor.Count; j++)
    {
        if ((coor[i].X0 >= coor[j].X1 | coor[i].X1 <= coor[j].X0 | coor[i].Y0 >= coor[j].Y1 | coor[i].Y1 <= coor[j].Y0 | coor[i].Z0 >= coor[j].Z1 | coor[i].Z1 <= coor[j].Z0) == false)
        {
            Console.WriteLine($"oops overlaps {coor[i].Container.Id}, {coor[j].Container.Id}");
        }
    }
}