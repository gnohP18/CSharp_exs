using CSharp_Ex.Models;
using Models;

var postOffice = new PostOffice(1);
// 2
postOffice.AddData();
// 3
void ex3 () {
    var list = postOffice.GetAll().Where(_ => _ is Package);
    foreach (var item in list)
    {   
        System.Console.WriteLine(item.ToString());
    }
}

// 4
void ex4 () {
    var list = postOffice.GetAll().Where(_ => _.Customer.ReceiverName == "Tran Van B");
    foreach (var item in list)
    {   
        System.Console.WriteLine(item.ToString());
    }
}

void ex5 () {
    var list = postOffice.GetAll().OrderBy(_ => _.Customer.ReceiverName).ThenBy(_ => _.Fee);
    foreach (var item in list)
    {   
        System.Console.WriteLine(item.ToString());
    }
}

void ex6 () {
    var ids = postOffice.GetAll().Where(_ => _ is Letter).Select(_ => _.Id).ToList();
    postOffice.DeleteMany(ids);
    var list = postOffice.GetAll();
    foreach (var item in list)
    {   
        System.Console.WriteLine(item.ToString());
    }
}

void ex7 () {
    var sumLetterFee = postOffice.GetAll().Where(_ => _ is Letter).Sum(_ => _.GetFee());
    var sumPackageFee = postOffice.GetAll().Where(_ => _ is Package).Sum(_ => _.GetFee());
    System.Console.WriteLine($"Total Letter Fee = {sumLetterFee} \n Total Package Fee = {sumPackageFee}");
}

// -------------------- Resolve --------------------
// ex3();
// ex4();
// ex5();
// ex6();
// ex7();
// Nang cao ===> Su dung Enumrable
// foreach(Postage postage in postOffice) 
// {
//     System.Console.WriteLine(postage);
// }





